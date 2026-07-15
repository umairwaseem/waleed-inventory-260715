namespace Ncsln.Master
{
    partial class frmEmployeeSalary
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEmployeeSalary));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pbEmployee = new System.Windows.Forms.PictureBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.RichTextBox();
            this.CmbFont = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dtp = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbGroup = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtRemaining = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.txtExpanse = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMajorAmount = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbTotalPercentage = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lbTotalSalary = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnPay = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtTotalPay = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.empId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.branch = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.employee = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.salary = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.percentage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.percentAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.growsAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.absentDays = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.absentAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Bonus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.finalAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.employeeSalaryIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.employeeSalaryDetailBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsEmployeeSalaryDetail1 = new Ncsln.Master.dsEmployeeSalaryDetail();
            this.daEmployeeSalaryDetail = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlDeleteCommand = new System.Data.SqlClient.SqlCommand();
            this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
            this.sqlInsertCommand = new System.Data.SqlClient.SqlCommand();
            this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
            this.sqlUpdateCommand = new System.Data.SqlClient.SqlCommand();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbEmployee)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemaining)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtExpanse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMajorAmount)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeeSalaryDetailBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsEmployeeSalaryDetail1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pbEmployee);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.txtDescription);
            this.panel1.Controls.Add(this.CmbFont);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.dtp);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.cmbGroup);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtRemaining);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtExpanse);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtMajorAmount);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1160, 180);
            this.panel1.TabIndex = 0;
            // 
            // pbEmployee
            // 
            this.pbEmployee.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbEmployee.Location = new System.Drawing.Point(631, 31);
            this.pbEmployee.Name = "pbEmployee";
            this.pbEmployee.Size = new System.Drawing.Size(131, 135);
            this.pbEmployee.TabIndex = 17;
            this.pbEmployee.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(425, 34);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 17);
            this.label8.TabIndex = 16;
            this.label8.Text = "Fonts";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(150, 69);
            this.txtDescription.Margin = new System.Windows.Forms.Padding(4);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(453, 54);
            this.txtDescription.TabIndex = 1;
            this.txtDescription.Text = "";
            // 
            // CmbFont
            // 
            this.CmbFont.FormattingEnabled = true;
            this.CmbFont.Items.AddRange(new object[] {
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "20"});
            this.CmbFont.Location = new System.Drawing.Point(482, 31);
            this.CmbFont.Name = "CmbFont";
            this.CmbFont.Size = new System.Drawing.Size(121, 24);
            this.CmbFont.TabIndex = 15;
            this.CmbFont.SelectionChangeCommitted += new System.EventHandler(this.CmbFont_SelectionChangeCommitted);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(29, 69);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 34);
            this.label6.TabIndex = 10;
            this.label6.Text = "Description\r\n(If Any)";
            // 
            // dtp
            // 
            this.dtp.CustomFormat = "dd/MMM/yyyy";
            this.dtp.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp.Location = new System.Drawing.Point(150, 31);
            this.dtp.Margin = new System.Windows.Forms.Padding(4);
            this.dtp.Name = "dtp";
            this.dtp.Size = new System.Drawing.Size(264, 23);
            this.dtp.TabIndex = 0;
            this.dtp.ValueChanged += new System.EventHandler(this.dtp_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(29, 34);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "Date/Month";
            // 
            // cmbGroup
            // 
            this.cmbGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGroup.FormattingEnabled = true;
            this.cmbGroup.Location = new System.Drawing.Point(150, 134);
            this.cmbGroup.Margin = new System.Windows.Forms.Padding(4);
            this.cmbGroup.Name = "cmbGroup";
            this.cmbGroup.Size = new System.Drawing.Size(264, 24);
            this.cmbGroup.TabIndex = 7;
            this.cmbGroup.Visible = false;
            this.cmbGroup.SelectedIndexChanged += new System.EventHandler(this.cmbGroup_SelectedIndexChanged);
            this.cmbGroup.SelectionChangeCommitted += new System.EventHandler(this.cmbGroup_SelectionChangeCommitted);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 138);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Select Group";
            this.label4.Visible = false;
            // 
            // txtRemaining
            // 
            this.txtRemaining.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRemaining.Enabled = false;
            this.txtRemaining.Location = new System.Drawing.Point(895, 99);
            this.txtRemaining.Margin = new System.Windows.Forms.Padding(4);
            this.txtRemaining.Maximum = new decimal(new int[] {
            1316134912,
            2328,
            0,
            0});
            this.txtRemaining.Name = "txtRemaining";
            this.txtRemaining.ReadOnly = true;
            this.txtRemaining.Size = new System.Drawing.Size(219, 23);
            this.txtRemaining.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(769, 101);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Remaining";
            // 
            // txtExpanse
            // 
            this.txtExpanse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtExpanse.Location = new System.Drawing.Point(895, 64);
            this.txtExpanse.Margin = new System.Windows.Forms.Padding(4);
            this.txtExpanse.Maximum = new decimal(new int[] {
            1316134912,
            2328,
            0,
            0});
            this.txtExpanse.Name = "txtExpanse";
            this.txtExpanse.Size = new System.Drawing.Size(219, 23);
            this.txtExpanse.TabIndex = 3;
            this.txtExpanse.ValueChanged += new System.EventHandler(this.txtExpanse_ValueChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(769, 66);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Expense";
            // 
            // txtMajorAmount
            // 
            this.txtMajorAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMajorAmount.Location = new System.Drawing.Point(895, 29);
            this.txtMajorAmount.Margin = new System.Windows.Forms.Padding(4);
            this.txtMajorAmount.Maximum = new decimal(new int[] {
            1316134912,
            2328,
            0,
            0});
            this.txtMajorAmount.Name = "txtMajorAmount";
            this.txtMajorAmount.Size = new System.Drawing.Size(219, 23);
            this.txtMajorAmount.TabIndex = 2;
            this.txtMajorAmount.ValueChanged += new System.EventHandler(this.txtMajorAmount_ValueChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(769, 31);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Major Amount";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lbTotalPercentage);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.lbTotalSalary);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.btnPrint);
            this.panel2.Controls.Add(this.btnPay);
            this.panel2.Controls.Add(this.btnSave);
            this.panel2.Controls.Add(this.txtTotalPay);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 489);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1160, 68);
            this.panel2.TabIndex = 1;
            // 
            // lbTotalPercentage
            // 
            this.lbTotalPercentage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbTotalPercentage.AutoSize = true;
            this.lbTotalPercentage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lbTotalPercentage.Location = new System.Drawing.Point(673, 27);
            this.lbTotalPercentage.Name = "lbTotalPercentage";
            this.lbTotalPercentage.Size = new System.Drawing.Size(18, 20);
            this.lbTotalPercentage.TabIndex = 8;
            this.lbTotalPercentage.Text = "0";
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label12.Location = new System.Drawing.Point(563, 27);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(82, 20);
            this.label12.TabIndex = 7;
            this.label12.Text = "% Share : ";
            // 
            // lbTotalSalary
            // 
            this.lbTotalSalary.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbTotalSalary.AutoSize = true;
            this.lbTotalSalary.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lbTotalSalary.Location = new System.Drawing.Point(442, 27);
            this.lbTotalSalary.Name = "lbTotalSalary";
            this.lbTotalSalary.Size = new System.Drawing.Size(18, 20);
            this.lbTotalSalary.TabIndex = 6;
            this.lbTotalSalary.Text = "0";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label9.Location = new System.Drawing.Point(352, 27);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 20);
            this.label9.TabIndex = 5;
            this.label9.Text = "Salary : ";
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(191, 24);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 30);
            this.btnPrint.TabIndex = 4;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnPay
            // 
            this.btnPay.Location = new System.Drawing.Point(110, 24);
            this.btnPay.Name = "btnPay";
            this.btnPay.Size = new System.Drawing.Size(75, 30);
            this.btnPay.TabIndex = 3;
            this.btnPay.Text = "Pay";
            this.btnPay.UseVisualStyleBackColor = true;
            this.btnPay.Click += new System.EventHandler(this.btnPay_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(29, 24);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 30);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtTotalPay
            // 
            this.txtTotalPay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotalPay.BackColor = System.Drawing.Color.White;
            this.txtTotalPay.Enabled = false;
            this.txtTotalPay.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtTotalPay.Location = new System.Drawing.Point(868, 24);
            this.txtTotalPay.Name = "txtTotalPay";
            this.txtTotalPay.ReadOnly = true;
            this.txtTotalPay.Size = new System.Drawing.Size(280, 26);
            this.txtTotalPay.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(770, 29);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 17);
            this.label7.TabIndex = 0;
            this.label7.Text = "Total Pay";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dgv);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 180);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1160, 309);
            this.panel3.TabIndex = 2;
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AutoGenerateColumns = false;
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.empId,
            this.branch,
            this.employee,
            this.salary,
            this.percentage,
            this.percentAmount,
            this.growsAmount,
            this.absentDays,
            this.absentAmount,
            this.Bonus,
            this.finalAmount,
            this.employeeSalaryIdDataGridViewTextBoxColumn});
            this.dgv.DataSource = this.employeeSalaryDetailBindingSource;
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.Location = new System.Drawing.Point(0, 0);
            this.dgv.Margin = new System.Windows.Forms.Padding(4);
            this.dgv.Name = "dgv";
            this.dgv.RowHeadersVisible = false;
            this.dgv.RowTemplate.Height = 24;
            this.dgv.Size = new System.Drawing.Size(1160, 309);
            this.dgv.TabIndex = 0;
            this.dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellClick);
            this.dgv.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellContentClick);
            this.dgv.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellValueChanged);
            this.dgv.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_RowEnter);
            // 
            // empId
            // 
            this.empId.DataPropertyName = "Id";
            this.empId.HeaderText = "Id";
            this.empId.Name = "empId";
            this.empId.ReadOnly = true;
            this.empId.Visible = false;
            // 
            // branch
            // 
            this.branch.DataPropertyName = "Branch_Id";
            this.branch.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.branch.HeaderText = "Branch";
            this.branch.Name = "branch";
            this.branch.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.branch.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // employee
            // 
            this.employee.DataPropertyName = "Employee_Id";
            this.employee.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.employee.HeaderText = "Employee";
            this.employee.Name = "employee";
            this.employee.ReadOnly = true;
            this.employee.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.employee.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // salary
            // 
            this.salary.DataPropertyName = "Salary";
            this.salary.HeaderText = "Salary";
            this.salary.Name = "salary";
            this.salary.ReadOnly = true;
            // 
            // percentage
            // 
            this.percentage.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.percentage.DataPropertyName = "Percentage";
            this.percentage.HeaderText = "%";
            this.percentage.Name = "percentage";
            this.percentage.Width = 40;
            // 
            // percentAmount
            // 
            this.percentAmount.DataPropertyName = "PercentAmount";
            this.percentAmount.HeaderText = "% Amount";
            this.percentAmount.Name = "percentAmount";
            // 
            // growsAmount
            // 
            this.growsAmount.DataPropertyName = "GrowsAmount";
            this.growsAmount.HeaderText = "G.Amount";
            this.growsAmount.Name = "growsAmount";
            // 
            // absentDays
            // 
            this.absentDays.DataPropertyName = "AbsentDays";
            this.absentDays.HeaderText = "Absent";
            this.absentDays.Name = "absentDays";
            // 
            // absentAmount
            // 
            this.absentAmount.DataPropertyName = "AbsentAmount";
            this.absentAmount.HeaderText = "Absent Amount";
            this.absentAmount.Name = "absentAmount";
            // 
            // Bonus
            // 
            this.Bonus.DataPropertyName = "Bonus";
            this.Bonus.HeaderText = "Bonus";
            this.Bonus.Name = "Bonus";
            // 
            // finalAmount
            // 
            this.finalAmount.DataPropertyName = "FinalAmount";
            this.finalAmount.HeaderText = "Final Pay";
            this.finalAmount.Name = "finalAmount";
            // 
            // employeeSalaryIdDataGridViewTextBoxColumn
            // 
            this.employeeSalaryIdDataGridViewTextBoxColumn.DataPropertyName = "EmployeeSalary_Id";
            this.employeeSalaryIdDataGridViewTextBoxColumn.HeaderText = "EmployeeSalary_Id";
            this.employeeSalaryIdDataGridViewTextBoxColumn.Name = "employeeSalaryIdDataGridViewTextBoxColumn";
            this.employeeSalaryIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // employeeSalaryDetailBindingSource
            // 
            this.employeeSalaryDetailBindingSource.DataMember = "EmployeeSalaryDetail";
            this.employeeSalaryDetailBindingSource.DataSource = this.dsEmployeeSalaryDetail1;
            // 
            // dsEmployeeSalaryDetail1
            // 
            this.dsEmployeeSalaryDetail1.DataSetName = "dsEmployeeSalaryDetail";
            this.dsEmployeeSalaryDetail1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // daEmployeeSalaryDetail
            // 
            this.daEmployeeSalaryDetail.DeleteCommand = this.sqlDeleteCommand;
            this.daEmployeeSalaryDetail.InsertCommand = this.sqlInsertCommand;
            this.daEmployeeSalaryDetail.SelectCommand = this.sqlSelectCommand1;
            this.daEmployeeSalaryDetail.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "EmployeeSalaryDetail", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("Id", "Id"),
                        new System.Data.Common.DataColumnMapping("Employee_Id", "Employee_Id"),
                        new System.Data.Common.DataColumnMapping("Salary", "Salary"),
                        new System.Data.Common.DataColumnMapping("Percentage", "Percentage"),
                        new System.Data.Common.DataColumnMapping("PercentAmount", "PercentAmount"),
                        new System.Data.Common.DataColumnMapping("GrowsAmount", "GrowsAmount"),
                        new System.Data.Common.DataColumnMapping("AbsentDays", "AbsentDays"),
                        new System.Data.Common.DataColumnMapping("AbsentAmount", "AbsentAmount"),
                        new System.Data.Common.DataColumnMapping("FinalAmount", "FinalAmount"),
                        new System.Data.Common.DataColumnMapping("Branch_Id", "Branch_Id"),
                        new System.Data.Common.DataColumnMapping("EmployeeSalary_Id", "EmployeeSalary_Id"),
                        new System.Data.Common.DataColumnMapping("Bonus", "Bonus")})});
            this.daEmployeeSalaryDetail.UpdateCommand = this.sqlUpdateCommand;
            // 
            // sqlDeleteCommand
            // 
            this.sqlDeleteCommand.CommandText = resources.GetString("sqlDeleteCommand.CommandText");
            this.sqlDeleteCommand.Connection = this.sqlConnection1;
            this.sqlDeleteCommand.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@Original_Id", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Id", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_Employee_Id", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Employee_Id", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_Employee_Id", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Employee_Id", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_Salary", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Salary", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_Salary", System.Data.SqlDbType.Decimal, 0, System.Data.ParameterDirection.Input, false, ((byte)(18)), ((byte)(2)), "Salary", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_Percentage", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Percentage", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_Percentage", System.Data.SqlDbType.Decimal, 0, System.Data.ParameterDirection.Input, false, ((byte)(18)), ((byte)(2)), "Percentage", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_PercentAmount", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "PercentAmount", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_PercentAmount", System.Data.SqlDbType.Decimal, 0, System.Data.ParameterDirection.Input, false, ((byte)(18)), ((byte)(2)), "PercentAmount", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_GrowsAmount", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "GrowsAmount", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_GrowsAmount", System.Data.SqlDbType.Decimal, 0, System.Data.ParameterDirection.Input, false, ((byte)(18)), ((byte)(2)), "GrowsAmount", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_AbsentDays", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "AbsentDays", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_AbsentDays", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "AbsentDays", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_AbsentAmount", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "AbsentAmount", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_AbsentAmount", System.Data.SqlDbType.Decimal, 0, System.Data.ParameterDirection.Input, false, ((byte)(18)), ((byte)(2)), "AbsentAmount", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_FinalAmount", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "FinalAmount", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_FinalAmount", System.Data.SqlDbType.Decimal, 0, System.Data.ParameterDirection.Input, false, ((byte)(18)), ((byte)(2)), "FinalAmount", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_Branch_Id", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Branch_Id", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_Branch_Id", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Branch_Id", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_EmployeeSalary_Id", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "EmployeeSalary_Id", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_EmployeeSalary_Id", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "EmployeeSalary_Id", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_Bonus", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Bonus", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_Bonus", System.Data.SqlDbType.Decimal, 0, System.Data.ParameterDirection.Input, false, ((byte)(18)), ((byte)(2)), "Bonus", System.Data.DataRowVersion.Original, null)});
            // 
            // sqlConnection1
            // 
            this.sqlConnection1.ConnectionString = "Data Source=(local);Initial Catalog=InventoryServer;Persist Security Info=Tr" +
    "ue;Integrated Security=True";
            this.sqlConnection1.FireInfoMessageEventOnUserErrors = false;
            // 
            // sqlInsertCommand
            // 
            this.sqlInsertCommand.CommandText = resources.GetString("sqlInsertCommand.CommandText");
            this.sqlInsertCommand.Connection = this.sqlConnection1;
            this.sqlInsertCommand.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@Employee_Id", System.Data.SqlDbType.Int, 0, "Employee_Id"),
            new System.Data.SqlClient.SqlParameter("@Salary", System.Data.SqlDbType.Decimal, 0, System.Data.ParameterDirection.Input, false, ((byte)(18)), ((byte)(2)), "Salary", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@Percentage", System.Data.SqlDbType.Decimal, 0, System.Data.ParameterDirection.Input, false, ((byte)(18)), ((byte)(2)), "Percentage", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@PercentAmount", System.Data.SqlDbType.Decimal, 0, System.Data.ParameterDirection.Input, false, ((byte)(18)), ((byte)(2)), "PercentAmount", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@GrowsAmount", System.Data.SqlDbType.Decimal, 0, System.Data.ParameterDirection.Input, false, ((byte)(18)), ((byte)(2)), "GrowsAmount", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@AbsentDays", System.Data.SqlDbType.Int, 0, "AbsentDays"),
            new System.Data.SqlClient.SqlParameter("@AbsentAmount", System.Data.SqlDbType.Decimal, 0, System.Data.ParameterDirection.Input, false, ((byte)(18)), ((byte)(2)), "AbsentAmount", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@FinalAmount", System.Data.SqlDbType.Decimal, 0, System.Data.ParameterDirection.Input, false, ((byte)(18)), ((byte)(2)), "FinalAmount", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@Branch_Id", System.Data.SqlDbType.Int, 0, "Branch_Id"),
            new System.Data.SqlClient.SqlParameter("@EmployeeSalary_Id", System.Data.SqlDbType.Int, 0, "EmployeeSalary_Id"),
            new System.Data.SqlClient.SqlParameter("@Bonus", System.Data.SqlDbType.Decimal, 0, System.Data.ParameterDirection.Input, false, ((byte)(18)), ((byte)(2)), "Bonus", System.Data.DataRowVersion.Current, null)});
            // 
            // sqlSelectCommand1
            // 
            this.sqlSelectCommand1.CommandText = resources.GetString("sqlSelectCommand1.CommandText");
            this.sqlSelectCommand1.Connection = this.sqlConnection1;
            this.sqlSelectCommand1.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@Id", System.Data.SqlDbType.Int, 4, "EmployeeSalary_Id")});
            // 
            // sqlUpdateCommand
            // 
            this.sqlUpdateCommand.CommandText = resources.GetString("sqlUpdateCommand.CommandText");
            this.sqlUpdateCommand.Connection = this.sqlConnection1;
            this.sqlUpdateCommand.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@Employee_Id", System.Data.SqlDbType.Int, 0, "Employee_Id"),
            new System.Data.SqlClient.SqlParameter("@Salary", System.Data.SqlDbType.Decimal, 0, System.Data.ParameterDirection.Input, false, ((byte)(18)), ((byte)(2)), "Salary", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@Percentage", System.Data.SqlDbType.Decimal, 0, System.Data.ParameterDirection.Input, false, ((byte)(18)), ((byte)(2)), "Percentage", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@PercentAmount", System.Data.SqlDbType.Decimal, 0, System.Data.ParameterDirection.Input, false, ((byte)(18)), ((byte)(2)), "PercentAmount", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@GrowsAmount", System.Data.SqlDbType.Decimal, 0, System.Data.ParameterDirection.Input, false, ((byte)(18)), ((byte)(2)), "GrowsAmount", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@AbsentDays", System.Data.SqlDbType.Int, 0, "AbsentDays"),
            new System.Data.SqlClient.SqlParameter("@AbsentAmount", System.Data.SqlDbType.Decimal, 0, System.Data.ParameterDirection.Input, false, ((byte)(18)), ((byte)(2)), "AbsentAmount", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@FinalAmount", System.Data.SqlDbType.Decimal, 0, System.Data.ParameterDirection.Input, false, ((byte)(18)), ((byte)(2)), "FinalAmount", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@Branch_Id", System.Data.SqlDbType.Int, 0, "Branch_Id"),
            new System.Data.SqlClient.SqlParameter("@EmployeeSalary_Id", System.Data.SqlDbType.Int, 0, "EmployeeSalary_Id"),
            new System.Data.SqlClient.SqlParameter("@Bonus", System.Data.SqlDbType.Decimal, 0, System.Data.ParameterDirection.Input, false, ((byte)(18)), ((byte)(2)), "Bonus", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@Original_Id", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Id", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_Employee_Id", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Employee_Id", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_Employee_Id", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Employee_Id", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_Salary", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Salary", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_Salary", System.Data.SqlDbType.Decimal, 0, System.Data.ParameterDirection.Input, false, ((byte)(18)), ((byte)(2)), "Salary", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_Percentage", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Percentage", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_Percentage", System.Data.SqlDbType.Decimal, 0, System.Data.ParameterDirection.Input, false, ((byte)(18)), ((byte)(2)), "Percentage", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_PercentAmount", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "PercentAmount", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_PercentAmount", System.Data.SqlDbType.Decimal, 0, System.Data.ParameterDirection.Input, false, ((byte)(18)), ((byte)(2)), "PercentAmount", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_GrowsAmount", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "GrowsAmount", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_GrowsAmount", System.Data.SqlDbType.Decimal, 0, System.Data.ParameterDirection.Input, false, ((byte)(18)), ((byte)(2)), "GrowsAmount", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_AbsentDays", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "AbsentDays", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_AbsentDays", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "AbsentDays", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_AbsentAmount", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "AbsentAmount", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_AbsentAmount", System.Data.SqlDbType.Decimal, 0, System.Data.ParameterDirection.Input, false, ((byte)(18)), ((byte)(2)), "AbsentAmount", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_FinalAmount", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "FinalAmount", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_FinalAmount", System.Data.SqlDbType.Decimal, 0, System.Data.ParameterDirection.Input, false, ((byte)(18)), ((byte)(2)), "FinalAmount", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_Branch_Id", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Branch_Id", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_Branch_Id", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Branch_Id", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_EmployeeSalary_Id", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "EmployeeSalary_Id", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_EmployeeSalary_Id", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "EmployeeSalary_Id", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_Bonus", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Bonus", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_Bonus", System.Data.SqlDbType.Decimal, 0, System.Data.ParameterDirection.Input, false, ((byte)(18)), ((byte)(2)), "Bonus", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Id", System.Data.SqlDbType.Int, 4, "Id")});
            // 
            // frmEmployeeSalary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1160, 557);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmEmployeeSalary";
            this.Text = "Employee Salary";
            this.Load += new System.EventHandler(this.frmEmployeeSalary_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbEmployee)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemaining)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtExpanse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMajorAmount)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeeSalaryDetailBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsEmployeeSalaryDetail1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.NumericUpDown txtMajorAmount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown txtRemaining;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown txtExpanse;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbGroup;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtp;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.RichTextBox txtDescription;
        private System.Windows.Forms.Label label6;
        private System.Data.SqlClient.SqlDataAdapter daEmployeeSalaryDetail;
        private System.Data.SqlClient.SqlCommand sqlDeleteCommand;
        private System.Data.SqlClient.SqlConnection sqlConnection1;
        private System.Data.SqlClient.SqlCommand sqlInsertCommand;
        private System.Data.SqlClient.SqlCommand sqlSelectCommand1;
        private System.Data.SqlClient.SqlCommand sqlUpdateCommand;
        private dsEmployeeSalaryDetail dsEmployeeSalaryDetail1;
        private System.Windows.Forms.BindingSource employeeSalaryDetailBindingSource;
        private System.Windows.Forms.TextBox txtTotalPay;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnPay;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox CmbFont;
        private System.Windows.Forms.PictureBox pbEmployee;
        private System.Windows.Forms.DataGridViewTextBoxColumn empId;
        private System.Windows.Forms.DataGridViewComboBoxColumn branch;
        private System.Windows.Forms.DataGridViewComboBoxColumn employee;
        private System.Windows.Forms.DataGridViewTextBoxColumn salary;
        private System.Windows.Forms.DataGridViewTextBoxColumn percentage;
        private System.Windows.Forms.DataGridViewTextBoxColumn percentAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn growsAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn absentDays;
        private System.Windows.Forms.DataGridViewTextBoxColumn absentAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Bonus;
        private System.Windows.Forms.DataGridViewTextBoxColumn finalAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn employeeSalaryIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label lbTotalPercentage;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lbTotalSalary;
        private System.Windows.Forms.Label label9;
    }
}