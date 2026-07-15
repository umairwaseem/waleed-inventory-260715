using Ncsln.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Ncsln.Stock.Reports
{
    public partial class frmRptStockInOut : Form
    {
        CoreClass ObjCore;
        public int hideItem = 0;
        public frmRptStockInOut()
        {
            InitializeComponent();
            this.ObjCore = new CoreClass();
        }

        private void frmRptStockInOut_Load(object sender, EventArgs e)
        {
            try
            {
                this.ObjCore.fillComboBoxWithReports(this.cmbItem, "Select Id, Code + ' ' + Name + ' (' + Convert(Nvarchar(50), Id) + ')' as Name from ItemList where Hide = '" + this.hideItem.ToString() + "'", this.ObjCore.getHBCConnectionString());
            }
            catch (Exception)
            {
                
            }
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.cmbItem.SelectedValue == null || this.cmbItem.SelectedValue.ToString() == "-1")
                {
                    this.dsStockLedger1.Clear();
                    this.dsStockLedger1.EnforceConstraints = false;
                    this.daStockLedger.SelectCommand.Connection.ConnectionString = this.ObjCore.getHBCConnectionString();
                    this.daStockLedger.SelectCommand.Parameters["@Hide"].Value = (this.hideItem == 0) ? false : true;
                    this.daStockLedger.Fill(this.dsStockLedger1);
                }
                else
                {
                    this.dsStockLedger1.Clear();
                    this.dsStockLedger1.EnforceConstraints = false;
                    this.daStockLedgerSelected.SelectCommand.Connection.ConnectionString = this.ObjCore.getHBCConnectionString();
                    this.daStockLedgerSelected.SelectCommand.Parameters["@Id"].Value = this.cmbItem.SelectedValue.ToString();
                    this.daStockLedgerSelected.Fill(this.dsStockLedger1);
                }

                docStockLedger rpt = new docStockLedger();
                rpt.SetDataSource(this.dsStockLedger1);
                this.crv.ReportSource = rpt;
            }
            catch (Exception ex)
            {

            }
        }
    }
}
