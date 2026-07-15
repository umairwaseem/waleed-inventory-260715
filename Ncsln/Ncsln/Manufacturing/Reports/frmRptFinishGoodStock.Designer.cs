namespace Ncsln.Manufacturing.Reports
{
    partial class frmRptFinishGoodStock
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnShow = new System.Windows.Forms.Button();
            this.cmbItems = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.crv = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.daMFinishGoods = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
            this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
            this.dsMFinishGoods1 = new Ncsln.Manufacturing.Reports.dsMFinishGoods();
            this.daMFinishGoodsSelected = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlCommand1 = new System.Data.SqlClient.SqlCommand();
            this.daMFinishGoodsOut = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlCommand2 = new System.Data.SqlClient.SqlCommand();
            this.dsMFinishGoodsOut1 = new Ncsln.Manufacturing.Reports.dsMFinishGoodsOut();
            this.rbtnStock = new System.Windows.Forms.RadioButton();
            this.rbtnStockOut = new System.Windows.Forms.RadioButton();
            this.daMFinishGoodsOutSelected = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlCommand3 = new System.Data.SqlClient.SqlCommand();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dsMFinishGoods1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsMFinishGoodsOut1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rbtnStockOut);
            this.panel1.Controls.Add(this.rbtnStock);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnShow);
            this.panel1.Controls.Add(this.cmbItems);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(833, 100);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Select Item";
            // 
            // btnShow
            // 
            this.btnShow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnShow.Location = new System.Drawing.Point(711, 48);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(75, 23);
            this.btnShow.TabIndex = 4;
            this.btnShow.Text = "Show";
            this.btnShow.UseVisualStyleBackColor = true;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // cmbItems
            // 
            this.cmbItems.FormattingEnabled = true;
            this.cmbItems.Location = new System.Drawing.Point(49, 48);
            this.cmbItems.Name = "cmbItems";
            this.cmbItems.Size = new System.Drawing.Size(310, 24);
            this.cmbItems.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.crv);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 100);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(833, 382);
            this.panel2.TabIndex = 1;
            // 
            // crv
            // 
            this.crv.ActiveViewIndex = -1;
            this.crv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crv.Cursor = System.Windows.Forms.Cursors.Default;
            this.crv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crv.Location = new System.Drawing.Point(0, 0);
            this.crv.Name = "crv";
            this.crv.Size = new System.Drawing.Size(833, 382);
            this.crv.TabIndex = 1;
            this.crv.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // daMFinishGoods
            // 
            this.daMFinishGoods.SelectCommand = this.sqlSelectCommand1;
            this.daMFinishGoods.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "vMFinishGoods", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("Id", "Id"),
                        new System.Data.Common.DataColumnMapping("Detail", "Detail"),
                        new System.Data.Common.DataColumnMapping("Qty", "Qty"),
                        new System.Data.Common.DataColumnMapping("Price", "Price"),
                        new System.Data.Common.DataColumnMapping("Date", "Date"),
                        new System.Data.Common.DataColumnMapping("Branch_Id", "Branch_Id"),
                        new System.Data.Common.DataColumnMapping("ModelNo", "ModelNo"),
                        new System.Data.Common.DataColumnMapping("Stock", "Stock")})});
            // 
            // sqlSelectCommand1
            // 
            this.sqlSelectCommand1.CommandText = "SELECT Id, Detail, Qty, Price, Date, Branch_Id, ModelNo, Stock\r\nFROM     vMFinish" +
    "Goods\r\nWHERE  (Stock > 0)";
            this.sqlSelectCommand1.Connection = this.sqlConnection1;
            // 
            // sqlConnection1
            // 
            this.sqlConnection1.ConnectionString = "Data Source=(local);Initial Catalog=InventoryServer;Persist Security Info=Tr" +
    "ue;Integrated Security=True";
            this.sqlConnection1.FireInfoMessageEventOnUserErrors = false;
            // 
            // dsMFinishGoods1
            // 
            this.dsMFinishGoods1.DataSetName = "dsMFinishGoods";
            this.dsMFinishGoods1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // daMFinishGoodsSelected
            // 
            this.daMFinishGoodsSelected.SelectCommand = this.sqlCommand1;
            this.daMFinishGoodsSelected.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "vMFinishGoods", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("Id", "Id"),
                        new System.Data.Common.DataColumnMapping("Detail", "Detail"),
                        new System.Data.Common.DataColumnMapping("Qty", "Qty"),
                        new System.Data.Common.DataColumnMapping("Price", "Price"),
                        new System.Data.Common.DataColumnMapping("Date", "Date"),
                        new System.Data.Common.DataColumnMapping("Branch_Id", "Branch_Id"),
                        new System.Data.Common.DataColumnMapping("ModelNo", "ModelNo"),
                        new System.Data.Common.DataColumnMapping("Stock", "Stock")})});
            // 
            // sqlCommand1
            // 
            this.sqlCommand1.CommandText = "SELECT Id, Detail, Qty, Price, Date, Branch_Id, ModelNo, Stock\r\nFROM     vMFinish" +
    "Goods\r\nWHERE  (Stock > 0) AND (Id = @Id)";
            this.sqlCommand1.Connection = this.sqlConnection1;
            this.sqlCommand1.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@Id", System.Data.SqlDbType.Int, 4, "Id")});
            // 
            // daMFinishGoodsOut
            // 
            this.daMFinishGoodsOut.SelectCommand = this.sqlCommand2;
            this.daMFinishGoodsOut.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "vMFinishGoodsStockOut", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("Id", "Id"),
                        new System.Data.Common.DataColumnMapping("ItemId", "ItemId"),
                        new System.Data.Common.DataColumnMapping("Detail", "Detail"),
                        new System.Data.Common.DataColumnMapping("ModelNo", "ModelNo"),
                        new System.Data.Common.DataColumnMapping("Branch_Id", "Branch_Id"),
                        new System.Data.Common.DataColumnMapping("BranchName", "BranchName"),
                        new System.Data.Common.DataColumnMapping("Qty", "Qty"),
                        new System.Data.Common.DataColumnMapping("Price", "Price"),
                        new System.Data.Common.DataColumnMapping("Date", "Date"),
                        new System.Data.Common.DataColumnMapping("Description", "Description")})});
            // 
            // sqlCommand2
            // 
            this.sqlCommand2.CommandText = "SELECT Id, ItemId, Detail, ModelNo, Branch_Id, BranchName, Qty, Price, Date, Desc" +
    "ription\r\nFROM     vMFinishGoodsStockOut";
            this.sqlCommand2.Connection = this.sqlConnection1;
            // 
            // dsMFinishGoodsOut1
            // 
            this.dsMFinishGoodsOut1.DataSetName = "dsMFinishGoodsOut";
            this.dsMFinishGoodsOut1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // rbtnStock
            // 
            this.rbtnStock.AutoSize = true;
            this.rbtnStock.Checked = true;
            this.rbtnStock.Location = new System.Drawing.Point(365, 49);
            this.rbtnStock.Name = "rbtnStock";
            this.rbtnStock.Size = new System.Drawing.Size(64, 21);
            this.rbtnStock.TabIndex = 6;
            this.rbtnStock.TabStop = true;
            this.rbtnStock.Text = "Stock";
            this.rbtnStock.UseVisualStyleBackColor = true;
            // 
            // rbtnStockOut
            // 
            this.rbtnStockOut.AutoSize = true;
            this.rbtnStockOut.Location = new System.Drawing.Point(435, 49);
            this.rbtnStockOut.Name = "rbtnStockOut";
            this.rbtnStockOut.Size = new System.Drawing.Size(91, 21);
            this.rbtnStockOut.TabIndex = 7;
            this.rbtnStockOut.Text = "Stock Out";
            this.rbtnStockOut.UseVisualStyleBackColor = true;
            // 
            // daMFinishGoodsOutSelected
            // 
            this.daMFinishGoodsOutSelected.SelectCommand = this.sqlCommand3;
            this.daMFinishGoodsOutSelected.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "vMFinishGoodsStockOut", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("Id", "Id"),
                        new System.Data.Common.DataColumnMapping("ItemId", "ItemId"),
                        new System.Data.Common.DataColumnMapping("Detail", "Detail"),
                        new System.Data.Common.DataColumnMapping("ModelNo", "ModelNo"),
                        new System.Data.Common.DataColumnMapping("Branch_Id", "Branch_Id"),
                        new System.Data.Common.DataColumnMapping("BranchName", "BranchName"),
                        new System.Data.Common.DataColumnMapping("Qty", "Qty"),
                        new System.Data.Common.DataColumnMapping("Price", "Price"),
                        new System.Data.Common.DataColumnMapping("Date", "Date"),
                        new System.Data.Common.DataColumnMapping("Description", "Description")})});
            // 
            // sqlCommand3
            // 
            this.sqlCommand3.CommandText = "SELECT Id, ItemId, Detail, ModelNo, Branch_Id, BranchName, Qty, Price, Date, Desc" +
    "ription\r\nFROM     vMFinishGoodsStockOut\r\nWHERE  (ItemId = @Id)";
            this.sqlCommand3.Connection = this.sqlConnection1;
            this.sqlCommand3.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@Id", System.Data.SqlDbType.Int, 4, "ItemId")});
            // 
            // frmRptFinishGoodStock
            // 
            this.AcceptButton = this.btnShow;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(833, 482);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "frmRptFinishGoodStock";
            this.Text = "Finish Good Report";
            this.Load += new System.EventHandler(this.frmRptFinishGoodStock_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dsMFinishGoods1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsMFinishGoodsOut1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.ComboBox cmbItems;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crv;
        private System.Data.SqlClient.SqlDataAdapter daMFinishGoods;
        private System.Data.SqlClient.SqlCommand sqlSelectCommand1;
        private System.Data.SqlClient.SqlConnection sqlConnection1;
        private dsMFinishGoods dsMFinishGoods1;
        private System.Data.SqlClient.SqlDataAdapter daMFinishGoodsSelected;
        private System.Data.SqlClient.SqlCommand sqlCommand1;
        private System.Data.SqlClient.SqlDataAdapter daMFinishGoodsOut;
        private System.Data.SqlClient.SqlCommand sqlCommand2;
        private dsMFinishGoodsOut dsMFinishGoodsOut1;
        private System.Windows.Forms.RadioButton rbtnStockOut;
        private System.Windows.Forms.RadioButton rbtnStock;
        private System.Data.SqlClient.SqlDataAdapter daMFinishGoodsOutSelected;
        private System.Data.SqlClient.SqlCommand sqlCommand3;
    }
}