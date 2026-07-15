using Ncsln.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Ncsln.Inventory
{
    public partial class frmVendor : Form
    {
        //DBModel.InventoryEntities DB;
        //DBModel.Vendor model;
        Classes.CoreClass ObjCore;
        public bool quickCall = false;

        int editMode;
        int ID;

        public frmVendor()
        {
            InitializeComponent();
            this.editMode = 1;
            this.ID = -1;
            //this.model = new DBModel.Vendor();
            this.ObjCore = new Classes.CoreClass();
        }

        private void frmItem_Load(object sender, EventArgs e)
        {
            this.LoadDg();
            //this.model.VendorId = -1;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ObjCore.CheckRightServer(36, this.ID))
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

            if (!CommonTask.Question(this.ID)) return;

            SqlConnection con = new SqlConnection();
            con.ConnectionString = this.ObjCore.getConnectionString();
            con.Open();
            SqlTransaction tran = con.BeginTransaction();
            SqlCommand com = new SqlCommand("", con, tran);
            string command = string.Empty;
            string vendorAccountId = string.Empty;
            bool success = false;
            try
            {
                if (this.editMode == 1)
                {
                    com.CommandType = CommandType.StoredProcedure;
                    com.CommandText = "spCreateVendor";

                    com.Parameters.AddWithValue("@Name", this.txtTitle.Text.Trim());
                    com.Parameters.AddWithValue("@Email", this.txtEmail.Text.Trim());
                    com.Parameters.AddWithValue("@PhoneNo", this.txtPhoneNo.Text.Trim());

                    com.Parameters.Add(new SqlParameter("@Id", SqlDbType.Decimal, 18, ParameterDirection.Output, false, 18, 0, "SaleId", DataRowVersion.Default, null));
                    com.Parameters.Add(new SqlParameter("@Success", SqlDbType.Bit, 1, ParameterDirection.Output, false, 1, 0, "Success", DataRowVersion.Default, null));
                    com.Parameters.Add(new SqlParameter("@Message", SqlDbType.NVarChar, 200, ParameterDirection.Output, false, 200, 0, "Message", DataRowVersion.Default, null));
                    com.UpdatedRowSource = UpdateRowSource.OutputParameters;
                    com.ExecuteNonQuery();
                    success = Convert.ToBoolean(com.Parameters["@Success"].Value);
                    string message = com.Parameters["@Message"].Value.ToString();
                    string itemIdStock = string.Empty;
                    if (success)
                        this.ID = Convert.ToInt32(com.Parameters["@Id"].Value);
                    tran.Commit();
                    if (success)
                    {
                        this.btnSave.Text = "Update";
                        this.editMode = 2;
                        this.Branches();
                    }
                    else
                    {
                        //this.dgDetail.ClearSelection();
                        MessageBox.Show(message, "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
                else
                {
                    com.CommandType = CommandType.StoredProcedure;
                    com.CommandText = "spUpdateVendor";

                    com.Parameters.AddWithValue("@Id", this.ID);
                    com.Parameters.AddWithValue("@Name", this.txtTitle.Text.Trim());
                    com.Parameters.AddWithValue("@Email", this.txtEmail.Text.Trim());
                    com.Parameters.AddWithValue("@PhoneNo", this.txtPhoneNo.Text.Trim());

                    com.Parameters.Add(new SqlParameter("@Success", SqlDbType.Bit, 1, ParameterDirection.Output, false, 1, 0, "Success", DataRowVersion.Default, null));
                    com.Parameters.Add(new SqlParameter("@Message", SqlDbType.NVarChar, 200, ParameterDirection.Output, false, 200, 0, "Message", DataRowVersion.Default, null));
                    com.UpdatedRowSource = UpdateRowSource.OutputParameters;
                    com.ExecuteNonQuery();
                    success = Convert.ToBoolean(com.Parameters["@Success"].Value);
                    string message = com.Parameters["@Message"].Value.ToString();
                    string itemIdStock = string.Empty;

                    tran.Commit();
                    if (!success)
                    {
                        MessageBox.Show(message, "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    else
                    {
                        //this.dgDetail.ClearSelection();
                        this.BranchesUpdate();
                    }
                }
            }
            catch (Exception ex)
            {
                tran.Rollback();
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
                this.LoadDg();
            }


            //if(!CommonTask.Question(this.model.VendorId)) return;

            //using (this.DB = new DBModel.InventoryEntities())
            //{
            //    this.model.Name = this.txtTitle.Text.Trim();
            //    this.model.PhoneNo = this.txtPhoneNo.Text.Trim();
            //    this.model.Email = this.txtEmail.Text.Trim();
            //    this.model.DefaultEntry = false;
            //    if (this.model.VendorId == -1)
            //        this.DB.Vendors.Add(this.model);
            //    else
            //        this.DB.Entry(this.model).State = EntityState.Modified;                
            //    this.DB.SaveChanges();
            //}
            //this.ClearForm();
            //this.LoadDg();
            //if (this.quickCall) this.Close();
        }

        private void Branches()
        {
            try
            {
                DataSet BranchesDs = this.ObjCore.getDataSet("Select * from Branches");


                for (int i = 0; i < BranchesDs.Tables[0].Rows.Count; i++)
                {
                    string ConString = BranchesDs.Tables[0].Rows[i]["ConnectionString"].ToString();
                    if (ConString != "")
                    {
                        bool status = this.ObjCore.ConnectionCheck(@"" + ConString);
                        if (status)
                        {
                            this.ObjCore.executeQuery("Insert into vendors (Name, Email, PhoneNo, Server_Id) values ('" + this.txtTitle.Text.Trim() + "','" + this.txtEmail.Text.Trim() + "','" + this.txtPhoneNo.Text.Trim() + "', '" + this.ID + "')", ConString);
                        }
                    }

                }
            }
            catch (Exception ex)
            {

            }
        }

        private void BranchesUpdate()
        {
            try
            {
                DataSet BranchesDs = this.ObjCore.getDataSet("Select * from Branches");


                for (int i = 0; i < BranchesDs.Tables[0].Rows.Count; i++)
                {
                    string ConString = BranchesDs.Tables[0].Rows[i]["ConnectionString"].ToString();
                    if (ConString != "")
                    {
                        bool status = this.ObjCore.ConnectionCheck(@"" + ConString);
                        if (status)
                        {
                            this.ObjCore.executeQuery("Update vendors Set Name = '" + this.txtTitle.Text.Trim() + "', Email = '" + this.txtEmail.Text.Trim() + "', PhoneNo = '" + this.txtPhoneNo.Text.Trim() + "' where Server_Id = '" + this.ID + "'", ConString);
                        }
                    }

                }
            }
            catch (Exception ex)
            {

            }
        }

        private void BranchesDelete()
        {
            try
            {
                DataSet BranchesDs = this.ObjCore.getDataSet("Select * from Branches");


                for (int i = 0; i < BranchesDs.Tables[0].Rows.Count; i++)
                {
                    string ConString = BranchesDs.Tables[0].Rows[i]["ConnectionString"].ToString();
                    if (ConString != "")
                    {
                        bool status = this.ObjCore.ConnectionCheck(@"" + ConString);
                        if (status)
                        {
                            this.ObjCore.executeQuery("Delete from vendors where Server_Id = '" + this.ID + "'", ConString);
                        }
                    }

                }
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
            this.txtTitle.Text = this.txtPhoneNo.Text = this.txtEmail.Text = "";
            this.btnSave.Text = "Save";
            this.ID = -1;
            this.editMode = 1;
        }

        private void LoadDg()
        {
            this.dsVendor1.Clear();
            this.AD.SelectCommand.Connection.ConnectionString = this.ObjCore.getConnectionString();
            this.AD.Fill(this.dsVendor1);
        }

        private void dg_DoubleClick(object sender, EventArgs e)
        {
            if (this.dg.CurrentRow.Index != -1)
            {
                this.ID = Convert.ToInt32(this.dg.CurrentRow.Cells["vendorId"].Value);

                DataTable dt = this.ObjCore.getDataSet("Select * from Vendors where VendorId = " + this.ID.ToString()).Tables[0];

                this.txtTitle.Text = dt.Rows[0]["Name"].ToString();
                this.txtEmail.Text = dt.Rows[0]["Email"].ToString();
                this.txtPhoneNo.Text = dt.Rows[0]["PhoneNo"].ToString();

                this.btnSave.Text = "Update";
                this.editMode = 2;

            }
        }

        private void dg_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dg.CurrentRow.Index != -1)
            {
                if (e.ColumnIndex == this.dg.Columns["Delete"].Index)
                {
                    if (!this.ObjCore.CheckRightServer(36, this.ID, true))
                    {
                        return;
                    }

                    if (!CommonTask.Question(this.ID, true)) return;

                    this.ID = Convert.ToInt32(this.dg.CurrentRow.Cells["vendorId"].Value.ToString());

                    this.ObjCore.executeQuery("Delete from Vendors where VendorId = " + this.ID.ToString());

                    this.BranchesDelete();

                    this.ClearForm();

                    this.LoadDg();
                }
            }
        }
    }
}
