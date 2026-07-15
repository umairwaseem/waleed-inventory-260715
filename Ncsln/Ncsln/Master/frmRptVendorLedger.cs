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
    public partial class frmRptVendorLedger : Form
    {

        CoreClass ObjCore;

        public frmRptVendorLedger()
        {
            InitializeComponent();
            this.ObjCore = new CoreClass();
        }

        private void frmRptVendorLedger_Load(object sender, EventArgs e)
        {
            this.ObjCore.fillComboBoxOptioni(this.cmbVendor, "Select Id, Name From VendorG");
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            try
            {
                this.dsVendorLedger1.Clear();
                this.daVendorLedger.SelectCommand.Connection.ConnectionString = this.ObjCore.getConnectionString();
                this.daVendorLedger.SelectCommand.Parameters["@VendorId"].Value = this.cmbVendor.SelectedValue.ToString();
                this.daVendorLedger.Fill(this.dsVendorLedger1);

                docVendorLedger rpt = new docVendorLedger();
                rpt.SetDataSource(this.dsVendorLedger1);
                this.crv.ReportSource = rpt;
            }
            catch (Exception ex)
            {

            }
        }
    }
}
