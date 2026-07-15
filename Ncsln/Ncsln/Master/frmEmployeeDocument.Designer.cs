namespace Ncsln.Master
{
    partial class frmEmployeeDocument
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEmployeeDocument));
            this.sqlCommand4 = new System.Data.SqlClient.SqlCommand();
            this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
            this.sqlUpdateCommand = new System.Data.SqlClient.SqlCommand();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lblClientName = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.sqlCommand2 = new System.Data.SqlClient.SqlCommand();
            this.daEmployeeDocuments = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlCommand1 = new System.Data.SqlClient.SqlCommand();
            this.sqlCommand3 = new System.Data.SqlClient.SqlCommand();
            this.sqlCommand5 = new System.Data.SqlClient.SqlCommand();
            this.sqlDeleteCommand = new System.Data.SqlClient.SqlCommand();
            this.sqlInsertCommand = new System.Data.SqlClient.SqlCommand();
            this.plTop = new System.Windows.Forms.Panel();
            this.btnCloseTop = new System.Windows.Forms.Button();
            this.lbTitle = new System.Windows.Forms.Label();
            this.txtDocumentType = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.employeeDocumentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pbxImage = new System.Windows.Forms.PictureBox();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnAttach = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose1 = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.dgVendorServices = new System.Windows.Forms.DataGridView();
            this.Edit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Delete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.DocumentIdSearch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.employeeIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.documentNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.documentImageDataGridViewImageColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.documentTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.employeeDocumentBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.dsEmployeeDocuments1 = new Ncsln.Master.dsEmployeeDocuments();
            this.panel1.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel6.SuspendLayout();
            this.plTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.employeeDocumentBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgVendorServices)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeeDocumentBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsEmployeeDocuments1)).BeginInit();
            this.SuspendLayout();
            // 
            // sqlCommand4
            // 
            this.sqlCommand4.CommandText = "SELECT DocumentId, EmployeeId, DocumentName, DocumentImage, DocumentType\r\nFROM   " +
    "  EmployeeDocument\r\nWHERE  (EmployeeId = @employeeId)\r\nORDER BY DocumentName";
            this.sqlCommand4.Connection = this.sqlConnection1;
            this.sqlCommand4.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@employeeId", System.Data.SqlDbType.Decimal, 9, System.Data.ParameterDirection.Input, false, ((byte)(18)), ((byte)(0)), "EmployeeId", System.Data.DataRowVersion.Current, null)});
            // 
            // sqlConnection1
            // 
            this.sqlConnection1.ConnectionString = "Data Source=(local);Initial Catalog=InventoryServer;Persist Security Info=Tr" +
    "ue;Integrated Security=True";
            this.sqlConnection1.FireInfoMessageEventOnUserErrors = false;
            // 
            // sqlUpdateCommand
            // 
            this.sqlUpdateCommand.CommandText = resources.GetString("sqlUpdateCommand.CommandText");
            this.sqlUpdateCommand.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@DocumentId", System.Data.SqlDbType.Decimal, 0, System.Data.ParameterDirection.Input, false, ((byte)(18)), ((byte)(0)), "DocumentId", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@StudentId", System.Data.SqlDbType.Decimal, 0, System.Data.ParameterDirection.Input, false, ((byte)(18)), ((byte)(0)), "StudentId", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@DocumentName", System.Data.SqlDbType.NVarChar, 0, "DocumentName"),
            new System.Data.SqlClient.SqlParameter("@DocumentImage", System.Data.SqlDbType.Image, 0, "DocumentImage"),
            new System.Data.SqlClient.SqlParameter("@DocumentType", System.Data.SqlDbType.NVarChar, 0, "DocumentType"),
            new System.Data.SqlClient.SqlParameter("@Original_DocumentId", System.Data.SqlDbType.Decimal, 0, System.Data.ParameterDirection.Input, false, ((byte)(18)), ((byte)(0)), "DocumentId", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_StudentId", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "StudentId", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_StudentId", System.Data.SqlDbType.Decimal, 0, System.Data.ParameterDirection.Input, false, ((byte)(18)), ((byte)(0)), "StudentId", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_DocumentName", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "DocumentName", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_DocumentName", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "DocumentName", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_DocumentType", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "DocumentType", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_DocumentType", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "DocumentType", System.Data.DataRowVersion.Original, null)});
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel8);
            this.panel1.Controls.Add(this.panel7);
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1171, 440);
            this.panel1.TabIndex = 25;
            // 
            // panel8
            // 
            this.panel8.AutoScroll = true;
            this.panel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel8.Controls.Add(this.pbxImage);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel8.Location = new System.Drawing.Point(0, 54);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(995, 386);
            this.panel8.TabIndex = 27;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.btnExport);
            this.panel7.Controls.Add(this.btnPrint);
            this.panel7.Controls.Add(this.label2);
            this.panel7.Controls.Add(this.txtFileName);
            this.panel7.Controls.Add(this.btnAttach);
            this.panel7.Controls.Add(this.btnSave);
            this.panel7.Controls.Add(this.btnClose1);
            this.panel7.Controls.Add(this.btnClear);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel7.Location = new System.Drawing.Point(995, 54);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(176, 386);
            this.panel7.TabIndex = 25;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Bookman Old Style", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(10, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(152, 21);
            this.label2.TabIndex = 25;
            this.label2.Text = "Document Name";
            // 
            // txtFileName
            // 
            this.txtFileName.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtFileName.Font = new System.Drawing.Font("Bookman Old Style", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFileName.Location = new System.Drawing.Point(13, 38);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(146, 27);
            this.txtFileName.TabIndex = 1;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.lblClientName);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1171, 54);
            this.panel5.TabIndex = 24;
            // 
            // lblClientName
            // 
            this.lblClientName.AutoSize = true;
            this.lblClientName.Font = new System.Drawing.Font("Bookman Old Style", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClientName.ForeColor = System.Drawing.Color.Brown;
            this.lblClientName.Location = new System.Drawing.Point(22, 15);
            this.lblClientName.Name = "lblClientName";
            this.lblClientName.Size = new System.Drawing.Size(0, 32);
            this.lblClientName.TabIndex = 17;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1171, 759);
            this.panel2.TabIndex = 7;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 440);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1171, 319);
            this.panel3.TabIndex = 26;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.panel6);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1171, 319);
            this.panel4.TabIndex = 24;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.dgVendorServices);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1171, 319);
            this.panel6.TabIndex = 1;
            // 
            // sqlCommand2
            // 
            this.sqlCommand2.CommandText = "SELECT        DocumentId, StudentId, DocumentName, DocumentImage, DocumentType\r\nF" +
    "ROM            tbl_StudentDocuments\r\nWHERE        (StudentId = @studentId)\r\nORDE" +
    "R BY DocumentName";
            this.sqlCommand2.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@studentId", System.Data.SqlDbType.Decimal, 9, System.Data.ParameterDirection.Input, false, ((byte)(18)), ((byte)(0)), "StudentId", System.Data.DataRowVersion.Current, null)});
            // 
            // daEmployeeDocuments
            // 
            this.daEmployeeDocuments.DeleteCommand = this.sqlCommand1;
            this.daEmployeeDocuments.InsertCommand = this.sqlCommand3;
            this.daEmployeeDocuments.SelectCommand = this.sqlCommand4;
            this.daEmployeeDocuments.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "EmployeeDocument", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("DocumentId", "DocumentId"),
                        new System.Data.Common.DataColumnMapping("EmployeeId", "EmployeeId"),
                        new System.Data.Common.DataColumnMapping("DocumentName", "DocumentName"),
                        new System.Data.Common.DataColumnMapping("DocumentImage", "DocumentImage"),
                        new System.Data.Common.DataColumnMapping("DocumentType", "DocumentType")})});
            this.daEmployeeDocuments.UpdateCommand = this.sqlCommand5;
            // 
            // sqlCommand1
            // 
            this.sqlCommand1.CommandText = resources.GetString("sqlCommand1.CommandText");
            this.sqlCommand1.Connection = this.sqlConnection1;
            this.sqlCommand1.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@Original_DocumentId", System.Data.SqlDbType.Decimal, 0, System.Data.ParameterDirection.Input, false, ((byte)(18)), ((byte)(0)), "DocumentId", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_EmployeeId", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "EmployeeId", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_EmployeeId", System.Data.SqlDbType.Decimal, 0, System.Data.ParameterDirection.Input, false, ((byte)(18)), ((byte)(0)), "EmployeeId", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_DocumentName", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "DocumentName", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_DocumentName", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "DocumentName", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_DocumentType", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "DocumentType", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_DocumentType", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "DocumentType", System.Data.DataRowVersion.Original, null)});
            // 
            // sqlCommand3
            // 
            this.sqlCommand3.CommandText = resources.GetString("sqlCommand3.CommandText");
            this.sqlCommand3.Connection = this.sqlConnection1;
            this.sqlCommand3.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@DocumentId", System.Data.SqlDbType.Decimal, 0, System.Data.ParameterDirection.Input, false, ((byte)(18)), ((byte)(0)), "DocumentId", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@EmployeeId", System.Data.SqlDbType.Decimal, 0, System.Data.ParameterDirection.Input, false, ((byte)(18)), ((byte)(0)), "EmployeeId", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@DocumentName", System.Data.SqlDbType.NVarChar, 0, "DocumentName"),
            new System.Data.SqlClient.SqlParameter("@DocumentImage", System.Data.SqlDbType.Image, 0, "DocumentImage"),
            new System.Data.SqlClient.SqlParameter("@DocumentType", System.Data.SqlDbType.NVarChar, 0, "DocumentType")});
            // 
            // sqlCommand5
            // 
            this.sqlCommand5.CommandText = resources.GetString("sqlCommand5.CommandText");
            this.sqlCommand5.Connection = this.sqlConnection1;
            this.sqlCommand5.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@DocumentId", System.Data.SqlDbType.Decimal, 0, System.Data.ParameterDirection.Input, false, ((byte)(18)), ((byte)(0)), "DocumentId", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@EmployeeId", System.Data.SqlDbType.Decimal, 0, System.Data.ParameterDirection.Input, false, ((byte)(18)), ((byte)(0)), "EmployeeId", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@DocumentName", System.Data.SqlDbType.NVarChar, 0, "DocumentName"),
            new System.Data.SqlClient.SqlParameter("@DocumentImage", System.Data.SqlDbType.Image, 0, "DocumentImage"),
            new System.Data.SqlClient.SqlParameter("@DocumentType", System.Data.SqlDbType.NVarChar, 0, "DocumentType"),
            new System.Data.SqlClient.SqlParameter("@Original_DocumentId", System.Data.SqlDbType.Decimal, 0, System.Data.ParameterDirection.Input, false, ((byte)(18)), ((byte)(0)), "DocumentId", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_EmployeeId", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "EmployeeId", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_EmployeeId", System.Data.SqlDbType.Decimal, 0, System.Data.ParameterDirection.Input, false, ((byte)(18)), ((byte)(0)), "EmployeeId", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_DocumentName", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "DocumentName", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_DocumentName", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "DocumentName", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_DocumentType", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "DocumentType", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_DocumentType", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "DocumentType", System.Data.DataRowVersion.Original, null)});
            // 
            // sqlDeleteCommand
            // 
            this.sqlDeleteCommand.CommandText = resources.GetString("sqlDeleteCommand.CommandText");
            this.sqlDeleteCommand.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@Original_DocumentId", System.Data.SqlDbType.Decimal, 0, System.Data.ParameterDirection.Input, false, ((byte)(18)), ((byte)(0)), "DocumentId", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_StudentId", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "StudentId", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_StudentId", System.Data.SqlDbType.Decimal, 0, System.Data.ParameterDirection.Input, false, ((byte)(18)), ((byte)(0)), "StudentId", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_DocumentName", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "DocumentName", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_DocumentName", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "DocumentName", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_DocumentType", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "DocumentType", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_DocumentType", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "DocumentType", System.Data.DataRowVersion.Original, null)});
            // 
            // sqlInsertCommand
            // 
            this.sqlInsertCommand.CommandText = resources.GetString("sqlInsertCommand.CommandText");
            this.sqlInsertCommand.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@DocumentId", System.Data.SqlDbType.Decimal, 0, System.Data.ParameterDirection.Input, false, ((byte)(18)), ((byte)(0)), "DocumentId", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@StudentId", System.Data.SqlDbType.Decimal, 0, System.Data.ParameterDirection.Input, false, ((byte)(18)), ((byte)(0)), "StudentId", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@DocumentName", System.Data.SqlDbType.NVarChar, 0, "DocumentName"),
            new System.Data.SqlClient.SqlParameter("@DocumentImage", System.Data.SqlDbType.Image, 0, "DocumentImage"),
            new System.Data.SqlClient.SqlParameter("@DocumentType", System.Data.SqlDbType.NVarChar, 0, "DocumentType")});
            // 
            // plTop
            // 
            this.plTop.BackColor = System.Drawing.Color.Transparent;
            this.plTop.BackgroundImage = global::Ncsln.Properties.Resources.formbackground;
            this.plTop.Controls.Add(this.btnCloseTop);
            this.plTop.Controls.Add(this.lbTitle);
            this.plTop.Controls.Add(this.txtDocumentType);
            this.plTop.Controls.Add(this.label3);
            this.plTop.Controls.Add(this.txtDescription);
            this.plTop.Controls.Add(this.label1);
            this.plTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.plTop.Location = new System.Drawing.Point(0, 0);
            this.plTop.Name = "plTop";
            this.plTop.Size = new System.Drawing.Size(1171, 60);
            this.plTop.TabIndex = 6;
            // 
            // btnCloseTop
            // 
            this.btnCloseTop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCloseTop.Image = global::Ncsln.Properties.Resources.wrong;
            this.btnCloseTop.Location = new System.Drawing.Point(1143, 3);
            this.btnCloseTop.Name = "btnCloseTop";
            this.btnCloseTop.Size = new System.Drawing.Size(25, 25);
            this.btnCloseTop.TabIndex = 28;
            this.btnCloseTop.TabStop = false;
            this.btnCloseTop.UseVisualStyleBackColor = true;
            this.btnCloseTop.Click += new System.EventHandler(this.btnCloseTop_Click);
            // 
            // lbTitle
            // 
            this.lbTitle.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbTitle.AutoSize = true;
            this.lbTitle.Font = new System.Drawing.Font("Century", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitle.ForeColor = System.Drawing.Color.White;
            this.lbTitle.Location = new System.Drawing.Point(272, 12);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(332, 35);
            this.lbTitle.TabIndex = 8;
            this.lbTitle.Text = "Employee Documents";
            // 
            // txtDocumentType
            // 
            this.txtDocumentType.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtDocumentType.Enabled = false;
            this.txtDocumentType.Font = new System.Drawing.Font("Bookman Old Style", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDocumentType.Location = new System.Drawing.Point(68, 18);
            this.txtDocumentType.Name = "txtDocumentType";
            this.txtDocumentType.Size = new System.Drawing.Size(146, 27);
            this.txtDocumentType.TabIndex = 26;
            this.txtDocumentType.Visible = false;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Bookman Old Style", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(103, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(144, 21);
            this.label3.TabIndex = 27;
            this.label3.Text = "Document Type";
            this.label3.Visible = false;
            // 
            // txtDescription
            // 
            this.txtDescription.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtDescription.Font = new System.Drawing.Font("Bookman Old Style", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescription.Location = new System.Drawing.Point(1012, 20);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(116, 27);
            this.txtDescription.TabIndex = 1;
            this.txtDescription.Visible = false;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bookman Old Style", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(786, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 21);
            this.label1.TabIndex = 7;
            this.label1.Text = "Description";
            this.label1.Visible = false;
            // 
            // employeeDocumentBindingSource
            // 
            this.employeeDocumentBindingSource.DataMember = "EmployeeDocument";
            // 
            // pbxImage
            // 
            this.pbxImage.Location = new System.Drawing.Point(0, 0);
            this.pbxImage.Name = "pbxImage";
            this.pbxImage.Size = new System.Drawing.Size(1, 1);
            this.pbxImage.TabIndex = 0;
            this.pbxImage.TabStop = false;
            // 
            // btnExport
            // 
            this.btnExport.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnExport.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnExport.BackgroundImage")));
            this.btnExport.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.Font = new System.Drawing.Font("Bookman Old Style", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.ForeColor = System.Drawing.Color.Black;
            this.btnExport.Location = new System.Drawing.Point(46, 222);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(87, 35);
            this.btnExport.TabIndex = 22;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnPrint.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPrint.BackgroundImage")));
            this.btnPrint.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Font = new System.Drawing.Font("Bookman Old Style", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.ForeColor = System.Drawing.Color.Black;
            this.btnPrint.Location = new System.Drawing.Point(46, 183);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(87, 35);
            this.btnPrint.TabIndex = 21;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnAttach
            // 
            this.btnAttach.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnAttach.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAttach.BackgroundImage")));
            this.btnAttach.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnAttach.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAttach.Font = new System.Drawing.Font("Bookman Old Style", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAttach.ForeColor = System.Drawing.Color.Black;
            this.btnAttach.Location = new System.Drawing.Point(46, 105);
            this.btnAttach.Name = "btnAttach";
            this.btnAttach.Size = new System.Drawing.Size(87, 35);
            this.btnAttach.TabIndex = 19;
            this.btnAttach.Text = "Attach";
            this.btnAttach.UseVisualStyleBackColor = true;
            this.btnAttach.Click += new System.EventHandler(this.btnAttach_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnSave.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSave.BackgroundImage")));
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Bookman Old Style", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.Black;
            this.btnSave.Location = new System.Drawing.Point(46, 144);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(87, 35);
            this.btnSave.TabIndex = 20;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose1
            // 
            this.btnClose1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnClose1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnClose1.BackgroundImage")));
            this.btnClose1.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnClose1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose1.Font = new System.Drawing.Font("Bookman Old Style", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose1.ForeColor = System.Drawing.Color.Black;
            this.btnClose1.Location = new System.Drawing.Point(46, 300);
            this.btnClose1.Name = "btnClose1";
            this.btnClose1.Size = new System.Drawing.Size(87, 35);
            this.btnClose1.TabIndex = 25;
            this.btnClose1.Text = "Close";
            this.btnClose1.UseVisualStyleBackColor = true;
            this.btnClose1.Click += new System.EventHandler(this.btnClose1_Click);
            // 
            // btnClear
            // 
            this.btnClear.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnClear.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnClear.BackgroundImage")));
            this.btnClear.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Bookman Old Style", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.Color.Black;
            this.btnClear.Location = new System.Drawing.Point(46, 261);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(87, 35);
            this.btnClear.TabIndex = 24;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // dgVendorServices
            // 
            this.dgVendorServices.AllowUserToAddRows = false;
            this.dgVendorServices.AllowUserToDeleteRows = false;
            this.dgVendorServices.AllowUserToResizeColumns = false;
            this.dgVendorServices.AllowUserToResizeRows = false;
            this.dgVendorServices.AutoGenerateColumns = false;
            this.dgVendorServices.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgVendorServices.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgVendorServices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgVendorServices.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DocumentIdSearch,
            this.employeeIdDataGridViewTextBoxColumn,
            this.documentNameDataGridViewTextBoxColumn,
            this.documentImageDataGridViewImageColumn,
            this.documentTypeDataGridViewTextBoxColumn,
            this.Edit,
            this.Delete});
            this.dgVendorServices.DataSource = this.employeeDocumentBindingSource1;
            this.dgVendorServices.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgVendorServices.Location = new System.Drawing.Point(0, 0);
            this.dgVendorServices.Name = "dgVendorServices";
            this.dgVendorServices.RowHeadersVisible = false;
            this.dgVendorServices.Size = new System.Drawing.Size(1171, 319);
            this.dgVendorServices.TabIndex = 2;
            this.dgVendorServices.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgVendorServices_CellContentClick);
            // 
            // Edit
            // 
            this.Edit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Edit.HeaderText = "Edit";
            this.Edit.Name = "Edit";
            this.Edit.Text = "Edit";
            this.Edit.ToolTipText = "Edit";
            this.Edit.UseColumnTextForButtonValue = true;
            this.Edit.Width = 40;
            // 
            // Delete
            // 
            this.Delete.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Delete.HeaderText = "Delete";
            this.Delete.Name = "Delete";
            this.Delete.Text = "Delete";
            this.Delete.ToolTipText = "Delete";
            this.Delete.UseColumnTextForButtonValue = true;
            this.Delete.Width = 50;
            // 
            // DocumentIdSearch
            // 
            this.DocumentIdSearch.DataPropertyName = "DocumentId";
            this.DocumentIdSearch.HeaderText = "DocumentId";
            this.DocumentIdSearch.Name = "DocumentIdSearch";
            this.DocumentIdSearch.Visible = false;
            // 
            // employeeIdDataGridViewTextBoxColumn
            // 
            this.employeeIdDataGridViewTextBoxColumn.DataPropertyName = "EmployeeId";
            this.employeeIdDataGridViewTextBoxColumn.HeaderText = "EmployeeId";
            this.employeeIdDataGridViewTextBoxColumn.Name = "employeeIdDataGridViewTextBoxColumn";
            this.employeeIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // documentNameDataGridViewTextBoxColumn
            // 
            this.documentNameDataGridViewTextBoxColumn.DataPropertyName = "DocumentName";
            this.documentNameDataGridViewTextBoxColumn.HeaderText = "Document";
            this.documentNameDataGridViewTextBoxColumn.Name = "documentNameDataGridViewTextBoxColumn";
            // 
            // documentImageDataGridViewImageColumn
            // 
            this.documentImageDataGridViewImageColumn.DataPropertyName = "DocumentImage";
            this.documentImageDataGridViewImageColumn.HeaderText = "DocumentImage";
            this.documentImageDataGridViewImageColumn.Name = "documentImageDataGridViewImageColumn";
            this.documentImageDataGridViewImageColumn.Visible = false;
            // 
            // documentTypeDataGridViewTextBoxColumn
            // 
            this.documentTypeDataGridViewTextBoxColumn.DataPropertyName = "DocumentType";
            this.documentTypeDataGridViewTextBoxColumn.HeaderText = "DocumentType";
            this.documentTypeDataGridViewTextBoxColumn.Name = "documentTypeDataGridViewTextBoxColumn";
            this.documentTypeDataGridViewTextBoxColumn.Visible = false;
            // 
            // employeeDocumentBindingSource1
            // 
            this.employeeDocumentBindingSource1.DataMember = "EmployeeDocument";
            this.employeeDocumentBindingSource1.DataSource = this.dsEmployeeDocuments1;
            // 
            // dsEmployeeDocuments1
            // 
            this.dsEmployeeDocuments1.DataSetName = "dsEmployeeDocuments";
            this.dsEmployeeDocuments1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // frmEmployeeDocument
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1171, 759);
            this.Controls.Add(this.plTop);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmEmployeeDocument";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Employee Document";
            this.Load += new System.EventHandler(this.frmEmployeeDocument_Load);
            this.panel1.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.plTop.ResumeLayout(false);
            this.plTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.employeeDocumentBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgVendorServices)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeeDocumentBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsEmployeeDocuments1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Data.SqlClient.SqlCommand sqlCommand4;
        private System.Data.SqlClient.SqlConnection sqlConnection1;
        private System.Windows.Forms.BindingSource employeeDocumentBindingSource;
        private System.Data.SqlClient.SqlCommand sqlUpdateCommand;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.PictureBox pbxImage;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.Button btnAttach;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose1;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label lblClientName;
        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.Panel plTop;
        private System.Windows.Forms.Button btnCloseTop;
        private System.Windows.Forms.TextBox txtDocumentType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.DataGridView dgVendorServices;
        private System.Data.SqlClient.SqlCommand sqlCommand2;
        private System.Data.SqlClient.SqlDataAdapter daEmployeeDocuments;
        private System.Data.SqlClient.SqlCommand sqlCommand1;
        private System.Data.SqlClient.SqlCommand sqlCommand3;
        private System.Data.SqlClient.SqlCommand sqlCommand5;
        private System.Data.SqlClient.SqlCommand sqlDeleteCommand;
        private System.Data.SqlClient.SqlCommand sqlInsertCommand;
        private dsEmployeeDocuments dsEmployeeDocuments1;
        private System.Windows.Forms.DataGridViewTextBoxColumn DocumentIdSearch;
        private System.Windows.Forms.DataGridViewTextBoxColumn employeeIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn documentNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewImageColumn documentImageDataGridViewImageColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn documentTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewButtonColumn Edit;
        private System.Windows.Forms.DataGridViewButtonColumn Delete;
        private System.Windows.Forms.BindingSource employeeDocumentBindingSource1;
    }
}