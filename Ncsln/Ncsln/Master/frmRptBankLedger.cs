using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ncsln.Master
{
    public partial class frmRptBankLedger : Form
    {
        private Classes.CoreClass ObjCore;

        public frmRptBankLedger()
        {
            InitializeComponent();
            this.ObjCore = new Classes.CoreClass();
        }

        private void frmRptBankLedger_Load(object sender, EventArgs e)
        {
            try
            {
                this.ObjCore.fillComboBoxWithReports2(this.cmbBank, "Select AccountNo, BankTitle from Banks", this.ObjCore.getHBCConnectionString());
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            try
            {
                this.dsBankLedger.Clear();
                this.daBankLedger.SelectCommand.Connection.ConnectionString = this.ObjCore.getHBCConnectionString();
                this.daBankLedger.SelectCommand.Parameters["@AccountNo"].Value = this.cmbBank.SelectedValue.ToString();
                this.daBankLedger.SelectCommand.Parameters["@MonthDate"].Value = this.dtpDateMonth.Value.ToString();
                this.daBankLedger.SelectCommand.Parameters["@ShowDebug"].Value = 0;
                this.daBankLedger.Fill(this.dsBankLedger);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void dataGridView1_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                for (int i = 0; i < this.dataGridView1.Rows.Count; i++)
                {
                    DataGridViewRow row = this.dataGridView1.Rows[i];
                    decimal receiveAmount = Convert.ToDecimal(row.Cells[this.receiveAmountDataGridViewTextBoxColumn.Index].Value ?? 0);
                    decimal paymentAmount = Convert.ToDecimal(row.Cells[this.paymentAmountDataGridViewTextBoxColumn.Index].Value ?? 0);

                    if (receiveAmount > 0)
                        row.DefaultCellStyle.BackColor = Color.Green;
                    else if (paymentAmount > 0)
                        row.DefaultCellStyle.BackColor = Color.Red;
                    else
                        row.DefaultCellStyle.BackColor = Color.SlateGray;

                    row.DefaultCellStyle.ForeColor = Color.White;
                }
            }
            catch (Exception)
            {

            }
        }
    }
}
