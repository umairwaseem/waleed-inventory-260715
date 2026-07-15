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
    public partial class frmRptDailyBanking : Form
    {
        CoreClass ObjCore;
        public int Id { get; set; }

        public frmRptDailyBanking()
        {
            InitializeComponent();
            this.ObjCore = new CoreClass();
        }

        private void frmRptExpenseVoucher_Load(object sender, EventArgs e)
        {
            try
            {
                this.dsDailyBanking1.Clear();
                this.daDailyBanking.SelectCommand.Connection.ConnectionString = this.ObjCore.getClientConnectionString();
                this.daDailyBanking.SelectCommand.Parameters["@Id"].Value = this.Id;
                this.daDailyBanking.Fill(this.dsDailyBanking1);

                docDailyBanking rpt = new docDailyBanking();
                rpt.SetDataSource(this.dsDailyBanking1);
                this.crv.ReportSource = rpt;
            }
            catch (Exception ex)
            {

            }
        }
    }
}
