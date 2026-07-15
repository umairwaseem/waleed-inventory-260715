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
                this.dataGridView1.Rows[0].DefaultCellStyle.BackColor = Color.Green;
                this.dataGridView1.Rows[0].DefaultCellStyle.ForeColor = Color.White;

                for (int i = 1; i < this.dataGridView1.Rows.Count; i++)
                {
                    this.dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.SlateGray;
                    this.dataGridView1.Rows[i].DefaultCellStyle.ForeColor = Color.White;
                }
            }
            catch (Exception)
            {

            }
        }
    }
}
