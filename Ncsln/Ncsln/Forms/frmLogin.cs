using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Data.SqlClient;
//using CrystalDecisions;
using System.Data;
using System.IO;
using System.Xml;
using Ncsln.Classes;

namespace Ncsln.Forms
{
    public partial class frmLogin : Form
    {
        private string DBName;

        public bool Relogin { get; set; }
        public bool ReLoginSuccess { get; set; }

        public frmLogin()
        {
            InitializeComponent();
            this.Relogin = false;
            this.ReLoginSuccess = false;
        }

        private void onEnterTextBox(Object sender, EventArgs e)
        {
            TextBox txtBox = sender as TextBox;
            txtBox.BackColor = Color.GhostWhite;
        }

        private void onLeaveTextBox(Object sender, EventArgs e)
        {
            TextBox txtBox = (TextBox)sender;
            txtBox.BackColor = Color.White;
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            txtPass.Enabled = !chkIS.Checked;
            txtUser.Enabled = !chkIS.Checked;
        }

     
        private void btnLogin_Click(object sender, EventArgs e)
        {
            this.login();
        }
        //This function checks the user identity, password and allows or disallows him/her to log in
        private void login()
        {
            try
            {
                Classes.CoreClass objCore = new Classes.CoreClass();
                if (this.txtuserid.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Please enter User Id.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.txtuserid.Focus();
                    return;
                }
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
                    ConString = objCore.getConnectionString();
                }
                else
                {
                    ConString = objCore.getClientConnectionString();
                }
                SqlDataReader dr = objCore.getDataReader("Select * from AISYS where UserLoginId = '" + this.txtuserid.Text.Trim() + "'", ConString);
                if (dr.HasRows)
                {
                    dr.Read();
                    if(!Convert.ToBoolean(dr["Active"]))
                    {
                        dr.Close();
                        objCore.closeConnection();
                        MessageBox.Show("This user is currently In-active.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }

                    if (dr["UserPassword"].ToString().Trim() != this.txtPassword.Text.Trim())
                    {
                        dr.Close();
                        objCore.closeConnection();
                        this.txtPassword.Clear();
                        MessageBox.Show("Incorrect Password.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    } else
                    {
                        this.ReLoginSuccess = true;
                    }

                    userId = dr["UserId"].ToString();
                    UserName = dr["UserName"].ToString();
                }
                else
                {
                    dr.Close();
                    objCore.closeConnection();
                    MessageBox.Show("User not found.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                Ncsln.Properties.Settings.Default.user = userId;
                Ncsln.Properties.Settings.Default.UserName = UserName;
                Ncsln.Properties.Settings.Default.Save();

                objCore.RecoardLogs("Login User", "Login");

                if (!this.Relogin)
                {                 
                    frmCenter obj = new frmCenter();
                    obj.Show();
                    this.Hide();
                }
                else
                {
                    if (this.ReLoginSuccess)
                    {
                        this.Close();    
                    }                    
                }

                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }               
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            try
            {
                if (this.Relogin)
                {
                    this.tabControl1.TabPages.Remove(tabServer);
                }
                

                if (SetupType.SoftType == SoftwareType.Master)
                {
                    this.txtuserid.UseSystemPasswordChar = true;
                }

                this.txtuserid.Focus();

                if (SetupType.SoftType == SoftwareType.Master)
                {
                    this.DBName = "waleedinventoryServer";
                }
                else if (SetupType.SoftType == SoftwareType.OfficeEmpire)
                {
                    this.DBName = "waleedinventory-one";
                }
                else if (SetupType.SoftType == SoftwareType.OfficeMaster)
                {
                    this.DBName = "waleedinventory-one";
                }
                else if (SetupType.SoftType == SoftwareType.OfficenOffice)
                {
                    this.DBName = "waleedinventory-two";
                }
                else if (SetupType.SoftType == SoftwareType.WorldStyle)
                {
                    this.DBName = "waleedinventory-one";
                }

                this.txtDB.Text = this.DBName;
            }
            catch
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.testConnection();
        }


        //Checks whether the connection with database with the given parameters is working or not
        private void testConnection()
        {
            try
            {
                string connection = string.Empty;
                if (this.chkIS.Checked)
                {
                    if (this.txtServerName.Text.Trim() == string.Empty)
                    {
                        MessageBox.Show("Please enter Server Name.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.txtServerName.Focus();
                        return;
                    }
                    if (this.txtDB.Text.Trim() == string.Empty)
                    {
                        MessageBox.Show("Please enter Database name.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.txtDB.Focus();
                        return;
                    }
                    connection = @"Data Source=" + this.txtServerName.Text.Trim() + ";Initial Catalog=" + this.txtDB.Text.Trim() + ";Integrated Security=True";
                }
                else
                {
                    if (this.txtServerName.Text.Trim() == string.Empty)
                    {
                        MessageBox.Show("Please enter Server Name.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.txtServerName.Focus();
                        return;
                    }
                    if (this.txtDB.Text.Trim() == string.Empty)
                    {
                        MessageBox.Show("Please enter Database name.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.txtDB.Focus();
                        return;
                    }
                    if (this.txtUser.Text.Trim() == string.Empty)
                    {

                        MessageBox.Show("Please enter Database Login.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.txtUser.Focus();
                        return;
                    }
                    if (this.txtPass.Text.Trim() == string.Empty)
                    {
                        MessageBox.Show("Please enter Database Login Password.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.txtPass.Focus();
                        return;
                    }
                    connection = @"Data Source=" + this.txtServerName.Text.Trim() + ";Initial Catalog=" + this.txtDB.Text.Trim() + ";User ID=" + this.txtUser.Text.Trim() + ";Password=" + this.txtPass.Text.Trim() + "";
                }
                SqlConnection con = new SqlConnection();
                con.ConnectionString = connection;
                con.Open();

                this.Cursor = Cursors.WaitCursor;
                con.Close();
                this.Cursor = Cursors.Arrow;
                Ncsln.Properties.Settings.Default.constring = connection;
                Ncsln.Properties.Settings.Default.Save();
                MessageBox.Show("Connection established successfully.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection could not be established.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
            }
        }



        private void frmLogin_KeyDown(object sender, KeyEventArgs e)
        {
            KeyEventArgs keyArgs = (KeyEventArgs)e;
            if (keyArgs.Control && keyArgs.Shift && keyArgs.KeyCode == Keys.K)
            {
                frmGetKey obj = new frmGetKey();
                obj.Show();
            }
        }
    }
}