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
    public partial class frmWithdraw : Form
    {
        DBModel.InventoryEntities DB;
        DBModel.OwnerAccount model;
        Classes.CoreClass ObjCore;

        public frmWithdraw()
        {
            InitializeComponent();
            
            this.model = new DBModel.OwnerAccount();
            this.ObjCore = new Classes.CoreClass();
        }

        private void frmItem_Load(object sender, EventArgs e)
        {
            this.LoadDg();
            this.model.Id = -1;
            this.btnPrint.Visible = this.ObjCore.getUserRight(9, "CanView");

            this.dg.Columns[0].Visible = false;

            this.txtPayBy.Text = this.maxSerialNo().ToString();

            this.dg.Columns["Delete"].Visible = this.ObjCore.getUserRight(8, "CanDelete");
        }

        private int maxSerialNo()
        {
            try
            {
                int serialNo = Convert.ToInt32(this.ObjCore.getDataSet("select MAX(PayBy) from OwnerAccount", this.ObjCore.getClientConnectionString()).Tables[0].Rows[0][0]);
                serialNo++;
                return serialNo;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ObjCore.TimeEntryLock(this.dtpDate.Value)) return;

            if (!this.ObjCore.CheckRight(8, this.model.Id))
            {
                return;
            }

            if (this.txtAmount.Value < 1)
            {
                MessageBox.Show("The Expense Amount must be greater than zero.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                if (this.model.Id == -1)
                {
                    this.txtPayBy.Text = this.maxSerialNo().ToString();

                    this.model.PayBy = this.maxSerialNo().ToString(); //this.txtPayBy.Text.Trim();
                } 
                else
                {
                    this.model.PayBy = this.txtPayBy.Text.Trim();
                }
                
                this.model.ReceiveBy = this.txtReceiveBy.Text.Trim();
                this.model.Date = this.dtpDate.Value;
                this.model.Amount = this.txtAmount.Value;
                this.model.PaymentType = (this.rbCash.Checked) ? "Cash" : "Bank";
                this.model.BankName = this.txtBankName.Text.Trim();
                this.model.AccountNo = this.txtAccountNo.Text.Trim();
                this.model.Detail = this.txtNote.Text.Trim();
                if (this.model.Id == -1)
                    this.DB.OwnerAccounts.Add(this.model);
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
            this.dtpDate.Value = DateTime.Now;
            this.txtNote.Text = this.txtPayBy.Text = this.txtReceiveBy.Text = this.txtBankName.Text = this.txtAccountNo.Text = "";
            this.rbCash.Checked = true;
            this.rbBank.Checked = false;
            this.btnSave.Text = "Save";
            this.model.Id = -1;
        }

        private void LoadDg()
        {
            this.dsWithdraw1.Clear();
            this.AD.SelectCommand.Connection.ConnectionString = this.ObjCore.getClientConnectionString();
            this.AD.Fill(this.dsWithdraw1);
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
                    if (!this.ObjCore.CheckRight(8, this.model.Id, true))
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
                    this.ClearForm();
                    this.model.Id = Convert.ToInt32(this.dg.CurrentRow.Cells["id"].Value);
                    using (this.DB = new DBModel.InventoryEntities(this.ObjCore.getClientConnectionStringName()))
                    {
                        //this.model = this.DB.OwnerAccounts.Where(x => x.Id == this.model.Id).FirstOrDefault();

                        //this.txtPayBy.Text = this.model.PayBy.ToString();
                        //this.txtReceiveBy.Text = this.model.ReceiveBy;
                        //this.rbCash.Checked = (this.model.PaymentType == "Cash") ? true : false;
                        //this.rbBank.Checked = (this.model.PaymentType == "Bank") ? true : false;
                        //this.txtAmount.Value = (decimal)this.model.Amount;
                        //this.txtBankName.Text = this.model.BankName;
                        //this.txtAccountNo.Text = this.model.AccountNo;
                        //this.txtNote.Text = this.model.Detail;
                        //this.dtpDate.Value = (DateTime)this.model.Date;
                        //this.tabControl1.SelectedTab = this.tabPage1;
                        //this.btnSave.Text = "Update";

                        DataTable dt = this.ObjCore.getDataSet("select * from OwnerAccount where Id = '" + this.model.Id + "'", this.ObjCore.getClientConnectionString()).Tables[0];

                        this.txtPayBy.Text = dt.Rows[0]["PayBy"].ToString();
                        this.txtReceiveBy.Text = dt.Rows[0]["ReceiveBy"].ToString();
                        this.rbCash.Checked = (dt.Rows[0]["PaymentType"].ToString() == "Cash") ? true : false;
                        this.rbBank.Checked = (dt.Rows[0]["PaymentType"].ToString() == "Bank") ? true : false;
                        this.txtAmount.Value = Convert.ToDecimal(dt.Rows[0]["Amount"].ToString());
                        this.txtBankName.Text = dt.Rows[0]["BankName"].ToString();
                        this.txtAccountNo.Text = dt.Rows[0]["AccountNo"].ToString(); ;
                        this.txtNote.Text = dt.Rows[0]["Detail"].ToString();
                        this.dtpDate.Value = Convert.ToDateTime(dt.Rows[0]["Date"].ToString());
                        this.tabControl1.SelectedTab = this.tabPage1;
                        this.btnSave.Text = "Update";
                    }
                }
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.model.Id != -1)
                {
                    Reports.frmRptDailyBanking obj = new Reports.frmRptDailyBanking();
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

        private void btnShow_Click(object sender, EventArgs e)
        {
            this.LoadDg();
        }

        private void btnShowInDate_Click(object sender, EventArgs e)
        {
            this.dsWithdraw1.Clear();
            this.daForDate.SelectCommand.Connection.ConnectionString = this.ObjCore.getClientConnectionString();
            this.daForDate.SelectCommand.Parameters["@Date"].Value = this.dtp.Value.ToShortDateString();
            this.daForDate.Fill(this.dsWithdraw1);
        }
    }
}
