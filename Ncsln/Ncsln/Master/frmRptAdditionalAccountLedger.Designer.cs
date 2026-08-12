namespace Ncsln.Master
{
    partial class frmRptAdditionalAccountLedger
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ComboBox cmbAccount;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.DataGridView dgv;
        private dsAdditionalAccountLedger dsAdditionalAccountLedger1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSrNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTranDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSourceType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReferenceId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAccountName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBankTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAccountNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDetail;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReceiveAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPaymentAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBalance;

        protected override void Dispose(bool disposing) { if (disposing && components != null) components.Dispose(); base.Dispose(disposing); }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.cmbAccount = new System.Windows.Forms.ComboBox(); this.dtpFromDate = new System.Windows.Forms.DateTimePicker(); this.dtpToDate = new System.Windows.Forms.DateTimePicker(); this.btnShow = new System.Windows.Forms.Button(); this.dgv = new System.Windows.Forms.DataGridView(); this.dsAdditionalAccountLedger1 = new Ncsln.Master.dsAdditionalAccountLedger();
            this.colSrNo = new System.Windows.Forms.DataGridViewTextBoxColumn(); this.colTranDate = new System.Windows.Forms.DataGridViewTextBoxColumn(); this.colSourceType = new System.Windows.Forms.DataGridViewTextBoxColumn(); this.colReferenceId = new System.Windows.Forms.DataGridViewTextBoxColumn(); this.colAccountName = new System.Windows.Forms.DataGridViewTextBoxColumn(); this.colBankTitle = new System.Windows.Forms.DataGridViewTextBoxColumn(); this.colAccountNo = new System.Windows.Forms.DataGridViewTextBoxColumn(); this.colDetail = new System.Windows.Forms.DataGridViewTextBoxColumn(); this.colReceiveAmount = new System.Windows.Forms.DataGridViewTextBoxColumn(); this.colPaymentAmount = new System.Windows.Forms.DataGridViewTextBoxColumn(); this.colBalance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            System.Windows.Forms.Label lblAccount = new System.Windows.Forms.Label(); System.Windows.Forms.Label lblFrom = new System.Windows.Forms.Label(); System.Windows.Forms.Label lblTo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit(); ((System.ComponentModel.ISupportInitialize)(this.dsAdditionalAccountLedger1)).BeginInit(); this.SuspendLayout();
            lblAccount.AutoSize = true; lblAccount.Location = new System.Drawing.Point(25, 25); lblAccount.Text = "Additional Account"; this.cmbAccount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList; this.cmbAccount.Location = new System.Drawing.Point(160, 21); this.cmbAccount.Size = new System.Drawing.Size(300, 25);
            lblFrom.AutoSize = true; lblFrom.Location = new System.Drawing.Point(485, 25); lblFrom.Text = "From"; this.dtpFromDate.CustomFormat = "dd/MMM/yyyy"; this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom; this.dtpFromDate.Location = new System.Drawing.Point(530, 21); this.dtpFromDate.Size = new System.Drawing.Size(130, 25);
            lblTo.AutoSize = true; lblTo.Location = new System.Drawing.Point(680, 25); lblTo.Text = "To"; this.dtpToDate.CustomFormat = "dd/MMM/yyyy"; this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom; this.dtpToDate.Location = new System.Drawing.Point(710, 21); this.dtpToDate.Size = new System.Drawing.Size(130, 25);
            this.btnShow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right))); this.btnShow.Location = new System.Drawing.Point(875, 18); this.btnShow.Size = new System.Drawing.Size(90, 32); this.btnShow.Text = "Show"; this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            this.dgv.AllowUserToAddRows = false; this.dgv.AllowUserToDeleteRows = false; this.dgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right))); this.dgv.AutoGenerateColumns = false; this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill; this.dgv.Location = new System.Drawing.Point(25, 75); this.dgv.ReadOnly = true; this.dgv.RowHeadersVisible = false; this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect; this.dgv.Size = new System.Drawing.Size(960, 475); this.dgv.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgv_RowPostPaint);
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { this.colSrNo, this.colTranDate, this.colSourceType, this.colReferenceId, this.colAccountName, this.colBankTitle, this.colAccountNo, this.colDetail, this.colReceiveAmount, this.colPaymentAmount, this.colBalance });
            this.colSrNo.DataPropertyName = "SrNo"; this.colSrNo.HeaderText = "#"; this.colSrNo.Name = "colSrNo"; this.colSrNo.FillWeight = 25; this.colTranDate.DataPropertyName = "TranDate"; this.colTranDate.DefaultCellStyle.Format = "dd/MMM/yyyy"; this.colTranDate.HeaderText = "Date"; this.colTranDate.Name = "colTranDate"; this.colTranDate.FillWeight = 55; this.colSourceType.DataPropertyName = "SourceType"; this.colSourceType.HeaderText = "Type"; this.colSourceType.Name = "colSourceType"; this.colSourceType.FillWeight = 55; this.colReferenceId.DataPropertyName = "ReferenceId"; this.colReferenceId.Name = "colReferenceId"; this.colReferenceId.Visible = false;
            this.colAccountName.DataPropertyName = "AccountName"; this.colAccountName.HeaderText = "Account"; this.colAccountName.Name = "colAccountName"; this.colBankTitle.DataPropertyName = "BankTitle"; this.colBankTitle.HeaderText = "Bank"; this.colBankTitle.Name = "colBankTitle"; this.colAccountNo.DataPropertyName = "AccountNo"; this.colAccountNo.HeaderText = "Bank Account #"; this.colAccountNo.Name = "colAccountNo"; this.colDetail.DataPropertyName = "Detail"; this.colDetail.HeaderText = "Detail"; this.colDetail.Name = "colDetail";
            this.colReceiveAmount.DataPropertyName = "ReceiveAmount"; this.colReceiveAmount.DefaultCellStyle.Format = "N2"; this.colReceiveAmount.HeaderText = "Receive"; this.colReceiveAmount.Name = "colReceiveAmount"; this.colReceiveAmount.FillWeight = 55; this.colPaymentAmount.DataPropertyName = "PaymentAmount"; this.colPaymentAmount.DefaultCellStyle.Format = "N2"; this.colPaymentAmount.HeaderText = "Payment"; this.colPaymentAmount.Name = "colPaymentAmount"; this.colPaymentAmount.FillWeight = 55; this.colBalance.DataPropertyName = "Balance"; this.colBalance.DefaultCellStyle.Format = "N2"; this.colBalance.HeaderText = "Balance"; this.colBalance.Name = "colBalance"; this.colBalance.FillWeight = 55;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F); this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font; this.ClientSize = new System.Drawing.Size(1010, 575); this.Controls.AddRange(new System.Windows.Forms.Control[] { lblAccount, this.cmbAccount, lblFrom, this.dtpFromDate, lblTo, this.dtpToDate, this.btnShow, this.dgv }); this.Font = new System.Drawing.Font("Segoe UI", 9.75F); this.MinimumSize = new System.Drawing.Size(900, 500); this.Name = "frmRptAdditionalAccountLedger"; this.Text = "Additional Account Ledger"; this.Load += new System.EventHandler(this.frmRptAdditionalAccountLedger_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit(); ((System.ComponentModel.ISupportInitialize)(this.dsAdditionalAccountLedger1)).EndInit(); this.ResumeLayout(false); this.PerformLayout();
        }
    }
}
