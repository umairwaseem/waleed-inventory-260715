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
    public partial class frmRptNegative : Form
    {

        CoreClass objCore;

        public frmRptNegative()
        {
            InitializeComponent();
            this.objCore = new CoreClass();
        }

        private void frmRptPurchaseDetail_Load(object sender, EventArgs e)
        {

        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                this.dsItemNegativeStock1.Clear();
                this.daItemNegativeStock.SelectCommand.CommandTimeout = 180;
                this.daItemNegativeStock.SelectCommand.Connection.ConnectionString = this.objCore.getClientConnectionString();
                //this.daItemNegativeStock.SelectCommand.Parameters["@date"].Value = this.dtpFrom.Value.ToShortDateString();
                this.daItemNegativeStock.Fill(this.dsItemNegativeStock1);

                //docTrend rpt = new docTrend();
                //rpt.SetDataSource(this.dsItemTrend1);
                //this.crv.ReportSource = rpt;
            }
            catch (Exception ex)
            {

            }
            finally
            {
                this.Cursor = Cursors.Default;
            }

        }
    }
}
