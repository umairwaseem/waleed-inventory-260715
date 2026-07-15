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
    public partial class frmclient : Form
    {
        DBModel.InventoryEntities DB;
        DBModel.Client model;
        Classes.CoreClass ObjCore;
        public bool quickCall = false;

        public frmclient()
        {
            InitializeComponent();
            
            this.model = new DBModel.Client();
            this.ObjCore = new Classes.CoreClass();
        }

        private void frmItem_Load(object sender, EventArgs e)
        {
            this.LoadDg();
            this.model.ClientId = -1;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ObjCore.CheckRight(2, this.model.ClientId))
            {
                return;
            }

            if (this.txtTitle.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please enter Item Name", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtTitle.Focus();
                return;
            }

            if (this.txtPhoneNo.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please enter Item Phone", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtPhoneNo.Focus();
                return;
            }

            this.SaveUpdate();
        }

        private void SaveUpdate()
        {
            if(!CommonTask.Question(this.model.ClientId)) return;

            using (this.DB = new DBModel.InventoryEntities(this.ObjCore.getClientConnectionStringName()))
            {
                this.model.Name = this.txtTitle.Text.Trim();
                this.model.PhoneNo = this.txtPhoneNo.Text.Trim();
                this.model.Email = this.txtEmail.Text.Trim();
                this.model.Address = this.txtAddress.Text.Trim();
                this.model.DefaultEntry = false;
                if (this.model.ClientId == -1)
                    this.DB.Clients.Add(this.model);
                else
                    this.DB.Entry(this.model).State = EntityState.Modified;                
                this.DB.SaveChanges();
            }
            this.ClearForm();
            this.LoadDg();
            if (this.quickCall) this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.ClearForm();
        }

        private void ClearForm()
        {
            this.txtTitle.Text = this.txtPhoneNo.Text = this.txtEmail.Text = this.txtAddress.Text = "";
            this.btnSave.Text = "Save";
            this.model.ClientId = -1;
        }

        private void LoadDg()
        {
            this.dsClient1.Clear();
            this.AD.SelectCommand.Connection.ConnectionString = this.ObjCore.getClientConnectionString();
            this.AD.Fill(this.dsClient1);
        }

        private void dg_DoubleClick(object sender, EventArgs e)
        {
            if (this.dg.CurrentRow.Index != -1)
            {
                this.model.ClientId = Convert.ToInt32(this.dg.CurrentRow.Cells["clientId"].Value);
                using (this.DB = new DBModel.InventoryEntities(this.ObjCore.getClientConnectionStringName()))
                {
                    this.model = this.DB.Clients.Where(x => x.ClientId == this.model.ClientId).FirstOrDefault();
                    this.txtTitle.Text = this.model.Name;
                    this.txtPhoneNo.Text = this.model.PhoneNo;
                    this.txtEmail.Text = this.model.Email;
                    this.txtAddress.Text = this.model.Address;
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
                    if (!this.ObjCore.CheckRight(1, this.model.ClientId, true))
                    {
                        return;
                    }

                    if (!CommonTask.Question(this.model.ClientId, true)) return;

                    using (this.DB = new DBModel.InventoryEntities(this.ObjCore.getClientConnectionStringName()))
                    {
                        int value = Convert.ToInt32(this.dg.CurrentRow.Cells["clientId"].Value.ToString());
                        this.model.ClientId = value;
                        this.DB.Entry(this.model).State = EntityState.Deleted;
                        this.DB.SaveChanges();
                        this.ClearForm();
                        this.LoadDg();
                    }
                }

                if (e.ColumnIndex == this.dg.Columns["Report"].Index)
                {

                    Reports.frmRptClientSale obj = new Reports.frmRptClientSale();
                    obj.MdiParent = this.MdiParent;
                    obj.ClientId = Convert.ToInt32(this.dg.CurrentRow.Cells["clientId"].Value.ToString());
                    obj.Show();
                }
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.dsClient1.Clear();
                this.daSearch.SelectCommand.Connection.ConnectionString = this.ObjCore.getClientConnectionString();
                this.daSearch.SelectCommand.Parameters["@key"].Value = this.txtSearch.Text.Trim();
                this.daSearch.Fill(this.dsClient1);
            }
            catch (Exception ex)
            {

            }
        }
    }
}
