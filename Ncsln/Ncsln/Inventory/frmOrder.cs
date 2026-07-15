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
    public partial class frmOrder : Form
    {
        InventoryEntities DB;
        Order model;
        CoreClass objCore;
        bool ValidStock = true;

        public frmOrder()
        {
            InitializeComponent();
            this.model = new Order();
            this.objCore = new CoreClass();

            this.model.Id = -1;
        }

        private void frmOrder_Load(object sender, EventArgs e)
        {

            this.LoadClientList();
            this.objCore.fillGridComboBoxWithAddNewOption((DataGridViewComboBoxColumn)this.dgDetail.Columns["itemId"], "Select ItemId, Title from Items", this.objCore.getClientConnectionString());
            this.btnPrint.Visible = this.btnDeliveryChallan.Visible = this.objCore.getUserRight(7, "CanView");
            //this.LoadOrder();
        }

        private void LoadClientList()
        {
            this.objCore.fillComboBoxWithAddNewOptioni(this.cmbClient, "Select ClientId, Name +' '+PhoneNo from Clients", this.objCore.getClientConnectionString());
        }

        private void LoadOrder()
        {
            this.dsOrderSearch1.Clear();
            this.daSearch.SelectCommand.Connection.ConnectionString = this.objCore.getClientConnectionString();
            this.daSearch.Fill(this.dsOrderSearch1);
            this.dgDetail.Columns[0].Visible = false;
        }

        private void GetTotal()
        {
            try
            {
                decimal Total = 0, Receive = 0, Balance = 0;
                for (int i = 0; i < this.dgSearch.Rows.Count; i++)
                {
                    Total += Convert.ToDecimal(this.dgSearch["Total", i].Value);
                    Receive += Convert.ToDecimal(this.dgSearch["Receive", i].Value);
                    Balance += Convert.ToDecimal(this.dgSearch["Balance", i].Value);
                }

                this.lbTotal.Text = "Total : " + Total.ToString();
                this.lbReceive.Text = "Receive : " + Receive.ToString();
                this.lbBalance.Text = "Balance : " + Balance.ToString();
            }
            catch (Exception ex)
            {

            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.objCore.CheckRight(6, this.model.Id, this.dtpDate.Value))
            {
                return;
            }            

            if (this.chkDelivered.Checked)
            {
                this.PreCheck();
                if (this.model.Id == -1)
                {
                    if (!this.objCore.TimeEntryLock(this.dtpDelivered.Value)) return;
                }
            }
            
            if(this.ValidStock)
            {
                this.SaveUpdate();
            }
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
                        if (!Convert.ToBoolean(this.dgDetail["ItemReturn", i].Value))
                        {
                            id = Convert.ToInt32(this.dgDetail["itemId", i].Value);
                            var item = this.DB.vItems.Where(x => x.ItemId == id).FirstOrDefault();
                            var itemBeforeQty = this.DB.OrdersDetails.Where(x => x.ItemId == id).Where(x => x.Order_Id == this.model.Id).FirstOrDefault();
                            if (itemBeforeQty == null && item.Stock < Convert.ToInt32(this.dgDetail["qty", i].Value))
                            {
                                this.dgDetail.Rows[i].Selected = true;
                                MessageBox.Show("This item available stock is (" + item.Stock + ")!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                this.ValidStock = false;
                                return;
                            }
                            else if (itemBeforeQty != null && model.Sale_Id == null && item.Stock < Convert.ToInt32(this.dgDetail["qty", i].Value))
                            {
                                this.dgDetail.Rows[i].Selected = true;
                                MessageBox.Show("You have enter extra (" + (Convert.ToInt32(this.dgDetail["qty", i].Value) - itemBeforeQty.Qty) + "), and stock avilable is (" + item.Stock + ")!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                this.ValidStock = false;
                                return;
                            }
                            else if (itemBeforeQty != null && model.Sale_Id != null && (item.Stock + itemBeforeQty.Qty) < Convert.ToInt32(this.dgDetail["qty", i].Value))
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
            //if (this.model.Id != -1 && this.model.Delivered == true)
            //{
            //    MessageBox.Show("This order cannot be update!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    return;
            //}

            if ((this.model.Delivered == true || this.chkDelivered.Checked == true) && Convert.ToDecimal(this.txtBalance.Text) > 0)
            {
                MessageBox.Show("The order cannot delivered until balance is zero!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (this.cmbClient.SelectedValue == null || this.cmbClient.SelectedValue.ToString() == "-1")
            {
                MessageBox.Show("Please select a client!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

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
                    com.CommandText = "spCreateOrder";

                    com.Parameters.AddWithValue("@OrderDate", this.dtpDate.Value);
                    com.Parameters.AddWithValue("@Description", this.txtDescription.Text.Trim());
                    com.Parameters.AddWithValue("@Description2", this.txtDescription2.Text.Trim());
                    com.Parameters.AddWithValue("@ClientId", this.cmbClient.SelectedValue);
                    com.Parameters.AddWithValue("@ExtraDetail", this.txtExtraDetail.Text.Trim());
                    com.Parameters.AddWithValue("@ExtraAmount", this.txtExtra.Value);
                    com.Parameters.AddWithValue("@DiscountAmount", this.txtDiscount.Value);
                    com.Parameters.AddWithValue("@FinalTotal", this.txtFinalTotal.Text);
                    com.Parameters.AddWithValue("@SalePerson", this.txtSalePerson.Text.Trim());
                    com.Parameters.AddWithValue("@Delivered", this.chkDelivered.Checked);
                    if (this.chkDelivered.Checked)
                        com.Parameters.AddWithValue("@DeliveredDate", this.dtpDelivered.Value);
                    else
                        com.Parameters.AddWithValue("@DeliveredDate", DBNull.Value);

                    
                    DataTable dt = new DataTable("Detail");
                    dt.Columns.Add(new DataColumn("ItemId", Type.GetType("System.Decimal")));
                    dt.Columns.Add(new DataColumn("Description", Type.GetType("System.String")));
                    dt.Columns.Add(new DataColumn("Qty", Type.GetType("System.Decimal")));
                    dt.Columns.Add(new DataColumn("DQty", Type.GetType("System.Decimal")));
                    dt.Columns.Add(new DataColumn("UnitPrice", Type.GetType("System.Decimal")));
                    dt.Columns.Add(new DataColumn("TotalPrice", Type.GetType("System.Decimal")));
                    dt.Columns.Add(new DataColumn("Cost", Type.GetType("System.Decimal")));
                    dt.Columns.Add(new DataColumn("ItemReturn", Type.GetType("System.Boolean")));
                    dt.Columns.Add(new DataColumn("Delivered", Type.GetType("System.Boolean")));
                    dt.Columns.Add(new DataColumn("ItemCode", Type.GetType("System.String")));
                    for (int i = 0; i < this.dgDetail.Rows.Count - 1; i++)
                    {
                        DataRow newRow = dt.NewRow();
                        newRow["ItemId"] = this.dgDetail["itemId", i].Value;
                        newRow["Description"] = this.dgDetail["description", i].Value;
                        newRow["Qty"] = this.dgDetail["qty", i].Value;
                        newRow["DQty"] = this.dgDetail["qty", i].Value;
                        newRow["UnitPrice"] = this.dgDetail["unitPrice", i].Value;
                        newRow["TotalPrice"] = this.dgDetail["totalPrice", i].Value;
                        newRow["Cost"] = this.dgDetail["Cost", i].Value;
                        newRow["ItemReturn"] = this.dgDetail["ItemReturn", i].Value;
                        newRow["Delivered"] = this.dgDetail["Delivered", i].Value;
                        newRow["ItemCode"] = this.dgDetail["ItemCode", i].Value;
                        dt.Rows.InsertAt(newRow, dt.Rows.Count);
                    }

                    System.IO.StringWriter sw = new System.IO.StringWriter();
                    dt.WriteXml(sw);
                    string xmlData = sw.ToString();

                    com.Parameters.AddWithValue("@Detail", xmlData);

                    com.Parameters.Add(new SqlParameter("@OrderNo", SqlDbType.Decimal, 18, ParameterDirection.Output, false, 18, 0, "ItemIdStock", DataRowVersion.Default, null));
                    com.Parameters.Add(new SqlParameter("@Id", SqlDbType.Decimal, 18, ParameterDirection.Output, false, 18, 0, "SaleId", DataRowVersion.Default, null));
                    com.Parameters.Add(new SqlParameter("@Sale_Id", SqlDbType.Decimal, 18, ParameterDirection.Output, false, 18, 0, "SaleId", DataRowVersion.Default, null));
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
                        this.txtOrderNo.Text = com.Parameters["@OrderNo"].Value.ToString();
                        this.txtSalaNo.Text = com.Parameters["@Sale_Id"].Value.ToString();
                        this.model.Delivered = this.chkDelivered.Checked;
                        this.dtpDate.Enabled = false;
                        this.btnSave.Text = "Update";

                        objCore.RecoardLogs("Order Added order # : " + this.model.Id.ToString(), "Sale Order");
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
                    com.CommandText = "spUpdateOrder";

                    com.Parameters.AddWithValue("@Id", this.model.Id);
                    com.Parameters.AddWithValue("@OrderDate", this.dtpDate.Value);
                    com.Parameters.AddWithValue("@Description", this.txtDescription.Text.Trim());
                    com.Parameters.AddWithValue("@Description2", this.txtDescription2.Text.Trim());
                    com.Parameters.AddWithValue("@ClientId", this.cmbClient.SelectedValue);
                    com.Parameters.AddWithValue("@ExtraDetail", this.txtExtraDetail.Text.Trim());
                    com.Parameters.AddWithValue("@ExtraAmount", this.txtExtra.Value);
                    com.Parameters.AddWithValue("@DiscountAmount", this.txtDiscount.Value);
                    com.Parameters.AddWithValue("@OrderNo", this.txtOrderNo.Text);
                    com.Parameters.AddWithValue("@FinalTotal", this.txtFinalTotal.Text);
                    com.Parameters.AddWithValue("@Delivered", this.chkDelivered.Checked);
                    com.Parameters.AddWithValue("@SalePerson", this.txtSalePerson.Text.Trim());
                    if (this.chkDelivered.Checked)
                        com.Parameters.AddWithValue("@DeliveredDate", this.dtpDelivered.Value);
                    else
                        com.Parameters.AddWithValue("@DeliveredDate", DBNull.Value);

                    DataTable dt = new DataTable("Detail");
                    dt.Columns.Add(new DataColumn("ItemId", Type.GetType("System.Decimal")));
                    dt.Columns.Add(new DataColumn("Description", Type.GetType("System.String")));
                    dt.Columns.Add(new DataColumn("Qty", Type.GetType("System.Decimal")));
                    dt.Columns.Add(new DataColumn("DQty", Type.GetType("System.Decimal")));
                    dt.Columns.Add(new DataColumn("UnitPrice", Type.GetType("System.Decimal")));
                    dt.Columns.Add(new DataColumn("TotalPrice", Type.GetType("System.Decimal")));
                    dt.Columns.Add(new DataColumn("Cost", Type.GetType("System.Decimal")));
                    dt.Columns.Add(new DataColumn("ItemReturn", Type.GetType("System.Boolean")));
                    dt.Columns.Add(new DataColumn("Delivered", Type.GetType("System.Boolean")));
                    dt.Columns.Add(new DataColumn("ItemCode", Type.GetType("System.String")));
                    for (int i = 0; i < this.dgDetail.Rows.Count - 1; i++)
                    {
                        DataRow newRow = dt.NewRow();
                        newRow["ItemId"] = this.dgDetail["itemId", i].Value;
                        newRow["Description"] = this.dgDetail["description", i].Value;
                        newRow["Qty"] = this.dgDetail["qty", i].Value;
                        newRow["DQty"] = this.dgDetail["DQty", i].Value;
                        newRow["UnitPrice"] = this.dgDetail["unitPrice", i].Value;
                        newRow["TotalPrice"] = this.dgDetail["totalPrice", i].Value;
                        newRow["Cost"] = this.dgDetail["Cost", i].Value;
                        newRow["ItemReturn"] = this.dgDetail["ItemReturn", i].Value;
                        newRow["Delivered"] = this.dgDetail["Delivered", i].Value;
                        newRow["ItemCode"] = this.dgDetail["ItemCode", i].Value;
                        dt.Rows.InsertAt(newRow, dt.Rows.Count);
                    }

                    System.IO.StringWriter sw = new System.IO.StringWriter();
                    dt.WriteXml(sw);
                    string xmlData = sw.ToString();

                    com.Parameters.AddWithValue("@Detail", xmlData);

                    com.Parameters.Add(new SqlParameter("@Sale_Id", SqlDbType.Decimal, 18, ParameterDirection.Output, false, 18, 0, "SaleId", DataRowVersion.Default, null));
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
                        this.model.Delivered = this.chkDelivered.Checked;
                        this.txtSalaNo.Text = (com.Parameters["@Sale_Id"].Value.ToString() == "0") ? "" : com.Parameters["@Sale_Id"].Value.ToString();
                        this.GetBalance();
                        objCore.RecoardLogs("Order updated order # : " + this.model.Id.ToString(), "Sale Order");
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
                this.Calculate();
            }

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.FromClear();
            this.LoadOrder();
        }

        private void FromClear()
        {
            this.model.Delivered = false;
            this.model.Id = -1;
            this.txtOrderNo.Text = this.txtDescription.Text = this.txtSalaNo.Text = this.txtSalePerson.Text = this.txtDescription2.Text = "";            
            this.txtExtra.Value = this.txtDiscount.Value = 0;
            this.cmbClient.SelectedValue = -2;
            this.dtpDate.Value = DateTime.Now;
            this.dsOrder1.Clear();
            this.txtTotal.Text = this.txtFinalTotal.Text = this.txtBalance.Text = this.txtReceive.Text = txtPayback.Text = "0";
            this.chkDelivered.Checked = false;
            this.dtpDate.Enabled = true;
            this.ValidStock = true;
            this.dtpDelivered.Value = DateTime.Now;
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
                if (this.dgDetail.CurrentRow != null && this.dgDetail.CurrentRow.Index != -1)
                {
                    if (e.ColumnIndex == this.dgDetail.Columns["itemId"].Index)
                    {
                        int id = Convert.ToInt32(this.dgDetail["itemId", e.RowIndex].Value);

                        using (this.DB = new InventoryEntities(this.objCore.getClientConnectionStringName()))
                        {
                            var item = this.DB.Items.Where(x => x.ItemId == id).FirstOrDefault();
                            //this.dgDetail["unitPrice", e.RowIndex].Value = item.SalePrice.ToString();
                            this.dgDetail["ItemCode", e.RowIndex].Value = item.Code;
                            this.dgDetail["unitPrice", e.RowIndex].Value = 0;
                            this.dgDetail["Cost", e.RowIndex].Value = item.PurchasePrice.ToString();
                        }
                    }

                    if (e.ColumnIndex == this.dgDetail.Columns["qty"].Index || e.ColumnIndex == this.dgDetail.Columns["unitPrice"].Index)
                    {
                        int qty = Convert.ToInt32(this.dgDetail["qty", e.RowIndex].Value);
                        this.dgDetail["totalPrice", e.RowIndex].Value = Convert.ToDecimal(this.dgDetail["unitPrice", e.RowIndex].Value) * qty;
                        this.dgDetail["DQty", e.RowIndex].Value = qty.ToString();
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
            try
            {
                if (this.dgDetail.CurrentRow.Index != -1)
                {
                    if (e.ColumnIndex == this.dgDetail.Columns["Delete"].Index)
                    {
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
                ////Grid Total
                //decimal GridTotal = 0, ExtraAmount = 0, FinalTotal = 0, Balance = 0, TotalReturn = 0;
                //for (int i = 0; i < this.dgDetail.Rows.Count - 1; i++)
                //{
                //    if (Convert.ToBoolean(this.dgDetail["ItemReturn", i].Value))
                //    {
                //        TotalReturn += Convert.ToDecimal(this.dgDetail["totalPrice", i].Value);
                //    }
                //    else
                //    {
                //        GridTotal += Convert.ToDecimal(this.dgDetail["totalPrice", i].Value);
                //    }
                    
                //}
                //GridTotal -= TotalReturn;
                //this.txtTotal.Text = GridTotal.ToString();
                //ExtraAmount = this.txtExtra.Value;
                //FinalTotal = GridTotal + ExtraAmount;
                //Balance = FinalTotal;// -Convert.ToDecimal(this.txtReceive.Text.Trim());
                //if ( this.model != null)
                //{
                //    using (this.DB = new InventoryEntities())
                //    {
                //        decimal pay = this.DB.Database.SqlQuery<decimal>("select dbo.funOrderPayBack(" + this.model.Id + ")").FirstOrDefault();
                //        this.txtPayback.Text = pay.ToString();
                //        Balance += pay;

                //        var OrderReceive = this.DB.Database.SqlQuery<decimal>("select dbo.funOrderReceive(" + this.model.Id.ToString() + ")").FirstOrDefault();
                //        this.txtReceive.Text = OrderReceive.ToString();
                //        Balance -= OrderReceive;
                //    }
                //}
                //this.txtFinalTotal.Text = FinalTotal.ToString();
                //this.txtBalance.Text = Balance.ToString();

                decimal GridTotal = 0, ExtraAmount = 0, FinalTotal = 0, Balance = 0, TotalReturn = 0, PayBack = 0, ReceiveAmount = 0 ;
                for (int i = 0; i < this.dgDetail.Rows.Count - 1; i++)
                {
                    if (Convert.ToBoolean(this.dgDetail["ItemReturn", i].Value))
                    {
                        TotalReturn += Convert.ToDecimal(this.dgDetail["totalPrice", i].Value);
                        this.dgDetail.Rows[i].DefaultCellStyle.BackColor = Color.PaleVioletRed;
                    }
                    else
                    {
                        GridTotal += Convert.ToDecimal(this.dgDetail["totalPrice", i].Value);
                        this.dgDetail.Rows[i].DefaultCellStyle.BackColor = Color.White;
                    }

                }
                Balance = GridTotal - TotalReturn;
                this.txtTotal.Text = Balance.ToString();
                Balance += Convert.ToDecimal(this.txtExtra.Value);
                Balance -= Convert.ToDecimal(this.txtDiscount.Value);

                this.txtFinalTotal.Text = Balance.ToString();

                if (this.model != null)
                {
                    using (this.DB = new InventoryEntities(this.objCore.getClientConnectionStringName()))
                    {
                        PayBack = this.DB.Database.SqlQuery<decimal>("select dbo.funOrderPayBack(" + this.model.Id + ")").FirstOrDefault();
                        this.txtPayback.Text = PayBack.ToString();
                        
                        ReceiveAmount = this.DB.Database.SqlQuery<decimal>("select dbo.funOrderReceive(" + this.model.Id.ToString() + ")").FirstOrDefault();
                        this.txtReceive.Text = ReceiveAmount.ToString();
                        
                    }
                }

                Balance -= ReceiveAmount;
                Balance += PayBack;

                this.txtBalance.Text = Balance.ToString();

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
                    if (!this.objCore.CheckRight(6, this.model.Id, true))
                    {
                        return;
                    }

                    if (!CommonTask.Question(0, true)) return;
                    int deleteid = Convert.ToInt32(this.dgSearch["orderid", e.RowIndex].Value);

                    using (this.DB = new InventoryEntities(this.objCore.getClientConnectionStringName()))
                    {
                        //this.model.Id = deleteid;
                        //this.DB.Entry(this.model).State = System.Data.Entity.EntityState.Deleted;
                        //this.DB.SaveChanges();
                        //this.LoadOrder();
                        objCore.RecoardLogs("Order create order # : " + deleteid.ToString(), "Order");

                        this.DB.spDeleteOrder(deleteid);
                        this.LoadOrder();
                    }
                    this.FromClear();
                }

                if (e.ColumnIndex == this.dgSearch.Columns["Edit"].Index)
                {
                    this.Cursor = Cursors.WaitCursor;
                    int editId = Convert.ToInt32(this.dgSearch["orderid", e.RowIndex].Value);

                    this.FromClear();

                    this.dsOrder1.Clear();
                    this.ADEdit.SelectCommand.Connection.ConnectionString = this.objCore.getClientConnectionString();
                    this.ADEdit.SelectCommand.Parameters["@id"].Value = editId;
                    this.ADEdit.Fill(this.dsOrder1);

                    using (this.DB = new InventoryEntities(this.objCore.getClientConnectionStringName()))
                    {
                        this.model = this.DB.Orders.Where(x => x.Id == editId).FirstOrDefault();
                        this.txtOrderNo.Text = this.model.OrderNo.ToString();
                        this.dtpDate.Value = Convert.ToDateTime(this.model.OrderDate);
                        this.cmbClient.SelectedValue = this.model.ClientId;
                        this.txtDescription.Text = this.model.Description;
                        this.txtDescription2.Text = this.model.Description2;
                        this.txtExtraDetail.Text = this.model.ExtraDetail;
                        this.txtExtra.Value = Convert.ToDecimal(this.model.ExtraAmount);
                        this.chkDelivered.Checked = (bool)this.model.Delivered;
                        this.txtSalePerson.Text = this.model.SalePerson;
                        this.txtSalaNo.Text = this.model.Sale_Id.ToString();
                        this.txtDiscount.Value = Convert.ToDecimal(this.model.Discount);
                        if ((bool)this.model.Delivered)
                            this.dtpDelivered.Value = (DateTime)this.model.DeliveredDate;
                    }

                    this.tab.SelectedTab = this.tabAddEdit;
                    this.dtpDate.Enabled = false;
                    this.btnSave.Text = "Update";
                    
                    this.GetBalance();
                    this.Calculate();
                    this.Cursor = Cursors.Default;
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.LoadOrder();
            this.GetTotal();
        }

        private void btnReceive_Click(object sender, EventArgs e)
        {
            if (this.model.Id != -1)
            {
                frmOrderReceive obj = new frmOrderReceive();
                obj.Order_id = this.model.Id;
                obj.WindowState = FormWindowState.Normal;
                obj.StartPosition = FormStartPosition.CenterParent;
                obj.ShowDialog();
                this.Calculate();
            }
        }

        private void chkDelivered_CheckedChanged(object sender, EventArgs e)
        {
            this.dtpDelivered.Enabled = this.chkDelivered.Checked;
        }

        private void cmbClient_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (this.cmbClient.SelectedValue.ToString() == "-1")
            {
                frmclient obj = new frmclient();
                obj.quickCall = true;
                obj.StartPosition = FormStartPosition.CenterParent;
                obj.ShowDialog();
                this.LoadClientList();
                using (this.DB = new InventoryEntities(this.objCore.getClientConnectionStringName()))
                {
                    var id = this.DB.Clients.Max(x => x.ClientId);
                    this.cmbClient.SelectedValue = id;
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

        private void GetBalance()
        {
            //using (this.DB = new InventoryEntities())
            //{
            //    var balance = this.DB.Database.SqlQuery<decimal>("select dbo.funOrderBalance(" + this.model.Id.ToString() + ")").FirstOrDefault();
            //    this.txtBalance.Text = balance.ToString();
            //    //this.txtReceive.Text = (Convert.ToDecimal(this.txtFinalTotal.Text) - balance).ToString();
            //    var OrderReceive = this.DB.Database.SqlQuery<decimal>("select dbo.funOrderReceive(" + this.model.Id.ToString() + ")").FirstOrDefault();
            //    this.txtReceive.Text = OrderReceive.ToString();
            //}
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
                        obj.ShowDialog();

                        this.objCore.fillGridComboBoxWithAddNewOption((DataGridViewComboBoxColumn)this.dgDetail.Columns["itemId"], "Select ItemId, Title from Items", this.objCore.getClientConnectionString());

                        if (obj.Selected)
                        {
                            this.dgDetail["itemId", e.RowIndex].Value = obj.ItemId;
                            this.dgDetail.ClearSelection();
                            this.dgDetail.CurrentCell = this.dgDetail.Rows[e.RowIndex].Cells["qty"];
                            this.dgDetail.Rows[e.RowIndex].Cells["qty"].Value = 1;
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

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (this.model.Id != -1)
            {
                Reports.frmSaleInvoice obj = new Reports.frmSaleInvoice();
                obj.Id = this.model.Id;
                obj.MdiParent = this.MdiParent;
                obj.Show();
            }
        }

        private void btnDeliveryChallan_Click(object sender, EventArgs e)
        {
            if (this.model.Id != -1)
            {
                Reports.frmSaleInvoice obj = new Reports.frmSaleInvoice();
                obj.Id = this.model.Id;
                obj.DeliveryChallan = true;
                obj.MdiParent = this.MdiParent;
                obj.Show();

                objCore.RecoardLogs("Order delivery Challan Printed order # : " + this.model.Id.ToString(), "Sale Order");
            }
        }

        private void ConditionSearch(bool Delivered)
        {
            this.dsOrderSearch1.Clear();
            this.daConditionSearch.SelectCommand.Connection.ConnectionString = this.objCore.getClientConnectionString();
            this.daConditionSearch.SelectCommand.Parameters["@Delivered"].Value = Delivered;
            this.daConditionSearch.Fill(this.dsOrderSearch1);
        }


        private void btnOrder_Click(object sender, EventArgs e)
        {
            this.ConditionSearch(false);
            this.GetTotal();
        }

        private void btnSale_Click(object sender, EventArgs e)
        {
            this.ConditionSearch(true);
            this.GetTotal();
        }

        private void txtkey_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string SearchKey = this.txtkey.Text.Trim();

                this.dsOrderSearch1.Clear();
                this.daSearchKey.SelectCommand.Connection.ConnectionString = this.objCore.getClientConnectionString();
                this.daSearchKey.SelectCommand.Parameters["@Key"].Value = SearchKey;
                this.daSearchKey.Fill(this.dsOrderSearch1);
            }
            catch (Exception ex)
            {

            }
        }

        private void dgSearch_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                this.dgSearch.ClearSelection();
                for (int i = 0; i < this.dgSearch.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(this.dgSearch.Rows[i].Cells["dgDelivered"].Value))
                    {
                        this.dgSearch.Rows[i].DefaultCellStyle.BackColor = Color.LightSkyBlue;
                    }
                    else
                    {
                        this.dgSearch.Rows[i].DefaultCellStyle.BackColor = Color.Beige;
                    }

                }
            }
            catch (Exception ex)
            {

            }
        }

        private void txtDiscount_ValueChanged(object sender, EventArgs e)
        {
            this.Calculate();
        }

        private void btnPayPrint_Click(object sender, EventArgs e)
        {
            if (this.model.Id != -1)
            {
                Reports.frmOrderPaymentDetail obj = new Reports.frmOrderPaymentDetail();
                obj.Id = this.model.Id.ToString();
                obj.MdiParent = this.MdiParent;
                obj.Show();

                objCore.RecoardLogs("Order Print order # : " + this.model.Id.ToString(), "Sale Order");
            }
        }
        
    }
}
