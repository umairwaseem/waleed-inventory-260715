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
    public partial class frmHBCStock : Form
    {
        CoreClass ObjCore;
        private bool HBCStock = false;

        public frmHBCStock()
        {
            InitializeComponent();
            this.ObjCore = new CoreClass();
        }

        private void frmHBCStock_Load(object sender, EventArgs e)
        {
            try
            {
                this.ObjCore.fillComboBoxOptioni(this.cmbLocalItemList, "Select ItemId, Code + ' ' + Title as Title from Items", this.ObjCore.getClientConnectionString());
                this.ObjCore.fillComboBoxOptioni(this.cmbHBCItems, "Select Id, Code + ' ' + Name as Name from SItems ", this.ObjCore.getHBCConnectionString());

                this.getStock();

            }
            catch (Exception)
            {
                
            }
        }

        private void cmbHBCItems_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //try
            //{
            //    DataTable dt = this.ObjCore.getDataSet("select dbo.funGetStockBalance(" + this.cmbHBCItems.SelectedValue.ToString() + ")", this.ObjCore.getHBCConnectionString()).Tables[0];

            //    this.lbCurrentStock.Text = Convert.ToInt32(dt.Rows[0][0]).ToString();
            //}
            //catch (Exception ex)
            //{

            //}
        }

        private void cmbHBCItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.getStock();
        }

        private void getStock()
        {
            try
            {
                DataTable dt = this.ObjCore.getDataSet("select dbo.funGetStock(" + this.cmbHBCItems.SelectedValue.ToString() + ")", this.ObjCore.getHBCConnectionString()).Tables[0];

                this.lbCurrentStock.Text = Convert.ToInt32(dt.Rows[0][0]).ToString();
            }
            catch (Exception ex)
            {

            }
        }

        private void btnStock_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = MessageBox.Show("Are sure to get stock from HBC", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == System.Windows.Forms.DialogResult.No) return;

                DataTable dt = this.ObjCore.getDataSet("select dbo.funGetStock(" + this.cmbHBCItems.SelectedValue.ToString() + ")", this.ObjCore.getHBCConnectionString()).Tables[0];
                if (Convert.ToInt32(dt.Rows[0][0]) < 1)
                {
                    MessageBox.Show("Selected item may have no stock available in HBC or some other taken while you process", "Alert");
                    return;
                }

               // string command = "Insert into InternalStock (CompanyName, ItemId, StockDate, Qty, Type) values ('HBC', '" + this.cmbLocalItemList.SelectedValue.ToString() + "', GETDATE(), '" + this.txtQty.Value.ToString() + "','1')";

               // this.ObjCore.executeQuery(command, this.ObjCore.getClientConnectionString());

                this.HBCStockEntry();

                this.getStock();

            }
            catch (Exception ex)
            {

            }
        }

        private void HBCStockEntry()
        {
            //1510 Office Empire

            string StockType = (this.rbtnGetStock.Checked) ? "OUT" : "IN";

            SqlConnection con = new SqlConnection();
            con.ConnectionString = this.ObjCore.getHBCConnectionString();
            con.Open();
            SqlTransaction tran = con.BeginTransaction();
            SqlCommand com = new SqlCommand("", con, tran);
            string command = string.Empty;
            string vendorAccountId = string.Empty;
            bool success = false;
            try
            {
                com.CommandType = CommandType.StoredProcedure;
                com.CommandText = "spCreateSStockOutFromBranch";

                com.Parameters.AddWithValue("@ItemId", this.cmbHBCItems.SelectedValue.ToString());
                com.Parameters.AddWithValue("@Qty", this.txtQty.Value.ToString());
                com.Parameters.AddWithValue("@Branch_Id", "1");
                com.Parameters.AddWithValue("@Type", StockType);

                com.Parameters.Add(new SqlParameter("@Success", SqlDbType.Bit, 1, ParameterDirection.Output, false, 1, 0, "Success", DataRowVersion.Default, null));
                com.Parameters.Add(new SqlParameter("@Message", SqlDbType.NVarChar, 200, ParameterDirection.Output, false, 200, 0, "Message", DataRowVersion.Default, null));
                com.UpdatedRowSource = UpdateRowSource.OutputParameters;
                com.ExecuteNonQuery();
                success = Convert.ToBoolean(com.Parameters["@Success"].Value);
                string message = com.Parameters["@Message"].Value.ToString();

                this.HBCStock = success;

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
                if (this.HBCStock)
                {
                    this.LocalStock();
                }
            }
        }

        private void LocalStock()
        {
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
                com.CommandText = "spCreateInternalStock";

                com.Parameters.AddWithValue("@ItemId", this.cmbLocalItemList.SelectedValue.ToString());
                com.Parameters.AddWithValue("@StockDate", DateTime.Now);
                com.Parameters.AddWithValue("@Qty", this.txtQty.Value);
                com.Parameters.AddWithValue("@CompanyName", companyInfo.companyName);
                com.Parameters.AddWithValue("@Type", this.rbtnGetStock.Checked.ToString());

                com.Parameters.Add(new SqlParameter("@Id", SqlDbType.Decimal, 18, ParameterDirection.Output, false, 18, 0, "SaleId", DataRowVersion.Default, null));
                com.Parameters.Add(new SqlParameter("@Success", SqlDbType.Bit, 1, ParameterDirection.Output, false, 1, 0, "Success", DataRowVersion.Default, null));
                com.Parameters.Add(new SqlParameter("@Message", SqlDbType.NVarChar, 200, ParameterDirection.Output, false, 200, 0, "Message", DataRowVersion.Default, null));
                com.UpdatedRowSource = UpdateRowSource.OutputParameters;
                com.ExecuteNonQuery();
                success = Convert.ToBoolean(com.Parameters["@Success"].Value);
                string message = com.Parameters["@Message"].Value.ToString();
                
                   
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
            }
        }
    }
}
