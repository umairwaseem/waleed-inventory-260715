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
    public partial class frmOrderReceive : Form
    {
        DBModel.InventoryEntities DB;
        DBModel.OrderReceive model;
        DBModel.vOrder data;
        public int Order_id;
        Classes.CoreClass ObjCore;

        public frmOrderReceive()
        {
            InitializeComponent();
            
            this.model = new DBModel.OrderReceive();
            this.data = new DBModel.vOrder();
            this.ObjCore = new Classes.CoreClass();
        }

        private void frmItem_Load(object sender, EventArgs e)
        {
            this.LoadDg();

            this.LoadOrder();
            
            this.model.Id = -1;
        }

        private void LoadOrder()
        {
            using (this.DB = new DBModel.InventoryEntities(this.ObjCore.getClientConnectionStringName()))
            {
                this.data = this.DB.vOrders.Where(x => x.Id == this.Order_id).FirstOrDefault();
                this.txtBalance.Text = this.data.Balance.ToString();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ObjCore.TimeEntryLock(this.dtpDate.Value)) return;

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

            if (this.model.Id == -1)
            {
                this.ObjCore.RecoardLogs("Payment added order # : " + this.Order_id.ToString(), "Order Receive");
            }
            else
            {
                this.ObjCore.RecoardLogs("Payment updated order # : " + this.Order_id.ToString(), "Order Receive");
            }

            using (this.DB = new DBModel.InventoryEntities(this.ObjCore.getClientConnectionStringName()))
            {
                this.model.Order_Id = this.Order_id;
                this.model.OrderDate = this.dtpDate.Value;
                this.model.Amount = this.txtAmount.Value;
                this.model.Description = this.txtNote.Text.Trim();
                this.model.OType = (this.rbtReceive.Checked) ? "R" : "P";
                if (this.model.Id == -1)
                    this.DB.OrderReceives.Add(this.model);
                else
                    this.DB.Entry(this.model).State = EntityState.Modified;                
                this.DB.SaveChanges();
            }
            this.ClearForm();
            this.LoadOrder();
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
            this.rbtReceive.Checked = true;
            this.rbtPay.Checked = false;
            this.model.Id = -1;
        }

        private void LoadDg()
        {
            this.dsOrderReceive.Clear();
            this.AD.SelectCommand.Connection.ConnectionString = this.ObjCore.getClientConnectionString();
            this.AD.SelectCommand.Parameters["@id"].Value = this.Order_id;
            this.AD.Fill(this.dsOrderReceive);
        }

        private void dg_DoubleClick(object sender, EventArgs e)
        {
            if (this.dg.CurrentRow.Index != -1)
            {
                this.model.Id = Convert.ToInt32(this.dg.CurrentRow.Cells["id"].Value);
                using (this.DB = new DBModel.InventoryEntities(this.ObjCore.getClientConnectionStringName()))
                {
                    this.model = this.DB.OrderReceives.Where(x => x.Id == this.model.Id).FirstOrDefault();
                    this.dtpDate.Value = (DateTime)this.model.OrderDate;
                    this.txtNote.Text = this.model.Description;
                    this.txtAmount.Value = (decimal)this.model.Amount;
                    if (this.model.OType == "R")
                    {
                        this.rbtReceive.Checked = true;
                        this.rbtPay.Checked = false;
                    }
                    else
                    {
                        this.rbtReceive.Checked = false;
                        this.rbtPay.Checked = true;
                    }
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
                    if (!this.ObjCore.TimeEntryLock(DateTime.Now)) return;

                    if (!CommonTask.Question(this.model.Id, true)) return;

                    using (this.DB = new DBModel.InventoryEntities(this.ObjCore.getClientConnectionStringName()))
                    {
                        int value = Convert.ToInt32(this.dg.CurrentRow.Cells["id"].Value.ToString());
                        this.model.Id = value;
                        this.DB.Entry(this.model).State = EntityState.Deleted;
                        this.DB.SaveChanges();
                        this.ClearForm();
                        this.LoadDg();
                        this.LoadOrder();
                    }
                }
            }
        }

        private void dg_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                this.dg.ClearSelection();
                for (int i = 0; i < this.dg.Rows.Count; i++)
                {
                    if (this.dg.Rows[i].Cells["OType"].Value.ToString() == "R"){
                        this.dg.Rows[i].DefaultCellStyle.BackColor = Color.AliceBlue;
                        this.dg.Rows[i].Cells["Type"].Value = "Received";
                    }
                    else
                    {
                        this.dg.Rows[i].DefaultCellStyle.BackColor = Color.Beige;
                        this.dg.Rows[i].Cells["Type"].Value = "Paid";
                    }
                        
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            Reports.frmOrderPaymentDetail obj = new Reports.frmOrderPaymentDetail();
            obj.Id = this.Order_id.ToString();
            obj.MdiParent = this.MdiParent;
            obj.Show();
        }
    }
}
