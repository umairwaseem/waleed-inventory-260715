using Ncsln.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Ncsln.Master
{
    public partial class frmBranchItems : Form
    {
        CoreClass ObjCore;

        public frmBranchItems()
        {
            InitializeComponent();
            this.ObjCore = new CoreClass();
        }

        private void frmVendorReport_Load(object sender, EventArgs e)
        {
            this.ObjCore.fillComboBoxOptioni(this.cmbVendor, "Select Id, Code + ' ' + Name + ' (' + Convert(nvarchar(50), Id) + ')' from ItemList where Id > 10000 and Hide = 0", this.ObjCore.getHBCConnectionString());
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataSet BranchesDs = this.ObjCore.getDataSet("Select * from Branches", this.ObjCore.getHBCConnectionString());

                DataSet Vendor;
                DataTable dt = new DataTable("VendersData");
                dt.Columns.Add(new DataColumn("Name", Type.GetType("System.String")));
                dt.Columns.Add(new DataColumn("Stock", Type.GetType("System.String")));
                dt.Columns.Add(new DataColumn("StockInOrder", Type.GetType("System.String")));
                dt.Columns.Add(new DataColumn("Available", Type.GetType("System.String")));
                for (int i = 0; i < BranchesDs.Tables[0].Rows.Count; i++)
                {
                    //string ConString = BranchesDs.Tables[0].Rows[i]["LocalConnectionString"].ToString();
                    string ConString = BranchesDs.Tables[0].Rows[i]["ConnectionString"].ToString();
                    if (ConString != "")
                    {
                        bool status = this.ObjCore.ConnectionCheck(@"" + ConString);
                        if (status)
                        {
                            Vendor = this.ObjCore.getDataSet("Select isnull(dbo.funGetItemStock(" + this.cmbVendor.SelectedValue.ToString() + "), 0), isnull(dbo.funGetItemStockInOrder(" + this.cmbVendor.SelectedValue.ToString() + "), 0)", ConString);
                            Vendor.EnforceConstraints = false;

                            DataRow dr = dt.NewRow();
                            dr["Name"] = BranchesDs.Tables[0].Rows[i]["BranchName"].ToString();
                            dr["Stock"] = Vendor.Tables[0].Rows[0][0].ToString();
                            dr["StockInOrder"] = Vendor.Tables[0].Rows[0][1].ToString();
                            dr["Available"] = (Convert.ToInt32(Vendor.Tables[0].Rows[0][0]) - Convert.ToInt32(Vendor.Tables[0].Rows[0][1])).ToString();
                            dt.Rows.InsertAt(dr, dt.Rows.Count);
                        }
                        else
                        {
                            DataRow dr = dt.NewRow();
                            dr["Name"] = BranchesDs.Tables[0].Rows[i]["BranchName"].ToString() + " - Not Available";
                            dr["Stock"] = "0";
                            dr["StockInOrder"] = "0";
                            dr["Available"] = "0";
                            dt.Rows.InsertAt(dr, dt.Rows.Count);
                        }
                    }

                }

                DataRow drr = dt.NewRow();
                drr["Name"] = "HBC";
                drr["Stock"] = this.ObjCore.getDataSet("select dbo.funGetStock(" + this.cmbVendor.SelectedValue.ToString() + ")", this.ObjCore.getHBCConnectionString()).Tables[0].Rows[0][0].ToString();
                dt.Rows.InsertAt(drr, dt.Rows.Count);

                DataRow drrr = dt.NewRow();
                drrr["Name"] = "Manufacturing Row";
                drrr["Stock"] = this.ObjCore.getDataSet("select dbo.funGetMStock(" + this.cmbVendor.SelectedValue.ToString() + ")", this.ObjCore.getHBCConnectionString()).Tables[0].Rows[0][0].ToString();
                dt.Rows.InsertAt(drrr, dt.Rows.Count);

                //DataTable ddt = dt;
                this.Cursor = Cursors.Default;
                this.dgv.DataSource = dt;

                decimal TotalPurchases = 0;
                decimal TotalInOrder = 0;

                for (int i = 0; i < this.dgv.Rows.Count; i++)
                {
                    TotalPurchases += Convert.ToDecimal(this.dgv[1, i].Value);
                    if (this.dgv[2, i].Value.ToString() != "")
                        TotalInOrder += Convert.ToDecimal(this.dgv[2, i].Value);
                }

                //decimal TotalPayment = Convert.ToDecimal(this.ObjCore.getDataSet("Select dbo.funGetVendorTotalPayment(" + this.cmbVendor.SelectedValue.ToString() + ")").Tables[0].Rows[0][0]);

                this.txtTotalPurchases.Text = (TotalPurchases - TotalInOrder).ToString();
                //this.txtTotalPayment.Text = TotalPayment.ToString();
                //this.txtBalance.Text = (TotalPurchases - TotalPayment).ToString();
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
