using Ncsln.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Ncsln.Inventory
{
    public partial class frmItem : Form
    {
        DBModel.InventoryEntities DB;
        DBModel.Item item;
        Classes.CoreClass objCore;
        public bool quickCall = false;
        public bool justClose = false;
        public decimal PercentRate = 0;

        public frmItem()
        {
            InitializeComponent();
            
            this.item = new DBModel.Item();
            this.objCore = new Classes.CoreClass();
        }

        private void frmItem_Load(object sender, EventArgs e)
        {
            this.LoadDg();
            this.PercentRate = Convert.ToDecimal(this.objCore.GetSetting(7));
            this.objCore.fillComboBoxOptioni(this.cmbVendor, "Select VendorId, Name from vendors where VendorId > 1", this.objCore.getClientConnectionString());
            this.item.ItemId = -1;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.justClose = true;
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.objCore.CheckRight(1, this.item.ItemId))
            {
                return;
            }

            if (this.txtTitle.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please enter Item Title", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtTitle.Focus();
                return;
            }

            if (this.txtCode.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please enter Item Code", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtCode.Focus();
                return;
            }

            if (this.txtPrice.Value < 1)
            {
                MessageBox.Show("The cost price can't be zero", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtPrice.Focus();
                return;
            }

            string[] vendorCode = this.txtCode.Text.Trim().Split(' ');

            if (vendorCode[0] == "V1" || vendorCode[0] == "v1")
            {
                MessageBox.Show("You have no right to add V1 vendor", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtCode.Focus();
                return;
            }

            //this.SaveUpdate();
            this.preCheck();
        }

        private void preCheck()
        {
            try
            {
                if (this.item.ItemId == -1)
                {
                    //DataTable V1dt = this.objCore.getDataSet()

                    DataTable dt = this.objCore.getDataSet("Select * from ItemList Where Code like '%" + this.txtCode.Text.Trim() + "%'", this.objCore.getHBCConnectionString()).Tables[0];
                    DataTable dtLocal = this.objCore.getDataSet("Select * from Items Where Code like '%" + this.txtCode.Text.Trim() + "%'", this.objCore.getClientConnectionString()).Tables[0];

                    if (dt.Rows.Count > 0 || dtLocal.Rows.Count > 0)
                    {
                        DialogResult dr = MessageBox.Show("You are entering similar model, do you want to add same more!", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (dr == System.Windows.Forms.DialogResult.No)
                            return;

                        this.SaveForAll();
                    }
                    else
                    {
                        this.SaveForAll();
                    }
                }
                else
                {
                    this.SaveForAll();
                }
                
            }
            catch (Exception ex)
            {

            }
        }


        private void SaveForAll()
        {
            if (!CommonTask.Question(this.item.ItemId)) return;

            SqlConnection con = new SqlConnection();
            con.ConnectionString = this.objCore.getHBCConnectionString();
            con.Open();
            SqlTransaction tran = con.BeginTransaction();
            SqlCommand com = new SqlCommand("", con, tran);
            bool success = false;
            try
            {
                if (this.item.ItemId == -1)
                {
                    com.CommandType = CommandType.StoredProcedure;
                    com.CommandText = "spCreateItemsList";

                    com.Parameters.AddWithValue("@Title", this.txtTitle.Text.Trim());
                    com.Parameters.AddWithValue("@Code", this.txtCode.Text.Trim());
                    com.Parameters.AddWithValue("@PurchasePrice", this.txtPrice.Value.ToString());
                    com.Parameters.AddWithValue("@Branch_Id", Classes.companyInfo.branchCode);
                    com.Parameters.AddWithValue("@Hide", "0");

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
                    {
                        this.item.ItemId = Convert.ToInt32(com.Parameters["@Id"].Value);
                        this.txtId.Text = com.Parameters["@Id"].Value.ToString();
                        this.btnSave.Text = "Update";
                    }

                    tran.Commit();
                }
                else
                {
                    com.CommandType = CommandType.StoredProcedure;
                    com.CommandText = "spUpdateItemsList";

                    com.Parameters.AddWithValue("@Id", this.item.ItemId);
                    com.Parameters.AddWithValue("@Title", this.txtTitle.Text.Trim());
                    com.Parameters.AddWithValue("@Code", this.txtCode.Text.Trim());
                    com.Parameters.AddWithValue("@PurchasePrice", this.txtPrice.Value.ToString());
                    com.Parameters.AddWithValue("@Branch_Id", Classes.companyInfo.branchCode);
                    com.Parameters.AddWithValue("@Hide", "0");

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
                    {
                        this.btnSave.Text = "Update";
                    }

                    tran.Commit();
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
                //sthis.ClearForm();
                this.LoadDg();
                if (this.quickCall) this.Close();
            }
        }
        

        private void SaveUpdate()
        {
            if(!CommonTask.Question(this.item.ItemId)) return;

            using (this.DB = new DBModel.InventoryEntities(this.objCore.getClientConnectionStringName()))
            {
                if (this.item.ItemId == -1)
                    if (this.DB.Items.Where(x => x.Code.Contains(this.txtCode.Text.Trim())).ToList().Count > 0)
                    {
                        DialogResult dr = MessageBox.Show("You are enter similar model, do you want to add same more!", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (dr == System.Windows.Forms.DialogResult.No)
                            return;
                    }

                //if (this.DB.Items.Where(x => x.Code == this.txtCode.Text.Trim() && x.ItemId != this.item.ItemId).ToList().Count() > 0)
                //{
                //    MessageBox.Show("This code is already taken try another!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    return;
                //}


                this.item.Title = this.txtTitle.Text.Trim();
                this.item.Code = this.txtCode.Text.Trim();
                this.item.PurchasePrice = this.txtPrice.Value;
                this.item.SalePrice = this.txtSalePrice.Value;
                if (this.cmbVendor.Text != "")
                    this.item.VendorId = Convert.ToInt32(this.cmbVendor.SelectedValue);
                if (this.item.ItemId == -1)
                    this.DB.Items.Add(this.item);
                else
                    this.DB.Entry(this.item).State = EntityState.Modified;                
                this.DB.SaveChanges();
            }
            this.ClearForm();
            this.LoadDg();
            if (this.quickCall) this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.ClearForm();
        }

        private void ClearForm()
        {
            this.txtTitle.Text = this.txtCode.Text = this.txtId.Text = "";
            this.txtStartPrice.Value = this.txtExtra.Value = this.txtOverHead.Value = 0;
            this.txtPrice.Value = this.txtSalePrice.Value = 0;
            this.btnSave.Text = "Save";
            this.item.ItemId = -1;
            this.txtOverHead.Visible = this.txtStartPrice.Visible = true;
            this.label8.Visible = this.label9.Visible = true;
            this.label3.Text = "Final Price";
        }

        private void LoadDg()
        {
            try
            {
                this.dsItems1.Clear();
                this.ADItems.SelectCommand.Connection.ConnectionString = this.objCore.getClientConnectionString();
                this.ADItems.SelectCommand.Parameters["@key"].Value = this.txtSearch.Text.Trim();
                this.ADItems.Fill(this.dsItems1);

                for (int i = 0; i < this.dg.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(this.dg["Hide", i].Value))
                    {
                        this.dg.Rows[i].DefaultCellStyle.BackColor = Color.LightGray;
                    }
                }
            }
            catch (Exception ex)
            {

            }
            
        }

        private void dg_DoubleClick(object sender, EventArgs e)
        {
            if (this.dg.CurrentRow.Index != -1)
            {
                frmUpdateItem obj = new frmUpdateItem();
                obj.Id = this.dg.CurrentRow.Cells["itemId"].Value.ToString();
                obj.ShowDialog();

                this.LoadDg();

                //this.item.ItemId = Convert.ToInt32(this.dg.CurrentRow.Cells["itemId"].Value);

                //DataTable dt = this.objCore.getDataSet("select * from Items where ItemId = " + this.item.ItemId.ToString()).Tables[0];

                //this.txtId.Text = dt.Rows[0]["ItemId"].ToString();
                //this.txtTitle.Text = dt.Rows[0]["Title"].ToString();
                //this.txtCode.Text = dt.Rows[0]["Code"].ToString();
                //this.txtPrice.Value = Convert.ToDecimal(dt.Rows[0]["PurchasePrice"]);

                //this.btnSave.Text = "Update";

                //using (this.DB = new DBModel.InventoryEntities(this.objCore.getClientConnectionStringName()))
                //{
                //    this.item = this.DB.Items.Where(x => x.ItemId == this.item.ItemId).FirstOrDefault();
                //    this.txtId.Text = this.item.ItemId.ToString();
                //    this.txtTitle.Text = this.item.Title;
                //    this.txtCode.Text = this.item.Code;
                //    this.txtPrice.Value = (decimal)this.item.PurchasePrice;
                //    //this.txtSalePrice.Value = (decimal)this.item.SalePrice;
                    
                //    this.btnSave.Text = "Update";
                //}
            }
        }

        private void dg_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (this.dg.CurrentRow.Index != -1)
                {
                    //if (e.ColumnIndex == this.dg.Columns["Delete"].Index)
                    //{
                    //    if (!this.objCore.CheckRight(1, this.item.ItemId, true))
                    //    {
                    //        return;
                    //    }

                    //    if (!CommonTask.Question(this.item.ItemId, true)) return;

                    //    using (this.DB = new DBModel.InventoryEntities(this.objCore.getClientConnectionStringName()))
                    //    {
                    //        int value = Convert.ToInt32(this.dg.CurrentRow.Cells["itemId"].Value.ToString());
                    //        //this.txtId.Text = value.ToString();
                    //        this.item.ItemId = value;
                    //        this.DB.Entry(this.item).State = EntityState.Deleted;
                    //        this.DB.SaveChanges();
                    //        this.ClearForm();
                    //        this.LoadDg();
                    //    }
                    //}
                    if (e.ColumnIndex == this.dg.Columns["Edit"].Index)
                    {
                        this.item.ItemId = Convert.ToInt32(this.dg["itemId", e.RowIndex].Value);

                        DataTable dt = this.objCore.getDataSet("select * from Items where ItemId = " + this.item.ItemId.ToString(), this.objCore.getClientConnectionString()).Tables[0];

                        string[] vendorCode = dt.Rows[0]["Code"].ToString().Trim().Split(' ');

                        if (vendorCode[0] == "V1")
                        {
                            this.txtOverHead.Visible = this.txtStartPrice.Visible = false;
                            this.label8.Visible = this.label9.Visible = false;
                            this.label3.Text = "Price";
                        }

                        this.txtId.Text = dt.Rows[0]["ItemId"].ToString();
                        this.txtTitle.Text = dt.Rows[0]["Title"].ToString();
                        this.txtCode.Text = dt.Rows[0]["Code"].ToString();
                        this.txtStartPrice.Value = Convert.ToDecimal(dt.Rows[0]["Price"]);
                        this.txtOverHead.Value = Convert.ToDecimal(dt.Rows[0]["OverHead"]);
                        this.txtExtra.Value = Convert.ToDecimal(dt.Rows[0]["ExtraAmount"]);
                        this.txtPrice.Value = Convert.ToDecimal(dt.Rows[0]["PurchasePrice"]);

                        this.btnSave.Text = "Update";
                    }
                }
            }
            catch (Exception ex)
            {

            }
            
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            this.LoadDg();
        }

        private void frmItem_FormClosed(object sender, FormClosedEventArgs e)
        {
            //this.justClose = true;
        }

        private void txtStartPrice_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                bool model = this.txtCode.Text.Contains("V22");
                bool model_v31 = this.txtCode.Text.Contains("V31");
                bool model_v2 = this.txtCode.Text.Contains("V2 ");
                bool model_v32 = this.txtCode.Text.Contains("V32 ");
                if (model)
                {
                    this.PercentRate = Convert.ToDecimal(this.objCore.GetSetting(8));
                }
                else
                {
                    if (model_v31)
                    {
                        this.PercentRate = Convert.ToDecimal(this.objCore.GetSetting(9));
                    }
                    else if (model_v2 || model_v32)
                    {
                        this.PercentRate = Convert.ToDecimal(this.objCore.GetSetting(10));
                    }
                    else
                    {
                        this.PercentRate = Convert.ToDecimal(this.objCore.GetSetting(7));
                    }

                }
                decimal overhead = this.txtStartPrice.Value * (this.PercentRate / 100);
                this.txtOverHead.Value = overhead;
                this.txtPrice.Value = this.txtStartPrice.Value + overhead;
            }
            catch (Exception)
            {

            }
        }

        private void txtCode_TextChanged(object sender, EventArgs e)
        {
            try
            {
                bool model = this.txtCode.Text.Contains("V22");
                bool model_v31 = this.txtCode.Text.Contains("V31");
                if (model)
                {
                    this.PercentRate = Convert.ToDecimal(this.objCore.GetSetting(8));
                }
                else
                {
                    if (model_v31)
                    {
                        this.PercentRate = Convert.ToDecimal(this.objCore.GetSetting(9));
                    }
                    else
                    {
                        this.PercentRate = Convert.ToDecimal(this.objCore.GetSetting(7));
                    }
                    
                }
                decimal overhead = this.txtStartPrice.Value * (this.PercentRate / 100);
                this.txtOverHead.Value = overhead;
                this.txtPrice.Value = this.txtStartPrice.Value + overhead;
            }
            catch (Exception ex)
            {

            }
        }
    }
}
