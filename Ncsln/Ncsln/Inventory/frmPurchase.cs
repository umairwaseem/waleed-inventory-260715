using Ncsln.Classes;
using Ncsln.DBModel;
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
    public partial class frmPurchase : Form
    {
        InventoryEntities DB;
        Purchase model;
        CoreClass objCore;

        public frmPurchase()
        {
            InitializeComponent();
            this.model = new Purchase();
            this.objCore = new CoreClass();
        }

        private void frmOrder_Load(object sender, EventArgs e)
        {
            this.model.Id = -1;

            this.objCore.fillComboBoxOptioni(this.cmbPurchase, "Select VendorId, Name from Vendors where VendorId not in (1)", this.objCore.getClientConnectionString());
            this.objCore.fillGridComboBoxWithAddNewOption((DataGridViewComboBoxColumn)this.dgDetail.Columns["itemId"], "Select ItemId, Title from Items", this.objCore.getClientConnectionString());
            this.btnPrint.Visible = this.objCore.getUserRight(5, "CanView");
            //this.LoadOrder();
        }

        private void LoadOrder()
        {
            this.dsPurchaseSearch1.Clear();
            this.dsPurchaseSearch1.EnforceConstraints = false;
            this.daSearch.SelectCommand.Connection.ConnectionString = this.objCore.getClientConnectionString();
            this.daSearch.SelectCommand.Parameters["@key"].Value = this.txtSearch.Text.Trim();
            this.daSearch.Fill(this.dsPurchaseSearch1);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.objCore.TimeEntryLock(this.dtpDate.Value)) return;

            if (!this.objCore.CheckRight(4, this.model.Id, this.dtpDate.Value))
            {
                return;
            }

            if (this.cmbPurchase.SelectedValue == null || this.cmbPurchase.SelectedValue.ToString() == "-1")
            {
                MessageBox.Show("Please select a vendor for this purchase", "Alret", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.SaveUpdate();
        }

        private void SaveUpdate()
        {
            if (!CommonTask.Question(this.model.Id)) return;

            SqlConnection con = new SqlConnection();
            con.ConnectionString = this.objCore.getClientConnectionString();
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
                    com.CommandText = "spCreatePurchase";

                    com.Parameters.AddWithValue("@PurchaseDate", this.dtpDate.Value);
                    com.Parameters.AddWithValue("@Description", this.txtDescription.Text.Trim());
                    com.Parameters.AddWithValue("@VendorId", this.cmbPurchase.SelectedValue);
                    com.Parameters.AddWithValue("@ExtraDetail", this.txtExtraDetail.Text.Trim());
                    com.Parameters.AddWithValue("@ExtraAmount", this.txtExtra.Value);
                    com.Parameters.AddWithValue("@FinalTotal", this.txtFinalTotal.Text);
                    com.Parameters.AddWithValue("@ChallanNo", this.txtChallanNo.Text);

                    DataTable dt = new DataTable("Detail");
                    dt.Columns.Add(new DataColumn("ItemId", Type.GetType("System.Decimal")));
                    dt.Columns.Add(new DataColumn("Description", Type.GetType("System.String")));
                    dt.Columns.Add(new DataColumn("Qty", Type.GetType("System.Decimal")));
                    dt.Columns.Add(new DataColumn("UnitPrice", Type.GetType("System.Decimal")));
                    dt.Columns.Add(new DataColumn("TotalPrice", Type.GetType("System.Decimal")));
                    dt.Columns.Add(new DataColumn("ItemReturn", Type.GetType("System.Boolean")));
                    dt.Columns.Add(new DataColumn("ItemCode", Type.GetType("System.String")));
                    for (int i = 0; i < this.dgDetail.Rows.Count - 1; i++)
                    {
                        DataRow newRow = dt.NewRow();
                        newRow["ItemId"] = this.dgDetail["itemId", i].Value;
                        newRow["Description"] = this.dgDetail["description", i].Value;
                        newRow["Qty"] = this.dgDetail["qty", i].Value;
                        newRow["UnitPrice"] = this.dgDetail["unitPrice", i].Value;
                        newRow["TotalPrice"] = this.dgDetail["totalPrice", i].Value;
                        newRow["ItemReturn"] = this.dgDetail["ItemReturn", i].Value;
                        newRow["ItemCode"] = this.dgDetail["ItemCode", i].Value;
                        dt.Rows.InsertAt(newRow, dt.Rows.Count);
                    }

                    System.IO.StringWriter sw = new System.IO.StringWriter();
                    dt.WriteXml(sw);
                    string xmlData = sw.ToString();

                    com.Parameters.AddWithValue("@Detail", xmlData);

                    com.Parameters.Add(new SqlParameter("@PurchaseNo", SqlDbType.Decimal, 18, ParameterDirection.Output, false, 18, 0, "ItemIdStock", DataRowVersion.Default, null));
                    com.Parameters.Add(new SqlParameter("@Id", SqlDbType.Decimal, 18, ParameterDirection.Output, false, 18, 0, "SaleId", DataRowVersion.Default, null));
                    com.Parameters.Add(new SqlParameter("@Success", SqlDbType.Bit, 1, ParameterDirection.Output, false, 1, 0, "Success", DataRowVersion.Default, null));
                    com.Parameters.Add(new SqlParameter("@Message", SqlDbType.NVarChar, 200, ParameterDirection.Output, false, 200, 0, "Message", DataRowVersion.Default, null));
                    com.UpdatedRowSource = UpdateRowSource.OutputParameters;
                    com.ExecuteNonQuery();
                    success = Convert.ToBoolean(com.Parameters["@Success"].Value);
                    string message = com.Parameters["@Message"].Value.ToString();
                    string itemIdStock = string.Empty;
                    if (success)
                        this.model.Id = Convert.ToInt32(com.Parameters["@Id"].Value);
                    else
                        itemIdStock = com.Parameters["@ItemIdStock"].Value.ToString();
                    tran.Commit();
                    if (success)
                    {
                        this.txtPurchaseNo.Text = com.Parameters["@PurchaseNo"].Value.ToString();
                        this.btnSave.Text = "Update";

                        objCore.RecoardLogs("Purchase Added purchase # : " + this.model.Id.ToString(), "Purchase Order");
                    }
                    else
                    {
                        this.dgDetail.ClearSelection();
                        MessageBox.Show(message, "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
                else
                {
                    com.CommandType = CommandType.StoredProcedure;
                    com.CommandText = "spUpdatePurchase";

                    com.Parameters.AddWithValue("@Id", this.model.Id);
                    com.Parameters.AddWithValue("@PurchaseDate", this.dtpDate.Value);
                    com.Parameters.AddWithValue("@Description", this.txtDescription.Text.Trim());
                    com.Parameters.AddWithValue("@VendorId", this.cmbPurchase.SelectedValue);
                    com.Parameters.AddWithValue("@ExtraDetail", this.txtExtraDetail.Text.Trim());
                    com.Parameters.AddWithValue("@ExtraAmount", this.txtExtra.Value);
                    com.Parameters.AddWithValue("@PurchaseNo", this.txtPurchaseNo.Text);
                    com.Parameters.AddWithValue("@FinalTotal", this.txtFinalTotal.Text);
                    com.Parameters.AddWithValue("@ChallanNo", this.txtChallanNo.Text);

                    DataTable dt = new DataTable("Detail");
                    dt.Columns.Add(new DataColumn("ItemId", Type.GetType("System.Decimal")));
                    dt.Columns.Add(new DataColumn("Description", Type.GetType("System.String")));
                    dt.Columns.Add(new DataColumn("Qty", Type.GetType("System.Decimal")));
                    dt.Columns.Add(new DataColumn("UnitPrice", Type.GetType("System.Decimal")));
                    dt.Columns.Add(new DataColumn("TotalPrice", Type.GetType("System.Decimal")));
                    dt.Columns.Add(new DataColumn("ItemReturn", Type.GetType("System.Boolean")));
                    dt.Columns.Add(new DataColumn("ItemCode", Type.GetType("System.String")));
                    for (int i = 0; i < this.dgDetail.Rows.Count - 1; i++)
                    {
                        DataRow newRow = dt.NewRow();
                        newRow["ItemId"] = this.dgDetail["itemId", i].Value;
                        newRow["Description"] = this.dgDetail["description", i].Value;
                        newRow["Qty"] = this.dgDetail["qty", i].Value;
                        newRow["UnitPrice"] = this.dgDetail["unitPrice", i].Value;
                        newRow["TotalPrice"] = this.dgDetail["totalPrice", i].Value;
                        newRow["ItemReturn"] = this.dgDetail["ItemReturn", i].Value;
                        newRow["ItemCode"] = this.dgDetail["ItemCode", i].Value;
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

                    tran.Commit();
                    if (!success)
                    {
                        this.dgDetail.ClearSelection();
                        MessageBox.Show(message, "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    else
                    {
                        objCore.RecoardLogs("Purchase updated purchase # : " + this.model.Id.ToString(), "Purchase Order");
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
                this.LoadOrder();
            }

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.FromClear();
            this.LoadOrder();
        }

        private void FromClear()
        {
            this.model.Id = -1;
            this.txtPurchaseNo.Text = this.txtDescription.Text = "";
            this.txtExtra.Value = this.txtChallanNo.Value = 0;
            this.cmbPurchase.SelectedValue = -2;
            this.dtpDate.Value = DateTime.Now;
            this.dsPurchase1.Clear();
            this.txtTotal.Text = this.txtFinalTotal.Text = "0";
            this.btnSave.Text = "Save";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgDetail_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (this.dgDetail.CurrentRow != null && this.dgDetail.CurrentRow.Index != -1 )
                {
                    if (e.ColumnIndex == this.dgDetail.Columns["itemId"].Index)
                    {
                        int id = Convert.ToInt32(this.dgDetail["itemId", e.RowIndex].Value);

                        using (this.DB = new InventoryEntities(this.objCore.getClientConnectionStringName()))
                        {
                            var item = this.DB.Items.Where(x => x.ItemId == id).FirstOrDefault();
                            this.dgDetail["unitPrice", e.RowIndex].Value = item.PurchasePrice.ToString();
                            this.dgDetail["ItemCode", e.RowIndex].Value = item.Code;
                        }
                    }

                    if (e.ColumnIndex == this.dgDetail.Columns["qty"].Index || e.ColumnIndex == this.dgDetail.Columns["unitPrice"].Index)
                    {
                        int qty = Convert.ToInt32(this.dgDetail["qty", e.RowIndex].Value);
                        this.dgDetail["totalPrice", e.RowIndex].Value = Convert.ToDecimal(this.dgDetail["unitPrice", e.RowIndex].Value) * qty;
                    }
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
            finally
            {
                this.Calculate();
            }
        }

        private void dgDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (this.dgDetail.CurrentRow.Index != -1)
                {
                    if (e.ColumnIndex == this.dgDetail.Columns["Delete"].Index)
                    {
                        if (!this.objCore.CheckRight(4, this.model.Id, true))
                        {
                            return;
                        }

                        if (!CommonTask.Question(this.model.Id, true)) return;

                        this.dgDetail.Rows.RemoveAt(e.RowIndex);
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

        private void Calculate()
        {
            try
            {
                //Grid Total
                decimal GridTotal = 0, ExtraAmount = 0, FinalTotal = 0;
                for (int i = 0; i < this.dgDetail.Rows.Count - 1; i++)
                {
                    if (Convert.ToBoolean(this.dgDetail["ItemReturn", i].Value))
                    {
                        GridTotal -= Convert.ToDecimal(this.dgDetail["totalPrice", i].Value);
                    }
                    else
                    {
                        GridTotal += Convert.ToDecimal(this.dgDetail["totalPrice", i].Value);
                    }
                }
                this.txtTotal.Text = GridTotal.ToString();
                ExtraAmount = this.txtExtra.Value;
                FinalTotal = GridTotal + ExtraAmount;
                this.txtFinalTotal.Text = FinalTotal.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtExtra_ValueChanged(object sender, EventArgs e)
        {
            this.Calculate();
        }

        private void dgSearch_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dgSearch.CurrentRow.Index != -1)
            {
                if (e.ColumnIndex == this.dgSearch.Columns["DeleteOrder"].Index)
                {
                    if (!CommonTask.Question(0, true)) return;
                    int deleteid = Convert.ToInt32(this.dgSearch["purchaseid", e.RowIndex].Value);

                    using (this.DB = new InventoryEntities(this.objCore.getClientConnectionStringName()))
                    {
                        objCore.RecoardLogs("Purchase deleted purchase # : " + deleteid.ToString(), "Purchase");

                        this.DB.spDeletePurchase(deleteid);
                        this.LoadOrder();
                    }
                    this.FromClear();
                }

                if (e.ColumnIndex == this.dgSearch.Columns["Edit"].Index)
                {
                    this.Cursor = Cursors.WaitCursor;
                    int editId = Convert.ToInt32(this.dgSearch["purchaseid", e.RowIndex].Value);

                    this.FromClear();

                    using (this.DB = new InventoryEntities(this.objCore.getClientConnectionStringName()))
                    {
                        this.model = this.DB.Purchases.Where(x => x.Id == editId).FirstOrDefault();
                        this.txtPurchaseNo.Text = this.model.PurchaseNo.ToString();
                        this.dtpDate.Value = Convert.ToDateTime(this.model.PurchaseDate);
                        this.cmbPurchase.SelectedValue = this.model.VendorId;
                        this.txtDescription.Text = this.model.Description;
                        this.txtExtraDetail.Text = this.model.ExtraDetail;
                        this.txtExtra.Value = Convert.ToDecimal(this.model.ExtraAmount);
                        this.txtChallanNo.Value = Convert.ToDecimal(this.model.ChallanNo);
                    }

                    this.dsPurchase1.Clear();
                    this.ADEdit.SelectCommand.Connection.ConnectionString = this.objCore.getClientConnectionString();
                    this.ADEdit.SelectCommand.Parameters["@id"].Value = this.model.Id;
                    this.ADEdit.Fill(this.dsPurchase1);

                    this.Calculate();

                    this.tab.SelectedTab = this.tabAddEdit;
                    this.btnSave.Text = "Update";
                    this.Cursor = Cursors.Default;
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.LoadOrder();
        }

        private void cmbPurchase_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (this.cmbPurchase.SelectedValue.ToString() == "-1")
            {
                frmVendor obj = new frmVendor();
                obj.quickCall = true;
                obj.StartPosition = FormStartPosition.CenterParent;
                obj.ShowDialog();
                this.objCore.fillComboBoxWithAddNewOptioni(this.cmbPurchase, "Select VendorId, Name from Vendors", this.objCore.getClientConnectionString());
                using (this.DB = new InventoryEntities(this.objCore.getClientConnectionStringName()))
                {
                    var id = this.DB.Vendors.Max(x => x.VendorId);
                    this.cmbPurchase.SelectedValue = id;
                }
            }
        }

        private void dgDetail_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control is DataGridViewComboBoxEditingControl)
            {
                ((ComboBox)e.Control).DropDownStyle = ComboBoxStyle.DropDown;
                ((ComboBox)e.Control).AutoCompleteMode = AutoCompleteMode.Suggest;
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (this.model.Id != -1)
            {
                Reports.frmInvoices obj = new Reports.frmInvoices();
                obj.id = this.model.Id;
                obj.type = 1;
                obj.MdiParent = this.MdiParent;
                obj.Show();
            }
        }

        private void dgDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                    if (e.ColumnIndex == this.dgDetail.Columns["itemId"].Index)
                    {
                        frmItemSearch obj = new frmItemSearch();
                        obj.StartPosition = FormStartPosition.CenterParent;
                        obj.OnlyVendor = false;
                        obj.VendorId = Convert.ToInt32(this.cmbPurchase.SelectedValue);
                        obj.ShowDialog();
                        this.objCore.fillGridComboBoxWithAddNewOption((DataGridViewComboBoxColumn)this.dgDetail.Columns["itemId"], "Select ItemId, Title from Items", this.objCore.getClientConnectionString());

                        if (obj.Selected)
                        {
                            this.dgDetail["itemId", e.RowIndex].Value = obj.ItemId;
                            this.dgDetail.ClearSelection();
                            this.dgDetail.CurrentCell = this.dgDetail.Rows[e.RowIndex].Cells["qty"];
                            this.dgDetail.Rows[e.RowIndex].Cells["qty"].Value = 1;
                            //this.dgDetail.Rows[e.RowIndex].Cells["unitPrice"].Value = "0";
                            this.dgDetail.Rows[e.RowIndex].Cells["unitPrice"].Value = obj.UnitPrice;
                            this.dgDetail.BeginEdit(true);
                            this.dgDetail.NotifyCurrentCellDirty(true);
                            this.dgDetail.NotifyCurrentCellDirty(false);
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
    }
}
