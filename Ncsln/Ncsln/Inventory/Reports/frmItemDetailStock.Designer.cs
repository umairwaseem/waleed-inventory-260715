namespace Ncsln.Inventory.Reports
{
    partial class frmItemDetailStock
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmItemDetailStock));
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmbItems = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnShow = new System.Windows.Forms.Button();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.crv = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.daItemDetailStock = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
            this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
            this.dsItemDetialStock1 = new Ncsln.Inventory.Reports.dsItemDetialStock();
            this.daItemDetailStockOne = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlCommand1 = new System.Data.SqlClient.SqlCommand();
            this.daItemDetailMenufecturing = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlCommand2 = new System.Data.SqlClient.SqlCommand();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dsItemDetialStock1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cmbItems);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.btnShow);
            this.panel1.Controls.Add(this.dtpTo);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.dtpFrom);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(810, 156);
            this.panel1.TabIndex = 0;
            // 
            // cmbItems
            // 
            this.cmbItems.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbItems.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbItems.FormattingEnabled = true;
            this.cmbItems.Location = new System.Drawing.Point(121, 110);
            this.cmbItems.Name = "cmbItems";
            this.cmbItems.Size = new System.Drawing.Size(648, 33);
            this.cmbItems.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(57, 113);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 25);
            this.label3.TabIndex = 5;
            this.label3.Text = "Items";
            // 
            // btnShow
            // 
            this.btnShow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnShow.Location = new System.Drawing.Point(694, 61);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(75, 35);
            this.btnShow.TabIndex = 4;
            this.btnShow.Text = "Show";
            this.btnShow.UseVisualStyleBackColor = true;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // dtpTo
            // 
            this.dtpTo.CustomFormat = "dd/MMM/yyyy";
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTo.Location = new System.Drawing.Point(253, 66);
            this.dtpTo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(183, 30);
            this.dtpTo.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(248, 34);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "To";
            // 
            // dtpFrom
            // 
            this.dtpFrom.CustomFormat = "dd/MMM/yyyy";
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFrom.Location = new System.Drawing.Point(62, 66);
            this.dtpFrom.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(183, 30);
            this.dtpFrom.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(57, 34);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "From";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.crv);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 156);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(810, 569);
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
            this.crv.Size = new System.Drawing.Size(810, 569);
            this.crv.TabIndex = 0;
            this.crv.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // daItemDetailStock
            // 
            this.daItemDetailStock.SelectCommand = this.sqlSelectCommand1;
            this.daItemDetailStock.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "vItemStock", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("Id", "Id"),
                        new System.Data.Common.DataColumnMapping("ItemId", "ItemId"),
                        new System.Data.Common.DataColumnMapping("Title", "Title"),
                        new System.Data.Common.DataColumnMapping("Decription", "Decription"),
                        new System.Data.Common.DataColumnMapping("Code", "Code"),
                        new System.Data.Common.DataColumnMapping("PurchasePrice", "PurchasePrice"),
                        new System.Data.Common.DataColumnMapping("SalePrice", "SalePrice"),
                        new System.Data.Common.DataColumnMapping("InvoiceId", "InvoiceId"),
                        new System.Data.Common.DataColumnMapping("InvoiceType", "InvoiceType"),
                        new System.Data.Common.DataColumnMapping("Qty", "Qty"),
                        new System.Data.Common.DataColumnMapping("Cost", "Cost"),
                        new System.Data.Common.DataColumnMapping("StockDate", "StockDate"),
                        new System.Data.Common.DataColumnMapping("InvoiceNo", "InvoiceNo"),
                        new System.Data.Common.DataColumnMapping("CompanyName", "CompanyName")})});
            // 
            // sqlSelectCommand1
            // 
            this.sqlSelectCommand1.CommandText = resources.GetString("sqlSelectCommand1.CommandText");
            this.sqlSelectCommand1.Connection = this.sqlConnection1;
            this.sqlSelectCommand1.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@from", System.Data.SqlDbType.DateTime),
            new System.Data.SqlClient.SqlParameter("@to", System.Data.SqlDbType.DateTime)});
            // 
            // sqlConnection1
            // 
            this.sqlConnection1.ConnectionString = "Data Source=(local);Initial Catalog=Inventory-oe;Persist Security Info=True;" +
    "User ID=adminom;Password=om123654";
            this.sqlConnection1.FireInfoMessageEventOnUserErrors = false;
            // 
            // dsItemDetialStock1
            // 
            this.dsItemDetialStock1.DataSetName = "dsItemDetialStock";
            this.dsItemDetialStock1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // daItemDetailStockOne
            // 
            this.daItemDetailStockOne.SelectCommand = this.sqlCommand1;
            this.daItemDetailStockOne.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "vItemStock", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("Id", "Id"),
                        new System.Data.Common.DataColumnMapping("ItemId", "ItemId"),
                        new System.Data.Common.DataColumnMapping("Title", "Title"),
                        new System.Data.Common.DataColumnMapping("Decription", "Decription"),
                        new System.Data.Common.DataColumnMapping("Code", "Code"),
                        new System.Data.Common.DataColumnMapping("PurchasePrice", "PurchasePrice"),
                        new System.Data.Common.DataColumnMapping("SalePrice", "SalePrice"),
                        new System.Data.Common.DataColumnMapping("InvoiceId", "InvoiceId"),
                        new System.Data.Common.DataColumnMapping("InvoiceType", "InvoiceType"),
                        new System.Data.Common.DataColumnMapping("Qty", "Qty"),
                        new System.Data.Common.DataColumnMapping("Cost", "Cost"),
                        new System.Data.Common.DataColumnMapping("StockDate", "StockDate"),
                        new System.Data.Common.DataColumnMapping("InvoiceNo", "InvoiceNo"),
                        new System.Data.Common.DataColumnMapping("CompanyName", "CompanyName")})});
            // 
            // sqlCommand1
            // 
            this.sqlCommand1.CommandText = resources.GetString("sqlCommand1.CommandText");
            this.sqlCommand1.Connection = this.sqlConnection1;
            this.sqlCommand1.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@from", System.Data.SqlDbType.DateTime),
            new System.Data.SqlClient.SqlParameter("@to", System.Data.SqlDbType.DateTime),
            new System.Data.SqlClient.SqlParameter("@ItemId", System.Data.SqlDbType.Decimal, 9, System.Data.ParameterDirection.Input, false, ((byte)(18)), ((byte)(0)), "ItemId", System.Data.DataRowVersion.Current, null)});
            // 
            // daItemDetailMenufecturing
            // 
            this.daItemDetailMenufecturing.SelectCommand = this.sqlCommand2;
            this.daItemDetailMenufecturing.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "vItemStock", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("Id", "Id"),
                        new System.Data.Common.DataColumnMapping("ItemId", "ItemId"),
                        new System.Data.Common.DataColumnMapping("Title", "Title"),
                        new System.Data.Common.DataColumnMapping("Decription", "Decription"),
                        new System.Data.Common.DataColumnMapping("Code", "Code"),
                        new System.Data.Common.DataColumnMapping("PurchasePrice", "PurchasePrice"),
                        new System.Data.Common.DataColumnMapping("SalePrice", "SalePrice"),
                        new System.Data.Common.DataColumnMapping("InvoiceId", "InvoiceId"),
                        new System.Data.Common.DataColumnMapping("InvoiceType", "InvoiceType"),
                        new System.Data.Common.DataColumnMapping("Qty", "Qty"),
                        new System.Data.Common.DataColumnMapping("Cost", "Cost"),
                        new System.Data.Common.DataColumnMapping("StockDate", "StockDate"),
                        new System.Data.Common.DataColumnMapping("InvoiceNo", "InvoiceNo"),
                        new System.Data.Common.DataColumnMapping("CompanyName", "CompanyName")})});
            // 
            // sqlCommand2
            // 
            this.sqlCommand2.CommandText = resources.GetString("sqlCommand2.CommandText");
            this.sqlCommand2.Connection = this.sqlConnection1;
            this.sqlCommand2.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@from", System.Data.SqlDbType.DateTime),
            new System.Data.SqlClient.SqlParameter("@to", System.Data.SqlDbType.DateTime)});
            // 
            // frmItemDetailStock
            // 
            this.AcceptButton = this.btnShow;
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(810, 725);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmItemDetailStock";
            this.Text = "Item Detail Stock";
            this.Load += new System.EventHandler(this.frmItemDetailStock_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dsItemDetialStock1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crv;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label label1;
        private System.Data.SqlClient.SqlDataAdapter daItemDetailStock;
        private System.Data.SqlClient.SqlCommand sqlSelectCommand1;
        private System.Data.SqlClient.SqlConnection sqlConnection1;
        private dsItemDetialStock dsItemDetialStock1;
        private System.Windows.Forms.ComboBox cmbItems;
        private System.Windows.Forms.Label label3;
        private System.Data.SqlClient.SqlDataAdapter daItemDetailStockOne;
        private System.Data.SqlClient.SqlCommand sqlCommand1;
        private System.Data.SqlClient.SqlDataAdapter daItemDetailMenufecturing;
        private System.Data.SqlClient.SqlCommand sqlCommand2;
    }
}