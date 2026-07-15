namespace Ncsln.Forms
{
    partial class frmDashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDashboard));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnItems = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dtp = new System.Windows.Forms.DateTimePicker();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.txtTotalExpense = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTotalPR = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTotalReceive = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
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
            this.txtMsg = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dsDailyExpense1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsDailySale1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsDailyOrderReceive1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsInternalStock1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPRInvoice1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.txtMsg);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(658, 100);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.flowLayoutPanel1);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 100);
            this.panel2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.panel2.Size = new System.Drawing.Size(658, 321);
            this.panel2.TabIndex = 2;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.flowLayoutPanel1.Controls.Add(this.btnItems);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(8, 8);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(455, 305);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // btnItems
            // 
            this.btnItems.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnItems.Location = new System.Drawing.Point(15, 16);
            this.btnItems.Margin = new System.Windows.Forms.Padding(15, 16, 15, 16);
            this.btnItems.Name = "btnItems";
            this.btnItems.Size = new System.Drawing.Size(146, 67);
            this.btnItems.TabIndex = 0;
            this.btnItems.Text = "Items";
            this.btnItems.UseVisualStyleBackColor = true;
            this.btnItems.Click += new System.EventHandler(this.btnItems_Click);
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.dtp);
            this.panel3.Controls.Add(this.btnRefresh);
            this.panel3.Controls.Add(this.txtTotalExpense);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.txtTotalPR);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.txtTotalReceive);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(463, 8);
            this.panel3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(187, 305);
            this.panel3.TabIndex = 0;
            // 
            // dtp
            // 
            this.dtp.CustomFormat = "dd/MMM/yyyy";
            this.dtp.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp.Location = new System.Drawing.Point(14, 17);
            this.dtp.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dtp.Name = "dtp";
            this.dtp.Size = new System.Drawing.Size(151, 20);
            this.dtp.TabIndex = 7;
            this.dtp.Visible = false;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.Location = new System.Drawing.Point(14, 167);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(157, 32);
            this.btnRefresh.TabIndex = 6;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // txtTotalExpense
            // 
            this.txtTotalExpense.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtTotalExpense.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTotalExpense.Enabled = false;
            this.txtTotalExpense.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalExpense.Location = new System.Drawing.Point(15, 141);
            this.txtTotalExpense.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtTotalExpense.Name = "txtTotalExpense";
            this.txtTotalExpense.ReadOnly = true;
            this.txtTotalExpense.Size = new System.Drawing.Size(157, 19);
            this.txtTotalExpense.TabIndex = 5;
            this.txtTotalExpense.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 123);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(137, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Total Expense today";
            // 
            // txtTotalPR
            // 
            this.txtTotalPR.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtTotalPR.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTotalPR.Enabled = false;
            this.txtTotalPR.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalPR.Location = new System.Drawing.Point(15, 99);
            this.txtTotalPR.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtTotalPR.Name = "txtTotalPR";
            this.txtTotalPR.ReadOnly = true;
            this.txtTotalPR.Size = new System.Drawing.Size(157, 19);
            this.txtTotalPR.TabIndex = 3;
            this.txtTotalPR.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 80);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Total PR";
            // 
            // txtTotalReceive
            // 
            this.txtTotalReceive.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtTotalReceive.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTotalReceive.Enabled = false;
            this.txtTotalReceive.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalReceive.Location = new System.Drawing.Point(15, 57);
            this.txtTotalReceive.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtTotalReceive.Name = "txtTotalReceive";
            this.txtTotalReceive.ReadOnly = true;
            this.txtTotalReceive.Size = new System.Drawing.Size(157, 19);
            this.txtTotalReceive.TabIndex = 1;
            this.txtTotalReceive.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 38);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Total Receive";
            // 
            // daDailyOrderReceive
            // 
            this.daDailyOrderReceive.SelectCommand = this.sqlSelectCommand1;
            this.daDailyOrderReceive.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "vOrderReceive", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("Id", "Id"),
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
            this.sqlConnection1.ConnectionString = "Data Source=DESKTOP-I89D7HF;Initial Catalog=Inventory;Integrated Security=True";
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
            // txtMsg
            // 
            this.txtMsg.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtMsg.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.txtMsg.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMsg.Enabled = false;
            this.txtMsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMsg.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.txtMsg.Location = new System.Drawing.Point(80, 37);
            this.txtMsg.Margin = new System.Windows.Forms.Padding(2);
            this.txtMsg.Name = "txtMsg";
            this.txtMsg.ReadOnly = true;
            this.txtMsg.Size = new System.Drawing.Size(524, 38);
            this.txtMsg.TabIndex = 0;
            this.txtMsg.Text = "Inventory";
            this.txtMsg.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtMsg.TextChanged += new System.EventHandler(this.txtMsg_TextChanged);
            // 
            // frmDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(658, 421);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "frmDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Dashboard";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmDashboard_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dsDailyExpense1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsDailySale1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsDailyOrderReceive1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsInternalStock1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPRInvoice1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnItems;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtTotalReceive;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.TextBox txtTotalExpense;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTotalPR;
        private System.Windows.Forms.Label label2;
        private System.Data.SqlClient.SqlDataAdapter daDailyOrderReceive;
        private System.Data.SqlClient.SqlCommand sqlSelectCommand1;
        private System.Data.SqlClient.SqlConnection sqlConnection1;
        private System.Data.SqlClient.SqlDataAdapter daDailySale;
        private System.Data.SqlClient.SqlCommand sqlCommand1;
        private System.Data.SqlClient.SqlDataAdapter daDailyExpense;
        private System.Data.SqlClient.SqlCommand sqlCommand2;
        private Inventory.Reports.dsDailyExpense dsDailyExpense1;
        private Inventory.Reports.dsDailySale dsDailySale1;
        private Inventory.Reports.dsDailyOrderReceive dsDailyOrderReceive1;
        private System.Data.SqlClient.SqlDataAdapter daInternalStock;
        private System.Data.SqlClient.SqlCommand sqlCommand3;
        private Inventory.Reports.dsInternalStock dsInternalStock1;
        private System.Data.SqlClient.SqlDataAdapter daPRInvoice;
        private System.Data.SqlClient.SqlCommand sqlDeleteCommand;
        private System.Data.SqlClient.SqlCommand sqlInsertCommand;
        private System.Data.SqlClient.SqlCommand sqlCommand4;
        private System.Data.SqlClient.SqlCommand sqlUpdateCommand;
        private Inventory.Reports.dsPRInvoice dsPRInvoice1;
        private System.Windows.Forms.DateTimePicker dtp;
        private System.Windows.Forms.TextBox txtMsg;
    }
}