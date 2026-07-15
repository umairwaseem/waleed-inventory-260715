using Ncsln.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Ncsln.Manufacturing.Reports
{
    public partial class frmRptItemsStock : Form
    {
        CoreClass ObjCore;

        public frmRptItemsStock()
        {
            InitializeComponent();
            this.ObjCore = new CoreClass();
        }

        private void frmRptItemsStock_Load(object sender, EventArgs e)
        {
            this.ObjCore.fillComboBoxWithReports(this.cmbItems, "Select Id, Code + ' ' + Name + ' (' + Convert(Nvarchar(50), Id) + ')' as Name From ItemList");
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            try
            {
                

                if (this.cmbItems.SelectedValue.ToString() == "-1")
                {
                    this.dsMItemsStock1.Clear();
                    this.daMItemsStock.SelectCommand.Connection.ConnectionString = this.ObjCore.getConnectionString();
                    this.daMItemsStock.Fill(this.dsMItemsStock1);

                }
                else
                {
                    this.dsMItemsStock1.Clear();
                    this.daMItemsStockSelected.SelectCommand.Connection.ConnectionString = this.ObjCore.getConnectionString();
                    this.daMItemsStockSelected.SelectCommand.Parameters["@Id"].Value = this.cmbItems.SelectedValue.ToString();
                    this.daMItemsStockSelected.Fill(this.dsMItemsStock1);
                }

                docMItemsStock rpt = new docMItemsStock();
                rpt.SetDataSource(this.dsMItemsStock1);
                this.crv.ReportSource = rpt;
            }
            catch (Exception ex)
            {

                
            }
        }
    }
}
