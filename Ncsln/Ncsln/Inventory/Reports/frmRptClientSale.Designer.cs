namespace Ncsln.Inventory.Reports
{
    partial class frmRptClientSale
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRptClientSale));
            this.crv = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
            this.dsClientSale1 = new Ncsln.Inventory.Reports.dsClientSale();
            this.daClientSale = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
            ((System.ComponentModel.ISupportInitialize)(this.dsClientSale1)).BeginInit();
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
            this.crv.Size = new System.Drawing.Size(643, 641);
            this.crv.TabIndex = 0;
            this.crv.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // sqlConnection1
            // 
            this.sqlConnection1.ConnectionString = "Data Source=(Local)\\sqlexpress2014;Initial Catalog=Inventory;Integrated Security=" +
    "True;MultipleActiveResultSets=True;Application Name=EntityFramework";
            this.sqlConnection1.FireInfoMessageEventOnUserErrors = false;
            // 
            // dsClientSale1
            // 
            this.dsClientSale1.DataSetName = "dsClientSale";
            this.dsClientSale1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // daClientSale
            // 
            this.daClientSale.SelectCommand = this.sqlSelectCommand1;
            this.daClientSale.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "vClientSale", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ClientId", "ClientId"),
                        new System.Data.Common.DataColumnMapping("Name", "Name"),
                        new System.Data.Common.DataColumnMapping("PhoneNo", "PhoneNo"),
                        new System.Data.Common.DataColumnMapping("Email", "Email"),
                        new System.Data.Common.DataColumnMapping("Address", "Address"),
                        new System.Data.Common.DataColumnMapping("DefaultEntry", "DefaultEntry"),
                        new System.Data.Common.DataColumnMapping("Id", "Id"),
                        new System.Data.Common.DataColumnMapping("OrderNo", "OrderNo"),
                        new System.Data.Common.DataColumnMapping("OrderDate", "OrderDate"),
                        new System.Data.Common.DataColumnMapping("Description", "Description"),
                        new System.Data.Common.DataColumnMapping("ExtraDetail", "ExtraDetail"),
                        new System.Data.Common.DataColumnMapping("ExtraAmount", "ExtraAmount"),
                        new System.Data.Common.DataColumnMapping("FinalTotal", "FinalTotal"),
                        new System.Data.Common.DataColumnMapping("Delivered", "Delivered"),
                        new System.Data.Common.DataColumnMapping("DeliveredDate", "DeliveredDate"),
                        new System.Data.Common.DataColumnMapping("Sale_Id", "Sale_Id"),
                        new System.Data.Common.DataColumnMapping("Amount", "Amount"),
                        new System.Data.Common.DataColumnMapping("OType", "OType"),
                        new System.Data.Common.DataColumnMapping("PaymentDate", "PaymentDate"),
                        new System.Data.Common.DataColumnMapping("PaymentDetail", "PaymentDetail")})});
            // 
            // sqlSelectCommand1
            // 
            this.sqlSelectCommand1.CommandText = resources.GetString("sqlSelectCommand1.CommandText");
            this.sqlSelectCommand1.Connection = this.sqlConnection1;
            this.sqlSelectCommand1.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@ClientId", System.Data.SqlDbType.Int, 4, "ClientId")});
            // 
            // frmRptClientSale
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(643, 641);
            this.Controls.Add(this.crv);
            this.Name = "frmRptClientSale";
            this.Text = "Client Sale Report";
            this.Load += new System.EventHandler(this.frmRptClientSale_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dsClientSale1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crv;
        private System.Data.SqlClient.SqlConnection sqlConnection1;
        private dsClientSale dsClientSale1;
        private System.Data.SqlClient.SqlDataAdapter daClientSale;
        private System.Data.SqlClient.SqlCommand sqlSelectCommand1;
    }
}