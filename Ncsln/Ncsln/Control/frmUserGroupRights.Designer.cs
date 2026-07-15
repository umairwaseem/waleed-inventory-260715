namespace Ncsln.Control
{
    partial class frmUserGroupRights
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.plControl = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(582, 100);
            this.panel1.TabIndex = 0;
            // 
            // plControl
            // 
            this.plControl.AutoScroll = true;
            this.plControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plControl.Location = new System.Drawing.Point(0, 100);
            this.plControl.Name = "plControl";
            this.plControl.Size = new System.Drawing.Size(582, 436);
            this.plControl.TabIndex = 1;
            // 
            // frmUserGroupRights
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 536);
            this.Controls.Add(this.plControl);
            this.Controls.Add(this.panel1);
            this.Name = "frmUserGroupRights";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "User Group Rights";
            this.Load += new System.EventHandler(this.frmtest_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel plControl;



    }
}