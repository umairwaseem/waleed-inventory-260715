using Ncsln.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Ncsln.Inventory
{
    public partial class frmVendorReport : Form
    {
        CoreClass ObjCore;

        public frmVendorReport()
        {
            InitializeComponent();
            this.ObjCore = new CoreClass();
        }

        private void frmVendorReport_Load(object sender, EventArgs e)
        {
            this.ObjCore.fillComboBoxOptioni(this.cmbVendor, "Select VendorId, Name From Vendors where VendorId not in (1)", this.ObjCore.getHBCConnectionString());            
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                string branchQuery = "Select * from Branches";

                DataSet BranchesDs = this.ObjCore.getDataSet(branchQuery, this.ObjCore.getHBCConnectionString());

                DataSet Vendor;
                DataTable dt = new DataTable("VendersData");
                dt.Columns.Add(new DataColumn("Name", Type.GetType("System.String")));
                dt.Columns.Add(new DataColumn("Balance", Type.GetType("System.String")));
                for (int i = 0; i < BranchesDs.Tables[0].Rows.Count; i++)
                {
                    //string ConString = BranchesDs.Tables[0].Rows[i]["LocalConnectionString"].ToString();
                    string ConString = BranchesDs.Tables[0].Rows[i]["ConnectionString"].ToString();
                    if (ConString != "")
                    {
                        bool status = this.ObjCore.ConnectionCheck(@"" + ConString);
                        if (status)
                        {
                            Vendor = this.ObjCore.getDataSet("Select isnull(dbo.funGetVendorCurrentStockBalance(" + this.cmbVendor.SelectedValue.ToString() + "), 0)", ConString);
                            Vendor.EnforceConstraints = false;

                            DataRow dr = dt.NewRow();
                            dr["Name"] = BranchesDs.Tables[0].Rows[i]["BranchName"].ToString();
                            dr["Balance"] = Vendor.Tables[0].Rows[0][0].ToString();
                            dt.Rows.InsertAt(dr, dt.Rows.Count);
                        }
                        else
                        {
                            DataRow dr = dt.NewRow();
                            dr["Name"] = BranchesDs.Tables[0].Rows[i]["BranchName"].ToString() + " - Not Available";
                            dr["Balance"] = "0";
                            dt.Rows.InsertAt(dr, dt.Rows.Count);
                        }
                    }

                }

                //DataTable ddt = dt;
                this.Cursor = Cursors.Default;
                this.dgv.DataSource = dt;

                decimal TotalPurchases = 0;

                for (int i = 0; i < this.dgv.Rows.Count; i++)
                {
                    TotalPurchases += Convert.ToDecimal(this.dgv[1, i].Value);
                }

                decimal TotalPayment = Convert.ToDecimal(this.ObjCore.getDataSet("Select dbo.funGetVendorTotalPayment(" + this.cmbVendor.SelectedValue.ToString() + ")").Tables[0].Rows[0][0]);

                this.txtTotalPurchases.Text = TotalPurchases.ToString();
                this.txtTotalPayment.Text = TotalPayment.ToString();
                this.txtBalance.Text = (TotalPurchases - TotalPayment).ToString();
            }
            catch (Exception ex)
            {

            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cmbVendor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            
            
        }
    }
}
