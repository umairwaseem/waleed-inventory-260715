using Ncsln.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Ncsln.Forms
{
    public partial class frmCenter : Form
    {
        CoreClass objCore;
        frmDashboard dashboard;
        public frmCenter()
        {
            InitializeComponent();
            this.objCore = new CoreClass();
        }

        private void frmCenter_Load(object sender, EventArgs e)
        {
            if (SetupVersion.version == SetupVersions.Full)
            {
                this.dashboard = new frmDashboard();
                dashboard.MdiParent = this;
                dashboard.WindowState = FormWindowState.Maximized;
                dashboard.Show();
            }

            this.GetViewRights();

            //this.Text = "Inverntory - " + this.objCore.getServerName();

            //if (SetupType.SoftType == SoftwareType.Master)
            //{
            //    this.changeServerToolStripMenuItem.Visible = true;
            //    this.vendorPaymentsToolStripMenuItem.Visible = true;
            //    this.vendorReportToolStripMenuItem.Visible = true;
            //    this.vendorDetailReportToolStripMenuItem.Visible = true;
            //    this.bankingReportToolStripMenuItem.Visible = true;
            //    this.clientToolStripMenuItem.Visible = false;
            //    this.Text = "Inverntory - Master - " + this.objCore.getServerName();
            //    this.masterToolStripMenuItem.Visible = true;
            //    this.manufacturingToolStripMenuItem.Visible = true;
            //    this.stockToolStripMenuItem.Visible = false;
            //}
            //else if(SetupType.SoftType == SoftwareType.HBC)
            //{
            //    this.stockToolStripMenuItem.Visible = true;
            //}
            //else
            //{
            //    this.masterToolStripMenuItem.Visible = false;
            //    this.changeServerToolStripMenuItem.Visible = false;
            //    this.vendorPaymentsToolStripMenuItem.Visible = false;
            //    this.vendorReportToolStripMenuItem.Visible = false;
            //    this.vendorDetailReportToolStripMenuItem.Visible = false;
            //    this.bankingReportToolStripMenuItem.Visible = false;
            //    this.manufacturingToolStripMenuItem.Visible = false;
            //    if (SetupType.SoftType == SoftwareType.OfficeEmpire)
            //    {
            //        this.Text = "Inverntory - Office Empire";
            //    }
            //    else if (SetupType.SoftType == SoftwareType.OfficeMaster)
            //    {
            //        this.Text = "Inverntory - Office Master";
            //    }
            //    else if (SetupType.SoftType == SoftwareType.OfficenOffice)
            //    {
            //        this.Text = "Inverntory - Office N Office";
            //    }
            //    else if (SetupType.SoftType == SoftwareType.WorldStyle)
            //    {
            //        this.Text = "Inverntory - World Style";
            //    }
            //}

            // All Menu hide in all cases
            this.vendorToolStripMenuItem.Visible = false;
            this.bankingReportToolStripMenuItem.Visible = false;
            this.vendorPaymentsToolStripMenuItem.Visible = false;
            this.vendorDetailReportToolStripMenuItem.Visible = false;
            this.vendorReportToolStripMenuItem.Visible = false;
            //this.stockToolStripMenuItem.Visible = false;
            
        }

        private void GetViewRights()
        {
            this.itemToolStripMenuItem.Visible = this.objCore.getUserRight(1, "Canview");
            this.vendorToolStripMenuItem.Visible = this.objCore.getUserRight(2, "Canview");
            this.clientToolStripMenuItem.Visible = this.objCore.getUserRight(3, "Canview");

            this.purchaseToolStripMenuItem.Visible = this.objCore.getUserRight(4, "Canview");
            this.orderToolStripMenuItem.Visible = this.objCore.getUserRight(6, "Canview");
            this.dailyBankingToolStripMenuItem.Visible = this.objCore.getUserRight(8, "Canview");

            this.itemStockToolStripMenuItem.Visible = this.objCore.getUserRight(12, "Canview");
            this.dailyReportToolStripMenuItem.Visible = this.objCore.getUserRight(13, "Canview");
            this.stockReportToolStripMenuItem.Visible = this.objCore.getUserRight(14, "Canview");

            this.expenseAccountToolStripMenuItem.Visible = this.objCore.getUserRight(10, "Canview");
            this.expenseVoucherToolStripMenuItem.Visible = this.objCore.getUserRight(11, "Canview");

            this.userToolStripMenuItem.Visible = this.objCore.getUserRight(15, "Canview");
            this.userGroupToolStripMenuItem.Visible = this.objCore.getUserRight(17, "Canview");
            this.purchaseDetailToolStripMenuItem.Visible = this.objCore.getUserRight(19, "CanView");
            this.internalStockToolStripMenuItem.Visible = this.objCore.getUserRight(20, "CanView");
            this.pRInvoiceToolStripMenuItem.Visible = this.objCore.getUserRight(21, "CanView");

            this.getHBCStockToolStripMenuItem.Visible = this.objCore.getUserRight(101, "CanView");
            this.itemMatchingToolStripMenuItem.Visible = this.objCore.getUserRight(102, "CanView");
            this.hBCStockReverseToolStripMenuItem.Visible = this.objCore.getUserRight(103, "CanView");

            this.branchRectifyStockToolStripMenuItem.Visible = this.objCore.getUserRight(55, "CanView");

            // HBC User Rights
            this.stockInToolStripMenuItem1.Visible = this.objCore.getUserRight(23, "CanView", this.objCore.getHBCConnectionString());
            this.stockOutToolStripMenuItem1.Visible = this.objCore.getUserRight(24, "CanView", this.objCore.getHBCConnectionString());
            this.stockReportToolStripMenuItem2.Visible = this.objCore.getUserRight(25, "CanView", this.objCore.getHBCConnectionString());
            this.stockLedgerToolStripMenuItem.Visible = this.objCore.getUserRight(26, "CanView", this.objCore.getHBCConnectionString());

            // Manufacturing 
            this.stockInToolStripMenuItem.Visible = this.objCore.getUserRight(27, "CanView", this.objCore.getHBCConnectionString());
            this.manufacturingToolStripMenuItem1.Visible = this.objCore.getUserRight(28, "CanView", this.objCore.getHBCConnectionString());
            this.stockOutToolStripMenuItem.Visible = this.objCore.getUserRight(29, "CanView", this.objCore.getHBCConnectionString());
            this.stockReportToolStripMenuItem1.Visible = this.objCore.getUserRight(30, "CanView", this.objCore.getHBCConnectionString());
            this.stockFinishGoodsReportToolStripMenuItem.Visible = this.objCore.getUserRight(31, "CanView", this.objCore.getHBCConnectionString());

            // Head Office
            this.bankSheetToolStripMenuItem.Visible = this.objCore.getUserRight(32, "CanView", this.objCore.getHBCConnectionString());
            this.vendorPaymentToolStripMenuItem1.Visible = this.objCore.getUserRight(33, "CanView", this.objCore.getHBCConnectionString());
            this.generalVendorPaymentToolStripMenuItem.Visible = this.objCore.getUserRight(34, "CanView", this.objCore.getHBCConnectionString());
            this.pRReportToolStripMenuItem.Visible = this.objCore.getUserRight(35, "CanView", this.objCore.getHBCConnectionString());
            this.addVendorToolStripMenuItem.Visible = this.objCore.getUserRight(36, "CanView", this.objCore.getHBCConnectionString());
            this.addGeneralVendorToolStripMenuItem1.Visible = this.objCore.getUserRight(37, "CanView", this.objCore.getHBCConnectionString());
            this.vendorReportToolStripMenuItem1.Visible = this.objCore.getUserRight(38, "CanView", this.objCore.getHBCConnectionString());
            this.generalVendorLedgerToolStripMenuItem.Visible = this.objCore.getUserRight(39, "CanView", this.objCore.getHBCConnectionString());
            this.generalVendorEntryToolStripMenuItem1.Visible = this.objCore.getUserRight(40, "CanView", this.objCore.getHBCConnectionString());
            this.vendorTempToolStripMenuItem.Visible = this.objCore.getUserRight(41, "CanView", this.objCore.getHBCConnectionString());
            this.finalReportToolStripMenuItem.Visible = this.objCore.getUserRight(42, "CanView", this.objCore.getHBCConnectionString());
            this.vendorBalancesToolStripMenuItem.Visible = this.objCore.getUserRight(43, "CanView", this.objCore.getHBCConnectionString());
            this.rectifyStockToolStripMenuItem.Visible = this.objCore.getUserRight(55, "CanView", this.objCore.getHBCConnectionString());

            this.employeeToolStripMenuItem.Visible = this.objCore.getUserRight(44, "CanView", this.objCore.getHBCConnectionString());
            this.partnerToolStripMenuItem.Visible = this.objCore.getUserRight(45, "CanView", this.objCore.getHBCConnectionString());

            this.cashReportToolStripMenuItem.Visible = this.objCore.getUserRight(56, "CanView", this.objCore.getHBCConnectionString());
            this.expenseToolStripMenuItem1.Visible = this.objCore.getUserRight(57, "CanView", this.objCore.getHBCConnectionString());
            this.expenseToolStripMenuItem1.Visible = this.objCore.getUserRight(57, "CanView", this.objCore.getHBCConnectionString());
            this.cashReportToolStripMenuItem.Visible = this.objCore.getUserRight(58, "CanView", this.objCore.getHBCConnectionString());

            this.additionalAccountListToolStripMenuItem.Visible = this.objCore.getUserRight("Additional Account List", "CanView", this.objCore.getHBCConnectionString());
            this.additionalBankingToolStripMenuItem.Visible = this.objCore.getUserRight("Additional Banking", "CanView", this.objCore.getHBCConnectionString());
            this.balanceDetailToolStripMenuItem.Visible = this.objCore.getUserRight("Balance Detail", "CanView", this.objCore.getHBCConnectionString());
            this.balanceDetailTransactionToolStripMenuItem.Visible = this.objCore.getUserRight("Balance Detail Transaction", "CanView", this.objCore.getHBCConnectionString());
            this.balanceDetailSummaryToolStripMenuItem.Visible = this.objCore.getUserRight("Balance Detail Summary", "CanView", this.objCore.getHBCConnectionString());
            this.cashToolStripMenuItem.Visible = true;
            this.pRToolStripMenuItem.Visible = this.objCore.getUserRight(59, "CanView", this.objCore.getHBCConnectionString());
            this.finalReportToolStripMenuItem.Visible = this.objCore.getUserRight(60, "CanView", this.objCore.getHBCConnectionString());
            this.employeeToolStripMenuItem.Visible = this.objCore.getUserRight(61, "CanView", this.objCore.getHBCConnectionString());

            this.promotionalItemToolStripMenuItem2.Visible = this.objCore.getUserRight(1000, "CanView");

            // Version check
            if (SetupType.SoftType == SoftwareType.Master)
            {
                this.changeServerToolStripMenuItem.Visible = true;
                this.vendorPaymentsToolStripMenuItem.Visible = true;
                this.vendorReportToolStripMenuItem.Visible = true;
                this.vendorDetailReportToolStripMenuItem.Visible = true;
                this.bankingReportToolStripMenuItem.Visible = true;
                this.clientToolStripMenuItem.Visible = false;
                this.Text = "Inverntory - Master - " + this.objCore.getServerName();
                this.masterToolStripMenuItem.Visible = true;
                this.manufacturingToolStripMenuItem.Visible = true;
                this.stockToolStripMenuItem.Visible = false;
                this.branchesDailyCashToolStripMenuItem.Visible = true;

                // Manufacturing
                if (SetupVersion.version == SetupVersions.Manufacturing)
                {
                    this.manufacturingToolStripMenuItem.Visible = true;
                    this.stockToolStripMenuItem.Visible = false;
                    this.masterToolStripMenuItem.Visible = false;
                }
                else if (SetupVersion.version == SetupVersions.HBC)
                {
                    this.stockToolStripMenuItem.Visible = true;
                    this.masterToolStripMenuItem.Visible = false;
                    this.manufacturingToolStripMenuItem.Visible = false;
                    //this.itemListToolStripMenuItem.Visible = true;
                }
                else
                {
                    this.stockToolStripMenuItem.Visible = true;
                    this.masterToolStripMenuItem.Visible = true;
                    this.inventoryToolStripMenuItem.Visible = true;
                    this.expenseToolStripMenuItem.Visible = true;
                    this.controlToolStripMenuItem.Visible = true;
                    this.itemListToolStripMenuItem.Visible = true;
                }
            }
            //else if (SetupType.SoftType == SoftwareType.HBC)
            //{
            //    this.stockToolStripMenuItem.Visible = true;
            //}
            else
            {
                this.masterToolStripMenuItem.Visible = false;
                this.changeServerToolStripMenuItem.Visible = false;
                this.vendorPaymentsToolStripMenuItem.Visible = false;
                this.vendorReportToolStripMenuItem.Visible = false;
                this.vendorDetailReportToolStripMenuItem.Visible = false;
                this.bankingReportToolStripMenuItem.Visible = false;
                this.manufacturingToolStripMenuItem.Visible = false;

                // For branches 
                this.inventoryToolStripMenuItem.Visible = true;
                this.expenseToolStripMenuItem.Visible = true;
                this.controlToolStripMenuItem.Visible = true;

                if (SetupType.SoftType == SoftwareType.OfficeEmpire)
                {
                    this.Text = "Inventory - One";
                }
                else if (SetupType.SoftType == SoftwareType.OfficeMaster)
                {
                    this.Text = "Inventory - Office Master";
                }
                else if (SetupType.SoftType == SoftwareType.OfficenOffice)
                {
                    this.Text = "Inventory - Two";
                }
                else if (SetupType.SoftType == SoftwareType.WorldStyle)
                {
                    this.Text = "Inventory - World Style";
                }
            }

            // No more need of these from client end 
            this.userToolStripMenuItem.Visible = false;
            this.userGroupToolStripMenuItem.Visible = false;   
            this.monthlyFinalReportToolStripMenuItem.Visible = false;

        }

        private void frmCenter_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void itemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Inventory.frmItem obj = new Inventory.frmItem();
            obj.WindowState = FormWindowState.Maximized;
            obj.MdiParent = this;
            obj.Show();
        }

        private void vendorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Inventory.frmVendor obj = new Inventory.frmVendor();
            //obj.WindowState = FormWindowState.Maximized;
            //obj.MdiParent = this;
            //obj.Show();
        }

        private void clientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Inventory.frmclient obj = new Inventory.frmclient();
            obj.WindowState = FormWindowState.Maximized;
            obj.MdiParent = this;
            obj.Show();
        }

        private void orderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SetupType.SoftType != SoftwareType.Master)
            {
                frmSecurity login = new frmSecurity();
                login.ShowDialog();

                if (!login.ReLoginSuccess)
                {
                    return;
                }
            }

            Inventory.frmOrder obj = new Inventory.frmOrder();
            obj.WindowState = FormWindowState.Maximized;
            obj.MdiParent = this;
            obj.Show();
        }

        private void purchaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SetupType.SoftType != SoftwareType.Master)
            {
                frmSecurity login = new frmSecurity();
                login.ShowDialog();

                if (!login.ReLoginSuccess)
                {
                    return;
                }
            }

            //frmSelectClient client = new frmSelectClient();
            //client.ShowDialog();

            Inventory.frmPurchase obj = new Inventory.frmPurchase();
            obj.WindowState = FormWindowState.Maximized;
            obj.MdiParent = this;
            obj.Show();
        }

        private void saleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Inventory.frmSale obj = new Inventory.frmSale();
            obj.WindowState = FormWindowState.Maximized;
            obj.MdiParent = this;
            obj.Show();
        }

        private void expenseAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Accounts.frmExpenseAccount obj = new Accounts.frmExpenseAccount();
            obj.WindowState = FormWindowState.Maximized;
            obj.MdiParent = this;
            obj.Show();
        }

        private void expenseVoucherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Accounts.frmExpenseVoucher obj = new Accounts.frmExpenseVoucher();
            obj.WindowState = FormWindowState.Maximized;
            obj.MdiParent = this;
            obj.Show();
        }

        private void itemStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmSelectClient client = new frmSelectClient();
            //client.ShowDialog();

            Inventory.Reports.frmItemStock obj = new Inventory.Reports.frmItemStock();
            obj.WindowState = FormWindowState.Maximized;
            obj.MdiParent = this;
            obj.Show();
        }

        private void dailyReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmSelectClient client = new frmSelectClient();
            //client.ShowDialog();

            DataTable dt = this.objCore.getDataSet("Select * from InternalStock where Verified = '0'", this.objCore.getClientConnectionString()).Tables[0];

            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("You have pending branch in/out kindly verify it", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Inventory.Reports.frmDailyReport obj = new Inventory.Reports.frmDailyReport();
            obj.WindowState = FormWindowState.Maximized;
            obj.MdiParent = this;
            obj.Show();
        }

        private void ownerWithdrawToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Accounts.frmWithdraw obj = new Accounts.frmWithdraw();
            obj.WindowState = FormWindowState.Maximized;
            obj.MdiParent = this;
            obj.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dailyBankingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Accounts.frmWithdraw obj = new Accounts.frmWithdraw();
            obj.WindowState = FormWindowState.Maximized;
            obj.MdiParent = this;
            obj.Show();
        }

        private void stockReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Inventory.Reports.frmItemDetailStock obj = new Inventory.Reports.frmItemDetailStock();
            obj.WindowState = FormWindowState.Maximized;
            obj.MdiParent = this;
            obj.Show();
        }

        private void userGroupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Control.frmUserGroup obj = new Control.frmUserGroup();
            obj.WindowState = FormWindowState.Maximized;
            obj.MdiParent = this;
            obj.Show();
        }

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Control.frmUserGroupRights obj = new Control.frmUserGroupRights();
            obj.WindowState = FormWindowState.Maximized;
            obj.MdiParent = this;
            obj.Show();
        }

        private void userToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Control.frmUser obj = new Control.frmUser();
            obj.WindowState = FormWindowState.Maximized;
            obj.MdiParent = this;
            obj.Show();
        }

        private void purchaseDetailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Inventory.Reports.frmRptPurchaseDetail obj = new Inventory.Reports.frmRptPurchaseDetail();
            obj.WindowState = FormWindowState.Maximized;
            obj.MdiParent = this;
            obj.Show();
        }

        private void internalStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SetupType.SoftType != SoftwareType.Master)
            {
                frmSecurity login = new frmSecurity();
                login.ShowDialog();

                if (!login.ReLoginSuccess)
                {
                    return;
                }
            }

            Inventory.frmInternalStock obj = new Inventory.frmInternalStock();
            obj.WindowState = FormWindowState.Maximized;
            obj.MdiParent = this;
            obj.Show();
        }

        private void pRInvoiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Inventory.frmPRInvoice obj = new Inventory.frmPRInvoice();
            obj.WindowState = FormWindowState.Maximized;
            obj.MdiParent = this;
            obj.Show();
        }

        private void backUpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Control.frmBackup obj = new Control.frmBackup();
            obj.ShowDialog();
        }



        private void changeServerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSelectClient client = new frmSelectClient(this.dashboard);
            client.ShowDialog();


            this.Text = "Inverntory - Master - " + this.objCore.getServerName();
            if(client.selected)
                foreach (var item in this.MdiChildren)
                {
                    if (item.Name != "frmDashboard")
                        item.Close();
                }

        }

        private void vendorPaymentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Inventory.frmVendorPayments obj = new Inventory.frmVendorPayments();
            //obj.WindowState = FormWindowState.Maximized;
            //obj.MdiParent = this;
            //obj.Show();
        }

        private void vendorReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Inventory.frmVendorReport obj = new Inventory.frmVendorReport();
            //obj.WindowState = FormWindowState.Maximized;
            //obj.MdiParent = this;
            //obj.Show();
        }

        private void vendorDetailReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Inventory.Reports.frmRptVendorReport obj = new Inventory.Reports.frmRptVendorReport();
            //obj.WindowState = FormWindowState.Maximized;
            //obj.MdiParent = this;
            //obj.Show();
        }

        private void bankingReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Inventory.Reports.frmRptBanking obj = new Inventory.Reports.frmRptBanking();
            //obj.WindowState = FormWindowState.Maximized;
            //obj.MdiParent = this;
            //obj.Show();
        }

        private void generalVendorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void generalVendorPaymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Master.frmVendorGPayments obj = new Master.frmVendorGPayments();
            obj.WindowState = FormWindowState.Maximized;
            obj.MdiParent = this;
            obj.Show();
        }

        private void pRReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Master.frmRptBranchesPRReport obj = new Master.frmRptBranchesPRReport();
            obj.WindowState = FormWindowState.Maximized;
            obj.MdiParent = this;
            obj.Show();
        }

        private void vendorReportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Master.frmRptVendorDetailReport obj = new Master.frmRptVendorDetailReport();
            obj.WindowState = FormWindowState.Maximized;
            obj.MdiParent = this;
            obj.Show();
        }

        private void finalReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Master.frmRptFinalReport obj = new Master.frmRptFinalReport();
            obj.WindowState = FormWindowState.Maximized;
            obj.MdiParent = this;
            obj.Show();
        }

        private void addVendorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Inventory.frmVendor obj = new Inventory.frmVendor();
            obj.WindowState = FormWindowState.Maximized;
            obj.MdiParent = this;
            obj.Show();
        }

        private void bankSheetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Inventory.Reports.frmRptBanking obj = new Inventory.Reports.frmRptBanking();
            obj.WindowState = FormWindowState.Maximized;
            obj.MdiParent = this;
            obj.Show();
        }

        private void vendorPaymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void vendorDetailReportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Inventory.Reports.frmRptVendorReport obj = new Inventory.Reports.frmRptVendorReport();
            obj.WindowState = FormWindowState.Maximized;
            obj.MdiParent = this;
            obj.Show();
        }

        private void vendorWiseReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Inventory.frmVendorReport obj = new Inventory.frmVendorReport();
            obj.WindowState = FormWindowState.Maximized;
            obj.MdiParent = this;
            obj.Show();
        }

        private void vendorPaymentToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Inventory.frmVendorPayments obj = new Inventory.frmVendorPayments();
            obj.WindowState = FormWindowState.Maximized;
            obj.MdiParent = this;
            obj.Show();
        }

        private void addGeneralVendorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void vendorLiabililtyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Master.frmVendorGLiability obj = new Master.frmVendorGLiability();
            //obj.WindowState = FormWindowState.Maximized;
            //obj.MdiParent = this;
            //obj.Show();
        }

        private void vendorLedgerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void getHBCStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SetupType.SoftType != SoftwareType.Master)
            {
                frmSecurity login = new frmSecurity();
                login.ShowDialog();

                if (!login.ReLoginSuccess)
                {
                    return;
                }
            }

            Inventory.frmHBCStockChallan obj = new Inventory.frmHBCStockChallan();
            obj.WindowState = FormWindowState.Maximized;
            obj.MdiParent = this;
            obj.Show();
        }

        private void generalVendorEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void addItemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Manufacturing.frmItems obj = new Manufacturing.frmItems();
            obj.MdiParent = this;
            obj.Show();
        }

        private void stockInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Manufacturing.frmStockIn obj = new Manufacturing.frmStockIn();
            obj.MdiParent = this;
            obj.Show();
        }

        private void manufacturingToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Manufacturing.frmManufacturing obj = new Manufacturing.frmManufacturing();
            obj.WindowState = FormWindowState.Maximized;
            obj.MdiParent = this;
            obj.Show();
        }

        private void stockOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Manufacturing.frmFinishGoodStockOut obj = new Manufacturing.frmFinishGoodStockOut();
            obj.WindowState = FormWindowState.Maximized;
            obj.MdiParent = this;
            obj.Show();
        }

        private void stockReportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Manufacturing.Reports.frmRptItemsStock obj = new Manufacturing.Reports.frmRptItemsStock();
            obj.WindowState = FormWindowState.Maximized;
            obj.MdiParent = this;
            obj.Show();
        }

        private void stockFinishGoodsReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Manufacturing.Reports.frmRptFinishGoodStock obj = new Manufacturing.Reports.frmRptFinishGoodStock();
            obj.WindowState = FormWindowState.Maximized;
            obj.MdiParent = this;
            obj.Show();
        }

        private void addItemsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
        }

        private void stockInToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Stock.frmSStockIn obj = new Stock.frmSStockIn();
            obj.WindowState = FormWindowState.Maximized;
            obj.MdiParent = this;
            obj.Show();
        }

        private void stockOutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Stock.frmSStockOut obj = new Stock.frmSStockOut();
            obj.WindowState = FormWindowState.Maximized;
            obj.MdiParent = this;
            obj.Show();
        }

        private void stockReportToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Stock.Reports.frmRptItemStock obj = new Stock.Reports.frmRptItemStock();
            obj.WindowState = FormWindowState.Maximized;
            obj.MdiParent = this;
            obj.Show();
        }

        private void stockLedgerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stock.Reports.frmRptStockInOut obj = new Stock.Reports.frmRptStockInOut();
            obj.WindowState = FormWindowState.Maximized;
            obj.MdiParent = this;
            obj.Show();
        }

        private void itemLocalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void itemMatchingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Inventory.frmServerItemMatching obj = new Inventory.frmServerItemMatching();
            obj.WindowState = FormWindowState.Maximized;
            obj.MdiParent = this;
            obj.Show();
        }

        private void hBCItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stock.frmSItems obj = new Stock.frmSItems();
            obj.HBCItem = true;
            obj.WindowState = FormWindowState.Maximized;
            obj.MdiParent = this;
            obj.Show();
        }

        private void localItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stock.frmSItems obj = new Stock.frmSItems();
            obj.HBCItem = false;
            obj.WindowState = FormWindowState.Maximized;
            obj.MdiParent = this;
            obj.Show();
        }

        private void vendorTempToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Inventory.frmVendorReport obj = new Inventory.frmVendorReport();
            obj.WindowState = FormWindowState.Maximized;
            obj.MdiParent = this;
            obj.Show();
        }

        private void hBCStockReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stock.Reports.frmRptItemStock obj = new Stock.Reports.frmRptItemStock();
            obj.WindowState = FormWindowState.Maximized;
            obj.MdiParent = this;
            obj.Show();
        }

        private void hBCStockReverseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stock.frmStockReverse obj = new Stock.frmStockReverse();
            obj.WindowState = FormWindowState.Maximized;
            obj.MdiParent = this;
            obj.Show();
        }

        private void vendorBalancesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Master.frmRptVendorBalance obj = new Master.frmRptVendorBalance();
            obj.WindowState = FormWindowState.Maximized;
            obj.MdiParent = this;
            obj.Show();
        }

        private void rectifyItemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Inventory.frmRectifyItems obj = new Inventory.frmRectifyItems();
            obj.WindowState = FormWindowState.Maximized;
            obj.MdiParent = this;
            obj.Show();
        }

        private void branchesStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Master.frmBranchItems obj = new Master.frmBranchItems();
            obj.WindowState = FormWindowState.Maximized;
            obj.MdiParent = this;
            obj.Show();
        }

        private void employeeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void employeeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Master.frmEmployee obj = new Master.frmEmployee();
            obj.WindowState = FormWindowState.Maximized;
            obj.MdiParent = this;
            obj.Show();
        }

        private void employeeSalaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Master.frmEmployeeSalary obj = new Master.frmEmployeeSalary();
            obj.groupId = 1;
            obj.allGroup = 0;
            obj.WindowState = FormWindowState.Maximized;
            obj.MdiParent = this;
            obj.Show();
        }

        private void employeeSalaryOfficeEmpireToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Master.frmEmployeeSalary obj = new Master.frmEmployeeSalary();
            obj.groupId = 2;
            obj.allGroup = 0;
            obj.WindowState = FormWindowState.Maximized;
            obj.MdiParent = this;
            obj.Show();
        }

        private void employeeSalaryHistroyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Master.frmEmployeeSalaryHistory obj = new Master.frmEmployeeSalaryHistory();
            obj.WindowState = FormWindowState.Maximized;
            obj.MdiParent = this;
            obj.Show();
        }

        private void salaryOfficeNOfficeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Master.frmEmployeeSalary obj = new Master.frmEmployeeSalary();
            obj.groupId = 2;
            obj.allGroup = 0;
            obj.WindowState = FormWindowState.Maximized;
            obj.MdiParent = this;
            obj.Show();
        }

        private void salaryOfficeEmpireToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Master.frmEmployeeSalary obj = new Master.frmEmployeeSalary();
            obj.groupId = 1;
            obj.allGroup = 0;
            obj.WindowState = FormWindowState.Maximized;
            obj.MdiParent = this;
            obj.Show();
        }

        private void salaryHBCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Master.frmEmployeeSalary obj = new Master.frmEmployeeSalary();
            obj.groupId = 5;
            obj.allGroup = 0;
            obj.WindowState = FormWindowState.Maximized;
            obj.MdiParent = this;
            obj.Show();
        }

        private void addPartnerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Master.frmPartner obj = new Master.frmPartner();
            obj.WindowState = FormWindowState.Maximized;
            obj.MdiParent = this;
            obj.Show(); 
        }

        private void partnerProfitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Master.frmPartnerProfit obj = new Master.frmPartnerProfit();
            obj.WindowState = FormWindowState.Maximized;
            obj.MdiParent = this;
            obj.Show(); 
        }

        private void partnerProfitHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Master.frmPartnerProfitHistory obj = new Master.frmPartnerProfitHistory();
            obj.WindowState = FormWindowState.Maximized;
            obj.MdiParent = this;
            obj.Show(); 
        }

        private void majorAmountsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Master.frmProfitMargin obj = new Master.frmProfitMargin();
            obj.WindowState = FormWindowState.Maximized;
            obj.MdiParent = this;
            obj.Show(); 
        }

        private void monthlyFinalReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Master.frmRptMonthlyFinalReport obj = new Master.frmRptMonthlyFinalReport();
            obj.WindowState = FormWindowState.Maximized;
            obj.MdiParent = this;
            obj.Show(); 
        }

        private void monthlyFinalReportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Master.frmRptMonthlyFinalReport obj = new Master.frmRptMonthlyFinalReport();
            obj.WindowState = FormWindowState.Maximized;
            obj.MdiParent = this;
            obj.Show();
        }

        private void partnerPaymentReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Master.frmRptPartnerPay obj = new Master.frmRptPartnerPay();
            obj.WindowState = FormWindowState.Maximized;
            obj.MdiParent = this;
            obj.Show(); 
        }

        private void branchesStockToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Master.frmBranchItems obj = new Master.frmBranchItems();
            obj.WindowState = FormWindowState.Maximized;
            obj.MdiParent = this;
            obj.Show();
        }

        private void rectifyStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stock.frmStockRectify obj = new Stock.frmStockRectify();
            obj.WindowState = FormWindowState.Maximized;
            obj.MdiParent = this;
            obj.Show();
        }

        private void stockHideItemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stock.Reports.frmRptItemStock obj = new Stock.Reports.frmRptItemStock();
            obj.hideItems = true;
            obj.WindowState = FormWindowState.Maximized;
            obj.MdiParent = this;
            obj.Show();
        }

        private void stockHideLedgerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stock.Reports.frmRptStockInOut obj = new Stock.Reports.frmRptStockInOut();
            obj.WindowState = FormWindowState.Maximized;
            obj.hideItem = 1;
            obj.MdiParent = this;
            obj.Show();
        }

        private void branchRectifyStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Inventory.frmStockRectify obj = new Inventory.frmStockRectify();
            obj.WindowState = FormWindowState.Maximized;
            obj.MdiParent = this;
            obj.Show();
        }

        private void vendorStockBalanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Inventory.frmVendorBranchReport obj = new Inventory.frmVendorBranchReport();
            obj.WindowState = FormWindowState.Maximized;
            obj.MdiParent = this;
            obj.Show();
        }

        private void stockBranchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Manufacturing.Reports.frmRptBranchRowGoods obj = new Manufacturing.Reports.frmRptBranchRowGoods();
            obj.WindowState = FormWindowState.Maximized;
            obj.MdiParent = this;
            obj.Show();
        }

        private void itemTrendToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Inventory.Reports.frmRptTrend obj = new Inventory.Reports.frmRptTrend();
            obj.WindowState = FormWindowState.Maximized;
            obj.MdiParent = this;
            obj.Show();
        }

        private void stockAlertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Inventory.Reports.frmRptStockAlert obj = new Inventory.Reports.frmRptStockAlert();
            obj.WindowState = FormWindowState.Maximized;
            obj.MdiParent = this;
            obj.Show();
        }

        private void expenseToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Master.frmExpenseOther obj = new Master.frmExpenseOther();
            obj.WindowState = FormWindowState.Maximized;
            obj.MdiParent = this;
            obj.Show();
        }

        private void cashReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Master.frmRptCashReport obj = new Master.frmRptCashReport();
            obj.WindowState = FormWindowState.Maximized;
            obj.MdiParent = this;
            obj.Show();
        }

        private void v10ReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Inventory.Reports.frmItemDetailStock obj = new Inventory.Reports.frmItemDetailStock();
            obj.WindowState = FormWindowState.Maximized;
            obj.MenufecturingReport = true;
            obj.MdiParent = this;
            obj.Show();
        }

        private void vendorInvoiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void addGeneralVendorToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Master.frmVendorG obj = new Master.frmVendorG();
            obj.WindowState = FormWindowState.Maximized;
            obj.MdiParent = this;
            obj.Show();
        }

        private void generalVendorLedgerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Master.frmRptVendorLedger obj = new Master.frmRptVendorLedger();
            obj.WindowState = FormWindowState.Maximized;
            obj.MdiParent = this;
            obj.Show();
        }

        private void generalVendorEntryToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Master.frmVendorGLiability obj = new Master.frmVendorGLiability();
            obj.WindowState = FormWindowState.Maximized;
            obj.MdiParent = this;
            obj.Show();
        }

        private void generalVendorInvoiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Inventory.frmSale obj = new Inventory.frmSale();
            obj.WindowState = FormWindowState.Maximized;
            obj.MdiParent = this;
            obj.Show();
        }

        private void expenseListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Master.frmExpenseList obj = new Master.frmExpenseList();
            obj.WindowState = FormWindowState.Maximized;
            obj.MdiParent = this;
            obj.Show();
        }

        private void additionalAccountListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Master.frmAdditionalAccount obj = new Master.frmAdditionalAccount();
            obj.WindowState = FormWindowState.Maximized;
            obj.MdiParent = this;
            obj.Show();
        }

        private void additionalBankingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Master.frmAdditionalAccountTransaction obj = new Master.frmAdditionalAccountTransaction();
            obj.WindowState = FormWindowState.Maximized;
            obj.MdiParent = this;
            obj.Show();
        }

        private void additionalAccountLedgerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Master.frmRptAdditionalAccountLedger obj = new Master.frmRptAdditionalAccountLedger();
            obj.WindowState = FormWindowState.Maximized;
            obj.MdiParent = this;
            obj.Show();
        }

        private void balanceDetailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Master.frmBalanceDetail obj = new Master.frmBalanceDetail();
            obj.WindowState = FormWindowState.Maximized;
            obj.MdiParent = this;
            obj.Show();
        }

        private void balanceDetailTransactionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Master.frmBalanceDetailTransaction obj = new Master.frmBalanceDetailTransaction();
            obj.WindowState = FormWindowState.Maximized;
            obj.MdiParent = this;
            obj.Show();
        }

        private void balanceDetailSummaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Master.frmRptBalanceDetailSummary obj = new Master.frmRptBalanceDetailSummary();
            obj.WindowState = FormWindowState.Maximized;
            obj.MdiParent = this;
            obj.Show();
        }

        private void workshopAccountListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Master.frmWorkshopAccount obj = new Master.frmWorkshopAccount();
            obj.WindowState = FormWindowState.Maximized;
            obj.MdiParent = this;
            obj.Show();
        }

        private void workshopTransactionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Master.frmWorkshopTransaction obj = new Master.frmWorkshopTransaction();
            obj.WindowState = FormWindowState.Maximized;
            obj.MdiParent = this;
            obj.Show();
        }

        private void workshopLedgerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Master.frmRptWorkshopLedger obj = new Master.frmRptWorkshopLedger();
            obj.WindowState = FormWindowState.Maximized;
            obj.MdiParent = this;
            obj.Show();
        }

        private void branchesDailyCashToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Inventory.Reports.frmRptBranchesDailyCash obj = new Inventory.Reports.frmRptBranchesDailyCash();
            obj.ShowDialog();
        }

        private void negativeStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Inventory.Reports.frmRptNegative obj = new Inventory.Reports.frmRptNegative();
            obj.WindowState = FormWindowState.Maximized;
            obj.MdiParent = this;
            obj.Show();
        }

        private void banksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Master.frmBanks obj = new Master.frmBanks();
            obj.WindowState = FormWindowState.Maximized;
            obj.MdiParent = this;
            obj.Show();
        }

        private void userLogsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Inventory.Reports.frmRptLogs obj = new Inventory.Reports.frmRptLogs();
            obj.WindowState = FormWindowState.Maximized;
            obj.MdiParent = this;
            obj.Show();
        }

        private void salaryALLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Master.frmEmployeeSalary obj = new Master.frmEmployeeSalary();
            obj.groupId = 6;
            obj.allGroup = 1;
            obj.WindowState = FormWindowState.Maximized;
            obj.MdiParent = this;
            obj.Show();
        }

        private void branchesStockToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Master.frmBranchItems obj = new Master.frmBranchItems();
            obj.WindowState = FormWindowState.Maximized;
            obj.MdiParent = this;
            obj.Show();
        }

        private void promotionalItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Master.frmOffers obj = new Master.frmOffers();
            obj.WindowState = FormWindowState.Maximized;
            obj.MdiParent = this;
            obj.Show();
        }

        private void promotionalItemToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                Master.frmRptOfferItems obj = new Master.frmRptOfferItems();
                //obj.MdiParent = this.MdiParent;
                obj.WindowState = FormWindowState.Maximized;
                obj.MdiParent = this;
                obj.Show();
            }
            catch (Exception ex)
            {

            }
        }

        private void promotionalItemToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            try
            {
                Master.frmOffers obj = new Master.frmOffers();
                obj.WindowState = FormWindowState.Maximized;
                obj.MdiParent = this;
                obj.Show();
            }
            catch (Exception ex)
            {

            }
        }

        private void vendorLedgerToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Master.frmRptVendorDetailReport obj = new Master.frmRptVendorDetailReport();
            obj.WindowState = FormWindowState.Maximized;
            obj.MdiParent = this;
            obj.Show();
        }

        private void bankLedgerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Master.frmRptBankLedger obj = new Master.frmRptBankLedger();
            obj.WindowState = FormWindowState.Maximized;
            obj.MdiParent = this;
            obj.Show();
        }
    }
}
