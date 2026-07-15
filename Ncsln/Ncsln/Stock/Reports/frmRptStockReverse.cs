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
    public partial class frmRptStockReverse : Form
    {
        public string ids;
        CoreClass ObjCore;
        public frmRptStockReverse()
        {
            InitializeComponent();
            this.ObjCore = new CoreClass();
        }

        private void frmRptStockReverse_Load(object sender, EventArgs e)
        {
            try
            {
                this.dsStockReveseReport1.Clear();
                this.daStockReveseReport.SelectCommand.Connection.ConnectionString = this.ObjCore.getConnectionString();
                this.daStockReveseReport.SelectCommand.CommandText = "SELECT Id, ItemId, Title, Code, Qty, Date FROM     vHBCReverse where Id in (" + this.ids + ") ORDER BY Date";
                this.daStockReveseReport.Fill(this.dsStockReveseReport1);

                docStockReverse rpt = new docStockReverse();
                rpt.SetDataSource(this.dsStockReveseReport1);
                this.crv.ReportSource = rpt;
            }
            catch (Exception ex)
            {

            }
        }
    }
}
