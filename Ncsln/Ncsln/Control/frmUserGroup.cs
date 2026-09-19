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

namespace Ncsln.Control
{
    public partial class frmUserGroup : Form
    {
        DBModel.InventoryEntities DB;
        DBModel.UserGroup model;
        Classes.CoreClass objCore;
        public bool quickCall = false;
        public bool UseHbcDatabase { get; set; }

        public frmUserGroup()
        {
            InitializeComponent();
            
            this.model = new DBModel.UserGroup();
            this.objCore = new Classes.CoreClass();
        }

        private void frmItem_Load(object sender, EventArgs e)
        {
            this.LoadDg();
            this.model.Id = -1;
            this.dg.Columns["Rights"].Visible = this.UseHbcDatabase
                ? this.objCore.getUserRight("User Group", "CanView", this.objCore.getHBCConnectionString())
                : this.objCore.getUserRight(16, "CanView");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (!(this.UseHbcDatabase
                ? this.objCore.CheckRightServer("User Group", this.model.Id)
                : this.objCore.CheckRight(17, this.model.Id)))
            {
                return;
            }

            if (this.txtTitle.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please enter Group Name", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtTitle.Focus();
                return;
            }

            this.SaveUpdate();
        }

        private void SaveUpdate()
        {
            if(!CommonTask.Question(this.model.Id)) return;

            using (this.DB = new DBModel.InventoryEntities(this.GetConnectionName()))
            {

                this.model.GroupName = this.txtTitle.Text.Trim();
                this.model.DefaultEntry = false;
                if (this.model.Id == -1)
                    this.DB.UserGroups.Add(this.model);
                else
                    this.DB.Entry(this.model).State = EntityState.Modified;                
                this.DB.SaveChanges();
            }
            this.ClearForm();
            this.LoadDg();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.ClearForm();
        }

        private void ClearForm()
        {
            this.txtTitle.Text = "";
            this.btnSave.Text = "Save";
            this.model.Id = -1;
        }

        private void LoadDg()
        {
            this.dsUserGroup1.Clear();
            this.daUserGroup.SelectCommand.Connection.ConnectionString = this.UseHbcDatabase
                ? this.objCore.getHBCConnectionString()
                : this.objCore.getClientConnectionString();
            this.daUserGroup.Fill(this.dsUserGroup1);
        }

        private void dg_DoubleClick(object sender, EventArgs e)
        {
            if (this.dg.CurrentRow.Index != -1)
            {
                this.model.Id = Convert.ToInt32(this.dg.CurrentRow.Cells["id"].Value);
                using (this.DB = new DBModel.InventoryEntities(this.GetConnectionName()))
                {
                    this.model = this.DB.UserGroups.Where(x => x.Id == this.model.Id).FirstOrDefault();
                    this.txtTitle.Text = this.model.GroupName;
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
                    if (Convert.ToBoolean(this.dg.CurrentRow.Cells["defaultEntry"].Value) == true)
                    {
                        MessageBox.Show("The default group cannot be delete", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }

                    if (!(this.UseHbcDatabase
                        ? this.objCore.CheckRightServer("User Group", this.model.Id, true)
                        : this.objCore.CheckRight(17, this.model.Id, true)))
                    {
                        return;
                    }


                    if (!CommonTask.Question(this.model.Id, true)) return;

                    using (this.DB = new DBModel.InventoryEntities(this.GetConnectionName()))
                    {
                        int value = Convert.ToInt32(this.dg.CurrentRow.Cells["id"].Value.ToString());
                        this.model.Id = value;
                        this.DB.Entry(this.model).State = EntityState.Deleted;
                        this.DB.SaveChanges();
                        this.ClearForm();
                        this.LoadDg();
                    }
                }

                if (e.ColumnIndex == this.dg.Columns["Rights"].Index)
                {
                    frmUserGroupRights obj = new frmUserGroupRights();
                    obj.GroupId = Convert.ToInt32(this.dg.CurrentRow.Cells["id"].Value.ToString());
                    obj.UseHbcDatabase = this.UseHbcDatabase;
                    obj.ShowDialog();
                }
            }
        }

        private string GetConnectionName()
        {
            return this.UseHbcDatabase
                ? this.objCore.getHBCConnectionStringName()
                : this.objCore.getClientConnectionStringName();
        }
    }
}
