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
    public partial class frmSale : Form
    {
        InventoryEntities DB;
        Sale model;
        ItemStock stock;
        CoreClass objCore;
        bool ValidStock = false;
        int editMode = -1;

        public frmSale()
        {
            InitializeComponent();
            this.model = new Sale();
            this.stock = new ItemStock();
            this.objCore = new CoreClass();
        }

        private void frmOrder_Load(object sender, EventArgs e)
        {
            this.model.Id = -1;

            this.objCore.fillComboBoxWithAddNewOptioni(this.cmbClient, "Select Id, Name from VendorG", this.objCore.getHBCConnectionString());
            this.objCore.fillGridComboBoxWithAddNewOption((DataGridViewComboBoxColumn)this.dgDetail.Columns["itemId"], "Select Id, Code + ' ' + Name + ' (' + Convert(Nvarchar(50), Id) + ')' from ItemList", this.objCore.getHBCConnectionString());

            this.LoadOrder();
        }

        private void LoadOrder()
        {
            this.dsSaleSearch1.Clear();
            this.daSearch.SelectCommand.Connection.ConnectionString = this.objCore.getHBCConnectionString();
            this.daSearch.Fill(this.dsSaleSearch1);
            this.dgDetail.Columns[0].Visible = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //this.PreCheck();

            //if (this.ValidStock)
            //{
                this.SaveUpdate();
            //}
        }

        private void PreCheck()
        {
            using (this.DB = new InventoryEntities(this.objCore.getClientConnectionStringName()))
            {
                this.dgDetail.ClearSelection();
                if (this.model.Id == -1)
                {
                    int id = 0;
                    for (int i = 0; i < this.dgDetail.Rows.Count - 1; i++)
                    {
                        id = Convert.ToInt32(this.dgDetail["itemId", i].Value);
                        var item = this.DB.vItems.Where(x => x.ItemId == id).FirstOrDefault();
                        if (item.Stock < Convert.ToInt32(this.dgDetail["qty", i].Value))
                        {
                            this.dgDetail.Rows[i].Selected = true;
                            MessageBox.Show("This item available stock is (" + item.Stock + ")!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.ValidStock = false;
                            return;
                        }
                        else
                        {
                            this.ValidStock = true;
                        }
                    }
                }
                else
                {
                    int id = 0;
                    for (int i = 0; i < this.dgDetail.Rows.Count - 1; i++)
                    {
                        id = Convert.ToInt32(this.dgDetail["itemId", i].Value);
                        var item = this.DB.vItems.Where(x => x.ItemId == id).FirstOrDefault();
                        var itemBeforeQty = this.DB.SaleDetails.Where(x => x.ItemId == id).Where(x => x.Sale_Id == this.model.Id).FirstOrDefault();
                        if ((item.Stock + itemBeforeQty.Qty) < Convert.ToInt32(this.dgDetail["qty", i].Value))
                        {
                            this.dgDetail.Rows[i].Selected = true;
                            MessageBox.Show("You have enter extra (" + (Convert.ToInt32(this.dgDetail["qty", i].Value) - itemBeforeQty.Qty) + "), and stock avilable is (" + item.Stock + ")!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.ValidStock = false;
                            return;
                        }
                        else
                        {
                            this.ValidStock = true;
                        }
                    }
                }
            }
        }

        private void SaveUpdate()
        {

            //if (this.cmbClient.SelectedValue.ToString() == "-1" || this.cmbClient.SelectedValue == null)
            //{
            //    MessageBox.Show("Please select vendor!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    this.cmbClient.Focus();
            //    return;
            //}

            if (!CommonTask.Question(this.model.Id)) return;

            SqlConnection con = new SqlConnection();
            con.ConnectionString = this.objCore.getHBCConnectionString();
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
                    com.CommandText = "spCreateSale";

                    com.Parameters.AddWithValue("@SaleDate", this.dtpDate.Value);
                    com.Parameters.AddWithValue("@Description", this.txtDescription.Text.Trim());
                    com.Parameters.AddWithValue("@ClientId", this.cmbClient.SelectedValue);
                    com.Parameters.AddWithValue("@ExtraDetail", this.txtExtraDetail.Text.Trim());
                    com.Parameters.AddWithValue("@ExtraAmount", this.txtDiscount.Value);
                    com.Parameters.AddWithValue("@Discount", this.txtDiscount.Value);
                    com.Parameters.AddWithValue("@FinalTotal", this.txtFinalTotal.Text);
                    com.Parameters.AddWithValue("@Branch_Id", this.cmbBranch.SelectedIndex.ToString());

                    DataTable dt = new DataTable("Detail");
                    dt.Columns.Add(new DataColumn("ItemId", Type.GetType("System.Decimal")));
                    dt.Columns.Add(new DataColumn("Description", Type.GetType("System.String")));
                    dt.Columns.Add(new DataColumn("Qty", Type.GetType("System.Decimal")));
                    dt.Columns.Add(new DataColumn("UnitPrice", Type.GetType("System.Decimal")));
                    dt.Columns.Add(new DataColumn("TotalPrice", Type.GetType("System.Decimal")));
                    dt.Columns.Add(new DataColumn("Cost", Type.GetType("System.Decimal")));
                    for (int i = 0; i < this.dgDetail.Rows.Count - 1; i++)
                    {
                        DataRow newRow = dt.NewRow();
                        newRow["ItemId"] = this.dgDetail["itemId", i].Value;
                        newRow["Description"] = this.dgDetail["description", i].Value;
                        newRow["Qty"] = this.dgDetail["qty", i].Value;
                        newRow["UnitPrice"] = this.dgDetail["price", i].Value;
                        newRow["TotalPrice"] = this.dgDetail["TotalPrice", i].Value;
                        newRow["Cost"] = this.dgDetail["Cost", i].Value;
                        dt.Rows.InsertAt(newRow, dt.Rows.Count);
                    }

                    System.IO.StringWriter sw = new System.IO.StringWriter();
                    dt.WriteXml(sw);
                    string xmlData = sw.ToString();

                    com.Parameters.AddWithValue("@Detail", xmlData);

                    com.Parameters.Add(new SqlParameter("@SaleNo", SqlDbType.Decimal, 18, ParameterDirection.Output, false, 18, 0, "ItemIdStock", DataRowVersion.Default, null));
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
                        this.txtSaleNo.Text = com.Parameters["@SaleNo"].Value.ToString();
                        this.btnSave.Text = "Update";
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
                    com.CommandText = "spUpdateSale";

                    com.Parameters.AddWithValue("@Id", this.model.Id);
                    com.Parameters.AddWithValue("@SaleDate", this.dtpDate.Value);
                    com.Parameters.AddWithValue("@Description", this.txtDescription.Text.Trim());
                    com.Parameters.AddWithValue("@ClientId", this.cmbClient.SelectedValue);
                    com.Parameters.AddWithValue("@ExtraDetail", this.txtExtraDetail.Text.Trim());
                    com.Parameters.AddWithValue("@ExtraAmount", this.txtDiscount.Value);
                    com.Parameters.AddWithValue("@Discount", this.txtDiscount.Value);
                    com.Parameters.AddWithValue("@SaleNo", this.txtSaleNo.Text);
                    com.Parameters.AddWithValue("@FinalTotal", this.txtFinalTotal.Text);
                    com.Parameters.AddWithValue("@Branch_Id", this.cmbBranch.SelectedIndex.ToString());

                    DataTable dt = new DataTable("Detail");
                    dt.Columns.Add(new DataColumn("ItemId", Type.GetType("System.Decimal")));
                    dt.Columns.Add(new DataColumn("Description", Type.GetType("System.String")));
                    dt.Columns.Add(new DataColumn("Qty", Type.GetType("System.Decimal")));
                    dt.Columns.Add(new DataColumn("UnitPrice", Type.GetType("System.Decimal")));
                    dt.Columns.Add(new DataColumn("TotalPrice", Type.GetType("System.Decimal")));
                    dt.Columns.Add(new DataColumn("Cost", Type.GetType("System.Decimal")));
                    for (int i = 0; i < this.dgDetail.Rows.Count - 1; i++)
                    {
                        DataRow newRow = dt.NewRow();
                        newRow["ItemId"] = this.dgDetail["itemId", i].Value;
                        newRow["Description"] = this.dgDetail["description", i].Value;
                        newRow["Qty"] = this.dgDetail["qty", i].Value;
                        newRow["UnitPrice"] = this.dgDetail["price", i].Value;
                        newRow["TotalPrice"] = this.dgDetail["TotalPrice", i].Value;
                        newRow["Cost"] = this.dgDetail["Cost", i].Value;
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
            this.txtSaleNo.Text = this.txtDescription.Text = "";            
            this.txtDiscount.Value = 0;
            this.cmbClient.SelectedValue = -2;
            this.dtpDate.Value = DateTime.Now;
            this.dsSale1.Clear();
            this.txtTotal.Text = this.txtFinalTotal.Text = "0";
            this.editMode = -1;
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
                if (this.dgDetail.CurrentRow.Index != -1)
                {
                    if (e.ColumnIndex == this.dgDetail.Columns["itemId"].Index)
                    {
                        int id = Convert.ToInt32(this.dgDetail["itemId", e.RowIndex].Value);

                        //using (this.DB = new InventoryEntities(this.objCore.getClientConnectionStringName()))
                        //{
                        //    var item = this.DB.Items.Where(x => x.ItemId == id).FirstOrDefault();
                        //    //this.dgDetail["unitPrice", e.RowIndex].Value = item.SalePrice.ToString();
                        //    this.dgDetail["unitPrice", e.RowIndex].Value = 0;
                        //    this.dgDetail["Cost", e.RowIndex].Value = item.PurchasePrice.ToString();
                        //}
                    }

                    if (e.ColumnIndex == this.dgDetail.Columns["qty"].Index || e.ColumnIndex == this.dgDetail.Columns["price"].Index)
                    {
                        int qty = Convert.ToInt32(this.dgDetail["qty", e.RowIndex].Value);
                        this.dgDetail["TotalPrice", e.RowIndex].Value = Convert.ToDecimal(this.dgDetail["price", e.RowIndex].Value) * qty;
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

        private void dgDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dgDetail.CurrentRow.Index != -1)
            {
                if (e.ColumnIndex == this.dgDetail.Columns["Delete"].Index)
                {
                    if (!CommonTask.Question(this.model.Id, true)) return;

                    this.dgDetail.Rows.RemoveAt(e.RowIndex);
                    this.Calculate();
                }
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
                    GridTotal += Convert.ToDecimal(this.dgDetail["TotalPrice", i].Value);
                }
                this.txtTotal.Text = GridTotal.ToString();
                ExtraAmount = this.txtDiscount.Value;
                FinalTotal = GridTotal - ExtraAmount;
                this.txtFinalTotal.Text = FinalTotal.ToString();
            }
            catch (Exception ex)
            {

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
                    int deleteid = Convert.ToInt32(this.dgSearch["saleid", e.RowIndex].Value);

                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = this.objCore.getHBCConnectionString();
                    con.Open();
                    SqlTransaction tran = con.BeginTransaction();
                    SqlCommand com = new SqlCommand("", con, tran);
                    string command = string.Empty;
                    string vendorAccountId = string.Empty;
                    bool success = false;
                    try
                    {
                        com.CommandType = CommandType.StoredProcedure;
                        com.CommandText = "spDeleteSale";

                        com.Parameters.AddWithValue("@Id", deleteid);

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
                    
                    this.FromClear();
                }

                if (e.ColumnIndex == this.dgSearch.Columns["Edit"].Index)
                {
                    this.Cursor = Cursors.WaitCursor;
                    int editId = Convert.ToInt32(this.dgSearch["saleid", e.RowIndex].Value);
                    
                    this.FromClear();
                    this.model.Id = editId;
                    DataTable dt = this.objCore.getDataSet("Select * from Sale where Id = " + editId, this.objCore.getHBCConnectionString()).Tables[0];

                    var dtrow = dt.Rows[0];

                    this.txtSaleNo.Text = dtrow["SaleNo"].ToString();
                    this.dtpDate.Value = Convert.ToDateTime(dtrow["SaleDate"]);
                    this.cmbClient.SelectedValue = dtrow["ClientId"].ToString();
                    this.txtDescription.Text = dtrow["Description"].ToString();
                    this.cmbBranch.SelectedIndex = Convert.ToInt32(dtrow["Branch_Id"]);
                    this.txtExtraDetail.Text = "0";
                    this.txtDiscount.Value = 0;

                    this.dsSale1.Clear();
                    this.ADEdit.SelectCommand.Connection.ConnectionString = this.objCore.getHBCConnectionString();
                    this.ADEdit.SelectCommand.Parameters["@id"].Value = editId;
                    this.ADEdit.Fill(this.dsSale1);

                    this.Calculate();
                    this.txtDiscount.Value = Convert.ToDecimal(dtrow["Discount"]);

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

        private void btnReceive_Click(object sender, EventArgs e)
        {
            //if (this.model.Id != -1)
            //{
            //    frmSaleReceive obj = new frmSaleReceive();
            //    obj.Sale_id = this.model.Id;
            //    obj.WindowState = FormWindowState.Normal;
            //    obj.StartPosition = FormStartPosition.CenterParent;
            //    obj.ShowDialog();
            //}
        }

        private void cmbClient_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //if (this.cmbClient.SelectedValue.ToString() == "-1")
            //{
            //    frmclient obj = new frmclient();
            //    obj.quickCall = true;
            //    obj.StartPosition = FormStartPosition.CenterParent;
            //    obj.ShowDialog();
            //    this.objCore.fillComboBoxWithAddNewOptioni(this.cmbClient, "Select ClientId, Name from Clients");
            //    using (this.DB = new InventoryEntities(this.objCore.getClientConnectionStringName()))
            //    {
            //        var id = this.DB.Clients.Max(x => x.ClientId);
            //        this.cmbClient.SelectedValue = id;
            //    }
            //}
        }

        private void dgDetail_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control is DataGridViewComboBoxEditingControl)
            {
                ((ComboBox)e.Control).DropDownStyle = ComboBoxStyle.DropDown;
                ((ComboBox)e.Control).AutoCompleteMode = AutoCompleteMode.Suggest;
            }
        }

        private void dgDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                if (e.ColumnIndex == this.dgDetail.Columns["ItemId"].Index)
                {
                    Stock.frmSearchControl obj = new Stock.frmSearchControl();
                    obj.StartPosition = FormStartPosition.CenterScreen;
                    obj.ShowDialog();

                    //this.objCore.fillGridComboBoxWithAddNewOption((DataGridViewComboBoxColumn)this.dgDetail.Columns["ItemId"], "Select Id, Name from ItemList");
                    this.objCore.fillGridComboBoxWithAddNewOption((DataGridViewComboBoxColumn)this.dgDetail.Columns["itemId"], "Select Id, Code + ' ' + Name + ' (' + Convert(Nvarchar(50), Id) + ')' from ItemList", this.objCore.getHBCConnectionString());


                    if (obj.Selected)
                    {
                        this.dgDetail["ItemId", e.RowIndex].Value = obj.Itemid;
                        this.dgDetail.ClearSelection();
                        this.dgDetail.CurrentCell = this.dgDetail.Rows[e.RowIndex].Cells["qty"];
                        this.dgDetail.Rows[e.RowIndex].Cells["qty"].Value = 1;
                        //this.dgDetail.Rows[e.RowIndex].Cells["ModelNo"].Value = obj.modelNo;
                        this.dgDetail.Rows[e.RowIndex].Cells["price"].Value = obj.pprice;
                        this.dgDetail.Rows[e.RowIndex].Cells["TotalPrice"].Value = obj.pprice;
                        this.dgDetail.BeginEdit(true);
                        this.dgDetail.NotifyCurrentCellDirty(true);
                        this.dgDetail.NotifyCurrentCellDirty(false);

                        this.Calculate();
                    }
                }
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (this.model.Id == -1)
                return;


        }
    }
}
