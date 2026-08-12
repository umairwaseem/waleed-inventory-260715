using Ncsln.Classes;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Ncsln.Master
{
    public partial class frmRptBalanceDetailSummary : Form
    {
        private const string PermissionName = "Balance Detail Summary";
        private readonly CoreClass objCore;

        public frmRptBalanceDetailSummary()
        {
            InitializeComponent();
            this.objCore = new CoreClass();
        }

        private void frmRptBalanceDetailSummary_Load(object sender, EventArgs e)
        {
            if (!this.objCore.getUserRight(PermissionName, "CanView", this.objCore.getHBCConnectionString()))
            {
                MessageBox.Show("You have no right to View", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
                return;
            }
            this.dtpFromDate.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            this.dtpToDate.Value = DateTime.Today;
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            if (this.dtpToDate.Value.Date < this.dtpFromDate.Value.Date)
            {
                MessageBox.Show("To Date must be on or after From Date", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.dtpToDate.Focus();
                return;
            }

            try
            {
                this.dsBalanceDetailSummary1.BalanceDetailSummary.Clear();
                using (SqlConnection connection = new SqlConnection(this.objCore.getHBCConnectionString()))
                using (SqlDataAdapter adapter = new SqlDataAdapter("spReportBalanceDetailSummary", connection))
                {
                    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    adapter.SelectCommand.Parameters.Add("@FromDate", SqlDbType.DateTime).Value = this.dtpFromDate.Value.Date;
                    adapter.SelectCommand.Parameters.Add("@ToDate", SqlDbType.DateTime).Value = this.dtpToDate.Value.Date;
                    adapter.Fill(this.dsBalanceDetailSummary1.BalanceDetailSummary);
                }
                this.dgv.DataSource = this.dsBalanceDetailSummary1.BalanceDetailSummary;
                this.ShowAllRows();
                this.dgv.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            this.ShowAllRows();
        }

        private void ShowAllRows()
        {
            this.dsBalanceDetailSummary1.BalanceDetailSummary.DefaultView.RowFilter = string.Empty;
            this.lblFilter.Text = "Showing all rows";
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != this.dgv.Columns["colAction"].Index) return;

            DataGridViewRow row = this.dgv.Rows[e.RowIndex];
            string rowType = Convert.ToString(row.Cells["colRowType"].Value);
            if (string.Equals(rowType, "Detail", StringComparison.OrdinalIgnoreCase))
            {
                object value = row.Cells["colBalanceDetailId"].Value;
                if (value == null || value == DBNull.Value) return;
                int balanceDetailId = Convert.ToInt32(value);
                string title = Convert.ToString(row.Cells["colTitle"].Value).Replace("'", "''");
                this.dsBalanceDetailSummary1.BalanceDetailSummary.DefaultView.RowFilter = "BalanceDetailId = " + balanceDetailId;
                this.lblFilter.Text = "Filtered: " + title;
            }
            else if (string.Equals(rowType, "Summary", StringComparison.OrdinalIgnoreCase))
            {
                string title = Convert.ToString(row.Cells["colTitle"].Value).Replace("'", "''");
                this.dsBalanceDetailSummary1.BalanceDetailSummary.DefaultView.RowFilter = "RowType = 'Summary' AND Title = '" + title + "'";
                this.lblFilter.Text = "Filtered: " + title;
            }
        }

        private void dgv_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            string rowType = Convert.ToString(this.dgv.Rows[e.RowIndex].Cells["colRowType"].Value);
            if (string.Equals(rowType, "Summary", StringComparison.OrdinalIgnoreCase))
            {
                this.dgv.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.SeaGreen;
                this.dgv.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.White;
                this.dgv.Rows[e.RowIndex].DefaultCellStyle.Font = new Font(this.dgv.Font, FontStyle.Bold);
            }
            else if (string.Equals(rowType, "Blank", StringComparison.OrdinalIgnoreCase))
            {
                this.dgv.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.WhiteSmoke;
                this.dgv.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.WhiteSmoke;
                this.dgv.Rows[e.RowIndex].Height = 12;
            }
            else
            {
                this.dgv.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.SlateGray;
                this.dgv.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.White;
            }
        }
    }
}
