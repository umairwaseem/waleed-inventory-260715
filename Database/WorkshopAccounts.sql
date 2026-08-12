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
    SELECT t.Id, t.WorkshopAccountId, a.AccountName, t.TransactionDate,
           t.Description, t.Amount
    FROM dbo.WorkshopTransaction t
    INNER JOIN dbo.WorkshopAccount a ON a.Id = t.WorkshopAccountId
    ORDER BY t.Id DESC
END
GO

IF OBJECT_ID(N'dbo.spCreateWorkshopTransaction', N'P') IS NULL
    EXEC(N'CREATE PROCEDURE dbo.spCreateWorkshopTransaction AS SELECT 1')
GO
ALTER PROCEDURE dbo.spCreateWorkshopTransaction
    @WorkshopAccountId int,
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

    IF NOT EXISTS (SELECT 1 FROM dbo.WorkshopAccount WHERE Id = @WorkshopAccountId)
    BEGIN
        SET @Message = N'Please select a valid workshop account.'
        RETURN
    END
    IF @Amount <= 0
    BEGIN
        SET @Message = N'Amount must be greater than zero.'
        RETURN
    END

    BEGIN TRY
        INSERT dbo.WorkshopTransaction(WorkshopAccountId, TransactionDate, Description, Amount)
        VALUES (@WorkshopAccountId, @TransactionDate, NULLIF(LTRIM(RTRIM(@Description)), N''), @Amount)
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
    @TransactionDate datetime,
    @Description nvarchar(500) = NULL,
    @Amount decimal(18,2),
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
    IF @Amount <= 0
    BEGIN
        SET @Message = N'Amount must be greater than zero.'
        RETURN
    END

    BEGIN TRY
        UPDATE dbo.WorkshopTransaction
        SET WorkshopAccountId = @WorkshopAccountId,
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
        Detail nvarchar(500) NULL,
        Amount decimal(18,2) NOT NULL
    )

    INSERT #Ledger(SrNo, TranDate, RowType, ReferenceId, AccountName, Detail, Amount)
    SELECT ROW_NUMBER() OVER (ORDER BY t.TransactionDate, t.Id),
           t.TransactionDate, N'Transaction', t.Id, a.AccountName, t.Description, t.Amount
    FROM dbo.WorkshopTransaction t
    INNER JOIN dbo.WorkshopAccount a ON a.Id = t.WorkshopAccountId
    WHERE t.TransactionDate >= @StartDate
      AND t.TransactionDate < @EndExclusive

    INSERT #Ledger(SrNo, TranDate, RowType, ReferenceId, AccountName, Detail, Amount)
    SELECT ISNULL(MAX(SrNo), 0) + 1, NULL, N'Total', NULL, N'Total', N'Total', ISNULL(SUM(Amount), 0)
    FROM #Ledger

    SELECT SrNo, TranDate, RowType, ReferenceId, AccountName, Detail, Amount
    FROM #Ledger
    ORDER BY SrNo
END
GO
