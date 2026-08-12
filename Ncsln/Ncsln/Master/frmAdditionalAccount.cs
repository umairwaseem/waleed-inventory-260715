using Ncsln.Classes;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Ncsln.Master
{
    public partial class frmAdditionalAccount : Form
    {
        private const string PermissionName = "Additional Account List";
        private readonly CoreClass objCore;
        private int id = -1;

        public int CreatedAccountId { get; private set; }

        public frmAdditionalAccount()
        {
            InitializeComponent();
            this.objCore = new CoreClass();
            this.CreatedAccountId = -1;
        }

        private void frmAdditionalAccount_Load(object sender, EventArgs e)
        {
            if (!this.objCore.getUserRight(PermissionName, "CanView", this.objCore.getHBCConnectionString()))
            {
                MessageBox.Show("You have no right to View", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
                return;
            }
            this.LoadAccounts();
        }

        private void LoadAccounts()
        {
            try
            {
                this.dsAdditionalAccount1.AdditionalAccount.Clear();
                using (SqlConnection connection = new SqlConnection(this.objCore.getHBCConnectionString()))
                using (SqlDataAdapter adapter = new SqlDataAdapter("spAdditionalAccountList", connection))
                {
                    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    adapter.Fill(this.dsAdditionalAccount1.AdditionalAccount);
                }
                this.dgv.DataSource = this.dsAdditionalAccount1.AdditionalAccount;
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
            string accountName = this.txtAccountName.Text.Trim();
            if (accountName.Length == 0)
            {
                MessageBox.Show("Please enter account name", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtAccountName.Focus();
                return;
            }
            if (!this.objCore.CheckRightServer(PermissionName, this.id)) return;
            if (!CommonTask.Question(this.id)) return;

            try
            {
                bool creating = this.id == -1;
                using (SqlConnection connection = new SqlConnection(this.objCore.getHBCConnectionString()))
                using (SqlCommand command = new SqlCommand(creating ? "spCreateAdditionalAccount" : "spUpdateAdditionalAccount", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    if (!creating) command.Parameters.Add("@Id", SqlDbType.Int).Value = this.id;
                    command.Parameters.Add("@AccountName", SqlDbType.NVarChar, 150).Value = accountName;
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
                        this.CreatedAccountId = Convert.ToInt32(idParameter.Value);
                }

                this.LoadAccounts();
                if (this.Modal && this.CreatedAccountId > 0)
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
                this.txtAccountName.Text = Convert.ToString(this.dgv.Rows[e.RowIndex].Cells["colAccountName"].Value);
                this.txtNotes.Text = Convert.ToString(this.dgv.Rows[e.RowIndex].Cells["colNotes"].Value);
                this.btnSave.Text = "Update";
            }
            else if (e.ColumnIndex == this.dgv.Columns["colDelete"].Index)
            {
                if (!this.objCore.CheckRightServer(PermissionName, selectedId, true)) return;
                if (!CommonTask.Question(selectedId, true)) return;
                this.DeleteAccount(selectedId);
            }
        }

        private void DeleteAccount(int selectedId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(this.objCore.getHBCConnectionString()))
                using (SqlCommand command = new SqlCommand("spDeleteAdditionalAccount", connection))
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
                this.LoadAccounts();
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
            this.txtAccountName.Clear();
            this.txtNotes.Clear();
            this.btnSave.Text = "Save";
            this.txtAccountName.Focus();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e) { this.ApplyFilter(); }

        private void ApplyFilter()
        {
            if (this.dsAdditionalAccount1 == null || this.dsAdditionalAccount1.AdditionalAccount == null) return;
            string value = this.txtSearch.Text.Trim().Replace("'", "''");
            this.dsAdditionalAccount1.AdditionalAccount.DefaultView.RowFilter = value.Length == 0 ? string.Empty : "AccountName LIKE '%" + value + "%' OR Notes LIKE '%" + value + "%'";
        }
    }
}
