/* Run against the HBC/Center database. Safe to run repeatedly. */
IF NOT EXISTS
(
    SELECT 1
    FROM dbo.UserForms
    WHERE FromName = N'User Group'
)
BEGIN
    INSERT INTO dbo.UserForms (FromName, Report)
    VALUES (N'User Group', 0);
END;
