namespace Ncsln.Master
{
    partial class frmProfitMargin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProfitMargin));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbAllExpTotal = new System.Windows.Forms.Label();
            this.lbHbcExpTotal = new System.Windows.Forms.Label();
            this.lbOEExpTotal = new System.Windows.Forms.Label();
            this.lbWSexpTotal = new System.Windows.Forms.Label();
            this.lbOOExpTotal = new System.Windows.Forms.Label();
            this.lbOmExpTotal = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.lbExpTotal = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lbExpHBC = new System.Windows.Forms.Label();
            this.lbExpOO = new System.Windows.Forms.Label();
            this.lbExpWS = new System.Windows.Forms.Label();
            this.lbExpOE = new System.Windows.Forms.Label();
            this.lbExpOm = new System.Windows.Forms.Label();
            this.totalP = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lbPHBC = new System.Windows.Forms.Label();
            this.lbPOO = new System.Windows.Forms.Label();
            this.lbPWS = new System.Windows.Forms.Label();
            this.lbPOE = new System.Windows.Forms.Label();
            this.lbPOm = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lbHBCMajor = new System.Windows.Forms.Label();
            this.lbHBC = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lbRe = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lbExp = new System.Windows.Forms.Label();
            this.lbMajor = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lbOO = new System.Windows.Forms.Label();
            this.lbWS = new System.Windows.Forms.Label();
            this.lbOE = new System.Windows.Forms.Label();
            this.lbOM = new System.Windows.Forms.Label();
            this.txtAmountFour = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.txtAmountThree = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAmountTwo = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.dtp = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtAmountOne = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.idShow = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amountOneDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AmountFour = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AmountThree = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amountTwoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Edit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Delete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.profitSharingBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsProfitMargin1 = new Ncsln.Master.dsProfitMargin();
            this.daProfitMargin = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlDeleteCommand = new System.Data.SqlClient.SqlCommand();
            this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
            this.sqlInsertCommand = new System.Data.SqlClient.SqlCommand();
            this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
            this.sqlUpdateCommand = new System.Data.SqlClient.SqlCommand();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtAmountFour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAmountThree)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAmountTwo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAmountOne)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.profitSharingBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsProfitMargin1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbAllExpTotal);
            this.panel1.Controls.Add(this.lbHbcExpTotal);
            this.panel1.Controls.Add(this.lbOEExpTotal);
            this.panel1.Controls.Add(this.lbWSexpTotal);
            this.panel1.Controls.Add(this.lbOOExpTotal);
            this.panel1.Controls.Add(this.lbOmExpTotal);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.lbExpTotal);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.lbExpHBC);
            this.panel1.Controls.Add(this.lbExpOO);
            this.panel1.Controls.Add(this.lbExpWS);
            this.panel1.Controls.Add(this.lbExpOE);
            this.panel1.Controls.Add(this.lbExpOm);
            this.panel1.Controls.Add(this.totalP);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.lbPHBC);
            this.panel1.Controls.Add(this.lbPOO);
            this.panel1.Controls.Add(this.lbPWS);
            this.panel1.Controls.Add(this.lbPOE);
            this.panel1.Controls.Add(this.lbPOm);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.lbHBCMajor);
            this.panel1.Controls.Add(this.lbHBC);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.lbRe);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.lbExp);
            this.panel1.Controls.Add(this.lbMajor);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.lbOO);
            this.panel1.Controls.Add(this.lbWS);
            this.panel1.Controls.Add(this.lbOE);
            this.panel1.Controls.Add(this.lbOM);
            this.panel1.Controls.Add(this.txtAmountFour);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtAmountThree);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtAmountTwo);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dtp);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.btnClear);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.txtAmountOne);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1231, 391);
            this.panel1.TabIndex = 0;
            // 
            // lbAllExpTotal
            // 
            this.lbAllExpTotal.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbAllExpTotal.AutoSize = true;
            this.lbAllExpTotal.Location = new System.Drawing.Point(799, 288);
            this.lbAllExpTotal.Name = "lbAllExpTotal";
            this.lbAllExpTotal.Size = new System.Drawing.Size(18, 20);
            this.lbAllExpTotal.TabIndex = 57;
            this.lbAllExpTotal.Text = "0";
            // 
            // lbHbcExpTotal
            // 
            this.lbHbcExpTotal.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbHbcExpTotal.AutoSize = true;
            this.lbHbcExpTotal.Location = new System.Drawing.Point(799, 236);
            this.lbHbcExpTotal.Name = "lbHbcExpTotal";
            this.lbHbcExpTotal.Size = new System.Drawing.Size(18, 20);
            this.lbHbcExpTotal.TabIndex = 56;
            this.lbHbcExpTotal.Text = "0";
            // 
            // lbOEExpTotal
            // 
            this.lbOEExpTotal.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbOEExpTotal.AutoSize = true;
            this.lbOEExpTotal.Location = new System.Drawing.Point(799, 191);
            this.lbOEExpTotal.Name = "lbOEExpTotal";
            this.lbOEExpTotal.Size = new System.Drawing.Size(18, 20);
            this.lbOEExpTotal.TabIndex = 55;
            this.lbOEExpTotal.Text = "0";
            // 
            // lbWSexpTotal
            // 
            this.lbWSexpTotal.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbWSexpTotal.AutoSize = true;
            this.lbWSexpTotal.Location = new System.Drawing.Point(799, 152);
            this.lbWSexpTotal.Name = "lbWSexpTotal";
            this.lbWSexpTotal.Size = new System.Drawing.Size(18, 20);
            this.lbWSexpTotal.TabIndex = 54;
            this.lbWSexpTotal.Text = "0";
            // 
            // lbOOExpTotal
            // 
            this.lbOOExpTotal.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbOOExpTotal.AutoSize = true;
            this.lbOOExpTotal.Location = new System.Drawing.Point(799, 111);
            this.lbOOExpTotal.Name = "lbOOExpTotal";
            this.lbOOExpTotal.Size = new System.Drawing.Size(18, 20);
            this.lbOOExpTotal.TabIndex = 53;
            this.lbOOExpTotal.Text = "0";
            // 
            // lbOmExpTotal
            // 
            this.lbOmExpTotal.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbOmExpTotal.AutoSize = true;
            this.lbOmExpTotal.Location = new System.Drawing.Point(799, 73);
            this.lbOmExpTotal.Name = "lbOmExpTotal";
            this.lbOmExpTotal.Size = new System.Drawing.Size(18, 20);
            this.lbOmExpTotal.TabIndex = 52;
            this.lbOmExpTotal.Text = "0";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(799, 45);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 20);
            this.label7.TabIndex = 51;
            this.label7.Text = "Sub Total";
            // 
            // label15
            // 
            this.label15.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(923, 288);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(18, 20);
            this.label15.TabIndex = 50;
            this.label15.Text = "=";
            // 
            // lbExpTotal
            // 
            this.lbExpTotal.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbExpTotal.AutoSize = true;
            this.lbExpTotal.Location = new System.Drawing.Point(952, 288);
            this.lbExpTotal.Name = "lbExpTotal";
            this.lbExpTotal.Size = new System.Drawing.Size(18, 20);
            this.lbExpTotal.TabIndex = 49;
            this.lbExpTotal.Text = "0";
            // 
            // label14
            // 
            this.label14.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(952, 45);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(73, 20);
            this.label14.TabIndex = 48;
            this.label14.Text = "Net Total";
            // 
            // lbExpHBC
            // 
            this.lbExpHBC.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbExpHBC.AutoSize = true;
            this.lbExpHBC.Location = new System.Drawing.Point(952, 236);
            this.lbExpHBC.Name = "lbExpHBC";
            this.lbExpHBC.Size = new System.Drawing.Size(18, 20);
            this.lbExpHBC.TabIndex = 47;
            this.lbExpHBC.Text = "0";
            // 
            // lbExpOO
            // 
            this.lbExpOO.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbExpOO.AutoSize = true;
            this.lbExpOO.Location = new System.Drawing.Point(952, 111);
            this.lbExpOO.Name = "lbExpOO";
            this.lbExpOO.Size = new System.Drawing.Size(18, 20);
            this.lbExpOO.TabIndex = 46;
            this.lbExpOO.Text = "0";
            // 
            // lbExpWS
            // 
            this.lbExpWS.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbExpWS.AutoSize = true;
            this.lbExpWS.Location = new System.Drawing.Point(952, 149);
            this.lbExpWS.Name = "lbExpWS";
            this.lbExpWS.Size = new System.Drawing.Size(18, 20);
            this.lbExpWS.TabIndex = 45;
            this.lbExpWS.Text = "0";
            // 
            // lbExpOE
            // 
            this.lbExpOE.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbExpOE.AutoSize = true;
            this.lbExpOE.Location = new System.Drawing.Point(952, 191);
            this.lbExpOE.Name = "lbExpOE";
            this.lbExpOE.Size = new System.Drawing.Size(18, 20);
            this.lbExpOE.TabIndex = 44;
            this.lbExpOE.Text = "0";
            // 
            // lbExpOm
            // 
            this.lbExpOm.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbExpOm.AutoSize = true;
            this.lbExpOm.Location = new System.Drawing.Point(952, 73);
            this.lbExpOm.Name = "lbExpOm";
            this.lbExpOm.Size = new System.Drawing.Size(18, 20);
            this.lbExpOm.TabIndex = 43;
            this.lbExpOm.Text = "0";
            // 
            // totalP
            // 
            this.totalP.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.totalP.AutoSize = true;
            this.totalP.Location = new System.Drawing.Point(624, 288);
            this.totalP.Name = "totalP";
            this.totalP.Size = new System.Drawing.Size(18, 20);
            this.totalP.TabIndex = 41;
            this.totalP.Text = "0";
            // 
            // label13
            // 
            this.label13.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(624, 45);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(82, 20);
            this.label13.TabIndex = 40;
            this.label13.Text = "% Sharing";
            // 
            // lbPHBC
            // 
            this.lbPHBC.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbPHBC.AutoSize = true;
            this.lbPHBC.Location = new System.Drawing.Point(624, 236);
            this.lbPHBC.Name = "lbPHBC";
            this.lbPHBC.Size = new System.Drawing.Size(18, 20);
            this.lbPHBC.TabIndex = 39;
            this.lbPHBC.Text = "0";
            // 
            // lbPOO
            // 
            this.lbPOO.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbPOO.AutoSize = true;
            this.lbPOO.Location = new System.Drawing.Point(624, 111);
            this.lbPOO.Name = "lbPOO";
            this.lbPOO.Size = new System.Drawing.Size(18, 20);
            this.lbPOO.TabIndex = 38;
            this.lbPOO.Text = "0";
            // 
            // lbPWS
            // 
            this.lbPWS.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbPWS.AutoSize = true;
            this.lbPWS.Location = new System.Drawing.Point(624, 149);
            this.lbPWS.Name = "lbPWS";
            this.lbPWS.Size = new System.Drawing.Size(18, 20);
            this.lbPWS.TabIndex = 37;
            this.lbPWS.Text = "0";
            // 
            // lbPOE
            // 
            this.lbPOE.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbPOE.AutoSize = true;
            this.lbPOE.Location = new System.Drawing.Point(624, 191);
            this.lbPOE.Name = "lbPOE";
            this.lbPOE.Size = new System.Drawing.Size(18, 20);
            this.lbPOE.TabIndex = 36;
            this.lbPOE.Text = "0";
            // 
            // lbPOm
            // 
            this.lbPOm.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbPOm.AutoSize = true;
            this.lbPOm.Location = new System.Drawing.Point(624, 73);
            this.lbPOm.Name = "lbPOm";
            this.lbPOm.Size = new System.Drawing.Size(18, 20);
            this.lbPOm.TabIndex = 35;
            this.lbPOm.Text = "0";
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(188, 45);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(116, 20);
            this.label12.TabIndex = 34;
            this.label12.Text = "Major Amounts";
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(444, 45);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(119, 20);
            this.label11.TabIndex = 33;
            this.label11.Text = "Salary/Expense";
            // 
            // lbHBCMajor
            // 
            this.lbHBCMajor.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbHBCMajor.AutoSize = true;
            this.lbHBCMajor.Location = new System.Drawing.Point(188, 236);
            this.lbHBCMajor.Name = "lbHBCMajor";
            this.lbHBCMajor.Size = new System.Drawing.Size(18, 20);
            this.lbHBCMajor.TabIndex = 32;
            this.lbHBCMajor.Text = "0";
            // 
            // lbHBC
            // 
            this.lbHBC.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbHBC.AutoSize = true;
            this.lbHBC.Location = new System.Drawing.Point(444, 236);
            this.lbHBC.Name = "lbHBC";
            this.lbHBC.Size = new System.Drawing.Size(18, 20);
            this.lbHBC.TabIndex = 31;
            this.lbHBC.Text = "0";
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(133, 238);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 20);
            this.label8.TabIndex = 30;
            this.label8.Text = "HBC";
            // 
            // lbRe
            // 
            this.lbRe.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbRe.AutoSize = true;
            this.lbRe.Location = new System.Drawing.Point(992, 347);
            this.lbRe.Name = "lbRe";
            this.lbRe.Size = new System.Drawing.Size(18, 20);
            this.lbRe.TabIndex = 29;
            this.lbRe.Text = "0";
            this.lbRe.Visible = false;
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(962, 347);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(18, 20);
            this.label10.TabIndex = 28;
            this.label10.Text = "=";
            this.label10.Visible = false;
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(313, 288);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(14, 20);
            this.label9.TabIndex = 27;
            this.label9.Text = "-";
            // 
            // lbExp
            // 
            this.lbExp.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbExp.AutoSize = true;
            this.lbExp.Location = new System.Drawing.Point(444, 288);
            this.lbExp.Name = "lbExp";
            this.lbExp.Size = new System.Drawing.Size(18, 20);
            this.lbExp.TabIndex = 26;
            this.lbExp.Text = "0";
            // 
            // lbMajor
            // 
            this.lbMajor.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbMajor.AutoSize = true;
            this.lbMajor.Location = new System.Drawing.Point(188, 288);
            this.lbMajor.Name = "lbMajor";
            this.lbMajor.Size = new System.Drawing.Size(18, 20);
            this.lbMajor.TabIndex = 25;
            this.lbMajor.Text = "0";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(179, 263);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(621, 20);
            this.label6.TabIndex = 24;
            this.label6.Text = "____________________________________________________________________";
            // 
            // lbOO
            // 
            this.lbOO.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbOO.AutoSize = true;
            this.lbOO.Location = new System.Drawing.Point(444, 111);
            this.lbOO.Name = "lbOO";
            this.lbOO.Size = new System.Drawing.Size(18, 20);
            this.lbOO.TabIndex = 23;
            this.lbOO.Text = "0";
            // 
            // lbWS
            // 
            this.lbWS.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbWS.AutoSize = true;
            this.lbWS.Location = new System.Drawing.Point(444, 149);
            this.lbWS.Name = "lbWS";
            this.lbWS.Size = new System.Drawing.Size(18, 20);
            this.lbWS.TabIndex = 22;
            this.lbWS.Text = "0";
            // 
            // lbOE
            // 
            this.lbOE.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbOE.AutoSize = true;
            this.lbOE.Location = new System.Drawing.Point(444, 191);
            this.lbOE.Name = "lbOE";
            this.lbOE.Size = new System.Drawing.Size(18, 20);
            this.lbOE.TabIndex = 21;
            this.lbOE.Text = "0";
            // 
            // lbOM
            // 
            this.lbOM.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbOM.AutoSize = true;
            this.lbOM.Location = new System.Drawing.Point(444, 73);
            this.lbOM.Name = "lbOM";
            this.lbOM.Size = new System.Drawing.Size(18, 20);
            this.lbOM.TabIndex = 20;
            this.lbOM.Text = "0";
            // 
            // txtAmountFour
            // 
            this.txtAmountFour.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtAmountFour.Location = new System.Drawing.Point(190, 109);
            this.txtAmountFour.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtAmountFour.Maximum = new decimal(new int[] {
            1316134912,
            2328,
            0,
            0});
            this.txtAmountFour.Name = "txtAmountFour";
            this.txtAmountFour.Size = new System.Drawing.Size(247, 26);
            this.txtAmountFour.TabIndex = 2;
            this.txtAmountFour.ValueChanged += new System.EventHandler(this.txtAmountFour_ValueChanged);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(133, 112);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(18, 20);
            this.label4.TabIndex = 19;
            this.label4.Text = "2";
            // 
            // txtAmountThree
            // 
            this.txtAmountThree.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtAmountThree.Location = new System.Drawing.Point(190, 147);
            this.txtAmountThree.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtAmountThree.Maximum = new decimal(new int[] {
            1316134912,
            2328,
            0,
            0});
            this.txtAmountThree.Name = "txtAmountThree";
            this.txtAmountThree.Size = new System.Drawing.Size(247, 26);
            this.txtAmountThree.TabIndex = 3;
            this.txtAmountThree.ValueChanged += new System.EventHandler(this.txtAmountThree_ValueChanged);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(133, 148);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(18, 20);
            this.label2.TabIndex = 17;
            this.label2.Text = "3";
            // 
            // txtAmountTwo
            // 
            this.txtAmountTwo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtAmountTwo.Location = new System.Drawing.Point(190, 189);
            this.txtAmountTwo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtAmountTwo.Maximum = new decimal(new int[] {
            1316134912,
            2328,
            0,
            0});
            this.txtAmountTwo.Name = "txtAmountTwo";
            this.txtAmountTwo.Size = new System.Drawing.Size(247, 26);
            this.txtAmountTwo.TabIndex = 4;
            this.txtAmountTwo.ValueChanged += new System.EventHandler(this.txtAmountTwo_ValueChanged);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(133, 192);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 20);
            this.label1.TabIndex = 15;
            this.label1.Text = "4";
            // 
            // dtp
            // 
            this.dtp.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dtp.CustomFormat = "dd/MMM/yyyy";
            this.dtp.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp.Location = new System.Drawing.Point(190, 12);
            this.dtp.Name = "dtp";
            this.dtp.Size = new System.Drawing.Size(398, 26);
            this.dtp.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(134, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 20);
            this.label5.TabIndex = 13;
            this.label5.Text = "Date";
            // 
            // btnClear
            // 
            this.btnClear.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnClear.Location = new System.Drawing.Point(476, 316);
            this.btnClear.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(112, 36);
            this.btnClear.TabIndex = 6;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnSave.Location = new System.Drawing.Point(355, 316);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(112, 36);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtAmountOne
            // 
            this.txtAmountOne.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtAmountOne.Location = new System.Drawing.Point(190, 72);
            this.txtAmountOne.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtAmountOne.Maximum = new decimal(new int[] {
            1316134912,
            2328,
            0,
            0});
            this.txtAmountOne.Name = "txtAmountOne";
            this.txtAmountOne.Size = new System.Drawing.Size(247, 26);
            this.txtAmountOne.TabIndex = 1;
            this.txtAmountOne.ValueChanged += new System.EventHandler(this.txtAmountOne_ValueChanged);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(133, 72);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(18, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "1";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgv);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 391);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1231, 208);
            this.panel2.TabIndex = 1;
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AutoGenerateColumns = false;
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idShow,
            this.dateDataGridViewTextBoxColumn,
            this.amountOneDataGridViewTextBoxColumn,
            this.AmountFour,
            this.AmountThree,
            this.amountTwoDataGridViewTextBoxColumn,
            this.Edit,
            this.Delete});
            this.dgv.DataSource = this.profitSharingBindingSource;
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.Location = new System.Drawing.Point(0, 0);
            this.dgv.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersVisible = false;
            this.dgv.RowTemplate.Height = 24;
            this.dgv.Size = new System.Drawing.Size(1231, 208);
            this.dgv.TabIndex = 0;
            this.dgv.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellContentClick);
            // 
            // idShow
            // 
            this.idShow.DataPropertyName = "Id";
            this.idShow.HeaderText = "Id";
            this.idShow.Name = "idShow";
            this.idShow.ReadOnly = true;
            this.idShow.Visible = false;
            // 
            // dateDataGridViewTextBoxColumn
            // 
            this.dateDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dateDataGridViewTextBoxColumn.DataPropertyName = "Date";
            dataGridViewCellStyle1.Format = "dd/MMM/yyyy";
            this.dateDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.dateDataGridViewTextBoxColumn.HeaderText = "Date";
            this.dateDataGridViewTextBoxColumn.Name = "dateDataGridViewTextBoxColumn";
            this.dateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // amountOneDataGridViewTextBoxColumn
            // 
            this.amountOneDataGridViewTextBoxColumn.DataPropertyName = "AmountOne";
            this.amountOneDataGridViewTextBoxColumn.HeaderText = "Office Master";
            this.amountOneDataGridViewTextBoxColumn.Name = "amountOneDataGridViewTextBoxColumn";
            this.amountOneDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // AmountFour
            // 
            this.AmountFour.DataPropertyName = "AmountFour";
            this.AmountFour.HeaderText = "Office And Office";
            this.AmountFour.Name = "AmountFour";
            this.AmountFour.ReadOnly = true;
            // 
            // AmountThree
            // 
            this.AmountThree.DataPropertyName = "AmountThree";
            this.AmountThree.HeaderText = "World Style";
            this.AmountThree.Name = "AmountThree";
            this.AmountThree.ReadOnly = true;
            // 
            // amountTwoDataGridViewTextBoxColumn
            // 
            this.amountTwoDataGridViewTextBoxColumn.DataPropertyName = "AmountTwo";
            this.amountTwoDataGridViewTextBoxColumn.HeaderText = "Office Empire";
            this.amountTwoDataGridViewTextBoxColumn.Name = "amountTwoDataGridViewTextBoxColumn";
            this.amountTwoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // Edit
            // 
            this.Edit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Edit.HeaderText = "Edit";
            this.Edit.Name = "Edit";
            this.Edit.ReadOnly = true;
            this.Edit.Text = "Edit";
            this.Edit.ToolTipText = "Edit";
            this.Edit.UseColumnTextForButtonValue = true;
            this.Edit.Width = 50;
            // 
            // Delete
            // 
            this.Delete.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Delete.HeaderText = "Delete";
            this.Delete.Name = "Delete";
            this.Delete.ReadOnly = true;
            this.Delete.Text = "Delete";
            this.Delete.ToolTipText = "Delete";
            this.Delete.UseColumnTextForButtonValue = true;
            this.Delete.Visible = false;
            this.Delete.Width = 80;
            // 
            // profitSharingBindingSource
            // 
            this.profitSharingBindingSource.DataMember = "ProfitSharing";
            this.profitSharingBindingSource.DataSource = this.dsProfitMargin1;
            // 
            // dsProfitMargin1
            // 
            this.dsProfitMargin1.DataSetName = "dsProfitMargin";
            this.dsProfitMargin1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // daProfitMargin
            // 
            this.daProfitMargin.DeleteCommand = this.sqlDeleteCommand;
            this.daProfitMargin.InsertCommand = this.sqlInsertCommand;
            this.daProfitMargin.SelectCommand = this.sqlSelectCommand1;
            this.daProfitMargin.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ProfitSharing", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("Id", "Id"),
                        new System.Data.Common.DataColumnMapping("AmountOne", "AmountOne"),
                        new System.Data.Common.DataColumnMapping("AmountTwo", "AmountTwo"),
                        new System.Data.Common.DataColumnMapping("Date", "Date"),
                        new System.Data.Common.DataColumnMapping("AmountThree", "AmountThree"),
                        new System.Data.Common.DataColumnMapping("AmountFour", "AmountFour")})});
            this.daProfitMargin.UpdateCommand = this.sqlUpdateCommand;
            // 
            // sqlDeleteCommand
            // 
            this.sqlDeleteCommand.CommandText = resources.GetString("sqlDeleteCommand.CommandText");
            this.sqlDeleteCommand.Connection = this.sqlConnection1;
            this.sqlDeleteCommand.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@Original_Id", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Id", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_AmountOne", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "AmountOne", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_AmountOne", System.Data.SqlDbType.Decimal, 0, System.Data.ParameterDirection.Input, false, ((byte)(18)), ((byte)(2)), "AmountOne", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_AmountTwo", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "AmountTwo", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_AmountTwo", System.Data.SqlDbType.Decimal, 0, System.Data.ParameterDirection.Input, false, ((byte)(18)), ((byte)(0)), "AmountTwo", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_Date", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Date", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_Date", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Date", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_AmountThree", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "AmountThree", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_AmountThree", System.Data.SqlDbType.Decimal, 0, System.Data.ParameterDirection.Input, false, ((byte)(18)), ((byte)(2)), "AmountThree", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_AmountFour", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "AmountFour", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_AmountFour", System.Data.SqlDbType.Decimal, 0, System.Data.ParameterDirection.Input, false, ((byte)(18)), ((byte)(2)), "AmountFour", System.Data.DataRowVersion.Original, null)});
            // 
            // sqlConnection1
            // 
            this.sqlConnection1.ConnectionString = "Data Source=(local);Initial Catalog=InventoryServer;Persist Security Info=True;In" +
    "tegrated Security=True";
            this.sqlConnection1.FireInfoMessageEventOnUserErrors = false;
            // 
            // sqlInsertCommand
            // 
            this.sqlInsertCommand.CommandText = resources.GetString("sqlInsertCommand.CommandText");
            this.sqlInsertCommand.Connection = this.sqlConnection1;
            this.sqlInsertCommand.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@AmountOne", System.Data.SqlDbType.Decimal, 0, System.Data.ParameterDirection.Input, false, ((byte)(18)), ((byte)(2)), "AmountOne", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@AmountTwo", System.Data.SqlDbType.Decimal, 0, System.Data.ParameterDirection.Input, false, ((byte)(18)), ((byte)(0)), "AmountTwo", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@Date", System.Data.SqlDbType.DateTime, 0, "Date"),
            new System.Data.SqlClient.SqlParameter("@AmountThree", System.Data.SqlDbType.Decimal, 0, System.Data.ParameterDirection.Input, false, ((byte)(18)), ((byte)(2)), "AmountThree", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@AmountFour", System.Data.SqlDbType.Decimal, 0, System.Data.ParameterDirection.Input, false, ((byte)(18)), ((byte)(2)), "AmountFour", System.Data.DataRowVersion.Current, null)});
            // 
            // sqlSelectCommand1
            // 
            this.sqlSelectCommand1.CommandText = "SELECT Id, AmountOne, AmountTwo, Date, AmountThree, AmountFour\r\nFROM     ProfitSh" +
    "aring\r\nORDER BY Id DESC";
            this.sqlSelectCommand1.Connection = this.sqlConnection1;
            // 
            // sqlUpdateCommand
            // 
            this.sqlUpdateCommand.CommandText = resources.GetString("sqlUpdateCommand.CommandText");
            this.sqlUpdateCommand.Connection = this.sqlConnection1;
            this.sqlUpdateCommand.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@AmountOne", System.Data.SqlDbType.Decimal, 0, System.Data.ParameterDirection.Input, false, ((byte)(18)), ((byte)(2)), "AmountOne", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@AmountTwo", System.Data.SqlDbType.Decimal, 0, System.Data.ParameterDirection.Input, false, ((byte)(18)), ((byte)(0)), "AmountTwo", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@Date", System.Data.SqlDbType.DateTime, 0, "Date"),
            new System.Data.SqlClient.SqlParameter("@AmountThree", System.Data.SqlDbType.Decimal, 0, System.Data.ParameterDirection.Input, false, ((byte)(18)), ((byte)(2)), "AmountThree", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@AmountFour", System.Data.SqlDbType.Decimal, 0, System.Data.ParameterDirection.Input, false, ((byte)(18)), ((byte)(2)), "AmountFour", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@Original_Id", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Id", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_AmountOne", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "AmountOne", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_AmountOne", System.Data.SqlDbType.Decimal, 0, System.Data.ParameterDirection.Input, false, ((byte)(18)), ((byte)(2)), "AmountOne", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_AmountTwo", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "AmountTwo", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_AmountTwo", System.Data.SqlDbType.Decimal, 0, System.Data.ParameterDirection.Input, false, ((byte)(18)), ((byte)(0)), "AmountTwo", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_Date", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Date", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_Date", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Date", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_AmountThree", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "AmountThree", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_AmountThree", System.Data.SqlDbType.Decimal, 0, System.Data.ParameterDirection.Input, false, ((byte)(18)), ((byte)(2)), "AmountThree", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_AmountFour", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "AmountFour", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_AmountFour", System.Data.SqlDbType.Decimal, 0, System.Data.ParameterDirection.Input, false, ((byte)(18)), ((byte)(2)), "AmountFour", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Id", System.Data.SqlDbType.Int, 4, "Id")});
            // 
            // frmProfitMargin
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1231, 599);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmProfitMargin";
            this.Text = "Margins Of Branches";
            this.Load += new System.EventHandler(this.frmEmployee_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtAmountFour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAmountThree)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAmountTwo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAmountOne)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.profitSharingBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsProfitMargin1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.NumericUpDown txtAmountOne;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridView dgv;
        private System.Data.SqlClient.SqlDataAdapter daProfitMargin;
        private System.Data.SqlClient.SqlCommand sqlSelectCommand1;
        private System.Windows.Forms.DateTimePicker dtp;
        private System.Windows.Forms.Label label5;
        private System.Data.SqlClient.SqlCommand sqlDeleteCommand;
        private System.Data.SqlClient.SqlCommand sqlInsertCommand;
        private System.Data.SqlClient.SqlCommand sqlUpdateCommand;
        private System.Windows.Forms.NumericUpDown txtAmountTwo;
        private System.Windows.Forms.Label label1;
        private System.Data.SqlClient.SqlConnection sqlConnection1;
        private dsProfitMargin dsProfitMargin1;
        private System.Windows.Forms.BindingSource profitSharingBindingSource;
        private System.Windows.Forms.NumericUpDown txtAmountFour;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown txtAmountThree;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbOO;
        private System.Windows.Forms.Label lbWS;
        private System.Windows.Forms.Label lbOE;
        private System.Windows.Forms.Label lbOM;
        private System.Windows.Forms.Label lbRe;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lbExp;
        private System.Windows.Forms.Label lbMajor;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbHBC;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lbHBCMajor;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DataGridViewTextBoxColumn idShow;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn amountOneDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn AmountFour;
        private System.Windows.Forms.DataGridViewTextBoxColumn AmountThree;
        private System.Windows.Forms.DataGridViewTextBoxColumn amountTwoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewButtonColumn Edit;
        private System.Windows.Forms.DataGridViewButtonColumn Delete;
        private System.Windows.Forms.Label totalP;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lbPHBC;
        private System.Windows.Forms.Label lbPOO;
        private System.Windows.Forms.Label lbPWS;
        private System.Windows.Forms.Label lbPOE;
        private System.Windows.Forms.Label lbPOm;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lbExpTotal;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lbExpHBC;
        private System.Windows.Forms.Label lbExpOO;
        private System.Windows.Forms.Label lbExpWS;
        private System.Windows.Forms.Label lbExpOE;
        private System.Windows.Forms.Label lbExpOm;
        private System.Windows.Forms.Label lbAllExpTotal;
        private System.Windows.Forms.Label lbHbcExpTotal;
        private System.Windows.Forms.Label lbOEExpTotal;
        private System.Windows.Forms.Label lbWSexpTotal;
        private System.Windows.Forms.Label lbOOExpTotal;
        private System.Windows.Forms.Label lbOmExpTotal;
        private System.Windows.Forms.Label label7;
    }
}