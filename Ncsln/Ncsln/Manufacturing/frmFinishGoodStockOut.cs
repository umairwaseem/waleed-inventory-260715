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
    public partial class frmFinishGoodStockOut : Form
    {
        CoreClass ObjCore;
        int Id = -1;

        public frmFinishGoodStockOut()
        {
            InitializeComponent();
            this.ObjCore = new CoreClass();
        }

        private void frmItems_Load(object sender, EventArgs e)
        {
            this.loadItems();
            this.ObjCore.fillComboBoxOptioni(this.cmbBranch, "Select Id, BranchName From Branches");
            this.LoadDGV();
        }

        private void loadItems()
        {
            this.ObjCore.fillComboBoxOptioni(this.cmbItems, "Select Server_Id, ModelNo + ' ' + Detail as Detail from vMFinishGoods");
            //this.ObjCore.fillComboBoxOptioni(this.cmbItems, "Select Id, Name + ' (' + Convert(Nvarchar(50), Id) + ')' From ItemList Where Id in (Select ItemId from MFinishGoodsStock)");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!this.ObjCore.CheckRightServer(29, this.Id))
                {
                    return;
                }

                if (!CommonTask.Question(this.Id)) return;

                if (this.txtQty.Value < 1)
                {
                    MessageBox.Show("Please enter qty", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.txtQty.Focus();
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
                    com.CommandText = "spCreateFinishGoodsStockOut";

                    com.Parameters.AddWithValue("@ItemId", this.cmbItems.SelectedValue.ToString());
                    com.Parameters.AddWithValue("@Branch_Id", this.cmbBranch.SelectedValue.ToString());
                    com.Parameters.AddWithValue("@Qty", this.txtQty.Value.ToString());
                    com.Parameters.AddWithValue("@Price", this.txtPrice.Value.ToString());
                    com.Parameters.AddWithValue("@Date", this.dtp.Value.ToString());
                    com.Parameters.AddWithValue("@Description", this.txtDetail.Text.ToString());                  

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
                    else
                    {
                        MessageBox.Show(message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    com.CommandType = CommandType.StoredProcedure;
                    com.CommandText = "spUpdateFinishGoodsStockOut";

                    com.Parameters.AddWithValue("@Id", this.Id);
                    com.Parameters.AddWithValue("@ItemId", this.cmbItems.SelectedValue.ToString());
                    com.Parameters.AddWithValue("@Branch_Id", this.cmbBranch.SelectedValue.ToString());
                    com.Parameters.AddWithValue("@Qty", this.txtQty.Value.ToString());
                    com.Parameters.AddWithValue("@Price", this.txtPrice.Value.ToString());
                    com.Parameters.AddWithValue("@Date", this.dtp.Value.ToString());
                    com.Parameters.AddWithValue("@Description", this.txtDetail.Text.ToString());                 

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
                    else
                    {
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
                this.dsMStockOut1.Clear();
                this.daMStockOut.SelectCommand.Connection.ConnectionString = this.ObjCore.getConnectionString();
                this.daMStockOut.Fill(this.dsMStockOut1);

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
                string currentId = this.dgv["showId", e.RowIndex].Value.ToString();
                if (e.ColumnIndex == this.dgv.Columns["Edit"].Index)
                {

                    DataTable dt = this.ObjCore.getDataSet("Select * from MFinishGoodsStockOut where Id = '" + currentId + "'").Tables[0];
                    this.Id = Convert.ToInt32(currentId);

                    this.cmbItems.SelectedValue = dt.Rows[0]["ItemId"].ToString();
                    this.cmbBranch.SelectedValue = dt.Rows[0]["Branch_Id"].ToString();
                    this.txtQty.Value = Convert.ToInt32(dt.Rows[0]["Qty"]);
                    this.txtPrice.Value = Convert.ToInt32(dt.Rows[0]["Price"]);
                    this.dtp.Value = Convert.ToDateTime(dt.Rows[0]["Date"]);
                    this.txtDetail.Text = dt.Rows[0]["Description"].ToString();

                    this.btnSave.Text = "Update";
                }
                if (e.ColumnIndex == this.dgv.Columns["Delete"].Index)
                {
                    if (!this.ObjCore.CheckRightServer(29, this.Id))
                    {
                        return;
                    }

                    if (!CommonTask.Question(this.Id, true)) return;

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
                        com.CommandType = CommandType.StoredProcedure;
                        com.CommandText = "spDeleteFinishGoodsStockOut";

                        com.Parameters.AddWithValue("@Id", currentId);

                        com.Parameters.Add(new SqlParameter("@Success", SqlDbType.Bit, 1, ParameterDirection.Output, false, 1, 0, "Success", DataRowVersion.Default, null));
                        com.Parameters.Add(new SqlParameter("@Message", SqlDbType.NVarChar, 200, ParameterDirection.Output, false, 200, 0, "Message", DataRowVersion.Default, null));
                        com.UpdatedRowSource = UpdateRowSource.OutputParameters;
                        com.ExecuteNonQuery();
                        success = Convert.ToBoolean(com.Parameters["@Success"].Value);
                        string message = com.Parameters["@Message"].Value.ToString();
                        if (success)
                            this.clearForm();

                        tran.Commit();
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
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.clearForm();
        }

        private void clearForm()
        {
            this.Id = -1;
            this.cmbItems.SelectedIndex = this.cmbBranch.SelectedIndex = 0;
            this.txtDetail.Text = "";
            this.txtPrice.Value = 0; //this.txtQty.Value = 0;
            this.dtp.Value = DateTime.Now;
            this.txtDetail.Text = "";
            this.btnSave.Text = "Save";
        }

        private void cmbItems_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = this.ObjCore.getDataSet("Select * from MFinishGoods where Server_Id = " + this.cmbItems.SelectedValue.ToString(), this.ObjCore.getHBCConnectionString()).Tables[0];

                this.cmbBranch.SelectedValue = dt.Rows[0]["Branch_Id"].ToString();
                this.txtPrice.Value = Convert.ToDecimal(dt.Rows[0]["Price"]);
            }
            catch (Exception ex)
            {

            }
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //try
            //{
            //    this.dgv.ClearSelection();
            //    this.dgv.Rows[e.RowIndex].Selected = true;
            //}
            //catch (Exception ex)
            //{

            //}
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.vMFinishGoodsStockOutBindingSource.Filter = " ModelNo like '%" + this.txtSearch.Text.Trim() + "%'";
            }
            catch (Exception)
            {
            }
        }


    }
}
