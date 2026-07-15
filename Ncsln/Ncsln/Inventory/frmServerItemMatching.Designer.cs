namespace Ncsln.Inventory
{
    partial class frmServerItemMatching
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmServerItemMatching));
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lbLocalItem = new System.Windows.Forms.Label();
            this.btnChange = new System.Windows.Forms.Button();
            this.cmbServerItems = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.vServerItemsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsServerItemMatching1 = new Ncsln.Inventory.dsServerItemMatching();
            this.daServerItemMatching = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
            this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
            this.ItemId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.serverCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.serverNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.decriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.purchasePriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ServerPurchasePrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.salePriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vendorIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.oStockDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.serverIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Change = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vServerItemsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsServerItemMatching1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtSearch);
            this.panel1.Controls.Add(this.lbLocalItem);
            this.panel1.Controls.Add(this.btnChange);
            this.panel1.Controls.Add(this.cmbServerItems);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1075, 141);
            this.panel1.TabIndex = 0;
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtSearch.Location = new System.Drawing.Point(367, 108);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(341, 22);
            this.txtSearch.TabIndex = 4;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // lbLocalItem
            // 
            this.lbLocalItem.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbLocalItem.AutoSize = true;
            this.lbLocalItem.Location = new System.Drawing.Point(364, 64);
            this.lbLocalItem.Name = "lbLocalItem";
            this.lbLocalItem.Size = new System.Drawing.Size(0, 17);
            this.lbLocalItem.TabIndex = 3;
            // 
            // btnChange
            // 
            this.btnChange.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnChange.Location = new System.Drawing.Point(731, 37);
            this.btnChange.Name = "btnChange";
            this.btnChange.Size = new System.Drawing.Size(75, 33);
            this.btnChange.TabIndex = 2;
            this.btnChange.Text = "Change";
            this.btnChange.UseVisualStyleBackColor = true;
            this.btnChange.Click += new System.EventHandler(this.btnChange_Click);
            // 
            // cmbServerItems
            // 
            this.cmbServerItems.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cmbServerItems.FormattingEnabled = true;
            this.cmbServerItems.Location = new System.Drawing.Point(364, 37);
            this.cmbServerItems.Name = "cmbServerItems";
            this.cmbServerItems.Size = new System.Drawing.Size(344, 24);
            this.cmbServerItems.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(364, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Server Item List";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgv);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 141);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1075, 375);
            this.panel2.TabIndex = 1;
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AutoGenerateColumns = false;
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ItemId,
            this.Code,
            this.serverCodeDataGridViewTextBoxColumn,
            this.Title,
            this.serverNameDataGridViewTextBoxColumn,
            this.decriptionDataGridViewTextBoxColumn,
            this.purchasePriceDataGridViewTextBoxColumn,
            this.ServerPurchasePrice,
            this.salePriceDataGridViewTextBoxColumn,
            this.vendorIdDataGridViewTextBoxColumn,
            this.oStockDataGridViewTextBoxColumn,
            this.serverIdDataGridViewTextBoxColumn,
            this.Change});
            this.dgv.DataSource = this.vServerItemsBindingSource;
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.Location = new System.Drawing.Point(0, 0);
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersVisible = false;
            this.dgv.RowTemplate.Height = 24;
            this.dgv.Size = new System.Drawing.Size(1075, 375);
            this.dgv.TabIndex = 0;
            this.dgv.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellContentClick);
            // 
            // vServerItemsBindingSource
            // 
            this.vServerItemsBindingSource.DataMember = "vServerItems";
            this.vServerItemsBindingSource.DataSource = this.dsServerItemMatching1;
            // 
            // dsServerItemMatching1
            // 
            this.dsServerItemMatching1.DataSetName = "dsServerItemMatching";
            this.dsServerItemMatching1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // daServerItemMatching
            // 
            this.daServerItemMatching.SelectCommand = this.sqlSelectCommand1;
            this.daServerItemMatching.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "vServerItems", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ItemId", "ItemId"),
                        new System.Data.Common.DataColumnMapping("Title", "Title"),
                        new System.Data.Common.DataColumnMapping("Decription", "Decription"),
                        new System.Data.Common.DataColumnMapping("Code", "Code"),
                        new System.Data.Common.DataColumnMapping("PurchasePrice", "PurchasePrice"),
                        new System.Data.Common.DataColumnMapping("SalePrice", "SalePrice"),
                        new System.Data.Common.DataColumnMapping("VendorId", "VendorId"),
                        new System.Data.Common.DataColumnMapping("OStock", "OStock"),
                        new System.Data.Common.DataColumnMapping("Server_Id", "Server_Id"),
                        new System.Data.Common.DataColumnMapping("ServerName", "ServerName"),
                        new System.Data.Common.DataColumnMapping("ServerCode", "ServerCode"),
                        new System.Data.Common.DataColumnMapping("ServerPurchasePrice", "ServerPurchasePrice")})});
            // 
            // sqlSelectCommand1
            // 
            this.sqlSelectCommand1.CommandText = resources.GetString("sqlSelectCommand1.CommandText");
            this.sqlSelectCommand1.Connection = this.sqlConnection1;
            this.sqlSelectCommand1.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@key", System.Data.SqlDbType.NVarChar, 500, "Title")});
            // 
            // sqlConnection1
            // 
            this.sqlConnection1.ConnectionString = "Data Source=.;Initial Catalog=Inventory-oe;Integrated Security=True";
            this.sqlConnection1.FireInfoMessageEventOnUserErrors = false;
            // 
            // ItemId
            // 
            this.ItemId.DataPropertyName = "ItemId";
            this.ItemId.HeaderText = "ItemId";
            this.ItemId.Name = "ItemId";
            this.ItemId.ReadOnly = true;
            this.ItemId.Visible = false;
            // 
            // Code
            // 
            this.Code.DataPropertyName = "Code";
            this.Code.HeaderText = "Model No";
            this.Code.Name = "Code";
            this.Code.ReadOnly = true;
            // 
            // serverCodeDataGridViewTextBoxColumn
            // 
            this.serverCodeDataGridViewTextBoxColumn.DataPropertyName = "ServerCode";
            this.serverCodeDataGridViewTextBoxColumn.HeaderText = "Server Model No";
            this.serverCodeDataGridViewTextBoxColumn.Name = "serverCodeDataGridViewTextBoxColumn";
            this.serverCodeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // Title
            // 
            this.Title.DataPropertyName = "Title";
            this.Title.HeaderText = "Title";
            this.Title.Name = "Title";
            this.Title.ReadOnly = true;
            // 
            // serverNameDataGridViewTextBoxColumn
            // 
            this.serverNameDataGridViewTextBoxColumn.DataPropertyName = "ServerName";
            this.serverNameDataGridViewTextBoxColumn.HeaderText = "Server Title";
            this.serverNameDataGridViewTextBoxColumn.Name = "serverNameDataGridViewTextBoxColumn";
            this.serverNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // decriptionDataGridViewTextBoxColumn
            // 
            this.decriptionDataGridViewTextBoxColumn.DataPropertyName = "Decription";
            this.decriptionDataGridViewTextBoxColumn.HeaderText = "Decription";
            this.decriptionDataGridViewTextBoxColumn.Name = "decriptionDataGridViewTextBoxColumn";
            this.decriptionDataGridViewTextBoxColumn.ReadOnly = true;
            this.decriptionDataGridViewTextBoxColumn.Visible = false;
            // 
            // purchasePriceDataGridViewTextBoxColumn
            // 
            this.purchasePriceDataGridViewTextBoxColumn.DataPropertyName = "PurchasePrice";
            this.purchasePriceDataGridViewTextBoxColumn.HeaderText = "Price";
            this.purchasePriceDataGridViewTextBoxColumn.Name = "purchasePriceDataGridViewTextBoxColumn";
            this.purchasePriceDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // ServerPurchasePrice
            // 
            this.ServerPurchasePrice.DataPropertyName = "ServerPurchasePrice";
            this.ServerPurchasePrice.HeaderText = "Server Price";
            this.ServerPurchasePrice.Name = "ServerPurchasePrice";
            this.ServerPurchasePrice.ReadOnly = true;
            // 
            // salePriceDataGridViewTextBoxColumn
            // 
            this.salePriceDataGridViewTextBoxColumn.DataPropertyName = "SalePrice";
            this.salePriceDataGridViewTextBoxColumn.HeaderText = "SalePrice";
            this.salePriceDataGridViewTextBoxColumn.Name = "salePriceDataGridViewTextBoxColumn";
            this.salePriceDataGridViewTextBoxColumn.ReadOnly = true;
            this.salePriceDataGridViewTextBoxColumn.Visible = false;
            // 
            // vendorIdDataGridViewTextBoxColumn
            // 
            this.vendorIdDataGridViewTextBoxColumn.DataPropertyName = "VendorId";
            this.vendorIdDataGridViewTextBoxColumn.HeaderText = "VendorId";
            this.vendorIdDataGridViewTextBoxColumn.Name = "vendorIdDataGridViewTextBoxColumn";
            this.vendorIdDataGridViewTextBoxColumn.ReadOnly = true;
            this.vendorIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // oStockDataGridViewTextBoxColumn
            // 
            this.oStockDataGridViewTextBoxColumn.DataPropertyName = "OStock";
            this.oStockDataGridViewTextBoxColumn.HeaderText = "OStock";
            this.oStockDataGridViewTextBoxColumn.Name = "oStockDataGridViewTextBoxColumn";
            this.oStockDataGridViewTextBoxColumn.ReadOnly = true;
            this.oStockDataGridViewTextBoxColumn.Visible = false;
            // 
            // serverIdDataGridViewTextBoxColumn
            // 
            this.serverIdDataGridViewTextBoxColumn.DataPropertyName = "Server_Id";
            this.serverIdDataGridViewTextBoxColumn.HeaderText = "Server_Id";
            this.serverIdDataGridViewTextBoxColumn.Name = "serverIdDataGridViewTextBoxColumn";
            this.serverIdDataGridViewTextBoxColumn.ReadOnly = true;
            this.serverIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // Change
            // 
            this.Change.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Change.HeaderText = "Change";
            this.Change.Name = "Change";
            this.Change.ReadOnly = true;
            this.Change.Text = "Change";
            this.Change.ToolTipText = "Change";
            this.Change.UseColumnTextForButtonValue = true;
            this.Change.Width = 80;
            // 
            // frmServerItemMatching
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1075, 516);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "frmServerItemMatching";
            this.Text = "Server Item Matching";
            this.Load += new System.EventHandler(this.frmServerItemMatching_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vServerItemsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsServerItemMatching1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgv;
        private System.Data.SqlClient.SqlDataAdapter daServerItemMatching;
        private System.Data.SqlClient.SqlCommand sqlSelectCommand1;
        private System.Data.SqlClient.SqlConnection sqlConnection1;
        private dsServerItemMatching dsServerItemMatching1;
        private System.Windows.Forms.BindingSource vServerItemsBindingSource;
        private System.Windows.Forms.Button btnChange;
        private System.Windows.Forms.ComboBox cmbServerItems;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbLocalItem;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Code;
        private System.Windows.Forms.DataGridViewTextBoxColumn serverCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Title;
        private System.Windows.Forms.DataGridViewTextBoxColumn serverNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn decriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn purchasePriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ServerPurchasePrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn salePriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vendorIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn oStockDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn serverIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewButtonColumn Change;
    }
}