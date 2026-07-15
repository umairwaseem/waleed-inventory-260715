using Ncsln.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Ncsln.Inventory
{
    public partial class frmPRInvoice : Form
    {
        DBModel.InventoryEntities DB;
        DBModel.PRInvoice model;
        Classes.CoreClass ObjCore;
        public bool quickCall = false;

        public frmPRInvoice()
        {
            InitializeComponent();
            
            this.model = new DBModel.PRInvoice();
            this.ObjCore = new Classes.CoreClass();
        }

        private void frmItem_Load(object sender, EventArgs e)
        {
            this.LoadDg();
            this.model.Id = -1;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ObjCore.TimeEntryLock(this.dtp.Value)) return;

            this.Calculation();
            if (!this.ObjCore.CheckRight(21, this.model.Id))
            {
                return;
            }

            if (this.txtDetail.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please inovice detail", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtDetail.Focus();
                return;
            }

            if (this.txtPrice.Value < 1)
            {
                MessageBox.Show("The invoice price cannot be zero!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtPrice.Focus();
                return;
            }

            this.SaveUpdate();
        }

        private void SaveUpdate()
        {
            if (!CommonTask.Question(this.model.Id)) return;

            int? InvoiceNo = 0;

            using (this.DB = new DBModel.InventoryEntities(this.ObjCore.getClientConnectionStringName()))
            {
                var obj = this.DB.PRInvoices.FirstOrDefault();
                if (this.model.Id == -1)
                {
                    if (obj != null)
                    {
                        InvoiceNo = Convert.ToInt32(this.DB.PRInvoices.Max(c => (int?)c.InvoviceNo).Value);
                        InvoiceNo++;
                        this.txtInvoiceNo.Text = InvoiceNo.ToString();
                    }
                    else
                    {
                        InvoiceNo++;
                        this.txtInvoiceNo.Text = InvoiceNo.ToString();
                    }
                }

                this.model.Detail = this.txtDetail.Text.Trim();
                this.model.Cost = this.txtCost.Value;
                this.model.ExtraDetail = this.txtExtraDetail.Text.Trim();
                this.model.Extra = this.txtExtra.Value;
                this.model.Price = this.txtPrice.Value;
                this.model.InvoiceDate = this.dtp.Value;
                this.model.InvoviceNo = Convert.ToInt32(this.txtInvoiceNo.Text);
                this.model.TotalPrice = this.txtTotal.Value;
                if (this.model.Id == -1)
                {
                    this.DB.PRInvoices.Add(this.model);
                } else {
                    this.DB.Entry(this.model).State = EntityState.Modified;
                }
                this.DB.SaveChanges();
            }
            this.ClearForm();
            this.LoadDg();
        }

        private void Calculation()
        {
            try
            {
                decimal cost = this.txtCost.Value, extra = this.txtExtra.Value, price = this.txtPrice.Value, balance;
                balance = (price + extra) - cost;
                this.txtTotal.Value = balance;
            }
            catch (Exception ex)
            {

            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.ClearForm();
        }

        private void ClearForm()
        {
            this.txtDetail.Text = this.txtExtraDetail.Text = "";
            this.txtCost.Value = this.txtExtra.Value = this.txtPrice.Value = 0;
            this.dtp.Value = DateTime.Now;
            this.btnSave.Text = "Save";
            this.model.Id = -1;
        }

        private void LoadDg()
        {
            this.dsPRInvoice1.Clear();
            this.daPRInvoice.SelectCommand.Connection.ConnectionString = this.ObjCore.getClientConnectionString();
            this.daPRInvoice.Fill(this.dsPRInvoice1);
        }

        private void dg_DoubleClick(object sender, EventArgs e)
        {
            if (this.dg.CurrentRow.Index != -1)
            {
                this.model.Id = Convert.ToInt32(this.dg.CurrentRow.Cells["id"].Value);
                using (this.DB = new DBModel.InventoryEntities(this.ObjCore.getClientConnectionStringName()))
                {
                    this.model = this.DB.PRInvoices.Where(x => x.Id == this.model.Id).FirstOrDefault();
                    this.txtDetail.Text = this.model.Detail;
                    this.txtCost.Value = (decimal)this.model.Cost;
                    this.txtExtraDetail.Text = this.model.ExtraDetail;
                    this.txtExtra.Value = (decimal)this.model.Extra;
                    this.txtPrice.Value = (decimal)this.model.Price;
                    this.dtp.Value = (DateTime)this.model.InvoiceDate;
                    this.txtInvoiceNo.Text = this.model.InvoviceNo.ToString();
                    this.btnSave.Text = "Update";
                }
            }
        }

        private void dg_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dg.CurrentRow.Index != -1)
            {
                if (e.ColumnIndex == this.dg.Columns["Delete"].Index)
                {
                    if (!this.ObjCore.CheckRight(21, this.model.Id, true))
                    {
                        return;
                    }

                    if (!CommonTask.Question(this.model.Id, true)) return;

                    using (this.DB = new DBModel.InventoryEntities(this.ObjCore.getClientConnectionStringName()))
                    {
                        int value = Convert.ToInt32(this.dg.CurrentRow.Cells["id"].Value.ToString());
                        this.model.Id = value;
                        this.DB.Entry(this.model).State = EntityState.Deleted;
                        this.DB.SaveChanges();
                        this.ClearForm();
                        this.LoadDg();
                    }
                }

                if (e.ColumnIndex == this.dg.Columns["Edit"].Index)
                {
                    this.model.Id = Convert.ToInt32(this.dg.CurrentRow.Cells["id"].Value);
                    using (this.DB = new DBModel.InventoryEntities(this.ObjCore.getClientConnectionStringName()))
                    {
                        this.model = this.DB.PRInvoices.Where(x => x.Id == this.model.Id).FirstOrDefault();
                        this.txtDetail.Text = this.model.Detail;
                        this.txtCost.Value = (decimal)this.model.Cost;
                        this.txtExtraDetail.Text = this.model.ExtraDetail;
                        this.txtExtra.Value = (decimal)this.model.Extra;
                        this.txtPrice.Value = (decimal)this.model.Price;
                        this.dtp.Value = (DateTime)this.model.InvoiceDate;
                        this.txtInvoiceNo.Text = this.model.InvoviceNo.ToString();
                        this.btnSave.Text = "Update";
                    }

                    //Reports.frmRptClientSale obj = new Reports.frmRptClientSale();
                    //obj.MdiParent = this.MdiParent;
                    //obj.ClientId = Convert.ToInt32(this.dg.CurrentRow.Cells["clientId"].Value.ToString());
                    //obj.Show();
                }
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.dsPRInvoice1.Clear();
                this.daPRInvoiceSearch.SelectCommand.Connection.ConnectionString = this.ObjCore.getClientConnectionString();
                this.daPRInvoiceSearch.SelectCommand.Parameters["@key"].Value = this.txtSearch.Text.Trim();
                this.daPRInvoiceSearch.Fill(this.dsPRInvoice1);
            }
            catch (Exception ex)
            {

            }
        }

        private void txtCost_ValueChanged(object sender, EventArgs e)
        {
            this.Calculation();
        }

        private void txtExtra_ValueChanged(object sender, EventArgs e)
        {
            this.Calculation();
        }

        private void txtPrice_ValueChanged(object sender, EventArgs e)
        {
            this.Calculation();
        }
    }
}
