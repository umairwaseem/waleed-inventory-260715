USE [waleedinventoryServer]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID(N'dbo.WorkshopAccount', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.WorkshopAccount
    (
        Id int IDENTITY(1,1) NOT NULL CONSTRAINT PK_WorkshopAccount PRIMARY KEY,
        AccountName nvarchar(150) NOT NULL,
        Notes nvarchar(500) NULL,
        CONSTRAINT UQ_WorkshopAccount_AccountName UNIQUE (AccountName)
    )
END
GO

IF OBJECT_ID(N'dbo.WorkshopTransaction', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.WorkshopTransaction
    (
        Id int IDENTITY(1,1) NOT NULL CONSTRAINT PK_WorkshopTransaction PRIMARY KEY,
        WorkshopAccountId int NOT NULL,
        TransactionDate datetime NOT NULL,
        Description nvarchar(500) NULL,
        Amount decimal(18,2) NOT NULL,
        CONSTRAINT CK_WorkshopTransaction_Amount CHECK (Amount > 0),
        CONSTRAINT FK_WorkshopTransaction_WorkshopAccount
            FOREIGN KEY (WorkshopAccountId) REFERENCES dbo.WorkshopAccount(Id)
    )

    CREATE INDEX IX_WorkshopTransaction_AccountDate
        ON dbo.WorkshopTransaction(WorkshopAccountId, TransactionDate)
    CREATE INDEX IX_WorkshopTransaction_Date
        ON dbo.WorkshopTransaction(TransactionDate)
END
GO

/* Add bank and payment direction to existing workshop transactions. */
IF COL_LENGTH(N'dbo.WorkshopTransaction', N'BankId') IS NULL
    ALTER TABLE dbo.WorkshopTransaction ADD BankId int NULL
GO

IF COL_LENGTH(N'dbo.WorkshopTransaction', N'IsPayment') IS NULL
    ALTER TABLE dbo.WorkshopTransaction ADD IsPayment bit NULL
GO

/*
   Existing rows are assigned the first available bank and Receive direction.
   Replace the SELECT below with a fixed bank ID if required, for example:
   SET @DefaultBankId = 1
*/
DECLARE @DefaultBankId int
SELECT TOP 1 @DefaultBankId = Id
FROM dbo.Banks
ORDER BY Id

IF EXISTS (SELECT 1 FROM dbo.WorkshopTransaction WHERE BankId IS NULL OR IsPayment IS NULL)
BEGIN
    IF @DefaultBankId IS NULL
    BEGIN
        THROW 50001, 'No bank exists in dbo.Banks. Create a bank before upgrading workshop transactions.', 1
    END

    UPDATE dbo.WorkshopTransaction
    SET BankId = ISNULL(BankId, @DefaultBankId),
        IsPayment = ISNULL(IsPayment, CONVERT(bit, 0))
    WHERE BankId IS NULL OR IsPayment IS NULL
END

/* A nullable indexed column must have its index removed before changing nullability. */
IF EXISTS (SELECT 1 FROM sys.columns WHERE object_id = OBJECT_ID(N'dbo.WorkshopTransaction') AND name = N'BankId' AND is_nullable = 1)
   AND EXISTS (SELECT 1 FROM sys.indexes WHERE object_id = OBJECT_ID(N'dbo.WorkshopTransaction') AND name = N'IX_WorkshopTransaction_BankId')
    DROP INDEX IX_WorkshopTransaction_BankId ON dbo.WorkshopTransaction

IF EXISTS (SELECT 1 FROM sys.columns WHERE object_id = OBJECT_ID(N'dbo.WorkshopTransaction') AND name = N'BankId' AND is_nullable = 1)
    ALTER TABLE dbo.WorkshopTransaction ALTER COLUMN BankId int NOT NULL

IF EXISTS (SELECT 1 FROM sys.columns WHERE object_id = OBJECT_ID(N'dbo.WorkshopTransaction') AND name = N'IsPayment' AND is_nullable = 1)
    ALTER TABLE dbo.WorkshopTransaction ALTER COLUMN IsPayment bit NOT NULL

IF NOT EXISTS (SELECT 1 FROM sys.foreign_keys WHERE name = N'FK_WorkshopTransaction_Banks')
    ALTER TABLE dbo.WorkshopTransaction ADD CONSTRAINT FK_WorkshopTransaction_Banks
        FOREIGN KEY (BankId) REFERENCES dbo.Banks(Id)

IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE object_id = OBJECT_ID(N'dbo.WorkshopTransaction') AND name = N'IX_WorkshopTransaction_BankId')
    CREATE INDEX IX_WorkshopTransaction_BankId ON dbo.WorkshopTransaction(BankId)
GO

IF OBJECT_ID(N'dbo.spWorkshopAccountList', N'P') IS NULL
    EXEC(N'CREATE PROCEDURE dbo.spWorkshopAccountList AS SELECT 1')
GO
ALTER PROCEDURE dbo.spWorkshopAccountList
AS
BEGIN
    SET NOCOUNT ON
    SELECT a.Id, a.AccountName, a.Notes
    FROM dbo.WorkshopAccount a
    ORDER BY a.AccountName
END
GO

IF OBJECT_ID(N'dbo.spCreateWorkshopAccount', N'P') IS NULL
    EXEC(N'CREATE PROCEDURE dbo.spCreateWorkshopAccount AS SELECT 1')
GO
ALTER PROCEDURE dbo.spCreateWorkshopAccount
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
    IF EXISTS (SELECT 1 FROM dbo.WorkshopAccount WHERE AccountName = @AccountName)
    BEGIN
        SET @Message = N'An account with this name already exists.'
        RETURN
    END

    BEGIN TRY
        INSERT dbo.WorkshopAccount(AccountName, Notes)
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

IF OBJECT_ID(N'dbo.spUpdateWorkshopAccount', N'P') IS NULL
    EXEC(N'CREATE PROCEDURE dbo.spUpdateWorkshopAccount AS SELECT 1')
GO
ALTER PROCEDURE dbo.spUpdateWorkshopAccount
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
    IF EXISTS (SELECT 1 FROM dbo.WorkshopAccount WHERE AccountName = @AccountName AND Id <> @Id)
    BEGIN
        SET @Message = N'An account with this name already exists.'
        RETURN
    END

    BEGIN TRY
        UPDATE dbo.WorkshopAccount
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

IF OBJECT_ID(N'dbo.spDeleteWorkshopAccount', N'P') IS NULL
    EXEC(N'CREATE PROCEDURE dbo.spDeleteWorkshopAccount AS SELECT 1')
GO
ALTER PROCEDURE dbo.spDeleteWorkshopAccount
    @Id int,
    @Success bit OUTPUT,
    @Message nvarchar(200) OUTPUT
AS
BEGIN
    SET NOCOUNT ON
    SET @Success = 0

    IF EXISTS (SELECT 1 FROM dbo.WorkshopTransaction WHERE WorkshopAccountId = @Id)
    BEGIN
        SET @Message = N'This account has transactions and cannot be deleted.'
        RETURN
    END

    BEGIN TRY
        DELETE dbo.WorkshopAccount WHERE Id = @Id
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

IF OBJECT_ID(N'dbo.spWorkshopTransactionList', N'P') IS NULL
    EXEC(N'CREATE PROCEDURE dbo.spWorkshopTransactionList AS SELECT 1')
GO
ALTER PROCEDURE dbo.spWorkshopTransactionList
AS
BEGIN
    SET NOCOUNT ON
    SELECT t.Id, t.WorkshopAccountId, a.AccountName, t.BankId,
           b.BankTitle, b.AccountNo, t.TransactionDate,
           t.Description, t.Amount, t.IsPayment,
           CASE WHEN t.IsPayment = 1 THEN N'Pay' ELSE N'Receive' END AS TransactionType
    FROM dbo.WorkshopTransaction t
    INNER JOIN dbo.WorkshopAccount a ON a.Id = t.WorkshopAccountId
    INNER JOIN dbo.Banks b ON b.Id = t.BankId
    ORDER BY t.Id DESC
END
GO

IF OBJECT_ID(N'dbo.spCreateWorkshopTransaction', N'P') IS NULL
    EXEC(N'CREATE PROCEDURE dbo.spCreateWorkshopTransaction AS SELECT 1')
GO
ALTER PROCEDURE dbo.spCreateWorkshopTransaction
    @WorkshopAccountId int,
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

    IF NOT EXISTS (SELECT 1 FROM dbo.WorkshopAccount WHERE Id = @WorkshopAccountId)
    BEGIN
        SET @Message = N'Please select a valid workshop account.'
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
        INSERT dbo.WorkshopTransaction(WorkshopAccountId, BankId, TransactionDate, Description, Amount, IsPayment)
        VALUES (@WorkshopAccountId, @BankId, @TransactionDate, NULLIF(LTRIM(RTRIM(@Description)), N''), @Amount, @IsPayment)
        SET @Id = SCOPE_IDENTITY()
        SET @Success = 1
        SET @Message = N'Transaction saved successfully.'
    END TRY
    BEGIN CATCH
        SET @Message = ERROR_MESSAGE()
    END CATCH
END
GO

IF OBJECT_ID(N'dbo.spUpdateWorkshopTransaction', N'P') IS NULL
    EXEC(N'CREATE PROCEDURE dbo.spUpdateWorkshopTransaction AS SELECT 1')
GO
ALTER PROCEDURE dbo.spUpdateWorkshopTransaction
    @Id int,
    @WorkshopAccountId int,
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

    IF NOT EXISTS (SELECT 1 FROM dbo.WorkshopAccount WHERE Id = @WorkshopAccountId)
    BEGIN
        SET @Message = N'Please select a valid workshop account.'
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
        UPDATE dbo.WorkshopTransaction
        SET WorkshopAccountId = @WorkshopAccountId,
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

IF OBJECT_ID(N'dbo.spDeleteWorkshopTransaction', N'P') IS NULL
    EXEC(N'CREATE PROCEDURE dbo.spDeleteWorkshopTransaction AS SELECT 1')
GO
ALTER PROCEDURE dbo.spDeleteWorkshopTransaction
    @Id int,
    @Success bit OUTPUT,
    @Message nvarchar(200) OUTPUT
AS
BEGIN
    SET NOCOUNT ON
    SET @Success = 0
    BEGIN TRY
        DELETE dbo.WorkshopTransaction WHERE Id = @Id
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

IF OBJECT_ID(N'dbo.spReportWorkshopLedger', N'P') IS NULL
    EXEC(N'CREATE PROCEDURE dbo.spReportWorkshopLedger AS SELECT 1')
GO
ALTER PROCEDURE dbo.spReportWorkshopLedger
    @FromDate datetime,
    @ToDate datetime
AS
BEGIN
    SET NOCOUNT ON

    DECLARE @StartDate datetime
    DECLARE @EndExclusive datetime
    SET @StartDate = CONVERT(datetime, CONVERT(varchar(10), @FromDate, 120))
    SET @EndExclusive = DATEADD(day, 1, CONVERT(datetime, CONVERT(varchar(10), @ToDate, 120)))

    IF @EndExclusive <= @StartDate
    BEGIN
        RAISERROR('To Date must be on or after From Date.', 16, 1)
        RETURN
    END

    CREATE TABLE #Ledger
    (
        SrNo int NOT NULL,
        TranDate datetime NULL,
        RowType nvarchar(20) NOT NULL,
        ReferenceId int NULL,
        AccountName nvarchar(150) NULL,
        BankId int NULL,
        BankTitle nvarchar(150) NULL,
        AccountNo nvarchar(50) NULL,
        Detail nvarchar(500) NULL,
        ReceiveAmount decimal(18,2) NOT NULL,
        PaymentAmount decimal(18,2) NOT NULL
    )

    INSERT #Ledger(SrNo, TranDate, RowType, ReferenceId, AccountName, BankId, BankTitle, AccountNo, Detail, ReceiveAmount, PaymentAmount)
    SELECT ROW_NUMBER() OVER (ORDER BY t.TransactionDate, t.Id),
           t.TransactionDate, N'Transaction', t.Id, a.AccountName, t.BankId, b.BankTitle, b.AccountNo,
           t.Description,
           CASE WHEN t.IsPayment = 0 THEN t.Amount ELSE 0 END,
           CASE WHEN t.IsPayment = 1 THEN t.Amount ELSE 0 END
    FROM dbo.WorkshopTransaction t
    INNER JOIN dbo.WorkshopAccount a ON a.Id = t.WorkshopAccountId
    INNER JOIN dbo.Banks b ON b.Id = t.BankId
    WHERE t.TransactionDate >= @StartDate
      AND t.TransactionDate < @EndExclusive

    INSERT #Ledger(SrNo, TranDate, RowType, ReferenceId, AccountName, BankId, BankTitle, AccountNo, Detail, ReceiveAmount, PaymentAmount)
    SELECT ISNULL(MAX(SrNo), 0) + 1, NULL, N'Total', NULL, N'Total', NULL, NULL, NULL, N'Total',
           ISNULL(SUM(ReceiveAmount), 0), ISNULL(SUM(PaymentAmount), 0)
    FROM #Ledger

    SELECT SrNo, TranDate, RowType, ReferenceId, AccountName, BankId, BankTitle, AccountNo,
           Detail, ReceiveAmount, PaymentAmount
    FROM #Ledger
    ORDER BY SrNo
END
GO
