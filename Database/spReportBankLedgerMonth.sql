USE [waleedinventoryServer]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[spReportBankLedgerMonth]
(
    @AccountNo NVARCHAR(50),
    @MonthDate DATETIME = NULL,
    @ShowDebug BIT = 0
)
AS
BEGIN
    SET NOCOUNT ON;

    IF @MonthDate IS NULL SET @MonthDate = GETDATE();
    IF @AccountNo IS NULL SET @AccountNo = N'';

    DECLARE @FromDate DATETIME = DATEADD(MONTH, DATEDIFF(MONTH, 0, @MonthDate), 0);
    DECLARE @ToDate DATETIME = DATEADD(MONTH, 1, @FromDate);

    DECLARE @Ledger TABLE
    (
        RowId INT IDENTITY(1,1), TranDate DATETIME, SourceType NVARCHAR(50),
        BranchName NVARCHAR(100), DatabaseName NVARCHAR(200), ReferenceId INT,
        Name NVARCHAR(150), Detail NVARCHAR(4000), AccountNo NVARCHAR(50),
        ReceiveAmount NUMERIC(18,2), PaymentAmount NUMERIC(18,2)
    );

    DECLARE @Opening TABLE
    (
        ReceiveAmount NUMERIC(18,2), PaymentAmount NUMERIC(18,2)
    );

    DECLARE @BranchDatabases TABLE
    (
        BranchId INT, BranchName NVARCHAR(100), ConnectionString NVARCHAR(4000),
        DatabaseName NVARCHAR(200)
    );

    DECLARE @BranchId INT, @BranchName NVARCHAR(100), @ConnectionString NVARCHAR(4000),
            @DatabaseName NVARCHAR(200), @SQL NVARCHAR(MAX), @OpeningBalance NUMERIC(18,2);
    SET @OpeningBalance = 0;

    DECLARE branch_cursor CURSOR LOCAL FAST_FORWARD FOR
        SELECT B.Id, B.BranchName, CAST(B.ConnectionString AS NVARCHAR(4000))
        FROM dbo.Branches B;
    OPEN branch_cursor;
    FETCH NEXT FROM branch_cursor INTO @BranchId, @BranchName, @ConnectionString;

    WHILE @@FETCH_STATUS = 0
    BEGIN
        SET @ConnectionString = ISNULL(@ConnectionString, N'');
        SET @DatabaseName = N'';
        DECLARE @Xml XML;
        SET @Xml = TRY_CAST(
            N'<root><x>' + REPLACE((SELECT @ConnectionString AS [text()] FOR XML PATH('')), N';', N'</x><x>') + N'</x></root>'
            AS XML);

        IF @Xml IS NOT NULL
        BEGIN
            SELECT TOP 1 @DatabaseName = LTRIM(RTRIM(
                REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(X.N.value('.', 'NVARCHAR(4000)'),
                    N'Initial Catalog=', N''), N'initial catalog=', N''), N'Database=', N''),
                    N'database=', N''), N'INITIAL CATALOG=', N''), N'DATABASE=', N'')))
            FROM @Xml.nodes('/root/x') X(N)
            WHERE X.N.value('.', 'NVARCHAR(4000)') LIKE N'Initial Catalog=%'
               OR X.N.value('.', 'NVARCHAR(4000)') LIKE N'initial catalog=%'
               OR X.N.value('.', 'NVARCHAR(4000)') LIKE N'Database=%'
               OR X.N.value('.', 'NVARCHAR(4000)') LIKE N'database=%';
        END;

        SET @DatabaseName = REPLACE(REPLACE(REPLACE(REPLACE(LTRIM(RTRIM(ISNULL(@DatabaseName, N''))), N'[', N''), N']', N''), N'"', N''), N'''', N'');
        IF @DatabaseName <> N''
            INSERT @BranchDatabases VALUES (@BranchId, @BranchName, @ConnectionString, @DatabaseName);

        FETCH NEXT FROM branch_cursor INTO @BranchId, @BranchName, @ConnectionString;
    END;
    CLOSE branch_cursor;
    DEALLOCATE branch_cursor;

    DECLARE branch_ledger_cursor CURSOR LOCAL FAST_FORWARD FOR
        SELECT BranchId, BranchName, ConnectionString, DatabaseName FROM @BranchDatabases;
    OPEN branch_ledger_cursor;
    FETCH NEXT FROM branch_ledger_cursor INTO @BranchId, @BranchName, @ConnectionString, @DatabaseName;

    WHILE @@FETCH_STATUS = 0
    BEGIN
        IF DB_ID(@DatabaseName) IS NOT NULL
           AND OBJECT_ID(QUOTENAME(@DatabaseName) + N'.dbo.OwnerAccount', N'U') IS NOT NULL
        BEGIN
            SET @SQL = N'
                SELECT OA.[Date], N''Branch Receive'', @BranchName, @DatabaseNameParam, OA.Id,
                       ISNULL(OA.ReceiveBy, N''''), CAST(OA.Detail AS NVARCHAR(4000)), OA.AccountNo,
                       CAST(ISNULL(OA.Amount, 0) AS NUMERIC(18,2)), CAST(0 AS NUMERIC(18,2))
                FROM ' + QUOTENAME(@DatabaseName) + N'.dbo.OwnerAccount OA
                WHERE LTRIM(RTRIM(ISNULL(OA.AccountNo, N''''))) = LTRIM(RTRIM(@AccountNo))
                  AND OA.[Date] >= @FromDate AND OA.[Date] < @ToDate;';
            INSERT @Ledger (TranDate, SourceType, BranchName, DatabaseName, ReferenceId, Name, Detail, AccountNo, ReceiveAmount, PaymentAmount)
            EXEC sp_executesql @SQL,
                N'@BranchName NVARCHAR(100), @DatabaseNameParam NVARCHAR(200), @AccountNo NVARCHAR(50), @FromDate DATETIME, @ToDate DATETIME',
                @BranchName, @DatabaseName, @AccountNo, @FromDate, @ToDate;
        END;
        FETCH NEXT FROM branch_ledger_cursor INTO @BranchId, @BranchName, @ConnectionString, @DatabaseName;
    END;
    CLOSE branch_ledger_cursor;
    DEALLOCATE branch_ledger_cursor;

    INSERT @Ledger (TranDate, SourceType, BranchName, DatabaseName, ReferenceId, Name, Detail, AccountNo, ReceiveAmount, PaymentAmount)
    SELECT VP.PaymentDate, N'Vendor Payment', N'Central', DB_NAME(), VP.Id, VP.Name,
           CAST(VP.Description AS NVARCHAR(4000)), VP.AccountNo, 0, CAST(ISNULL(VP.Amount, 0) AS NUMERIC(18,2))
    FROM dbo.vVendorPayment VP
    WHERE LTRIM(RTRIM(ISNULL(VP.AccountNo, N''))) = LTRIM(RTRIM(@AccountNo))
      AND VP.PaymentDate >= @FromDate AND VP.PaymentDate < @ToDate;

    INSERT @Ledger (TranDate, SourceType, BranchName, DatabaseName, ReferenceId, Name, Detail, AccountNo, ReceiveAmount, PaymentAmount)
    SELECT VGP.PaymentDate, N'Vendor General Payment', N'Central', DB_NAME(), VGP.Id, VGP.Name,
           CAST(VGP.Description AS NVARCHAR(4000)), VGP.AccountNo, 0, CAST(ISNULL(VGP.Amount, 0) AS NUMERIC(18,2))
    FROM dbo.vVendorGPayment VGP
    WHERE LTRIM(RTRIM(ISNULL(VGP.AccountNo, N''))) = LTRIM(RTRIM(@AccountNo))
      AND VGP.PaymentDate >= @FromDate AND VGP.PaymentDate < @ToDate;

    /* Additional account pay/receive for the selected bank. */
    IF OBJECT_ID(N'dbo.AdditionalAccountTransaction', N'U') IS NOT NULL
    BEGIN
        INSERT @Ledger (TranDate, SourceType, BranchName, DatabaseName, ReferenceId, Name, Detail, AccountNo, ReceiveAmount, PaymentAmount)
        SELECT T.TransactionDate,
               CASE WHEN T.IsPayment = 1 THEN N'Additional Pay' ELSE N'Additional Receive' END,
               N'Central', DB_NAME(), T.Id, A.AccountName, CAST(T.Description AS NVARCHAR(4000)), B.AccountNo,
               CASE WHEN T.IsPayment = 0 THEN CAST(T.Amount AS NUMERIC(18,2)) ELSE 0 END,
               CASE WHEN T.IsPayment = 1 THEN CAST(T.Amount AS NUMERIC(18,2)) ELSE 0 END
        FROM dbo.AdditionalAccountTransaction T
        INNER JOIN dbo.AdditionalAccount A ON A.Id = T.AdditionalAccountId
        INNER JOIN dbo.Banks B ON B.Id = T.BankId
        WHERE LTRIM(RTRIM(ISNULL(B.AccountNo, N''))) = LTRIM(RTRIM(@AccountNo))
          AND T.TransactionDate >= @FromDate AND T.TransactionDate < @ToDate;
    END;

    /* Workshop account pay/receive for the selected bank. */
    IF OBJECT_ID(N'dbo.WorkshopTransaction', N'U') IS NOT NULL
    BEGIN
        INSERT @Ledger (TranDate, SourceType, BranchName, DatabaseName, ReferenceId, Name, Detail, AccountNo, ReceiveAmount, PaymentAmount)
        SELECT T.TransactionDate,
               CASE WHEN T.IsPayment = 1 THEN N'Workshop Pay' ELSE N'Workshop Receive' END,
               N'Central', DB_NAME(), T.Id, A.AccountName, CAST(T.Description AS NVARCHAR(4000)), B.AccountNo,
               CASE WHEN T.IsPayment = 0 THEN CAST(T.Amount AS NUMERIC(18,2)) ELSE 0 END,
               CASE WHEN T.IsPayment = 1 THEN CAST(T.Amount AS NUMERIC(18,2)) ELSE 0 END
        FROM dbo.WorkshopTransaction T
        INNER JOIN dbo.WorkshopAccount A ON A.Id = T.WorkshopAccountId
        INNER JOIN dbo.Banks B ON B.Id = T.BankId
        WHERE LTRIM(RTRIM(ISNULL(B.AccountNo, N''))) = LTRIM(RTRIM(@AccountNo))
          AND T.TransactionDate >= @FromDate AND T.TransactionDate < @ToDate;
    END;

    DECLARE opening_cursor CURSOR LOCAL FAST_FORWARD FOR
        SELECT BranchId, BranchName, ConnectionString, DatabaseName FROM @BranchDatabases;
    OPEN opening_cursor;
    FETCH NEXT FROM opening_cursor INTO @BranchId, @BranchName, @ConnectionString, @DatabaseName;
    WHILE @@FETCH_STATUS = 0
    BEGIN
        IF DB_ID(@DatabaseName) IS NOT NULL
           AND OBJECT_ID(QUOTENAME(@DatabaseName) + N'.dbo.OwnerAccount', N'U') IS NOT NULL
        BEGIN
            SET @SQL = N'
                SELECT CAST(ISNULL(SUM(OA.Amount), 0) AS NUMERIC(18,2)), CAST(0 AS NUMERIC(18,2))
                FROM ' + QUOTENAME(@DatabaseName) + N'.dbo.OwnerAccount OA
                WHERE LTRIM(RTRIM(ISNULL(OA.AccountNo, N''''))) = LTRIM(RTRIM(@AccountNo))
                  AND OA.[Date] < @FromDate;';
            INSERT @Opening (ReceiveAmount, PaymentAmount)
            EXEC sp_executesql @SQL, N'@AccountNo NVARCHAR(50), @FromDate DATETIME', @AccountNo, @FromDate;
        END;
        FETCH NEXT FROM opening_cursor INTO @BranchId, @BranchName, @ConnectionString, @DatabaseName;
    END;
    CLOSE opening_cursor;
    DEALLOCATE opening_cursor;

    INSERT @Opening SELECT 0, CAST(ISNULL(SUM(VP.Amount), 0) AS NUMERIC(18,2))
    FROM dbo.vVendorPayment VP
    WHERE LTRIM(RTRIM(ISNULL(VP.AccountNo, N''))) = LTRIM(RTRIM(@AccountNo)) AND VP.PaymentDate < @FromDate;
    INSERT @Opening SELECT 0, CAST(ISNULL(SUM(VGP.Amount), 0) AS NUMERIC(18,2))
    FROM dbo.vVendorGPayment VGP
    WHERE LTRIM(RTRIM(ISNULL(VGP.AccountNo, N''))) = LTRIM(RTRIM(@AccountNo)) AND VGP.PaymentDate < @FromDate;

    IF OBJECT_ID(N'dbo.AdditionalAccountTransaction', N'U') IS NOT NULL
        INSERT @Opening
        SELECT CAST(ISNULL(SUM(CASE WHEN T.IsPayment = 0 THEN T.Amount ELSE 0 END), 0) AS NUMERIC(18,2)),
               CAST(ISNULL(SUM(CASE WHEN T.IsPayment = 1 THEN T.Amount ELSE 0 END), 0) AS NUMERIC(18,2))
        FROM dbo.AdditionalAccountTransaction T INNER JOIN dbo.Banks B ON B.Id = T.BankId
        WHERE LTRIM(RTRIM(ISNULL(B.AccountNo, N''))) = LTRIM(RTRIM(@AccountNo)) AND T.TransactionDate < @FromDate;

    IF OBJECT_ID(N'dbo.WorkshopTransaction', N'U') IS NOT NULL
        INSERT @Opening
        SELECT CAST(ISNULL(SUM(CASE WHEN T.IsPayment = 0 THEN T.Amount ELSE 0 END), 0) AS NUMERIC(18,2)),
               CAST(ISNULL(SUM(CASE WHEN T.IsPayment = 1 THEN T.Amount ELSE 0 END), 0) AS NUMERIC(18,2))
        FROM dbo.WorkshopTransaction T INNER JOIN dbo.Banks B ON B.Id = T.BankId
        WHERE LTRIM(RTRIM(ISNULL(B.AccountNo, N''))) = LTRIM(RTRIM(@AccountNo)) AND T.TransactionDate < @FromDate;

    SELECT @OpeningBalance = ISNULL(SUM(ReceiveAmount), 0) - ISNULL(SUM(PaymentAmount), 0) FROM @Opening;

    ;WITH FinalLedger AS
    (
        SELECT 0 SortOrder, @FromDate TranDate, N'Balance Carry Forward' SourceType, N'Opening' BranchName,
               CAST(NULL AS NVARCHAR(200)) DatabaseName, CAST(NULL AS INT) ReferenceId, CAST(N'' AS NVARCHAR(150)) Name,
               CAST(N'Balance Carry Forward' AS NVARCHAR(4000)) Detail, CAST(@AccountNo AS NVARCHAR(50)) AccountNo,
               CAST(CASE WHEN @OpeningBalance >= 0 THEN @OpeningBalance ELSE 0 END AS NUMERIC(18,2)) ReceiveAmount,
               CAST(CASE WHEN @OpeningBalance < 0 THEN ABS(@OpeningBalance) ELSE 0 END AS NUMERIC(18,2)) PaymentAmount
        UNION ALL
        SELECT 1, TranDate, SourceType, BranchName, DatabaseName, ReferenceId, Name, Detail, AccountNo, ReceiveAmount, PaymentAmount
        FROM @Ledger
    )
    SELECT CAST(ROW_NUMBER() OVER (ORDER BY SortOrder, TranDate, SourceType, ISNULL(ReferenceId, 0), BranchName) AS INT) SrNo,
           TranDate, SourceType, BranchName, DatabaseName, ReferenceId, Name, Detail, AccountNo, ReceiveAmount, PaymentAmount,
           CAST(SUM(ReceiveAmount - PaymentAmount) OVER
               (ORDER BY SortOrder, TranDate, SourceType, ISNULL(ReferenceId, 0), BranchName ROWS UNBOUNDED PRECEDING)
               AS NUMERIC(18,2)) Balance
    FROM FinalLedger
    ORDER BY SortOrder, TranDate, SourceType, ISNULL(ReferenceId, 0), BranchName;
END;
GO
