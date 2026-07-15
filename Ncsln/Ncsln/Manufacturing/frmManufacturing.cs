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
    public partial class frmManufacturing : Form
    {
        CoreClass ObjCore;
        private int Id;
        public frmManufacturing()
        {
            InitializeComponent();
            this.ObjCore = new CoreClass();
            this.Id = -1;
        }

        private void frmStockIn_Load(object sender, EventArgs e)
        {
            this.ObjCore.fillComboBoxOptioni(this.cmbVendor, "Select VendorId, Name from Vendors");
            this.ObjCore.fillGridComboBoxWithAddNewOption((DataGridViewComboBoxColumn)this.dgvItems.Columns["itemId"], "Select Id, Name from ItemList");

            this.ObjCore.fillComboBoxOptioni(this.cmbBranch, "Select Id, BranchName from Branches", this.ObjCore.getHBCConnectionString());
        }

        private void dgvItems_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                if (e.ColumnIndex == this.dgvItems.Columns["Delete"].Index)
                {
                    if (!CommonTask.Question(this.Id, true)) return;

                    this.dgvItems.Rows.RemoveAt(e.RowIndex);
                    this.Calculate();
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
            finally
            {
                this.Calculate();
            }
        }

        private void dgvItems_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                if (e.ColumnIndex == this.dgvItems.Columns["itemId"].Index)
                {
                    frmSearchControl obj = new frmSearchControl();
                    obj.ForManufacturing = true;
                    obj.StartPosition = FormStartPosition.CenterScreen;
                    obj.ShowDialog();

                    if (obj.Selected)
                    {
                        this.dgvItems["itemId", e.RowIndex].Value = obj.Itemid;
                        this.dgvItems.ClearSelection();
                        this.dgvItems.CurrentCell = this.dgvItems.Rows[e.RowIndex].Cells["qty"];
                        this.dgvItems.Rows[e.RowIndex].Cells["qty"].Value = 1;
                        this.dgvItems.Rows[e.RowIndex].Cells["ModelNo"].Value = obj.modelNo;
                        this.dgvItems.Rows[e.RowIndex].Cells["price"].Value = obj.pprice;
                        this.dgvItems.Rows[e.RowIndex].Cells["Total"].Value = obj.pprice;
                        this.dgvItems.BeginEdit(true);
                        this.dgvItems.NotifyCurrentCellDirty(true);
                        this.dgvItems.NotifyCurrentCellDirty(false);
                    }
                }
            }
            this.Calculate();
        }

        private void Calculate()
        {
            try
            {
                decimal total = 0;
                for (int i = 0; i < this.dgvItems.Rows.Count; i++)
                {
                    total += Convert.ToDecimal(this.dgvItems["Total", i].Value);
                }
                this.lbTotal.Text = "Total : " + total.ToString();
                this.txtPrice.Value = Convert.ToDecimal(total);
            }
            catch (Exception ex)
            {

            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!this.ObjCore.CheckRightServer(28, this.Id))
                {
                    return;
                }

                if (this.cmbItems.SelectedValue == null || this.cmbItems.SelectedValue.ToString() == "-1")
                {
                    MessageBox.Show("Please Select Item!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                //if (this.txtDescription.Text.Trim() == string.Empty)
                //{
                //    MessageBox.Show("Please entry new product detail!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //    this.txtDescription.Focus();
                //    return;
                //}

                //if (this.txtModelNo.Text.Trim() == string.Empty)
                //{
                //    MessageBox.Show("Please entry new product model #!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //    this.txtModelNo.Focus();
                //    return;
                //}

                if (this.txtQty.Value < 1)
                {
                    MessageBox.Show("Please entry qty!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.txtQty.Focus();
                    return;
                }

                this.PreCheck();
            }
            catch (Exception ex)
            {

            }
        }

        private void PreCheck()
        {
            try
            {
                bool StockVerify = false;
                if (this.Id == -1)
                {
                    for (int i = 0; i < this.dgvItems.Rows.Count - 1; i++)
                    {
                        DataTable dt = this.ObjCore.getDataSet("Select dbo.funGetMStock(" + this.dgvItems["ItemId", i].Value.ToString() + ")").Tables[0];

                        if (Convert.ToInt32(dt.Rows[0][0]) < Convert.ToInt32(this.dgvItems["qty", i].Value))
                        {
                            this.dgvItems.ClearSelection();
                            this.dgvItems.Rows[i].Selected = true;
                            MessageBox.Show("The selected row item has not enough qty", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            StockVerify = false;
                            break;
                        }
                        else
                        {
                            StockVerify = true;
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < this.dgvItems.Rows.Count - 1; i++)
                    {
                        int preQty = 0;

                        DataTable dt = this.ObjCore.getDataSet("Select dbo.funGetMStock(" + this.dgvItems["ItemId", i].Value.ToString() + ")").Tables[0];

                        DataTable dtt = this.ObjCore.getDataSet("Select Qty from MFinishGoodsDetail where Item_Id = " + this.dgvItems["ItemId", i].Value.ToString() + " and FinishGoods_Id = " + this.Id.ToString() + "").Tables[0];

                        if (dtt.Rows.Count > 0)
                        {
                            preQty = Convert.ToInt32(dtt.Rows[0][0]);
                        }

                        if ((Convert.ToInt32(dt.Rows[0][0]) + preQty) < Convert.ToInt32(this.dgvItems["qty", i].Value))
                        {
                            this.dgvItems.ClearSelection();
                            this.dgvItems.Rows[i].Selected = true;
                            MessageBox.Show("The selected row item has not enough qty", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            StockVerify = false;
                            break;
                        }
                        else
                        {
                            StockVerify = true;
                        }
                    }
                }

                if (StockVerify)
                {
                    this.SaveUpdate();
                }
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
                    com.CommandText = "spCreateFinishGood";

                    com.Parameters.AddWithValue("@Date", this.dtp.Value);
                    com.Parameters.AddWithValue("@Detail", this.txtDescription.Text.Trim());
                    com.Parameters.AddWithValue("@Qty", this.txtQty.Value.ToString());
                    com.Parameters.AddWithValue("@Price", this.txtPrice.Value.ToString());
                    com.Parameters.AddWithValue("@Branch_Id", this.cmbBranch.SelectedValue.ToString());
                    com.Parameters.AddWithValue("@ModelNo", this.txtModelNo.Text.Trim());
                    com.Parameters.AddWithValue("@Server_Id", this.cmbItems.SelectedValue.ToString());

                    DataTable dt = new DataTable("Detail");
                    dt.Columns.Add(new DataColumn("ItemId", Type.GetType("System.Decimal")));
                    dt.Columns.Add(new DataColumn("Qty", Type.GetType("System.Decimal")));
                    dt.Columns.Add(new DataColumn("Price", Type.GetType("System.Decimal")));
                    dt.Columns.Add(new DataColumn("Total", Type.GetType("System.Decimal")));
                    dt.Columns.Add(new DataColumn("ModelNo", Type.GetType("System.String")));
                    for (int i = 0; i < this.dgvItems.Rows.Count - 1; i++)
                    {
                        DataRow newRow = dt.NewRow();
                        newRow["ItemId"] = this.dgvItems["itemId", i].Value;
                        newRow["ModelNo"] = this.dgvItems["ModelNo", i].Value;
                        newRow["Qty"] = this.dgvItems["qty", i].Value;
                        newRow["Price"] = this.dgvItems["price", i].Value;
                        newRow["Total"] = this.dgvItems["Total", i].Value;
                        dt.Rows.InsertAt(newRow, dt.Rows.Count);
                    }

                    System.IO.StringWriter sw = new System.IO.StringWriter();
                    dt.WriteXml(sw);
                    string xmlData = sw.ToString();

                    com.Parameters.AddWithValue("@Details", xmlData);

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
                    com.CommandText = "spUpdateFinishGood";

                    com.Parameters.AddWithValue("@Id", this.Id);
                    com.Parameters.AddWithValue("@Date", this.dtp.Value);
                    com.Parameters.AddWithValue("@Detail", this.txtDescription.Text.Trim());
                    com.Parameters.AddWithValue("@Qty", this.txtQty.Value.ToString());
                    com.Parameters.AddWithValue("@Price", this.txtPrice.Value.ToString());
                    com.Parameters.AddWithValue("@Branch_Id", this.cmbBranch.SelectedValue.ToString());
                    com.Parameters.AddWithValue("@ModelNo", this.txtModelNo.Text.Trim());
                    com.Parameters.AddWithValue("@Server_Id", this.cmbItems.SelectedValue.ToString());

                    DataTable dt = new DataTable("Detail");
                    dt.Columns.Add(new DataColumn("ItemId", Type.GetType("System.Decimal")));
                    dt.Columns.Add(new DataColumn("Qty", Type.GetType("System.Decimal")));
                    dt.Columns.Add(new DataColumn("Price", Type.GetType("System.Decimal")));
                    dt.Columns.Add(new DataColumn("Total", Type.GetType("System.Decimal")));
                    dt.Columns.Add(new DataColumn("ModelNo", Type.GetType("System.String")));
                    for (int i = 0; i < this.dgvItems.Rows.Count - 1; i++)
                    {
                        DataRow newRow = dt.NewRow();
                        newRow["ItemId"] = this.dgvItems["itemId", i].Value;
                        newRow["ModelNo"] = this.dgvItems["ModelNo", i].Value;
                        newRow["Qty"] = this.dgvItems["qty", i].Value;
                        newRow["Price"] = this.dgvItems["price", i].Value;
                        newRow["Total"] = this.dgvItems["Total", i].Value;
                        dt.Rows.InsertAt(newRow, dt.Rows.Count);
                    }

                    System.IO.StringWriter sw = new System.IO.StringWriter();
                    dt.WriteXml(sw);
                    string xmlData = sw.ToString();

                    com.Parameters.AddWithValue("@Details", xmlData);

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

                    DataTable dt = this.ObjCore.getDataSet("Select * from MFinishGoods where Id = " + this.Id.ToString()).Tables[0];

                    this.dtp.Value = Convert.ToDateTime(dt.Rows[0]["Date"]);
                    this.txtQty.Value = 1;
                    this.txtPrice.Value = Convert.ToDecimal(dt.Rows[0]["Price"]);
                    this.txtModelNo.Text = dt.Rows[0]["ModelNo"].ToString();

                    //if (dt.Rows[0]["Branch_Id"].ToString() != string.Empty)
                    this.cmbBranch.SelectedValue = dt.Rows[0]["Branch_Id"].ToString();
                    this.cmbItems.SelectedValue = dt.Rows[0]["Server_Id"].ToString();

                    //this.dtp.Value = Convert.ToDateTime(this.dgvShow["date", e.RowIndex].Value);
                    //this.txtDescription.Text = this.dgvShow["detail", e.RowIndex].Value.ToString();
                    //this.txtQty.Value = Convert.ToInt32(this.dgvShow["showQty", e.RowIndex].Value);
                    //this.txtPrice.Value = Convert.ToInt32(this.dgvShow["showPrice", e.RowIndex].Value);
                    //this.txtModelNo.Text = this.dgvShow["showModelNo", e.RowIndex].Value.ToString();

                    this.dsFinishGoodsItems1.Clear();
                    this.daFinishGoodsItems.SelectCommand.Connection.ConnectionString = this.ObjCore.getConnectionString();
                    this.daFinishGoodsItems.SelectCommand.Parameters["@Id"].Value = this.Id;
                    this.daFinishGoodsItems.Fill(this.dsFinishGoodsItems1);

                    this.btnSave.Text = "Update";
                    this.tabControl1.SelectedTab = this.tabPage1;
                }

                if (e.ColumnIndex == this.dgvShow.Columns["DeleteShow"].Index)
                {
                    if (!this.ObjCore.CheckRightServer(28, this.Id, true))
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
                        com.CommandText = "spDeleteFinishGood";

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
                this.dsMFinishGoodsShow.Clear();
                this.daMFinishGoodsSHow.SelectCommand.Connection.ConnectionString = this.ObjCore.getConnectionString();
                this.daMFinishGoodsSHow.Fill(this.dsMFinishGoodsShow);
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
            this.txtQty.Value = 0;
            this.txtPrice.Value = 0;
            this.txtDescription.Text = "";
            this.txtModelNo.Text = "";

            this.btnSave.Text = "Save";
            this.Id = -1;
            this.dsFinishGoodsItems1.Clear();
        }

        private void cmbBranch_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = this.ObjCore.getDataSet("Select * from Branches where Id = " + this.cmbBranch.SelectedValue.ToString(), this.ObjCore.getHBCConnectionString()).Tables[0];

                //string conString = dt.Rows[0]["LocalConnectionString"].ToString();
                string conString = dt.Rows[0]["ConnectionString"].ToString();

                this.ObjCore.fillComboBoxOptioni(this.cmbItems, "Select ItemId, Code + ' ' + Title + ' (' + Convert(nvarchar(50), ItemId) + ')' from Items where ItemId > 10000 and Hide = 0", conString);
            }
            catch (Exception ex)
            {
                
            }
        }

        private void cmbBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = this.ObjCore.getDataSet("Select * from Branches where Id = " + this.cmbBranch.SelectedValue.ToString(), this.ObjCore.getHBCConnectionString()).Tables[0];

                //string conString = dt.Rows[0]["LocalConnectionString"].ToString();
                string conString = dt.Rows[0]["ConnectionString"].ToString();

                this.ObjCore.fillComboBoxOptioni(this.cmbItems, "Select ItemId, Code + ' ' + Title + ' (' + Convert(nvarchar(50), ItemId) + ')' from Items where ItemId > 10000 and Hide = 0", conString);
            }
            catch (Exception ex)
            {

            }
        }
    }
}
