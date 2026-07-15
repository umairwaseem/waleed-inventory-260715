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
    public partial class frmRptBranchesPRReport : Form
    {
        CoreClass ObjCore;

        public frmRptBranchesPRReport()
        {
            InitializeComponent();
            this.ObjCore = new CoreClass();
        }

        private void frmRptBranchesPRReport_Load(object sender, EventArgs e)
        {
            this.ObjCore.fillComboBoxWithReports(this.cmbBranch, "Select Id, BranchName from Branches");

            this.crv.Visible = false;
            this.plGrid.Visible = true;
            this.plGrid.Dock = DockStyle.Fill;
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

                string commandbr = string.Empty;

                if (this.cmbBranch.SelectedValue.ToString() == "-1")
                    commandbr = "Select * from Branches";
                else
                    commandbr = "Select * from Branches where Id = " + this.cmbBranch.SelectedValue.ToString();

                DataSet BranchesDs = this.ObjCore.getDataSet(commandbr);

                DataSet purchases;
                DataTable dt = new DataTable("PRReport");
                dt.Columns.Add(new DataColumn("Branch_Id", Type.GetType("System.String")));
                dt.Columns.Add(new DataColumn("Date", Type.GetType("System.String")));
                dt.Columns.Add(new DataColumn("Detail", Type.GetType("System.String")));
                dt.Columns.Add(new DataColumn("Amount", Type.GetType("System.String")));
                dt.Columns.Add(new DataColumn("FinalAmount", Type.GetType("System.String")));
               
                for (int i = 0; i < BranchesDs.Tables[0].Rows.Count; i++)
                {
                    //string ConString = BranchesDs.Tables[0].Rows[i]["LocalConnectionString"].ToString();
                    string ConString = BranchesDs.Tables[0].Rows[i]["ConnectionString"].ToString();
                    if (ConString != "")
                    {
                        bool status = this.ObjCore.ConnectionCheck(@"" + ConString);
                        if (status)
                        {
                            foreach (DateTime day in EachDay(this.dtpFrom.Value, this.dtpTo.Value))
                            {
                                string command = "select dbo.funGetDailyPR('" + day.ToShortDateString() + "'), dbo.funGetDailyPRFinalCost('" + day.ToShortDateString() + "')";
                                purchases = this.ObjCore.getDataSet(command, ConString);
                                purchases.EnforceConstraints = false;

                                DataRow dr = dt.NewRow();
                                dr["Branch_Id"] = BranchesDs.Tables[0].Rows[i]["Id"].ToString();
                                dr["Date"] = day;
                                dr["Detail"] = "PR Invoice";
                                dr["Amount"] = purchases.Tables[0].Rows[0][0].ToString();
                                dr["FinalAmount"] = purchases.Tables[0].Rows[0][1].ToString();
                                dt.Rows.InsertAt(dr, dt.Rows.Count);
                            }
                        }
                        else
                        {
                            DataRow dr = dt.NewRow();
                            dr["Branch_Id"] = BranchesDs.Tables[0].Rows[i]["Id"].ToString();
                            dr["Date"] = "";
                            dr["Detail"] = "Client not available";
                            dr["Amount"] = 0;
                            dr["FinalAmount"] = 0;
                            dt.Rows.InsertAt(dr, dt.Rows.Count);
                        }
                    }

                }

                //DataTable ddt = dt;

                this.SetData(dt);
                
                this.Cursor = Cursors.Default;

                this.dsPRReport2.Clear();
                this.daPRReport.SelectCommand.Connection.ConnectionString = this.ObjCore.getConnectionString();
                this.daPRReport.Fill(this.dsPRReport2);

                if (this.dsPRReport2.vPRReport.Rows.Count > 0)
                {
                    this.btnPrint.Enabled = true;
                }




            }
            catch (Exception ex)
            {

            }
        }

        private void SetData(DataTable dt)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = this.ObjCore.getConnectionString();
            con.Open();
            SqlTransaction tran = con.BeginTransaction();
            SqlCommand com = new SqlCommand("", con, tran);
            try
            {
                com.CommandType = CommandType.StoredProcedure;
                com.CommandText = "spPRReport";



                System.IO.StringWriter sw = new System.IO.StringWriter();
                dt.WriteXml(sw);
                string xmlData = sw.ToString();
                com.Parameters.AddWithValue("@Detail", xmlData);
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

        public IEnumerable<DateTime> EachDay(DateTime from, DateTime thru)
        {
            for (var day = from.Date; day.Date <= thru.Date; day = day.AddDays(1))
                yield return day;
        }

        private void dgv_Paint(object sender, PaintEventArgs e)
        {
            try
            {

                decimal total = 0;
                decimal finalTotal = 0;

                for (int i = 0; i < this.dgv.Rows.Count; i++)
                {
                    //if (this.dgv["Id", i].Value.ToString() == "1")
                    //{
                    //    this.dgv.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
                    //}
                    //else if (this.dgv["Id", i].Value.ToString() == "2")
                    //{
                    //    this.dgv.Rows[i].DefaultCellStyle.BackColor = Color.Purple;
                    //    this.dgv.Rows[i].DefaultCellStyle.ForeColor = Color.White;
                    //}
                    //else if (this.dgv["Id", i].Value.ToString() == "3")
                    //{
                    //    this.dgv.Rows[i].DefaultCellStyle.BackColor = Color.Blue;
                    //    this.dgv.Rows[i].DefaultCellStyle.ForeColor = Color.White;
                    //}
                    //else if (this.dgv["Id", i].Value.ToString() == "4")
                    //{
                    //    this.dgv.Rows[i].DefaultCellStyle.BackColor = Color.SlateGray;
                    //    this.dgv.Rows[i].DefaultCellStyle.ForeColor = Color.White;
                    //}
                    //else
                    //{
                        this.dgv.Rows[i].DefaultCellStyle.BackColor = Color.Black;
                        this.dgv.Rows[i].DefaultCellStyle.ForeColor = Color.White;

                    //}

                    total += Convert.ToDecimal(this.dgv["Amount2", i].Value);
                    finalTotal += Convert.ToDecimal(this.dgv["FinalAmount", i].Value);
                }
                this.lbTotal.Text = "PR Total = " + total.ToString();
                this.lbFinalAmount.Text = "Total = " + finalTotal.ToString();
            }
            catch (Exception ex)
            {

            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                this.dgv.Visible = false;
                this.crv.Visible = true;
                this.crv.Dock = DockStyle.Fill;

                docRRReport rpt = new docRRReport();
                rpt.SetDataSource(this.dsPRReport2);
                this.crv.ReportSource = rpt;

            }
            catch (Exception ex)
            {

            }
        }
    }
}
