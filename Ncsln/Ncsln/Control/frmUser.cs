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
    public partial class frmUser : Form
    {
        DBModel.InventoryEntities DB;
        DBModel.AISY model;
        Classes.CoreClass objCore;
        public bool quickCall = false;

        public frmUser()
        {
            InitializeComponent();
            
            this.model = new DBModel.AISY();
            this.objCore = new Classes.CoreClass();
        }

        private void frmItem_Load(object sender, EventArgs e)
        {
            this.LoadDg();
            this.model.UserId = -1;
            this.objCore.fillComboBoxOptioni(this.cmbUserGroup, "Select Id, GroupName from UserGroups", this.objCore.getClientConnectionString());
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (!this.objCore.CheckRight(15, (Int32)this.model.UserId))
            {
                return;
            }

            if (this.txtTitle.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please enter Name", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtTitle.Focus();
                return;
            }

            this.SaveUpdate();
        }

        private void SaveUpdate()
        {
            if(!CommonTask.Question((Int32)this.model.UserId)) return;

            using (this.DB = new DBModel.InventoryEntities(this.objCore.getClientConnectionStringName()))
            {

                if (this.DB.AISYS.Where(x => x.UserLoginId == this.txtUserId.Text.Trim() && x.UserId != this.model.UserId).ToList().Count() > 0)
                {
                    MessageBox.Show("This login Id is already taken try another!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                this.model.UserName = this.txtTitle.Text.Trim();
                this.model.UserLoginId = this.txtUserId.Text.Trim();
                this.model.UserPassword = this.txtPassword.Text.Trim();
                this.model.Group_Id = Convert.ToInt32(this.cmbUserGroup.SelectedValue);
                this.model.Active = this.ckbStatus.Checked;
                this.model.DefaultEntry = false;
                if (this.model.UserId == -1)
                    this.DB.AISYS.Add(this.model);
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
            this.txtTitle.Text = this.txtUserId.Text = this.txtPassword.Text = "";
            this.cmbUserGroup.SelectedValue = -1;
            this.btnSave.Text = "Save";
            this.model.UserId = -1;
        }

        private void LoadDg()
        {
            this.dsUser1.Clear();
            this.dsUser1.EnforceConstraints = false;
            this.daUser.SelectCommand.Connection.ConnectionString = this.objCore.getClientConnectionString();
            this.daUser.Fill(this.dsUser1);
        }

        private void dg_DoubleClick(object sender, EventArgs e)
        {
            if (this.dg.CurrentRow.Index != -1)
            {
                this.model.UserId = Convert.ToDecimal(this.dg.CurrentRow.Cells["id"].Value);
                using (this.DB = new DBModel.InventoryEntities(this.objCore.getClientConnectionStringName()))
                {
                    this.model = this.DB.AISYS.Where(x => x.UserId == this.model.UserId).FirstOrDefault();
                    this.txtTitle.Text = this.model.UserName;
                    this.txtUserId.Text = this.model.UserLoginId;
                    this.txtPassword.Text = this.model.UserPassword;
                    this.cmbUserGroup.SelectedValue = this.model.Group_Id;
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

                    if (!this.objCore.CheckRight(15, (Int32)this.model.UserId, true))
                    {
                        return;
                    }

                    if (Convert.ToBoolean(this.dg.CurrentRow.Cells["defaultEntry"].Value) == true)
                    {
                        MessageBox.Show("The default group cannot be delete", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }


                    if (!CommonTask.Question((Int32)this.model.UserId, true)) return;

                    using (this.DB = new DBModel.InventoryEntities(this.objCore.getClientConnectionStringName()))
                    {
                        int value = Convert.ToInt32(this.dg.CurrentRow.Cells["id"].Value.ToString());
                        this.model.UserId = value;
                        this.DB.Entry(this.model).State = EntityState.Deleted;
                        this.DB.SaveChanges();
                        this.ClearForm();
                        this.LoadDg();
                    }
                }
            }
        }
    }
}
