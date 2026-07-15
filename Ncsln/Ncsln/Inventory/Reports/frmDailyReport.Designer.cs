namespace Ncsln.Inventory.Reports
{
    partial class frmDailyReport
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDailyReport));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnShow = new System.Windows.Forms.Button();
            this.dtp = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.crv = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.daDailyOrderReceive = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
            this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
            this.daDailySale = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlCommand1 = new System.Data.SqlClient.SqlCommand();
            this.daDailyExpense = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlCommand2 = new System.Data.SqlClient.SqlCommand();
            this.dsDailyExpense1 = new Ncsln.Inventory.Reports.dsDailyExpense();
            this.dsDailySale1 = new Ncsln.Inventory.Reports.dsDailySale();
            this.dsDailyOrderReceive1 = new Ncsln.Inventory.Reports.dsDailyOrderReceive();
            this.daInternalStock = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlCommand3 = new System.Data.SqlClient.SqlCommand();
            this.dsInternalStock1 = new Ncsln.Inventory.Reports.dsInternalStock();
            this.daPRInvoice = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlDeleteCommand = new System.Data.SqlClient.SqlCommand();
            this.sqlInsertCommand = new System.Data.SqlClient.SqlCommand();
            this.sqlCommand4 = new System.Data.SqlClient.SqlCommand();
            this.sqlUpdateCommand = new System.Data.SqlClient.SqlCommand();
            this.dsPRInvoice1 = new Ncsln.Inventory.Reports.dsPRInvoice();
            this.daHBCChallanDetail = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlCommand7 = new System.Data.SqlClient.SqlCommand();
            this.dsHBCChallanDetail1 = new Ncsln.Inventory.Reports.dsHBCChallanDetail();
            this.daMenufacturingStock = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlCommand5 = new System.Data.SqlClient.SqlCommand();
            this.dsManufacturingStock1 = new Ncsln.Inventory.Reports.dsManufacturingStock();
            this.daHBCRevers = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlCommand6 = new System.Data.SqlClient.SqlCommand();
            this.dsHBCReverse1 = new Ncsln.Inventory.Reports.dsHBCReverse();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dsDailyExpense1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsDailySale1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsDailyOrderReceive1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsInternalStock1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPRInvoice1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsHBCChallanDetail1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsManufacturingStock1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsHBCReverse1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnShow);
            this.panel1.Controls.Add(this.dtp);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1108, 104);
            this.panel1.TabIndex = 0;
            // 
            // btnShow
            // 
            this.btnShow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnShow.Location = new System.Drawing.Point(908, 48);
            this.btnShow.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(112, 34);
            this.btnShow.TabIndex = 2;
            this.btnShow.Text = "Show";
            this.btnShow.UseVisualStyleBackColor = true;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // dtp
            // 
            this.dtp.CustomFormat = "dd/MMM/yyyy";
            this.dtp.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp.Location = new System.Drawing.Point(68, 48);
            this.dtp.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtp.Name = "dtp";
            this.dtp.Size = new System.Drawing.Size(298, 30);
            this.dtp.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(63, 17);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Date";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.crv);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 104);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1108, 951);
            this.panel2.TabIndex = 1;
            // 
            // crv
            // 
            this.crv.ActiveViewIndex = -1;
            this.crv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crv.Cursor = System.Windows.Forms.Cursors.Default;
            this.crv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crv.Location = new System.Drawing.Point(0, 0);
            this.crv.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.crv.Name = "crv";
            this.crv.Size = new System.Drawing.Size(1108, 951);
            this.crv.TabIndex = 0;
            this.crv.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // daDailyOrderReceive
            // 
            this.daDailyOrderReceive.SelectCommand = this.sqlSelectCommand1;
            this.daDailyOrderReceive.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "vOrderReceive", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("Id", "Id"),
                        new System.Data.Common.DataColumnMapping("OrderNo", "OrderNo"),
                        new System.Data.Common.DataColumnMapping("InvoiceNo", "InvoiceNo"),
                        new System.Data.Common.DataColumnMapping("Date", "Date"),
                        new System.Data.Common.DataColumnMapping("ClientId", "ClientId"),
                        new System.Data.Common.DataColumnMapping("Name", "Name"),
                        new System.Data.Common.DataColumnMapping("PhoneNo", "PhoneNo"),
                        new System.Data.Common.DataColumnMapping("Email", "Email"),
                        new System.Data.Common.DataColumnMapping("Description", "Description"),
                        new System.Data.Common.DataColumnMapping("ExtraDetail", "ExtraDetail"),
                        new System.Data.Common.DataColumnMapping("ExtraAmount", "ExtraAmount"),
                        new System.Data.Common.DataColumnMapping("FinalTotal", "FinalTotal"),
                        new System.Data.Common.DataColumnMapping("Receive", "Receive"),
                        new System.Data.Common.DataColumnMapping("Balance", "Balance"),
                        new System.Data.Common.DataColumnMapping("ReceiveDate", "ReceiveDate"),
                        new System.Data.Common.DataColumnMapping("Amount", "Amount"),
                        new System.Data.Common.DataColumnMapping("OType", "OType"),
                        new System.Data.Common.DataColumnMapping("SalePerson", "SalePerson"),
                        new System.Data.Common.DataColumnMapping("ReceiveToDate", "ReceiveToDate"),
                        new System.Data.Common.DataColumnMapping("BalanceToDate", "BalanceToDate")})});
            // 
            // sqlSelectCommand1
            // 
            this.sqlSelectCommand1.CommandText = resources.GetString("sqlSelectCommand1.CommandText");
            this.sqlSelectCommand1.Connection = this.sqlConnection1;
            this.sqlSelectCommand1.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@date", System.Data.SqlDbType.DateTime)});
            // 
            // sqlConnection1
            // 
            this.sqlConnection1.ConnectionString = "Data Source=(local);Initial Catalog=Inventory-oe;Persist Security Info=True;" +
    "User ID=adminom;Password=om123654";
            this.sqlConnection1.FireInfoMessageEventOnUserErrors = false;
            // 
            // daDailySale
            // 
            this.daDailySale.SelectCommand = this.sqlCommand1;
            this.daDailySale.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "vOrder", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("Id", "Id"),
                        new System.Data.Common.DataColumnMapping("SaleNo", "SaleNo"),
                        new System.Data.Common.DataColumnMapping("SaleDate", "SaleDate"),
                        new System.Data.Common.DataColumnMapping("ClientId", "ClientId"),
                        new System.Data.Common.DataColumnMapping("Name", "Name"),
                        new System.Data.Common.DataColumnMapping("PhoneNo", "PhoneNo"),
                        new System.Data.Common.DataColumnMapping("Email", "Email"),
                        new System.Data.Common.DataColumnMapping("Description", "Description"),
                        new System.Data.Common.DataColumnMapping("ExtraDetail", "ExtraDetail"),
                        new System.Data.Common.DataColumnMapping("ExtraAmount", "ExtraAmount"),
                        new System.Data.Common.DataColumnMapping("FinalTotal", "FinalTotal"),
                        new System.Data.Common.DataColumnMapping("Receive", "Receive"),
                        new System.Data.Common.DataColumnMapping("Balance", "Balance"),
                        new System.Data.Common.DataColumnMapping("SalePrice", "SalePrice"),
                        new System.Data.Common.DataColumnMapping("Cost", "Cost"),
                        new System.Data.Common.DataColumnMapping("SalePerson", "SalePerson")})});
            // 
            // sqlCommand1
            // 
            this.sqlCommand1.CommandText = resources.GetString("sqlCommand1.CommandText");
            this.sqlCommand1.Connection = this.sqlConnection1;
            this.sqlCommand1.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@date", System.Data.SqlDbType.DateTime)});
            // 
            // daDailyExpense
            // 
            this.daDailyExpense.SelectCommand = this.sqlCommand2;
            this.daDailyExpense.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "vExpense", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("Id", "Id"),
                        new System.Data.Common.DataColumnMapping("Expense_Id", "Expense_Id"),
                        new System.Data.Common.DataColumnMapping("Expense", "Expense"),
                        new System.Data.Common.DataColumnMapping("Date", "Date"),
                        new System.Data.Common.DataColumnMapping("Description", "Description"),
                        new System.Data.Common.DataColumnMapping("Amount", "Amount")})});
            // 
            // sqlCommand2
            // 
            this.sqlCommand2.CommandText = "SELECT Id, Expense_Id, Expense, Date, Description, Amount\r\nFROM     vExpense\r\nWHE" +
    "RE  (CONVERT(datetime, CONVERT(nvarchar(10), Date, 111)) = @date)";
            this.sqlCommand2.Connection = this.sqlConnection1;
            this.sqlCommand2.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@date", System.Data.SqlDbType.DateTime)});
            // 
            // dsDailyExpense1
            // 
            this.dsDailyExpense1.DataSetName = "dsDailyExpense";
            this.dsDailyExpense1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dsDailySale1
            // 
            this.dsDailySale1.DataSetName = "dsDailySale";
            this.dsDailySale1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dsDailyOrderReceive1
            // 
            this.dsDailyOrderReceive1.DataSetName = "dsDailyOrderReceive";
            this.dsDailyOrderReceive1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // daInternalStock
            // 
            this.daInternalStock.SelectCommand = this.sqlCommand3;
            this.daInternalStock.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "vInternalStock", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("Id", "Id"),
                        new System.Data.Common.DataColumnMapping("CompanyName", "CompanyName"),
                        new System.Data.Common.DataColumnMapping("Title", "Title"),
                        new System.Data.Common.DataColumnMapping("Code", "Code"),
                        new System.Data.Common.DataColumnMapping("StockDate", "StockDate"),
                        new System.Data.Common.DataColumnMapping("Qty", "Qty"),
                        new System.Data.Common.DataColumnMapping("Type", "Type"),
                        new System.Data.Common.DataColumnMapping("Stock", "Stock"),
                        new System.Data.Common.DataColumnMapping("ItemId", "ItemId")})});
            // 
            // sqlCommand3
            // 
            this.sqlCommand3.CommandText = "SELECT Id, CompanyName, Title, Code, StockDate, Qty, Type, Stock, ItemId\r\nFROM   " +
    "  vInternalStock\r\nWHERE  (CONVERT(datetime, CONVERT(nvarchar(10), StockDate, 111" +
    ")) = @date)";
            this.sqlCommand3.Connection = this.sqlConnection1;
            this.sqlCommand3.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@date", System.Data.SqlDbType.DateTime)});
            // 
            // dsInternalStock1
            // 
            this.dsInternalStock1.DataSetName = "dsInternalStock";
            this.dsInternalStock1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // daPRInvoice
            // 
            this.daPRInvoice.DeleteCommand = this.sqlDeleteCommand;
            this.daPRInvoice.InsertCommand = this.sqlInsertCommand;
            this.daPRInvoice.SelectCommand = this.sqlCommand4;
            this.daPRInvoice.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "PRInvoice", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("Id", "Id"),
                        new System.Data.Common.DataColumnMapping("InvoviceNo", "InvoviceNo"),
                        new System.Data.Common.DataColumnMapping("Detail", "Detail"),
                        new System.Data.Common.DataColumnMapping("Cost", "Cost"),
                        new System.Data.Common.DataColumnMapping("ExtraDetail", "ExtraDetail"),
                        new System.Data.Common.DataColumnMapping("Extra", "Extra"),
                        new System.Data.Common.DataColumnMapping("Price", "Price"),
                        new System.Data.Common.DataColumnMapping("TotalPrice", "TotalPrice"),
                        new System.Data.Common.DataColumnMapping("InvoiceDate", "InvoiceDate")})});
            this.daPRInvoice.UpdateCommand = this.sqlUpdateCommand;
            // 
            // sqlDeleteCommand
            // 
            this.sqlDeleteCommand.CommandText = resources.GetString("sqlDeleteCommand.CommandText");
            this.sqlDeleteCommand.Connection = this.sqlConnection1;
            this.sqlDeleteCommand.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@Original_Id", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Id", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_InvoviceNo", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "InvoviceNo", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_InvoviceNo", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "InvoviceNo", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_Detail", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Detail", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_Detail", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Detail", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_Cost", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Cost", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_Cost", System.Data.SqlDbType.Decimal, 0, System.Data.ParameterDirection.Input, false, ((byte)(18)), ((byte)(2)), "Cost", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_ExtraDetail", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ExtraDetail", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_ExtraDetail", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ExtraDetail", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_Extra", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Extra", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_Extra", System.Data.SqlDbType.Decimal, 0, System.Data.ParameterDirection.Input, false, ((byte)(18)), ((byte)(2)), "Extra", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_Price", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Price", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_Price", System.Data.SqlDbType.Decimal, 0, System.Data.ParameterDirection.Input, false, ((byte)(18)), ((byte)(2)), "Price", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_TotalPrice", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "TotalPrice", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_TotalPrice", System.Data.SqlDbType.Decimal, 0, System.Data.ParameterDirection.Input, false, ((byte)(18)), ((byte)(2)), "TotalPrice", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_InvoiceDate", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "InvoiceDate", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_InvoiceDate", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "InvoiceDate", System.Data.DataRowVersion.Original, null)});
            // 
            // sqlInsertCommand
            // 
            this.sqlInsertCommand.CommandText = resources.GetString("sqlInsertCommand.CommandText");
            this.sqlInsertCommand.Connection = this.sqlConnection1;
            this.sqlInsertCommand.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@InvoviceNo", System.Data.SqlDbType.Int, 0, "InvoviceNo"),
            new System.Data.SqlClient.SqlParameter("@Detail", System.Data.SqlDbType.NVarChar, 0, "Detail"),
            new System.Data.SqlClient.SqlParameter("@Cost", System.Data.SqlDbType.Decimal, 0, System.Data.ParameterDirection.Input, false, ((byte)(18)), ((byte)(2)), "Cost", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@ExtraDetail", System.Data.SqlDbType.NVarChar, 0, "ExtraDetail"),
            new System.Data.SqlClient.SqlParameter("@Extra", System.Data.SqlDbType.Decimal, 0, System.Data.ParameterDirection.Input, false, ((byte)(18)), ((byte)(2)), "Extra", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@Price", System.Data.SqlDbType.Decimal, 0, System.Data.ParameterDirection.Input, false, ((byte)(18)), ((byte)(2)), "Price", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@TotalPrice", System.Data.SqlDbType.Decimal, 0, System.Data.ParameterDirection.Input, false, ((byte)(18)), ((byte)(2)), "TotalPrice", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@InvoiceDate", System.Data.SqlDbType.DateTime, 0, "InvoiceDate")});
            // 
            // sqlCommand4
            // 
            this.sqlCommand4.CommandText = "SELECT Id, InvoviceNo, Detail, Cost, ExtraDetail, Extra, Price, TotalPrice, Invoi" +
    "ceDate\r\nFROM     PRInvoice\r\nWHERE  (CONVERT(datetime, CONVERT(nvarchar(10), Invo" +
    "iceDate, 111)) = @date)";
            this.sqlCommand4.Connection = this.sqlConnection1;
            this.sqlCommand4.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@date", System.Data.SqlDbType.DateTime)});
            // 
            // sqlUpdateCommand
            // 
            this.sqlUpdateCommand.CommandText = resources.GetString("sqlUpdateCommand.CommandText");
            this.sqlUpdateCommand.Connection = this.sqlConnection1;
            this.sqlUpdateCommand.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@InvoviceNo", System.Data.SqlDbType.Int, 0, "InvoviceNo"),
            new System.Data.SqlClient.SqlParameter("@Detail", System.Data.SqlDbType.NVarChar, 0, "Detail"),
            new System.Data.SqlClient.SqlParameter("@Cost", System.Data.SqlDbType.Decimal, 0, System.Data.ParameterDirection.Input, false, ((byte)(18)), ((byte)(2)), "Cost", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@ExtraDetail", System.Data.SqlDbType.NVarChar, 0, "ExtraDetail"),
            new System.Data.SqlClient.SqlParameter("@Extra", System.Data.SqlDbType.Decimal, 0, System.Data.ParameterDirection.Input, false, ((byte)(18)), ((byte)(2)), "Extra", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@Price", System.Data.SqlDbType.Decimal, 0, System.Data.ParameterDirection.Input, false, ((byte)(18)), ((byte)(2)), "Price", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@TotalPrice", System.Data.SqlDbType.Decimal, 0, System.Data.ParameterDirection.Input, false, ((byte)(18)), ((byte)(2)), "TotalPrice", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@InvoiceDate", System.Data.SqlDbType.DateTime, 0, "InvoiceDate"),
            new System.Data.SqlClient.SqlParameter("@Original_Id", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Id", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_InvoviceNo", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "InvoviceNo", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_InvoviceNo", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "InvoviceNo", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_Detail", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Detail", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_Detail", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Detail", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_Cost", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Cost", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_Cost", System.Data.SqlDbType.Decimal, 0, System.Data.ParameterDirection.Input, false, ((byte)(18)), ((byte)(2)), "Cost", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_ExtraDetail", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ExtraDetail", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_ExtraDetail", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ExtraDetail", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_Extra", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Extra", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_Extra", System.Data.SqlDbType.Decimal, 0, System.Data.ParameterDirection.Input, false, ((byte)(18)), ((byte)(2)), "Extra", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_Price", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Price", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_Price", System.Data.SqlDbType.Decimal, 0, System.Data.ParameterDirection.Input, false, ((byte)(18)), ((byte)(2)), "Price", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_TotalPrice", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "TotalPrice", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_TotalPrice", System.Data.SqlDbType.Decimal, 0, System.Data.ParameterDirection.Input, false, ((byte)(18)), ((byte)(2)), "TotalPrice", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_InvoiceDate", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "InvoiceDate", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_InvoiceDate", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "InvoiceDate", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Id", System.Data.SqlDbType.Int, 4, "Id")});
            // 
            // dsPRInvoice1
            // 
            this.dsPRInvoice1.DataSetName = "dsPRInvoice";
            this.dsPRInvoice1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // daHBCChallanDetail
            // 
            this.daHBCChallanDetail.SelectCommand = this.sqlCommand7;
            this.daHBCChallanDetail.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "vHBCChallanDetail", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("Challan_Id", "Challan_Id"),
                        new System.Data.Common.DataColumnMapping("ItemId", "ItemId"),
                        new System.Data.Common.DataColumnMapping("ModelNo", "ModelNo"),
                        new System.Data.Common.DataColumnMapping("Title", "Title"),
                        new System.Data.Common.DataColumnMapping("Qty", "Qty"),
                        new System.Data.Common.DataColumnMapping("Price", "Price"),
                        new System.Data.Common.DataColumnMapping("Total", "Total"),
                        new System.Data.Common.DataColumnMapping("Server_Id", "Server_Id"),
                        new System.Data.Common.DataColumnMapping("Date", "Date")})});
            // 
            // sqlCommand7
            // 
            this.sqlCommand7.CommandText = "SELECT Challan_Id, ItemId, ModelNo, Title, Qty, Price, Total, Server_Id, Date\r\nFR" +
    "OM     vHBCChallanDetail\r\nWHERE  (CONVERT(datetime, CONVERT(nvarchar(10), Date, " +
    "111)) = @date)";
            this.sqlCommand7.Connection = this.sqlConnection1;
            this.sqlCommand7.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@date", System.Data.SqlDbType.DateTime)});
            // 
            // dsHBCChallanDetail1
            // 
            this.dsHBCChallanDetail1.DataSetName = "dsHBCChallanDetail";
            this.dsHBCChallanDetail1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // daMenufacturingStock
            // 
            this.daMenufacturingStock.SelectCommand = this.sqlCommand5;
            this.daMenufacturingStock.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "vMenufacturingStock", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ItemId", "ItemId"),
                        new System.Data.Common.DataColumnMapping("Code", "Code"),
                        new System.Data.Common.DataColumnMapping("Title", "Title"),
                        new System.Data.Common.DataColumnMapping("Qty", "Qty"),
                        new System.Data.Common.DataColumnMapping("Cost", "Cost"),
                        new System.Data.Common.DataColumnMapping("StockDate", "StockDate"),
                        new System.Data.Common.DataColumnMapping("InvoiceType", "InvoiceType")})});
            // 
            // sqlCommand5
            // 
            this.sqlCommand5.CommandText = "SELECT ItemId, Code, Title, Qty, Cost, StockDate, InvoiceType\r\nFROM     vMenufact" +
    "uringStock\r\nWHERE  (CONVERT(datetime, CONVERT(nvarchar(10), StockDate, 111)) = @" +
    "date)";
            this.sqlCommand5.Connection = this.sqlConnection1;
            this.sqlCommand5.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@date", System.Data.SqlDbType.DateTime)});
            // 
            // dsManufacturingStock1
            // 
            this.dsManufacturingStock1.DataSetName = "dsManufacturingStock";
            this.dsManufacturingStock1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // daHBCRevers
            // 
            this.daHBCRevers.SelectCommand = this.sqlCommand6;
            this.daHBCRevers.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "vHBCReverse", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("Id", "Id"),
                        new System.Data.Common.DataColumnMapping("ItemId", "ItemId"),
                        new System.Data.Common.DataColumnMapping("Title", "Title"),
                        new System.Data.Common.DataColumnMapping("Code", "Code"),
                        new System.Data.Common.DataColumnMapping("Qty", "Qty"),
                        new System.Data.Common.DataColumnMapping("Date", "Date")})});
            // 
            // sqlCommand6
            // 
            this.sqlCommand6.CommandText = "SELECT Id, ItemId, Title, Code, Qty, Date\r\nFROM     vHBCReverse\r\nWHERE  (CONVERT(" +
    "datetime, CONVERT(nvarchar(10), Date, 111)) = @date)";
            this.sqlCommand6.Connection = this.sqlConnection1;
            this.sqlCommand6.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@date", System.Data.SqlDbType.DateTime)});
            // 
            // dsHBCReverse1
            // 
            this.dsHBCReverse1.DataSetName = "dsHBCReverse";
            this.dsHBCReverse1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // frmDailyReport
            // 
            this.AcceptButton = this.btnShow;
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1108, 1055);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmDailyReport";
            this.Text = "Daily Sale Sheet";
            this.Load += new System.EventHandler(this.frmDailyReport_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dsDailyExpense1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsDailySale1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsDailyOrderReceive1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsInternalStock1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPRInvoice1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsHBCChallanDetail1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsManufacturingStock1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsHBCReverse1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crv;
        private System.Data.SqlClient.SqlDataAdapter daDailyOrderReceive;
        private System.Data.SqlClient.SqlCommand sqlSelectCommand1;
        private System.Data.SqlClient.SqlConnection sqlConnection1;
        private dsDailyOrderReceive dsDailyOrderReceive1;
        private System.Data.SqlClient.SqlDataAdapter daDailySale;
        private System.Data.SqlClient.SqlCommand sqlCommand1;
        private dsDailySale dsDailySale1;
        private System.Data.SqlClient.SqlDataAdapter daDailyExpense;
        private System.Data.SqlClient.SqlCommand sqlCommand2;
        private dsDailyExpense dsDailyExpense1;
        private System.Windows.Forms.DateTimePicker dtp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnShow;
        private System.Data.SqlClient.SqlDataAdapter daInternalStock;
        private System.Data.SqlClient.SqlCommand sqlCommand3;
        private dsInternalStock dsInternalStock1;
        private System.Data.SqlClient.SqlDataAdapter daPRInvoice;
        private System.Data.SqlClient.SqlCommand sqlDeleteCommand;
        private System.Data.SqlClient.SqlCommand sqlInsertCommand;
        private System.Data.SqlClient.SqlCommand sqlCommand4;
        private System.Data.SqlClient.SqlCommand sqlUpdateCommand;
        private dsPRInvoice dsPRInvoice1;
        private System.Data.SqlClient.SqlDataAdapter daHBCChallanDetail;
        private System.Data.SqlClient.SqlCommand sqlCommand7;
        private dsHBCChallanDetail dsHBCChallanDetail1;
        private System.Data.SqlClient.SqlDataAdapter daMenufacturingStock;
        private System.Data.SqlClient.SqlCommand sqlCommand5;
        private dsManufacturingStock dsManufacturingStock1;
        private System.Data.SqlClient.SqlDataAdapter daHBCRevers;
        private System.Data.SqlClient.SqlCommand sqlCommand6;
        private dsHBCReverse dsHBCReverse1;
    }
}