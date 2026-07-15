using Ncsln.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Ncsln.Master
{
    public partial class frmRptPartnerPay : Form
    {
        CoreClass ObjCore;

        public frmRptPartnerPay()
        {
            InitializeComponent();
            this.ObjCore = new CoreClass();
        }

        private void frmRptPartnerPay_Load(object sender, EventArgs e)
        {
            try
            {
                this.ObjCore.fillComboBoxWithReports2(this.cmbPartner, "Select Id , Name From Partner", this.ObjCore.getHBCConnectionString());
            }
            catch (Exception ex)
            {

            }
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            try
            {
                this.dsPartnerHistory1.Clear();
                this.dsPartnerHistory1.EnforceConstraints = false;
                this.daPartnerHistory.SelectCommand.Connection.ConnectionString = this.ObjCore.getHBCConnectionString();
                this.daPartnerHistory.SelectCommand.Parameters["@Id"].Value = this.cmbPartner.SelectedValue.ToString();
                this.daPartnerHistory.Fill(this.dsPartnerHistory1);

                docPartnerHistory rpt = new docPartnerHistory();
                rpt.SetDataSource(this.dsPartnerHistory1);
                this.crv.ReportSource = rpt;
            }
            catch (Exception ex)
            {
                
            }
        }
    }
}
