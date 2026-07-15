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
    public partial class frmOffers : Form
    {
        CoreClass ObjCore;
        private int Id = -1;

        public frmOffers()
        {
            InitializeComponent();
            this.ObjCore = new CoreClass();
        }

        private void frmOffers_Load(object sender, EventArgs e)
        {
            this.ObjCore.fillComboBoxOptioni(this.cmbItem, "Select ItemId, Code + ' ' + Title + ' (' + Convert(nvarchar(50), ItemId) + ')' from Items  where ItemId > 10000 and Hide = 0", this.ObjCore.getClientConnectionString());
            this.LoadDGV();
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

                //if (this.txtSalary.Value < 1)
                //{
                //    MessageBox.Show("Salary cannot be zero", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //    this.txtSalary.Focus();
                //    return;
                //}

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
                    com.CommandText = "spCreateOfferItem";

                    com.Parameters.AddWithValue("@ItemId", this.cmbItem.SelectedValue.ToString());

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
                    com.CommandText = "spUpdateOfferItem";

                    com.Parameters.AddWithValue("@Id", this.Id.ToString());
                    com.Parameters.AddWithValue("@ItemId", this.cmbItem.SelectedValue.ToString());

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
                this.dsOfferItem1.Clear();
                this.dsOfferItem1.EnforceConstraints = false;

                this.daOfferItem.SelectCommand.Connection.ConnectionString = this.ObjCore.getHBCConnectionString();
                this.daOfferItem.SelectCommand.Parameters["@key"].Value = this.txtSearch.Text.Trim();
                this.daOfferItem.Fill(this.dsOfferItem1);
            }
            catch (Exception ex)
            {

            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.ClearAll();
        }

        private void ClearAll()
        {
            this.Id = -1;
            this.btnSave.Text = "Save";
            this.pBxPhoto.Image = null;

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
                    //Size imgSize = new Size(this.pBxPhoto.Width, this.pBxPhoto.Height);
                    //System.Drawing.Bitmap bmpPhoto = new Bitmap(Image.FromFile(imagePath), imgSize);
                    //this.pBxPhoto.Image = bmpPhoto;


                    // Load the original image
                    Image originalImage = Image.FromFile(imagePath);

                    // Calculate the new width to maintain the aspect ratio
                    int newWidth = (int)(originalImage.Width * ((float)this.pBxPhoto.Height / originalImage.Height));

                    // Create a new size with the calculated width and the desired height
                    Size newSize = new Size(newWidth, this.pBxPhoto.Height);

                    // Resize the image
                    Bitmap resizedImage = new Bitmap(originalImage, newSize);

                    // Set the resized image to the PictureBox
                    this.pBxPhoto.Image = resizedImage;

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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    if (e.ColumnIndex == this.dataGridView1.Columns["Edit"].Index)
                    {
                        string SelectedId = this.dataGridView1["idShow", e.RowIndex].Value.ToString();

                        DataTable dt = this.ObjCore.getDataSet("Select * from OfferItems where Id = " + SelectedId, this.ObjCore.getHBCConnectionString()).Tables[0];

                        this.cmbItem.SelectedValue = dt.Rows[0]["ItemId"].ToString();

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

                    if (e.ColumnIndex == this.dataGridView1.Columns["Delete"].Index)
                    {

                        DialogResult question = MessageBox.Show("Are you sure to delete?", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (question == System.Windows.Forms.DialogResult.No)
                            return;

                        string SelectedId = this.dataGridView1["idShow", e.RowIndex].Value.ToString();

                        DataTable dt = this.ObjCore.getDataSet("Select * from OfferItems where Id = " + SelectedId, this.ObjCore.getHBCConnectionString()).Tables[0];

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
                            
                                com.CommandType = CommandType.StoredProcedure;
                                com.CommandText = "spDeleteOfferItem";

                                com.Parameters.AddWithValue("@Id", SelectedId);                                

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
                        catch (Exception ex)
                        {
                            tran.Rollback();
                            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        finally
                        {
                            con.Close();
                            this.LoadDGV();
                            this.ClearAll();
                        }

                    }
                    
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                frmRptOfferItems obj = new frmRptOfferItems();                
                obj.MdiParent = this.MdiParent;
                obj.Show();
            }
            catch (Exception ex)
            {

            }
        }

        private void cmbItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = this.ObjCore.getDataSet("Select dbo.funGetOverAllItemStock(" + this.cmbItem.SelectedValue.ToString() + ")", this.ObjCore.getHBCConnectionString());

                this.lbStock.Text = ds.Tables[0].Rows[0][0].ToString();
            }
            catch (Exception ex)
            {
                
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            this.LoadDGV();
        }
    }
}
