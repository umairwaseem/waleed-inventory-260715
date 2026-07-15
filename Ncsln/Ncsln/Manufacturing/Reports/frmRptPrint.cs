using Ncsln.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Ncsln.Manufacturing.Reports
{
    public partial class frmRptPrint : Form
    {
        CoreClass ObjCore;
        public int Id = -1;

        public frmRptPrint()
        {
            InitializeComponent();
            this.ObjCore = new CoreClass();
        }

        private void frmRptPrint_Load(object sender, EventArgs e)
        {
            try
            {
                this.dsMStockInDetail1.Clear();
                this.dsMStockInDetail1.EnforceConstraints = false;
                this.daMStockInDetail.SelectCommand.Connection.ConnectionString = this.ObjCore.getHBCConnectionString();
                this.daMStockInDetail.SelectCommand.Parameters["@Id"].Value = this.Id;
                this.daMStockInDetail.Fill(this.dsMStockInDetail1);

                docMStockInDetail rpt = new docMStockInDetail();
                rpt.SetDataSource(this.dsMStockInDetail1);
                this.crv.ReportSource = rpt;

            }
            catch (Exception ex)
            {

            }
        }
    }
}
