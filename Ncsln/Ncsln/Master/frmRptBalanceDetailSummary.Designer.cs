namespace Ncsln.Master
{
    partial class frmRptBalanceDetailSummary
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.Button btnShowAll;
        private System.Windows.Forms.Label lblFilter;
        private System.Windows.Forms.DataGridView dgv;
        private dsBalanceDetailSummary dsBalanceDetailSummary1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRowType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDisplayOrder;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTranDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBalance;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBalanceDetailId;
        private System.Windows.Forms.DataGridViewButtonColumn colAction;

        protected override void Dispose(bool disposing) { if (disposing && components != null) components.Dispose(); base.Dispose(disposing); }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.btnShow = new System.Windows.Forms.Button();
            this.btnShowAll = new System.Windows.Forms.Button();
            this.lblFilter = new System.Windows.Forms.Label();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.colRowType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDisplayOrder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTranDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBalance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBalanceDetailId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAction = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dsBalanceDetailSummary1 = new Ncsln.Master.dsBalanceDetailSummary();
            this.lblFrom = new System.Windows.Forms.Label();
            this.lblTo = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsBalanceDetailSummary1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.CustomFormat = "dd/MMM/yyyy";
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFromDate.Location = new System.Drawing.Point(78, 25);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(130, 25);
            this.dtpFromDate.TabIndex = 1;
            // 
            // dtpToDate
            // 
            this.dtpToDate.CustomFormat = "dd/MMM/yyyy";
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpToDate.Location = new System.Drawing.Point(263, 25);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(130, 25);
            this.dtpToDate.TabIndex = 3;
            // 
            // btnShow
            // 
            this.btnShow.Location = new System.Drawing.Point(418, 21);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(90, 32);
            this.btnShow.TabIndex = 4;
            this.btnShow.Text = "Show";
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // btnShowAll
            // 
            this.btnShowAll.Location = new System.Drawing.Point(518, 21);
            this.btnShowAll.Name = "btnShowAll";
            this.btnShowAll.Size = new System.Drawing.Size(95, 32);
            this.btnShowAll.TabIndex = 5;
            this.btnShowAll.Text = "Show All";
            this.btnShowAll.Click += new System.EventHandler(this.btnShowAll_Click);
            // 
            // lblFilter
            // 
            this.lblFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFilter.Location = new System.Drawing.Point(665, 27);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(320, 20);
            this.lblFilter.TabIndex = 6;
            this.lblFilter.Text = "Showing all rows";
            this.lblFilter.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AutoGenerateColumns = false;
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colRowType,
            this.colDisplayOrder,
            this.colTranDate,
            this.colTitle,
            this.colDescription,
            this.colAmount,
            this.colBalance,
            this.colBalanceDetailId,
            this.colAction});
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.Location = new System.Drawing.Point(0, 0);
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersVisible = false;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(1010, 500);
            this.dgv.TabIndex = 7;
            this.dgv.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellContentClick);
            this.dgv.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgv_RowPostPaint);
            // 
            // colRowType
            // 
            this.colRowType.DataPropertyName = "RowType";
            this.colRowType.FillWeight = 55F;
            this.colRowType.HeaderText = "Type";
            this.colRowType.Name = "colRowType";
            this.colRowType.ReadOnly = true;
            // 
            // colDisplayOrder
            // 
            this.colDisplayOrder.DataPropertyName = "DisplayOrder";
            this.colDisplayOrder.Name = "colDisplayOrder";
            this.colDisplayOrder.ReadOnly = true;
            this.colDisplayOrder.Visible = false;
            // 
            // colTranDate
            // 
            this.colTranDate.DataPropertyName = "TranDate";
            this.colTranDate.DefaultCellStyle.Format = "dd/MMM/yyyy";
            this.colTranDate.FillWeight = 55F;
            this.colTranDate.HeaderText = "Date";
            this.colTranDate.Name = "colTranDate";
            this.colTranDate.ReadOnly = true;
            // 
            // colTitle
            // 
            this.colTitle.DataPropertyName = "Title";
            this.colTitle.HeaderText = "Title";
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
            // colBalance
            // 
            this.colBalance.DataPropertyName = "Balance";
            this.colBalance.DefaultCellStyle.Format = "N2";
            this.colBalance.FillWeight = 55F;
            this.colBalance.HeaderText = "Balance";
            this.colBalance.Name = "colBalance";
            this.colBalance.ReadOnly = true;
            // 
            // colBalanceDetailId
            // 
            this.colBalanceDetailId.DataPropertyName = "BalanceDetailId";
            this.colBalanceDetailId.Name = "colBalanceDetailId";
            this.colBalanceDetailId.ReadOnly = true;
            this.colBalanceDetailId.Visible = false;
            // 
            // colAction
            // 
            this.colAction.DataPropertyName = "ActionText";
            this.colAction.FillWeight = 40F;
            this.colAction.HeaderText = "Option";
            this.colAction.Name = "colAction";
            this.colAction.ReadOnly = true;
            this.colAction.Text = "Filter";
            // 
            // dsBalanceDetailSummary1
            // 
            this.dsBalanceDetailSummary1.DataSetName = "dsBalanceDetailSummary";
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Location = new System.Drawing.Point(25, 29);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(39, 17);
            this.lblFrom.TabIndex = 0;
            this.lblFrom.Text = "From";
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Location = new System.Drawing.Point(228, 29);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(21, 17);
            this.lblTo.TabIndex = 2;
            this.lblTo.Text = "To";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblFrom);
            this.panel1.Controls.Add(this.dtpFromDate);
            this.panel1.Controls.Add(this.lblTo);
            this.panel1.Controls.Add(this.dtpToDate);
            this.panel1.Controls.Add(this.btnShow);
            this.panel1.Controls.Add(this.btnShowAll);
            this.panel1.Controls.Add(this.lblFilter);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1010, 75);
            this.panel1.TabIndex = 8;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgv);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 75);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1010, 500);
            this.panel2.TabIndex = 9;
            // 
            // frmRptBalanceDetailSummary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1010, 575);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.MinimumSize = new System.Drawing.Size(900, 500);
            this.Name = "frmRptBalanceDetailSummary";
            this.Text = "Balance Detail Summary";
            this.Load += new System.EventHandler(this.frmRptBalanceDetailSummary_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsBalanceDetailSummary1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
    }
}
