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
    public partial class frmRptVendorDetailReport : Form
    {
        CoreClass ObjCore;

        public frmRptVendorDetailReport()
        {
            InitializeComponent();
            this.ObjCore = new CoreClass();
        }

        private void frmRptVendorDetailReport_Load(object sender, EventArgs e)
        {
            this.ObjCore.fillComboBoxOptioni(this.cmbVendor, "Select VendorId, Name From Vendors where VendorId not in (1, 2)");
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataSet BranchesDs = this.ObjCore.getDataSet("Select * from Branches", this.ObjCore.getHBCConnectionString());

                DataSet purchases;
                DataTable dt = new DataTable("PurchaseDetail");
                dt.Columns.Add(new DataColumn("Branch_Id", Type.GetType("System.String")));
                dt.Columns.Add(new DataColumn("PurchaseNo", Type.GetType("System.String")));
                dt.Columns.Add(new DataColumn("PurchaseDate", Type.GetType("System.String")));
                dt.Columns.Add(new DataColumn("Name", Type.GetType("System.String")));
                dt.Columns.Add(new DataColumn("PhoneNo", Type.GetType("System.String")));
                dt.Columns.Add(new DataColumn("Description", Type.GetType("System.String")));
                dt.Columns.Add(new DataColumn("ExtraDetail", Type.GetType("System.String")));
                dt.Columns.Add(new DataColumn("ExtraAmount", Type.GetType("System.String")));
                dt.Columns.Add(new DataColumn("FinalTotal", Type.GetType("System.String")));
                dt.Columns.Add(new DataColumn("Code", Type.GetType("System.String")));
                dt.Columns.Add(new DataColumn("Title", Type.GetType("System.String")));
                dt.Columns.Add(new DataColumn("Qty", Type.GetType("System.String")));
                dt.Columns.Add(new DataColumn("UnitPrice", Type.GetType("System.String")));
                dt.Columns.Add(new DataColumn("Payment", Type.GetType("System.String")));
                dt.Columns.Add(new DataColumn("OverHead", Type.GetType("System.String")));
                for (int i = 0; i < BranchesDs.Tables[0].Rows.Count; i++)
                {
                    //string ConString = BranchesDs.Tables[0].Rows[i]["LocalConnectionString"].ToString();
                    string ConString = BranchesDs.Tables[0].Rows[i]["ConnectionString"].ToString();
                    if (ConString != "")
                    {
                        bool status = this.ObjCore.ConnectionCheck(@"" + ConString);
                        if (status)
                        {
                            string command = "";

                            if (this.chkDate.Checked)
                            {
                                command = "select PurchaseNo * ItemId + Qty as PurchaseNo, PurchaseDate, Name, PhoneNo, Description, ExtraDetail, ExtraAmount, FinalTotal, Code, Title, Qty, UnitPrice, ItemReturn, OverHead from vPurchaseDetail where VendorId = (Select VendorId from Vendors where Server_Id = " + this.cmbVendor.SelectedValue.ToString() + ") and PurchaseDate between '" + this.dtpFrom.Value.ToString("yyyy-MM-dd") + " 00:00:00.000' and '" + this.dtpTo.Value.ToString("yyyy-MM-dd") + " 23:59:59.999'";
                            }
                            else
                            {
                                command = "select PurchaseNo * ItemId + Qty as PurchaseNo, PurchaseDate, Name, PhoneNo, Description, ExtraDetail, ExtraAmount, FinalTotal, Code, Title, Qty, UnitPrice, ItemReturn, OverHead from vPurchaseDetail where VendorId = (Select VendorId from Vendors where Server_Id = " + this.cmbVendor.SelectedValue.ToString() + ")";
                                //command = "select PurchaseNo * ItemId + Qty as PurchaseNo, PurchaseDate, Name, PhoneNo, Description, ExtraDetail, ExtraAmount, FinalTotal, Code, Title, Qty, UnitPrice from vPurchaseDetail where VendorId not in (1005)";
                            }

                            purchases = this.ObjCore.getDataSet(command, ConString);
                            purchases.EnforceConstraints = false;

                            for (int j = 0; j < purchases.Tables[0].Rows.Count; j++)
                            {
                                DataRow dr = dt.NewRow();
                                dr["Branch_Id"] = BranchesDs.Tables[0].Rows[i]["Id"].ToString();
                                dr["PurchaseNo"] = purchases.Tables[0].Rows[j][0].ToString();
                                dr["PurchaseDate"] = purchases.Tables[0].Rows[j][1].ToString();
                                dr["Name"] = purchases.Tables[0].Rows[j][2].ToString();
                                dr["PhoneNo"] = purchases.Tables[0].Rows[j][3].ToString();
                                dr["Description"] = purchases.Tables[0].Rows[j][4].ToString();
                                dr["ExtraDetail"] = purchases.Tables[0].Rows[j][5].ToString();
                                dr["ExtraAmount"] = purchases.Tables[0].Rows[j][6].ToString();
                                dr["FinalTotal"] = purchases.Tables[0].Rows[j][7].ToString();
                                dr["Code"] = purchases.Tables[0].Rows[j][8].ToString();
                                dr["Title"] = purchases.Tables[0].Rows[j][9].ToString();
                                if (Convert.ToBoolean(purchases.Tables[0].Rows[j][12]))
                                {
                                    //dr["Qty"] = "-" + purchases.Tables[0].Rows[j][10].ToString();
                                    dr["Qty"] = purchases.Tables[0].Rows[j][10].ToString();
                                }
                                else
                                    dr["Qty"] = purchases.Tables[0].Rows[j][10].ToString();
                                dr["UnitPrice"] = purchases.Tables[0].Rows[j][11].ToString();
                                dr["Payment"] = "0";
                                dr["OverHead"] = purchases.Tables[0].Rows[j][13].ToString();
                                dt.Rows.InsertAt(dr, dt.Rows.Count);
                            }
                        }
                        else
                        {
                            DataRow dr = dt.NewRow();
                            dr["Branch_Id"] = BranchesDs.Tables[0].Rows[i]["Id"].ToString();
                            dr["PurchaseNo"] = "";
                            dr["PurchaseDate"] = "";
                            dr["Name"] = "";
                            dr["PhoneNo"] = "";
                            dr["Description"] = "Client not available";
                            dr["ExtraDetail"] = "";
                            dr["ExtraAmount"] = "0";
                            dr["FinalTotal"] = "0";
                            dr["Code"] = "";
                            dr["Title"] = "";
                            dr["Qty"] = "0";
                            dr["UnitPrice"] = "0";
                            dr["Payment"] = "0";
                            dr["OverHead"] = "0";
                            dt.Rows.InsertAt(dr, dt.Rows.Count);
                        }
                    }

                }

                //DataTable ddt = dt;

                this.SetData(dt);


                this.Cursor = Cursors.Default;

                this.dsVendorDetialReport1.Clear();
                this.daVendorDetailReport.SelectCommand.Connection.ConnectionString = this.ObjCore.getHBCConnectionString();
                this.daVendorDetailReport.Fill(this.dsVendorDetialReport1);

                docVendorDetail rpt = new docVendorDetail();
                rpt.SetDataSource(this.dsVendorDetialReport1);
                this.crv.ReportSource = rpt;

                //docCashBankingPayment rpt = new docCashBankingPayment();
                //rpt.SetDataSource(this.dsCashBanking1);
                //this.crv.ReportSource = rpt;
               

            }
            catch (Exception ex)
            {

            }
        }

        private void SetData(DataTable dt)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = this.ObjCore.getHBCConnectionString();
            con.Open();
            SqlTransaction tran = con.BeginTransaction();
            SqlCommand com = new SqlCommand("", con, tran);
            try
            {
                com.CommandType = CommandType.StoredProcedure;
                com.CommandText = "spVendorDetail";

                System.IO.StringWriter sw = new System.IO.StringWriter();
                dt.WriteXml(sw);
                string xmlData = sw.ToString();
                com.Parameters.AddWithValue("@Detail", xmlData);
                com.Parameters.AddWithValue("@From", this.dtpFrom.Value.ToShortDateString());
                com.Parameters.AddWithValue("@To", this.dtpTo.Value.ToShortDateString());
                com.Parameters.AddWithValue("@DateCheck", this.chkDate.Checked.ToString());
                com.Parameters.AddWithValue("@VendorId", this.cmbVendor.SelectedValue.ToString());
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

        private void crv_ClickPage(object sender, CrystalDecisions.Windows.Forms.PageMouseEventArgs e)
        {
            //if (e.ObjectInfo.Name == "Code1")
            //{
            //    MessageBox.Show(e.ObjectInfo.ObjectType.ToString());
            //}
        }

        private void chkDate_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkDate.Checked)
            {
                this.dtpFrom.Enabled = true;
                this.dtpTo.Enabled = true;
            }
            else
            {
                this.dtpFrom.Enabled = false;
                this.dtpTo.Enabled = false;
            }
        }
    }
}
