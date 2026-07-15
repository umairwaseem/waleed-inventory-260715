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
using System.Data.Entity.Core.Objects.DataClasses;

namespace Ncsln.Inventory
{
    public partial class frmSaleReceive : Form
    {
        DBModel.InventoryEntities DB;
        DBModel.SaleReceive model;
        DBModel.vSale data;
        public int Sale_id;
        Classes.CoreClass ObjCore;

        public frmSaleReceive()
        {
            InitializeComponent();
            
            this.model = new DBModel.SaleReceive();
            this.data = new DBModel.vSale();
            this.ObjCore = new Classes.CoreClass();
        }

        private void frmItem_Load(object sender, EventArgs e)
        {
            this.DB.Database.Connection.ConnectionString = this.ObjCore.getConnectionString();
            this.LoadDg();

            this.LoadSale();
            
            this.model.Id = -1;
        }

        private void LoadSale()
        {
            using (this.DB = new DBModel.InventoryEntities(this.ObjCore.getClientConnectionStringName()))
            {
                this.data = this.DB.vSales.Where(x => x.Id == this.Sale_id).FirstOrDefault();
                this.txtBalance.Text = this.data.Balance.ToString();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.txtAmount.Value < 1)
            {
                MessageBox.Show("The amount should be greater then 0", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtAmount.Focus();
                return;
            }

            this.SaveUpdate();
        }

        private void SaveUpdate()
        {
            if(!CommonTask.Question(this.model.Id)) return;

            using (this.DB = new DBModel.InventoryEntities(this.ObjCore.getClientConnectionStringName()))
            {
                this.model.Sale_Id = this.Sale_id;
                this.model.SaleDate = this.dtpDate.Value;
                this.model.Amount = this.txtAmount.Value;
                this.model.Description = this.txtNote.Text.Trim();
                if (this.model.Id == -1)
                    this.DB.SaleReceives.Add(this.model);
                else
                    this.DB.Entry(this.model).State = EntityState.Modified;                
                this.DB.SaveChanges();
            }
            this.ClearForm();
            this.LoadSale();
            this.LoadDg();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.ClearForm();
        }

        private void ClearForm()
        {
            this.txtBalance.Text = "0";
            this.txtAmount.Value = 0;
            this.txtNote.Text = "";
            this.btnSave.Text = "Save";
            this.model.Id = -1;
        }

        private void LoadDg()
        {
            this.dsSaleReceive1.Clear();
            this.AD.SelectCommand.Connection.ConnectionString = this.ObjCore.getConnectionString();
            this.AD.SelectCommand.Parameters["@id"].Value = this.Sale_id;
            this.AD.Fill(this.dsSaleReceive1);
        }

        private void dg_DoubleClick(object sender, EventArgs e)
        {
            if (this.dg.CurrentRow.Index != -1)
            {
                this.model.Id = Convert.ToInt32(this.dg.CurrentRow.Cells["id"].Value);
                using (this.DB = new DBModel.InventoryEntities(this.ObjCore.getClientConnectionStringName()))
                {
                    this.model = this.DB.SaleReceives.Where(x => x.Id == this.model.Id).FirstOrDefault();
                    this.dtpDate.Value = (DateTime)this.model.SaleDate;
                    this.txtNote.Text = this.model.Description;
                    this.txtAmount.Value = (decimal)this.model.Amount;
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
                    if (!CommonTask.Question(this.model.Id, true)) return;

                    using (this.DB = new DBModel.InventoryEntities(this.ObjCore.getClientConnectionStringName()))
                    {
                        int value = Convert.ToInt32(this.dg.CurrentRow.Cells["id"].Value.ToString());
                        this.model.Id = value;
                        this.DB.Entry(this.model).State = EntityState.Deleted;
                        this.DB.SaveChanges();
                        this.ClearForm();
                        this.LoadDg();
                        this.LoadSale();
                    }
                }
            }
        }
    }
}
