using Ncsln.Classes;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Ncsln.Master
{
    public partial class frmBalanceDetailTransaction : Form
    {
        private const string PermissionName = "Balance Detail Transaction";
        private readonly CoreClass objCore;
        private int id = -1;

        public frmBalanceDetailTransaction()
        {
            InitializeComponent();
            this.objCore = new CoreClass();
        }

        private void frmBalanceDetailTransaction_Load(object sender, EventArgs e)
        {
            if (!this.objCore.getUserRight(PermissionName, "CanView", this.objCore.getHBCConnectionString()))
            {
                MessageBox.Show("You have no right to View", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
                return;
            }
            this.LoadBalanceDetailCombo(-1);
            this.LoadTransactions();
        }

        private void LoadBalanceDetailCombo(int selectedBalanceDetailId)
        {
            try
            {
                DataTable details = new DataTable();
                using (SqlConnection connection = new SqlConnection(this.objCore.getHBCConnectionString()))
                using (SqlDataAdapter adapter = new SqlDataAdapter("spBalanceDetailList", connection))
                {
                    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    adapter.Fill(details);
                }
                DataRow addNew = details.NewRow();
                addNew["Id"] = -1;
                addNew["Title"] = "<<--Add New-->>";
                details.Rows.InsertAt(addNew, 0);
                this.cmbBalanceDetail.DataSource = details;
                this.cmbBalanceDetail.DisplayMember = "Title";
                this.cmbBalanceDetail.ValueMember = "Id";
                this.cmbBalanceDetail.SelectedIndex = selectedBalanceDetailId > 0 ? -1 : 0;
                if (selectedBalanceDetailId > 0) this.cmbBalanceDetail.SelectedValue = selectedBalanceDetailId;
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
                this.dsBalanceDetailTransaction1.BalanceDetailTransaction.Clear();
                using (SqlConnection connection = new SqlConnection(this.objCore.getHBCConnectionString()))
                using (SqlDataAdapter adapter = new SqlDataAdapter("spBalanceDetailTransactionList", connection))
                {
                    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    adapter.Fill(this.dsBalanceDetailTransaction1.BalanceDetailTransaction);
                }
                this.dgv.DataSource = this.dsBalanceDetailTransaction1.BalanceDetailTransaction;
                this.dgv.ClearSelection();
                this.ApplyFilter();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int SelectedBalanceDetailId
        {
            get
            {
                if (this.cmbBalanceDetail.SelectedValue == null || this.cmbBalanceDetail.SelectedValue is DataRowView) return -1;
                int value;
                return int.TryParse(this.cmbBalanceDetail.SelectedValue.ToString(), out value) ? value : -1;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int balanceDetailId = this.SelectedBalanceDetailId;
            if (balanceDetailId <= 0)
            {
                MessageBox.Show("Please select a balance detail", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.cmbBalanceDetail.Focus();
                return;
            }
            if (this.txtAmount.Value <= 0)
            {
                MessageBox.Show("Amount must be greater than zero", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtAmount.Focus();
                return;
            }
            if (!this.objCore.CheckRightServer(PermissionName, this.id)) return;
            if (!CommonTask.Question(this.id)) return;

            try
            {
                bool creating = this.id == -1;
                using (SqlConnection connection = new SqlConnection(this.objCore.getHBCConnectionString()))
                using (SqlCommand command = new SqlCommand(creating ? "spCreateBalanceDetailTransaction" : "spUpdateBalanceDetailTransaction", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    if (!creating) command.Parameters.Add("@Id", SqlDbType.Int).Value = this.id;
                    command.Parameters.Add("@BalanceDetailId", SqlDbType.Int).Value = balanceDetailId;
                    command.Parameters.Add("@TransactionDate", SqlDbType.DateTime).Value = this.dtpTransactionDate.Value;
                    command.Parameters.Add("@Description", SqlDbType.NVarChar, 500).Value = string.IsNullOrWhiteSpace(this.txtDescription.Text) ? (object)DBNull.Value : this.txtDescription.Text.Trim();
                    SqlParameter amount = command.Parameters.Add("@Amount", SqlDbType.Decimal);
                    amount.Precision = 18; amount.Scale = 2; amount.Value = this.txtAmount.Value;
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

        private void cmbBalanceDetail_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (this.SelectedBalanceDetailId != -1) return;
            using (frmBalanceDetail detailForm = new frmBalanceDetail())
            {
                if (detailForm.ShowDialog(this) == DialogResult.OK && detailForm.CreatedBalanceDetailId > 0)
                    this.LoadBalanceDetailCombo(detailForm.CreatedBalanceDetailId);
                else
                    this.LoadBalanceDetailCombo(-1);
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
                this.cmbBalanceDetail.SelectedValue = Convert.ToInt32(row.Cells["colBalanceDetailId"].Value);
                this.dtpTransactionDate.Value = Convert.ToDateTime(row.Cells["colTransactionDate"].Value);
                this.txtDescription.Text = Convert.ToString(row.Cells["colDescription"].Value);
                this.txtAmount.Value = Convert.ToDecimal(row.Cells["colAmount"].Value);
                this.btnSave.Text = "Update";
            }
            else if (e.ColumnIndex == this.dgv.Columns["colDelete"].Index)
            {
                if (!this.objCore.CheckRightServer(PermissionName, selectedId, true)) return;
                if (!CommonTask.Question(selectedId, true)) return;
                this.DeleteTransaction(selectedId);
            }
        }

        private void DeleteTransaction(int selectedId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(this.objCore.getHBCConnectionString()))
                using (SqlCommand command = new SqlCommand("spDeleteBalanceDetailTransaction", connection))
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
            this.cmbBalanceDetail.SelectedIndex = this.cmbBalanceDetail.Items.Count > 0 ? 0 : -1;
            this.dtpTransactionDate.Value = DateTime.Now;
            this.txtDescription.Clear();
            this.txtAmount.Value = 0;
            this.btnSave.Text = "Save";
        }

        private void txtSearch_TextChanged(object sender, EventArgs e) { this.ApplyFilter(); }

        private void ApplyFilter()
        {
            string value = this.txtSearch.Text.Trim().Replace("'", "''");
            this.dsBalanceDetailTransaction1.BalanceDetailTransaction.DefaultView.RowFilter = value.Length == 0 ? string.Empty : "Title LIKE '%" + value + "%' OR Description LIKE '%" + value + "%'";
        }
    }
}
