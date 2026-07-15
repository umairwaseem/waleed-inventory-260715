using Ncsln.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Ncsln.Inventory.Reports
{
    public partial class frmRptPurchaseDetail : Form
    {

        CoreClass objCore;

        public frmRptPurchaseDetail()
        {
            InitializeComponent();
            this.objCore = new CoreClass();
        }

        private void frmRptPurchaseDetail_Load(object sender, EventArgs e)
        {

        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            try
            {
                this.dsDetailPurchase1.Clear();
                this.daDetailPurchase.SelectCommand.Connection.ConnectionString = this.objCore.getClientConnectionString();
                this.daDetailPurchase.SelectCommand.Parameters["@from"].Value = this.dtpFrom.Value.ToShortDateString();
                this.daDetailPurchase.SelectCommand.Parameters["@to"].Value = this.dtpTo.Value.ToShortDateString();
                this.daDetailPurchase.Fill(this.dsDetailPurchase1);

                docDetailPurchase rpt = new docDetailPurchase();
                rpt.SetDataSource(this.dsDetailPurchase1);
                rpt.SetParameterValue("MyCompanyName", this.objCore.getServerName());
                this.crv.ReportSource = rpt;
            }
            catch (Exception ex)
            {

            }

        }
    }
}
