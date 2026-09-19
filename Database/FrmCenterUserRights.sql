/*
    Seeds the UserForms used by the additional frmCenter menu permissions.
    Run this script once against each database that owns these menus:
      - the client database for local/client menu permissions
      - the HBC/center database for HBC menu permissions

    No UserGroupRights rows are inserted. New forms therefore start denied
    and can be assigned or withdrawn from the existing user-group rights form.
*/

DECLARE @MissingForms TABLE
(
    FromName nvarchar(50) NOT NULL,
    Report bit NOT NULL
);

INSERT INTO @MissingForms (FromName, Report)
VALUES
    (N'Sale', 0),
    (N'Owner Withdraw', 0),
    (N'Back up', 0),
    (N'Rectify Items', 0),
    (N'Item Trend', 1),
    (N'Stock Alert', 1),
    (N'Overall Stock', 1),
    (N'Add Items', 0),
    (N'HBC Item', 0),
    (N'Local Item', 0),
    (N'HBC Stock Report', 1),
    (N'Stock Hide Items', 1),
    (N'Stock Hide Ledger', 1),
    (N'Branches Stock', 1),
    (N'Add Employee', 0),
    (N'Salary (Office Master)', 0),
    (N'Salary (World Style)', 0),
    (N'Salary Histroy', 1),
    (N'Salary (Two)', 0),
    (N'Salary (One)', 0),
    (N'Salary (HBC)', 0),
    (N'Salary ALL', 0),
    (N'Add Partner', 0),
    (N'Partner Profit', 0),
    (N'Partner Profit History', 1),
    (N'Major Amounts', 0),
    (N'Monthly Final Report', 1),
    (N'Partner Payment Report', 1),
    (N'Vendor Stock Balance', 1),
    (N'Stock Branch', 1),
    (N'V10 Report', 1),
    (N'General Vendor Invoice', 0),
    (N'Person List', 0),
    (N'Additional Account Ledger', 1),
    (N'Workshop Account List', 0),
    (N'Workshop Transaction', 0),
    (N'Workshop Ledger', 1),
    (N'Branches Daily Cash', 1),
    (N'Negative Stock', 1),
    (N'Banks', 0),
    (N'User Logs', 1),
    (N'Promotional Item', 0),
    (N'Vendor Report', 1),
    (N'Vendor Wise Report', 1),
    (N'Vendor Ledger', 1),
    (N'Bank Ledger', 1);

INSERT INTO dbo.UserForms (FromName, Report)
SELECT forms.FromName, forms.Report
FROM @MissingForms AS forms
WHERE NOT EXISTS
(
    SELECT 1
    FROM dbo.UserForms AS existingForms
    WHERE existingForms.FromName = forms.FromName
);
