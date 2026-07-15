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
    public partial class frmRptFinalReport : Form
    {
        CoreClass ObjCore;

        public frmRptFinalReport()
        {
            InitializeComponent();
            this.ObjCore = new CoreClass();
        }

        private void frmRptFinalReport_Load(object sender, EventArgs e)
        {

        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataSet BranchesDs = this.ObjCore.getDataSet("Select * from Branches");

                DataSet purchases;
                DataTable dt = new DataTable("FinalReport");
                dt.Columns.Add(new DataColumn("Branch_Id", Type.GetType("System.String")));
                dt.Columns.Add(new DataColumn("GT", Type.GetType("System.String")));
                dt.Columns.Add(new DataColumn("VendorBalance", Type.GetType("System.String")));
                dt.Columns.Add(new DataColumn("BankBalance", Type.GetType("System.String")));
                dt.Columns.Add(new DataColumn("AdvancesBalance", Type.GetType("System.String")));
                dt.Columns.Add(new DataColumn("Detail", Type.GetType("System.String")));
                for (int i = 0; i < BranchesDs.Tables[0].Rows.Count; i++)
                {
                    //string ConString = BranchesDs.Tables[0].Rows[i]["LocalConnectionString"].ToString();
                    string ConString = BranchesDs.Tables[0].Rows[i]["ConnectionString"].ToString();
                    if (ConString != "")
                    {
                        bool status = this.ObjCore.ConnectionCheck(@"" + ConString);
                        if (status)
                        {
                            string command = "select dbo.funGetStockGT() as GT, dbo.funGetAllVendorBalance() as VendorBalance, dbo.funGetBankBalance() as Bank, dbo.funGetAllAdvance() as Advances";
                            purchases = this.ObjCore.getDataSet(command, ConString);
                            purchases.EnforceConstraints = false;

                            DataRow dr = dt.NewRow();
                            dr["Branch_Id"] = BranchesDs.Tables[0].Rows[i]["Id"].ToString();
                            dr["GT"] = purchases.Tables[0].Rows[0]["GT"].ToString();
                            dr["VendorBalance"] = purchases.Tables[0].Rows[0]["VendorBalance"].ToString();
                            dr["BankBalance"] = purchases.Tables[0].Rows[0]["Bank"].ToString();
                            dr["AdvancesBalance"] = purchases.Tables[0].Rows[0]["Advances"].ToString();
                            dr["Detail"] = "Successfully receive";
                            dt.Rows.InsertAt(dr, dt.Rows.Count);
                            
                        }
                        else
                        {
                            DataRow dr = dt.NewRow();
                            dr["Branch_Id"] = BranchesDs.Tables[0].Rows[i]["Id"].ToString();
                            dr["GT"] = "0";
                            dr["VendorBalance"] = "0";
                            dr["BankBalance"] = "0";
                            dr["AdvancesBalance"] = "0";
                            dr["Detail"] = "Branch not available";
                            dt.Rows.InsertAt(dr, dt.Rows.Count);
                        }
                    }

                }

                //DataTable HBC = this.ObjCore.getDataSet("select dbo.funGetStockValue()", this.ObjCore.getHBCConnectionString()).Tables[0];
                DataTable OtherALL = this.ObjCore.getDataSet("select dbo.funGetSStockGT() as HBC, dbo.funGetMRowGT() AS RowMatrial, dbo.funGetMFinishGoodsGT() as FinishGoods").Tables[0];

                //this.Cursor = Cursors.Default;

                //DataTable ddt = dt;

                this.SetData(dt);


                this.Cursor = Cursors.Default;

                this.dsFinalReport1.Clear();
                this.daFinalReport.SelectCommand.Connection.ConnectionString = this.ObjCore.getConnectionString();
                this.daFinalReport.Fill(this.dsFinalReport1);

                docFinalReport rpt = new docFinalReport();
                rpt.SetDataSource(this.dsFinalReport1);
                rpt.SetParameterValue("HBCGT", OtherALL.Rows[0][0].ToString());
                rpt.SetParameterValue("RowGT", OtherALL.Rows[0][1].ToString());
                rpt.SetParameterValue("FinishGoodGT", OtherALL.Rows[0][2].ToString());
                this.crv.ReportSource = rpt;

                //this.dsVendorDetialReport1.Clear();
                //this.daVendorDetailReport.SelectCommand.Connection.ConnectionString = this.ObjCore.getConnectionString();
                //this.daVendorDetailReport.Fill(this.dsVendorDetialReport1);

                //docVendorDetail rpt = new docVendorDetail();
                //rpt.SetDataSource(this.dsVendorDetialReport1);
                //this.crv.ReportSource = rpt;
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
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
                com.CommandText = "spFinalReport";

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
    }
}
