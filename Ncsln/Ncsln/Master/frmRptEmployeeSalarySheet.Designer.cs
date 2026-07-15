namespace Ncsln.Master
{
    partial class frmRptEmployeeSalarySheet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRptEmployeeSalarySheet));
            this.crv = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.daEmployeeSalarySheet = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
            this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
            this.dsEmployeeSalarySheet1 = new Ncsln.Master.dsEmployeeSalarySheet();
            this.daEmployeeSalarySheetAll = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlCommand1 = new System.Data.SqlClient.SqlCommand();
            ((System.ComponentModel.ISupportInitialize)(this.dsEmployeeSalarySheet1)).BeginInit();
            this.SuspendLayout();
            // 
            // crv
            // 
            this.crv.ActiveViewIndex = -1;
            this.crv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crv.Cursor = System.Windows.Forms.Cursors.Default;
            this.crv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crv.Location = new System.Drawing.Point(0, 0);
            this.crv.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.crv.Name = "crv";
            this.crv.Size = new System.Drawing.Size(734, 485);
            this.crv.TabIndex = 0;
            this.crv.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // daEmployeeSalarySheet
            // 
            this.daEmployeeSalarySheet.SelectCommand = this.sqlSelectCommand1;
            this.daEmployeeSalarySheet.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "vEmployeeSalary", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("Id", "Id"),
                        new System.Data.Common.DataColumnMapping("SalaryMonth", "SalaryMonth"),
                        new System.Data.Common.DataColumnMapping("MajorAmount", "MajorAmount"),
                        new System.Data.Common.DataColumnMapping("Expense", "Expense"),
                        new System.Data.Common.DataColumnMapping("Remaining", "Remaining"),
                        new System.Data.Common.DataColumnMapping("GroupType", "GroupType"),
                        new System.Data.Common.DataColumnMapping("GroupName", "GroupName"),
                        new System.Data.Common.DataColumnMapping("Description", "Description"),
                        new System.Data.Common.DataColumnMapping("TotalPay", "TotalPay"),
                        new System.Data.Common.DataColumnMapping("Employee_Id", "Employee_Id"),
                        new System.Data.Common.DataColumnMapping("Name", "Name"),
                        new System.Data.Common.DataColumnMapping("PhoneNo", "PhoneNo"),
                        new System.Data.Common.DataColumnMapping("Photo", "Photo"),
                        new System.Data.Common.DataColumnMapping("Salary", "Salary"),
                        new System.Data.Common.DataColumnMapping("Percentage", "Percentage"),
                        new System.Data.Common.DataColumnMapping("PercentAmount", "PercentAmount"),
                        new System.Data.Common.DataColumnMapping("GrowsAmount", "GrowsAmount"),
                        new System.Data.Common.DataColumnMapping("AbsentDays", "AbsentDays"),
                        new System.Data.Common.DataColumnMapping("AbsentAmount", "AbsentAmount"),
                        new System.Data.Common.DataColumnMapping("FinalAmount", "FinalAmount"),
                        new System.Data.Common.DataColumnMapping("Bonus", "Bonus")})});
            // 
            // sqlSelectCommand1
            // 
            this.sqlSelectCommand1.CommandText = resources.GetString("sqlSelectCommand1.CommandText");
            this.sqlSelectCommand1.Connection = this.sqlConnection1;
            this.sqlSelectCommand1.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@Id", System.Data.SqlDbType.Int, 4, "Id"),
            new System.Data.SqlClient.SqlParameter("@Branch_Id", System.Data.SqlDbType.Int, 4, "Branch_Id")});
            // 
            // sqlConnection1
            // 
            this.sqlConnection1.ConnectionString = "Data Source=(local);Initial Catalog=InventoryServer;Persist Security Info=Tr" +
    "ue;Integrated Security=True";
            this.sqlConnection1.FireInfoMessageEventOnUserErrors = false;
            // 
            // dsEmployeeSalarySheet1
            // 
            this.dsEmployeeSalarySheet1.DataSetName = "dsEmployeeSalarySheet";
            this.dsEmployeeSalarySheet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // daEmployeeSalarySheetAll
            // 
            this.daEmployeeSalarySheetAll.SelectCommand = this.sqlCommand1;
            this.daEmployeeSalarySheetAll.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "vEmployeeSalary", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("Id", "Id"),
                        new System.Data.Common.DataColumnMapping("SalaryMonth", "SalaryMonth"),
                        new System.Data.Common.DataColumnMapping("MajorAmount", "MajorAmount"),
                        new System.Data.Common.DataColumnMapping("Expense", "Expense"),
                        new System.Data.Common.DataColumnMapping("Remaining", "Remaining"),
                        new System.Data.Common.DataColumnMapping("GroupType", "GroupType"),
                        new System.Data.Common.DataColumnMapping("GroupName", "GroupName"),
                        new System.Data.Common.DataColumnMapping("Description", "Description"),
                        new System.Data.Common.DataColumnMapping("TotalPay", "TotalPay"),
                        new System.Data.Common.DataColumnMapping("Employee_Id", "Employee_Id"),
                        new System.Data.Common.DataColumnMapping("Name", "Name"),
                        new System.Data.Common.DataColumnMapping("PhoneNo", "PhoneNo"),
                        new System.Data.Common.DataColumnMapping("Photo", "Photo"),
                        new System.Data.Common.DataColumnMapping("Salary", "Salary"),
                        new System.Data.Common.DataColumnMapping("Percentage", "Percentage"),
                        new System.Data.Common.DataColumnMapping("PercentAmount", "PercentAmount"),
                        new System.Data.Common.DataColumnMapping("GrowsAmount", "GrowsAmount"),
                        new System.Data.Common.DataColumnMapping("AbsentDays", "AbsentDays"),
                        new System.Data.Common.DataColumnMapping("AbsentAmount", "AbsentAmount"),
                        new System.Data.Common.DataColumnMapping("FinalAmount", "FinalAmount"),
                        new System.Data.Common.DataColumnMapping("Bonus", "Bonus")})});
            // 
            // sqlCommand1
            // 
            this.sqlCommand1.CommandText = resources.GetString("sqlCommand1.CommandText");
            this.sqlCommand1.Connection = this.sqlConnection1;
            this.sqlCommand1.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@Id", System.Data.SqlDbType.Int, 4, "Id")});
            // 
            // frmRptEmployeeSalarySheet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 485);
            this.Controls.Add(this.crv);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "frmRptEmployeeSalarySheet";
            this.Text = "Salary Sheet";
            this.Load += new System.EventHandler(this.frmRptEmployeeSalarySheet_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dsEmployeeSalarySheet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crv;
        private System.Data.SqlClient.SqlDataAdapter daEmployeeSalarySheet;
        private System.Data.SqlClient.SqlCommand sqlSelectCommand1;
        private System.Data.SqlClient.SqlConnection sqlConnection1;
        private dsEmployeeSalarySheet dsEmployeeSalarySheet1;
        private System.Data.SqlClient.SqlDataAdapter daEmployeeSalarySheetAll;
        private System.Data.SqlClient.SqlCommand sqlCommand1;
    }
}