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
    public partial class frmRectifyItems : Form
    {
        CoreClass ObjCore;

        public frmRectifyItems()
        {
            InitializeComponent();
            this.ObjCore = new CoreClass();
        }

        private void frmRectifyItems_Load(object sender, EventArgs e)
        {
            try
            {
                this.lbBranchName.Text = companyInfo.companyName.ToString();
            }
            catch (Exception ex)
            {

                
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtLocalSearch_TextChanged(object sender, EventArgs e)
        {
            this.loadLocal();
        }

        private void txtServerSearch_TextChanged(object sender, EventArgs e)
        {
            this.loadServer();
        }

        private void dgvLocal_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    if (e.ColumnIndex == this.dgvLocal.Columns["Select"].Index)
                    {
                        this.txtLocalItemId.Text = this.dgvLocal["Id", e.RowIndex].Value.ToString();
                        this.txtCurrentItem.Text = this.dgvLocal["title", e.RowIndex].Value.ToString();
                        this.txtCurrentModel.Text = this.dgvLocal["code", e.RowIndex].Value.ToString();
                        this.txtCurrentPrice.Text = this.dgvLocal["price", e.RowIndex].Value.ToString();
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void dgvServer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    if (e.ColumnIndex == this.dgvServer.Columns["Selected"].Index)
                    {
                        this.txtServerItemId.Text = this.dgvServer["Ids", e.RowIndex].Value.ToString();
                        this.txtServerItem.Text = this.dgvServer["titles", e.RowIndex].Value.ToString();
                        this.txtServerModel.Text = this.dgvServer["codes", e.RowIndex].Value.ToString();
                        this.txtServerPrice.Text = this.dgvServer["prices", e.RowIndex].Value.ToString();
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void dgvLocal_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            try
            {
                if (this.dgvLocal["TryToChange", e.RowIndex].Value.ToString() == "1" && this.dgvLocal["Old_Id", e.RowIndex].Value.ToString() == "")
                {
                    this.dgvLocal.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.BlueViolet;
                } 
                else if (this.dgvLocal["Old_Id", e.RowIndex].Value.ToString() == "")
                {
                    this.dgvLocal.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.RosyBrown;
                }
                else
                {
                    this.dgvLocal.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void loadLocal()
        {
            try
            {
                this.dsRLocalItems1.Clear();
                this.dsRLocalItems1.EnforceConstraints = false;
                this.daLocalItems.SelectCommand.Connection.ConnectionString = this.ObjCore.getClientConnectionString();
                //this.daLocalItems.SelectCommand.Parameters["@key"].Value = this.txtLocalSearch.Text.Trim();
                this.daLocalItems.Fill(this.dsRLocalItems1);

                this.txtServerSearch.Text = this.txtLocalSearch.Text.Trim();
            }
            catch (Exception ex)
            {

            }
        }

        private void loadServer()
        {
            try
            {
                this.dsRServerItems1.Clear();
                this.dsRServerItems1.EnforceConstraints = false;
                this.daServerItems.SelectCommand.Connection.ConnectionString = this.ObjCore.getClientConnectionString();
                this.daServerItems.SelectCommand.CommandText = "SELECT ItemId as Id, Title as Name, Code, PurchasePrice, 0 as Branch_Id,  0 as OPStock, 0 as Hide FROM     Items as ItemList WHERE ItemId > 10000 and  (Code LIKE '%' + @key + '%')";
                this.daServerItems.SelectCommand.Parameters["@key"].Value = this.txtServerSearch.Text.Trim();
                this.daServerItems.Fill(this.dsRServerItems1);
            }
            catch (Exception ex)
            {

            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (this.txtLocalItemId.Text.Trim() == "")
            {
                MessageBox.Show("Current item is not selected", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (this.txtServerItemId.Text.Trim() == "")
            {
                MessageBox.Show("Server item is not selected", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult dr = MessageBox.Show("Are you sure to rectify item", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dr == System.Windows.Forms.DialogResult.No) return;

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
                com.CommandText = "spAdjustId";

                com.Parameters.AddWithValue("@CurrentId", this.txtLocalItemId.Text.Trim());
                com.Parameters.AddWithValue("@Server_Id", this.txtServerItemId.Text.Trim());

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
                    this.clearForm();
                    MessageBox.Show(message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // this.dgvItems.ClearSelection();
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
                this.loadLocal();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.clearForm();
        }

        private void clearForm()
        {
            this.txtLocalItemId.Text = this.txtCurrentPrice.Text = this.txtCurrentItem.Text = this.txtCurrentModel.Text = "";
            this.txtServerItemId.Text = this.txtServerItem.Text = this.txtServerModel.Text = this.txtServerPrice.Text = "";
        }
    }
}
