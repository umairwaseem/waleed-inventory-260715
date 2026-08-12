USE [waleedinventoryServer]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID(N'dbo.AdditionalAccount', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.AdditionalAccount
    (
        Id int IDENTITY(1,1) NOT NULL CONSTRAINT PK_AdditionalAccount PRIMARY KEY,
        AccountName nvarchar(150) NOT NULL,
        Notes nvarchar(500) NULL,
        CONSTRAINT UQ_AdditionalAccount_AccountName UNIQUE (AccountName)
    )
END
GO

IF OBJECT_ID(N'dbo.AdditionalAccountTransaction', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.AdditionalAccountTransaction
    (
        Id int IDENTITY(1,1) NOT NULL CONSTRAINT PK_AdditionalAccountTransaction PRIMARY KEY,
        AdditionalAccountId int NOT NULL,
        BankId int NOT NULL,
        TransactionDate datetime NOT NULL,
        Description nvarchar(500) NULL,
        Amount decimal(18,2) NOT NULL,
        IsPayment bit NOT NULL,
        CONSTRAINT CK_AdditionalAccountTransaction_Amount CHECK (Amount > 0),
        CONSTRAINT FK_AdditionalAccountTransaction_AdditionalAccount
            FOREIGN KEY (AdditionalAccountId) REFERENCES dbo.AdditionalAccount(Id),
        CONSTRAINT FK_AdditionalAccountTransaction_Banks
            FOREIGN KEY (BankId) REFERENCES dbo.Banks(Id)
    )

    CREATE INDEX IX_AdditionalAccountTransaction_AccountDate
        ON dbo.AdditionalAccountTransaction(AdditionalAccountId, TransactionDate)
    CREATE INDEX IX_AdditionalAccountTransaction_BankId
        ON dbo.AdditionalAccountTransaction(BankId)
END
GO

IF COL_LENGTH(N'dbo.AdditionalAccountTransaction', N'BankId') IS NULL
    ALTER TABLE dbo.AdditionalAccountTransaction ADD BankId int NULL
GO

DECLARE @DefaultBankId int
-- Set this value when upgrading existing transactions.
-- Example: SET @DefaultBankId = 1
SET @DefaultBankId = NULL

IF EXISTS (SELECT 1 FROM dbo.AdditionalAccountTransaction WHERE BankId IS NULL)
BEGIN
    IF @DefaultBankId IS NULL OR NOT EXISTS (SELECT 1 FROM dbo.Banks WHERE Id = @DefaultBankId)
    BEGIN
        RAISERROR('Set @DefaultBankId to a valid dbo.Banks.Id before upgrading existing Additional Account transactions.', 16, 1)
        RETURN
    END

    UPDATE dbo.AdditionalAccountTransaction
    SET BankId = @DefaultBankId
    WHERE BankId IS NULL
END

IF EXISTS (SELECT 1 FROM sys.columns WHERE object_id = OBJECT_ID(N'dbo.AdditionalAccountTransaction') AND name = N'BankId' AND is_nullable = 1)
    ALTER TABLE dbo.AdditionalAccountTransaction ALTER COLUMN BankId int NOT NULL

IF NOT EXISTS (SELECT 1 FROM sys.foreign_keys WHERE name = N'FK_AdditionalAccountTransaction_Banks')
    ALTER TABLE dbo.AdditionalAccountTransaction ADD CONSTRAINT FK_AdditionalAccountTransaction_Banks
        FOREIGN KEY (BankId) REFERENCES dbo.Banks(Id)

IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE object_id = OBJECT_ID(N'dbo.AdditionalAccountTransaction') AND name = N'IX_AdditionalAccountTransaction_BankId')
    CREATE INDEX IX_AdditionalAccountTransaction_BankId ON dbo.AdditionalAccountTransaction(BankId)

IF COL_LENGTH(N'dbo.AdditionalAccount', N'BankId') IS NOT NULL
BEGIN
    IF EXISTS (SELECT 1 FROM sys.foreign_keys WHERE name = N'FK_AdditionalAccount_Banks')
        ALTER TABLE dbo.AdditionalAccount DROP CONSTRAINT FK_AdditionalAccount_Banks
    IF EXISTS (SELECT 1 FROM sys.indexes WHERE object_id = OBJECT_ID(N'dbo.AdditionalAccount') AND name = N'IX_AdditionalAccount_BankId')
        DROP INDEX IX_AdditionalAccount_BankId ON dbo.AdditionalAccount
    ALTER TABLE dbo.AdditionalAccount DROP COLUMN BankId
END
GO

IF OBJECT_ID(N'dbo.spAdditionalAccountList', N'P') IS NULL
    EXEC(N'CREATE PROCEDURE dbo.spAdditionalAccountList AS SELECT 1')
GO
ALTER PROCEDURE dbo.spAdditionalAccountList
AS
BEGIN
    SET NOCOUNT ON
    SELECT a.Id, a.AccountName, a.Notes
    FROM dbo.AdditionalAccount a
    ORDER BY a.AccountName
END
GO

IF OBJECT_ID(N'dbo.spCreateAdditionalAccount', N'P') IS NULL
    EXEC(N'CREATE PROCEDURE dbo.spCreateAdditionalAccount AS SELECT 1')
GO
ALTER PROCEDURE dbo.spCreateAdditionalAccount
    @AccountName nvarchar(150),
    @Notes nvarchar(500) = NULL,
    @Id int OUTPUT,
    @Success bit OUTPUT,
    @Message nvarchar(200) OUTPUT
AS
BEGIN
    SET NOCOUNT ON
    SET @AccountName = LTRIM(RTRIM(@AccountName))
    SET @Success = 0
    SET @Id = NULL

    IF ISNULL(@AccountName, N'') = N''
    BEGIN
        SET @Message = N'Account name is required.'
        RETURN
    END

    IF EXISTS (SELECT 1 FROM dbo.AdditionalAccount WHERE AccountName = @AccountName)
    BEGIN
        SET @Message = N'An account with this name already exists.'
        RETURN
    END

    BEGIN TRY
        INSERT dbo.AdditionalAccount(AccountName, Notes)
        VALUES (@AccountName, NULLIF(LTRIM(RTRIM(@Notes)), N''))
        SET @Id = SCOPE_IDENTITY()
        SET @Success = 1
        SET @Message = N'Account saved successfully.'
    END TRY
    BEGIN CATCH
        SET @Message = ERROR_MESSAGE()
    END CATCH
END
GO

IF OBJECT_ID(N'dbo.spUpdateAdditionalAccount', N'P') IS NULL
    EXEC(N'CREATE PROCEDURE dbo.spUpdateAdditionalAccount AS SELECT 1')
GO
ALTER PROCEDURE dbo.spUpdateAdditionalAccount
    @Id int,
    @AccountName nvarchar(150),
    @Notes nvarchar(500) = NULL,
    @Success bit OUTPUT,
    @Message nvarchar(200) OUTPUT
AS
BEGIN
    SET NOCOUNT ON
    SET @AccountName = LTRIM(RTRIM(@AccountName))
    SET @Success = 0

    IF ISNULL(@AccountName, N'') = N''
    BEGIN
        SET @Message = N'Account name is required.'
        RETURN
    END

    IF EXISTS (SELECT 1 FROM dbo.AdditionalAccount WHERE AccountName = @AccountName AND Id <> @Id)
    BEGIN
        SET @Message = N'An account with this name already exists.'
        RETURN
    END

    BEGIN TRY
        UPDATE dbo.AdditionalAccount
        SET AccountName = @AccountName,
            Notes = NULLIF(LTRIM(RTRIM(@Notes)), N'')
        WHERE Id = @Id

        IF @@ROWCOUNT = 0
            SET @Message = N'Account was not found.'
        ELSE
        BEGIN
            SET @Success = 1
            SET @Message = N'Account updated successfully.'
        END
    END TRY
    BEGIN CATCH
        SET @Message = ERROR_MESSAGE()
    END CATCH
END
GO

IF OBJECT_ID(N'dbo.spDeleteAdditionalAccount', N'P') IS NULL
    EXEC(N'CREATE PROCEDURE dbo.spDeleteAdditionalAccount AS SELECT 1')
GO
ALTER PROCEDURE dbo.spDeleteAdditionalAccount
    @Id int,
    @Success bit OUTPUT,
    @Message nvarchar(200) OUTPUT
AS
BEGIN
    SET NOCOUNT ON
    SET @Success = 0

    IF EXISTS (SELECT 1 FROM dbo.AdditionalAccountTransaction WHERE AdditionalAccountId = @Id)
    BEGIN
        SET @Message = N'This account has transactions and cannot be deleted.'
        RETURN
    END

    BEGIN TRY
        DELETE dbo.AdditionalAccount WHERE Id = @Id
        IF @@ROWCOUNT = 0
            SET @Message = N'Account was not found.'
        ELSE
        BEGIN
            SET @Success = 1
            SET @Message = N'Account deleted successfully.'
        END
    END TRY
    BEGIN CATCH
        SET @Message = ERROR_MESSAGE()
    END CATCH
END
GO

IF OBJECT_ID(N'dbo.spAdditionalAccountTransactionList', N'P') IS NULL
    EXEC(N'CREATE PROCEDURE dbo.spAdditionalAccountTransactionList AS SELECT 1')
GO
ALTER PROCEDURE dbo.spAdditionalAccountTransactionList
AS
BEGIN
    SET NOCOUNT ON
    SELECT t.Id, t.AdditionalAccountId, a.AccountName, t.BankId,
           b.BankTitle, b.AccountNo, t.TransactionDate,
           t.Description, t.Amount, t.IsPayment
    FROM dbo.AdditionalAccountTransaction t
    INNER JOIN dbo.AdditionalAccount a ON a.Id = t.AdditionalAccountId
    INNER JOIN dbo.Banks b ON b.Id = t.BankId
    ORDER BY t.Id DESC
END
GO

IF OBJECT_ID(N'dbo.spCreateAdditionalAccountTransaction', N'P') IS NULL
    EXEC(N'CREATE PROCEDURE dbo.spCreateAdditionalAccountTransaction AS SELECT 1')
GO
ALTER PROCEDURE dbo.spCreateAdditionalAccountTransaction
    @AdditionalAccountId int,
    @BankId int,
    @TransactionDate datetime,
    @Description nvarchar(500) = NULL,
    @Amount decimal(18,2),
    @IsPayment bit,
    @Id int OUTPUT,
    @Success bit OUTPUT,
    @Message nvarchar(200) OUTPUT
AS
BEGIN
    SET NOCOUNT ON
    SET @Success = 0
    SET @Id = NULL

    IF NOT EXISTS (SELECT 1 FROM dbo.AdditionalAccount WHERE Id = @AdditionalAccountId)
    BEGIN
        SET @Message = N'Please select a valid account.'
        RETURN
    END
    IF NOT EXISTS (SELECT 1 FROM dbo.Banks WHERE Id = @BankId)
    BEGIN
        SET @Message = N'Please select a valid bank.'
        RETURN
    END
    IF @Amount <= 0
    BEGIN
        SET @Message = N'Amount must be greater than zero.'
        RETURN
    END

    BEGIN TRY
        INSERT dbo.AdditionalAccountTransaction
            (AdditionalAccountId, BankId, TransactionDate, Description, Amount, IsPayment)
        VALUES
            (@AdditionalAccountId, @BankId, @TransactionDate, NULLIF(LTRIM(RTRIM(@Description)), N''), @Amount, @IsPayment)
        SET @Id = SCOPE_IDENTITY()
        SET @Success = 1
        SET @Message = N'Transaction saved successfully.'
    END TRY
    BEGIN CATCH
        SET @Message = ERROR_MESSAGE()
    END CATCH
END
GO

IF OBJECT_ID(N'dbo.spUpdateAdditionalAccountTransaction', N'P') IS NULL
    EXEC(N'CREATE PROCEDURE dbo.spUpdateAdditionalAccountTransaction AS SELECT 1')
GO
ALTER PROCEDURE dbo.spUpdateAdditionalAccountTransaction
    @Id int,
    @AdditionalAccountId int,
    @BankId int,
    @TransactionDate datetime,
    @Description nvarchar(500) = NULL,
    @Amount decimal(18,2),
    @IsPayment bit,
    @Success bit OUTPUT,
    @Message nvarchar(200) OUTPUT
AS
BEGIN
    SET NOCOUNT ON
    SET @Success = 0

    IF NOT EXISTS (SELECT 1 FROM dbo.AdditionalAccount WHERE Id = @AdditionalAccountId)
    BEGIN
        SET @Message = N'Please select a valid account.'
        RETURN
    END
    IF NOT EXISTS (SELECT 1 FROM dbo.Banks WHERE Id = @BankId)
    BEGIN
        SET @Message = N'Please select a valid bank.'
        RETURN
    END
    IF @Amount <= 0
    BEGIN
        SET @Message = N'Amount must be greater than zero.'
        RETURN
    END

    BEGIN TRY
        UPDATE dbo.AdditionalAccountTransaction
        SET AdditionalAccountId = @AdditionalAccountId,
            BankId = @BankId,
            TransactionDate = @TransactionDate,
            Description = NULLIF(LTRIM(RTRIM(@Description)), N''),
            Amount = @Amount,
            IsPayment = @IsPayment
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

IF OBJECT_ID(N'dbo.spDeleteAdditionalAccountTransaction', N'P') IS NULL
    EXEC(N'CREATE PROCEDURE dbo.spDeleteAdditionalAccountTransaction AS SELECT 1')
GO
ALTER PROCEDURE dbo.spDeleteAdditionalAccountTransaction
    @Id int,
    @Success bit OUTPUT,
    @Message nvarchar(200) OUTPUT
AS
BEGIN
    SET NOCOUNT ON
    SET @Success = 0
    BEGIN TRY
        DELETE dbo.AdditionalAccountTransaction WHERE Id = @Id
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

IF OBJECT_ID(N'dbo.spReportAdditionalAccountLedger', N'P') IS NULL
    EXEC(N'CREATE PROCEDURE dbo.spReportAdditionalAccountLedger AS SELECT 1')
GO
ALTER PROCEDURE dbo.spReportAdditionalAccountLedger
    @AdditionalAccountId int,
    @FromDate datetime,
    @ToDate datetime
AS
BEGIN
    SET NOCOUNT ON

    DECLARE @StartDate datetime
    DECLARE @EndExclusive datetime
    DECLARE @OpeningBalance decimal(18,2)
    DECLARE @AccountName nvarchar(150)

    SET @StartDate = CONVERT(datetime, CONVERT(varchar(10), @FromDate, 120))
    SET @EndExclusive = DATEADD(day, 1, CONVERT(datetime, CONVERT(varchar(10), @ToDate, 120)))

    IF @EndExclusive <= @StartDate
    BEGIN
        RAISERROR('To Date must be on or after From Date.', 16, 1)
        RETURN
    END

    SELECT @AccountName = a.AccountName
    FROM dbo.AdditionalAccount a
    WHERE a.Id = @AdditionalAccountId

    IF @AccountName IS NULL
    BEGIN
        RAISERROR('Please select a valid Additional Account.', 16, 1)
        RETURN
    END

    SELECT @OpeningBalance = ISNULL(SUM(CASE WHEN IsPayment = 1 THEN -Amount ELSE Amount END), 0)
    FROM dbo.AdditionalAccountTransaction
    WHERE AdditionalAccountId = @AdditionalAccountId
      AND TransactionDate < @StartDate

    CREATE TABLE #Ledger
    (
        RowNo int IDENTITY(1,1) NOT NULL,
        ReferenceId int NOT NULL,
        TranDate datetime NOT NULL,
        BankId int NOT NULL,
        BankTitle nvarchar(150) NOT NULL,
        AccountNo nvarchar(50) NULL,
        Detail nvarchar(500) NULL,
        ReceiveAmount decimal(18,2) NOT NULL,
        PaymentAmount decimal(18,2) NOT NULL
    )

    INSERT #Ledger(ReferenceId, TranDate, BankId, BankTitle, AccountNo, Detail, ReceiveAmount, PaymentAmount)
    SELECT TOP 2147483647 t.Id, t.TransactionDate, t.BankId, b.BankTitle, b.AccountNo, t.Description,
           CASE WHEN t.IsPayment = 0 THEN t.Amount ELSE 0 END,
           CASE WHEN t.IsPayment = 1 THEN t.Amount ELSE 0 END
    FROM dbo.AdditionalAccountTransaction t
    INNER JOIN dbo.Banks b ON b.Id = t.BankId
    WHERE t.AdditionalAccountId = @AdditionalAccountId
      AND t.TransactionDate >= @StartDate
      AND t.TransactionDate < @EndExclusive
    ORDER BY t.TransactionDate, t.Id

    SELECT SrNo, TranDate, SourceType, ReferenceId, AccountName, BankId,
           BankTitle, AccountNo, Detail, ReceiveAmount, PaymentAmount, Balance
    FROM
    (
        SELECT 0 AS SrNo, @StartDate AS TranDate, N'Opening Balance' AS SourceType,
               0 AS ReferenceId, @AccountName AS AccountName, CONVERT(int, NULL) AS BankId,
               CONVERT(nvarchar(150), NULL) AS BankTitle, CONVERT(nvarchar(50), NULL) AS AccountNo,
               N'Opening Balance' AS Detail,
               CONVERT(decimal(18,2), 0) AS ReceiveAmount,
               CONVERT(decimal(18,2), 0) AS PaymentAmount,
               @OpeningBalance AS Balance
        UNION ALL
        SELECT l.RowNo, l.TranDate, N'Transaction', l.ReferenceId,
               @AccountName, l.BankId, l.BankTitle, l.AccountNo, l.Detail,
               l.ReceiveAmount, l.PaymentAmount,
               @OpeningBalance +
                   (SELECT SUM(x.ReceiveAmount - x.PaymentAmount)
                    FROM #Ledger x WHERE x.RowNo <= l.RowNo)
        FROM #Ledger l
    ) ledger
    ORDER BY SrNo
END
GO

IF NOT EXISTS (SELECT 1 FROM dbo.UserForms WHERE FromName = N'Additional Account List')
    INSERT dbo.UserForms(FromName, Report) VALUES (N'Additional Account List', 0)
GO
IF NOT EXISTS (SELECT 1 FROM dbo.UserForms WHERE FromName = N'Additional Banking')
    INSERT dbo.UserForms(FromName, Report) VALUES (N'Additional Banking', 0)
GO
