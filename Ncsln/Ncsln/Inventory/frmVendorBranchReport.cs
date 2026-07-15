using Ncsln.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Ncsln.Inventory
{
    public partial class frmVendorBranchReport : Form
    {
        CoreClass ObjCore;
        public int branchId = -1;

        public frmVendorBranchReport()
        {
            InitializeComponent();
            this.ObjCore = new CoreClass();
        }

        private void frmVendorReport_Load(object sender, EventArgs e)
        {
            this.ObjCore.fillComboBoxOptioni(this.cmbVendor, "Select VendorId, Name From Vendors where VendorId not in (1)", this.ObjCore.getHBCConnectionString());            
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            try
            {
                string vendorName = this.cmbVendor.Text.ToString();
                string Abv = vendorName.Substring(0, 3);

                this.dsVendorBranchStock1.Clear();
                this.dsVendorBranchStock1.EnforceConstraints = false;
                this.daVendorBranchStockBalance.SelectCommand.Connection.ConnectionString = this.ObjCore.getClientConnectionString();
                this.daVendorBranchStockBalance.SelectCommand.Parameters["@key"].Value = Abv;
                this.daVendorBranchStockBalance.Fill(this.dsVendorBranchStock1);

                docVendorBranchStockBalance rpt = new docVendorBranchStockBalance();
                rpt.SetDataSource(this.dsVendorBranchStock1);
                this.crv.ReportSource = rpt;
                
            }
            catch (Exception ex)
            {

            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cmbVendor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            
            
        }
    }
}
