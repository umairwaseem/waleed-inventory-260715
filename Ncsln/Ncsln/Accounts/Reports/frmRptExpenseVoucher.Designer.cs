namespace Ncsln.Accounts.Reports
{
    partial class frmRptExpenseVoucher
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
            this.crv = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.daExpenseVoucher = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
            this.sqlSelectCommand = new System.Data.SqlClient.SqlCommand();
            this.dsExpenseVoucher1 = new Ncsln.Accounts.Reports.dsExpenseVoucher();
            ((System.ComponentModel.ISupportInitialize)(this.dsExpenseVoucher1)).BeginInit();
            this.SuspendLayout();
            // 
            // crv
            // 
            this.crv.ActiveViewIndex = -1;
            this.crv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crv.Cursor = System.Windows.Forms.Cursors.Default;
            this.crv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crv.Location = new System.Drawing.Point(0, 0);
            this.crv.Name = "crv";
            this.crv.Size = new System.Drawing.Size(687, 581);
            this.crv.TabIndex = 0;
            this.crv.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // daExpenseVoucher
            // 
            this.daExpenseVoucher.SelectCommand = this.sqlSelectCommand;
            this.daExpenseVoucher.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "vExpense", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("Id", "Id"),
                        new System.Data.Common.DataColumnMapping("Expense_Id", "Expense_Id"),
                        new System.Data.Common.DataColumnMapping("Expense", "Expense"),
                        new System.Data.Common.DataColumnMapping("Date", "Date"),
                        new System.Data.Common.DataColumnMapping("Description", "Description"),
                        new System.Data.Common.DataColumnMapping("Amount", "Amount")})});
            // 
            // sqlConnection1
            // 
            this.sqlConnection1.ConnectionString = "Data Source=(Local)\\sqlexpress2014;Initial Catalog=Inventory;Integrated Security=" +
    "True;MultipleActiveResultSets=True;Application Name=EntityFramework";
            this.sqlConnection1.FireInfoMessageEventOnUserErrors = false;
            // 
            // sqlSelectCommand
            // 
            this.sqlSelectCommand.CommandText = "SELECT Id, Expense_Id, Expense, Date, Description, Amount\r\nFROM     vExpense\r\nWHE" +
    "RE  (Id = @Id)";
            this.sqlSelectCommand.Connection = this.sqlConnection1;
            this.sqlSelectCommand.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@Id", System.Data.SqlDbType.Int, 4, "Id")});
            // 
            // dsExpenseVoucher1
            // 
            this.dsExpenseVoucher1.DataSetName = "dsExpenseVoucher";
            this.dsExpenseVoucher1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // frmRptExpenseVoucher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(687, 581);
            this.Controls.Add(this.crv);
            this.Name = "frmRptExpenseVoucher";
            this.Text = "Expense Voucher";
            this.Load += new System.EventHandler(this.frmRptExpenseVoucher_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dsExpenseVoucher1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crv;
        private System.Data.SqlClient.SqlDataAdapter daExpenseVoucher;
        private System.Data.SqlClient.SqlCommand sqlSelectCommand;
        private System.Data.SqlClient.SqlConnection sqlConnection1;
        private dsExpenseVoucher dsExpenseVoucher1;
    }
}