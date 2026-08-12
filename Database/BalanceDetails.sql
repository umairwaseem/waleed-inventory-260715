USE [waleedinventoryServer]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID(N'dbo.BalanceDetail', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.BalanceDetail
    (
        Id int IDENTITY(1,1) NOT NULL CONSTRAINT PK_BalanceDetail PRIMARY KEY,
        Title nvarchar(150) NOT NULL,
        Notes nvarchar(500) NULL,
        CONSTRAINT UQ_BalanceDetail_Title UNIQUE (Title)
    )
END
GO

IF OBJECT_ID(N'dbo.BalanceDetailTransaction', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.BalanceDetailTransaction
    (
        Id int IDENTITY(1,1) NOT NULL CONSTRAINT PK_BalanceDetailTransaction PRIMARY KEY,
        BalanceDetailId int NOT NULL,
        TransactionDate datetime NOT NULL,
        Description nvarchar(500) NULL,
        Amount decimal(18,2) NOT NULL,
        CONSTRAINT CK_BalanceDetailTransaction_Amount CHECK (Amount > 0),
        CONSTRAINT FK_BalanceDetailTransaction_BalanceDetail
            FOREIGN KEY (BalanceDetailId) REFERENCES dbo.BalanceDetail(Id)
    )

    CREATE INDEX IX_BalanceDetailTransaction_DetailDate
        ON dbo.BalanceDetailTransaction(BalanceDetailId, TransactionDate)
    CREATE INDEX IX_BalanceDetailTransaction_Date
        ON dbo.BalanceDetailTransaction(TransactionDate)
END
GO

IF OBJECT_ID(N'dbo.spBalanceDetailList', N'P') IS NULL
    EXEC(N'CREATE PROCEDURE dbo.spBalanceDetailList AS SELECT 1')
GO
ALTER PROCEDURE dbo.spBalanceDetailList
AS
BEGIN
    SET NOCOUNT ON
    SELECT d.Id, d.Title, d.Notes
    FROM dbo.BalanceDetail d
    ORDER BY d.Title
END
GO

IF OBJECT_ID(N'dbo.spCreateBalanceDetail', N'P') IS NULL
    EXEC(N'CREATE PROCEDURE dbo.spCreateBalanceDetail AS SELECT 1')
GO
ALTER PROCEDURE dbo.spCreateBalanceDetail
    @Title nvarchar(150),
    @Notes nvarchar(500) = NULL,
    @Id int OUTPUT,
    @Success bit OUTPUT,
    @Message nvarchar(200) OUTPUT
AS
BEGIN
    SET NOCOUNT ON
    SET @Title = LTRIM(RTRIM(@Title))
    SET @Success = 0
    SET @Id = NULL

    IF ISNULL(@Title, N'') = N''
    BEGIN
        SET @Message = N'Title is required.'
        RETURN
    END
    IF EXISTS (SELECT 1 FROM dbo.BalanceDetail WHERE Title = @Title)
    BEGIN
        SET @Message = N'A balance detail with this title already exists.'
        RETURN
    END

    BEGIN TRY
        INSERT dbo.BalanceDetail(Title, Notes)
        VALUES (@Title, NULLIF(LTRIM(RTRIM(@Notes)), N''))
        SET @Id = SCOPE_IDENTITY()
        SET @Success = 1
        SET @Message = N'Balance detail saved successfully.'
    END TRY
    BEGIN CATCH
        SET @Message = ERROR_MESSAGE()
    END CATCH
END
GO

IF OBJECT_ID(N'dbo.spUpdateBalanceDetail', N'P') IS NULL
    EXEC(N'CREATE PROCEDURE dbo.spUpdateBalanceDetail AS SELECT 1')
GO
ALTER PROCEDURE dbo.spUpdateBalanceDetail
    @Id int,
    @Title nvarchar(150),
    @Notes nvarchar(500) = NULL,
    @Success bit OUTPUT,
    @Message nvarchar(200) OUTPUT
AS
BEGIN
    SET NOCOUNT ON
    SET @Title = LTRIM(RTRIM(@Title))
    SET @Success = 0

    IF ISNULL(@Title, N'') = N''
    BEGIN
        SET @Message = N'Title is required.'
        RETURN
    END
    IF EXISTS (SELECT 1 FROM dbo.BalanceDetail WHERE Title = @Title AND Id <> @Id)
    BEGIN
        SET @Message = N'A balance detail with this title already exists.'
        RETURN
    END

    BEGIN TRY
        UPDATE dbo.BalanceDetail
        SET Title = @Title,
            Notes = NULLIF(LTRIM(RTRIM(@Notes)), N'')
        WHERE Id = @Id

        IF @@ROWCOUNT = 0
            SET @Message = N'Balance detail was not found.'
        ELSE
        BEGIN
            SET @Success = 1
            SET @Message = N'Balance detail updated successfully.'
        END
    END TRY
    BEGIN CATCH
        SET @Message = ERROR_MESSAGE()
    END CATCH
END
GO

IF OBJECT_ID(N'dbo.spDeleteBalanceDetail', N'P') IS NULL
    EXEC(N'CREATE PROCEDURE dbo.spDeleteBalanceDetail AS SELECT 1')
GO
ALTER PROCEDURE dbo.spDeleteBalanceDetail
    @Id int,
    @Success bit OUTPUT,
    @Message nvarchar(200) OUTPUT
AS
BEGIN
    SET NOCOUNT ON
    SET @Success = 0

    IF EXISTS (SELECT 1 FROM dbo.BalanceDetailTransaction WHERE BalanceDetailId = @Id)
    BEGIN
        SET @Message = N'This balance detail has transactions and cannot be deleted.'
        RETURN
    END

    BEGIN TRY
        DELETE dbo.BalanceDetail WHERE Id = @Id
        IF @@ROWCOUNT = 0
            SET @Message = N'Balance detail was not found.'
        ELSE
        BEGIN
            SET @Success = 1
            SET @Message = N'Balance detail deleted successfully.'
        END
    END TRY
    BEGIN CATCH
        SET @Message = ERROR_MESSAGE()
    END CATCH
END
GO

IF OBJECT_ID(N'dbo.spBalanceDetailTransactionList', N'P') IS NULL
    EXEC(N'CREATE PROCEDURE dbo.spBalanceDetailTransactionList AS SELECT 1')
GO
ALTER PROCEDURE dbo.spBalanceDetailTransactionList
AS
BEGIN
    SET NOCOUNT ON
    SELECT t.Id, t.BalanceDetailId, d.Title, t.TransactionDate,
           t.Description, t.Amount
    FROM dbo.BalanceDetailTransaction t
    INNER JOIN dbo.BalanceDetail d ON d.Id = t.BalanceDetailId
    ORDER BY t.Id DESC
END
GO

IF OBJECT_ID(N'dbo.spCreateBalanceDetailTransaction', N'P') IS NULL
    EXEC(N'CREATE PROCEDURE dbo.spCreateBalanceDetailTransaction AS SELECT 1')
GO
ALTER PROCEDURE dbo.spCreateBalanceDetailTransaction
    @BalanceDetailId int,
    @TransactionDate datetime,
    @Description nvarchar(500) = NULL,
    @Amount decimal(18,2),
    @Id int OUTPUT,
    @Success bit OUTPUT,
    @Message nvarchar(200) OUTPUT
AS
BEGIN
    SET NOCOUNT ON
    SET @Success = 0
    SET @Id = NULL

    IF NOT EXISTS (SELECT 1 FROM dbo.BalanceDetail WHERE Id = @BalanceDetailId)
    BEGIN
        SET @Message = N'Please select a valid balance detail.'
        RETURN
    END
    IF @Amount <= 0
    BEGIN
        SET @Message = N'Amount must be greater than zero.'
        RETURN
    END

    BEGIN TRY
        INSERT dbo.BalanceDetailTransaction(BalanceDetailId, TransactionDate, Description, Amount)
        VALUES (@BalanceDetailId, @TransactionDate, NULLIF(LTRIM(RTRIM(@Description)), N''), @Amount)
        SET @Id = SCOPE_IDENTITY()
        SET @Success = 1
        SET @Message = N'Transaction saved successfully.'
    END TRY
    BEGIN CATCH
        SET @Message = ERROR_MESSAGE()
    END CATCH
END
GO

IF OBJECT_ID(N'dbo.spUpdateBalanceDetailTransaction', N'P') IS NULL
    EXEC(N'CREATE PROCEDURE dbo.spUpdateBalanceDetailTransaction AS SELECT 1')
GO
ALTER PROCEDURE dbo.spUpdateBalanceDetailTransaction
    @Id int,
    @BalanceDetailId int,
    @TransactionDate datetime,
    @Description nvarchar(500) = NULL,
    @Amount decimal(18,2),
    @Success bit OUTPUT,
    @Message nvarchar(200) OUTPUT
AS
BEGIN
    SET NOCOUNT ON
    SET @Success = 0

    IF NOT EXISTS (SELECT 1 FROM dbo.BalanceDetail WHERE Id = @BalanceDetailId)
    BEGIN
        SET @Message = N'Please select a valid balance detail.'
        RETURN
    END
    IF @Amount <= 0
    BEGIN
        SET @Message = N'Amount must be greater than zero.'
        RETURN
    END

    BEGIN TRY
        UPDATE dbo.BalanceDetailTransaction
        SET BalanceDetailId = @BalanceDetailId,
            TransactionDate = @TransactionDate,
            Description = NULLIF(LTRIM(RTRIM(@Description)), N''),
            Amount = @Amount
        WHERE Id = @Id

        IF @@ROWCOUNT = 0
            SET @Message = N'Transaction was not found.'
        ELSE
        BEGIN
            SET @Success = 1
            SET @Message = N'Transaction updated successfully.'
        END
    END TRY
    BEGIN CATCH
        SET @Message = ERROR_MESSAGE()
    END CATCH
END
GO

IF OBJECT_ID(N'dbo.spDeleteBalanceDetailTransaction', N'P') IS NULL
    EXEC(N'CREATE PROCEDURE dbo.spDeleteBalanceDetailTransaction AS SELECT 1')
GO
ALTER PROCEDURE dbo.spDeleteBalanceDetailTransaction
    @Id int,
    @Success bit OUTPUT,
    @Message nvarchar(200) OUTPUT
AS
BEGIN
    SET NOCOUNT ON
    SET @Success = 0
    BEGIN TRY
        DELETE dbo.BalanceDetailTransaction WHERE Id = @Id
        IF @@ROWCOUNT = 0
            SET @Message = N'Transaction was not found.'
        ELSE
        BEGIN
            SET @Success = 1
            SET @Message = N'Transaction deleted successfully.'
        END
    END TRY
    BEGIN CATCH
        SET @Message = ERROR_MESSAGE()
    END CATCH
END
GO

IF OBJECT_ID(N'dbo.spReportBalanceDetailSummary', N'P') IS NULL
    EXEC(N'CREATE PROCEDURE dbo.spReportBalanceDetailSummary AS SELECT 1')
GO
ALTER PROCEDURE dbo.spReportBalanceDetailSummary
    @FromDate datetime,
    @ToDate datetime
AS
BEGIN
    SET NOCOUNT ON

    DECLARE @StartDate datetime
    DECLARE @EndExclusive datetime
    DECLARE @AdditionalInPeriod decimal(18,2)
    DECLARE @BankPreviousBalance decimal(18,2)
    DECLARE @BankPeriodReceive decimal(18,2)
    DECLARE @BankPeriodPayment decimal(18,2)
    DECLARE @BankCurrentBalance decimal(18,2)
    DECLARE @ClosingBalance decimal(18,2)
    DECLARE @BalanceDetailTotal decimal(18,2)
    DECLARE @WorkshopTotal decimal(18,2)
    DECLARE @BranchId int
    DECLARE @BranchName nvarchar(100)
    DECLARE @ConnectionString nvarchar(4000)
    DECLARE @DatabaseName nvarchar(200)
    DECLARE @SQL nvarchar(max)

    SET @StartDate = CONVERT(datetime, CONVERT(varchar(10), @FromDate, 120))
    SET @EndExclusive = DATEADD(day, 1, CONVERT(datetime, CONVERT(varchar(10), @ToDate, 120)))

    IF @EndExclusive <= @StartDate
    BEGIN
        RAISERROR('To Date must be on or after From Date.', 16, 1)
        RETURN
    END

    SET @BankPreviousBalance = 0
    SET @BankPeriodReceive = 0
    SET @BankPeriodPayment = 0

    DECLARE @BranchDatabases TABLE
    (
        BranchId int,
        BranchName nvarchar(100),
        ConnectionString nvarchar(4000),
        DatabaseName nvarchar(200)
    )

    DECLARE branch_cursor CURSOR LOCAL FAST_FORWARD FOR
    SELECT B.Id, B.BranchName, CAST(B.ConnectionString AS nvarchar(4000))
    FROM dbo.Branches B

    OPEN branch_cursor
    FETCH NEXT FROM branch_cursor INTO @BranchId, @BranchName, @ConnectionString

    WHILE @@FETCH_STATUS = 0
    BEGIN
        SET @ConnectionString = ISNULL(@ConnectionString, N'')
        SET @DatabaseName = N''

        DECLARE @Xml xml
        SET @Xml = TRY_CAST(
            N'<root><x>' +
            REPLACE((SELECT @ConnectionString AS [text()] FOR XML PATH('')), N';', N'</x><x>') +
            N'</x></root>' AS xml
        )

        IF @Xml IS NOT NULL
        BEGIN
            SELECT TOP 1
                @DatabaseName =
                    LTRIM(RTRIM(
                        REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(
                            X.N.value('.', 'nvarchar(4000)'),
                            N'Initial Catalog=', N''),
                            N'initial catalog=', N''),
                            N'Database=', N''),
                            N'database=', N''),
                            N'INITIAL CATALOG=', N''),
                            N'DATABASE=', N'')
                    ))
            FROM @Xml.nodes('/root/x') X(N)
            WHERE X.N.value('.', 'nvarchar(4000)') LIKE N'Initial Catalog=%'
               OR X.N.value('.', 'nvarchar(4000)') LIKE N'initial catalog=%'
               OR X.N.value('.', 'nvarchar(4000)') LIKE N'Database=%'
               OR X.N.value('.', 'nvarchar(4000)') LIKE N'database=%'
        END

        SET @DatabaseName = LTRIM(RTRIM(ISNULL(@DatabaseName, N'')))
        SET @DatabaseName = REPLACE(@DatabaseName, N'[', N'')
        SET @DatabaseName = REPLACE(@DatabaseName, N']', N'')
        SET @DatabaseName = REPLACE(@DatabaseName, N'"', N'')
        SET @DatabaseName = REPLACE(@DatabaseName, N'''', N'')

        IF @DatabaseName <> N''
        BEGIN
            INSERT INTO @BranchDatabases(BranchId, BranchName, ConnectionString, DatabaseName)
            VALUES (@BranchId, @BranchName, @ConnectionString, @DatabaseName)
        END

        FETCH NEXT FROM branch_cursor INTO @BranchId, @BranchName, @ConnectionString
    END

    CLOSE branch_cursor
    DEALLOCATE branch_cursor

    DECLARE bank_branch_cursor CURSOR LOCAL FAST_FORWARD FOR
    SELECT BranchId, BranchName, ConnectionString, DatabaseName
    FROM @BranchDatabases

    OPEN bank_branch_cursor
    FETCH NEXT FROM bank_branch_cursor INTO @BranchId, @BranchName, @ConnectionString, @DatabaseName

    WHILE @@FETCH_STATUS = 0
    BEGIN
        IF DB_ID(@DatabaseName) IS NOT NULL
           AND OBJECT_ID(QUOTENAME(@DatabaseName) + N'.dbo.OwnerAccount', N'U') IS NOT NULL
        BEGIN
            SET @SQL = N'
                SELECT
                    @Previous = @Previous + CAST(ISNULL(SUM(CASE WHEN OA.[Date] < @StartDate THEN OA.Amount ELSE 0 END), 0) AS decimal(18,2)),
                    @PeriodReceive = @PeriodReceive + CAST(ISNULL(SUM(CASE WHEN OA.[Date] >= @StartDate AND OA.[Date] < @EndExclusive THEN OA.Amount ELSE 0 END), 0) AS decimal(18,2))
                FROM ' + QUOTENAME(@DatabaseName) + N'.dbo.OwnerAccount OA
                WHERE OA.[Date] < @EndExclusive
                  AND LTRIM(RTRIM(ISNULL(OA.AccountNo, N''''))) <> N'''';
            '

            EXEC sp_executesql
                @SQL,
                N'@StartDate datetime,
                  @EndExclusive datetime,
                  @Previous decimal(18,2) OUTPUT,
                  @PeriodReceive decimal(18,2) OUTPUT',
                @StartDate = @StartDate,
                @EndExclusive = @EndExclusive,
                @Previous = @BankPreviousBalance OUTPUT,
                @PeriodReceive = @BankPeriodReceive OUTPUT
        END

        FETCH NEXT FROM bank_branch_cursor INTO @BranchId, @BranchName, @ConnectionString, @DatabaseName
    END

    CLOSE bank_branch_cursor
    DEALLOCATE bank_branch_cursor

    SELECT @BankPreviousBalance = @BankPreviousBalance + ISNULL(SUM(VP.Amount), 0) * -1
    FROM dbo.vVendorPayment VP
    WHERE VP.PaymentDate < @StartDate
      AND LTRIM(RTRIM(ISNULL(VP.AccountNo, N''))) <> N''

    SELECT @BankPeriodPayment = @BankPeriodPayment + ISNULL(SUM(VP.Amount), 0)
    FROM dbo.vVendorPayment VP
    WHERE VP.PaymentDate >= @StartDate
      AND VP.PaymentDate < @EndExclusive
      AND LTRIM(RTRIM(ISNULL(VP.AccountNo, N''))) <> N''

    SELECT @BankPreviousBalance = @BankPreviousBalance + ISNULL(SUM(VGP.Amount), 0) * -1
    FROM dbo.vVendorGPayment VGP
    WHERE VGP.PaymentDate < @StartDate
      AND LTRIM(RTRIM(ISNULL(VGP.AccountNo, N''))) <> N''

    SELECT @BankPeriodPayment = @BankPeriodPayment + ISNULL(SUM(VGP.Amount), 0)
    FROM dbo.vVendorGPayment VGP
    WHERE VGP.PaymentDate >= @StartDate
      AND VGP.PaymentDate < @EndExclusive
      AND LTRIM(RTRIM(ISNULL(VGP.AccountNo, N''))) <> N''

    SELECT @AdditionalInPeriod = ISNULL(SUM(CASE WHEN IsPayment = 1 THEN -Amount ELSE Amount END), 0)
    FROM dbo.AdditionalAccountTransaction
    WHERE TransactionDate >= @StartDate
      AND TransactionDate < @EndExclusive

    SELECT @BalanceDetailTotal = ISNULL(SUM(Amount), 0)
    FROM dbo.BalanceDetailTransaction
    WHERE TransactionDate >= @StartDate
      AND TransactionDate < @EndExclusive

    SELECT @WorkshopTotal = ISNULL(SUM(Amount), 0)
    FROM dbo.WorkshopTransaction
    WHERE TransactionDate >= @StartDate
      AND TransactionDate < @EndExclusive

    SET @BankCurrentBalance = @BankPreviousBalance + @BankPeriodReceive - @BankPeriodPayment
    SET @ClosingBalance = @BankCurrentBalance - @AdditionalInPeriod

    CREATE TABLE #Summary
    (
        RowType nvarchar(30) NOT NULL,
        DisplayOrder int NOT NULL,
        TranDate datetime NULL,
        Title nvarchar(150) NULL,
        Description nvarchar(500) NULL,
        Amount decimal(18,2) NULL,
        Balance decimal(18,2) NULL,
        BalanceDetailId int NULL,
        ActionText nvarchar(50) NULL
    )

    INSERT #Summary(RowType, DisplayOrder, TranDate, Title, Description, Amount, Balance, BalanceDetailId, ActionText)
    VALUES
        (N'Summary', 10, @StartDate, N'Previous Bank Balance', N'Bank receives before From Date minus bank payments before From Date', NULL, @BankPreviousBalance, NULL, N'Filter'),
        (N'Summary', 20, DATEADD(ms, -3, @EndExclusive), N'Current Bank Balance', N'Previous Bank Balance plus selected-date bank receives minus selected-date bank payments', NULL, @BankCurrentBalance, NULL, N'Filter'),
        (N'Summary', 30, @StartDate, N'Additional Balance', N'Additional Account signed balance within selected dates', @AdditionalInPeriod, NULL, NULL, N'Filter'),
        (N'Summary', 40, DATEADD(ms, -3, @EndExclusive), N'Closing Balance', N'Current Bank Balance - Additional Balance', NULL, @ClosingBalance, NULL, N'Filter'),
        (N'Blank', 50, NULL, NULL, NULL, NULL, NULL, NULL, NULL)

    INSERT #Summary(RowType, DisplayOrder, TranDate, Title, Description, Amount, Balance, BalanceDetailId, ActionText)
    SELECT N'Detail',
           100 + ROW_NUMBER() OVER (ORDER BY TransactionDate, SourceId, Title),
           TransactionDate,
           Title,
           Description,
           Amount,
           NULL,
           BalanceDetailId,
           ActionText
    FROM
    (
        SELECT t.TransactionDate, t.Id AS SourceId, d.Title, t.Description, t.Amount,
               t.BalanceDetailId, N'Filter' AS ActionText
        FROM dbo.BalanceDetailTransaction t
        INNER JOIN dbo.BalanceDetail d ON d.Id = t.BalanceDetailId
        WHERE t.TransactionDate >= @StartDate
          AND t.TransactionDate < @EndExclusive
    ) BalanceRows

    INSERT #Summary(RowType, DisplayOrder, TranDate, Title, Description, Amount, Balance, BalanceDetailId, ActionText)
    SELECT N'Summary',
           ISNULL(MAX(DisplayOrder), 50) + 1,
           @EndExclusive,
           N'Balance Detail Total',
           N'Total balance detail transactions within selected dates',
           NULL,
           @BalanceDetailTotal,
           NULL,
           N''
    FROM #Summary
    WHERE RowType = N'Detail'

    INSERT #Summary(RowType, DisplayOrder, TranDate, Title, Description, Amount, Balance, BalanceDetailId, ActionText)
    SELECT N'Detail',
           ISNULL((SELECT MAX(DisplayOrder) FROM #Summary), 50) +
               ROW_NUMBER() OVER (ORDER BY TransactionDate, SourceId, Title),
           TransactionDate,
           Title,
           Description,
           Amount,
           NULL,
           BalanceDetailId,
           ActionText
    FROM
    (
        SELECT t.TransactionDate, t.Id AS SourceId, a.AccountName AS Title,
               t.Description, t.Amount, NULL AS BalanceDetailId, N'' AS ActionText
        FROM dbo.WorkshopTransaction t
        INNER JOIN dbo.WorkshopAccount a ON a.Id = t.WorkshopAccountId
        WHERE t.TransactionDate >= @StartDate
          AND t.TransactionDate < @EndExclusive
    ) WorkshopRows

    INSERT #Summary(RowType, DisplayOrder, TranDate, Title, Description, Amount, Balance, BalanceDetailId, ActionText)
    SELECT N'Summary',
           ISNULL(MAX(DisplayOrder), 50) + 1,
           @EndExclusive,
           N'Workshop Total',
           N'Total workshop transactions within selected dates',
           NULL,
           @WorkshopTotal,
           NULL,
           N''
    FROM #Summary
    WHERE RowType = N'Detail'

    SELECT RowType, DisplayOrder, TranDate, Title, Description, Amount, Balance, BalanceDetailId, ActionText
    FROM #Summary
    ORDER BY DisplayOrder
END
GO

IF NOT EXISTS (SELECT 1 FROM dbo.UserForms WHERE FromName = N'Balance Detail')
    INSERT dbo.UserForms(FromName, Report) VALUES (N'Balance Detail', 0)
GO
IF NOT EXISTS (SELECT 1 FROM dbo.UserForms WHERE FromName = N'Balance Detail Transaction')
    INSERT dbo.UserForms(FromName, Report) VALUES (N'Balance Detail Transaction', 0)
GO
IF NOT EXISTS (SELECT 1 FROM dbo.UserForms WHERE FromName = N'Balance Detail Summary')
    INSERT dbo.UserForms(FromName, Report) VALUES (N'Balance Detail Summary', 1)
GO
