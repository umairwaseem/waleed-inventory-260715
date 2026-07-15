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
    public partial class frmItemStock : Form
    {
        CoreClass objCore;

        public frmItemStock()
        {
            InitializeComponent();
            this.objCore = new CoreClass();
        }

        private void frmItemStock_Load(object sender, EventArgs e)
        {
            this.objCore.fillComboBoxWithReports(this.cmbItem, "Select ItemId, Code + ' ' + Title + ' (' + Convert(Nvarchar(50), ItemId) + ')' from items where ItemId > 10000 and Hide = 0", this.objCore.getClientConnectionString());
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            try
            {
                string command = "";

                if (this.cmbItem.SelectedValue.ToString() == "-1")
                {
                    command = "SELECT ItemId, Title, Decription, Code, PurchasePrice, SalePrice, Stock FROM vItems WHERE(Stock > 0)";
                } else
                {
                    command = "SELECT ItemId, Title, Decription, Code, PurchasePrice, SalePrice, Stock FROM vItems WHERE(Stock > 0) and (ItemId = '" + this.cmbItem.SelectedValue.ToString() + "')";
                }

                this.dsItemStock1.Clear();
                this.daItemStock.SelectCommand.Connection.ConnectionString = this.objCore.getClientConnectionString();
                this.daItemStock.SelectCommand.CommandText = command;
                this.daItemStock.Fill(this.dsItemStock1);

                docItemReport rpt = new docItemReport();
                rpt.SetDataSource(this.dsItemStock1);
                this.crv.ReportSource = rpt;
            }
            catch (Exception ex)
            {

            }
        }
    }
}
