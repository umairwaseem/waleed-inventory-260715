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
    public partial class frmRptFinishGoodStock : Form
    {
        CoreClass ObjCore;

        public frmRptFinishGoodStock()
        {
            InitializeComponent();
            this.ObjCore = new CoreClass();
        }

        private void frmRptFinishGoodStock_Load(object sender, EventArgs e)
        {
            try
            {
                this.ObjCore.fillComboBoxWithReports(this.cmbItems, "Select Id, Detail + ' (' + Convert(Nvarchar(50), Id) + ')' From MFinishGoods");
                //this.ObjCore.fillComboBoxWithReports(this.cmbItems, "Select Id, Name + ' (' + Convert(Nvarchar(50), Id) + ')' From ItemList Where Id in (Select ItemId from MFinishGoodsStock)");
            }
            catch (Exception ex)
            {

            }
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.rbtnStock.Checked)
                {
                    if (this.cmbItems.SelectedValue.ToString() == "-1")
                    {
                        this.dsMFinishGoods1.Clear();
                        this.daMFinishGoods.SelectCommand.Connection.ConnectionString = this.ObjCore.getConnectionString();
                        this.daMFinishGoods.Fill(this.dsMFinishGoods1);
                    }
                    else
                    {
                        this.dsMFinishGoods1.Clear();
                        this.daMFinishGoodsSelected.SelectCommand.Connection.ConnectionString = this.ObjCore.getConnectionString();
                        this.daMFinishGoodsSelected.SelectCommand.Parameters["@Id"].Value = this.cmbItems.SelectedValue.ToString();
                        this.daMFinishGoodsSelected.Fill(this.dsMFinishGoods1);
                    }

                    docMFinsihGoods rpt = new docMFinsihGoods();
                    rpt.SetDataSource(this.dsMFinishGoods1);
                    this.crv.ReportSource = rpt;
                }
                else
                {
                    if (this.cmbItems.SelectedValue.ToString() == "-1")
                    {
                        this.dsMFinishGoodsOut1.Clear();
                        this.daMFinishGoodsOut.SelectCommand.Connection.ConnectionString = this.ObjCore.getConnectionString();
                        this.daMFinishGoodsOut.Fill(this.dsMFinishGoodsOut1);
                    }
                    else
                    {
                        this.dsMFinishGoodsOut1.Clear();
                        this.daMFinishGoodsOutSelected.SelectCommand.Connection.ConnectionString = this.ObjCore.getConnectionString();
                        this.daMFinishGoodsOutSelected.SelectCommand.Parameters["@Id"].Value = this.cmbItems.SelectedValue.ToString();
                        this.daMFinishGoodsOutSelected.Fill(this.dsMFinishGoodsOut1);
                    }

                    docMFinishGoodOut rpt = new docMFinishGoodOut();
                    rpt.SetDataSource(this.dsMFinishGoodsOut1);
                    this.crv.ReportSource = rpt;
                }
                
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
