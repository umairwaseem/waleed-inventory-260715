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

namespace Ncsln.Inventory
{
    public partial class frmItemSearch : Form
    {
        InventoryEntities DB;

        public int ItemId { get; set; }
        public bool Selected { get; set; }

        public bool OnlyVendor { get; set; }
        public int VendorId { get; set; }

        public decimal UnitPrice { get; set; }

        CoreClass objCore = new CoreClass();


        public frmItemSearch()
        {
            InitializeComponent();
            this.OnlyVendor = false;
        }

        private void frmItemSearch_Load(object sender, EventArgs e)
        {
            this.LoadItems();
        }

        private void LoadItems()
        {
            try
            {
                if (this.OnlyVendor && this.VendorId != 1)
                {
                    this.dsItemSearch1.Clear();
                    this.DaOnlyVendor.SelectCommand.Connection.ConnectionString = this.objCore.getClientConnectionString();
                    this.DaOnlyVendor.SelectCommand.Parameters["@key"].Value = this.txtSearch.Text.Trim();
                    this.DaOnlyVendor.SelectCommand.Parameters["@VendorId"].Value = this.VendorId;
                    this.DaOnlyVendor.Fill(this.dsItemSearch1);
                }
                else
                {

                    this.dsItemSearch1.Clear();
                    this.DA.SelectCommand.Connection.ConnectionString = this.objCore.getClientConnectionString();
                    this.DA.SelectCommand.Parameters["@key"].Value = this.txtSearch.Text.Trim();
                    this.DA.Fill(this.dsItemSearch1);
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Selected = false;
            this.Close();
        }

        private void frmItemSearch_FormClosed(object sender, FormClosedEventArgs e)
        {
            //this.Selected = false;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            this.itemsBindingSource.Filter = "Code like '%" + this.txtSearch.Text.Trim() + "%'";
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == this.dgv.Columns["Add"].Index)
                {
                    this.ItemId = Convert.ToInt32(this.dgv["id", e.RowIndex].Value);
                    this.UnitPrice = Convert.ToDecimal(this.dgv["purchasePrice", e.RowIndex].Value);
                    this.Selected = true;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            try
            {
                frmItem obj = new frmItem();
                obj.StartPosition = FormStartPosition.CenterParent;
                obj.quickCall = true;
                obj.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                obj.ShowDialog();

                if (obj.justClose)
                {
                    this.Selected = false;
                    this.Close();
                }
                else
                {
                    using (this.DB = new InventoryEntities(this.objCore.getClientConnectionStringName()))
                    {
                        var value = this.DB.Items.Max(x => x.ItemId);
                        var price = this.DB.Items.Where(x => x.ItemId == value).FirstOrDefault().PurchasePrice;
                        this.ItemId = Convert.ToInt32(value);
                        this.UnitPrice = (decimal)price;
                        this.Selected = true;
                        this.Close();
                    }
                }

                
            }
            catch (Exception ex)
            {

            }
        }
    }
}
