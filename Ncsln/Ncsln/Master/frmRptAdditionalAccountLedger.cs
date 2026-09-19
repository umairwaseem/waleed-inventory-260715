using Ncsln.Classes;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Ncsln.Master
{
    public partial class frmRptAdditionalAccountLedger : Form
    {
        private readonly CoreClass objCore;

        public frmRptAdditionalAccountLedger()
        {
            InitializeComponent();
            this.objCore = new CoreClass();
        }

        private void frmRptAdditionalAccountLedger_Load(object sender, EventArgs e)
        {
            this.dtpFromDate.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            this.dtpToDate.Value = DateTime.Today;
            this.LoadAccounts();
        }

        private void LoadAccounts()
        {
            try
            {
                DataTable accounts = new DataTable();
                using (SqlConnection connection = new SqlConnection(this.objCore.getHBCConnectionString()))
                using (SqlDataAdapter adapter = new SqlDataAdapter("spAdditionalAccountList", connection))
                {
                    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    adapter.Fill(accounts);
                }
                this.cmbAccount.DataSource = accounts;
                this.cmbAccount.DisplayMember = "AccountName";
                this.cmbAccount.ValueMember = "Id";
                this.cmbAccount.SelectedIndex = -1;
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

        private void btnShow_Click(object sender, EventArgs e)
        {
            if (this.SelectedAccountId <= 0)
            {
                MessageBox.Show("Please select an account", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.cmbAccount.Focus();
                return;
            }
            if (this.dtpToDate.Value.Date < this.dtpFromDate.Value.Date)
            {
                MessageBox.Show("To Date must be on or after From Date", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.dtpToDate.Focus();
                return;
            }

            try
            {
                this.dsAdditionalAccountLedger1.AdditionalAccountLedger.Clear();
                using (SqlConnection connection = new SqlConnection(this.objCore.getHBCConnectionString()))
                using (SqlDataAdapter adapter = new SqlDataAdapter("spReportAdditionalAccountLedger", connection))
                {
                    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    adapter.SelectCommand.Parameters.Add("@AdditionalAccountId", SqlDbType.Int).Value = this.SelectedAccountId;
                    adapter.SelectCommand.Parameters.Add("@FromDate", SqlDbType.DateTime).Value = this.dtpFromDate.Value.Date;
                    adapter.SelectCommand.Parameters.Add("@ToDate", SqlDbType.DateTime).Value = this.dtpToDate.Value.Date;
                    adapter.Fill(this.dsAdditionalAccountLedger1.AdditionalAccountLedger);
                }
                this.dgv.DataSource = this.dsAdditionalAccountLedger1.AdditionalAccountLedger;
                this.dgv.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgv_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= this.dgv.Rows.Count) return;

            DataGridViewColumn sourceTypeColumn = null;
            foreach (DataGridViewColumn column in this.dgv.Columns)
            {
                if (string.Equals(column.DataPropertyName, "SourceType", StringComparison.OrdinalIgnoreCase))
                {
                    sourceTypeColumn = column;
                    break;
                }
            }

            if (sourceTypeColumn == null) return;

            object sourceType = this.dgv.Rows[e.RowIndex].Cells[sourceTypeColumn.Index].Value;
            bool opening = string.Equals(Convert.ToString(sourceType), "Opening Balance", StringComparison.OrdinalIgnoreCase);
            this.dgv.Rows[e.RowIndex].DefaultCellStyle.BackColor = opening ? Color.SeaGreen : Color.SlateGray;
            this.dgv.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.White;
        }
    }
}
