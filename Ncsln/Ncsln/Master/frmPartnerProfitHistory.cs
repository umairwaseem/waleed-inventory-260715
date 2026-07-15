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

namespace Ncsln.Master
{
    public partial class frmPartnerProfitHistory : Form
    {
        CoreClass ObjCore;
        public frmPartnerProfitHistory()
        {
            InitializeComponent();
            this.ObjCore = new CoreClass();
        }

        private void frmPartnerProfitHistory_Load(object sender, EventArgs e)
        {
            try
            {
                this.dsPartnerProfitHistory1.Clear();
                this.daPartnerProfitHistory.SelectCommand.Connection.ConnectionString = this.ObjCore.getHBCConnectionString();
                this.daPartnerProfitHistory.Fill(this.dsPartnerProfitHistory1);
            }
            catch (Exception ex)
            {

            }
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            try
            {
                this.dsPartnerProfitHistory1.Clear();
                this.daPartnerProfitHistory.SelectCommand.Connection.ConnectionString = this.ObjCore.getHBCConnectionString();
                this.daPartnerProfitHistory.Fill(this.dsPartnerProfitHistory1);
            }
            catch (Exception ex)
            {

            }
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    if (e.ColumnIndex == this.dgv.Columns["Edit"].Index)
                    {
                        int id = Convert.ToInt32(this.dgv["Id", e.RowIndex].Value);

                        frmPartnerProfit obj = new frmPartnerProfit();
                        obj.Id = id;
                        obj.MdiParent = this.MdiParent;
                        obj.Show();
                    }

                    if (e.ColumnIndex == this.dgv.Columns["Delete"].Index)
                    {
                        if (!CommonTask.Question(-1, true)) return;

                        int id = Convert.ToInt32(this.dgv["id", e.RowIndex].Value);

                        this.DelateHistroy(id);
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void DelateHistroy(int Id)
        {
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
                com.CommandText = "spDeletePartnerProfit";

                com.Parameters.AddWithValue("@Id", Id.ToString());

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
                    //this.dgDetail.ClearSelection();
                    MessageBox.Show(message, "Stop", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                this.dsPartnerProfitHistory1.Clear();
                this.daPartnerProfitHistory.SelectCommand.Connection.ConnectionString = this.ObjCore.getHBCConnectionString();
                this.daPartnerProfitHistory.Fill(this.dsPartnerProfitHistory1);
            }
        }
    }
}
