using Ncsln.Classes;
using Ncsln.DBModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Objects;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Ncsln.Inventory
{
    public partial class frmInternalStock : Form
    {

        CoreClass ObjCore;
        InventoryEntities DB;
        InternalStock model;
        bool StockType;


        public frmInternalStock()
        {
            InitializeComponent();
            this.ObjCore = new CoreClass();
            this.StockType = false;
        }

        private void frmInternalStock_Load(object sender, EventArgs e)
        {
            this.ObjCore.fillComboBoxOptioni(this.cmbBranches, "Select Id, BranchName from Branches", this.ObjCore.getHBCConnectionString());

            this.ObjCore.fillComboBoxOptioni(this.cmbItem, "Select ItemId, Code + ' ' + Title + ' (' + Convert(nvarchar(50), ItemId) + ')' from Items  where ItemId > 10000 and Hide = 0", this.ObjCore.getClientConnectionString());
            this.model = new InternalStock() { Id = -1 };
            this.LoadData();
        }

        private void LoadData()
        {
            try
            {
                this.dsIntenalStock1.Clear();
                this.daIntenalStock.SelectCommand.Connection.ConnectionString = this.ObjCore.getClientConnectionString();
                this.daIntenalStock.Fill(this.dsIntenalStock1);
            }
            catch (Exception Ex)
            {

            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ObjCore.TimeEntryLock(this.dtp.Value)) return;

            if (!this.ObjCore.CheckRight(20, this.model.Id))
            {
                return;
            }

            if (this.txtFromTo.Text.Trim() == "")
            {
                MessageBox.Show("Please enter From/To ", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtFromTo.Focus();
                return;
            }

            if (this.cmbItem.SelectedValue == null || this.cmbItem.SelectedValue.ToString() == "-1")
            {
                MessageBox.Show("Please select a item!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (this.txtQty.Value < 1)
            {
                MessageBox.Show("Please enter qty", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtQty.Focus();
                return;
            }

            this.Save();

        }

        private void Save()
        {
            if (!CommonTask.Question(this.model.Id)) return;

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
                if (this.model.Id == -1)
                {
                    com.CommandType = CommandType.StoredProcedure;
                    com.CommandText = "spCreateInternalStock";

                    com.Parameters.AddWithValue("@ItemId", this.cmbItem.SelectedValue.ToString());
                    com.Parameters.AddWithValue("@StockDate", this.dtp.Value);
                    com.Parameters.AddWithValue("@Qty", this.txtQty.Value);
                    com.Parameters.AddWithValue("@CompanyName", this.txtFromTo.Text.Trim());
                    com.Parameters.AddWithValue("@Type", this.StockType);

                    com.Parameters.AddWithValue("@BranchType", "Stock");
                    com.Parameters.AddWithValue("@Verified", this.chkVerified.Checked.ToString());
                    com.Parameters.AddWithValue("@Branch_Id", this.cmbBranches.SelectedValue.ToString());
                    com.Parameters.AddWithValue("@CurrentBranch_Id", Classes.companyInfo.branchCode.ToString());
                    com.Parameters.AddWithValue("@Server_Id", this.Server_Id.ToString());

                    com.Parameters.AddWithValue("@UserId", this.ObjCore.getUserId());                    

                    com.Parameters.Add(new SqlParameter("@Id", SqlDbType.Decimal, 18, ParameterDirection.Output, false, 18, 0, "SaleId", DataRowVersion.Default, null));
                    com.Parameters.Add(new SqlParameter("@Success", SqlDbType.Bit, 1, ParameterDirection.Output, false, 1, 0, "Success", DataRowVersion.Default, null));
                    com.Parameters.Add(new SqlParameter("@Message", SqlDbType.NVarChar, 200, ParameterDirection.Output, false, 200, 0, "Message", DataRowVersion.Default, null));
                    com.UpdatedRowSource = UpdateRowSource.OutputParameters;
                    com.ExecuteNonQuery();
                    success = Convert.ToBoolean(com.Parameters["@Success"].Value);
                    string message = com.Parameters["@Message"].Value.ToString();
                    if (success)
                        this.model.Id = Convert.ToInt32(com.Parameters["@Id"].Value);
                    tran.Commit();
                    if (success)
                    {
                        this.btnSave.Text = "Update";
                        MessageBox.Show(message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.ClearForm();

                        this.ObjCore.RecoardLogs("Internal Stock create Challan # : " + this.model.Id.ToString(), "Internal Stock");
                    }
                    else
                    {
                        MessageBox.Show(message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    com.CommandType = CommandType.StoredProcedure;
                    com.CommandText = "spUpdateInternalStock";

                    com.Parameters.AddWithValue("@Id", this.model.Id);
                    com.Parameters.AddWithValue("@ItemId", this.cmbItem.SelectedValue.ToString());
                    com.Parameters.AddWithValue("@StockDate", this.dtp.Value);
                    com.Parameters.AddWithValue("@Qty", this.txtQty.Value);
                    com.Parameters.AddWithValue("@CompanyName", this.txtFromTo.Text.Trim());
                    com.Parameters.AddWithValue("@Type", this.StockType);
                    com.Parameters.AddWithValue("@BranchType", "Stock");
                    com.Parameters.AddWithValue("@Verified", this.chkVerified.Checked.ToString());

                    com.Parameters.AddWithValue("@UserId", this.ObjCore.getUserId()); 

                    com.Parameters.Add(new SqlParameter("@Success", SqlDbType.Bit, 1, ParameterDirection.Output, false, 1, 0, "Success", DataRowVersion.Default, null));
                    com.Parameters.Add(new SqlParameter("@Message", SqlDbType.NVarChar, 200, ParameterDirection.Output, false, 200, 0, "Message", DataRowVersion.Default, null));
                    com.UpdatedRowSource = UpdateRowSource.OutputParameters;
                    com.ExecuteNonQuery();
                    success = Convert.ToBoolean(com.Parameters["@Success"].Value);
                    string message = com.Parameters["@Message"].Value.ToString();
                    if (success)
                        this.model.Id = Convert.ToInt32(com.Parameters["@Id"].Value);
                    tran.Commit();
                    if (success)
                    {
                        MessageBox.Show(message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.ClearForm();
                        this.ObjCore.RecoardLogs("Internal Stock updated Challan # : " + this.model.Id.ToString(), "Internal Stock");
                    }
                    else
                    {
                        MessageBox.Show(message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                this.LoadData();
            }
        }

        private void rbtnIn_CheckedChanged(object sender, EventArgs e)
        {
            this.StockInOut();
        }

        private void rbtnOut_CheckedChanged(object sender, EventArgs e)
        {
            this.StockInOut();
        }

        private void StockInOut()
        {
            this.StockType = this.rbtnIn.Checked;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.ClearForm();
        }

        private void ClearForm()
        {
            this.txtFromTo.Text = "";
            this.txtQty.Value = 0;
            this.dtp.Value = DateTime.Now;
            this.StockType = true;
            this.rbtnIn.Checked = false;
            this.rbtnOut.Checked = true;
            this.btnSave.Text = "Save";
            this.model.Id = -1;
            this.chkVerified.Enabled = false;
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == this.dgv.Columns["Edit"].Index)
                {
                    int id = (Int32)this.dgv["id", e.RowIndex].Value;

                    DataTable dt = this.ObjCore.getDataSet("Select * from InternalStock where Id = " + id.ToString(), this.ObjCore.getClientConnectionString()).Tables[0];

                    this.txtFromTo.Text = dt.Rows[0]["CompanyName"].ToString();
                    this.txtQty.Value = Convert.ToDecimal(dt.Rows[0]["Qty"]);
                    this.dtp.Value = Convert.ToDateTime(dt.Rows[0]["StockDate"]);
                    this.cmbItem.SelectedValue = dt.Rows[0]["ItemId"].ToString();
                    if (Convert.ToBoolean(dt.Rows[0]["Type"]))
                    {
                        this.rbtnIn.Checked = true;
                        this.rbtnOut.Checked = false;
                    }
                    else
                    {
                        this.rbtnIn.Checked = false;
                        this.rbtnOut.Checked = true;
                    }

                    this.model.Id = id;

                    this.chkVerified.Checked = Convert.ToBoolean(dt.Rows[0]["Verified"]);

                    this.Server_Id = dt.Rows[0]["Server_Id"].ToString();

                    this.txtFromTo.Text = dt.Rows[0]["CompanyName"].ToString();
                    this.btnSave.Text = "Update";
                    this.chkVerified.Enabled = true;

                    //using (this.DB = new InventoryEntities(this.ObjCore.getClientConnectionStringName()))
                    //{
                    //    this.model = this.DB.InternalStocks.Where(x => x.Id == id).FirstOrDefault();
                    //    this.txtFromTo.Text = this.model.CompanyName;
                    //    this.txtQty.Value = (decimal)this.model.Qty;
                    //    this.dtp.Value = (DateTime)this.model.StockDate;
                    //    this.cmbItem.SelectedValue = this.model.ItemId.ToString();
                    //    if ((bool)this.model.Type)
                    //    {
                    //        this.rbtnIn.Checked = true;
                    //        this.rbtnOut.Checked = false;
                    //    }
                    //    else
                    //    {
                    //        this.rbtnIn.Checked = false;
                    //        this.rbtnOut.Checked = true;
                    //    }
                    //    this.btnSave.Text = "Update";
                    //    this.chkVerified.Enabled = true;

                    //}
                                        
                }

                if (e.ColumnIndex == this.dgv.Columns["Delete"].Index)
                {
                    if (!this.ObjCore.CheckRight(20, this.model.Id, true))
                    {
                        return;
                    }

                    if (!CommonTask.Question(this.model.Id, true)) return;

                    this.ClearForm();

                    int id = (Int32)this.dgv["id", e.RowIndex].Value;
                    ObjectParameter Success = new ObjectParameter("Success", typeof(bool));
                    ObjectParameter msg = new ObjectParameter("Message", typeof(string));
                    
                    using (this.DB = new InventoryEntities(this.ObjCore.getClientConnectionStringName()))
                    {
                        this.DB.spDeleteInternalStock(id, Success, msg);
                        if ((bool)Success.Value)
                        {
                            this.ObjCore.RecoardLogs("Internal Stock deleted Challan # : " + id.ToString(), "Internal Stock");
                            MessageBox.Show(msg.Value.ToString(), "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        
                    }

                    this.LoadData();
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.dsIntenalStock1.Clear();
                this.daInternalStockSearch.SelectCommand.Connection.ConnectionString = this.ObjCore.getClientConnectionString();
                this.daInternalStockSearch.SelectCommand.Parameters["@key"].Value = this.txtSearch.Text.Trim();
                this.daInternalStockSearch.Fill(this.dsIntenalStock1);
            }
            catch (Exception ex)
            {

            }
        }

        private void cmbBranches_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = this.ObjCore.getDataSet("Select * from Branches where Id = " + this.cmbBranches.SelectedValue.ToString(), this.ObjCore.getHBCConnectionString()).Tables[0];
                this.txtFromTo.Text = dt.Rows[0]["BranchName"].ToString();
            }
            catch (Exception ex)
            {

            }
        }

        private string Server_Id;

        private void cmbItem_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = this.ObjCore.getDataSet("select * from Items where ItemId = " + this.cmbItem.SelectedValue.ToString(), this.ObjCore.getClientConnectionString()).Tables[0];
                this.Server_Id = dt.Rows[0]["Server_Id"].ToString();
            }
            catch (Exception ex)
            {

            }
        }

        private void cmbItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = this.ObjCore.getDataSet("select * from Items where ItemId = " + this.cmbItem.SelectedValue.ToString(), this.ObjCore.getClientConnectionString()).Tables[0];
                this.Server_Id = dt.Rows[0]["Server_Id"].ToString();
            }
            catch (Exception ex)
            {

            }
        }
    }
}
