using Ncsln.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Ncsln.Control
{
    public partial class frmBackup : Form
    {

        private CoreClass objCore;

        public frmBackup()
        {
            InitializeComponent();
            this.objCore = new CoreClass();
        }

        private void frmBackup_Load(object sender, EventArgs e)
        {

        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.txtPath.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Please select any path to take backup", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
                string command = "USE MASTER BACKUP DATABASE Inventory TO DISK = '" + this.txtPath.Text.ToString() + "'";
                this.objCore.executeQuery(command);

                MessageBox.Show("Backup successfully taken.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                FolderBrowserDialog fbd = new FolderBrowserDialog();
                if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string fileName = String.Format("{0:yyyyddMM}", DateTime.Now) + ".bak";
                    this.txtPath.Text = fbd.SelectedPath.ToString() + "\\" + fileName;
                }
            }
            catch (Exception ex)
            {


            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
