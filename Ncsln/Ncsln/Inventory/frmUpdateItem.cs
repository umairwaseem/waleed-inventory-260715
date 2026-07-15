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
    public partial class frmUpdateItem : Form
    {
        Classes.CoreClass objCore = new Classes.CoreClass();
        public string Id { get; set; }
        public frmUpdateItem()
        {
            InitializeComponent();
        }

        private void frmUpdateItem_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = this.objCore.getDataSet("Select * from Items Where ItemId = " + this.Id, this.objCore.getClientConnectionString()).Tables[0];

                this.txtPrice.Value = Convert.ToDecimal(dt.Rows[0]["AutoHide"]);
                this.chkHide.Checked = Convert.ToBoolean(dt.Rows[0]["Hide"]);
                this.chkAutoHide.Checked = Convert.ToBoolean(dt.Rows[0]["AutoHide"]);

            }
            catch (Exception)
            {

            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                this.UpdateItem();
            }
            catch (Exception)
            {

            }
        }

        private void UpdateItem()
        {
            if (!CommonTask.Question(1)) return;

            SqlConnection con = new SqlConnection();
            con.ConnectionString = this.objCore.getClientConnectionString();
            con.Open();
            SqlTransaction tran = con.BeginTransaction();
            SqlCommand com = new SqlCommand("", con, tran);
            bool success = false;
            try
            {
                    com.CommandType = CommandType.StoredProcedure;
                    com.CommandText = "spUpdateItems";

                    com.Parameters.AddWithValue("@ItemId", this.Id.ToString());
                    com.Parameters.AddWithValue("@Hide", this.chkHide.Checked.ToString());
                    com.Parameters.AddWithValue("@AutoHide", this.chkAutoHide.Checked.ToString());
                    com.Parameters.AddWithValue("@StockAlert", this.txtPrice.Value.ToString());

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
            catch (Exception ex)
            {
                tran.Rollback();
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
                //sthis.ClearForm();
                if (success)
                    this.Close();
            }
        }
    }
}
