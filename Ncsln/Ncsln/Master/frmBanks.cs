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
    public partial class frmBanks : Form
    {
        CoreClass objCore;
        int formMode;
        int Id;

        public frmBanks()
        {
            InitializeComponent();
            this.objCore = new CoreClass();
            this.formMode = 1;
            this.Id = -1;
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
                    MessageBox.Show("Please enter Item Name", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    string Command = "Insert into Banks (BankTitle, Address, AccountNo, CreatedDate) values ('" + this.txtTitle.Text.Trim() + "','" + this.txtAddress.Text.Trim() + "','" + this.txtAddresss.Text.Trim() + "', GETDATE())";
                    this.objCore.executeQuery(Command);
                }
                else
                {
                    string Command = "Update Banks set BankTitle = '" + this.txtTitle.Text.Trim() + "', Address = '" + this.txtAddress.Text.Trim() + "', AccountNo = '" + this.txtAddresss.Text.Trim() + "' where Id = " + this.Id.ToString();
                    this.objCore.executeQuery(Command);
                }


                this.loadDG();
                this.ClearForm();
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
            this.txtTitle.Text = this.txtAddress.Text = this.txtAddresss.Text = "";
        }

        private void loadDG()
        {
            try
            {
                this.dsBanks1.Clear();
                this.daBanks.SelectCommand.Connection.ConnectionString = this.objCore.getConnectionString();
                this.daBanks.Fill(this.dsBanks1);

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

                    this.txtTitle.Text = this.dgv["bankTitle", e.RowIndex].Value.ToString();
                    this.txtAddress.Text = this.dgv["address", e.RowIndex].Value.ToString();
                    this.txtAddresss.Text = this.dgv["accountNo", e.RowIndex].Value.ToString();

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

                    string Command = "Delete from VendorG where Id = " + this.Id.ToString();

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
