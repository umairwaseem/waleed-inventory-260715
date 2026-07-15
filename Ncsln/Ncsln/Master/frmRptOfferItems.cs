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
    public partial class frmRptOfferItems : Form
    {
        CoreClass ObjCore;

        public frmRptOfferItems()
        {
            InitializeComponent();
            this.ObjCore = new CoreClass();
        }

        private void frmRptOfferItems_Load(object sender, EventArgs e)
        {
            try
            {
                this.dsOfferItemReport1.Clear();
                this.dsOfferItemReport1.EnforceConstraints = false;

                this.daOfferItemReport.SelectCommand.Connection.ConnectionString = this.ObjCore.getHBCConnectionString();
                this.daOfferItemReport.Fill(this.dsOfferItemReport1);

                docOfferItemList doc = new docOfferItemList();
                doc.SetDataSource(this.dsOfferItemReport1);
                this.crv.ReportSource = doc;
            }
            catch (Exception ex)
            {
                                
            }
        }
    }
}
