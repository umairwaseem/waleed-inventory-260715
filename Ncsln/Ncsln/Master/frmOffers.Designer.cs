namespace Ncsln.Master
{
    partial class frmOffers
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOffers));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbStock = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnResest = new System.Windows.Forms.Button();
            this.btnSelectPicture = new System.Windows.Forms.Button();
            this.pBxPhoto = new System.Windows.Forms.PictureBox();
            this.cmbItem = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.idShow = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.purchasePriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.branchIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.oPStockDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hideDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.overHeadDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.priceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.extraAmountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.photoDataGridViewImageColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.createdatDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.updateatDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Stock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Edit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Delete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.vOfferItemsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsOfferItem1 = new Ncsln.Master.dsOfferItem();
            this.daOfferItem = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
            this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBxPhoto)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vOfferItemsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsOfferItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtSearch);
            this.panel1.Controls.Add(this.lbStock);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnPrint);
            this.panel1.Controls.Add(this.btnClear);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.btnResest);
            this.panel1.Controls.Add(this.btnSelectPicture);
            this.panel1.Controls.Add(this.pBxPhoto);
            this.panel1.Controls.Add(this.cmbItem);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1005, 369);
            this.panel1.TabIndex = 0;
            // 
            // lbStock
            // 
            this.lbStock.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbStock.AutoSize = true;
            this.lbStock.Location = new System.Drawing.Point(738, 156);
            this.lbStock.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbStock.Name = "lbStock";
            this.lbStock.Size = new System.Drawing.Size(18, 20);
            this.lbStock.TabIndex = 19;
            this.lbStock.Text = "0";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(674, 156);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 20);
            this.label1.TabIndex = 18;
            this.label1.Text = "Stock = ";
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnPrint.Location = new System.Drawing.Point(821, 279);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(137, 33);
            this.btnPrint.TabIndex = 17;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnClear
            // 
            this.btnClear.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnClear.Location = new System.Drawing.Point(678, 279);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(137, 33);
            this.btnClear.TabIndex = 16;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnSave.Location = new System.Drawing.Point(678, 239);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(137, 33);
            this.btnSave.TabIndex = 15;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnResest
            // 
            this.btnResest.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnResest.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnResest.Location = new System.Drawing.Point(678, 116);
            this.btnResest.Name = "btnResest";
            this.btnResest.Size = new System.Drawing.Size(137, 27);
            this.btnResest.TabIndex = 13;
            this.btnResest.Text = "Reset";
            this.btnResest.UseVisualStyleBackColor = true;
            this.btnResest.Click += new System.EventHandler(this.btnResest_Click);
            // 
            // btnSelectPicture
            // 
            this.btnSelectPicture.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnSelectPicture.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnSelectPicture.Location = new System.Drawing.Point(678, 83);
            this.btnSelectPicture.Name = "btnSelectPicture";
            this.btnSelectPicture.Size = new System.Drawing.Size(137, 27);
            this.btnSelectPicture.TabIndex = 12;
            this.btnSelectPicture.Text = "Picture";
            this.btnSelectPicture.UseVisualStyleBackColor = true;
            this.btnSelectPicture.Click += new System.EventHandler(this.btnSelectPicture_Click);
            // 
            // pBxPhoto
            // 
            this.pBxPhoto.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pBxPhoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pBxPhoto.Location = new System.Drawing.Point(225, 83);
            this.pBxPhoto.Name = "pBxPhoto";
            this.pBxPhoto.Size = new System.Drawing.Size(429, 229);
            this.pBxPhoto.TabIndex = 14;
            this.pBxPhoto.TabStop = false;
            // 
            // cmbItem
            // 
            this.cmbItem.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cmbItem.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbItem.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbItem.FormattingEnabled = true;
            this.cmbItem.Location = new System.Drawing.Point(225, 47);
            this.cmbItem.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbItem.Name = "cmbItem";
            this.cmbItem.Size = new System.Drawing.Size(590, 28);
            this.cmbItem.TabIndex = 3;
            this.cmbItem.SelectedIndexChanged += new System.EventHandler(this.cmbItem_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(147, 51);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Item";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 369);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1005, 188);
            this.panel2.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idShow,
            this.itemIdDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.codeDataGridViewTextBoxColumn,
            this.purchasePriceDataGridViewTextBoxColumn,
            this.branchIdDataGridViewTextBoxColumn,
            this.oPStockDataGridViewTextBoxColumn,
            this.hideDataGridViewCheckBoxColumn,
            this.overHeadDataGridViewTextBoxColumn,
            this.priceDataGridViewTextBoxColumn,
            this.extraAmountDataGridViewTextBoxColumn,
            this.photoDataGridViewImageColumn,
            this.createdatDataGridViewTextBoxColumn,
            this.updateatDataGridViewTextBoxColumn,
            this.Stock,
            this.Edit,
            this.Delete});
            this.dataGridView1.DataSource = this.vOfferItemsBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(1005, 188);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // idShow
            // 
            this.idShow.DataPropertyName = "Id";
            this.idShow.HeaderText = "Id";
            this.idShow.Name = "idShow";
            this.idShow.ReadOnly = true;
            this.idShow.Visible = false;
            // 
            // itemIdDataGridViewTextBoxColumn
            // 
            this.itemIdDataGridViewTextBoxColumn.DataPropertyName = "ItemId";
            this.itemIdDataGridViewTextBoxColumn.HeaderText = "Item Id";
            this.itemIdDataGridViewTextBoxColumn.Name = "itemIdDataGridViewTextBoxColumn";
            this.itemIdDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // codeDataGridViewTextBoxColumn
            // 
            this.codeDataGridViewTextBoxColumn.DataPropertyName = "Code";
            this.codeDataGridViewTextBoxColumn.HeaderText = "Code";
            this.codeDataGridViewTextBoxColumn.Name = "codeDataGridViewTextBoxColumn";
            this.codeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // purchasePriceDataGridViewTextBoxColumn
            // 
            this.purchasePriceDataGridViewTextBoxColumn.DataPropertyName = "PurchasePrice";
            this.purchasePriceDataGridViewTextBoxColumn.HeaderText = "PurchasePrice";
            this.purchasePriceDataGridViewTextBoxColumn.Name = "purchasePriceDataGridViewTextBoxColumn";
            this.purchasePriceDataGridViewTextBoxColumn.ReadOnly = true;
            this.purchasePriceDataGridViewTextBoxColumn.Visible = false;
            // 
            // branchIdDataGridViewTextBoxColumn
            // 
            this.branchIdDataGridViewTextBoxColumn.DataPropertyName = "Branch_Id";
            this.branchIdDataGridViewTextBoxColumn.HeaderText = "Branch_Id";
            this.branchIdDataGridViewTextBoxColumn.Name = "branchIdDataGridViewTextBoxColumn";
            this.branchIdDataGridViewTextBoxColumn.ReadOnly = true;
            this.branchIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // oPStockDataGridViewTextBoxColumn
            // 
            this.oPStockDataGridViewTextBoxColumn.DataPropertyName = "OPStock";
            this.oPStockDataGridViewTextBoxColumn.HeaderText = "OPStock";
            this.oPStockDataGridViewTextBoxColumn.Name = "oPStockDataGridViewTextBoxColumn";
            this.oPStockDataGridViewTextBoxColumn.ReadOnly = true;
            this.oPStockDataGridViewTextBoxColumn.Visible = false;
            // 
            // hideDataGridViewCheckBoxColumn
            // 
            this.hideDataGridViewCheckBoxColumn.DataPropertyName = "Hide";
            this.hideDataGridViewCheckBoxColumn.HeaderText = "Hide";
            this.hideDataGridViewCheckBoxColumn.Name = "hideDataGridViewCheckBoxColumn";
            this.hideDataGridViewCheckBoxColumn.ReadOnly = true;
            this.hideDataGridViewCheckBoxColumn.Visible = false;
            // 
            // overHeadDataGridViewTextBoxColumn
            // 
            this.overHeadDataGridViewTextBoxColumn.DataPropertyName = "OverHead";
            this.overHeadDataGridViewTextBoxColumn.HeaderText = "OverHead";
            this.overHeadDataGridViewTextBoxColumn.Name = "overHeadDataGridViewTextBoxColumn";
            this.overHeadDataGridViewTextBoxColumn.ReadOnly = true;
            this.overHeadDataGridViewTextBoxColumn.Visible = false;
            // 
            // priceDataGridViewTextBoxColumn
            // 
            this.priceDataGridViewTextBoxColumn.DataPropertyName = "Price";
            this.priceDataGridViewTextBoxColumn.HeaderText = "Price";
            this.priceDataGridViewTextBoxColumn.Name = "priceDataGridViewTextBoxColumn";
            this.priceDataGridViewTextBoxColumn.ReadOnly = true;
            this.priceDataGridViewTextBoxColumn.Visible = false;
            // 
            // extraAmountDataGridViewTextBoxColumn
            // 
            this.extraAmountDataGridViewTextBoxColumn.DataPropertyName = "ExtraAmount";
            this.extraAmountDataGridViewTextBoxColumn.HeaderText = "ExtraAmount";
            this.extraAmountDataGridViewTextBoxColumn.Name = "extraAmountDataGridViewTextBoxColumn";
            this.extraAmountDataGridViewTextBoxColumn.ReadOnly = true;
            this.extraAmountDataGridViewTextBoxColumn.Visible = false;
            // 
            // photoDataGridViewImageColumn
            // 
            this.photoDataGridViewImageColumn.DataPropertyName = "Photo";
            this.photoDataGridViewImageColumn.HeaderText = "Photo";
            this.photoDataGridViewImageColumn.Name = "photoDataGridViewImageColumn";
            this.photoDataGridViewImageColumn.ReadOnly = true;
            this.photoDataGridViewImageColumn.Visible = false;
            // 
            // createdatDataGridViewTextBoxColumn
            // 
            this.createdatDataGridViewTextBoxColumn.DataPropertyName = "created_at";
            this.createdatDataGridViewTextBoxColumn.HeaderText = "created_at";
            this.createdatDataGridViewTextBoxColumn.Name = "createdatDataGridViewTextBoxColumn";
            this.createdatDataGridViewTextBoxColumn.ReadOnly = true;
            this.createdatDataGridViewTextBoxColumn.Visible = false;
            // 
            // updateatDataGridViewTextBoxColumn
            // 
            this.updateatDataGridViewTextBoxColumn.DataPropertyName = "update_at";
            this.updateatDataGridViewTextBoxColumn.HeaderText = "update_at";
            this.updateatDataGridViewTextBoxColumn.Name = "updateatDataGridViewTextBoxColumn";
            this.updateatDataGridViewTextBoxColumn.ReadOnly = true;
            this.updateatDataGridViewTextBoxColumn.Visible = false;
            // 
            // Stock
            // 
            this.Stock.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Stock.DataPropertyName = "Stock";
            this.Stock.FillWeight = 70F;
            this.Stock.HeaderText = "Stock";
            this.Stock.Name = "Stock";
            this.Stock.ReadOnly = true;
            this.Stock.Width = 70;
            // 
            // Edit
            // 
            this.Edit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Edit.FillWeight = 80F;
            this.Edit.HeaderText = "Edit";
            this.Edit.Name = "Edit";
            this.Edit.ReadOnly = true;
            this.Edit.Text = "Edit";
            this.Edit.ToolTipText = "Edit";
            this.Edit.UseColumnTextForButtonValue = true;
            // 
            // Delete
            // 
            this.Delete.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Delete.FillWeight = 80F;
            this.Delete.HeaderText = "Delete";
            this.Delete.Name = "Delete";
            this.Delete.ReadOnly = true;
            this.Delete.Text = "Delete";
            this.Delete.ToolTipText = "Delete";
            this.Delete.UseColumnTextForButtonValue = true;
            // 
            // vOfferItemsBindingSource
            // 
            this.vOfferItemsBindingSource.DataMember = "vOfferItems";
            this.vOfferItemsBindingSource.DataSource = this.dsOfferItem1;
            // 
            // dsOfferItem1
            // 
            this.dsOfferItem1.DataSetName = "dsOfferItem";
            this.dsOfferItem1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // daOfferItem
            // 
            this.daOfferItem.SelectCommand = this.sqlSelectCommand1;
            this.daOfferItem.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "vOfferItems", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("Id", "Id"),
                        new System.Data.Common.DataColumnMapping("ItemId", "ItemId"),
                        new System.Data.Common.DataColumnMapping("Name", "Name"),
                        new System.Data.Common.DataColumnMapping("Code", "Code"),
                        new System.Data.Common.DataColumnMapping("PurchasePrice", "PurchasePrice"),
                        new System.Data.Common.DataColumnMapping("Branch_Id", "Branch_Id"),
                        new System.Data.Common.DataColumnMapping("OPStock", "OPStock"),
                        new System.Data.Common.DataColumnMapping("Hide", "Hide"),
                        new System.Data.Common.DataColumnMapping("OverHead", "OverHead"),
                        new System.Data.Common.DataColumnMapping("Price", "Price"),
                        new System.Data.Common.DataColumnMapping("ExtraAmount", "ExtraAmount"),
                        new System.Data.Common.DataColumnMapping("Photo", "Photo"),
                        new System.Data.Common.DataColumnMapping("created_at", "created_at"),
                        new System.Data.Common.DataColumnMapping("update_at", "update_at"),
                        new System.Data.Common.DataColumnMapping("Stock", "Stock")})});
            // 
            // sqlSelectCommand1
            // 
            this.sqlSelectCommand1.CommandText = resources.GetString("sqlSelectCommand1.CommandText");
            this.sqlSelectCommand1.Connection = this.sqlConnection1;
            this.sqlSelectCommand1.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@key", System.Data.SqlDbType.NVarChar, 250, "Name")});
            // 
            // sqlConnection1
            // 
            this.sqlConnection1.ConnectionString = "Data Source=(local);Initial Catalog=InventoryServer;Persist Security Info=Tr" +
    "ue;User ID=adminom";
            this.sqlConnection1.FireInfoMessageEventOnUserErrors = false;
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtSearch.Location = new System.Drawing.Point(225, 335);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(429, 26);
            this.txtSearch.TabIndex = 20;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(147, 338);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 20);
            this.label3.TabIndex = 21;
            this.label3.Text = "Search";
            // 
            // frmOffers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1005, 557);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmOffers";
            this.Text = "Promotional Item";
            this.Load += new System.EventHandler(this.frmOffers_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBxPhoto)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vOfferItemsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsOfferItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox cmbItem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnResest;
        private System.Windows.Forms.Button btnSelectPicture;
        private System.Windows.Forms.PictureBox pBxPhoto;
        private System.Data.SqlClient.SqlDataAdapter daOfferItem;
        private System.Data.SqlClient.SqlCommand sqlSelectCommand1;
        private System.Data.SqlClient.SqlConnection sqlConnection1;
        private dsOfferItem dsOfferItem1;
        private System.Windows.Forms.BindingSource vOfferItemsBindingSource;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Label lbStock;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idShow;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn codeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn purchasePriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn branchIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn oPStockDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn hideDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn overHeadDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn priceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn extraAmountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewImageColumn photoDataGridViewImageColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn createdatDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn updateatDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Stock;
        private System.Windows.Forms.DataGridViewButtonColumn Edit;
        private System.Windows.Forms.DataGridViewButtonColumn Delete;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSearch;
    }
}