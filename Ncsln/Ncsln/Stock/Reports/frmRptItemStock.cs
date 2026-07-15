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
    public partial class frmRptItemStock : Form
    {
        CoreClass ObjCore;
        public bool hideItems = false;
        public frmRptItemStock()
        {
            InitializeComponent();
            this.ObjCore = new CoreClass();
        }

        private void frmRptItemStock_Load(object sender, EventArgs e)
        {
            try
            {
                if (!this.hideItems)
                {
                    this.ObjCore.fillComboBoxWithReports(this.cmbItems, "Select Id, Code + ' ' + Name + ' (' + Convert(Nvarchar(50), Id) + ')' as Name From ItemList where Hide = 0", this.ObjCore.getHBCConnectionString());
                }
                else
                {
                    this.ObjCore.fillComboBoxWithReports(this.cmbItems, "Select Id, Code + ' ' + Name + ' (' + Convert(Nvarchar(50), Id) + ')' as Name From ItemList where hide = 1", this.ObjCore.getHBCConnectionString());
                }

                
            }
            catch (Exception ex)
            {

            }
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.cmbItems.SelectedValue.ToString() == "-1")
                {
                    if (this.chkZero.Checked)
                    {
                        this.dsSStock1.Clear();
                        this.daSStock.SelectCommand.Connection.ConnectionString = this.ObjCore.getHBCConnectionString();
                        if (this.hideItems)
                        {
                            this.daSStock.SelectCommand.CommandText = "SELECT Id, Name, Code, PurchasePrice, Stock FROM vSStock where Stock = 0 and Id in (select Id from ItemList where Hide = 1) Order by Name";
                        }
                        else
                        {
                            this.daSStock.SelectCommand.CommandText = "SELECT Id, Name, Code, PurchasePrice, Stock FROM vSStock where Stock = 0 and Id in (select Id from ItemList where Hide = 0) Order by Name";
                        }
                        this.daSStock.Fill(this.dsSStock1);
                    }
                    else
                    {
                        if (this.chkWithOutZero.Checked)
                        {
                            this.dsSStock1.Clear();
                            this.daSStock.SelectCommand.Connection.ConnectionString = this.ObjCore.getHBCConnectionString();
                            if (this.hideItems)
                            {
                                this.daSStock.SelectCommand.CommandText = "SELECT Id, Name, Code, PurchasePrice, Stock FROM vSStock where Stock <> 0 and Id in (select Id from ItemList where Hide = 1) Order by Name";
                            }
                            else
                            {
                                this.daSStock.SelectCommand.CommandText = "SELECT Id, Name, Code, PurchasePrice, Stock FROM vSStock where Stock <> 0 and Id in (select Id from ItemList where Hide = 0) Order by Name";
                            }
                            this.daSStock.Fill(this.dsSStock1);
                        }
                        else
                        {

                            this.dsSStock1.Clear();
                            this.daSStock.SelectCommand.Connection.ConnectionString = this.ObjCore.getHBCConnectionString();
                            if (this.hideItems)
                            {
                                this.daSStock.SelectCommand.CommandText = "SELECT Id, Name, Code, PurchasePrice, Stock FROM vSStock where Id in (select Id from ItemList where Hide = 1) Order by Name";
                            }
                            else
                            {
                                this.daSStock.SelectCommand.CommandText = "SELECT Id, Name, Code, PurchasePrice, Stock FROM vSStock where Id in (select Id from ItemList where Hide = 0) Order by Name";
                            }
                            this.daSStock.Fill(this.dsSStock1);
                        }
                    }                    
                }
                else
                {
                    this.dsSStock1.Clear();
                    this.daSStockSelected.SelectCommand.Connection.ConnectionString = this.ObjCore.getHBCConnectionString();
                    this.daSStockSelected.SelectCommand.Parameters["@Id"].Value = this.cmbItems.SelectedValue.ToString();
                    this.daSStockSelected.Fill(this.dsSStock1);
                }

                docSStock rpt = new docSStock();
                rpt.SetDataSource(this.dsSStock1);
                this.crv.ReportSource = rpt;
            }
            catch (Exception ex)
            {

            }
        }

        private void chkZero_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkWithOutZero.Checked)
                this.chkWithOutZero.Checked = !this.chkZero.Checked;
        }

        private void chkWithOutZero_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkZero.Checked)
                this.chkZero.Checked = !this.chkWithOutZero.Checked;
        }
    }
}
