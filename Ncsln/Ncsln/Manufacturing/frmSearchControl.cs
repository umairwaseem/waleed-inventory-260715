using Ncsln.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Ncsln.Manufacturing
{
    public partial class frmSearchControl : Form
    {
        CoreClass ObjCore;
        public string Itemid = "";
        public string modelNo = "";
        public string pprice = "";
        public string overHead = "";
        public bool Selected = false;
        public bool ForManufacturing = false;

        public frmSearchControl()
        {
            InitializeComponent();
            this.ObjCore = new CoreClass();
        }

        private void frmSearchControl_Load(object sender, EventArgs e)
        {
            this.SearchItems();
        }

        private void SearchItems()
        {
            try
            {
                if (this.ForManufacturing)
                {
                    this.dsItemSearch.Clear();
                    this.daItemSearchFromManufacturing.SelectCommand.Connection.ConnectionString = this.ObjCore.getConnectionString();
                    this.daItemSearchFromManufacturing.SelectCommand.Parameters["@key"].Value = this.txtSearchKey.Text.Trim();
                    this.daItemSearchFromManufacturing.Fill(this.dsItemSearch);
                }
                else
                {
                    this.dsItemSearch.Clear();
                    this.daItemSearch.SelectCommand.Connection.ConnectionString = this.ObjCore.getConnectionString();
                    this.daItemSearch.SelectCommand.Parameters["@key"].Value = this.txtSearchKey.Text.Trim();
                    this.daItemSearch.Fill(this.dsItemSearch);
                }
                
            }
            catch (Exception ex)
            {

            }
        }

        private void txtSearchKey_TextChanged(object sender, EventArgs e)
        {
            this.SearchItems();
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                if (e.ColumnIndex == this.dgv.Columns["Add"].Index)
                {
                    this.Itemid = this.dgv["idDataGridViewTextBoxColumn", e.RowIndex].Value.ToString();
                    this.modelNo = this.dgv["codeDataGridViewTextBoxColumn", e.RowIndex].Value.ToString();
                    this.pprice = this.dgv["purchasePriceDataGridViewTextBoxColumn", e.RowIndex].Value.ToString();
                    this.overHead = this.dgv["overHeadDataGridViewTextBoxColumn", e.RowIndex].Value.ToString();
                    this.Selected = true;
                    this.Close();
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Stock.frmSItems obj = new Stock.frmSItems();
                obj.QuickCall = true;
                obj.HBCItem = false;
                obj.ShowDialog();

                DataTable dt = this.ObjCore.getDataSet("Select * from ItemList where Id = " + obj.Id.ToString(), this.ObjCore.getHBCConnectionString()).Tables[0];

                this.Itemid = obj.Id.ToString();
                this.modelNo = dt.Rows[0]["Code"].ToString();
                this.pprice = dt.Rows[0]["PurchasePrice"].ToString();
                this.overHead = dt.Rows[0]["OverHead"].ToString();
                this.Selected = true;
                this.Close();
            }
            catch (Exception ex)
            {

            }
        }
    }
}
