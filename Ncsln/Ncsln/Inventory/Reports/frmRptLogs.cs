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
    public partial class frmRptLogs : Form
    {

        CoreClass objCore;

        public frmRptLogs()
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
                this.dsUserLogs.Clear();
                this.daUserLog.SelectCommand.Connection.ConnectionString = this.objCore.getClientConnectionString();
                //this.daItemNegativeStock.SelectCommand.Parameters["@date"].Value = this.dtpFrom.Value.ToShortDateString();
                this.daUserLog.Fill(this.dsUserLogs);

                //docTrend rpt = new docTrend();
                //rpt.SetDataSource(this.dsItemTrend1);
                //this.crv.ReportSource = rpt;
            }
            catch (Exception ex)
            {

            }

        }
    }
}
