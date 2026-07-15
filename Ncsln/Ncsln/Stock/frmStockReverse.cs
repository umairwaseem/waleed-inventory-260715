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
    public partial class frmStockReverse : Form
    {
        CoreClass ObjCore;
        private int Id = -1;

        public frmStockReverse()
        {
            InitializeComponent();
            this.ObjCore = new CoreClass();
        }

        private void frmStockReverse_Load(object sender, EventArgs e)
        {
            try
            {
                this.ObjCore.fillComboBoxOptioni(this.cmbItems, "Select ItemId, Code + ' ' + Title + ' (' + Convert(nvarchar(50), ItemId) + ')' as Title from Items where Code like 'V1 %' and ItemId > 10000", this.ObjCore.getClientConnectionString());
                this.LoadDgv();
            }
            catch (Exception ex)
            {

            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!this.ObjCore.TimeEntryLock(this.dtp.Value)) return;

                if (!this.ObjCore.CheckRight(103, this.Id))
                {
                    return;
                }

                if (this.cmbItems.SelectedValue == null || this.cmbItems.SelectedValue.ToString() == "-1")
                {
                    MessageBox.Show("Please select any item first", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;                    
                }

                if (this.txtQty.Value < 1)
                {
                    MessageBox.Show("Please enter qty more then 0", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (this.txtDescription.Text == "")
                {
                    MessageBox.Show("Please enter description of return", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.txtDescription.Focus();
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
            if (!CommonTask.Question(this.Id)) return;

            SqlConnection con = new SqlConnection();
            con.ConnectionString = this.ObjCore.getClientConnectionString();
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
                    com.CommandText = "spCreateHBCReverse";

                    com.Parameters.AddWithValue("@ItemId", this.cmbItems.SelectedValue.ToString());
                    com.Parameters.AddWithValue("@Qty", this.txtQty.Value);
                    com.Parameters.AddWithValue("@Date", this.dtp.Value);
                    com.Parameters.AddWithValue("@BranchId", companyInfo.branchCode.ToString());
                    com.Parameters.AddWithValue("@Description", this.txtDescription.Text.Trim());                    

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
                    }
                    else
                    {
                       // this.dgvItems.ClearSelection();
                        MessageBox.Show(message, "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
                else
                {
                    com.CommandType = CommandType.StoredProcedure;
                    com.CommandText = "spUpdateHBCReverse";

                    com.Parameters.AddWithValue("@Id", this.Id);
                    com.Parameters.AddWithValue("@ItemId", this.cmbItems.SelectedValue.ToString());
                    com.Parameters.AddWithValue("@Qty", this.txtQty.Value);
                    com.Parameters.AddWithValue("@Date", this.dtp.Value);
                    com.Parameters.AddWithValue("@BranchId", companyInfo.branchCode.ToString());
                    com.Parameters.AddWithValue("@Description", this.txtDescription.Text.Trim());    

                    com.Parameters.Add(new SqlParameter("@Success", SqlDbType.Bit, 1, ParameterDirection.Output, false, 1, 0, "Success", DataRowVersion.Default, null));
                    com.Parameters.Add(new SqlParameter("@Message", SqlDbType.NVarChar, 200, ParameterDirection.Output, false, 200, 0, "Message", DataRowVersion.Default, null));
                    com.UpdatedRowSource = UpdateRowSource.OutputParameters;
                    com.ExecuteNonQuery();
                    success = Convert.ToBoolean(com.Parameters["@Success"].Value);
                    string message = com.Parameters["@Message"].Value.ToString();
                    string itemIdStock = string.Empty;
         

                    tran.Commit();
                    if (success)
                    {

                        this.btnSave.Text = "Update";
                    }
                    else
                    {
                        //this.dgvItems.ClearSelection();
                        MessageBox.Show(message, "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
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
               this.LoadDgv();
            }
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    if (e.ColumnIndex == this.dgv.Columns["Select"].Index)
                    {
                        this.dgv["Select", e.RowIndex].Value = !Convert.ToBoolean(this.dgv["Select", e.RowIndex].Value);
                    }

                    if (e.ColumnIndex == this.dgv.Columns["Edit"].Index)
                    {
                        int id = Convert.ToInt32(this.dgv["searchId", e.RowIndex].Value);

                        DataTable dt = this.ObjCore.getDataSet("Select * from HBCReverse where Id = " + id.ToString(), this.ObjCore.getClientConnectionString()).Tables[0];

                        this.cmbItems.SelectedValue = dt.Rows[0]["ItemId"].ToString();
                        this.txtQty.Value = Convert.ToDecimal(dt.Rows[0]["Qty"]);
                        this.dtp.Value = Convert.ToDateTime(dt.Rows[0]["Date"]);

                        this.Id = id;
                        this.btnSave.Text = "Update";

                    }

                    if (e.ColumnIndex == this.dgv.Columns["Delete"].Index)
                    {
                        if (!this.ObjCore.CheckRight(103, this.Id, true))
                        {
                            return;
                        }

                        if (!CommonTask.Question(this.Id, true)) return;

                        this.ClearForm();

                        int id = Convert.ToInt32(this.dgv["searchId", e.RowIndex].Value);

                        SqlConnection con = new SqlConnection();
                        con.ConnectionString = this.ObjCore.getClientConnectionString();
                        con.Open();
                        SqlTransaction tran = con.BeginTransaction();
                        SqlCommand com = new SqlCommand("", con, tran);
                        string command = string.Empty;
                        string vendorAccountId = string.Empty;
                        bool success = false;
                        try
                        {
                            
                                com.CommandType = CommandType.StoredProcedure;
                                com.CommandText = "spDeleteHBCReverse";

                                com.Parameters.AddWithValue("@Id", id);
                                com.Parameters.AddWithValue("@BranchId", companyInfo.branchCode.ToString()); 

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

                                    
                                }
                                else
                                {
                                    //this.dgvItems.ClearSelection();
                                    MessageBox.Show(message, "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
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
                            this.LoadDgv();
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void LoadDgv()
        {
            try
            {
                this.dsStockReverse.Clear();
                this.daStockReverse.SelectCommand.Connection.ConnectionString = this.ObjCore.getClientConnectionString();
                this.daStockReverse.Fill(this.dsStockReverse);
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
            this.Id = -1;
            //this.cmbItems.SelectedValue = "-1";
            this.txtQty.Value = 0;
            this.dtp.Value = DateTime.Now;
            this.btnSave.Text = "Save";
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                string ids = string.Empty;
                for (int i = 0; i < this.dgv.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(this.dgv["Select", i].Value))
                    {
                        ids += this.dgv["searchId", i].Value.ToString();
                        ids += ",";
                    }
                }

                ids = ids.Remove(ids.Length - 1, 1);

                Reports.frmRptStockReverse obj = new Reports.frmRptStockReverse();
                obj.ids = ids;
                obj.MdiParent = this.MdiParent;
                obj.Show();
            }
            catch (Exception ex)
            {

            }
        }
    }
}
