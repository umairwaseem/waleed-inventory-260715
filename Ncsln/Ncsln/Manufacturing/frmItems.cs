using Ncsln.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Ncsln.Manufacturing
{
    public partial class frmItems : Form
    {
        CoreClass ObjCore;
        int Id = -1;

        public frmItems()
        {
            InitializeComponent();
            this.ObjCore = new CoreClass();
        }

        private void frmItems_Load(object sender, EventArgs e)
        {
            this.LoadDGV();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!CommonTask.Question(this.Id)) return;

                if (this.txtTitle.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Please enter title for item", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.txtTitle.Focus();
                    return;
                }

                if (this.txtModel.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Please enter model No for item", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.txtModel.Focus();
                    return;
                }

                this.SaveUpdate();


            }
            catch (Exception ex)
            {

            }
        }

        private void SaveUpdate()
        {
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
                if (this.Id == -1)
                {
                    com.CommandType = CommandType.StoredProcedure;
                    com.CommandText = "spCreateItems";

                    com.Parameters.AddWithValue("@Name", this.txtTitle.Text.Trim());
                    com.Parameters.AddWithValue("@Code", this.txtModel.Text.Trim());
                    com.Parameters.AddWithValue("@PurchasePrice", this.txtPrice.Value.ToString());                  

                    com.Parameters.Add(new SqlParameter("@Id", SqlDbType.Decimal, 18, ParameterDirection.Output, false, 18, 0, "SaleId", DataRowVersion.Default, null));
                    com.Parameters.Add(new SqlParameter("@Success", SqlDbType.Bit, 1, ParameterDirection.Output, false, 1, 0, "Success", DataRowVersion.Default, null));
                    com.Parameters.Add(new SqlParameter("@Message", SqlDbType.NVarChar, 200, ParameterDirection.Output, false, 200, 0, "Message", DataRowVersion.Default, null));
                    com.UpdatedRowSource = UpdateRowSource.OutputParameters;
                    com.ExecuteNonQuery();
                    success = Convert.ToBoolean(com.Parameters["@Success"].Value);
                    string message = com.Parameters["@Message"].Value.ToString();
                    string itemIdStock = string.Empty;
                    if (success)
                        this.Id = Convert.ToInt32(com.Parameters["@Id"].Value);

                    tran.Commit();
                    if (success)
                    {
                        this.btnSave.Text = "Update";
                   
                        //this.dgDetail.ClearSelection();
                        MessageBox.Show(message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    com.CommandType = CommandType.StoredProcedure;
                    com.CommandText = "spUpdateItems";

                    com.Parameters.AddWithValue("@Id", this.Id);
                    com.Parameters.AddWithValue("@Name", this.txtTitle.Text.Trim());
                    com.Parameters.AddWithValue("@Code", this.txtModel.Text.Trim());
                    com.Parameters.AddWithValue("@PurchasePrice", this.txtPrice.Value.ToString());                  

                    com.Parameters.Add(new SqlParameter("@Success", SqlDbType.Bit, 1, ParameterDirection.Output, false, 1, 0, "Success", DataRowVersion.Default, null));
                    com.Parameters.Add(new SqlParameter("@Message", SqlDbType.NVarChar, 200, ParameterDirection.Output, false, 200, 0, "Message", DataRowVersion.Default, null));
                    com.UpdatedRowSource = UpdateRowSource.OutputParameters;
                    com.ExecuteNonQuery();
                    success = Convert.ToBoolean(com.Parameters["@Success"].Value);
                    string message = com.Parameters["@Message"].Value.ToString();
                    string itemIdStock = string.Empty;
                    if (success)
                        this.Id = Convert.ToInt32(com.Parameters["@Id"].Value);

                    tran.Commit();
                    if (success)
                    {
                        //this.dgDetail.ClearSelection();
                        MessageBox.Show(message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                this.LoadDGV();
            }
        }

        private void LoadDGV()
        {
            try
            {
                this.dsMItems.Clear();
                this.daMItems.SelectCommand.Connection.ConnectionString = this.ObjCore.getConnectionString();
                this.daMItems.Fill(this.dsMItems);

                this.dgv.ClearSelection();
            }
            catch (Exception ex)
            {

            }

        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                string currentId = this.dgv["ItemId", e.RowIndex].Value.ToString();
                if (e.ColumnIndex == this.dgv.Columns["Edit"].Index)
                {

                    DataTable dt = this.ObjCore.getDataSet("Select * from MItems where Id = '" + currentId + "'").Tables[0];
                    this.Id = Convert.ToInt32(currentId);

                    this.txtTitle.Text = dt.Rows[0]["Name"].ToString();
                    this.txtModel.Text = dt.Rows[0]["Code"].ToString();
                    this.txtPrice.Value = Convert.ToDecimal(dt.Rows[0]["PurchasePrice"]);

                    this.btnSave.Text = "Update";
                }
                if (e.ColumnIndex == this.dgv.Columns["Delete"].Index)
                {
                    if (!CommonTask.Question(this.Id, true)) return;

                    this.ObjCore.executeQuery("Delete from MItems where Id = " + currentId);

                    this.LoadDGV();
                    this.clearForm();
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.clearForm();
        }

        private void clearForm()
        {
            this.Id = -1;
            this.txtTitle.Text = this.txtModel.Text = "";
            this.txtPrice.Value = 0;
            this.btnSave.Text = "Save";
        }


    }
}
