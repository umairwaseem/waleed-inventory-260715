using System;
using System.Drawing;
using System.Windows.Forms;

namespace CControl
{
	/// <summary>
	/// Summary description for TextBox.
	/// </summary>
	public class NumericTextBox : TextBox
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public NumericTextBox()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitializeComponent call

		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			// 
			// TextBoxNumeric
			// 
			this.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.ForeColor = System.Drawing.Color.Black;
			this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxNumeric_KeyPress);
			this.TextChanged += new System.EventHandler(this.TextBoxNumeric_TextChanged);
			this.Leave += new System.EventHandler(this.TextBoxNumeric_Leave);
			this.Enter += new System.EventHandler(this.TextBoxNumeric_Enter);
            this.MouseClick += new MouseEventHandler(TextBoxNumeric_MouseClick);
			this.Text = "0";
		}
		#endregion

		private void TextBoxNumeric_Enter(object sender, System.EventArgs e)
		{
		
		}

		private void TextBoxNumeric_Leave(object sender, System.EventArgs e)
		{
		
		}

        private void TextBoxNumeric_MouseClick(object sender, MouseEventArgs e)
        {
          
        }

		private void TextBoxNumeric_TextChanged(object sender, System.EventArgs e)
		{
			
		}

		private void TextBoxNumeric_KeyPress(object sender, KeyPressEventArgs e)
		{
			
		
		}
	}	
		
}