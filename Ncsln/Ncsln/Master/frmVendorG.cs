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
    public partial class frmVendorG : Form
    {
        CoreClass objCore;
        int formMode;
        int Id;

        public frmVendorG()
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
                    string Command = "Insert into VendorG (Name, PhoneNo, Email) values ('" + this.txtTitle.Text.Trim() + "','" + this.txtPhoneNo.Text.Trim() + "','" + this.txtEmail.Text.Trim() + "')";
                    this.objCore.executeQuery(Command);
                }
                else
                {
                    string Command = "Update VendorG set Name = '" + this.txtTitle.Text.Trim() + "', PhoneNo = '" + this.txtPhoneNo.Text.Trim() + "', Email = '" + this.txtEmail.Text.Trim() + "' where Id = " + this.Id.ToString();
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
            this.txtTitle.Text = this.txtPhoneNo.Text = this.txtEmail.Text = "";
        }

        private void loadDG()
        {
            try
            {
                this.dsVendorG1.Clear();
                this.daVendor.SelectCommand.Connection.ConnectionString = this.objCore.getConnectionString();
                this.daVendor.Fill(this.dsVendorG1);

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

                    this.txtTitle.Text = this.dgv["name", e.RowIndex].Value.ToString();
                    this.txtPhoneNo.Text = this.dgv["phone", e.RowIndex].Value.ToString();
                    this.txtEmail.Text = this.dgv["email", e.RowIndex].Value.ToString();

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
