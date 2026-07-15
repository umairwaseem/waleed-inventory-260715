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
    public partial class frmItemDetailStock : Form
    {
        CoreClass objCore;
        public bool MenufecturingReport { get; set; }
        public frmItemDetailStock()
        {
            InitializeComponent();
            this.objCore = new CoreClass();
            this.MenufecturingReport = false;
        }

        private void frmItemDetailStock_Load(object sender, EventArgs e)
        {
            this.objCore.fillComboBoxWithReports(this.cmbItems, "Select ItemId, Code + ' ' + Title + ' (' + Convert(Nvarchar(50), ItemId) + ')' from items where ItemId > 10000 and Hide = 0", this.objCore.getClientConnectionString());

            this.label3.Visible = this.cmbItems.Visible = !this.MenufecturingReport;
            this.Text = (!this.MenufecturingReport) ? "Item Detail Stock" : "Item Detail Stock V10";
            
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            try
            {
                if (!this.MenufecturingReport)
                {
                    if (this.cmbItems.SelectedValue.ToString() == "-1")
                    {
                        this.dsItemDetialStock1.Clear();
                        this.daItemDetailStock.SelectCommand.Connection.ConnectionString = this.objCore.getClientConnectionString();
                        this.daItemDetailStock.SelectCommand.Parameters["@from"].Value = this.dtpFrom.Value.ToShortDateString();
                        this.daItemDetailStock.SelectCommand.Parameters["@to"].Value = this.dtpTo.Value.ToShortDateString();
                        this.daItemDetailStock.Fill(this.dsItemDetialStock1);

                        docItemDetailStock rpt = new docItemDetailStock();
                        rpt.SetDataSource(this.dsItemDetialStock1);
                        this.crv.ReportSource = rpt;
                    }
                    else
                    {
                        this.dsItemDetialStock1.Clear();
                        this.daItemDetailStockOne.SelectCommand.Connection.ConnectionString = this.objCore.getClientConnectionString();
                        this.daItemDetailStockOne.SelectCommand.Parameters["@from"].Value = this.dtpFrom.Value.ToShortDateString();
                        this.daItemDetailStockOne.SelectCommand.Parameters["@to"].Value = this.dtpTo.Value.ToShortDateString();
                        this.daItemDetailStockOne.SelectCommand.Parameters["@ItemId"].Value = this.cmbItems.SelectedValue.ToString();
                        this.daItemDetailStockOne.Fill(this.dsItemDetialStock1);

                        docItemDetailStock rpt = new docItemDetailStock();
                        rpt.SetDataSource(this.dsItemDetialStock1);
                        this.crv.ReportSource = rpt;
                    }
                } 
                else
                {
                    this.dsItemDetialStock1.Clear();
                    this.daItemDetailMenufecturing.SelectCommand.Connection.ConnectionString = this.objCore.getClientConnectionString();
                    this.daItemDetailMenufecturing.SelectCommand.Parameters["@from"].Value = this.dtpFrom.Value.ToShortDateString();
                    this.daItemDetailMenufecturing.SelectCommand.Parameters["@to"].Value = this.dtpTo.Value.ToShortDateString();
                    this.daItemDetailMenufecturing.Fill(this.dsItemDetialStock1);

                    docV10Report rpt = new docV10Report();
                    rpt.SetDataSource(this.dsItemDetialStock1);
                    this.crv.ReportSource = rpt;
                }

            }
            catch (Exception ex)
            {

            }
        }
    }
}
