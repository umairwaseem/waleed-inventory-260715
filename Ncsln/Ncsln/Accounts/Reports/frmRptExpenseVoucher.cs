using Ncsln.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Ncsln.Accounts.Reports
{
    public partial class frmRptExpenseVoucher : Form
    {
        CoreClass ObjCore;
        public int Id { get; set; }

        public frmRptExpenseVoucher()
        {
            InitializeComponent();
            this.ObjCore = new CoreClass();
        }

        private void frmRptExpenseVoucher_Load(object sender, EventArgs e)
        {
            try
            {
                this.dsExpenseVoucher1.Clear();
                this.daExpenseVoucher.SelectCommand.Connection.ConnectionString = this.ObjCore.getClientConnectionString();
                this.daExpenseVoucher.SelectCommand.Parameters["@Id"].Value = this.Id;
                this.daExpenseVoucher.Fill(this.dsExpenseVoucher1);

                docExpenseVoucher rpt = new docExpenseVoucher();
                rpt.SetDataSource(this.dsExpenseVoucher1);
                this.crv.ReportSource = rpt;
            }
            catch (Exception ex)
            {

            }
        }
    }
}
