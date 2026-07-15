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
    public partial class frmRptStockInInvoice : Form
    {
        CoreClass ObjCore;
        public string Id;
        public frmRptStockInInvoice()
        {
            InitializeComponent();
            this.ObjCore = new CoreClass();
        }

        private void frmRptStockInInvoice_Load(object sender, EventArgs e)
        {
            try
            {
                this.dsStockInInvoice1.Clear();
                this.dsStockInInvoice1.EnforceConstraints = false;
                this.daStockInInvoice.SelectCommand.Connection.ConnectionString = this.ObjCore.getConnectionString();
                this.daStockInInvoice.SelectCommand.Parameters["@Id"].Value = this.Id;
                this.daStockInInvoice.Fill(this.dsStockInInvoice1);

                docStockInInvoice rpt = new docStockInInvoice();
                rpt.SetDataSource(this.dsStockInInvoice1);
                this.crv.ReportSource = rpt;
            }
            catch (Exception ex)
            {

            }
        }
    }
}
