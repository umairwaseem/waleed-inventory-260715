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

namespace Ncsln.Stock
{
    public partial class frmSItems : Form
    {
        CoreClass ObjCore;
        public int Id = -1;
        public bool HBCItem = true;
        public bool QuickCall = false;
        public decimal PercentRate = 0;

        public frmSItems()
        {
            InitializeComponent();
            this.ObjCore = new CoreClass();
        }

        private void frmItems_Load(object sender, EventArgs e)
        {
            this.LoadDGV();
            this.PercentRate = Convert.ToDecimal(this.ObjCore.GetSetting(7));
            this.label9.Visible = this.txtExtra.Visible = this.ObjCore.getUserRight(23, "CanUpdate", this.ObjCore.getHBCConnectionString());
            if (this.HBCItem)
            {
                this.txtExtra.Visible = this.txtOverHead.Visible = this.txtStartPrice.Visible = false;
                this.label7.Visible = this.label8.Visible = this.label9.Visible = false;
                var inp = new Point(495, 59);
                var txp = new Point(437, 61);
                this.txtPrice.Location = inp;
                this.label4.Location = txp;
                this.label4.Text = "Price";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!this.ObjCore.CheckRightServer(23, this.Id))
                {
                    return;
                }

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
                    com.CommandText = "spCreateItemsList";

                    com.Parameters.AddWithValue("@Title", this.txtTitle.Text.Trim());
                    com.Parameters.AddWithValue("@Code", this.txtModel.Text.Trim());
                    com.Parameters.AddWithValue("@PurchasePrice", this.txtPrice.Value.ToString());
                    com.Parameters.AddWithValue("@Branch_Id", "0");
                    com.Parameters.AddWithValue("@Hide", this.chkHide.Checked.ToString());

                    com.Parameters.AddWithValue("@OverHead", this.txtOverHead.Value.ToString());
                    com.Parameters.AddWithValue("@Price", this.txtStartPrice.Value.ToString());
                    com.Parameters.AddWithValue("@ExtraAmount", this.txtExtra.Value.ToString());

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
                        if (this.QuickCall) this.Close();
                        this.btnSave.Text = "Update";
                   
                        //this.dgDetail.ClearSelection();
                        MessageBox.Show(message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    com.CommandType = CommandType.StoredProcedure;
                    com.CommandText = "spUpdateItemsList";

                    com.Parameters.AddWithValue("@Id", this.Id);
                    com.Parameters.AddWithValue("@Title", this.txtTitle.Text.Trim());
                    com.Parameters.AddWithValue("@Code", this.txtModel.Text.Trim());
                    com.Parameters.AddWithValue("@PurchasePrice", this.txtPrice.Value.ToString());
                    com.Parameters.AddWithValue("@Branch_Id", "0");
                    com.Parameters.AddWithValue("@Hide", this.chkHide.Checked.ToString());

                    com.Parameters.AddWithValue("@OverHead", this.txtOverHead.Value.ToString());
                    com.Parameters.AddWithValue("@Price", this.txtStartPrice.Value.ToString());
                    com.Parameters.AddWithValue("@ExtraAmount", this.txtExtra.Value.ToString());   

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
                        if (this.QuickCall) this.Close();
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
                if (this.HBCItem)
                {
                    this.dsSItems.Clear();
                    this.daSItems.SelectCommand.Connection.ConnectionString = this.ObjCore.getConnectionString();
                    this.daSItems.SelectCommand.Parameters["@key"].Value = this.txtSearch.Text.Trim();
                    this.daSItems.SelectCommand.Parameters["@Hide"].Value = this.rbtnHide.Checked.ToString();
                    this.daSItems.Fill(this.dsSItems);
                }
                else
                {
                    this.dsSItems.Clear();
                    this.daSTimeNotHBC.SelectCommand.Connection.ConnectionString = this.ObjCore.getConnectionString();
                    this.daSTimeNotHBC.SelectCommand.Parameters["@key"].Value = this.txtSearch.Text.Trim();
                    this.daSTimeNotHBC.SelectCommand.Parameters["@Hide"].Value = this.rbtnHide.Checked.ToString();
                    this.daSTimeNotHBC.Fill(this.dsSItems);
                }

                for (int i = 0; i < this.dgv.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(this.dgv["Hide", i].Value))
                    {
                        this.dgv.Rows[i].DefaultCellStyle.BackColor = Color.LightGray;
                    }
                }

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
                if (e.RowIndex != -1)
                {
                    string currentId = this.dgv["ItemId", e.RowIndex].Value.ToString();
                    if (e.ColumnIndex == this.dgv.Columns["Edit"].Index)
                    {

                        DataTable dt = this.ObjCore.getDataSet("Select * from ItemList where Id = '" + currentId + "'").Tables[0];
                        this.Id = Convert.ToInt32(currentId);

                        this.txtTitle.Text = dt.Rows[0]["Name"].ToString();
                        this.txtModel.Text = dt.Rows[0]["Code"].ToString();
                        this.txtStartPrice.Value = Convert.ToDecimal(dt.Rows[0]["Price"]);
                        this.txtOverHead.Value = Convert.ToDecimal(dt.Rows[0]["OverHead"]);
                        this.txtExtra.Value = Convert.ToDecimal(dt.Rows[0]["ExtraAmount"]);
                        this.txtPrice.Value = Convert.ToDecimal(dt.Rows[0]["PurchasePrice"]);
                        this.chkHide.Checked = Convert.ToBoolean(dt.Rows[0]["Hide"]);

                        this.btnSave.Text = "Update";
                    }
                    if (e.ColumnIndex == this.dgv.Columns["Delete"].Index)
                    {
                        if (!this.ObjCore.CheckRightServer(23, this.Id, true))
                        {
                            return;
                        }

                        if (!CommonTask.Question(this.Id, true)) return;

                        this.ObjCore.executeQuery("Delete from ItemList where Id = " + currentId);

                        this.LoadDGV();
                        this.clearForm();
                    }
                }
            }
            catch (Exception ex)
            {

                
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
            this.txtStartPrice.Value = 0;
            this.txtExtra.Value = 0;
            this.txtPrice.Value = 0;
            this.txtOverHead.Value = 0;
            this.chkHide.Checked = false;
            this.btnSave.Text = "Save";
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            this.LoadDGV();
        }

        private void rbtnUnHide_CheckedChanged(object sender, EventArgs e)
        {
            this.LoadDGV();
        }

        private void rbtnHide_CheckedChanged(object sender, EventArgs e)
        {
            this.LoadDGV();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtStartPrice_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                decimal overhead = this.txtStartPrice.Value * (this.PercentRate / 100);
                this.txtOverHead.Value = overhead + this.txtExtra.Value;
                this.txtPrice.Value = this.txtStartPrice.Value + overhead;
            }
            catch (Exception)
            {

            }
        }

        private void txtExtra_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.txtPrice.Value += this.txtExtra.Value;
            }
            catch (Exception)
            {

            }
        }

        private void txtOverHead_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                //decimal overhead = this.txtStartPrice.Value * (this.PercentRate / 100);
                //this.txtOverHead.Value = overhead + this.txtExtra.Value;
                this.txtPrice.Value = this.txtStartPrice.Value + this.txtOverHead.Value + this.txtExtra.Value;
            }
            catch (Exception)
            {

            }
        }


    }
}
