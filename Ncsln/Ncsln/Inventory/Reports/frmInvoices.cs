using Ncsln.Classes;
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
    public partial class frmInvoices : Form
    {
        CoreClass objCore;
        public int id = 0;
        /*
         * 1 = Purchase
         * 2 = Order
         */
        public int type = 0;

        public frmInvoices()
        {
            InitializeComponent();
            this.objCore = new CoreClass();
        }

        private void frmInvoices_Load(object sender, EventArgs e)
        {
            try
            {
                dsInvoice ds = new dsInvoice();
                ds.Clear();

                decimal TotalReceive = 0;
                decimal Balance = 0;

                string command = "";
                if (type == 1)
                    command = "Select Id, PurchaseNo as No, PurchaseDate as Date,Name as Person,Title as ItemName,Qty as Qty,UnitPrice as Price,TotalPrice as TotalPrice,ExtraDetail as ExtraDetail,ExtraAmount as ExtraAmount,0 as Payment,Description as Notes, ItemReturn from vPurchaseDetail where Id = " + this.id;
                else
                {
                    command = "select Id, OrderNo as No, OrderDate as Date,Name as Person,Title as ItemName,Qty as Qty,UnitPrice as Price,TotalPrice as TotalPrice,ExtraDetail as ExtraDetail,ExtraAmount as ExtraAmount,0 as Payment,Description as Notes, ItemReturn from vOrderDetail where Id = " + this.id;
                    DataTable dt = this.objCore.getDataSet("select dbo.funOrderReceive(" + this.id + "), dbo.funOrderBalance(" + this.id + ")").Tables[0];
                    TotalReceive = Convert.ToDecimal(dt.Rows[0][0]);
                    Balance = Convert.ToDecimal(dt.Rows[0][1]);
                }
                    

                this.daInvoice.SelectCommand.Connection.ConnectionString = this.objCore.getClientConnectionString();
                
                this.daInvoice.SelectCommand.CommandText = command;
                this.daInvoice.Fill(ds.Invoice);

                docInvoice rpt = new docInvoice();
                rpt.SetDataSource(ds);
                rpt.SetParameterValue("TotalReceive", TotalReceive);
                rpt.SetParameterValue("Balance", Balance);
                this.crv.ReportSource = rpt;
            }
            catch (Exception ex)
            {

            }
        }
    }
}
