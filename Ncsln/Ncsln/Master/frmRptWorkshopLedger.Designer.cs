namespace Ncsln.Master
{
    partial class frmRptWorkshopLedger
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.DataGridView dgv;
        private dsWorkshopLedger dsWorkshopLedger1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSrNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTranDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRowType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReferenceId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAccountName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDetail;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAmount;

        protected override void Dispose(bool disposing) { if (disposing && components != null) components.Dispose(); base.Dispose(disposing); }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.btnShow = new System.Windows.Forms.Button();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.colSrNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTranDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRowType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colReferenceId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAccountName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDetail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsWorkshopLedger1 = new Ncsln.Master.dsWorkshopLedger();
            this.lblFrom = new System.Windows.Forms.Label();
            this.lblTo = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsWorkshopLedger1)).BeginInit();
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
            this.dtpFromDate.Size = new System.Drawing.Size(145, 25);
            this.dtpFromDate.TabIndex = 1;
            // 
            // dtpToDate
            // 
            this.dtpToDate.CustomFormat = "dd/MMM/yyyy";
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpToDate.Location = new System.Drawing.Point(288, 25);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(145, 25);
            this.dtpToDate.TabIndex = 3;
            // 
            // btnShow
            // 
            this.btnShow.Location = new System.Drawing.Point(458, 21);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(90, 32);
            this.btnShow.TabIndex = 4;
            this.btnShow.Text = "Show";
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AutoGenerateColumns = false;
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSrNo,
            this.colTranDate,
            this.colRowType,
            this.colReferenceId,
            this.colAccountName,
            this.colDetail,
            this.colAmount});
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.Location = new System.Drawing.Point(0, 0);
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersVisible = false;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(1010, 500);
            this.dgv.TabIndex = 5;
            this.dgv.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgv_RowPostPaint);
            // 
            // colSrNo
            // 
            this.colSrNo.DataPropertyName = "SrNo";
            this.colSrNo.FillWeight = 25F;
            this.colSrNo.HeaderText = "#";
            this.colSrNo.Name = "colSrNo";
            this.colSrNo.ReadOnly = true;
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
            // colRowType
            // 
            this.colRowType.DataPropertyName = "RowType";
            this.colRowType.Name = "colRowType";
            this.colRowType.ReadOnly = true;
            this.colRowType.Visible = false;
            // 
            // colReferenceId
            // 
            this.colReferenceId.DataPropertyName = "ReferenceId";
            this.colReferenceId.Name = "colReferenceId";
            this.colReferenceId.ReadOnly = true;
            this.colReferenceId.Visible = false;
            // 
            // colAccountName
            // 
            this.colAccountName.DataPropertyName = "AccountName";
            this.colAccountName.HeaderText = "Workshop Account";
            this.colAccountName.Name = "colAccountName";
            this.colAccountName.ReadOnly = true;
            // 
            // colDetail
            // 
            this.colDetail.DataPropertyName = "Detail";
            this.colDetail.HeaderText = "Description";
            this.colDetail.Name = "colDetail";
            this.colDetail.ReadOnly = true;
            // 
            // colAmount
            // 
            this.colAmount.DataPropertyName = "Amount";
            this.colAmount.DefaultCellStyle.Format = "N2";
            this.colAmount.FillWeight = 55F;
            this.colAmount.HeaderText = "Paid";
            this.colAmount.Name = "colAmount";
            this.colAmount.ReadOnly = true;
            // 
            // dsWorkshopLedger1
            // 
            this.dsWorkshopLedger1.DataSetName = "dsWorkshopLedger";
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
            this.lblTo.Location = new System.Drawing.Point(253, 29);
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
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1010, 75);
            this.panel1.TabIndex = 6;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgv);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 75);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1010, 500);
            this.panel2.TabIndex = 7;
            // 
            // frmRptWorkshopLedger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1010, 575);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.MinimumSize = new System.Drawing.Size(900, 500);
            this.Name = "frmRptWorkshopLedger";
            this.Text = "Workshop Ledger";
            this.Load += new System.EventHandler(this.frmRptWorkshopLedger_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsWorkshopLedger1)).EndInit();
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
