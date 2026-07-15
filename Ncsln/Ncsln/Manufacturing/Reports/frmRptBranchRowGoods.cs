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
    public partial class frmRptBranchRowGoods : Form
    {
        CoreClass ObjCore;

        public frmRptBranchRowGoods()
        {
            InitializeComponent();
            this.ObjCore = new CoreClass();
        }

        private void frmRptItemsStock_Load(object sender, EventArgs e)
        {
            //this.ObjCore.fillComboBoxWithReports(this.cmbItems, "Select Id, Code + ' ' + Name + ' (' + Convert(Nvarchar(50), Id) + ')' as Name From ItemList");
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            try
            {

                this.dsRowBranchGoods1.Clear();
                this.daRowBranchGoods.SelectCommand.Connection.ConnectionString = this.ObjCore.getHBCConnectionString();
                this.daRowBranchGoods.Fill(this.dsRowBranchGoods1);

                docRowBranchGoods rpt = new docRowBranchGoods();
                rpt.SetDataSource(this.dsRowBranchGoods1);
                this.crv.ReportSource = rpt;
                

                //docMItemsStock rpt = new docMItemsStock();
                //rpt.SetDataSource(this.dsMItemsStock1);
                //this.crv.ReportSource = rpt;
            }
            catch (Exception ex)
            {

                
            }
        }
    }
}
