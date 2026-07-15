using Ncsln.Classes;
using Ncsln.DBModel;
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
    public partial class frmDailyReport : Form
    {
        CoreClass objCore;
        InventoryEntities DB;
        public frmDailyReport()
        {
            InitializeComponent();
            this.objCore = new CoreClass();
        }

        private void frmDailyReport_Load(object sender, EventArgs e)
        {
            
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            try
            {
                decimal PreviousBalance = 0;
                decimal TotalReceive = 0;
                decimal TotalReturn = 0;
                decimal TotalExpense = 0;
                decimal BankWithdraw = 0;
                decimal ProfitRatio = 0;
                decimal PRInvoiceTotal = 0;

                using (this.DB = new InventoryEntities(this.objCore.getClientConnectionStringName()))
                {
                    var PreviusBal = this.DB.Database.SqlQuery<decimal>("select dbo.funPreviousBalance('" + this.dtp.Value.ToShortDateString() + "')").FirstOrDefault();
                    PreviousBalance = PreviusBal;
                    var Withdraw = this.DB.Database.SqlQuery<decimal>("select dbo.funGetWithdraw('" + this.dtp.Value.ToShortDateString() + "')").FirstOrDefault();
                    BankWithdraw = Withdraw;
                }

                this.dsDailyOrderReceive1.Clear();
                this.dsDailyOrderReceive1.EnforceConstraints = false;
                this.daDailyOrderReceive.SelectCommand.Connection.ConnectionString = this.objCore.getClientConnectionString();
                this.daDailyOrderReceive.SelectCommand.Parameters["@date"].Value = this.dtp.Value.ToShortDateString();
                this.daDailyOrderReceive.Fill(this.dsDailyOrderReceive1);

                for (int i = 0; i < this.dsDailyOrderReceive1.vOrderReceive.Rows.Count; i++)
                {
                    if (this.dsDailyOrderReceive1.vOrderReceive.Rows[i]["OType"].ToString() == "R")
                        TotalReceive += Convert.ToDecimal(this.dsDailyOrderReceive1.vOrderReceive.Rows[i]["Amount"]);

                    if (this.dsDailyOrderReceive1.vOrderReceive.Rows[i]["OType"].ToString() == "P")
                        TotalReturn += Convert.ToDecimal(this.dsDailyOrderReceive1.vOrderReceive.Rows[i]["Amount"]);
                }

                TotalReceive -= TotalReturn;

                this.dsDailySale1.Clear();
                this.dsDailySale1.EnforceConstraints = false;
                this.daDailySale.SelectCommand.Connection.ConnectionString = this.objCore.getClientConnectionString();
                this.daDailySale.SelectCommand.Parameters["@date"].Value = this.dtp.Value.ToShortDateString();
                this.daDailySale.Fill(this.dsDailySale1);

                decimal SalePrice = 0;
                decimal SaleCost = 0;

                for (int i = 0; i < this.dsDailySale1.vOrder.Rows.Count; i++)
                {
                    SalePrice = Convert.ToDecimal(this.dsDailySale1.vOrder.Rows[i]["FinalTotal"]);
                    SaleCost = Convert.ToDecimal(this.dsDailySale1.vOrder.Rows[i]["Cost"]);
                    
                    ProfitRatio += (SalePrice - SaleCost);
                }

                this.dsDailyExpense1.Clear();
                this.dsDailyExpense1.EnforceConstraints = false;
                this.daDailyExpense.SelectCommand.Connection.ConnectionString = this.objCore.getClientConnectionString();
                this.daDailyExpense.SelectCommand.Parameters["@date"].Value = this.dtp.Value.ToShortDateString();
                this.daDailyExpense.Fill(this.dsDailyExpense1);

                for (int i = 0; i < this.dsDailyExpense1.vExpense.Rows.Count; i++)
                {
                    TotalExpense += Convert.ToDecimal(this.dsDailyExpense1.vExpense.Rows[i]["Amount"]);
                }

                this.dsPRInvoice1.Clear();
                this.daPRInvoice.SelectCommand.Connection.ConnectionString = this.objCore.getClientConnectionString();
                this.daPRInvoice.SelectCommand.Parameters["@date"].Value = this.dtp.Value.ToShortDateString();
                this.daPRInvoice.Fill(this.dsPRInvoice1);

                for (int i = 0; i < this.dsPRInvoice1.PRInvoice.Rows.Count; i++)
                {
                    PRInvoiceTotal += Convert.ToDecimal(this.dsPRInvoice1.PRInvoice.Rows[i]["TotalPrice"]);                    
                }

                TotalReceive += PRInvoiceTotal;
                ProfitRatio += PRInvoiceTotal;

                this.dsInternalStock1.Clear();
                this.dsInternalStock1.EnforceConstraints = false;
                this.daInternalStock.SelectCommand.Connection.ConnectionString = this.objCore.getClientConnectionString();
                this.daInternalStock.SelectCommand.Parameters["@date"].Value = this.dtp.Value.ToShortDateString();
                this.daInternalStock.Fill(this.dsInternalStock1);

                //this.dsHBCChallanDetail1.Clear();
                //this.dsHBCChallanDetail1.EnforceConstraints = false;
                //this.daHBCChallanDetail.SelectCommand.Connection.ConnectionString = this.objCore.getClientConnectionString();
                //this.daHBCChallanDetail.SelectCommand.Parameters["@date"].Value = this.dtp.Value.ToShortDateString();
                //this.daHBCChallanDetail.Fill(this.dsHBCChallanDetail1);

                this.dsManufacturingStock1.Clear();
                this.dsManufacturingStock1.EnforceConstraints = false;
                this.daMenufacturingStock.SelectCommand.Connection.ConnectionString = this.objCore.getClientConnectionString();
                this.daMenufacturingStock.SelectCommand.Parameters["@date"].Value = this.dtp.Value.ToShortDateString();
                this.daMenufacturingStock.Fill(this.dsManufacturingStock1);

                this.dsHBCReverse1.Clear();
                this.dsHBCReverse1.EnforceConstraints = false;
                this.daHBCRevers.SelectCommand.Connection.ConnectionString = this.objCore.getClientConnectionString();
                this.daHBCRevers.SelectCommand.Parameters["@date"].Value = this.dtp.Value.ToShortDateString();
                this.daHBCRevers.Fill(this.dsHBCReverse1);


                docDailyReport rpt = new docDailyReport();
                rpt.Subreports["subOrderReceive"].SetDataSource(this.dsDailyOrderReceive1);
                rpt.Subreports["subSales"].SetDataSource(this.dsDailySale1);
                rpt.Subreports["subExpense"].SetDataSource(this.dsDailyExpense1);
                rpt.Subreports["subInternalStock"].SetDataSource(this.dsInternalStock1);
                rpt.Subreports["subPRInvoice"].SetDataSource(this.dsPRInvoice1);
                //rpt.Subreports["subHBCChallan"].SetDataSource(this.dsHBCChallanDetail1);
                rpt.Subreports["subManufacturing"].SetDataSource(this.dsManufacturingStock1);
                rpt.Subreports["subHBCReverse"].SetDataSource(this.dsHBCReverse1);

                rpt.SetParameterValue("dailyDate", this.dtp.Value.ToShortDateString());
                rpt.SetParameterValue("PreviousBalance", PreviousBalance);
                rpt.SetParameterValue("TotalReceive", TotalReceive);
                rpt.SetParameterValue("TotalExpense", TotalExpense);
                rpt.SetParameterValue("BankWithdraw", BankWithdraw);
                rpt.SetParameterValue("TotalPR", (ProfitRatio - TotalExpense));
                rpt.SetParameterValue("MyCompany", this.objCore.getServerName());
                rpt.SetParameterValue("CompanyCode", Classes.companyInfo.invoiceCode, "subOrderReceive");
                rpt.SetParameterValue("CompanyCode", Classes.companyInfo.invoiceCode, "subSales");
                rpt.SetParameterValue("MyCompanyName", Classes.companyInfo.companyName, "subInternalStock");
                if (SetupType.SoftType == SoftwareType.Master)
                {
                    rpt.SetParameterValue("MyCompanyName", this.objCore.GetSetting(2), "subInternalStock");
                    rpt.SetParameterValue("CompanyCode", this.objCore.GetSetting(3), "subOrderReceive");
                    rpt.SetParameterValue("CompanyCode", this.objCore.GetSetting(3), "subSales");
                }
                
                this.crv.ReportSource = rpt;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
