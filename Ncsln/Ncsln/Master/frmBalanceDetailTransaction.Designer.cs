namespace Ncsln.Master
{
    partial class frmBalanceDetailTransaction
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ComboBox cmbBalanceDetail;
        private System.Windows.Forms.DateTimePicker dtpTransactionDate;
        private System.Windows.Forms.RichTextBox txtDescription;
        private System.Windows.Forms.NumericUpDown txtAmount;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.DataGridView dgv;
        private dsBalanceDetailTransaction dsBalanceDetailTransaction1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBalanceDetailId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTransactionDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAmount;
        private System.Windows.Forms.DataGridViewButtonColumn colEdit;
        private System.Windows.Forms.DataGridViewButtonColumn colDelete;

        protected override void Dispose(bool disposing) { if (disposing && components != null) components.Dispose(); base.Dispose(disposing); }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.cmbBalanceDetail = new System.Windows.Forms.ComboBox();
            this.dtpTransactionDate = new System.Windows.Forms.DateTimePicker();
            this.txtDescription = new System.Windows.Forms.RichTextBox();
            this.txtAmount = new System.Windows.Forms.NumericUpDown();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBalanceDetailId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTransactionDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEdit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colDelete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dsBalanceDetailTransaction1 = new Ncsln.Master.dsBalanceDetailTransaction();
            this.lblBalanceDetail = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblAmount = new System.Windows.Forms.Label();
            this.lblSearch = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.txtAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsBalanceDetailTransaction1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbBalanceDetail
            // 
            this.cmbBalanceDetail.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cmbBalanceDetail.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbBalanceDetail.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbBalanceDetail.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBalanceDetail.Location = new System.Drawing.Point(303, 12);
            this.cmbBalanceDetail.Name = "cmbBalanceDetail";
            this.cmbBalanceDetail.Size = new System.Drawing.Size(362, 25);
            this.cmbBalanceDetail.TabIndex = 1;
            this.cmbBalanceDetail.SelectionChangeCommitted += new System.EventHandler(this.cmbBalanceDetail_SelectionChangeCommitted);
            // 
            // dtpTransactionDate
            // 
            this.dtpTransactionDate.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dtpTransactionDate.CustomFormat = "dd/MMM/yyyy";
            this.dtpTransactionDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTransactionDate.Location = new System.Drawing.Point(303, 51);
            this.dtpTransactionDate.Name = "dtpTransactionDate";
            this.dtpTransactionDate.Size = new System.Drawing.Size(145, 25);
            this.dtpTransactionDate.TabIndex = 3;
            // 
            // txtDescription
            // 
            this.txtDescription.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtDescription.Location = new System.Drawing.Point(303, 90);
            this.txtDescription.MaxLength = 500;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(362, 68);
            this.txtDescription.TabIndex = 7;
            this.txtDescription.Text = "";
            // 
            // txtAmount
            // 
            this.txtAmount.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtAmount.DecimalPlaces = 2;
            this.txtAmount.Location = new System.Drawing.Point(535, 51);
            this.txtAmount.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(130, 25);
            this.txtAmount.TabIndex = 5;
            this.txtAmount.ThousandsSeparator = true;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(121, 270);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(350, 25);
            this.txtSearch.TabIndex = 11;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnSave.Location = new System.Drawing.Point(357, 211);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(95, 34);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClear
            // 
            this.btnClear.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnClear.Location = new System.Drawing.Point(468, 211);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(95, 34);
            this.btnClear.TabIndex = 9;
            this.btnClear.Text = "Clear";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AutoGenerateColumns = false;
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colBalanceDetailId,
            this.colTransactionDate,
            this.colTitle,
            this.colDescription,
            this.colAmount,
            this.colEdit,
            this.colDelete});
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.Location = new System.Drawing.Point(0, 0);
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersVisible = false;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(950, 299);
            this.dgv.TabIndex = 12;
            this.dgv.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellContentClick);
            // 
            // colId
            // 
            this.colId.DataPropertyName = "Id";
            this.colId.HeaderText = "Id";
            this.colId.Name = "colId";
            this.colId.ReadOnly = true;
            this.colId.Visible = false;
            // 
            // colBalanceDetailId
            // 
            this.colBalanceDetailId.DataPropertyName = "BalanceDetailId";
            this.colBalanceDetailId.HeaderText = "BalanceDetailId";
            this.colBalanceDetailId.Name = "colBalanceDetailId";
            this.colBalanceDetailId.ReadOnly = true;
            this.colBalanceDetailId.Visible = false;
            // 
            // colTransactionDate
            // 
            this.colTransactionDate.DataPropertyName = "TransactionDate";
            this.colTransactionDate.DefaultCellStyle.Format = "dd/MMM/yyyy";
            this.colTransactionDate.FillWeight = 55F;
            this.colTransactionDate.HeaderText = "Date";
            this.colTransactionDate.Name = "colTransactionDate";
            this.colTransactionDate.ReadOnly = true;
            // 
            // colTitle
            // 
            this.colTitle.DataPropertyName = "Title";
            this.colTitle.HeaderText = "Balance Detail";
            this.colTitle.Name = "colTitle";
            this.colTitle.ReadOnly = true;
            // 
            // colDescription
            // 
            this.colDescription.DataPropertyName = "Description";
            this.colDescription.HeaderText = "Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.ReadOnly = true;
            // 
            // colAmount
            // 
            this.colAmount.DataPropertyName = "Amount";
            this.colAmount.DefaultCellStyle.Format = "N2";
            this.colAmount.FillWeight = 55F;
            this.colAmount.HeaderText = "Amount";
            this.colAmount.Name = "colAmount";
            this.colAmount.ReadOnly = true;
            // 
            // colEdit
            // 
            this.colEdit.FillWeight = 35F;
            this.colEdit.HeaderText = "Edit";
            this.colEdit.Name = "colEdit";
            this.colEdit.ReadOnly = true;
            this.colEdit.Text = "Edit";
            this.colEdit.UseColumnTextForButtonValue = true;
            // 
            // colDelete
            // 
            this.colDelete.FillWeight = 35F;
            this.colDelete.HeaderText = "Delete";
            this.colDelete.Name = "colDelete";
            this.colDelete.ReadOnly = true;
            this.colDelete.Text = "Delete";
            this.colDelete.UseColumnTextForButtonValue = true;
            // 
            // dsBalanceDetailTransaction1
            // 
            this.dsBalanceDetailTransaction1.DataSetName = "dsBalanceDetailTransaction";
            // 
            // lblBalanceDetail
            // 
            this.lblBalanceDetail.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblBalanceDetail.AutoSize = true;
            this.lblBalanceDetail.Location = new System.Drawing.Point(188, 16);
            this.lblBalanceDetail.Name = "lblBalanceDetail";
            this.lblBalanceDetail.Size = new System.Drawing.Size(95, 17);
            this.lblBalanceDetail.TabIndex = 0;
            this.lblBalanceDetail.Text = "Balance Detail";
            // 
            // lblDate
            // 
            this.lblDate.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(248, 55);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(35, 17);
            this.lblDate.TabIndex = 2;
            this.lblDate.Text = "Date";
            // 
            // lblDescription
            // 
            this.lblDescription.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(209, 93);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(74, 17);
            this.lblDescription.TabIndex = 6;
            this.lblDescription.Text = "Description";
            // 
            // lblAmount
            // 
            this.lblAmount.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblAmount.AutoSize = true;
            this.lblAmount.Location = new System.Drawing.Point(465, 55);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(53, 17);
            this.lblAmount.TabIndex = 4;
            this.lblAmount.Text = "Amount";
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(21, 274);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(47, 17);
            this.lblSearch.TabIndex = 10;
            this.lblSearch.Text = "Search";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblBalanceDetail);
            this.panel1.Controls.Add(this.txtSearch);
            this.panel1.Controls.Add(this.cmbBalanceDetail);
            this.panel1.Controls.Add(this.lblSearch);
            this.panel1.Controls.Add(this.btnClear);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.lblDate);
            this.panel1.Controls.Add(this.dtpTransactionDate);
            this.panel1.Controls.Add(this.lblDescription);
            this.panel1.Controls.Add(this.txtAmount);
            this.panel1.Controls.Add(this.txtDescription);
            this.panel1.Controls.Add(this.lblAmount);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(950, 301);
            this.panel1.TabIndex = 13;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgv);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 301);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(950, 299);
            this.panel2.TabIndex = 14;
            // 
            // frmBalanceDetailTransaction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(950, 600);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.MinimumSize = new System.Drawing.Size(850, 520);
            this.Name = "frmBalanceDetailTransaction";
            this.Text = "Balance Detail Transaction";
            this.Load += new System.EventHandler(this.frmBalanceDetailTransaction_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsBalanceDetailTransaction1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Label lblBalanceDetail;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
    }
}
