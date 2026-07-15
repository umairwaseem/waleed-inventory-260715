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
    public partial class frmStockRectify : Form
    {
        CoreClass ObjCore;
        public int Id = -1;
        public bool HBCItem = true;
        public bool QuickCall = false;

        public frmStockRectify()
        {
            InitializeComponent();
            this.ObjCore = new CoreClass();
        }

        private void frmItems_Load(object sender, EventArgs e)
        {
            this.ObjCore.fillComboBoxOptioni(this.cmbItems, "Select Id, Code + ' ' + Name + ' (' + Convert(nvarchar(50), Id) + ')' from ItemList", this.ObjCore.getHBCConnectionString());
            this.LoadDGV();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!this.ObjCore.CheckRightServer(55, this.Id))
                {
                    return;
                }

                if (!CommonTask.Question(this.Id)) return;

                if (this.cmbItems.SelectedValue.ToString() == "-1" || this.cmbItems.SelectedValue == null)
                {
                    MessageBox.Show("Please Select Item/Product", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.cmbItems.Focus();
                    return;
                }

                if (this.txtQty.Value < 1)
                {
                    MessageBox.Show("The qty must not be zero", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                    com.CommandText = "spCreateSStockRectify";

                    com.Parameters.AddWithValue("@ItemId", this.cmbItems.SelectedValue.ToString());
                    com.Parameters.AddWithValue("@Qty", this.txtQty.Value);
                    com.Parameters.AddWithValue("@QtyType", this.rbtAdd.Checked.ToString());
                    com.Parameters.AddWithValue("@Description", this.txtDescription.Text.Trim());
                    com.Parameters.AddWithValue("@Date", this.dtp.Value.ToString());                  

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
                    com.CommandText = "spUpdateSStockRectify";

                    com.Parameters.AddWithValue("@Id", this.Id);
                    com.Parameters.AddWithValue("@ItemId", this.cmbItems.SelectedValue.ToString());
                    com.Parameters.AddWithValue("@Qty", this.txtQty.Value);
                    com.Parameters.AddWithValue("@QtyType", this.rbtAdd.Checked.ToString());
                    com.Parameters.AddWithValue("@Description", this.txtDescription.Text.Trim());
                    com.Parameters.AddWithValue("@Date", this.dtp.Value.ToString());                   

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
                //if (this.HBCItem)
                //{
                //    this.dsSItems.Clear();
                //    this.daSItems.SelectCommand.Connection.ConnectionString = this.ObjCore.getConnectionString();
                //    this.daSItems.SelectCommand.Parameters["@key"].Value = this.txtSearch.Text.Trim();
                //    this.daSItems.Fill(this.dsSItems);
                //}
                //else
                //{
                //    this.dsSItems.Clear();
                //    this.daSTimeNotHBC.SelectCommand.Connection.ConnectionString = this.ObjCore.getConnectionString();
                //    this.daSTimeNotHBC.SelectCommand.Parameters["@key"].Value = this.txtSearch.Text.Trim();
                //    this.daSTimeNotHBC.Fill(this.dsSItems);
                //}

                this.dsStockRectify1.Clear();
                this.dsStockRectify1.EnforceConstraints = false;
                this.daStockRectify.SelectCommand.Connection.ConnectionString = this.ObjCore.getHBCConnectionString();
                this.daStockRectify.Fill(this.dsStockRectify1);

                //for (int i = 0; i < this.dgv.Rows.Count; i++)
                //{
                //    if (Convert.ToBoolean(this.dgv["qtyType", i].Value))
                //        this.dgv.Rows[i].DefaultCellStyle.BackColor = Color.LightGreen;
                //    else
                //        this.dgv.Rows[i].DefaultCellStyle.BackColor = Color.PaleVioletRed;
                        
                //}

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
                    string currentId = this.dgv["Ids", e.RowIndex].Value.ToString();
                    if (e.ColumnIndex == this.dgv.Columns["Edit"].Index)
                    {

                        DataTable dt = this.ObjCore.getDataSet("Select * from SStockRectify where Id = '" + currentId + "'").Tables[0];
                        this.Id = Convert.ToInt32(currentId);

                        this.cmbItems.SelectedValue = dt.Rows[0]["ItemId"].ToString();
                        this.txtDescription.Text = dt.Rows[0]["Description"].ToString();
                        this.txtQty.Value = Convert.ToDecimal(dt.Rows[0]["Qty"]);
                        this.rbtAdd.Checked = Convert.ToBoolean(dt.Rows[0]["QtyType"]);
                        this.rbtnLess.Checked = !Convert.ToBoolean(dt.Rows[0]["QtyType"]);
                        this.dtp.Value = Convert.ToDateTime(dt.Rows[0]["Date"]);
                        this.btnSave.Text = "Update";
                    }
                    if (e.ColumnIndex == this.dgv.Columns["Delete"].Index)
                    {
                        if (!this.ObjCore.CheckRightServer(55, this.Id, true))
                        {
                            return;
                        }

                        if (!CommonTask.Question(this.Id, true)) return;

                        //this.ObjCore.executeQuery("Delete from ItemList where Id = " + currentId);

                        //this.LoadDGV();
                        //this.clearForm();

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
                            com.CommandText = "spDeleteSStockRectify";

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
            this.txtDescription.Text = "";
            this.txtQty.Value = 0;
            this.rbtAdd.Checked = true;
            this.rbtnLess.Checked = false;
            this.cmbItems.SelectedIndex = 1;
            this.btnSave.Text = "Save";
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            this.LoadDGV();
        }

        private void dgv_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            try
            {
                if (Convert.ToBoolean(this.dgv["qtyType", e.RowIndex].Value))
                    this.dgv.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGreen;
                else
                    this.dgv.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.PaleVioletRed;
                        
            }
            catch (Exception ex)
            {

            }
        }


    }
}
