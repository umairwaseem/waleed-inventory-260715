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

namespace Ncsln.Master
{
    public partial class frmPartnerProfit : Form
    {
        CoreClass ObjCore;
        public int Id = -1;

        public frmPartnerProfit()
        {
            InitializeComponent();
            this.ObjCore = new CoreClass();
        }

        private void frmPartnerProfit_Load(object sender, EventArgs e)
        {
            try
            {
                this.ObjCore.fillGridComboBoxWithAddNewOption((DataGridViewComboBoxColumn)this.dgv.Columns["partner"], "Select Id, Name from Partner", this.ObjCore.getHBCConnectionString());
                
                if (this.Id == -1)
                {
                    this.txtAmount.Value = this.getProfitAmount();

                    DataTable dt = this.ObjCore.getDataSet("Select * from Partner where Status = 1 order by Rank asc", this.ObjCore.getHBCConnectionString()).Tables[0];

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        DataRow dr = this.dsPartnerProfitDetail1.PartnerProfitDetail.NewRow();
                        dr["Partner_Id"] = dt.Rows[i]["Id"].ToString();
                        dr["Percentage"] = dt.Rows[i]["Percentage"].ToString();
                        dr["PercentAmount"] = "0";
                        this.dsPartnerProfitDetail1.PartnerProfitDetail.Rows.InsertAt(dr, this.dsPartnerProfitDetail1.PartnerProfitDetail.Rows.Count);
                    }

                    this.Calculate();
                }
                else
                {
                    //this.dtp.Enabled = false;
                    DataTable dt = this.ObjCore.getDataSet("Select * From PartnerProfit where Id = " +  this.Id.ToString(), this.ObjCore.getHBCConnectionString()).Tables[0];

                    this.dtp.Value = Convert.ToDateTime(dt.Rows[0]["Profitdate"]);
                    this.txtAmount.Value = Convert.ToDecimal(dt.Rows[0]["Amount"]);
                    this.txtDescription.Text = dt.Rows[0]["Description"].ToString();
                    this.txtTotalPay.Text = dt.Rows[0]["TotalPay"].ToString();
                    this.txtRemaining.Text = dt.Rows[0]["Remaining"].ToString();

                    this.dsPartnerProfitDetail1.Clear();
                    this.daPartnerProfitDetail.SelectCommand.Connection.ConnectionString = this.ObjCore.getHBCConnectionString();
                    this.daPartnerProfitDetail.SelectCommand.Parameters["@Id"].Value = this.Id.ToString();
                    this.daPartnerProfitDetail.Fill(this.dsPartnerProfitDetail1);

                    this.btnSave.Text = "Update";
                }

                this.setFonts();
                this.CmbFont.SelectedItem = this.ObjCore.GetSetting(1);
            }
            catch (Exception ex)
            {

            }
        }

        private void setFonts()
        {
            this.dgv.DefaultCellStyle.Font = new Font("Arial", Convert.ToInt32(this.ObjCore.GetSetting(1)));
            this.dgv.AlternatingRowsDefaultCellStyle.Font = new Font("Arial", Convert.ToInt32(this.ObjCore.GetSetting(1)));
        }

        private decimal getProfitAmount()
        {
            try
            {
                DataTable dt = this.ObjCore.getDataSet("select dbo.funGetRemainingN('" + this.dtp.Value.ToString() + "')", this.ObjCore.getHBCConnectionString()).Tables[0];

                decimal profit = Convert.ToDecimal(dt.Rows[0][0]);

                return profit;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        private void dgv_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    if (e.ColumnIndex == this.dgv.Columns["percentage"].Index)
                    {
                        

                        this.Calculate();
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void Calculate()
        {
            try
            {
                decimal amount = this.txtAmount.Value;
                for (int i = 0; i < this.dgv.Rows.Count; i++)
                {
                    if (this.txtAmount.Value > 0)
                    {

                        decimal per = Convert.ToDecimal(this.dgv["percentage", i].Value) / 100;
                        decimal cal = amount * per;
                        this.dgv["percentAmount", i].Value = Convert.ToInt32(cal).ToString();
                        //amount -= cal;
                    }
                }

                decimal total = 0;
                for (int i = 0; i < this.dgv.Rows.Count; i++)
                {
                    total += Convert.ToDecimal(this.dgv["percentAmount", i].Value);
                }

                this.txtTotalPay.Text = Convert.ToInt32(total).ToString();
                this.txtRemaining.Text = Convert.ToInt32(this.txtAmount.Value - total).ToString();

                this.txtTotalPay.Text = this.txtAmount.Value.ToString();
            }
            catch (Exception ex)
            {

            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                this.SaveUpdate();
            }
            catch (Exception ex)
            {

            }
        }

        private void SaveUpdate()
        {
            if (!CommonTask.Question(this.Id)) return;

            SqlConnection con = new SqlConnection();
            con.ConnectionString = this.ObjCore.getHBCConnectionString();
            con.Open();
            SqlTransaction tran = con.BeginTransaction();
            SqlCommand com = new SqlCommand("", con, tran);
            string command = string.Empty;
            string vendorAccountId = string.Empty;
            bool success = false;
            try
            {
                if (this.Id == -1)
                {
                    com.CommandType = CommandType.StoredProcedure;
                    com.CommandText = "spCreatePartnerProfit";

                    com.Parameters.AddWithValue("@ProfitDate", this.dtp.Value.ToString());
                    com.Parameters.AddWithValue("@Amount", this.txtAmount.Value.ToString());
                    com.Parameters.AddWithValue("@Remaining", this.txtRemaining.Text.Trim());
                    com.Parameters.AddWithValue("@Description", this.txtDescription.Text.Trim());
                    com.Parameters.AddWithValue("@TotalPay", this.txtTotalPay.Text.Trim());

                    DataTable dt = new DataTable("Detail");
                    dt.Columns.Add(new DataColumn("Partner_Id", Type.GetType("System.Decimal")));
                    dt.Columns.Add(new DataColumn("Percentage", Type.GetType("System.Decimal")));
                    dt.Columns.Add(new DataColumn("PercentAmount", Type.GetType("System.Decimal")));
                    for (int i = 0; i < this.dgv.Rows.Count; i++)
                    {
                        DataRow newRow = dt.NewRow();
                        newRow["Partner_Id"] = this.dgv["partner", i].Value;
                        newRow["Percentage"] = this.dgv["percentage", i].Value;
                        newRow["PercentAmount"] = this.dgv["percentAmount", i].Value;
                        dt.Rows.InsertAt(newRow, dt.Rows.Count);
                    }

                    System.IO.StringWriter sw = new System.IO.StringWriter();
                    dt.WriteXml(sw);
                    string xmlData = sw.ToString();

                    com.Parameters.AddWithValue("@Detail", xmlData);

                    com.Parameters.Add(new SqlParameter("@Id", SqlDbType.Decimal, 18, ParameterDirection.Output, false, 18, 0, "SaleId", DataRowVersion.Default, null));
                    com.Parameters.Add(new SqlParameter("@Success", SqlDbType.Bit, 1, ParameterDirection.Output, false, 1, 0, "Success", DataRowVersion.Default, null));
                    com.Parameters.Add(new SqlParameter("@Message", SqlDbType.NVarChar, 200, ParameterDirection.Output, false, 200, 0, "Message", DataRowVersion.Default, null));
                    com.UpdatedRowSource = UpdateRowSource.OutputParameters;
                    com.ExecuteNonQuery();

                    success = Convert.ToBoolean(com.Parameters["@Success"].Value);
                    string message = com.Parameters["@Message"].Value.ToString();
                    string itemIdStock = string.Empty;
                    if (success)
                        this.Id = Convert.ToInt32(com.Parameters["@Id"].Value);
                    tran.Commit();
                    if (success)
                    {
                        this.btnSave.Text = "Update";
                    }
                    else
                    {
                        //this.dgDetail.ClearSelection();
                        MessageBox.Show(message, "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
                else
                {
                    com.CommandType = CommandType.StoredProcedure;
                    com.CommandText = "spUpdatePartnerProfit";

                    com.Parameters.AddWithValue("@Id", this.Id);
                    com.Parameters.AddWithValue("@ProfitDate", this.dtp.Value.ToString());
                    com.Parameters.AddWithValue("@Amount", this.txtAmount.Value.ToString());
                    com.Parameters.AddWithValue("@Remaining", this.txtRemaining.Text.Trim());
                    com.Parameters.AddWithValue("@Description", this.txtDescription.Text.Trim());
                    com.Parameters.AddWithValue("@TotalPay", this.txtTotalPay.Text.Trim());

                    DataTable dt = new DataTable("Detail");
                    dt.Columns.Add(new DataColumn("Partner_Id", Type.GetType("System.Decimal")));
                    dt.Columns.Add(new DataColumn("Percentage", Type.GetType("System.Decimal")));
                    dt.Columns.Add(new DataColumn("PercentAmount", Type.GetType("System.Decimal")));
                    for (int i = 0; i < this.dgv.Rows.Count; i++)
                    {
                        DataRow newRow = dt.NewRow();
                        newRow["Partner_Id"] = this.dgv["partner", i].Value;
                        newRow["Percentage"] = this.dgv["percentage", i].Value;
                        newRow["PercentAmount"] = this.dgv["percentAmount", i].Value;
                        dt.Rows.InsertAt(newRow, dt.Rows.Count);
                    }

                    System.IO.StringWriter sw = new System.IO.StringWriter();
                    dt.WriteXml(sw);
                    string xmlData = sw.ToString();

                    com.Parameters.AddWithValue("@Detail", xmlData);

                    com.Parameters.Add(new SqlParameter("@Success", SqlDbType.Bit, 1, ParameterDirection.Output, false, 1, 0, "Success", DataRowVersion.Default, null));
                    com.Parameters.Add(new SqlParameter("@Message", SqlDbType.NVarChar, 200, ParameterDirection.Output, false, 200, 0, "Message", DataRowVersion.Default, null));
                    com.UpdatedRowSource = UpdateRowSource.OutputParameters;
                    com.ExecuteNonQuery();

                    success = Convert.ToBoolean(com.Parameters["@Success"].Value);
                    string message = com.Parameters["@Message"].Value.ToString();
                    string itemIdStock = string.Empty;

                    tran.Commit();
                    if (!success)
                    {
                        //this.dgDetail.ClearSelection();
                        MessageBox.Show(message, "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
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
            }
        }

        private void txtAmount_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.Calculate();
            }
            catch (Exception ex)
            {

            }
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            try
            {
                //if (this.Id != -1)
                //{
                    frmExpensePayment obj = new frmExpensePayment();
                    obj.Amount = Convert.ToDecimal(this.txtTotalPay.Text);
                    obj.Invoice_Id = this.Id;
                    obj.TypeId = 2;
                    obj.StartPosition = FormStartPosition.CenterScreen;
                    obj.ShowDialog();
                //}
            }
            catch (Exception ex)
            {

            }
        }

        private void dtp_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.txtAmount.Value = this.getProfitAmount();
                if (this.Id == -1)
                {
                    DataTable dt = this.ObjCore.getDataSet("Select * from Partner where Status = 1 order by Rank asc", this.ObjCore.getHBCConnectionString()).Tables[0];

                    this.dsPartnerProfitDetail1.Clear();

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        DataRow dr = this.dsPartnerProfitDetail1.PartnerProfitDetail.NewRow();
                        dr["Partner_Id"] = dt.Rows[i]["Id"].ToString();
                        dr["Percentage"] = dt.Rows[i]["Percentage"].ToString();
                        dr["PercentAmount"] = "0";
                        this.dsPartnerProfitDetail1.PartnerProfitDetail.Rows.InsertAt(dr, this.dsPartnerProfitDetail1.PartnerProfitDetail.Rows.Count);
                    }

                    this.Calculate();
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void CmbFont_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                string command = "Update Settings set Value = '" + this.CmbFont.SelectedItem + "' where Id = 1";
                this.ObjCore.executeQuery(command, this.ObjCore.getHBCConnectionString());
                this.setFonts();
            }
            catch (Exception ex)
            {

            }
        }
    }
}
