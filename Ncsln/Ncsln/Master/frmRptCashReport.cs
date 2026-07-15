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
    public partial class frmRptCashReport : Form
    {
        CoreClass ObjCore;
        bool firstTime = true;

        public frmRptCashReport()
        {
            InitializeComponent();
            this.ObjCore = new CoreClass();
        }

        private void frmRptBanking_Load(object sender, EventArgs e)
        {
            this.ObjCore.fillComboBoxWithReports(this.cmbBranch, "Select Id, BranchName from Branches");

            this.crv.Visible = false;
            this.dgv.Visible = true;
            this.dgv.Dock = DockStyle.Fill;

            this.setFonts();
            this.CmbFont.SelectedItem = this.ObjCore.GetSetting(1);
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.btnPrint.Enabled)
                {
                    this.crv.Visible = false;
                    this.dgv.Visible = true;
                    this.dgv.Dock = DockStyle.Fill;
                    this.btnPrint.Enabled = false;
                }

                this.Cursor = Cursors.WaitCursor;
                string branchCommand = string.Empty;

                if (this.cmbBranch.SelectedValue.ToString() == "-1")
                {
                    branchCommand = "Select * from Branches";
                }
                else
                {
                    branchCommand = "Select * from Branches where Id = " + this.cmbBranch.SelectedValue.ToString();
                }

                DataSet BranchesDs = this.ObjCore.getDataSet(branchCommand);

                DataSet purchases;
                DataTable dt = new DataTable("CashBankData");
                dt.Columns.Add(new DataColumn("Branch_Id", Type.GetType("System.String")));
                dt.Columns.Add(new DataColumn("PayBy", Type.GetType("System.String")));
                dt.Columns.Add(new DataColumn("ReceiveBy", Type.GetType("System.String")));
                dt.Columns.Add(new DataColumn("PaymentType", Type.GetType("System.String")));
                dt.Columns.Add(new DataColumn("BankName", Type.GetType("System.String")));
                dt.Columns.Add(new DataColumn("AccountNo", Type.GetType("System.String")));
                dt.Columns.Add(new DataColumn("Date", Type.GetType("System.String")));
                dt.Columns.Add(new DataColumn("Detail", Type.GetType("System.String")));
                dt.Columns.Add(new DataColumn("Bank", Type.GetType("System.String")));
                dt.Columns.Add(new DataColumn("Amount", Type.GetType("System.String")));
                for (int i = 0; i < BranchesDs.Tables[0].Rows.Count; i++)
                {
                    //string ConString = BranchesDs.Tables[0].Rows[i]["LocalConnectionString"].ToString();
                    string ConString = BranchesDs.Tables[0].Rows[i]["ConnectionString"].ToString();
                    if (ConString != "")
                    {
                        bool status = this.ObjCore.ConnectionCheck(@"" + ConString);
                        if (status)
                        {
                            string command = "select PayBy, ReceiveBy, PaymentType, BankName, AccountNo, Date, Detail, Amount from OwnerAccount where Date between '" + this.dtpFrom.Value.ToString("yyyy-MM-dd") + " 00:00:00.000' and '" + this.dtpTo.Value.ToString("yyyy-MM-dd") + " 23:59:59.999'";
                            purchases = this.ObjCore.getDataSet(command, ConString);
                            purchases.EnforceConstraints = false;

                            for (int j = 0; j < purchases.Tables[0].Rows.Count; j++)
                            {
                                DataRow dr = dt.NewRow();
                                dr["Branch_Id"] = BranchesDs.Tables[0].Rows[i]["Id"].ToString();
                                dr["PayBy"] = purchases.Tables[0].Rows[j][0].ToString();
                                dr["ReceiveBy"] = purchases.Tables[0].Rows[j][1].ToString();
                                dr["PaymentType"] = purchases.Tables[0].Rows[j][2].ToString();
                                dr["BankName"] = purchases.Tables[0].Rows[j][3].ToString();
                                dr["AccountNo"] = purchases.Tables[0].Rows[j][4].ToString();
                                dr["Date"] = purchases.Tables[0].Rows[j][5].ToString();
                                dr["Detail"] = purchases.Tables[0].Rows[j][6].ToString();
                                dr["Bank"] = (purchases.Tables[0].Rows[j][2].ToString() == "Bank") ? purchases.Tables[0].Rows[j][7].ToString() : "0";
                                dr["Amount"] = purchases.Tables[0].Rows[j][7].ToString();
                                dt.Rows.InsertAt(dr, dt.Rows.Count);
                            }
                        }
                        else
                        {
                            DataRow dr = dt.NewRow();
                            dr["Branch_Id"] = BranchesDs.Tables[0].Rows[i]["Id"].ToString();
                            dr["PayBy"] = "";
                            dr["ReceiveBy"] = "";
                            dr["PaymentType"] = "";
                            dr["BankName"] = "";
                            dr["AccountNo"] = "";
                            dr["Date"] = "";
                            dr["Detail"] = "Client not available";
                            dr["Bank"] = "0";
                            dr["Amount"] = "0";
                            dt.Rows.InsertAt(dr, dt.Rows.Count);
                        }
                    }

                }

                //DataTable ddt = dt;

                this.SetVendorData(dt);


                this.Cursor = Cursors.Default;

                this.FillDGV();

                this.GetTotal();

                if (this.firstTime)
                {
                    string culumns = this.ObjCore.GetSetting(6);
                    string[] col = culumns.Split(',');
                    this.firstTime = false;

                    int i = 0;
                    foreach (var item in col)
                    {
                                              
                        this.dgv.Columns[i].Width = Convert.ToInt32(item);
                        i++;
                    }
                }

                //docCashBankingPayment rpt = new docCashBankingPayment();
                //rpt.SetDataSource(this.dsCashBanking1);
                //this.crv.ReportSource = rpt;
                //if (this.dsCashBanking1.vCashBanking.Rows.Count > 0)
                //{
                //    this.btnPrint.Enabled = true;
                //}



            }
            catch (Exception ex)
            {
                
            }
            finally
            {
                this.dgv.Columns["detailDataGridViewTextBoxColumn"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                this.dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
                this.dgv.Columns["detailDataGridViewTextBoxColumn"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }

        private void FillDGV()
        {
            if (this.cmbBranch.SelectedValue.ToString() == "-1")
            {
                this.dsCashReport1.Clear();
                this.dsCashReport1.EnforceConstraints = false;
                this.daCashReport.SelectCommand.Connection.ConnectionString = this.ObjCore.getConnectionString();
                this.daCashReport.Fill(this.dsCashReport1);
            }
            else
            {
                this.dsCashReport1.Clear();
                this.dsCashReport1.EnforceConstraints = false;
                this.daCashReportSelected.SelectCommand.Connection.ConnectionString = this.ObjCore.getConnectionString();
                this.daCashReportSelected.SelectCommand.Parameters["@Id"].Value = this.cmbBranch.SelectedValue.ToString();
                this.daCashReportSelected.Fill(this.dsCashReport1);
            }
            this.dgv.ClearSelection();
            this.gridPaint();
            this.GetTotal();
        }

        private void GetTotal()
        {
            try
            {
                decimal receive = 0;
                decimal pay = 0;

                if (this.cmbBranch.SelectedValue.ToString() == "-1")
                {
                    for (int i = 1; i < this.dgv.Rows.Count; i++)
                    {
                        receive += Convert.ToDecimal(this.dgv["recamount", i].Value);
                        pay += Convert.ToDecimal(this.dgv["paymentDataGridViewTextBoxColumn", i].Value);
                    }
                } 
                else
                {
                    for (int i = 0; i < this.dgv.Rows.Count; i++)
                    {
                        receive += Convert.ToDecimal(this.dgv["recamount", i].Value);
                        pay += Convert.ToDecimal(this.dgv["paymentDataGridViewTextBoxColumn", i].Value);
                    }
                }

                this.txtTotalReceive.Text = receive.ToString();
                this.txtPay.Text = pay.ToString();
                this.txtBalance.Text = (receive - pay).ToString();

                

            }
            catch (Exception ex)
            {

            }
        }

        private void SetVendorData(DataTable dt)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = this.ObjCore.getConnectionString();
            con.Open();
            SqlTransaction tran = con.BeginTransaction();
            SqlCommand com = new SqlCommand("", con, tran);
            try
            {
                com.CommandType = CommandType.StoredProcedure;
                com.CommandText = "spCashReport";

                System.IO.StringWriter sw = new System.IO.StringWriter();
                dt.WriteXml(sw);
                string xmlData = sw.ToString();
                com.Parameters.AddWithValue("@Detail", xmlData);
                com.Parameters.AddWithValue("@From", this.dtpFrom.Value.ToShortDateString());
                com.Parameters.AddWithValue("@To", this.dtpTo.Value.ToShortDateString());
                com.ExecuteNonQuery();

                tran.Commit();
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

        private void dgv_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                for (int i = 0; i < this.dgv.Rows.Count; i++)
                {
                    if (this.dgv["Id", i].Value.ToString() == "1")
                    {
                        this.dgv.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
                    }
                    else if (this.dgv["Id", i].Value.ToString() == "2")
                    {
                        this.dgv.Rows[i].DefaultCellStyle.BackColor = Color.Purple;
                        this.dgv.Rows[i].DefaultCellStyle.ForeColor = Color.White;
                    }
                    else if (this.dgv["Id", i].Value.ToString() == "3")
                    {
                        this.dgv.Rows[i].DefaultCellStyle.BackColor = Color.Blue;
                        this.dgv.Rows[i].DefaultCellStyle.ForeColor = Color.White;
                    }
                    else if (this.dgv["Id", i].Value.ToString() == "4")
                    {
                        this.dgv.Rows[i].DefaultCellStyle.BackColor = Color.SlateGray;
                        this.dgv.Rows[i].DefaultCellStyle.ForeColor = Color.White;
                    }
                    else
                    {
                        //if (this.dgv["recamount", i].Value.ToString() != "0")
                        //{
                        //    this.dgv.Rows[i].DefaultCellStyle.BackColor = Color.GreenYellow;
                        //    this.dgv.Rows[i].DefaultCellStyle.ForeColor = Color.White;
                        //}
                        //else
                        //{
                        //    this.dgv.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                        //    this.dgv.Rows[i].DefaultCellStyle.ForeColor = Color.White;
                        //}
                    }
                }

                this.dgv.Rows[0].DefaultCellStyle.BackColor = Color.Red;
                this.dgv.Rows[0].DefaultCellStyle.ForeColor = Color.White;
            }
            catch (Exception ex)
            {

            }
        }

        private void gridPaint()
        {
            try
            {
                for (int i = 0; i < this.dgv.Rows.Count; i++)
                {
                    if (this.dgv["Id", i].Value.ToString() == "1")
                    {
                        this.dgv.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
                    }
                    else if (this.dgv["Id", i].Value.ToString() == "2")
                    {
                        this.dgv.Rows[i].DefaultCellStyle.BackColor = Color.Purple;
                        this.dgv.Rows[i].DefaultCellStyle.ForeColor = Color.White;
                    }
                    else if (this.dgv["Id", i].Value.ToString() == "3")
                    {
                        this.dgv.Rows[i].DefaultCellStyle.BackColor = Color.Blue;
                        this.dgv.Rows[i].DefaultCellStyle.ForeColor = Color.White;
                    }
                    else if (this.dgv["Id", i].Value.ToString() == "4")
                    {
                        this.dgv.Rows[i].DefaultCellStyle.BackColor = Color.SlateGray;
                        this.dgv.Rows[i].DefaultCellStyle.ForeColor = Color.White;
                    }
                    else
                    {
                        if (Convert.ToDecimal(this.dgv["recamount", i].Value) > 0)
                        {
                            this.dgv.Rows[i].DefaultCellStyle.BackColor = Color.Green;
                            this.dgv.Rows[i].DefaultCellStyle.ForeColor = Color.White;
                        }
                        else
                        {
                            this.dgv.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                            this.dgv.Rows[i].DefaultCellStyle.ForeColor = Color.White;
                        }
                    }
                }

                this.dgv.Rows[0].DefaultCellStyle.BackColor = Color.Green;
                this.dgv.Rows[0].DefaultCellStyle.ForeColor = Color.White;
            }
            catch (Exception ex)
            {

            }
        }

        

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                //this.dgv.Visible = false;
                //this.crv.Visible = true;
                //this.crv.Dock = DockStyle.Fill;

                //docCashBankingPayment rpt = new docCashBankingPayment();
                //rpt.SetDataSource(this.dsCashBanking1);
                //this.crv.ReportSource = rpt;

            }
            catch (Exception ex)
            {

            }
        }

        private void CmbFont_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void CmbFont_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //try
            //{
            //    string command = "Update Settings set Value = '" + this.CmbFont.SelectedItem + "' where Id = 1";
            //    this.ObjCore.executeQuery(command, this.ObjCore.getHBCConnectionString());
            //    this.setFonts();
            //}
            //catch (Exception ex)
            //{

            //}
        }

        private void setFonts()
        {
            this.dgv.DefaultCellStyle.Font = new Font("Arial", Convert.ToInt32(this.ObjCore.GetSetting(1)));
            this.dgv.AlternatingRowsDefaultCellStyle.Font = new Font("Arial", Convert.ToInt32(this.ObjCore.GetSetting(1)));

            //if (this.firstTime)
            //{
            //    string culumns = this.ObjCore.GetSetting(5);
            //    string[] col = culumns.Split(',');

            //    int i = 0;
            //    foreach (var item in col)
            //    {
            //        this.dgv.Columns[i].Width = Convert.ToInt32(item);
            //        i++;
            //    }
            //    this.firstTime = false;
            //}
        }

        private void label3_Click(object sender, EventArgs e)
        {
            
                       
        }

        private void dgv_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            try
            {


                if (!this.firstTime)
                {
                    string culumsWidths = string.Empty;
                    for (int i = 0; i < this.dgv.Columns.Count; i++)
                    {
                        culumsWidths += this.dgv.Columns[i].Width.ToString();
                        if (i + 1 != this.dgv.Columns.Count)
                            culumsWidths += ",";

                    }

                    string command = "Update Settings set Value = '" + culumsWidths + "' where Id = 6";
                    this.ObjCore.executeQuery(command, this.ObjCore.getHBCConnectionString());
                }

            }
            catch (Exception ex)
            {

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //string key = this.txtSearch.Text.Trim();
                //this.vCashBankingBindingSource.Filter = "AccountNo like '%" + key + "%' or Detail like '%" + key + "%'";

                //this.gridPaint();
            }
            catch (Exception ex)
            {

            }
        }

    }
}
