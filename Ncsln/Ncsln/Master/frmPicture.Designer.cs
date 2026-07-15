namespace Ncsln.Master
{
    partial class frmPicture
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
            this.pBxPhoto = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pBxPhoto)).BeginInit();
            this.SuspendLayout();
            // 
            // pBxPhoto
            // 
            this.pBxPhoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pBxPhoto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pBxPhoto.Location = new System.Drawing.Point(0, 0);
            this.pBxPhoto.Name = "pBxPhoto";
            this.pBxPhoto.Size = new System.Drawing.Size(376, 379);
            this.pBxPhoto.TabIndex = 12;
            this.pBxPhoto.TabStop = false;
            // 
            // frmPicture
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(376, 379);
            this.Controls.Add(this.pBxPhoto);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmPicture";
            this.Text = "Photo";
            this.Load += new System.EventHandler(this.frmPicture_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pBxPhoto)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pBxPhoto;
    }
}