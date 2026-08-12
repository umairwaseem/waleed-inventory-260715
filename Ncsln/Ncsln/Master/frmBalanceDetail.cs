using Ncsln.Classes;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Ncsln.Master
{
    public partial class frmBalanceDetail : Form
    {
        private const string PermissionName = "Balance Detail";
        private readonly CoreClass objCore;
        private int id = -1;

        public int CreatedBalanceDetailId { get; private set; }

        public frmBalanceDetail()
        {
            InitializeComponent();
            this.objCore = new CoreClass();
            this.CreatedBalanceDetailId = -1;
        }

        private void frmBalanceDetail_Load(object sender, EventArgs e)
        {
            if (!this.objCore.getUserRight(PermissionName, "CanView", this.objCore.getHBCConnectionString()))
            {
                MessageBox.Show("You have no right to View", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
                return;
            }
            this.LoadBalanceDetails();
        }

        private void LoadBalanceDetails()
        {
            try
            {
                this.dsBalanceDetail1.BalanceDetail.Clear();
                using (SqlConnection connection = new SqlConnection(this.objCore.getHBCConnectionString()))
                using (SqlDataAdapter adapter = new SqlDataAdapter("spBalanceDetailList", connection))
                {
                    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    adapter.Fill(this.dsBalanceDetail1.BalanceDetail);
                }
                this.dgv.DataSource = this.dsBalanceDetail1.BalanceDetail;
                this.dgv.ClearSelection();
                this.ApplyFilter();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string title = this.txtTitle.Text.Trim();
            if (title.Length == 0)
            {
                MessageBox.Show("Please enter title", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtTitle.Focus();
                return;
            }
            if (!this.objCore.CheckRightServer(PermissionName, this.id)) return;
            if (!CommonTask.Question(this.id)) return;

            try
            {
                bool creating = this.id == -1;
                using (SqlConnection connection = new SqlConnection(this.objCore.getHBCConnectionString()))
                using (SqlCommand command = new SqlCommand(creating ? "spCreateBalanceDetail" : "spUpdateBalanceDetail", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    if (!creating) command.Parameters.Add("@Id", SqlDbType.Int).Value = this.id;
                    command.Parameters.Add("@Title", SqlDbType.NVarChar, 150).Value = title;
                    command.Parameters.Add("@Notes", SqlDbType.NVarChar, 500).Value = string.IsNullOrWhiteSpace(this.txtNotes.Text) ? (object)DBNull.Value : this.txtNotes.Text.Trim();
                    SqlParameter idParameter = null;
                    if (creating)
                    {
                        idParameter = command.Parameters.Add("@Id", SqlDbType.Int);
                        idParameter.Direction = ParameterDirection.Output;
                    }
                    SqlParameter successParameter = command.Parameters.Add("@Success", SqlDbType.Bit);
                    successParameter.Direction = ParameterDirection.Output;
                    SqlParameter messageParameter = command.Parameters.Add("@Message", SqlDbType.NVarChar, 200);
                    messageParameter.Direction = ParameterDirection.Output;
                    connection.Open();
                    command.ExecuteNonQuery();

                    bool success = successParameter.Value != DBNull.Value && Convert.ToBoolean(successParameter.Value);
                    string message = Convert.ToString(messageParameter.Value);
                    if (!success)
                    {
                        MessageBox.Show(message, "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }
                    if (creating && idParameter.Value != DBNull.Value)
                        this.CreatedBalanceDetailId = Convert.ToInt32(idParameter.Value);
                }

                this.LoadBalanceDetails();
                if (this.Modal && this.CreatedBalanceDetailId > 0)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    this.ClearForm();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            int selectedId = Convert.ToInt32(this.dgv.Rows[e.RowIndex].Cells["colId"].Value);
            if (e.ColumnIndex == this.dgv.Columns["colEdit"].Index)
            {
                this.id = selectedId;
                this.txtTitle.Text = Convert.ToString(this.dgv.Rows[e.RowIndex].Cells["colTitle"].Value);
                this.txtNotes.Text = Convert.ToString(this.dgv.Rows[e.RowIndex].Cells["colNotes"].Value);
                this.btnSave.Text = "Update";
            }
            else if (e.ColumnIndex == this.dgv.Columns["colDelete"].Index)
            {
                if (!this.objCore.CheckRightServer(PermissionName, selectedId, true)) return;
                if (!CommonTask.Question(selectedId, true)) return;
                this.DeleteBalanceDetail(selectedId);
            }
        }

        private void DeleteBalanceDetail(int selectedId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(this.objCore.getHBCConnectionString()))
                using (SqlCommand command = new SqlCommand("spDeleteBalanceDetail", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@Id", SqlDbType.Int).Value = selectedId;
                    SqlParameter success = command.Parameters.Add("@Success", SqlDbType.Bit);
                    success.Direction = ParameterDirection.Output;
                    SqlParameter message = command.Parameters.Add("@Message", SqlDbType.NVarChar, 200);
                    message.Direction = ParameterDirection.Output;
                    connection.Open();
                    command.ExecuteNonQuery();
                    if (success.Value == DBNull.Value || !Convert.ToBoolean(success.Value))
                    {
                        MessageBox.Show(Convert.ToString(message.Value), "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }
                }
                this.ClearForm();
                this.LoadBalanceDetails();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e) { this.ClearForm(); }

        private void ClearForm()
        {
            this.id = -1;
            this.txtTitle.Clear();
            this.txtNotes.Clear();
            this.btnSave.Text = "Save";
            this.txtTitle.Focus();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e) { this.ApplyFilter(); }

        private void ApplyFilter()
        {
            if (this.dsBalanceDetail1 == null || this.dsBalanceDetail1.BalanceDetail == null) return;
            string value = this.txtSearch.Text.Trim().Replace("'", "''");
            this.dsBalanceDetail1.BalanceDetail.DefaultView.RowFilter = value.Length == 0 ? string.Empty : "Title LIKE '%" + value + "%' OR Notes LIKE '%" + value + "%'";
        }
    }
}
