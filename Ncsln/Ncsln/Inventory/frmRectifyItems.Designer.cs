namespace Ncsln.Inventory
{
    partial class frmRectifyItems
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRectifyItems));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtServerSearch = new System.Windows.Forms.TextBox();
            this.txtLocalSearch = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtServerPrice = new System.Windows.Forms.TextBox();
            this.txtServerModel = new System.Windows.Forms.TextBox();
            this.txtCurrentPrice = new System.Windows.Forms.TextBox();
            this.txtCurrentModel = new System.Windows.Forms.TextBox();
            this.lbBranchName = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.txtServerItem = new System.Windows.Forms.TextBox();
            this.txtServerItemId = new System.Windows.Forms.TextBox();
            this.txtCurrentItem = new System.Windows.Forms.TextBox();
            this.txtLocalItemId = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dgvLocal = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.decriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.salePriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vendorIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.oStockDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.serverIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Old_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TryToChange = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Select = new System.Windows.Forms.DataGridViewButtonColumn();
            this.itemsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsRLocalItems1 = new Ncsln.Inventory.dsRLocalItems();
            this.dgvServer = new System.Windows.Forms.DataGridView();
            this.Ids = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.titles = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prices = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.branchIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.oPStockDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hideDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Selected = new System.Windows.Forms.DataGridViewButtonColumn();
            this.itemListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsRServerItems1 = new Ncsln.Inventory.dsRServerItems();
            this.daLocalItems = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlDeleteCommand = new System.Data.SqlClient.SqlCommand();
            this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
            this.sqlInsertCommand = new System.Data.SqlClient.SqlCommand();
            this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
            this.sqlUpdateCommand = new System.Data.SqlClient.SqlCommand();
            this.daServerItems = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlCommand1 = new System.Data.SqlClient.SqlCommand();
            this.sqlCommand2 = new System.Data.SqlClient.SqlCommand();
            this.sqlCommand3 = new System.Data.SqlClient.SqlCommand();
            this.sqlCommand4 = new System.Data.SqlClient.SqlCommand();
            this.daLocalSetItems = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlCommand5 = new System.Data.SqlClient.SqlCommand();
            this.sqlCommand6 = new System.Data.SqlClient.SqlCommand();
            this.sqlCommand7 = new System.Data.SqlClient.SqlCommand();
            this.sqlCommand8 = new System.Data.SqlClient.SqlCommand();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsRLocalItems1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemListBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsRServerItems1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtServerSearch);
            this.panel1.Controls.Add(this.txtLocalSearch);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1136, 66);
            this.panel1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(677, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Server Items";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(103, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Current Items";
            // 
            // txtServerSearch
            // 
            this.txtServerSearch.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtServerSearch.Location = new System.Drawing.Point(680, 38);
            this.txtServerSearch.Name = "txtServerSearch";
            this.txtServerSearch.Size = new System.Drawing.Size(368, 22);
            this.txtServerSearch.TabIndex = 1;
            this.txtServerSearch.TextChanged += new System.EventHandler(this.txtServerSearch_TextChanged);
            // 
            // txtLocalSearch
            // 
            this.txtLocalSearch.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtLocalSearch.Location = new System.Drawing.Point(103, 38);
            this.txtLocalSearch.Name = "txtLocalSearch";
            this.txtLocalSearch.Size = new System.Drawing.Size(368, 22);
            this.txtLocalSearch.TabIndex = 0;
            this.txtLocalSearch.TextChanged += new System.EventHandler(this.txtLocalSearch_TextChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtServerPrice);
            this.panel2.Controls.Add(this.txtServerModel);
            this.panel2.Controls.Add(this.txtCurrentPrice);
            this.panel2.Controls.Add(this.txtCurrentModel);
            this.panel2.Controls.Add(this.lbBranchName);
            this.panel2.Controls.Add(this.btnClear);
            this.panel2.Controls.Add(this.btnConfirm);
            this.panel2.Controls.Add(this.txtServerItem);
            this.panel2.Controls.Add(this.txtServerItemId);
            this.panel2.Controls.Add(this.txtCurrentItem);
            this.panel2.Controls.Add(this.txtLocalItemId);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 288);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1136, 339);
            this.panel2.TabIndex = 1;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // txtServerPrice
            // 
            this.txtServerPrice.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtServerPrice.BackColor = System.Drawing.SystemColors.Window;
            this.txtServerPrice.Enabled = false;
            this.txtServerPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtServerPrice.Location = new System.Drawing.Point(332, 195);
            this.txtServerPrice.Name = "txtServerPrice";
            this.txtServerPrice.ReadOnly = true;
            this.txtServerPrice.Size = new System.Drawing.Size(178, 26);
            this.txtServerPrice.TabIndex = 12;
            // 
            // txtServerModel
            // 
            this.txtServerModel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtServerModel.BackColor = System.Drawing.SystemColors.Window;
            this.txtServerModel.Enabled = false;
            this.txtServerModel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtServerModel.Location = new System.Drawing.Point(332, 163);
            this.txtServerModel.Name = "txtServerModel";
            this.txtServerModel.ReadOnly = true;
            this.txtServerModel.Size = new System.Drawing.Size(178, 26);
            this.txtServerModel.TabIndex = 11;
            // 
            // txtCurrentPrice
            // 
            this.txtCurrentPrice.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtCurrentPrice.BackColor = System.Drawing.SystemColors.Window;
            this.txtCurrentPrice.Enabled = false;
            this.txtCurrentPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCurrentPrice.Location = new System.Drawing.Point(332, 83);
            this.txtCurrentPrice.Name = "txtCurrentPrice";
            this.txtCurrentPrice.ReadOnly = true;
            this.txtCurrentPrice.Size = new System.Drawing.Size(178, 26);
            this.txtCurrentPrice.TabIndex = 10;
            // 
            // txtCurrentModel
            // 
            this.txtCurrentModel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtCurrentModel.BackColor = System.Drawing.SystemColors.Window;
            this.txtCurrentModel.Enabled = false;
            this.txtCurrentModel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCurrentModel.Location = new System.Drawing.Point(332, 51);
            this.txtCurrentModel.Name = "txtCurrentModel";
            this.txtCurrentModel.ReadOnly = true;
            this.txtCurrentModel.Size = new System.Drawing.Size(178, 26);
            this.txtCurrentModel.TabIndex = 9;
            // 
            // lbBranchName
            // 
            this.lbBranchName.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbBranchName.AutoSize = true;
            this.lbBranchName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbBranchName.Location = new System.Drawing.Point(210, 233);
            this.lbBranchName.Name = "lbBranchName";
            this.lbBranchName.Size = new System.Drawing.Size(137, 24);
            this.lbBranchName.TabIndex = 8;
            this.lbBranchName.Text = "Branch Name";
            // 
            // btnClear
            // 
            this.btnClear.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnClear.Location = new System.Drawing.Point(843, 249);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 30);
            this.btnClear.TabIndex = 7;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnConfirm
            // 
            this.btnConfirm.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnConfirm.Location = new System.Drawing.Point(762, 249);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(75, 30);
            this.btnConfirm.TabIndex = 6;
            this.btnConfirm.Text = "Confirm";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // txtServerItem
            // 
            this.txtServerItem.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtServerItem.BackColor = System.Drawing.SystemColors.Window;
            this.txtServerItem.Enabled = false;
            this.txtServerItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtServerItem.Location = new System.Drawing.Point(516, 131);
            this.txtServerItem.Multiline = true;
            this.txtServerItem.Name = "txtServerItem";
            this.txtServerItem.ReadOnly = true;
            this.txtServerItem.Size = new System.Drawing.Size(402, 90);
            this.txtServerItem.TabIndex = 5;
            // 
            // txtServerItemId
            // 
            this.txtServerItemId.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtServerItemId.BackColor = System.Drawing.SystemColors.Window;
            this.txtServerItemId.Enabled = false;
            this.txtServerItemId.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtServerItemId.Location = new System.Drawing.Point(332, 131);
            this.txtServerItemId.Name = "txtServerItemId";
            this.txtServerItemId.ReadOnly = true;
            this.txtServerItemId.Size = new System.Drawing.Size(178, 26);
            this.txtServerItemId.TabIndex = 4;
            // 
            // txtCurrentItem
            // 
            this.txtCurrentItem.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtCurrentItem.BackColor = System.Drawing.SystemColors.Window;
            this.txtCurrentItem.Enabled = false;
            this.txtCurrentItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCurrentItem.Location = new System.Drawing.Point(516, 19);
            this.txtCurrentItem.Multiline = true;
            this.txtCurrentItem.Name = "txtCurrentItem";
            this.txtCurrentItem.ReadOnly = true;
            this.txtCurrentItem.Size = new System.Drawing.Size(402, 90);
            this.txtCurrentItem.TabIndex = 3;
            // 
            // txtLocalItemId
            // 
            this.txtLocalItemId.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtLocalItemId.BackColor = System.Drawing.SystemColors.Window;
            this.txtLocalItemId.Enabled = false;
            this.txtLocalItemId.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLocalItemId.Location = new System.Drawing.Point(332, 19);
            this.txtLocalItemId.Name = "txtLocalItemId";
            this.txtLocalItemId.ReadOnly = true;
            this.txtLocalItemId.Size = new System.Drawing.Size(178, 26);
            this.txtLocalItemId.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(210, 129);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 24);
            this.label4.TabIndex = 1;
            this.label4.Text = "Server Item";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(202, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 24);
            this.label3.TabIndex = 0;
            this.label3.Text = "Current Item";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 66);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgvLocal);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvServer);
            this.splitContainer1.Size = new System.Drawing.Size(1136, 222);
            this.splitContainer1.SplitterDistance = 577;
            this.splitContainer1.TabIndex = 2;
            // 
            // dgvLocal
            // 
            this.dgvLocal.AllowUserToAddRows = false;
            this.dgvLocal.AllowUserToDeleteRows = false;
            this.dgvLocal.AutoGenerateColumns = false;
            this.dgvLocal.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLocal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLocal.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.code,
            this.title,
            this.decriptionDataGridViewTextBoxColumn,
            this.price,
            this.salePriceDataGridViewTextBoxColumn,
            this.vendorIdDataGridViewTextBoxColumn,
            this.oStockDataGridViewTextBoxColumn,
            this.serverIdDataGridViewTextBoxColumn,
            this.Old_Id,
            this.TryToChange,
            this.Select});
            this.dgvLocal.DataSource = this.itemsBindingSource;
            this.dgvLocal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLocal.Location = new System.Drawing.Point(0, 0);
            this.dgvLocal.Name = "dgvLocal";
            this.dgvLocal.ReadOnly = true;
            this.dgvLocal.RowHeadersVisible = false;
            this.dgvLocal.RowTemplate.Height = 24;
            this.dgvLocal.Size = new System.Drawing.Size(577, 222);
            this.dgvLocal.TabIndex = 0;
            this.dgvLocal.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLocal_CellContentClick);
            this.dgvLocal.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvLocal_RowPostPaint);
            // 
            // Id
            // 
            this.Id.DataPropertyName = "ItemId";
            this.Id.HeaderText = "ItemId";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            // 
            // code
            // 
            this.code.DataPropertyName = "Code";
            this.code.HeaderText = "Model";
            this.code.Name = "code";
            this.code.ReadOnly = true;
            // 
            // title
            // 
            this.title.DataPropertyName = "Title";
            this.title.HeaderText = "Title";
            this.title.Name = "title";
            this.title.ReadOnly = true;
            // 
            // decriptionDataGridViewTextBoxColumn
            // 
            this.decriptionDataGridViewTextBoxColumn.DataPropertyName = "Decription";
            this.decriptionDataGridViewTextBoxColumn.HeaderText = "Decription";
            this.decriptionDataGridViewTextBoxColumn.Name = "decriptionDataGridViewTextBoxColumn";
            this.decriptionDataGridViewTextBoxColumn.ReadOnly = true;
            this.decriptionDataGridViewTextBoxColumn.Visible = false;
            // 
            // price
            // 
            this.price.DataPropertyName = "PurchasePrice";
            this.price.HeaderText = "Price";
            this.price.Name = "price";
            this.price.ReadOnly = true;
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
            // Old_Id
            // 
            this.Old_Id.DataPropertyName = "Old_Id";
            this.Old_Id.HeaderText = "Old_Id";
            this.Old_Id.Name = "Old_Id";
            this.Old_Id.ReadOnly = true;
            // 
            // TryToChange
            // 
            this.TryToChange.DataPropertyName = "TryToChange";
            this.TryToChange.HeaderText = "TryToChange";
            this.TryToChange.Name = "TryToChange";
            this.TryToChange.ReadOnly = true;
            this.TryToChange.Visible = false;
            // 
            // Select
            // 
            this.Select.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Select.HeaderText = "Select";
            this.Select.Name = "Select";
            this.Select.ReadOnly = true;
            this.Select.Text = "Select";
            this.Select.ToolTipText = "Select";
            this.Select.UseColumnTextForButtonValue = true;
            this.Select.Width = 80;
            // 
            // itemsBindingSource
            // 
            this.itemsBindingSource.DataMember = "Items";
            this.itemsBindingSource.DataSource = this.dsRLocalItems1;
            // 
            // dsRLocalItems1
            // 
            this.dsRLocalItems1.DataSetName = "dsRLocalItems";
            this.dsRLocalItems1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dgvServer
            // 
            this.dgvServer.AllowUserToAddRows = false;
            this.dgvServer.AllowUserToDeleteRows = false;
            this.dgvServer.AutoGenerateColumns = false;
            this.dgvServer.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvServer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvServer.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Ids,
            this.codes,
            this.titles,
            this.prices,
            this.branchIdDataGridViewTextBoxColumn,
            this.oPStockDataGridViewTextBoxColumn,
            this.hideDataGridViewCheckBoxColumn,
            this.Selected});
            this.dgvServer.DataSource = this.itemListBindingSource;
            this.dgvServer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvServer.Location = new System.Drawing.Point(0, 0);
            this.dgvServer.Name = "dgvServer";
            this.dgvServer.ReadOnly = true;
            this.dgvServer.RowHeadersVisible = false;
            this.dgvServer.RowTemplate.Height = 24;
            this.dgvServer.Size = new System.Drawing.Size(555, 222);
            this.dgvServer.TabIndex = 0;
            this.dgvServer.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvServer_CellContentClick);
            // 
            // Ids
            // 
            this.Ids.DataPropertyName = "Id";
            this.Ids.HeaderText = "Id";
            this.Ids.Name = "Ids";
            this.Ids.ReadOnly = true;
            // 
            // codes
            // 
            this.codes.DataPropertyName = "Code";
            this.codes.HeaderText = "Model";
            this.codes.Name = "codes";
            this.codes.ReadOnly = true;
            // 
            // titles
            // 
            this.titles.DataPropertyName = "Name";
            this.titles.HeaderText = "Title";
            this.titles.Name = "titles";
            this.titles.ReadOnly = true;
            // 
            // prices
            // 
            this.prices.DataPropertyName = "PurchasePrice";
            this.prices.HeaderText = "Price";
            this.prices.Name = "prices";
            this.prices.ReadOnly = true;
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
            // Selected
            // 
            this.Selected.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Selected.HeaderText = "Select";
            this.Selected.Name = "Selected";
            this.Selected.ReadOnly = true;
            this.Selected.Text = "Select";
            this.Selected.ToolTipText = "Select";
            this.Selected.UseColumnTextForButtonValue = true;
            this.Selected.Width = 80;
            // 
            // itemListBindingSource
            // 
            this.itemListBindingSource.DataMember = "ItemList";
            this.itemListBindingSource.DataSource = this.dsRServerItems1;
            // 
            // dsRServerItems1
            // 
            this.dsRServerItems1.DataSetName = "dsRServerItems";
            this.dsRServerItems1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // daLocalItems
            // 
            this.daLocalItems.DeleteCommand = this.sqlDeleteCommand;
            this.daLocalItems.InsertCommand = this.sqlInsertCommand;
            this.daLocalItems.SelectCommand = this.sqlSelectCommand1;
            this.daLocalItems.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "Items", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ItemId", "ItemId"),
                        new System.Data.Common.DataColumnMapping("Title", "Title"),
                        new System.Data.Common.DataColumnMapping("Decription", "Decription"),
                        new System.Data.Common.DataColumnMapping("Code", "Code"),
                        new System.Data.Common.DataColumnMapping("PurchasePrice", "PurchasePrice"),
                        new System.Data.Common.DataColumnMapping("SalePrice", "SalePrice"),
                        new System.Data.Common.DataColumnMapping("VendorId", "VendorId"),
                        new System.Data.Common.DataColumnMapping("OStock", "OStock"),
                        new System.Data.Common.DataColumnMapping("Server_Id", "Server_Id"),
                        new System.Data.Common.DataColumnMapping("Old_Id", "Old_Id"),
                        new System.Data.Common.DataColumnMapping("TryToChange", "TryToChange")})});
            this.daLocalItems.UpdateCommand = this.sqlUpdateCommand;
            // 
            // sqlDeleteCommand
            // 
            this.sqlDeleteCommand.CommandText = resources.GetString("sqlDeleteCommand.CommandText");
            this.sqlDeleteCommand.Connection = this.sqlConnection1;
            this.sqlDeleteCommand.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@Original_ItemId", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ItemId", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_Title", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Title", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_Title", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Title", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_Decription", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Decription", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_Decription", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Decription", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_Code", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Code", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_Code", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Code", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_PurchasePrice", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "PurchasePrice", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_PurchasePrice", System.Data.SqlDbType.Decimal, 0, System.Data.ParameterDirection.Input, false, ((byte)(18)), ((byte)(2)), "PurchasePrice", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_SalePrice", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "SalePrice", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_SalePrice", System.Data.SqlDbType.Decimal, 0, System.Data.ParameterDirection.Input, false, ((byte)(18)), ((byte)(2)), "SalePrice", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_VendorId", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "VendorId", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_VendorId", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "VendorId", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_OStock", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "OStock", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_OStock", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "OStock", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_Server_Id", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Server_Id", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_Server_Id", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Server_Id", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_Old_Id", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Old_Id", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_Old_Id", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Old_Id", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_TryToChange", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "TryToChange", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_TryToChange", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "TryToChange", System.Data.DataRowVersion.Original, null)});
            // 
            // sqlConnection1
            // 
            this.sqlConnection1.ConnectionString = "Data Source=.;Initial Catalog=Inventory-oe;Integrated Security=True";
            this.sqlConnection1.FireInfoMessageEventOnUserErrors = false;
            // 
            // sqlInsertCommand
            // 
            this.sqlInsertCommand.CommandText = resources.GetString("sqlInsertCommand.CommandText");
            this.sqlInsertCommand.Connection = this.sqlConnection1;
            this.sqlInsertCommand.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@ItemId", System.Data.SqlDbType.Int, 0, "ItemId"),
            new System.Data.SqlClient.SqlParameter("@Title", System.Data.SqlDbType.NVarChar, 0, "Title"),
            new System.Data.SqlClient.SqlParameter("@Decription", System.Data.SqlDbType.NVarChar, 0, "Decription"),
            new System.Data.SqlClient.SqlParameter("@Code", System.Data.SqlDbType.NVarChar, 0, "Code"),
            new System.Data.SqlClient.SqlParameter("@PurchasePrice", System.Data.SqlDbType.Decimal, 0, System.Data.ParameterDirection.Input, false, ((byte)(18)), ((byte)(2)), "PurchasePrice", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@SalePrice", System.Data.SqlDbType.Decimal, 0, System.Data.ParameterDirection.Input, false, ((byte)(18)), ((byte)(2)), "SalePrice", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@VendorId", System.Data.SqlDbType.Int, 0, "VendorId"),
            new System.Data.SqlClient.SqlParameter("@OStock", System.Data.SqlDbType.Int, 0, "OStock"),
            new System.Data.SqlClient.SqlParameter("@Server_Id", System.Data.SqlDbType.Int, 0, "Server_Id"),
            new System.Data.SqlClient.SqlParameter("@Old_Id", System.Data.SqlDbType.Int, 0, "Old_Id"),
            new System.Data.SqlClient.SqlParameter("@TryToChange", System.Data.SqlDbType.NVarChar, 0, "TryToChange")});
            // 
            // sqlSelectCommand1
            // 
            this.sqlSelectCommand1.CommandText = resources.GetString("sqlSelectCommand1.CommandText");
            this.sqlSelectCommand1.Connection = this.sqlConnection1;
            // 
            // sqlUpdateCommand
            // 
            this.sqlUpdateCommand.CommandText = resources.GetString("sqlUpdateCommand.CommandText");
            this.sqlUpdateCommand.Connection = this.sqlConnection1;
            this.sqlUpdateCommand.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@ItemId", System.Data.SqlDbType.Int, 0, "ItemId"),
            new System.Data.SqlClient.SqlParameter("@Title", System.Data.SqlDbType.NVarChar, 0, "Title"),
            new System.Data.SqlClient.SqlParameter("@Decription", System.Data.SqlDbType.NVarChar, 0, "Decription"),
            new System.Data.SqlClient.SqlParameter("@Code", System.Data.SqlDbType.NVarChar, 0, "Code"),
            new System.Data.SqlClient.SqlParameter("@PurchasePrice", System.Data.SqlDbType.Decimal, 0, System.Data.ParameterDirection.Input, false, ((byte)(18)), ((byte)(2)), "PurchasePrice", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@SalePrice", System.Data.SqlDbType.Decimal, 0, System.Data.ParameterDirection.Input, false, ((byte)(18)), ((byte)(2)), "SalePrice", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@VendorId", System.Data.SqlDbType.Int, 0, "VendorId"),
            new System.Data.SqlClient.SqlParameter("@OStock", System.Data.SqlDbType.Int, 0, "OStock"),
            new System.Data.SqlClient.SqlParameter("@Server_Id", System.Data.SqlDbType.Int, 0, "Server_Id"),
            new System.Data.SqlClient.SqlParameter("@Old_Id", System.Data.SqlDbType.Int, 0, "Old_Id"),
            new System.Data.SqlClient.SqlParameter("@TryToChange", System.Data.SqlDbType.NVarChar, 0, "TryToChange"),
            new System.Data.SqlClient.SqlParameter("@Original_ItemId", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ItemId", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_Title", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Title", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_Title", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Title", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_Decription", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Decription", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_Decription", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Decription", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_Code", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Code", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_Code", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Code", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_PurchasePrice", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "PurchasePrice", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_PurchasePrice", System.Data.SqlDbType.Decimal, 0, System.Data.ParameterDirection.Input, false, ((byte)(18)), ((byte)(2)), "PurchasePrice", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_SalePrice", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "SalePrice", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_SalePrice", System.Data.SqlDbType.Decimal, 0, System.Data.ParameterDirection.Input, false, ((byte)(18)), ((byte)(2)), "SalePrice", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_VendorId", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "VendorId", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_VendorId", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "VendorId", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_OStock", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "OStock", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_OStock", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "OStock", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_Server_Id", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Server_Id", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_Server_Id", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Server_Id", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_Old_Id", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Old_Id", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_Old_Id", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Old_Id", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_TryToChange", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "TryToChange", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_TryToChange", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "TryToChange", System.Data.DataRowVersion.Original, null)});
            // 
            // daServerItems
            // 
            this.daServerItems.DeleteCommand = this.sqlCommand1;
            this.daServerItems.InsertCommand = this.sqlCommand2;
            this.daServerItems.SelectCommand = this.sqlCommand3;
            this.daServerItems.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ItemList", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("Id", "Id"),
                        new System.Data.Common.DataColumnMapping("Name", "Name"),
                        new System.Data.Common.DataColumnMapping("Code", "Code"),
                        new System.Data.Common.DataColumnMapping("PurchasePrice", "PurchasePrice"),
                        new System.Data.Common.DataColumnMapping("Branch_Id", "Branch_Id"),
                        new System.Data.Common.DataColumnMapping("OPStock", "OPStock"),
                        new System.Data.Common.DataColumnMapping("Hide", "Hide")})});
            this.daServerItems.UpdateCommand = this.sqlCommand4;
            // 
            // sqlCommand1
            // 
            this.sqlCommand1.CommandText = resources.GetString("sqlCommand1.CommandText");
            this.sqlCommand1.Connection = this.sqlConnection1;
            this.sqlCommand1.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@Original_Id", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Id", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_Name", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Name", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_Name", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Name", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_Code", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Code", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_Code", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Code", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_PurchasePrice", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "PurchasePrice", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_PurchasePrice", System.Data.SqlDbType.Decimal, 0, System.Data.ParameterDirection.Input, false, ((byte)(18)), ((byte)(2)), "PurchasePrice", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_Branch_Id", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Branch_Id", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_Branch_Id", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Branch_Id", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_OPStock", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "OPStock", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_OPStock", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "OPStock", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_Hide", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Hide", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_Hide", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Hide", System.Data.DataRowVersion.Original, null)});
            // 
            // sqlCommand2
            // 
            this.sqlCommand2.CommandText = resources.GetString("sqlCommand2.CommandText");
            this.sqlCommand2.Connection = this.sqlConnection1;
            this.sqlCommand2.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@Name", System.Data.SqlDbType.NVarChar, 0, "Name"),
            new System.Data.SqlClient.SqlParameter("@Code", System.Data.SqlDbType.NVarChar, 0, "Code"),
            new System.Data.SqlClient.SqlParameter("@PurchasePrice", System.Data.SqlDbType.Decimal, 0, System.Data.ParameterDirection.Input, false, ((byte)(18)), ((byte)(2)), "PurchasePrice", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@Branch_Id", System.Data.SqlDbType.Int, 0, "Branch_Id"),
            new System.Data.SqlClient.SqlParameter("@OPStock", System.Data.SqlDbType.Int, 0, "OPStock"),
            new System.Data.SqlClient.SqlParameter("@Hide", System.Data.SqlDbType.Bit, 0, "Hide")});
            // 
            // sqlCommand3
            // 
            this.sqlCommand3.CommandText = "SELECT Id, Name, Code, PurchasePrice, Branch_Id, OPStock, Hide\r\nFROM     ItemList" +
    "\r\nWHERE  (Name LIKE \'%\' + @key + \'%\') OR\r\n                  (Code LIKE \'%\' + @ke" +
    "y + \'%\')";
            this.sqlCommand3.Connection = this.sqlConnection1;
            this.sqlCommand3.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@key", System.Data.SqlDbType.NVarChar, 250, "Name")});
            // 
            // sqlCommand4
            // 
            this.sqlCommand4.CommandText = resources.GetString("sqlCommand4.CommandText");
            this.sqlCommand4.Connection = this.sqlConnection1;
            this.sqlCommand4.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@Name", System.Data.SqlDbType.NVarChar, 0, "Name"),
            new System.Data.SqlClient.SqlParameter("@Code", System.Data.SqlDbType.NVarChar, 0, "Code"),
            new System.Data.SqlClient.SqlParameter("@PurchasePrice", System.Data.SqlDbType.Decimal, 0, System.Data.ParameterDirection.Input, false, ((byte)(18)), ((byte)(2)), "PurchasePrice", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@Branch_Id", System.Data.SqlDbType.Int, 0, "Branch_Id"),
            new System.Data.SqlClient.SqlParameter("@OPStock", System.Data.SqlDbType.Int, 0, "OPStock"),
            new System.Data.SqlClient.SqlParameter("@Hide", System.Data.SqlDbType.Bit, 0, "Hide"),
            new System.Data.SqlClient.SqlParameter("@Original_Id", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Id", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_Name", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Name", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_Name", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Name", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_Code", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Code", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_Code", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Code", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_PurchasePrice", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "PurchasePrice", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_PurchasePrice", System.Data.SqlDbType.Decimal, 0, System.Data.ParameterDirection.Input, false, ((byte)(18)), ((byte)(2)), "PurchasePrice", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_Branch_Id", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Branch_Id", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_Branch_Id", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Branch_Id", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_OPStock", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "OPStock", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_OPStock", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "OPStock", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_Hide", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Hide", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_Hide", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Hide", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Id", System.Data.SqlDbType.Int, 4, "Id")});
            // 
            // daLocalSetItems
            // 
            this.daLocalSetItems.DeleteCommand = this.sqlCommand5;
            this.daLocalSetItems.InsertCommand = this.sqlCommand6;
            this.daLocalSetItems.SelectCommand = this.sqlCommand7;
            this.daLocalSetItems.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "Items", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("Id", "Id"),
                        new System.Data.Common.DataColumnMapping("Name", "Name"),
                        new System.Data.Common.DataColumnMapping("Code", "Code"),
                        new System.Data.Common.DataColumnMapping("PurchasePrice", "PurchasePrice"),
                        new System.Data.Common.DataColumnMapping("Branch_Id", "Branch_Id"),
                        new System.Data.Common.DataColumnMapping("OPStock", "OPStock"),
                        new System.Data.Common.DataColumnMapping("Hide", "Hide")})});
            this.daLocalSetItems.UpdateCommand = this.sqlCommand8;
            // 
            // sqlCommand5
            // 
            this.sqlCommand5.CommandText = resources.GetString("sqlCommand5.CommandText");
            this.sqlCommand5.Connection = this.sqlConnection1;
            this.sqlCommand5.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@Original_Id", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Id", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_Name", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Name", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_Name", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Name", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_Code", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Code", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_Code", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Code", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_PurchasePrice", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "PurchasePrice", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_PurchasePrice", System.Data.SqlDbType.Decimal, 0, System.Data.ParameterDirection.Input, false, ((byte)(18)), ((byte)(2)), "PurchasePrice", System.Data.DataRowVersion.Original, null)});
            // 
            // sqlCommand6
            // 
            this.sqlCommand6.CommandText = resources.GetString("sqlCommand6.CommandText");
            this.sqlCommand6.Connection = this.sqlConnection1;
            this.sqlCommand6.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@Id", System.Data.SqlDbType.Int, 0, "Id"),
            new System.Data.SqlClient.SqlParameter("@Name", System.Data.SqlDbType.NVarChar, 0, "Name"),
            new System.Data.SqlClient.SqlParameter("@Code", System.Data.SqlDbType.NVarChar, 0, "Code"),
            new System.Data.SqlClient.SqlParameter("@PurchasePrice", System.Data.SqlDbType.Decimal, 0, System.Data.ParameterDirection.Input, false, ((byte)(18)), ((byte)(2)), "PurchasePrice", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@ItemId", System.Data.SqlDbType.Int, 4, "Id")});
            // 
            // sqlCommand7
            // 
            this.sqlCommand7.CommandText = resources.GetString("sqlCommand7.CommandText");
            this.sqlCommand7.Connection = this.sqlConnection1;
            this.sqlCommand7.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@key", System.Data.SqlDbType.NVarChar, 500, "Name")});
            // 
            // sqlCommand8
            // 
            this.sqlCommand8.CommandText = resources.GetString("sqlCommand8.CommandText");
            this.sqlCommand8.Connection = this.sqlConnection1;
            this.sqlCommand8.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@Id", System.Data.SqlDbType.Int, 0, "Id"),
            new System.Data.SqlClient.SqlParameter("@Name", System.Data.SqlDbType.NVarChar, 0, "Name"),
            new System.Data.SqlClient.SqlParameter("@Code", System.Data.SqlDbType.NVarChar, 0, "Code"),
            new System.Data.SqlClient.SqlParameter("@PurchasePrice", System.Data.SqlDbType.Decimal, 0, System.Data.ParameterDirection.Input, false, ((byte)(18)), ((byte)(2)), "PurchasePrice", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@Original_Id", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Id", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_Name", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Name", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_Name", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Name", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_Code", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Code", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_Code", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Code", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_PurchasePrice", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "PurchasePrice", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_PurchasePrice", System.Data.SqlDbType.Decimal, 0, System.Data.ParameterDirection.Input, false, ((byte)(18)), ((byte)(2)), "PurchasePrice", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@ItemId", System.Data.SqlDbType.Int, 4, "Id")});
            // 
            // frmRectifyItems
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1136, 627);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "frmRectifyItems";
            this.Text = "Rectify Items";
            this.Load += new System.EventHandler(this.frmRectifyItems_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsRLocalItems1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemListBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsRServerItems1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dgvLocal;
        private System.Windows.Forms.DataGridView dgvServer;
        private System.Windows.Forms.TextBox txtServerSearch;
        private System.Windows.Forms.TextBox txtLocalSearch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Data.SqlClient.SqlDataAdapter daLocalItems;
        private System.Data.SqlClient.SqlCommand sqlDeleteCommand;
        private System.Data.SqlClient.SqlConnection sqlConnection1;
        private System.Data.SqlClient.SqlCommand sqlInsertCommand;
        private System.Data.SqlClient.SqlCommand sqlSelectCommand1;
        private System.Data.SqlClient.SqlCommand sqlUpdateCommand;
        private dsRLocalItems dsRLocalItems1;
        private System.Windows.Forms.BindingSource itemsBindingSource;
        private System.Data.SqlClient.SqlDataAdapter daServerItems;
        private System.Data.SqlClient.SqlCommand sqlCommand1;
        private System.Data.SqlClient.SqlCommand sqlCommand2;
        private System.Data.SqlClient.SqlCommand sqlCommand3;
        private System.Data.SqlClient.SqlCommand sqlCommand4;
        private dsRServerItems dsRServerItems1;
        private System.Windows.Forms.BindingSource itemListBindingSource;
        private System.Windows.Forms.TextBox txtServerItem;
        private System.Windows.Forms.TextBox txtServerItemId;
        private System.Windows.Forms.TextBox txtCurrentItem;
        private System.Windows.Forms.TextBox txtLocalItemId;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Label lbBranchName;
        private System.Windows.Forms.TextBox txtServerPrice;
        private System.Windows.Forms.TextBox txtServerModel;
        private System.Windows.Forms.TextBox txtCurrentPrice;
        private System.Windows.Forms.TextBox txtCurrentModel;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ids;
        private System.Windows.Forms.DataGridViewTextBoxColumn codes;
        private System.Windows.Forms.DataGridViewTextBoxColumn titles;
        private System.Windows.Forms.DataGridViewTextBoxColumn prices;
        private System.Windows.Forms.DataGridViewTextBoxColumn branchIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn oPStockDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn hideDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewButtonColumn Selected;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn code;
        private System.Windows.Forms.DataGridViewTextBoxColumn title;
        private System.Windows.Forms.DataGridViewTextBoxColumn decriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn price;
        private System.Windows.Forms.DataGridViewTextBoxColumn salePriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vendorIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn oStockDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn serverIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Old_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn TryToChange;
        private System.Windows.Forms.DataGridViewButtonColumn Select;
        private System.Data.SqlClient.SqlDataAdapter daLocalSetItems;
        private System.Data.SqlClient.SqlCommand sqlCommand5;
        private System.Data.SqlClient.SqlCommand sqlCommand6;
        private System.Data.SqlClient.SqlCommand sqlCommand7;
        private System.Data.SqlClient.SqlCommand sqlCommand8;
    }
}