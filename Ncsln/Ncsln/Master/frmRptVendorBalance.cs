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
    public partial class frmRptVendorBalance : Form
    {
        CoreClass ObjCore;

        public frmRptVendorBalance()
        {
            InitializeComponent();
            this.ObjCore = new CoreClass();
        }

        private void frmRptVendorBalance_Load(object sender, EventArgs e)
        {

        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            try
            {
                this.dsVendorBalance1.Clear();
                this.daVendorBalance.SelectCommand.Connection.ConnectionString = this.ObjCore.getHBCConnectionString();
                this.daVendorBalance.Fill(this.dsVendorBalance1);

                docVendorBalance rpt = new docVendorBalance();
                rpt.SetDataSource(this.dsVendorBalance1);
                this.crv.ReportSource = rpt;
            }
            catch (Exception ex)
            {

            }
        }
    }
}
