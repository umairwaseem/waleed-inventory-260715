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
    public partial class frmEmployee : Form
    {
        CoreClass ObjCore;
        private int Id = -1;

        public frmEmployee()
        {
            InitializeComponent();
            this.ObjCore = new CoreClass();
        }

        private void frmEmployee_Load(object sender, EventArgs e)
        {
            this.LoadDGV();
            this.ObjCore.fillComboBoxOptioni(this.cmbBranch, "Select Id, GroupName from BranchesGroup", this.ObjCore.getHBCConnectionString());
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.txtName.Text.Trim() == "")
                {
                    MessageBox.Show("Please enter Employee Name", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.txtName.Focus();
                    return;
                }

                if (this.txtSalary.Value < 1)
                {
                    MessageBox.Show("Salary cannot be zero", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.txtSalary.Focus();
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

            bool photoExists = false;
            System.IO.MemoryStream photoStream = new System.IO.MemoryStream();
            if (this.pBxPhoto.Image != null)
            {
                photoExists = true;
                this.pBxPhoto.Image.Save(photoStream, System.Drawing.Imaging.ImageFormat.Jpeg);
            }

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
                    com.CommandText = "spCreateEmployee";

                    com.Parameters.AddWithValue("@Name", this.txtName.Text.Trim());
                    com.Parameters.AddWithValue("@Branch_Id", this.cmbBranch.SelectedValue.ToString());
                    com.Parameters.AddWithValue("@PhoneNo", this.txtPhone.Text.Trim());
                    com.Parameters.AddWithValue("@Salary", this.txtSalary.Value.ToString());
                    com.Parameters.AddWithValue("@Status", this.chkActive.Checked.ToString());
                    com.Parameters.AddWithValue("@CNIC", this.txtCNIC.Text.Trim());
                    com.Parameters.AddWithValue("@CNICDetail", this.txtCNICDetail.Text.Trim());

                    com.Parameters.Add("@photo", SqlDbType.Image);
                    if (photoExists)
                        com.Parameters["@photo"].Value = photoStream.ToArray();
                    else
                        com.Parameters["@photo"].Value = DBNull.Value;

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
                    com.CommandText = "spUpdateEmployee";

                    com.Parameters.AddWithValue("@Id", this.Id.ToString());
                    com.Parameters.AddWithValue("@Name", this.txtName.Text.Trim());
                    com.Parameters.AddWithValue("@Branch_Id", this.cmbBranch.SelectedValue.ToString());
                    com.Parameters.AddWithValue("@PhoneNo", this.txtPhone.Text.Trim());
                    com.Parameters.AddWithValue("@Salary", this.txtSalary.Value.ToString());
                    com.Parameters.AddWithValue("@Status", this.chkActive.Checked.ToString());
                    com.Parameters.AddWithValue("@CNIC", this.txtCNIC.Text.Trim());
                    com.Parameters.AddWithValue("@CNICDetail", this.txtCNICDetail.Text.Trim());

                    com.Parameters.Add("@photo", SqlDbType.Image);
                    if (photoExists)
                        com.Parameters["@photo"].Value = photoStream.ToArray();
                    else
                        com.Parameters["@photo"].Value = DBNull.Value;

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
                this.dsEmployee1.Clear();
                this.dsEmployee1.EnforceConstraints = false;
                this.daEmployee.SelectCommand.Connection.ConnectionString = this.ObjCore.getHBCConnectionString();
                this.daEmployee.SelectCommand.Parameters["@key"].Value = this.txtSearch.Text.Trim();
                this.daEmployee.Fill(this.dsEmployee1);
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

                        DataTable dt = this.ObjCore.getDataSet("Select * from Employee where Id = " + SelectedId, this.ObjCore.getHBCConnectionString()).Tables[0];

                        this.txtName.Text = dt.Rows[0]["Name"].ToString();
                        this.txtPhone.Text = dt.Rows[0]["PhoneNo"].ToString();
                        this.txtSalary.Value = Convert.ToDecimal(dt.Rows[0]["Salary"]);
                        this.txtCNIC.Text = dt.Rows[0]["CNIC"].ToString();
                        this.txtCNICDetail.Text = dt.Rows[0]["CNICDetail"].ToString();
                        this.cmbBranch.SelectedValue = dt.Rows[0]["Branch_Id"].ToString();
                        this.chkActive.Checked = Convert.ToBoolean(dt.Rows[0]["Status"]);

                        if (dt.Rows[0]["Photo"].ToString() == "")
                        {
                            this.pBxPhoto.Image = null;
                        }
                        else
                        {
                            System.IO.MemoryStream photoStream = new System.IO.MemoryStream((byte[])dt.Rows[0]["Photo"]);
                            this.pBxPhoto.Image = Image.FromStream(photoStream, true, true);
                        }

                        

                        this.Id = Convert.ToInt32(dt.Rows[0]["Id"]);
                        this.btnSave.Text = "Update";

                    }

                    if (e.ColumnIndex == this.dgv.Columns["Photo"].Index)
                    {
                        string SelectedId = this.dgv["idShow", e.RowIndex].Value.ToString();
                        frmPicture obj = new frmPicture();
                        obj.Id = SelectedId;
                        obj.StartPosition = FormStartPosition.CenterScreen;
                        obj.ShowDialog();
                    }

                    if (e.ColumnIndex == this.dgv.Columns["Doc"].Index)
                    {
                        string SelectedId = this.dgv["idShow", e.RowIndex].Value.ToString();

                        frmEmployeeDocument obj = new frmEmployeeDocument();
                        obj.hrmId = SelectedId;
                        obj.ShowDialog();
                    }
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
            this.txtName.Text = this.txtPhone.Text = "";
            this.txtSalary.Value = 0;
            this.txtCNIC.Text = this.txtCNICDetail.Text = "";
            this.chkActive.Checked = false;
            this.pBxPhoto.Image = null;
            this.btnSave.Text = "Save";
            this.Id = -1;
        }

        private void btnSelectPicture_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog opDlg = new OpenFileDialog();
                DialogResult dlg = opDlg.ShowDialog(this);
                if (dlg == DialogResult.Cancel)
                    return;
                string imagePath = opDlg.FileName;

                System.IO.FileInfo flInfo = new System.IO.FileInfo(imagePath);
                string photoType = flInfo.Extension;
                if (photoType == ".jpeg" || photoType == ".jpg" || photoType == ".png" || photoType == ".gif" || photoType == ".JPEG" || photoType == ".JPG" || photoType == ".PNG" || photoType == ".GIF")
                {
                    int photoSize = Convert.ToInt32(flInfo.Length);

                    //Following code checks if the Photo size is greater than 16K Bytes
                    //if (photoSize > 65536)
                    //{
                    //    MessageBox.Show("Can not accept a photo greater than 64K bytes", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    //    return;
                    //}
                    Size imgSize = new Size(this.pBxPhoto.Width, this.pBxPhoto.Height);
                    System.Drawing.Bitmap bmpPhoto = new Bitmap(Image.FromFile(imagePath), imgSize);
                    this.pBxPhoto.Image = bmpPhoto;
                }
                else
                {
                    MessageBox.Show("Please load image of type JPEG, GIF OR PNG", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnResest_Click(object sender, EventArgs e)
        {
            this.pBxPhoto.Image = null;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtSearch_TextChanged_1(object sender, EventArgs e)
        {
            this.LoadDGV();
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.dgv.ClearSelection();
                this.dgv.Rows[e.RowIndex].Selected = true;
            }
            catch (Exception ex)
            {

            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
