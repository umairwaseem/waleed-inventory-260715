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

namespace Ncsln.Inventory
{
    public partial class frmHBCStockChallan : Form
    {
        CoreClass ObjCore;
        private int Id = -1;
        private bool HBC_verified = false;

        public frmHBCStockChallan()
        {
            InitializeComponent();
            this.ObjCore = new CoreClass();
        }

        private void frmHBCStockChallan_Load(object sender, EventArgs e)
        {
            this.ObjCore.fillGridComboBoxWithAddNewOption((DataGridViewComboBoxColumn)this.dgvItems.Columns["ItemId"], "Select ItemId, Title from Items", this.ObjCore.getClientConnectionString());
            this.LoadDgv();
        }

        private void dgvItems_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                    if (e.ColumnIndex == this.dgvItems.Columns["ItemId"].Index)
                    {
                        frmItemSearch obj = new frmItemSearch();
                        obj.StartPosition = FormStartPosition.CenterParent;
                        obj.ShowDialog();

                        this.ObjCore.fillGridComboBoxWithAddNewOption((DataGridViewComboBoxColumn)this.dgvItems.Columns["ItemId"], "Select ItemId, Title from Items", this.ObjCore.getClientConnectionString());

                        if (obj.Selected)
                        {
                            DataTable dt = this.ObjCore.getDataSet("Select * from Items where ItemId = " + obj.ItemId, this.ObjCore.getClientConnectionString()).Tables[0];

                            this.dgvItems["ItemId", e.RowIndex].Value = obj.ItemId;
                            this.dgvItems.ClearSelection();
                            this.dgvItems.Rows[e.RowIndex].Cells["ModelNo"].Value = dt.Rows[0]["Code"].ToString();
                            this.dgvItems.Rows[e.RowIndex].Cells["Price"].Value = dt.Rows[0]["PurchasePrice"].ToString();
                            this.dgvItems.Rows[e.RowIndex].Cells["Total"].Value = dt.Rows[0]["PurchasePrice"].ToString();
                            this.dgvItems.Rows[e.RowIndex].Cells["Server_Id"].Value = dt.Rows[0]["Server_Id"].ToString();
                            this.dgvItems.CurrentCell = this.dgvItems.Rows[e.RowIndex].Cells["qty"];
                            this.dgvItems.Rows[e.RowIndex].Cells["qty"].Value = 1;
                            this.dgvItems.BeginEdit(true);
                            this.dgvItems.NotifyCurrentCellDirty(true);
                            this.dgvItems.NotifyCurrentCellDirty(false);
                        }
                    }
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

                if (!this.ObjCore.CheckRight(101, this.Id))
                {
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
            string BranchCode = string.Empty;
            if (SetupType.SoftType == SoftwareType.Master)
            {
                BranchCode = this.ObjCore.GetSetting(4);
            }
            else
            {
                BranchCode = companyInfo.branchCode.ToString();
            }

            try
            {
                if (this.Id == -1)
                {
                    com.CommandType = CommandType.StoredProcedure;
                    com.CommandText = "spCreateHBCChallan";

                    com.Parameters.AddWithValue("@Date", this.dtp.Value);
                    com.Parameters.AddWithValue("@Description", this.txtDescription.Text.Trim());
                    com.Parameters.AddWithValue("@Verified", this.chkVerified.Checked.ToString());
                    com.Parameters.AddWithValue("@Branch_Id", BranchCode);

                    DataTable dt = new DataTable("items");
                    dt.Columns.Add(new DataColumn("ItemId", Type.GetType("System.Decimal")));
                    dt.Columns.Add(new DataColumn("Qty", Type.GetType("System.Decimal")));
                    dt.Columns.Add(new DataColumn("ModelNo", Type.GetType("System.String")));
                    dt.Columns.Add(new DataColumn("Price", Type.GetType("System.Decimal")));
                    dt.Columns.Add(new DataColumn("Total", Type.GetType("System.Decimal")));
                    dt.Columns.Add(new DataColumn("Server_Id", Type.GetType("System.Decimal")));
                    for (int i = 0; i < this.dgvItems.Rows.Count - 1; i++)
                    {
                        DataRow newRow = dt.NewRow();
                        newRow["ItemId"] = this.dgvItems["ItemId", i].Value;
                        newRow["Qty"] = this.dgvItems["qty", i].Value;
                        newRow["ModelNo"] = this.dgvItems["ModelNO", i].Value;
                        newRow["Price"] = this.dgvItems["Price", i].Value;
                        newRow["Total"] = this.dgvItems["Total", i].Value;
                        newRow["Server_Id"] = this.dgvItems["Server_Id", i].Value;
                        dt.Rows.InsertAt(newRow, dt.Rows.Count);
                    }

                    System.IO.StringWriter sw = new System.IO.StringWriter();
                    dt.WriteXml(sw);
                    string xmlData = sw.ToString();

                    com.Parameters.AddWithValue("@Detail", xmlData);

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
                        this.HBC_verified = this.chkVerified.Checked;
                        this.btnSave.Text = "Update";

                        this.ObjCore.RecoardLogs("HBC Stock create Challan # : " + this.Id.ToString(), "HBC Stock");
                    }
                    else
                    {
                        this.dgvItems.ClearSelection();
                        MessageBox.Show(message, "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
                else
                {
                    com.CommandType = CommandType.StoredProcedure;
                    com.CommandText = "spUpdateHBCChallan";

                    com.Parameters.AddWithValue("@Id", this.Id);
                    com.Parameters.AddWithValue("@Date", this.dtp.Value);
                    com.Parameters.AddWithValue("@Description", this.txtDescription.Text.Trim());
                    com.Parameters.AddWithValue("@Verified", this.chkVerified.Checked.ToString());
                    com.Parameters.AddWithValue("@Branch_Id", BranchCode);

                    DataTable dt = new DataTable("items");
                    dt.Columns.Add(new DataColumn("ItemId", Type.GetType("System.Decimal")));
                    dt.Columns.Add(new DataColumn("Qty", Type.GetType("System.Decimal")));
                    dt.Columns.Add(new DataColumn("ModelNo", Type.GetType("System.String")));
                    dt.Columns.Add(new DataColumn("Price", Type.GetType("System.Decimal")));
                    dt.Columns.Add(new DataColumn("Total", Type.GetType("System.Decimal")));
                    dt.Columns.Add(new DataColumn("Server_Id", Type.GetType("System.Decimal")));
                    for (int i = 0; i < this.dgvItems.Rows.Count - 1; i++)
                    {
                        DataRow newRow = dt.NewRow();
                        newRow["ItemId"] = this.dgvItems["ItemId", i].Value;
                        newRow["Qty"] = this.dgvItems["qty", i].Value;
                        newRow["ModelNo"] = this.dgvItems["ModelNO", i].Value;
                        newRow["Price"] = this.dgvItems["Price", i].Value;
                        newRow["Total"] = this.dgvItems["Total", i].Value;
                        newRow["Server_Id"] = this.dgvItems["Server_Id", i].Value;
                        dt.Rows.InsertAt(newRow, dt.Rows.Count);
                    }

                    System.IO.StringWriter sw = new System.IO.StringWriter();
                    dt.WriteXml(sw);
                    string xmlData = sw.ToString();

                    com.Parameters.AddWithValue("@Detail", xmlData);

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
                        this.HBC_verified = this.chkVerified.Checked;
                        this.btnSave.Text = "Update";

                        this.ObjCore.RecoardLogs("HBC Stock updated Challan # : " + this.Id.ToString(), "HBC Stock");
                    }
                    else
                    {
                        this.dgvItems.ClearSelection();
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

        private void btnShow_Click(object sender, EventArgs e)
        {
            this.LoadDgv();
        }

        private void dgvShow_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    if (e.ColumnIndex == this.dgvShow.Columns["Edit"].Index)
                    {
                        this.Id = Convert.ToInt32(this.dgvShow["IdShow", e.RowIndex].Value);
                        this.dtp.Value = Convert.ToDateTime(this.dgvShow["dtpShow", e.RowIndex].Value);
                        this.txtDescription.Text = this.dgvShow["txt", e.RowIndex].Value.ToString();
                        this.chkVerified.Checked = Convert.ToBoolean(this.dgvShow["verified", e.RowIndex].Value);
                        this.HBC_verified = Convert.ToBoolean(this.dgvShow["verified", e.RowIndex].Value);

                        this.dsHBCChallanItems1.Clear();
                        this.daHBCChallanItems.SelectCommand.Connection.ConnectionString = this.ObjCore.getClientConnectionString();
                        this.daHBCChallanItems.SelectCommand.Parameters["@Id"].Value = this.Id.ToString();
                        this.daHBCChallanItems.Fill(this.dsHBCChallanItems1);

                        this.btnSave.Text = "Update";
                        this.tabControl1.SelectedTab = this.tabPage1;
                    }

                    if (e.ColumnIndex == this.dgvShow.Columns["Delete"].Index)
                    {
                        if (!this.ObjCore.CheckRight(101, this.Id, true))
                        {
                            return;
                        }

                        if (!CommonTask.Question(this.Id, true)) return;

                        int id = Convert.ToInt32(this.dgvShow["IdShow", e.RowIndex].Value);

                        SqlConnection con = new SqlConnection();
                        con.ConnectionString = this.ObjCore.getClientConnectionString();
                        con.Open();
                        SqlTransaction tran = con.BeginTransaction();
                        SqlCommand com = new SqlCommand("", con, tran);
                        string command = string.Empty;
                        string vendorAccountId = string.Empty;
                        bool success = false;
                        string BranchCode = string.Empty;
                        if (SetupType.SoftType == SoftwareType.Master)
                        {
                            BranchCode = this.ObjCore.GetSetting(4);
                        }
                        else
                        {
                            BranchCode = companyInfo.branchCode.ToString();
                        }
                        try
                        {
                            com.CommandType = CommandType.StoredProcedure;
                            com.CommandText = "spDeleteHBCChallan";

                            com.Parameters.AddWithValue("@Id", id);
                            com.Parameters.AddWithValue("@Branch_Id", BranchCode);


                            com.Parameters.Add(new SqlParameter("@Success", SqlDbType.Bit, 1, ParameterDirection.Output, false, 1, 0, "Success", DataRowVersion.Default, null));
                            com.Parameters.Add(new SqlParameter("@Message", SqlDbType.NVarChar, 200, ParameterDirection.Output, false, 200, 0, "Message", DataRowVersion.Default, null));
                            com.UpdatedRowSource = UpdateRowSource.OutputParameters;
                            com.ExecuteNonQuery();
                            success = Convert.ToBoolean(com.Parameters["@Success"].Value);
                            string message = com.Parameters["@Message"].Value.ToString();
                            if (success)
                                this.ClearForm();

                            if (success)
                                this.ObjCore.RecoardLogs("Internal Stock deleted Challan # : " + Id.ToString(), "HBC Stock");

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
                this.dsHBCChallanShow1.Clear();
                this.daHBCChallanShow.SelectCommand.Connection.ConnectionString = this.ObjCore.getClientConnectionString();
                this.daHBCChallanShow.Fill(this.dsHBCChallanShow1);
            }
            catch (Exception ex)
            {

            }
        }

        private void ClearForm()
        {
            this.Id = -1;
            this.dtp.Value = DateTime.Now;
            this.txtDescription.Text = "";
            this.btnSave.Text = "Save";
            this.HBC_verified = false;
            this.chkVerified.Checked = false;
            this.dsHBCChallanItems1.Clear();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.ClearForm();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (this.Id != -1 && this.HBC_verified == true)
            {
                Reports.frmRptHBCChallan obj = new Reports.frmRptHBCChallan();
                obj.Id = this.Id.ToString();
                obj.MdiParent = this.MdiParent;
                obj.Show();
            }
        }

        private void dgvItems_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {

                    if (e.ColumnIndex == this.dgvItems.Columns["Remove"].Index)
                    {
                        if (!this.ObjCore.CheckRight(101, this.Id, true) && this.Id != -1)
                        {
                            return;
                        }

                        if (!CommonTask.Question(this.Id, true)) return;

                        this.dgvItems.Rows.RemoveAt(e.RowIndex);
                    }

                }
            }
            catch (Exception ex)
            {

            }
        }

        private void dgvItems_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    decimal total = 0;
                    if (this.dgvItems.Columns["qty"].Index == e.ColumnIndex || this.dgvItems.Columns["Price"].Index == e.ColumnIndex)
                    {
                        total = Convert.ToDecimal(this.dgvItems["qty", e.RowIndex].Value) * Convert.ToDecimal(this.dgvItems["Price", e.RowIndex].Value);
                        this.dgvItems["Total", e.RowIndex].Value = total.ToString();
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
