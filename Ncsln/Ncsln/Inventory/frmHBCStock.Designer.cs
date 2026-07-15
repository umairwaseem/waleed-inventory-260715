namespace Ncsln.Inventory
{
    partial class frmHBCStock
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
            this.label1 = new System.Windows.Forms.Label();
            this.cmbLocalItemList = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbHBCItems = new System.Windows.Forms.ComboBox();
            this.lbCurrentStock = new System.Windows.Forms.Label();
            this.txtQty = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.btnStock = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rbtnGetStock = new System.Windows.Forms.RadioButton();
            this.rbtnReverseStock = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.txtQty)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(196, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Items";
            // 
            // cmbLocalItemList
            // 
            this.cmbLocalItemList.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbLocalItemList.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbLocalItemList.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbLocalItemList.FormattingEnabled = true;
            this.cmbLocalItemList.Location = new System.Drawing.Point(196, 68);
            this.cmbLocalItemList.Name = "cmbLocalItemList";
            this.cmbLocalItemList.Size = new System.Drawing.Size(345, 33);
            this.cmbLocalItemList.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(196, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "HBC Items";
            // 
            // cmbHBCItems
            // 
            this.cmbHBCItems.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbHBCItems.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbHBCItems.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbHBCItems.FormattingEnabled = true;
            this.cmbHBCItems.Location = new System.Drawing.Point(196, 142);
            this.cmbHBCItems.Name = "cmbHBCItems";
            this.cmbHBCItems.Size = new System.Drawing.Size(345, 33);
            this.cmbHBCItems.TabIndex = 3;
            this.cmbHBCItems.SelectedIndexChanged += new System.EventHandler(this.cmbHBCItems_SelectedIndexChanged);
            this.cmbHBCItems.SelectionChangeCommitted += new System.EventHandler(this.cmbHBCItems_SelectionChangeCommitted);
            // 
            // lbCurrentStock
            // 
            this.lbCurrentStock.AutoSize = true;
            this.lbCurrentStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCurrentStock.Location = new System.Drawing.Point(547, 146);
            this.lbCurrentStock.Name = "lbCurrentStock";
            this.lbCurrentStock.Size = new System.Drawing.Size(23, 25);
            this.lbCurrentStock.TabIndex = 4;
            this.lbCurrentStock.Text = "0";
            // 
            // txtQty
            // 
            this.txtQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQty.Location = new System.Drawing.Point(196, 211);
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(345, 30);
            this.txtQty.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(196, 183);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 25);
            this.label3.TabIndex = 6;
            this.label3.Text = "QTY";
            // 
            // btnStock
            // 
            this.btnStock.Location = new System.Drawing.Point(466, 309);
            this.btnStock.Name = "btnStock";
            this.btnStock.Size = new System.Drawing.Size(75, 38);
            this.btnStock.TabIndex = 7;
            this.btnStock.Text = "Process";
            this.btnStock.UseVisualStyleBackColor = true;
            this.btnStock.Click += new System.EventHandler(this.btnStock_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel1.Controls.Add(this.label4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(747, 63);
            this.panel1.TabIndex = 8;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.rbtnReverseStock);
            this.panel2.Controls.Add(this.rbtnGetStock);
            this.panel2.Controls.Add(this.cmbLocalItemList);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.btnStock);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.cmbHBCItems);
            this.panel2.Controls.Add(this.txtQty);
            this.panel2.Controls.Add(this.lbCurrentStock);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 63);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(747, 406);
            this.panel2.TabIndex = 9;
            // 
            // rbtnGetStock
            // 
            this.rbtnGetStock.AutoSize = true;
            this.rbtnGetStock.Checked = true;
            this.rbtnGetStock.Location = new System.Drawing.Point(315, 256);
            this.rbtnGetStock.Name = "rbtnGetStock";
            this.rbtnGetStock.Size = new System.Drawing.Size(106, 21);
            this.rbtnGetStock.TabIndex = 8;
            this.rbtnGetStock.TabStop = true;
            this.rbtnGetStock.Text = "Get Stock In";
            this.rbtnGetStock.UseVisualStyleBackColor = true;
            // 
            // rbtnReverseStock
            // 
            this.rbtnReverseStock.AutoSize = true;
            this.rbtnReverseStock.Location = new System.Drawing.Point(431, 256);
            this.rbtnReverseStock.Name = "rbtnReverseStock";
            this.rbtnReverseStock.Size = new System.Drawing.Size(121, 21);
            this.rbtnReverseStock.TabIndex = 9;
            this.rbtnReverseStock.Text = "Reverse Stock";
            this.rbtnReverseStock.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(226, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(268, 29);
            this.label4.TabIndex = 0;
            this.label4.Text = "Get Stock From HBC";
            // 
            // frmHBCStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(747, 469);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "frmHBCStock";
            this.Text = "HBC Stock";
            this.Load += new System.EventHandler(this.frmHBCStock_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtQty)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbLocalItemList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbHBCItems;
        private System.Windows.Forms.Label lbCurrentStock;
        private System.Windows.Forms.NumericUpDown txtQty;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnStock;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton rbtnReverseStock;
        private System.Windows.Forms.RadioButton rbtnGetStock;
        private System.Windows.Forms.Label label4;
    }
}