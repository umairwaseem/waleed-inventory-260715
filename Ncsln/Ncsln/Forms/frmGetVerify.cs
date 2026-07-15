using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Ncsln.Forms
{
    public partial class frmGetVerify : Form
    {
        public frmGetVerify()
        {
            InitializeComponent();
        }

        private void frmGetVerify_Load(object sender, EventArgs e)
        {

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                string StrKey = this.txtKey.Text.Trim();
                bool One, Two, Three, Four;

                char[] sperator = { '-' };

                string[] AllKey = StrKey.Split(sperator);

                if (AllKey.Count() != 4)
                {
                    MessageBox.Show("Wrong Key try again", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // For the first
                One = this.FirstCheck(AllKey);

                // For the Second 
                Two = this.SecondCheck(AllKey);

                // For the Third
                Three = this.ThirdCheck(AllKey);

                // For the Fourth
                Four = this.FourthCheck(AllKey);


                if (One == true && Two == true && Three == true && Four == true)
                {
                    Ncsln.Properties.Settings.Default.AppKey = this.txtKey.Text.Trim();
                    Ncsln.Properties.Settings.Default.Save();
                    MessageBox.Show("Your key successfully verified", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Application.Exit();
                }
                else
                {
                    MessageBox.Show("Wrong Key try again", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                

            }
            catch (Exception ex)
            {

            }
        }

        private bool FirstCheck(string[] AllKey)
        {
            char[] FirstOne = AllKey[0].ToCharArray();
            bool KeyStatus = false;

            if (FirstOne[0].ToString() == "U")
            {
                KeyStatus = true;
            }
            else
            {
                return false;
            }

            if (FirstOne[1].ToString() == "W")
            {
                KeyStatus = true;
            }
            else
            {
                return false;
            }

            string YearYY = DateTime.Now.ToString("yy");

            if ((FirstOne[2].ToString() + FirstOne[3].ToString()) == YearYY)
            {
                KeyStatus = true;
            }
            else
            {
                return false;
            }

            return KeyStatus;
        }

        private bool SecondCheck(string[] AllKey)
        {
            char[] Second = AllKey[1].ToCharArray();
            string SecondMM = Second[2].ToString() + Second[3].ToString();
            if (SecondMM == DateTime.Now.ToString("MM"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool ThirdCheck(string[] AllKey)
        {
            char[] Third = AllKey[2].ToCharArray();
            string Thirddd = Third[0].ToString() + Third[1].ToString();
            if (Thirddd == DateTime.Now.ToString("dd"))
                return true;
            else
                return false;
        }

        private bool FourthCheck(string[] AllKey)
        {
            char[] Fourth = AllKey[3].ToCharArray();
            string Fourthdd = Fourth[2].ToString() + Fourth[3].ToString();
            if (Fourthdd == DateTime.Now.ToString("hh"))
                return true;
            else
                return false;
        }
    }
}
