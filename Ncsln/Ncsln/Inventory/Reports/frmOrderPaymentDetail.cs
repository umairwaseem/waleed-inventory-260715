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
    public partial class frmOrderPaymentDetail : Form
    {
        public string Id { get; set; }
        Classes.CoreClass objCore = new Classes.CoreClass();
        public frmOrderPaymentDetail()
        {
            InitializeComponent();
        }

        private void frmOrderPaymentDetail_Load(object sender, EventArgs e)
        {
            try
            {
                this.dsOrderReceiveDetail1.Clear();
                this.daOrderReceiveDetail.SelectCommand.Connection.ConnectionString = this.objCore.getClientConnectionString();
                this.daOrderReceiveDetail.SelectCommand.Parameters["@Id"].Value = this.Id;
                this.daOrderReceiveDetail.Fill(this.dsOrderReceiveDetail1);

                docOrderPaymentDetail rpt = new docOrderPaymentDetail();
                rpt.SetDataSource(this.dsOrderReceiveDetail1);
                this.crv.ReportSource = rpt;

            }
            catch (Exception)
            {

            }
        }
    }
}
