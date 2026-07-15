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
    public partial class frmVendorGPayments : Form
    {
        CoreClass ObjCore;
        private int EditMode = 1;
        private int PaymentId = -1;

        public frmVendorGPayments()
        {
            InitializeComponent();
            this.ObjCore = new CoreClass();
        }

        private void frmVendorPayments_Load(object sender, EventArgs e)
        {
            this.ObjCore.fillComboBoxOptioni(this.cmbVendors, "Select Id, Name From VendorG");
            this.loadDG();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ObjCore.CheckRightServer(34, this.PaymentId))
            {
                return;
            }

            if (this.cmbVendors.SelectedValue == null || this.cmbVendors.SelectedValue.ToString() == "-1")
            {
                MessageBox.Show("Please select a vendor!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (this.txtPayment.Value < 1)
            {
                MessageBox.Show("Payment must more then zero!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            this.SaveUpdate();
        }

        private void SaveUpdate()
        {
            if (!CommonTask.Question(this.PaymentId)) return;

            SqlConnection con = new SqlConnection();
            con.ConnectionString = this.ObjCore.getConnectionString();
            con.Open();
            SqlTransaction tran = con.BeginTransaction();
            SqlCommand com = new SqlCommand("", con, tran);
            string command = string.Empty;
            string vendorAccountId = string.Empty;
            bool success = false;
            try
            {
                if (this.EditMode == 1)
                {
                    com.CommandType = CommandType.StoredProcedure;
                    com.CommandText = "spCreateVendorGPayment";

                    com.Parameters.AddWithValue("@VendorId", this.cmbVendors.SelectedValue.ToString());
                    com.Parameters.AddWithValue("@Amount", this.txtPayment.Value);
                    com.Parameters.AddWithValue("@PaymentDate", this.dtp.Value);
                    com.Parameters.AddWithValue("@Description", this.txtDetail.Text.Trim());
                    com.Parameters.AddWithValue("@BankName", this.txtBankName.Text.Trim());
                    com.Parameters.AddWithValue("@AccountNo", this.txtAccountNo.Text.Trim());

                    com.Parameters.Add(new SqlParameter("@Id", SqlDbType.Decimal, 18, ParameterDirection.Output, false, 18, 0, "SaleId", DataRowVersion.Default, null));
                    com.Parameters.Add(new SqlParameter("@Success", SqlDbType.Bit, 1, ParameterDirection.Output, false, 1, 0, "Success", DataRowVersion.Default, null));
                    com.Parameters.Add(new SqlParameter("@Message", SqlDbType.NVarChar, 200, ParameterDirection.Output, false, 200, 0, "Message", DataRowVersion.Default, null));
                    com.UpdatedRowSource = UpdateRowSource.OutputParameters;
                    com.ExecuteNonQuery();
                    success = Convert.ToBoolean(com.Parameters["@Success"].Value);
                    string message = com.Parameters["@Message"].Value.ToString();
                    string itemIdStock = string.Empty;
                    if (success)
                        this.PaymentId = Convert.ToInt32(com.Parameters["@Id"].Value);
                    tran.Commit();
                    if (success)
                    {
                        //this.btnSave.Text = "Update";
                        //this.EditMode = 2;
                        //this.ClearForm();
                        MessageBox.Show(message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    com.CommandText = "spUpdateVendorGPayment";

                    com.Parameters.AddWithValue("@Id", this.PaymentId);
                    com.Parameters.AddWithValue("@VendorId", this.cmbVendors.SelectedValue.ToString());
                    com.Parameters.AddWithValue("@Amount", this.txtPayment.Value);
                    com.Parameters.AddWithValue("@PaymentDate", this.dtp.Value);
                    com.Parameters.AddWithValue("@Description", this.txtDetail.Text.Trim());
                    com.Parameters.AddWithValue("@BankName", this.txtBankName.Text.Trim());
                    com.Parameters.AddWithValue("@AccountNo", this.txtAccountNo.Text.Trim());

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
                        MessageBox.Show(message, "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    else
                    {
                        //this.dgDetail.ClearSelection();

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
                this.loadDG();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.ClearForm();
        }

        private void ClearForm()
        {
            this.cmbVendors.SelectedValue = -1;

            this.dtp.Value = DateTime.Now;
            this.txtPayment.Value = 0;
            this.txtDetail.Text = "";
            this.btnSave.Text = "Save";
            this.EditMode = 1;
        }

        private void loadDG()
        {
            try
            {
                //this.dsVendorPayment1.Clear();
                //this.daVendorPayment.SelectCommand.Connection.ConnectionString = this.ObjCore.getConnectionString();
                //this.daVendorPayment.Fill(this.dsVendorPayment1);

                this.dsVendorGPayment1.Clear();
                this.daVendorPaymentSelected.SelectCommand.Connection.ConnectionString = this.ObjCore.getConnectionString();
                this.daVendorPaymentSelected.SelectCommand.Parameters["@id"].Value = this.cmbVendors.SelectedValue.ToString();
                this.daVendorPaymentSelected.Fill(this.dsVendorGPayment1);
            }
            catch (Exception ex)
            {

                
            }
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    if (e.ColumnIndex == this.dgv.Columns["Edit"].Index)
                    {
                        int id = Convert.ToInt32(this.dgv["id", e.RowIndex].Value);

                        DataTable dt = this.ObjCore.getDataSet("Select * from VendorGPayment Where Id = " + id.ToString()).Tables[0];

                        this.PaymentId = id;
                        this.cmbVendors.SelectedValue = dt.Rows[0]["Vendorg_Id"].ToString();
                        this.dtp.Value = Convert.ToDateTime(dt.Rows[0]["PaymentDate"]);
                        this.txtPayment.Value = Convert.ToDecimal(dt.Rows[0]["Amount"]);
                        this.txtDetail.Text = dt.Rows[0]["Description"].ToString();

                        this.EditMode = 2;
                        this.btnSave.Text = "Update";
                    }

                    if (e.ColumnIndex == this.dgv.Columns["Delete"].Index)
                    {
                        if (!this.ObjCore.CheckRightServer(34, this.PaymentId, true))
                        {
                            return;
                        }

                        DialogResult dr = MessageBox.Show("Are you sure to delete?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dr == System.Windows.Forms.DialogResult.No) return;

                        int id = Convert.ToInt32(this.dgv["id", e.RowIndex].Value);

                        this.ObjCore.executeQuery("Delete from VendorGPayment where Id = " + id);

                        this.ClearForm();

                        this.loadDG();
                    }
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                
            }
        }

        private void cmbVendors_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //try
            //{
            //    this.dsVendorPayment1.Clear();
            //    this.daVendorPaymentSelected.SelectCommand.Connection.ConnectionString = this.ObjCore.getConnectionString();
            //    this.daVendorPaymentSelected.SelectCommand.Parameters["@id"].Value = this.cmbVendors.SelectedValue.ToString();
            //    this.daVendorPaymentSelected.Fill(this.dsVendorPayment1);
            //}
            //catch (Exception ex)
            //{

            //}

            this.loadDG();
        }

        private void txtPayment_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
