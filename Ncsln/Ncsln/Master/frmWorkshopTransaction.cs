using Ncsln.Classes;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Ncsln.Master
{
    public partial class frmWorkshopTransaction : Form
    {
        private readonly CoreClass objCore;
        private int id = -1;

        public frmWorkshopTransaction()
        {
            InitializeComponent();
            this.objCore = new CoreClass();
        }

        private void frmWorkshopTransaction_Load(object sender, EventArgs e)
        {
            this.LoadAccountCombo(-1);
            this.LoadTransactions();
        }

        private void LoadAccountCombo(int selectedAccountId)
        {
            try
            {
                DataTable accounts = new DataTable();
                using (SqlConnection connection = new SqlConnection(this.objCore.getHBCConnectionString()))
                using (SqlDataAdapter adapter = new SqlDataAdapter("spWorkshopAccountList", connection))
                {
                    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    adapter.Fill(accounts);
                }
                DataRow addNew = accounts.NewRow();
                addNew["Id"] = -1;
                addNew["AccountName"] = "<<--Add New-->>";
                accounts.Rows.InsertAt(addNew, 0);
                this.cmbAccount.DataSource = accounts;
                this.cmbAccount.DisplayMember = "AccountName";
                this.cmbAccount.ValueMember = "Id";
                this.cmbAccount.SelectedIndex = selectedAccountId > 0 ? -1 : 0;
                if (selectedAccountId > 0) this.cmbAccount.SelectedValue = selectedAccountId;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadTransactions()
        {
            try
            {
                this.dsWorkshopTransaction1.WorkshopTransaction.Clear();
                using (SqlConnection connection = new SqlConnection(this.objCore.getHBCConnectionString()))
                using (SqlDataAdapter adapter = new SqlDataAdapter("spWorkshopTransactionList", connection))
                {
                    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    adapter.Fill(this.dsWorkshopTransaction1.WorkshopTransaction);
                }
                this.dgv.DataSource = this.dsWorkshopTransaction1.WorkshopTransaction;
                this.dgv.ClearSelection();
                this.ApplyFilter();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int SelectedAccountId
        {
            get
            {
                if (this.cmbAccount.SelectedValue == null || this.cmbAccount.SelectedValue is DataRowView) return -1;
                int value;
                return int.TryParse(this.cmbAccount.SelectedValue.ToString(), out value) ? value : -1;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.SelectedAccountId <= 0)
            {
                MessageBox.Show("Please select a workshop account", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.cmbAccount.Focus();
                return;
            }
            if (this.txtAmount.Value <= 0)
            {
                MessageBox.Show("Amount must be greater than zero", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtAmount.Focus();
                return;
            }
            if (!CommonTask.Question(this.id)) return;

            try
            {
                bool creating = this.id == -1;
                using (SqlConnection connection = new SqlConnection(this.objCore.getHBCConnectionString()))
                using (SqlCommand command = new SqlCommand(creating ? "spCreateWorkshopTransaction" : "spUpdateWorkshopTransaction", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    if (!creating) command.Parameters.Add("@Id", SqlDbType.Int).Value = this.id;
                    command.Parameters.Add("@WorkshopAccountId", SqlDbType.Int).Value = this.SelectedAccountId;
                    command.Parameters.Add("@TransactionDate", SqlDbType.DateTime).Value = this.dtpTransactionDate.Value;
                    command.Parameters.Add("@Description", SqlDbType.NVarChar, 500).Value = string.IsNullOrWhiteSpace(this.txtDescription.Text) ? (object)DBNull.Value : this.txtDescription.Text.Trim();
                    SqlParameter amount = command.Parameters.Add("@Amount", SqlDbType.Decimal);
                    amount.Precision = 18;
                    amount.Scale = 2;
                    amount.Value = this.txtAmount.Value;
                    if (creating)
                    {
                        SqlParameter newId = command.Parameters.Add("@Id", SqlDbType.Int);
                        newId.Direction = ParameterDirection.Output;
                    }
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
                this.LoadTransactions();
                this.ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbAccount_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (this.SelectedAccountId != -1) return;
            using (frmWorkshopAccount accountForm = new frmWorkshopAccount())
            {
                if (accountForm.ShowDialog(this) == DialogResult.OK && accountForm.CreatedAccountId > 0)
                    this.LoadAccountCombo(accountForm.CreatedAccountId);
                else
                    this.LoadAccountCombo(-1);
            }
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow row = this.dgv.Rows[e.RowIndex];
            int selectedId = Convert.ToInt32(row.Cells["colId"].Value);
            if (e.ColumnIndex == this.dgv.Columns["colEdit"].Index)
            {
                this.id = selectedId;
                this.cmbAccount.SelectedValue = Convert.ToInt32(row.Cells["colWorkshopAccountId"].Value);
                this.dtpTransactionDate.Value = Convert.ToDateTime(row.Cells["colTransactionDate"].Value);
                this.txtDescription.Text = Convert.ToString(row.Cells["colDescription"].Value);
                this.txtAmount.Value = Convert.ToDecimal(row.Cells["colAmount"].Value);
                this.btnSave.Text = "Update";
            }
            else if (e.ColumnIndex == this.dgv.Columns["colDelete"].Index)
            {
                if (!CommonTask.Question(selectedId, true)) return;
                this.DeleteTransaction(selectedId);
            }
        }

        private void DeleteTransaction(int selectedId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(this.objCore.getHBCConnectionString()))
                using (SqlCommand command = new SqlCommand("spDeleteWorkshopTransaction", connection))
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
                this.LoadTransactions();
                this.ClearForm();
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
            this.cmbAccount.SelectedIndex = this.cmbAccount.Items.Count > 0 ? 0 : -1;
            this.dtpTransactionDate.Value = DateTime.Now;
            this.txtDescription.Clear();
            this.txtAmount.Value = 0;
            this.btnSave.Text = "Save";
        }

        private void txtSearch_TextChanged(object sender, EventArgs e) { this.ApplyFilter(); }

        private void ApplyFilter()
        {
            string value = this.txtSearch.Text.Trim().Replace("'", "''");
            this.dsWorkshopTransaction1.WorkshopTransaction.DefaultView.RowFilter = value.Length == 0 ? string.Empty : "AccountName LIKE '%" + value + "%' OR Description LIKE '%" + value + "%'";
        }
    }
}
