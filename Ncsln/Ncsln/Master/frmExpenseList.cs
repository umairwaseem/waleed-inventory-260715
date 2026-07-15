using Ncsln.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Ncsln.Master
{
    public partial class frmExpenseList : Form
    {
        CoreClass objCore;
        int formMode;
        int Id;
        public Boolean closeCall;

        public frmExpenseList()
        {
            InitializeComponent();
            this.objCore = new CoreClass();
            this.formMode = 1;
            this.Id = -1;
            this.closeCall = false;
        }

        private void frmVendorG_Load(object sender, EventArgs e)
        {
            this.loadDG();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!this.objCore.CheckRightServer(37, this.Id))
                {
                    return;
                }

                if (this.txtTitle.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Please enter title Name", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txtTitle.Focus();
                    return;
                }

                //if (this.txtPhoneNo.Text.Trim() == string.Empty)
                //{
                //    MessageBox.Show("Please enter Item Phone", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    this.txtPhoneNo.Focus();
                //    return;
                //}

                this.SaveUpdate();
            }
            catch (Exception ex)
            {

            }
        }

        private void SaveUpdate()
        {
            try
            {
                if (!CommonTask.Question(this.Id)) return;

                if (this.formMode == 1)
                {
                    string Command = "Insert into ExpenseList (PayTo) values ('" + this.txtTitle.Text.Trim() + "')";
                    this.objCore.executeQuery(Command);
                }
                else
                {
                    string Command = "Update ExpenseList set PayTo = '" + this.txtTitle.Text.Trim() + "' where Id = " + this.Id.ToString();
                    this.objCore.executeQuery(Command);
                }


                this.loadDG();
                this.ClearForm();
                if (this.closeCall)
                    this.Close();
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
            this.formMode = 1;
            this.Id = -1;
            this.btnSave.Text = "Save";
            this.txtTitle.Text = "";
        }

        private void loadDG()
        {
            try
            {
                this.dsExpenseList1.Clear();
                this.daExpenseList.SelectCommand.Connection.ConnectionString = this.objCore.getConnectionString();
                this.daExpenseList.Fill(this.dsExpenseList1);

                this.dgv.ClearSelection();
            }
            catch (Exception ex)
            {

                
            }
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == this.dgv.Columns["Edit"].Index)
                {
                    this.ClearForm();
                    this.Id = Convert.ToInt32(this.dgv["dgvId", e.RowIndex].Value);

                    this.txtTitle.Text = this.dgv["PayTo", e.RowIndex].Value.ToString();
                    

                    this.formMode = 2;
                    this.btnSave.Text = "Update";

                }

                if (e.ColumnIndex == this.dgv.Columns["Delete"].Index)
                {
                    if (!this.objCore.CheckRightServer(37, this.Id, true))
                    {
                        return;
                    }

                    if (!CommonTask.Question(this.Id, true)) return;

                    this.Id = Convert.ToInt32(this.dgv["dgvId", e.RowIndex].Value);

                    string Command = "Delete from ExpenseList where Id = " + this.Id.ToString();

                    this.objCore.executeQuery(Command);
                    this.ClearForm();
                    this.loadDG();
                   
                }
            }
            catch (Exception ex)
            {

            }
        }

        
    }
}
