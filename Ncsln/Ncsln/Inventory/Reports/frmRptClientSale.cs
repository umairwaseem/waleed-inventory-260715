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
    public partial class frmRptClientSale : Form
    {

        CoreClass objCore;

        public int ClientId { get; set; }

        public frmRptClientSale()
        {
            InitializeComponent();
            this.objCore = new CoreClass();
        }

        private void frmRptClientSale_Load(object sender, EventArgs e)
        {
            try
            {
                this.dsClientSale1.Clear();
                this.dsClientSale1.EnforceConstraints = false;
                this.daClientSale.SelectCommand.Connection.ConnectionString = this.objCore.getClientConnectionString();
                this.daClientSale.SelectCommand.Parameters["@ClientId"].Value = this.ClientId;
                this.daClientSale.Fill(this.dsClientSale1);

                docClientSale rpt = new docClientSale();
                rpt.SetDataSource(this.dsClientSale1);
                crv.ReportSource = rpt;
            }
            catch (Exception ex)
            {

            }
        }
    }
}
