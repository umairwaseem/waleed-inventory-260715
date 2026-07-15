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

namespace Ncsln.Accounts
{
    public partial class frmExpenseAccount : Form
    {
        DBModel.InventoryEntities DB;
        DBModel.Expense model;
        Classes.CoreClass ObjCore;

        public bool quickCall = false;

        public frmExpenseAccount()
        {
            InitializeComponent();
            
            this.model = new DBModel.Expense();
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

            if (!this.ObjCore.CheckRight(18, this.model.Id))
            {
                return;
            }

            if (this.txtTitle.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please enter Expense Name", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtTitle.Focus();
                return;
            }

            this.SaveUpdate();
        }

        private void SaveUpdate()
        {
            if(!CommonTask.Question(this.model.Id)) return;

            try
            {
                using (this.DB = new DBModel.InventoryEntities(this.ObjCore.getClientConnectionStringName()))
                {
                    this.model.Expense1 = this.txtTitle.Text.Trim();
                    if (this.model.Id == -1)
                        this.DB.Expenses.Add(this.model);
                    else
                        this.DB.Entry(this.model).State = EntityState.Modified;
                    this.DB.SaveChanges();
                }
            }
            catch (System.Data.Entity.Core.MetadataException ex)
            {
                MessageBox.Show(ex.InnerException.Message);
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
            this.txtTitle.Text = "";
            this.btnSave.Text = "Save";
            this.model.Id = -1;
        }

        private void LoadDg()
        {
            this.dsExpense1.Clear();
            this.AD.SelectCommand.Connection.ConnectionString = this.ObjCore.getClientConnectionString();
            this.AD.Fill(this.dsExpense1);
        }

        private void dg_DoubleClick(object sender, EventArgs e)
        {
            if (this.dg.CurrentRow.Index != -1)
            {
                this.model.Id = Convert.ToInt32(this.dg.CurrentRow.Cells["id"].Value);
                using (this.DB = new DBModel.InventoryEntities(this.ObjCore.getClientConnectionStringName()))
                {
                    this.model = this.DB.Expenses.Where(x => x.Id == this.model.Id).FirstOrDefault();
                    this.txtTitle.Text = this.model.Expense1;
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
                    if (!this.ObjCore.CheckRight(18, this.model.Id, true))
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
            }
        }
    }
}
