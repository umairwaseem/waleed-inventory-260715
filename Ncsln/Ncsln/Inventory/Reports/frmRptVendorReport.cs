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

namespace Ncsln.Inventory.Reports
{
    public partial class frmRptVendorReport : Form
    {
        CoreClass ObjCore;

        public frmRptVendorReport()
        {
            InitializeComponent();
            this.ObjCore = new CoreClass();
        }

        private void frmRptVendorReport_Load(object sender, EventArgs e)
        {
            this.ObjCore.fillComboBoxOptioni(this.cmbVendor, "Select VendorId, Name From Vendors");
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataSet BranchesDs = this.ObjCore.getDataSet("Select * from Branches");

                DataSet purchases;
                DataTable dt = new DataTable("VendersData");
                dt.Columns.Add(new DataColumn("Vendor_Id", Type.GetType("System.String")));
                dt.Columns.Add(new DataColumn("Branch_Id", Type.GetType("System.String")));
                dt.Columns.Add(new DataColumn("TranNo", Type.GetType("System.String")));
                dt.Columns.Add(new DataColumn("TranDate", Type.GetType("System.String")));
                dt.Columns.Add(new DataColumn("TranType", Type.GetType("System.String")));
                dt.Columns.Add(new DataColumn("Purchase", Type.GetType("System.String")));
                dt.Columns.Add(new DataColumn("Payment", Type.GetType("System.String")));
                for (int i = 0; i < BranchesDs.Tables[0].Rows.Count; i++)
                {
                    //string ConString = BranchesDs.Tables[0].Rows[i]["LocalConnectionString"].ToString();
                    string ConString = BranchesDs.Tables[0].Rows[i]["ConnectionString"].ToString();
                    if (ConString != "")
                    {
                        bool status = this.ObjCore.ConnectionCheck(@"" + ConString);
                        if (status)
                        {
                            //purchases = this.ObjCore.getDataSet("Select PurchaseNo, VendorId, PurchaseDate, FinalTotal - dbo.funGetPurchaseOverhead(Id) from Purchase where VendorId = (Select VendorId from Vendors where Server_Id = " + this.cmbVendor.SelectedValue.ToString() + ")", ConString);
                            string command = "Select PurchaseNo, (Select Server_Id from Vendors where Vendors.VendorId = Purchase.VendorId) as VendorId, PurchaseDate, FinalTotal - dbo.funGetPurchaseOverhead(Id) from Purchase where PurchaseDate between '" + this.dtpFrom.Value.ToString("yyyy-MM-dd") + " 00:00:00.000' and '" + this.dtpTo.Value.ToString("yyyy-MM-dd") + " 23:59:59.999'";
                            purchases = this.ObjCore.getDataSet(command, ConString);
                            purchases.EnforceConstraints = false;

                            for (int j = 0; j < purchases.Tables[0].Rows.Count; j++)
                            {
                                DataRow dr = dt.NewRow();
                                dr["Vendor_Id"] = purchases.Tables[0].Rows[j][1].ToString();
                                dr["Branch_Id"] = BranchesDs.Tables[0].Rows[i]["Id"].ToString();
                                dr["TranNo"] = purchases.Tables[0].Rows[j][0].ToString();
                                dr["TranDate"] = purchases.Tables[0].Rows[j][2].ToString();
                                dr["TranType"] = "Purchases";
                                dr["Purchase"] = purchases.Tables[0].Rows[j][3].ToString();
                                dr["Payment"] = "0";
                                dt.Rows.InsertAt(dr, dt.Rows.Count);
                            }
                        }
                        else
                        {
                            DataRow dr = dt.NewRow();
                            dr["Vendor_Id"] = "0";
                            dr["Branch_Id"] = BranchesDs.Tables[0].Rows[i]["Id"].ToString();
                            dr["TranNo"] = "0";
                            dr["TranDate"] = DateTime.Now.ToShortDateString();
                            dr["TranType"] = "Client not available";
                            dr["Purchase"] = "0";
                            dr["Payment"] = "0";
                            dt.Rows.InsertAt(dr, dt.Rows.Count);
                        }
                    }

                }

                //DataTable ddt = dt;

                this.SetVendorData(dt);


                this.Cursor = Cursors.Default;

                this.dsVendorReport1.Clear();
                this.daVendorReport.SelectCommand.Connection.ConnectionString = this.ObjCore.getConnectionString();
                this.daVendorReport.Fill(this.dsVendorReport1);

                docVendorReport rpt = new docVendorReport();
                rpt.SetDataSource(this.dsVendorReport1);
                this.crv.ReportSource = rpt;
                
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
                com.CommandText = "spVendorReport";

                com.Parameters.AddWithValue("@From", this.dtpFrom.Value.ToShortDateString());
                com.Parameters.AddWithValue("@To", this.dtpTo.Value.ToShortDateString());

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

        private void crv_ClickPage(object sender, CrystalDecisions.Windows.Forms.PageMouseEventArgs e)
        {
            if (e.ObjectInfo.Name == "TranNo1")
            {
                string[] TranNo = e.ObjectInfo.Text.Split('-');

                string BranchId = TranNo[0].ToString();
                string VoucherNo = TranNo[1].ToString();

                string ConString = this.GetBranchConString(BranchId);

                DataSet ds = this.ObjCore.getDataSet("select Code as Model, Title, Qty, UnitPrice, TotalPrice from vPurchaseDetail where PurchaseNo = '" + VoucherNo + "' ", ConString);

                frmRptVendorPurchaseDetail obj = new frmRptVendorPurchaseDetail();
                obj.ds = ds;
                obj.ShowDialog();
                
            }
        }

        private string GetBranchConString(string id)
        {
            DataTable dt = this.ObjCore.getDataSet("Select ConnectionString from Branches where Id = " + id).Tables[0];
            return dt.Rows[0][0].ToString();
        }
    }
}
