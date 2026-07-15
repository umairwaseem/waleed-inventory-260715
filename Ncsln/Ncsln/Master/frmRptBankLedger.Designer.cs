
namespace Ncsln.Master
{
    partial class frmRptBankLedger
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbBank = new System.Windows.Forms.ComboBox();
            this.dtpDateMonth = new System.Windows.Forms.DateTimePicker();
            this.btnShow = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.daBankLedger = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
            this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
            this.dsBankLedger1 = new Ncsln.Master.dsBankLedger();
            this.dsBankLedger = new Ncsln.Master.dsBankLedger();
            this.spReportBankLedgerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.srNoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tranDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sourceTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.branchNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.databaseNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.referenceIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.detailDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.accountNoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.receiveAmountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.paymentAmountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.balanceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsBankLedger1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsBankLedger)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spReportBankLedgerBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnShow);
            this.panel1.Controls.Add(this.dtpDateMonth);
            this.panel1.Controls.Add(this.cmbBank);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 100);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 100);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(800, 350);
            this.panel2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(51, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select Bank";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(252, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Select Month";
            // 
            // cmbBank
            // 
            this.cmbBank.FormattingEnabled = true;
            this.cmbBank.Location = new System.Drawing.Point(54, 46);
            this.cmbBank.Name = "cmbBank";
            this.cmbBank.Size = new System.Drawing.Size(192, 21);
            this.cmbBank.TabIndex = 2;
            // 
            // dtpDateMonth
            // 
            this.dtpDateMonth.CustomFormat = "MMM/yyyy";
            this.dtpDateMonth.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateMonth.Location = new System.Drawing.Point(255, 46);
            this.dtpDateMonth.Name = "dtpDateMonth";
            this.dtpDateMonth.Size = new System.Drawing.Size(200, 20);
            this.dtpDateMonth.TabIndex = 3;
            // 
            // btnShow
            // 
            this.btnShow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnShow.Location = new System.Drawing.Point(713, 47);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(75, 23);
            this.btnShow.TabIndex = 4;
            this.btnShow.Text = "Show";
            this.btnShow.UseVisualStyleBackColor = true;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.srNoDataGridViewTextBoxColumn,
            this.tranDateDataGridViewTextBoxColumn,
            this.sourceTypeDataGridViewTextBoxColumn,
            this.branchNameDataGridViewTextBoxColumn,
            this.databaseNameDataGridViewTextBoxColumn,
            this.referenceIdDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.detailDataGridViewTextBoxColumn,
            this.accountNoDataGridViewTextBoxColumn,
            this.receiveAmountDataGridViewTextBoxColumn,
            this.paymentAmountDataGridViewTextBoxColumn,
            this.balanceDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.spReportBankLedgerBindingSource;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(800, 350);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.Paint += new System.Windows.Forms.PaintEventHandler(this.dataGridView1_Paint);
            // 
            // daBankLedger
            // 
            this.daBankLedger.SelectCommand = this.sqlSelectCommand1;
            this.daBankLedger.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "spReportBankLedger", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("SrNo", "SrNo"),
                        new System.Data.Common.DataColumnMapping("TranDate", "TranDate"),
                        new System.Data.Common.DataColumnMapping("SourceType", "SourceType"),
                        new System.Data.Common.DataColumnMapping("BranchName", "BranchName"),
                        new System.Data.Common.DataColumnMapping("DatabaseName", "DatabaseName"),
                        new System.Data.Common.DataColumnMapping("ReferenceId", "ReferenceId"),
                        new System.Data.Common.DataColumnMapping("Name", "Name"),
                        new System.Data.Common.DataColumnMapping("Detail", "Detail"),
                        new System.Data.Common.DataColumnMapping("AccountNo", "AccountNo"),
                        new System.Data.Common.DataColumnMapping("ReceiveAmount", "ReceiveAmount"),
                        new System.Data.Common.DataColumnMapping("PaymentAmount", "PaymentAmount"),
                        new System.Data.Common.DataColumnMapping("Balance", "Balance")})});
            // 
            // sqlSelectCommand1
            // 
            this.sqlSelectCommand1.CommandText = "dbo.spReportBankLedgerMonth";
            this.sqlSelectCommand1.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlSelectCommand1.Connection = this.sqlConnection1;
            this.sqlSelectCommand1.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@AccountNo", System.Data.SqlDbType.NVarChar, 50),
            new System.Data.SqlClient.SqlParameter("@MonthDate", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@ShowDebug", System.Data.SqlDbType.Bit, 1)});
            // 
            // sqlConnection1
            // 
            this.sqlConnection1.ConnectionString = "Data Source=202.165.249.169;Initial Catalog=waleedinventoryServer;Persist Securit" +
    "y Info=True;User ID=cruxtech;Password=crux123";
            this.sqlConnection1.FireInfoMessageEventOnUserErrors = false;
            // 
            // dsBankLedger1
            // 
            this.dsBankLedger1.DataSetName = "dsBankLedger";
            this.dsBankLedger1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dsBankLedger
            // 
            this.dsBankLedger.DataSetName = "dsBankLedger";
            this.dsBankLedger.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // spReportBankLedgerBindingSource
            // 
            this.spReportBankLedgerBindingSource.DataMember = "spReportBankLedger";
            this.spReportBankLedgerBindingSource.DataSource = this.dsBankLedger;
            // 
            // srNoDataGridViewTextBoxColumn
            // 
            this.srNoDataGridViewTextBoxColumn.DataPropertyName = "SrNo";
            this.srNoDataGridViewTextBoxColumn.HeaderText = "SrNo";
            this.srNoDataGridViewTextBoxColumn.Name = "srNoDataGridViewTextBoxColumn";
            this.srNoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tranDateDataGridViewTextBoxColumn
            // 
            this.tranDateDataGridViewTextBoxColumn.DataPropertyName = "TranDate";
            dataGridViewCellStyle2.Format = "dd/MMM/yyyy";
            this.tranDateDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.tranDateDataGridViewTextBoxColumn.HeaderText = "Date";
            this.tranDateDataGridViewTextBoxColumn.Name = "tranDateDataGridViewTextBoxColumn";
            this.tranDateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // sourceTypeDataGridViewTextBoxColumn
            // 
            this.sourceTypeDataGridViewTextBoxColumn.DataPropertyName = "SourceType";
            this.sourceTypeDataGridViewTextBoxColumn.HeaderText = "SourceType";
            this.sourceTypeDataGridViewTextBoxColumn.Name = "sourceTypeDataGridViewTextBoxColumn";
            this.sourceTypeDataGridViewTextBoxColumn.ReadOnly = true;
            this.sourceTypeDataGridViewTextBoxColumn.Visible = false;
            // 
            // branchNameDataGridViewTextBoxColumn
            // 
            this.branchNameDataGridViewTextBoxColumn.DataPropertyName = "BranchName";
            this.branchNameDataGridViewTextBoxColumn.HeaderText = "Branch";
            this.branchNameDataGridViewTextBoxColumn.Name = "branchNameDataGridViewTextBoxColumn";
            this.branchNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // databaseNameDataGridViewTextBoxColumn
            // 
            this.databaseNameDataGridViewTextBoxColumn.DataPropertyName = "DatabaseName";
            this.databaseNameDataGridViewTextBoxColumn.HeaderText = "DatabaseName";
            this.databaseNameDataGridViewTextBoxColumn.Name = "databaseNameDataGridViewTextBoxColumn";
            this.databaseNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.databaseNameDataGridViewTextBoxColumn.Visible = false;
            // 
            // referenceIdDataGridViewTextBoxColumn
            // 
            this.referenceIdDataGridViewTextBoxColumn.DataPropertyName = "ReferenceId";
            this.referenceIdDataGridViewTextBoxColumn.HeaderText = "ReferenceId";
            this.referenceIdDataGridViewTextBoxColumn.Name = "referenceIdDataGridViewTextBoxColumn";
            this.referenceIdDataGridViewTextBoxColumn.ReadOnly = true;
            this.referenceIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            this.nameDataGridViewTextBoxColumn.Visible = false;
            // 
            // detailDataGridViewTextBoxColumn
            // 
            this.detailDataGridViewTextBoxColumn.DataPropertyName = "Detail";
            this.detailDataGridViewTextBoxColumn.HeaderText = "Detail";
            this.detailDataGridViewTextBoxColumn.Name = "detailDataGridViewTextBoxColumn";
            this.detailDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // accountNoDataGridViewTextBoxColumn
            // 
            this.accountNoDataGridViewTextBoxColumn.DataPropertyName = "AccountNo";
            this.accountNoDataGridViewTextBoxColumn.HeaderText = "Account #";
            this.accountNoDataGridViewTextBoxColumn.Name = "accountNoDataGridViewTextBoxColumn";
            this.accountNoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // receiveAmountDataGridViewTextBoxColumn
            // 
            this.receiveAmountDataGridViewTextBoxColumn.DataPropertyName = "ReceiveAmount";
            this.receiveAmountDataGridViewTextBoxColumn.HeaderText = "Receive";
            this.receiveAmountDataGridViewTextBoxColumn.Name = "receiveAmountDataGridViewTextBoxColumn";
            this.receiveAmountDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // paymentAmountDataGridViewTextBoxColumn
            // 
            this.paymentAmountDataGridViewTextBoxColumn.DataPropertyName = "PaymentAmount";
            this.paymentAmountDataGridViewTextBoxColumn.HeaderText = "Payment";
            this.paymentAmountDataGridViewTextBoxColumn.Name = "paymentAmountDataGridViewTextBoxColumn";
            this.paymentAmountDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // balanceDataGridViewTextBoxColumn
            // 
            this.balanceDataGridViewTextBoxColumn.DataPropertyName = "Balance";
            this.balanceDataGridViewTextBoxColumn.HeaderText = "Balance";
            this.balanceDataGridViewTextBoxColumn.Name = "balanceDataGridViewTextBoxColumn";
            this.balanceDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // frmRptBankLedger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "frmRptBankLedger";
            this.Text = "Bank Ledger";
            this.Load += new System.EventHandler(this.frmRptBankLedger_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsBankLedger1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsBankLedger)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spReportBankLedgerBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DateTimePicker dtpDateMonth;
        private System.Windows.Forms.ComboBox cmbBank;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Data.SqlClient.SqlDataAdapter daBankLedger;
        private System.Data.SqlClient.SqlCommand sqlSelectCommand1;
        private System.Data.SqlClient.SqlConnection sqlConnection1;
        private dsBankLedger dsBankLedger1;
        private System.Windows.Forms.BindingSource spReportBankLedgerBindingSource;
        private dsBankLedger dsBankLedger;
        private System.Windows.Forms.DataGridViewTextBoxColumn srNoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tranDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sourceTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn branchNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn databaseNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn referenceIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn detailDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn accountNoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn receiveAmountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn paymentAmountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn balanceDataGridViewTextBoxColumn;
    }
}