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
    public partial class frmEmployeeDocument : Form
    {
        public Classes.CoreClass objCore { get; set; }
        public string hrmId { get; set; }
        public bool remoteCall { get; set; }
        public int editMode { get; set; }
        public string documentId { get; set; }

        System.Drawing.Bitmap chartMap;
        System.Drawing.Printing.PrintDocument printChart;

        public frmEmployeeDocument()
        {
            InitializeComponent();
            this.documentId = string.Empty;
            this.hrmId = string.Empty;
            this.editMode = 0;
            this.remoteCall = false;
            this.objCore = new Classes.CoreClass();
            this.printChart = new System.Drawing.Printing.PrintDocument();
            this.printChart.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(printChart_PrintPage);
        }

        private void printChart_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(this.chartMap, e.PageBounds.Width / 2 - this.pbxImage.Width / 2, e.PageBounds.Height / 2 - this.pbxImage.Height / 2);
        }

        private void frmEmployeeDocument_Load(object sender, EventArgs e)
        {
            try
            {
                SqlDataReader dr = this.objCore.getDataReader("Select Name from Employee Where Id =  " + this.hrmId, this.objCore.getHBCConnectionString());
                if (dr.HasRows)
                {
                    dr.Read();
                    this.lbTitle.Text = "Employee Documents : " + dr.GetValue(0).ToString();
                }
                dr.Close();
                this.objCore.closeConnection();
                this.loadItems();

                if (this.remoteCall)
                {
                    //
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAttach_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.Filter = "(*.JPG;*.JPEG;*.PNG)|*.JPG;*.JPEG;*.PNG";
                if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string fileName = dlg.FileName;
                    //System.IO.FileStream frStrm = new System.IO.FileStream(fileName, System.IO.FileMode.Open);
                    //System.IO.StreamReader srReader = new System.IO.StreamReader(frStrm);
                    int lastIndexOfSlash = fileName.LastIndexOf('\\');
                    if (lastIndexOfSlash < 0)
                        lastIndexOfSlash = 0;
                    this.txtFileName.Text = fileName.Substring(lastIndexOfSlash + 1, fileName.IndexOf('.') - lastIndexOfSlash - 1);
                    this.txtDocumentType.Text = fileName.Substring(fileName.IndexOf('.') + 1);
                    //Bitmap bmp = new Bitmap(Image.FromFile(fileName), this.pbxLogo.Width, this.pbxLogo.Height);
                    this.pbxImage.Image = Image.FromFile(fileName);
                    Size sz = new Size(this.pbxImage.Image.Size.Width, this.pbxImage.Image.Size.Height);
                    this.pbxImage.Size = sz;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                this.saveFrame();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void saveFrame()
        {
            SqlDataReader dr;


            if (this.pbxImage.Image == null)
            {
                MessageBox.Show("Please select an Image to save.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (this.txtFileName.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please enter doucment name.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtFileName.Focus();
                return;
            }
            if (this.editMode == 0)
            {
                DialogResult dlg = MessageBox.Show("Are you sure to save the Employee Document?", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlg == System.Windows.Forms.DialogResult.No)
                    return;
            }
            else if (this.editMode == 1)
            {
                DialogResult dlg = MessageBox.Show("Are you sure to update the Employee Document?", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlg == System.Windows.Forms.DialogResult.No)
                    return;
            }

            SqlConnection con = new SqlConnection();
            con.ConnectionString = this.objCore.getHBCConnectionString();
            con.Open();
            SqlTransaction tran = con.BeginTransaction();
            SqlCommand com = new SqlCommand("", con, tran);
            string command = string.Empty;
            bool success = false;

            try
            {
                if (this.editMode == 0)
                {
                    com.CommandType = CommandType.StoredProcedure;
                    com.CommandText = "spCreateEmployeeDocument";

                    com.Parameters.Add("@EmployeeId", SqlDbType.Decimal);
                    com.Parameters["@EmployeeId"].Value = this.hrmId;

                    com.Parameters.Add("@DocumentName", SqlDbType.NVarChar);
                    com.Parameters["@DocumentName"].Value = this.txtFileName.Text.Trim();

                    com.Parameters.Add("@DocumentType", SqlDbType.NVarChar);
                    com.Parameters["@DocumentType"].Value = this.txtDocumentType.Text.Trim();

                    com.Parameters.Add("@DocumentImage", SqlDbType.Image);
                    System.IO.MemoryStream strMem = new System.IO.MemoryStream();
                    this.pbxImage.Image.Save(strMem, System.Drawing.Imaging.ImageFormat.Jpeg);
                    com.Parameters["@DocumentImage"].Value = strMem.ToArray();

                    com.Parameters.Add("@CurrentUserId", SqlDbType.NVarChar);
                    com.Parameters["@CurrentUserId"].Value = this.objCore.getUserId();

                    com.Parameters.Add(new SqlParameter("@DocumentId", SqlDbType.Decimal, 10, ParameterDirection.Output, false, 10, 0, "ItemId", DataRowVersion.Default, null));
                    com.Parameters.Add(new SqlParameter("@Success", SqlDbType.Bit, 1, ParameterDirection.Output, false, 1, 0, "Success", DataRowVersion.Default, null));
                    com.Parameters.Add(new SqlParameter("@Message", SqlDbType.NVarChar, 200, ParameterDirection.Output, false, 200, 0, "Message", DataRowVersion.Default, null));
                    com.UpdatedRowSource = UpdateRowSource.OutputParameters;
                    com.ExecuteNonQuery();
                    success = Convert.ToBoolean(com.Parameters["@Success"].Value);
                    string message = com.Parameters["@Message"].Value.ToString();
                    if (success)
                        this.documentId = com.Parameters["@DocumentId"].Value.ToString();
                    tran.Commit();
                    if (success)
                    {
                        this.editMode = 1;
                        this.btnSave.Text = "Update";
                        //MessageBox.Show(message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }

                }
                else if (this.editMode == 1)
                {
                    com.CommandType = CommandType.StoredProcedure;
                    com.CommandText = "spUpdateEmployeeDocument";

                    com.Parameters.Add("@EmployeeId", SqlDbType.Decimal);
                    com.Parameters["@EmployeeId"].Value = this.hrmId;

                    com.Parameters.Add("@DocumentName", SqlDbType.NVarChar);
                    com.Parameters["@DocumentName"].Value = this.txtFileName.Text.Trim();

                    com.Parameters.Add("@DocumentType", SqlDbType.NVarChar);
                    com.Parameters["@DocumentType"].Value = this.txtDocumentType.Text.Trim();

                    com.Parameters.Add("@DocumentImage", SqlDbType.Image);
                    System.IO.MemoryStream strMem = new System.IO.MemoryStream();
                    this.pbxImage.Image.Save(strMem, System.Drawing.Imaging.ImageFormat.Jpeg);
                    com.Parameters["@DocumentImage"].Value = strMem.ToArray();

                    com.Parameters.Add("@CurrentUserId", SqlDbType.NVarChar);
                    com.Parameters["@CurrentUserId"].Value = this.objCore.getUserId();

                    com.Parameters.Add("@DocumentId", SqlDbType.Decimal);
                    com.Parameters["@DocumentId"].Value = this.documentId;

                    com.Parameters.Add(new SqlParameter("@Success", SqlDbType.Bit, 1, ParameterDirection.Output, false, 1, 0, "Success", DataRowVersion.Default, null));
                    com.Parameters.Add(new SqlParameter("@Message", SqlDbType.NVarChar, 200, ParameterDirection.Output, false, 200, 0, "Message", DataRowVersion.Default, null));
                    com.UpdatedRowSource = UpdateRowSource.OutputParameters;
                    com.ExecuteNonQuery();
                    success = Convert.ToBoolean(com.Parameters["@Success"].Value);
                    string message = com.Parameters["@Message"].Value.ToString();
                    tran.Commit();
                    if (success)
                    {
                        this.editMode = 1;
                        this.btnSave.Text = "Update";
                        //MessageBox.Show(message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Stop);
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
                this.loadItems();
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (this.pbxImage.Image == null)
                return;
            this.chartMap = new Bitmap(this.pbxImage.Width, this.pbxImage.Height);
            this.pbxImage.DrawToBitmap(this.chartMap, new Rectangle(0, 0, this.pbxImage.Width, this.pbxImage.Height));
            PageSetupDialog dlgSetup = new PageSetupDialog();
            dlgSetup.Document = this.printChart;
            if (dlgSetup.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //PrintPreviewDialog dlgpre = new PrintPreviewDialog();
                //dlgpre.Document = this.printChart;
                //dlgpre.ShowDialog();
                PrintDialog dlg = new PrintDialog();
                dlg.Document = this.printChart;
                dlg.ShowDialog();
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.pbxImage.Image == null)
                    return;
                System.Windows.Forms.SaveFileDialog dlb = new SaveFileDialog();
                if (this.txtFileName.Text.Trim() != string.Empty)
                {
                    dlb.FileName = this.txtFileName.Text.Trim();
                }
                dlb.Filter = "(*.JPG;*.JPEG;*.PNG)|*.JPG;*.JPEG;*.PNG";
                if (dlb.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    this.pbxImage.Image.Save(dlb.FileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.clearall();
        }

        private void clearall()
        {
            this.documentId = string.Empty;
            this.btnSave.Text = "Save";
            this.editMode = 0;
            this.pbxImage.Image = null;
            this.pbxImage.Size = new Size(1, 1);
            this.txtFileName.Clear();
        }
          

        private void btnClose1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void loadItems()
        {
            try
            {
                this.dsEmployeeDocuments1.Clear();
                this.daEmployeeDocuments.SelectCommand.Connection.ConnectionString = this.objCore.getConnectionString();
                this.daEmployeeDocuments.SelectCommand.Parameters["@employeeId"].Value = this.hrmId;
                this.daEmployeeDocuments.Fill(this.dsEmployeeDocuments1);

            }
            catch (Exception ex)
            {
            }
        }

        private void dgVendorServices_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == this.dgVendorServices.Columns["Edit"].Index)
            {
                if (e.RowIndex >= 0 && e.RowIndex < this.dgVendorServices.Rows.Count)
                {
                    try
                    {
                        this.clearall();
                        string billId = this.dgVendorServices["DocumentIdSearch", e.RowIndex].Value.ToString();
                        SqlDataReader dr = this.objCore.getDataReader("Select * from EmployeeDocument  Where DocumentId = " + billId, this.objCore.getHBCConnectionString());
                        if (dr.HasRows)
                        {
                            dr.Read();
                            this.txtFileName.Text = dr["DocumentName"].ToString();
                            this.txtDocumentType.Text = dr["DocumentType"].ToString();
                            System.IO.MemoryStream memStem = new System.IO.MemoryStream((byte[])dr["DocumentImage"]);
                            this.pbxImage.Image = Image.FromStream(memStem);
                            Size sz = new Size(this.pbxImage.Image.Size.Width, this.pbxImage.Image.Size.Height);
                            this.pbxImage.Size = sz;
                            this.documentId = billId;
                            this.editMode = 1;
                            this.btnSave.Text = "Update";
                        }

                        dr.Close();
                        this.objCore.closeConnection();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else if (e.ColumnIndex == this.dgVendorServices.Columns["Delete"].Index)
            {
                if (e.RowIndex >= 0 && e.RowIndex < this.dgVendorServices.Rows.Count)
                {
                    try
                    {
                        DialogResult dlg = MessageBox.Show("Are you sure to delete the Student Document?", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dlg == System.Windows.Forms.DialogResult.No)
                            return;
                        string billId = this.dgVendorServices["DocumentIdSearch", e.RowIndex].Value.ToString();


                        SqlConnection con = new SqlConnection();
                        con.ConnectionString = this.objCore.getHBCConnectionString();
                        con.Open();
                        SqlTransaction tran = con.BeginTransaction();
                        SqlCommand com = new SqlCommand("", con, tran);
                        string command = string.Empty;
                        try
                        {
                            com.CommandType = CommandType.StoredProcedure;
                            com.CommandText = "spDeleteEmployeeDocument";

                            com.Parameters.Add("@DocumentId", SqlDbType.Decimal);
                            com.Parameters["@DocumentId"].Value = billId;

                            com.Parameters.Add("@CurrentUserId", SqlDbType.NVarChar);
                            com.Parameters["@CurrentUserId"].Value = this.objCore.getUserId();

                            com.Parameters.Add(new SqlParameter("@Success", SqlDbType.Bit, 1, ParameterDirection.Output, false, 1, 0, "Success", DataRowVersion.Default, null));
                            com.Parameters.Add(new SqlParameter("@Message", SqlDbType.NVarChar, 200, ParameterDirection.Output, false, 200, 0, "Message", DataRowVersion.Default, null));
                            com.UpdatedRowSource = UpdateRowSource.OutputParameters;
                            com.ExecuteNonQuery();
                            bool success = Convert.ToBoolean(com.Parameters["@Success"].Value);
                            string message = com.Parameters["@Message"].Value.ToString();
                            tran.Commit();
                            if (success)
                            {
                                if (billId == this.documentId)
                                    this.clearall();
                                //MessageBox.Show(message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show(message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            }
                        }
                        catch (Exception ex)
                        {
                            tran.Rollback();
                            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        finally
                        {
                            com.Clone();
                            this.loadItems();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnCloseTop_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
