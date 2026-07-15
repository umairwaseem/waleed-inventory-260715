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
    public partial class frmRptVendorPurchaseDetail : Form
    {
        public DataSet ds;
        public frmRptVendorPurchaseDetail()
        {
            InitializeComponent();
        }

        private void frmRptVendorPurchaseDetail_Load(object sender, EventArgs e)
        {
            try
            {
                this.dgv.DataSource = this.ds.Tables[0];

                decimal total = 0, qty = 0, extra = 0, final = 0;

                DataTable dt = this.ds.Tables[0];

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    total += Convert.ToDecimal(dt.Rows[i]["TotalPrice"]);
                    qty += Convert.ToDecimal(dt.Rows[i]["Qty"]);
                }

                extra = qty * 100;
                final = total - extra;

                this.lbTotal.Text = Convert.ToInt32(total).ToString();
                this.lbExtra.Text = Convert.ToInt32(extra).ToString();
                this.lbFinalTotal.Text = Convert.ToInt32(final).ToString();

            }
            catch (Exception ex)
            {

            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
