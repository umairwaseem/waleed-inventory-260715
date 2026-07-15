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
    public partial class frmExpenseVoucher : Form
    {
        DBModel.InventoryEntities DB;
        DBModel.ExpenseVoucher model;
        Classes.CoreClass objCore;

        public frmExpenseVoucher()
        {
            InitializeComponent();
            
            this.model = new DBModel.ExpenseVoucher();
            this.objCore = new Classes.CoreClass();
        }

        private void frmItem_Load(object sender, EventArgs e)
        {
            this.LoadDg();
            this.objCore.fillComboBoxWithAddNewOptioni(this.cmbExpense, "Select Id, Expense from Expense", this.objCore.getClientConnectionString());
            this.objCore.fillComboBoxWithReports(this.cmbExpenseSearch, "Select Id, Expense from Expense", this.objCore.getClientConnectionString());
            this.model.Id = -1;
            this.btnPrint.Visible = this.objCore.getUserRight(11, "CanView");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.objCore.TimeEntryLock(this.dtpDate.Value)) return;

            if (!this.objCore.CheckRight(10, this.model.Id))
            {
                return;
            }

            if (this.txtAmount.Value < 1)
            {
                MessageBox.Show("The Expense Amount must be more then zero", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                this.objCore.RecoardLogs("Expense added", "Expense");
            }
            else
            {
                this.objCore.RecoardLogs("Expense updated invoice # : " + this.model.Id.ToString(), "Expense");
            }

            using (this.DB = new DBModel.InventoryEntities(this.objCore.getClientConnectionStringName()))
            {
                

                this.model.Expense_Id = (int)this.cmbExpense.SelectedValue;
                this.model.Date = this.dtpDate.Value;
                this.model.Description = this.txtNote.Text.Trim();
                this.model.Amount = this.txtAmount.Value;
                if (this.model.Id == -1)
                    this.DB.ExpenseVouchers.Add(this.model);
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
            this.txtAmount.Value = 0;
            this.cmbExpense.SelectedValue = -2;
            this.txtNote.Text = "";
            this.btnSave.Text = "Save";
            this.model.Id = -1;
        }

        private void LoadDg()
        {
            this.dsExpenseVoucher.Clear();
            this.AD.SelectCommand.Connection.ConnectionString = this.objCore.getClientConnectionString();
            this.AD.Fill(this.dsExpenseVoucher);
        }

        private void dg_DoubleClick(object sender, EventArgs e)
        {
            //if (this.dg.CurrentRow.Index != -1)
            //{
            //    this.model.Id = Convert.ToInt32(this.dg.CurrentRow.Cells["id"].Value);
            //    using (this.DB = new DBModel.InventoryEntities())
            //    {
            //        this.model = this.DB.Expenses.Where(x => x.Id == this.model.Id).FirstOrDefault();
            //        this.txtTitle.Text = this.model.Expense1;
            //        this.btnSave.Text = "Update";
            //    }
            //}
        }

        private void dg_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dg.CurrentRow.Index != -1)
            {
                if (e.ColumnIndex == this.dg.Columns["Delete"].Index)
                {
                    if (!this.objCore.CheckRight(10, this.model.Id, true))
                    {
                        return;
                    }

                    if (!CommonTask.Question(this.model.Id, true)) return;

                    using (this.DB = new DBModel.InventoryEntities(this.objCore.getClientConnectionStringName()))
                    {
                        int value = Convert.ToInt32(this.dg.CurrentRow.Cells["id"].Value.ToString());
                        this.model.Id = value;
                        this.DB.Entry(this.model).State = EntityState.Deleted;
                        this.DB.SaveChanges();
                        this.ClearForm();
                        this.LoadDg();

                        this.objCore.RecoardLogs("Expense deleted invoice # : " + this.model.Id.ToString(), "Expense");
                    }
                }

                if (e.ColumnIndex == this.dg.Columns["Edit"].Index)
                {
                    this.ClearForm();
                    this.model.Id = Convert.ToInt32(this.dg.CurrentRow.Cells["id"].Value);
                    using (this.DB = new DBModel.InventoryEntities(this.objCore.getClientConnectionStringName()))
                    {                        
                        this.model = this.DB.ExpenseVouchers.Where(x => x.Id == this.model.Id).FirstOrDefault();
                        this.cmbExpense.SelectedValue = this.model.Expense_Id;
                        this.txtAmount.Value = (decimal)this.model.Amount;
                        this.txtNote.Text = this.model.Description;
                        this.dtpDate.Value = (DateTime)this.model.Date;
                        this.tabControl1.SelectedTab = this.tabPage1;
                        this.btnSave.Text = "Update";
                    }
                }
            }
        }

        private void cmbExpense_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (this.cmbExpense.SelectedValue.ToString() == "-1")
            {
                frmExpenseAccount obj = new frmExpenseAccount();
                obj.StartPosition = FormStartPosition.CenterParent;
                obj.quickCall = true;
                obj.ShowDialog();

                this.objCore.fillComboBoxWithAddNewOptioni(this.cmbExpense, "Select Id, Expense from Expense", this.objCore.getClientConnectionString());

                using (this.DB = new DBModel.InventoryEntities(this.objCore.getClientConnectionStringName()))
                {
                    var value = this.DB.Expenses.Max(x => x.Id);
                    this.cmbExpense.SelectedValue = value;
                }

            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.model.Id != -1)
                {
                    Reports.frmRptExpenseVoucher obj = new Reports.frmRptExpenseVoucher();
                    obj.Id = this.model.Id;
                    obj.MdiParent = this.MdiParent;
                    obj.WindowState = FormWindowState.Maximized;
                    obj.Show();
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.cmbExpenseSearch.SelectedValue.ToString() == "-1" || this.cmbExpenseSearch.SelectedValue == null)
                {
                    this.LoadDg();
                }
                else
                {
                    this.dsExpenseVoucher.Clear();
                    this.daSearch.SelectCommand.Connection.ConnectionString = this.objCore.getClientConnectionString();
                    this.daSearch.SelectCommand.Parameters["@key"].Value = this.cmbExpenseSearch.SelectedValue.ToString();
                    this.daSearch.Fill(this.dsExpenseVoucher);
                }
            }
            catch (Exception Ex)
            {

            }
        }
    }
}
