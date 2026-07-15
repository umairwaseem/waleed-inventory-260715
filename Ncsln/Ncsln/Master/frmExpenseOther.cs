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
    public partial class frmExpenseOther : Form
    {
        CoreClass ObjCore;
        public int TypeId = -1;
        public int Invoice_Id = -1;
        public decimal Amount = 0;
        private int Id = -1;

        public frmExpenseOther()
        {
            InitializeComponent();
            this.ObjCore = new CoreClass();
        }

        private void frmEmployee_Load(object sender, EventArgs e)
        {
            this.LoadDGV();
            this.txtAmount.Value = this.Amount;
            this.ObjCore.fillComboBoxWithAddNewOptioni(this.cmbPayToList, "Select Id, PayTo from ExpenseList", this.ObjCore.getHBCConnectionString());
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.txtPayto.Text.Trim() == "")
                {
                    MessageBox.Show("Please select Pay to", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.cmbPayToList.Focus();
                    return;
                }

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
                    com.CommandText = "spCreateExpenseOther";

                    com.Parameters.AddWithValue("@PaymentDate", this.dtp.Value.ToString());
                    com.Parameters.AddWithValue("@Description", this.txtDescription.Text.Trim());
                    com.Parameters.AddWithValue("@PayTo", this.txtPayto.Text.Trim());
                    com.Parameters.AddWithValue("@Amount", this.txtAmount.Value.ToString());
                    com.Parameters.AddWithValue("@Payment", this.rbtnPay.Checked.ToString());
                    com.Parameters.AddWithValue("@ExpenseListId", this.cmbPayToList.SelectedValue.ToString());

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
                    com.CommandText = "spUpdateExpenseOther";

                    com.Parameters.AddWithValue("@Id", this.Id.ToString());
                    com.Parameters.AddWithValue("@PaymentDate", this.dtp.Value.ToString());
                    com.Parameters.AddWithValue("@Description", this.txtDescription.Text.Trim());
                    com.Parameters.AddWithValue("@PayTo", this.txtPayto.Text.Trim());
                    com.Parameters.AddWithValue("@Amount", this.txtAmount.Value.ToString());
                    com.Parameters.AddWithValue("@Payment", this.rbtnPay.Checked.ToString());
                    com.Parameters.AddWithValue("@ExpenseListId", this.cmbPayToList.SelectedValue.ToString());

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

        private void ColorGrid()
        {
            //try
            //{
            //    this.expenseOtherBindingSource.EndEdit();
            //    for (int i = 0; i < this.dgv.Rows.Count; i++)
            //    {
            //        if (Convert.ToBoolean(this.dgv["Payment", i].Value))
            //            this.dgv.Rows[i].DefaultCellStyle.BackColor = Color.OrangeRed;
            //        else
            //            this.dgv.Rows[i].DefaultCellStyle.BackColor = Color.Green;
            //    }
            //}
            //catch (Exception)
            //{

            //}
        }

        private void LoadDGV()
        {
            try
            {
                this.dsExpenseOther1.Clear();
                this.dsExpenseOther1.EnforceConstraints = false;
                this.daExpenseOther.SelectCommand.Connection.ConnectionString = this.ObjCore.getHBCConnectionString();
                this.daExpenseOther.Fill(this.dsExpenseOther1);

                this.ColorGrid();
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

                        DataTable dt = this.ObjCore.getDataSet("Select * from ExpenseOther where Id = " + SelectedId, this.ObjCore.getHBCConnectionString()).Tables[0];

                        this.txtPayto.Text = dt.Rows[0]["PayTo"].ToString();
                        this.txtDescription.Text = dt.Rows[0]["Description"].ToString();
                        this.dtp.Value = Convert.ToDateTime(dt.Rows[0]["PaymentDate"]);
                        this.txtAmount.Value = Convert.ToDecimal(dt.Rows[0]["Amount"]);
                        if (Convert.ToBoolean(dt.Rows[0]["Payment"]))
                        {
                            this.rbtnPay.Checked = true;
                            this.rbtnReceive.Checked = false;
                        } 
                        else
                        {
                            this.rbtnPay.Checked = false;
                            this.rbtnReceive.Checked = true;
                        }
                        this.Id = Convert.ToInt32(dt.Rows[0]["Id"]);
                        this.cmbPayToList.SelectedValue = dt.Rows[0]["ExpenseListId"].ToString();
                        this.btnSave.Text = "Update";

                    }

                    if (e.ColumnIndex == this.dgv.Columns["Delete"].Index)
                    {
                        if (!CommonTask.Question(-1, true)) return;

                        string SelectedId = this.dgv["idShow", e.RowIndex].Value.ToString();

                        this.ObjCore.executeQuery("Delete from ExpenseOther where Id = " + SelectedId.ToString(), this.ObjCore.getHBCConnectionString());

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
            this.txtName.Text = this.txtPayto.Text = "";
            this.txtAmount.Value = 0;
            this.cmbPayToList.SelectedValue = "-1";
            
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

        private void dgv_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            try
            {
                if (Convert.ToBoolean(this.dgv["Payment", e.RowIndex].Value))
                    this.dgv.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.PaleVioletRed;
                else
                    this.dgv.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGreen;

            }
            catch (Exception ex)
            {

            }
        }

        private void cmbPayToList_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.txtPayto.Text = this.cmbPayToList.Text;
        }

        private void cmbPayToList_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (this.cmbPayToList.SelectedValue.ToString() == "-1")
                {
                    frmExpenseList obj = new frmExpenseList();
                    obj.closeCall = true;
                    obj.ShowDialog();

                    this.ObjCore.fillComboBoxWithAddNewOptioni(this.cmbPayToList, "Select Id, PayTo from ExpenseList", this.ObjCore.getHBCConnectionString());
                    this.cmbPayToList.SelectedIndex = this.cmbPayToList.Items.Count - 1;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                this.txtPayto.Text = this.cmbPayToList.Text;
            }
            
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.expenseOtherBindingSource.Filter = " PayTo like '%"+ this.txtSearch.Text.Trim() +"%'";
            }
            catch (Exception ex)
            {

            }
        }
    }
}
