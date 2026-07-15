using Ncsln.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Ncsln.Forms
{
    public partial class frmSecurity : Form
    {
        private Classes.CoreClass ObjCore;
        public bool ReLoginSuccess { get; set; }

        public frmSecurity()
        {
            InitializeComponent();
            this.ObjCore = new Classes.CoreClass();
            this.ReLoginSuccess = false;
        }

        private void frmSecurity_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.login();
        }

        private void login()
        {
            try
            {   
                if (this.txtPassword.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Please enter User Password.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.txtPassword.Focus();
                    return;
                }

                string userId = string.Empty;
                string UserName = string.Empty;
                string ConString = string.Empty;
                if (SetupType.SoftType == SoftwareType.Master)
                {
                    ConString = this.ObjCore.getConnectionString();
                }
                else
                {
                    ConString = this.ObjCore.getClientConnectionString();
                }
                SqlDataReader dr = this.ObjCore.getDataReader("Select * from AISYS where UserPassword = '" + this.txtPassword.Text.Trim() + "'", ConString);
                if (dr.HasRows)
                {
                    dr.Read();
                    if (!Convert.ToBoolean(dr["Active"]))
                    {
                        dr.Close();
                        this.ObjCore.closeConnection();
                        MessageBox.Show("This user is currently In-active.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    else
                    {
                        this.ReLoginSuccess = true;
                    }

                    userId = dr["UserId"].ToString();
                    UserName = dr["UserName"].ToString();
                }
                else
                {
                    dr.Close();
                    this.ObjCore.closeConnection();
                    MessageBox.Show("User not found.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                Ncsln.Properties.Settings.Default.user = userId;
                Ncsln.Properties.Settings.Default.UserName = UserName;
                Ncsln.Properties.Settings.Default.Save();

                this.ObjCore.RecoardLogs("User Security login", "Security");

                if (this.ReLoginSuccess)
                {
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
