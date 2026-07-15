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
    public partial class frmSaleInvoice : Form
    {

        CoreClass objCore;
        InventoryEntities DB;
        public int Id { get; set; }
        public bool DeliveryChallan { get; set; }

        public frmSaleInvoice()
        {
            InitializeComponent();
            this.objCore = new CoreClass();
            this.DeliveryChallan = false;
            this.DB = new InventoryEntities(this.objCore.getClientConnectionStringName());
        }

        private void frmSaleInvoice_Load(object sender, EventArgs e)
        {
            try
            {
                if (this.DeliveryChallan)
                {
                    decimal PayBack = 0, ReceiveAmount = 0, Receive = 0;
                    this.dsSaleInvoice1.Clear();
                    this.dsSaleInvoice1.EnforceConstraints = false;
                    this.daSaleDelivered.SelectCommand.Connection.ConnectionString = this.objCore.getClientConnectionString();
                    this.daSaleDelivered.SelectCommand.Parameters["@Id"].Value = this.Id;
                    this.daSaleDelivered.Fill(this.dsSaleInvoice1);

                    //using (this.DB = new InventoryEntities())
                    //{
                    //    PayBack = this.DB.Database.SqlQuery<decimal>("select dbo.funOrderPayBack(" + this.Id + ")").FirstOrDefault();

                    //    ReceiveAmount = this.DB.Database.SqlQuery<decimal>("select dbo.funOrderReceive(" + this.Id.ToString() + ")").FirstOrDefault();

                    //}

                    Receive = ReceiveAmount - PayBack;


                    docSaleDelivered rpt = new docSaleDelivered();
                    rpt.SetDataSource(this.dsSaleInvoice1);
                    rpt.SetParameterValue("TotalReceive", Receive);
                    this.crv.ReportSource = rpt;
                }
                else
                {
                    decimal PayBack = 0, ReceiveAmount = 0, Receive = 0;
                    this.dsSaleInvoice1.Clear();
                    this.dsSaleInvoice1.EnforceConstraints = false;
                    this.daSaleInvoice.SelectCommand.Connection.ConnectionString = this.objCore.getClientConnectionString();
                    this.daSaleInvoice.SelectCommand.Parameters["@Id"].Value = this.Id;
                    this.daSaleInvoice.Fill(this.dsSaleInvoice1);

                    using (this.DB = new InventoryEntities(this.objCore.getClientConnectionStringName()))
                    {
                        PayBack = this.DB.Database.SqlQuery<decimal>("select dbo.funOrderPayBack(" + this.Id + ")").FirstOrDefault();

                        ReceiveAmount = this.DB.Database.SqlQuery<decimal>("select dbo.funOrderReceive(" + this.Id.ToString() + ")").FirstOrDefault();

                    }

                    Receive = ReceiveAmount - PayBack;

                    docSaleInvoice rpt = new docSaleInvoice();
                    rpt.SetDataSource(this.dsSaleInvoice1);
                    rpt.SetParameterValue("TotalReceive", Receive);
                    this.crv.ReportSource = rpt;
                }
            }
            catch (Exception ex)
            {
                
            }
        }
    }
}
