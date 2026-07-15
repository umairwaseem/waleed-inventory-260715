using Ncsln.Classes;
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
    public partial class frmSelectClient : Form
    {

        CoreClass ObjCore;
        public bool selected = false;
        frmDashboard dashboard;

        public frmSelectClient(frmDashboard _dashboard)
        {
            InitializeComponent();
            this.ObjCore = new CoreClass();
            this.dashboard = _dashboard;
        }

        private void frmSelectClient_Load(object sender, EventArgs e)
        {
            try
            {
                string Command = "Select Id, BranchName from Branches";
                this.ObjCore.fillComboBoxOptioni(this.cmbClients, Command);
            }
            catch (Exception ex)
            {

            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = MessageBox.Show("If you change the client the all the open windows will close. So, do you want to change the client", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == System.Windows.Forms.DialogResult.No) return;

                DataTable dt = this.ObjCore.getDataSet("Select * from Branches where Id = '" + this.cmbClients.SelectedValue.ToString() + "'").Tables[0];

                string ConString = dt.Rows[0]["ConnectionString"].ToString();
                //string ConString = dt.Rows[0]["LocalConnectionString"].ToString();
                string ConStringName = dt.Rows[0]["ConnectionName"].ToString();                
                string BranchName = dt.Rows[0]["BranchName"].ToString();
                string InvoiceCode = dt.Rows[0]["InvoiceCode"].ToString();
                string Id = this.cmbClients.SelectedValue.ToString();

                this.ObjCore.updateSettings(2, BranchName);
                this.ObjCore.updateSettings(3, InvoiceCode);
                this.ObjCore.updateSettings(4, Id);

                this.Cursor = Cursors.WaitCursor;
                bool ConStatus = this.ObjCore.ConnectionCheck(ConString);
                this.Cursor = Cursors.Default;

                if (!ConStatus)
                {
                    MessageBox.Show("The client is not available try again later!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                Ncsln.Properties.Settings.Default.ClientConString = ConString;
                Ncsln.Properties.Settings.Default.ClientConStringName = ConStringName;
                Ncsln.Properties.Settings.Default.ServerName = BranchName;
                Ncsln.Properties.Settings.Default.InvoiceCode = InvoiceCode;
                Ncsln.Properties.Settings.Default.BranchId = Id;
                //Ncsln.Properties.Settings.Default.Upgrade();
                Ncsln.Properties.Settings.Default.Save();
                this.selected = true;

                this.dashboard.SetValueZero();

                this.Close();
            }
            catch (Exception ex)
            {

            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.selected = false;
            this.Close();
        }
    }
}
