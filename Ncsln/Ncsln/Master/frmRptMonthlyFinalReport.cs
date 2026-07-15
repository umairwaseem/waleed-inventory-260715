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
    public partial class frmRptMonthlyFinalReport : Form
    {
        CoreClass ObjCore;

        public frmRptMonthlyFinalReport()
        {
            InitializeComponent();
            this.ObjCore = new CoreClass();
        }

        private void frmRptMonthlyFinalReport_Load(object sender, EventArgs e)
        {

        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            try
            {
                decimal AmountOne = 0, AmountTwo = 0, AmountThree = 0, AmountFour = 0, Salaries = 0, Partner = 0;

                DataTable dt = this.ObjCore.getDataSet("Select * from ProfitSharing where MONTH(Date) = MONTH('" + this.dtp.Value.ToString() + "') and Year(Date) = Year('" + this.dtp.Value.ToString() + "')", this.ObjCore.getHBCConnectionString()).Tables[0];

                AmountOne = Convert.ToDecimal(dt.Rows[0]["AmountOne"]);
                AmountTwo = Convert.ToDecimal(dt.Rows[0]["AmountTwo"]);
                AmountThree = Convert.ToDecimal(dt.Rows[0]["AmountThree"]);
                AmountFour = Convert.ToDecimal(dt.Rows[0]["AmountFour"]);

                this.dsMonthlyFinalReportBranches1.Clear();
                this.dsMonthlyFinalReportBranches1.EnforceConstraints = false;
                this.daBranches.SelectCommand.Connection.ConnectionString = this.ObjCore.getHBCConnectionString();
                this.daBranches.SelectCommand.Parameters["@Date"].Value = this.dtp.Value.ToString();
                this.daBranches.Fill(this.dsMonthlyFinalReportBranches1);

                for (int i = 0; i < this.dsMonthlyFinalReportBranches1.BranchesGroup.Rows.Count; i++)
                {
                    Salaries += Convert.ToDecimal(this.dsMonthlyFinalReportBranches1.BranchesGroup.Rows[i]["Salaries"]);
                }

                this.dsMonthlyParterDetail1.Clear();
                this.dsMonthlyParterDetail1.EnforceConstraints = false;
                this.daPartnerDetail.SelectCommand.Connection.ConnectionString = this.ObjCore.getHBCConnectionString();
                this.daPartnerDetail.SelectCommand.Parameters["@Date"].Value = this.dtp.Value.ToString();
                this.daPartnerDetail.Fill(this.dsMonthlyParterDetail1);

                for (int i = 0; i < this.dsMonthlyParterDetail1.vPartnerProfitDetail.Rows.Count; i++)
                {
                    
                    Partner += Convert.ToDecimal(this.dsMonthlyParterDetail1.vPartnerProfitDetail.Rows[i]["PercentAmount"]);
                }

                docMonthlyFinalReport rpt = new docMonthlyFinalReport();
                rpt.Subreports["subBranches"].SetDataSource(this.dsMonthlyFinalReportBranches1);
                rpt.Subreports["subPartners"].SetDataSource(this.dsMonthlyParterDetail1);

                rpt.SetParameterValue("AmountOne", AmountOne.ToString());
                rpt.SetParameterValue("AmountTwo", AmountTwo.ToString());
                rpt.SetParameterValue("AmountThree", AmountThree.ToString());
                rpt.SetParameterValue("AmountFour", AmountFour.ToString());
                rpt.SetParameterValue("TotalSalary", Salaries.ToString());
                rpt.SetParameterValue("TotalPartner", Partner.ToString());
                rpt.SetParameterValue("Date", this.dtp.Value.ToString());

                this.crv.ReportSource = rpt;


            }
            catch (Exception ex)
            {

            }
        }
    }
}
