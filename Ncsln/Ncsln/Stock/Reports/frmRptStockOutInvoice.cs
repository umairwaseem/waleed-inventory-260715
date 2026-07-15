using Ncsln.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Ncsln.Stock.Reports
{
    public partial class frmRptStockOutInvoice : Form
    {
        CoreClass ObjCore;
        public string Id;
        public frmRptStockOutInvoice()
        {
            InitializeComponent();
            this.ObjCore = new CoreClass();
        }

        private void frmRptStockOutInvoice_Load(object sender, EventArgs e)
        {
            try
            {
                this.dsStockOutInvoice1.Clear();
                this.dsStockOutInvoice1.EnforceConstraints = false;
                this.daStockOutInvoice.SelectCommand.Connection.ConnectionString = this.ObjCore.getConnectionString();
                this.daStockOutInvoice.SelectCommand.Parameters["@Id"].Value = this.Id;
                this.daStockOutInvoice.Fill(this.dsStockOutInvoice1);

                docStockOutInvoice rpt = new docStockOutInvoice();
                rpt.SetDataSource(this.dsStockOutInvoice1);
                this.crv.ReportSource = rpt;
            }
            catch (Exception ex)
            {

                
            }
        }
    }
}
