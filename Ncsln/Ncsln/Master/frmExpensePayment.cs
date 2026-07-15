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
    public partial class frmExpensePayment : Form
    {
        CoreClass ObjCore;
        public int TypeId = -1;
        public int Invoice_Id = -1;
        public decimal Amount = 0;
        private int Id = -1;

        public frmExpensePayment()
        {
            InitializeComponent();
            this.ObjCore = new CoreClass();
        }

        private void frmEmployee_Load(object sender, EventArgs e)
        {
            this.LoadDGV();
            this.txtAmount.Value = this.Amount;
            //this.ObjCore.fillComboBoxOptioni(this.cmbBranch, "Select Id, GroupName from BranchesGroup", this.ObjCore.getHBCConnectionString());
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                //if (this.txtName.Text.Trim() == "")
                //{
                //    MessageBox.Show("Please enter Employee Name", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //    this.txtName.Focus();
                //    return;
                //}

                if (this.txtAmount.Value < 1)
                {
                    MessageBox.Show("Payment cannot be zero", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.txtAmount.Focus();
                    return;
                }

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
                    com.CommandText = "spCreateExpense";

                    com.Parameters.AddWithValue("@Invoice_Id", this.Invoice_Id.ToString());
                    com.Parameters.AddWithValue("@PaymentType", this.TypeId.ToString());
                    com.Parameters.AddWithValue("@PayDate", this.dtp.Value.ToString());
                    com.Parameters.AddWithValue("@Description", this.txtDescription.Text.Trim());
                    com.Parameters.AddWithValue("@Bank", this.txtName.Text.Trim());
                    com.Parameters.AddWithValue("@AccountNo", this.txtAccountNo.Text.Trim());
                    com.Parameters.AddWithValue("@Amount", this.txtAmount.Value.ToString());

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
                    com.CommandText = "spUpdateExpense";

                    com.Parameters.AddWithValue("@Id", this.Id.ToString());
                    com.Parameters.AddWithValue("@Invoice_Id", this.Invoice_Id.ToString());
                    com.Parameters.AddWithValue("@PaymentType", this.TypeId.ToString());
                    com.Parameters.AddWithValue("@PayDate", this.dtp.Value.ToString());
                    com.Parameters.AddWithValue("@Description", this.txtDescription.Text.Trim());
                    com.Parameters.AddWithValue("@Bank", this.txtName.Text.Trim());
                    com.Parameters.AddWithValue("@AccountNo", this.txtAccountNo.Text.Trim());
                    com.Parameters.AddWithValue("@Amount", this.txtAmount.Value.ToString());

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
                this.LoadDGV();
            }
        }

        private void LoadDGV()
        {
            try
            {
                this.dsExpensePayment1.Clear();
                this.dsExpensePayment1.EnforceConstraints = false;
                this.daExpensePayment.SelectCommand.Connection.ConnectionString = this.ObjCore.getHBCConnectionString();
                this.daExpensePayment.SelectCommand.Parameters["@Id"].Value = this.Invoice_Id.ToString();
                this.daExpensePayment.SelectCommand.Parameters["@Type"].Value = this.TypeId.ToString();
                this.daExpensePayment.Fill(this.dsExpensePayment1);
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
                        string SelectedId = this.dgv["idShow", e.RowIndex].Value.ToString();

                        DataTable dt = this.ObjCore.getDataSet("Select * from ExpensePayments where Id = " + SelectedId, this.ObjCore.getHBCConnectionString()).Tables[0];

                        this.txtName.Text = dt.Rows[0]["Bank"].ToString();
                        this.txtAccountNo.Text = dt.Rows[0]["AccountNo"].ToString();
                        this.txtDescription.Text = dt.Rows[0]["Description"].ToString();
                        this.dtp.Value = Convert.ToDateTime(dt.Rows[0]["PayDate"]);
                        this.txtAmount.Value = Convert.ToDecimal(dt.Rows[0]["Amount"]);
                        
                        this.Id = Convert.ToInt32(dt.Rows[0]["Id"]);
                        this.btnSave.Text = "Update";

                    }

                    if (e.ColumnIndex == this.dgv.Columns["Delete"].Index)
                    {
                        if (!CommonTask.Question(-1, true)) return;

                        string SelectedId = this.dgv["idShow", e.RowIndex].Value.ToString();

                        this.ObjCore.executeQuery("Delete from ExpensePayments where Id = " + SelectedId.ToString(), this.ObjCore.getHBCConnectionString());

                        this.LoadDGV();
                    }

                    //if (e.ColumnIndex == this.dgv.Columns["Photo"].Index)
                    //{
                    //    string SelectedId = this.dgv["idShow", e.RowIndex].Value.ToString();
                    //    frmPicture obj = new frmPicture();
                    //    obj.Id = SelectedId;
                    //    obj.StartPosition = FormStartPosition.CenterScreen;
                    //    obj.ShowDialog();
                    //}
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.clearForm();
        }

        private void clearForm()
        {
            this.txtName.Text = this.txtAccountNo.Text = "";
            this.txtAmount.Value = 0;
            
            this.btnSave.Text = "Save";
            this.Id = -1;
        }

        private void btnSelectPicture_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    OpenFileDialog opDlg = new OpenFileDialog();
            //    DialogResult dlg = opDlg.ShowDialog(this);
            //    if (dlg == DialogResult.Cancel)
            //        return;
            //    string imagePath = opDlg.FileName;

            //    System.IO.FileInfo flInfo = new System.IO.FileInfo(imagePath);
            //    string photoType = flInfo.Extension;
            //    if (photoType == ".jpeg" || photoType == ".jpg" || photoType == ".png" || photoType == ".gif" || photoType == ".JPEG" || photoType == ".JPG" || photoType == ".PNG" || photoType == ".GIF")
            //    {
            //        int photoSize = Convert.ToInt32(flInfo.Length);

            //        //Following code checks if the Photo size is greater than 16K Bytes
            //        //if (photoSize > 65536)
            //        //{
            //        //    MessageBox.Show("Can not accept a photo greater than 64K bytes", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //        //    return;
            //        //}
            //        Size imgSize = new Size(this.pBxPhoto.Width, this.pBxPhoto.Height);
            //        System.Drawing.Bitmap bmpPhoto = new Bitmap(Image.FromFile(imagePath), imgSize);
            //        this.pBxPhoto.Image = bmpPhoto;
            //    }
            //    else
            //    {
            //        MessageBox.Show("Please load image of type JPEG, GIF OR PNG", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void btnResest_Click(object sender, EventArgs e)
        {
            //this.pBxPhoto.Image = null;
        }
    }
}
