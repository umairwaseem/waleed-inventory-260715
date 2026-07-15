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
    public partial class frmStockIn : Form
    {
        CoreClass ObjCore;
        private int Id;
        public frmStockIn()
        {
            InitializeComponent();
            this.ObjCore = new CoreClass();
            this.Id = -1;
        }

        private void frmStockIn_Load(object sender, EventArgs e)
        {
            this.ObjCore.fillComboBoxOptioni(this.cmbVendor, "Select VendorId, Name from Vendors where VendorId <> 1");
            this.ObjCore.fillComboBoxOptioni(this.cmbBranch, "Select Id, BranchName from Branches");
            this.ObjCore.fillGridComboBoxWithAddNewOption((DataGridViewComboBoxColumn)this.dgvItems.Columns["itemId"], "Select Id, Name from ItemList");

        }

        private void dgvItems_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                if (e.ColumnIndex == this.dgvItems.Columns["Delete"].Index)
                {
                    if (!CommonTask.Question(this.Id, true)) return;

                    this.dgvItems.Rows.RemoveAt(e.RowIndex);
                }
            }
        }

        private void dgvItems_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    if (e.ColumnIndex == this.dgvItems.Columns["qty"].Index)
                    {
                        int qty = Convert.ToInt32(this.dgvItems.Rows[e.RowIndex].Cells["qty"].Value);
                        int price = Convert.ToInt32(this.dgvItems.Rows[e.RowIndex].Cells["price"].Value);

                        this.dgvItems.Rows[e.RowIndex].Cells["Total"].Value = (qty * price).ToString();
                    }

                    if (e.ColumnIndex == this.dgvItems.Columns["price"].Index)
                    {
                        int qty = Convert.ToInt32(this.dgvItems.Rows[e.RowIndex].Cells["qty"].Value);
                        int price = Convert.ToInt32(this.dgvItems.Rows[e.RowIndex].Cells["price"].Value);

                        this.dgvItems.Rows[e.RowIndex].Cells["Total"].Value = (qty * price).ToString();
                    }
                    
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void dgvItems_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                if (e.ColumnIndex == this.dgvItems.Columns["itemId"].Index)
                {
                    frmSearchControl obj = new frmSearchControl();
                    obj.StartPosition = FormStartPosition.CenterScreen;
                    obj.ShowDialog();

                    this.ObjCore.fillGridComboBoxWithAddNewOption((DataGridViewComboBoxColumn)this.dgvItems.Columns["itemId"], "Select Id, Name, OverHead from ItemList");

                    if (obj.Selected)
                    {
                        this.dgvItems["itemId", e.RowIndex].Value = obj.Itemid;
                        this.dgvItems.ClearSelection();
                        this.dgvItems.CurrentCell = this.dgvItems.Rows[e.RowIndex].Cells["qty"];
                        this.dgvItems.Rows[e.RowIndex].Cells["qty"].Value = 1;
                        this.dgvItems.Rows[e.RowIndex].Cells["ModelNo"].Value = obj.modelNo;
                        this.dgvItems.Rows[e.RowIndex].Cells["price"].Value = obj.pprice;
                        this.dgvItems.Rows[e.RowIndex].Cells["Total"].Value = obj.pprice;
                        this.dgvItems.Rows[e.RowIndex].Cells["OverHead"].Value = obj.overHead;
                        this.dgvItems.BeginEdit(true);
                        this.dgvItems.NotifyCurrentCellDirty(true);
                        this.dgvItems.NotifyCurrentCellDirty(false);
                    }
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!this.ObjCore.CheckRightServer(27, this.Id))
                {
                    return;
                }

                if (this.cmbVendor.SelectedValue == null || this.cmbVendor.SelectedValue.ToString() == "-1" )
                {
                    MessageBox.Show("Please select a vendor!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                    com.CommandText = "spCreateStockIn";

                    com.Parameters.AddWithValue("@StockDate", this.dtp.Value);
                    com.Parameters.AddWithValue("@Description", this.txtDescription.Text.Trim());
                    com.Parameters.AddWithValue("@Vendor_Id", this.cmbVendor.SelectedValue);
                    com.Parameters.AddWithValue("@Branch_Id", this.cmbBranch.SelectedValue);

                    DataTable dt = new DataTable("Detail");
                    dt.Columns.Add(new DataColumn("ItemId", Type.GetType("System.Decimal")));
                    dt.Columns.Add(new DataColumn("Qty", Type.GetType("System.Decimal")));
                    dt.Columns.Add(new DataColumn("Price", Type.GetType("System.Decimal")));
                    dt.Columns.Add(new DataColumn("Total", Type.GetType("System.Decimal")));
                    dt.Columns.Add(new DataColumn("ModelNo", Type.GetType("System.String")));
                    dt.Columns.Add(new DataColumn("OverHead", Type.GetType("System.String")));
                    for (int i = 0; i < this.dgvItems.Rows.Count - 1; i++)
                    {
                        DataRow newRow = dt.NewRow();
                        newRow["ItemId"] = this.dgvItems["itemId", i].Value;
                        newRow["ModelNo"] = this.dgvItems["ModelNo", i].Value;
                        newRow["Qty"] = this.dgvItems["qty", i].Value;
                        newRow["Price"] = this.dgvItems["price", i].Value;
                        newRow["Total"] = this.dgvItems["Total", i].Value;
                        newRow["OverHead"] = this.dgvItems["OverHead", i].Value;
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
                       
                        this.btnSave.Text = "Update";
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
                    com.CommandText = "spUpdateStockIn";

                    com.Parameters.AddWithValue("@Id", this.Id);
                    com.Parameters.AddWithValue("@StockDate", this.dtp.Value);
                    com.Parameters.AddWithValue("@Description", this.txtDescription.Text.Trim());
                    com.Parameters.AddWithValue("@Vendor_Id", this.cmbVendor.SelectedValue);
                    com.Parameters.AddWithValue("@Branch_Id", this.cmbBranch.SelectedValue);

                    DataTable dt = new DataTable("Detail");
                    dt.Columns.Add(new DataColumn("ItemId", Type.GetType("System.Decimal")));
                    dt.Columns.Add(new DataColumn("Qty", Type.GetType("System.Decimal")));
                    dt.Columns.Add(new DataColumn("Price", Type.GetType("System.Decimal")));
                    dt.Columns.Add(new DataColumn("Total", Type.GetType("System.Decimal")));
                    dt.Columns.Add(new DataColumn("ModelNo", Type.GetType("System.String")));
                    dt.Columns.Add(new DataColumn("OverHead", Type.GetType("System.String")));
                    for (int i = 0; i < this.dgvItems.Rows.Count - 1; i++)
                    {
                        DataRow newRow = dt.NewRow();
                        newRow["ItemId"] = this.dgvItems["itemId", i].Value;
                        newRow["ModelNo"] = this.dgvItems["ModelNo", i].Value;
                        newRow["Qty"] = this.dgvItems["qty", i].Value;
                        newRow["Price"] = this.dgvItems["price", i].Value;
                        newRow["Total"] = this.dgvItems["Total", i].Value;
                        newRow["OverHead"] = this.dgvItems["OverHead", i].Value;
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
                    if (success)
                        this.Id = Convert.ToInt32(com.Parameters["@Id"].Value);
       
                    tran.Commit();
                    if (success)
                    {

                        this.btnSave.Text = "Update";
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

        private void dgvShow_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {

                if (e.ColumnIndex == this.dgvShow.Columns["Edit"].Index)
                {
                    this.Id = Convert.ToInt32(this.dgvShow["showId", e.RowIndex].Value);

                    this.lb.Text = "Id # " + Id.ToString();

                    this.dtp.Value = Convert.ToDateTime(this.dgvShow["stockDate", e.RowIndex].Value);
                    this.txtDescription.Text = this.dgvShow["description", e.RowIndex].Value.ToString();
                    this.cmbVendor.SelectedValue = this.dgvShow["vendorId", e.RowIndex].Value.ToString();
                    if (this.dgvShow["Branch_Id", e.RowIndex].Value.ToString() != string.Empty)
                        this.cmbBranch.SelectedValue = this.dgvShow["Branch_Id", e.RowIndex].Value.ToString();

                    this.dsStockInItems1.Clear();
                    this.daStockItems.SelectCommand.Connection.ConnectionString = this.ObjCore.getConnectionString();
                    this.daStockItems.SelectCommand.Parameters["@Id"].Value = this.Id.ToString();
                    this.daStockItems.Fill(this.dsStockInItems1);

                    this.btnSave.Text = "Update";
                    this.tabControl1.SelectedTab = this.tabPage1;
                }

                if (e.ColumnIndex == this.dgvShow.Columns["DeleteShow"].Index)
                {
                    if (!this.ObjCore.CheckRightServer(27, this.Id, true))
                    {
                        return;
                    }

                    if (!CommonTask.Question(this.Id, true)) return;

                    int id = Convert.ToInt32(this.dgvShow["showId", e.RowIndex].Value);

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
                        com.CommandText = "spDeleteStockIn";

                        com.Parameters.AddWithValue("@Id", id);

                        com.Parameters.Add(new SqlParameter("@Success", SqlDbType.Bit, 1, ParameterDirection.Output, false, 1, 0, "Success", DataRowVersion.Default, null));
                        com.Parameters.Add(new SqlParameter("@Message", SqlDbType.NVarChar, 200, ParameterDirection.Output, false, 200, 0, "Message", DataRowVersion.Default, null));
                        com.UpdatedRowSource = UpdateRowSource.OutputParameters;
                        com.ExecuteNonQuery();
                        success = Convert.ToBoolean(com.Parameters["@Success"].Value);
                        string message = com.Parameters["@Message"].Value.ToString();
                        if (success)
                            this.ClearForm();

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

        private void btnShow_Click(object sender, EventArgs e)
        {
            this.LoadDgv();
        }

        private void LoadDgv()
        {
            try
            {
                this.dsStockIN.Clear();
                this.daMStockInSHow.SelectCommand.Connection.ConnectionString = this.ObjCore.getConnectionString();
                this.daMStockInSHow.Fill(this.dsStockIN);
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
            this.dtp.Value = DateTime.Now;
            this.cmbVendor.SelectedIndex = 1;
            this.txtDescription.Text = "";
            this.btnSave.Text = "Save";
            this.Id = -1;
            this.dsStockInItems1.Clear();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.Id != -1)
                {
                    Reports.frmRptPrint obj = new Reports.frmRptPrint();
                    obj.Id = this.Id;
                    obj.MdiParent = this.MdiParent;
                    obj.Show();
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.vMStockInBindingSource.Filter = " Name like '%" + this.txtSearch.Text.Trim() + "%' or CONVERT(Id, System.String) like '%" + this.txtSearch.Text.Trim() + "%'";
            }
            catch (Exception)
            {

            }
        }
    }
}
