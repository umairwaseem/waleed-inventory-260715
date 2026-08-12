using Ncsln.Classes;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Ncsln.Master
{
    public partial class frmRptWorkshopLedger : Form
    {
        private readonly CoreClass objCore;

        public frmRptWorkshopLedger()
        {
            InitializeComponent();
            this.objCore = new CoreClass();
        }

        private void frmRptWorkshopLedger_Load(object sender, EventArgs e)
        {
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
                this.dsWorkshopLedger1.WorkshopLedger.Clear();
                using (SqlConnection connection = new SqlConnection(this.objCore.getHBCConnectionString()))
                using (SqlDataAdapter adapter = new SqlDataAdapter("spReportWorkshopLedger", connection))
                {
                    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    adapter.SelectCommand.Parameters.Add("@FromDate", SqlDbType.DateTime).Value = this.dtpFromDate.Value.Date;
                    adapter.SelectCommand.Parameters.Add("@ToDate", SqlDbType.DateTime).Value = this.dtpToDate.Value.Date;
                    adapter.Fill(this.dsWorkshopLedger1.WorkshopLedger);
                }
                this.dgv.DataSource = this.dsWorkshopLedger1.WorkshopLedger;
                this.dgv.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgv_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            object rowType = this.dgv.Rows[e.RowIndex].Cells["colRowType"].Value;
            if (!string.Equals(Convert.ToString(rowType), "Total", StringComparison.OrdinalIgnoreCase)) return;
            this.dgv.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.SeaGreen;
            this.dgv.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.White;
            this.dgv.Rows[e.RowIndex].DefaultCellStyle.Font = new Font(this.dgv.Font, FontStyle.Bold);
        }
    }
}
