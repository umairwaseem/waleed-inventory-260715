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
    public partial class frmProfitMargin : Form
    {
        CoreClass ObjCore;
        public int TypeId = -1;
        public int Invoice_Id = -1;
        public decimal Amount = 0;
        private int Id = -1;

        public frmProfitMargin()
        {
            InitializeComponent();
            this.ObjCore = new CoreClass();
        }

        private void frmEmployee_Load(object sender, EventArgs e)
        {
            this.LoadDGV();
            this.txtAmountOne.Value = this.Amount;
            //this.ObjCore.fillComboBoxOptioni(this.cmbBranch, "Select Id, GroupName from BranchesGroup", this.ObjCore.getHBCConnectionString());

            DataTable td = this.ObjCore.getDataSet("select dbo.funGetSalaries(1), dbo.funGetSalaries(2), dbo.funGetSalaries(3), dbo.funGetSalaries(4), dbo.funGetSalaries(5)").Tables[0];
            this.lbOM.Text = td.Rows[0][0].ToString();
            this.lbWS.Text = td.Rows[0][1].ToString();
            this.lbOO.Text = td.Rows[0][2].ToString();
            this.lbOE.Text = td.Rows[0][3].ToString();
            this.lbHBC.Text = td.Rows[0][4].ToString();

            decimal totalEx = Convert.ToDecimal(this.lbOM.Text) + Convert.ToDecimal(this.lbOO.Text) + Convert.ToDecimal(this.lbWS.Text) + Convert.ToDecimal(this.lbOE.Text) + Convert.ToDecimal(this.lbHBC.Text);
            this.lbExp.Text = totalEx.ToString();
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

                if (this.txtAmountOne.Value < 1)
                {
                    MessageBox.Show("Amount cannot be zero", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.txtAmountOne.Focus();
                    return;
                }

                if (this.txtAmountTwo.Value < 1)
                {
                    MessageBox.Show("Amount cannot be zero", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.txtAmountTwo.Focus();
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
                    com.CommandText = "spCreateProfitMargin";

                    com.Parameters.AddWithValue("@Date", this.dtp.Value.ToString());
                    com.Parameters.AddWithValue("@AmountOne", this.txtAmountOne.Value.ToString());
                    com.Parameters.AddWithValue("@AmountTwo", this.txtAmountTwo.Value.ToString());
                    com.Parameters.AddWithValue("@AmountThree", this.txtAmountThree.Value.ToString());
                    com.Parameters.AddWithValue("@AmountFour", this.txtAmountFour.Value.ToString());

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
                    com.CommandText = "spUpdateProfitMargin";

                    com.Parameters.AddWithValue("@Id", this.Id.ToString());
                    com.Parameters.AddWithValue("@Date", this.dtp.Value.ToString());
                    com.Parameters.AddWithValue("@AmountOne", this.txtAmountOne.Value.ToString());
                    com.Parameters.AddWithValue("@AmountTwo", this.txtAmountTwo.Value.ToString());
                    com.Parameters.AddWithValue("@AmountThree", this.txtAmountThree.Value.ToString());
                    com.Parameters.AddWithValue("@AmountFour", this.txtAmountFour.Value.ToString());

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
                this.dsProfitMargin1.Clear();
                this.dsProfitMargin1.EnforceConstraints = false;
                this.daProfitMargin.SelectCommand.Connection.ConnectionString = this.ObjCore.getHBCConnectionString();
                this.daProfitMargin.Fill(this.dsProfitMargin1);
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
                        this.clearForm();
                        string SelectedId = this.dgv["idShow", e.RowIndex].Value.ToString();

                        DataTable dt = this.ObjCore.getDataSet("Select * from ProfitSharing where Id = " + SelectedId, this.ObjCore.getHBCConnectionString()).Tables[0];

                        this.dtp.Value = Convert.ToDateTime(dt.Rows[0]["Date"]);
                        this.txtAmountOne.Value = Convert.ToDecimal(dt.Rows[0]["AmountOne"]);
                        this.txtAmountTwo.Value = Convert.ToDecimal(dt.Rows[0]["AmountTwo"]);
                        this.txtAmountThree.Value = Convert.ToDecimal(dt.Rows[0]["AmountThree"]);
                        this.txtAmountFour.Value = Convert.ToDecimal(dt.Rows[0]["AmountFour"]);
                        
                        this.Id = Convert.ToInt32(dt.Rows[0]["Id"]);

                        DataTable dtSalary = this.ObjCore.getDataSet("select GroupType, sum((Salary - AbsentAmount) + Bonus) as WithOutPer, sum(PercentAmount) as PercentageAmount, Expense, GroupName, MajorAmount  from vEmployeeSalary where Month(SalaryMonth) = month('" + this.dtp.Value.ToShortDateString() + "') and YEAR(SalaryMonth) = Year('" + this.dtp.Value.ToShortDateString() + "') group by GroupType, GroupName, Expense, MajorAmount", this.ObjCore.getHBCConnectionString()).Tables[0];

                        if (Convert.ToInt32(dtSalary.Rows[0]["GroupType"]) == 6)
                        {
                            dtSalary = this.ObjCore.getDataSet("select Branch_Id as GroupType, sum((Salary - AbsentAmount) + Bonus) as WithOutPer, sum(PercentAmount) as PercentageAmount, Expense, GroupName, MajorAmount  from vEmployeeSalaryAll where Month(SalaryMonth) = month('" + this.dtp.Value.ToShortDateString() + "') and YEAR(SalaryMonth) = Year('" + this.dtp.Value.ToShortDateString() + "') group by GroupType, GroupName, Expense, MajorAmount, Branch_Id", this.ObjCore.getHBCConnectionString()).Tables[0];
                        }

                        for (int i = 0; i < dtSalary.Rows.Count; i++)
                        {
                            if (Convert.ToInt32(dtSalary.Rows[i]["GroupType"]) == 1)
                            {
                                this.lbOM.Text = dtSalary.Rows[i]["WithOutPer"].ToString();
                                this.lbPOm.Text = dtSalary.Rows[i]["PercentageAmount"].ToString();
                                this.lbExpOm.Text = (txtAmountOne.Value - (Convert.ToDecimal(this.lbOM.Text) + Convert.ToDecimal(this.lbPOm.Text))).ToString();
                            }
                            else if (Convert.ToInt32(dtSalary.Rows[i]["GroupType"]) == 2)
                            {
                                this.lbWS.Text = dtSalary.Rows[i]["WithOutPer"].ToString();
                                this.lbPWS.Text = dtSalary.Rows[i]["PercentageAmount"].ToString();
                                this.lbExpWS.Text = (txtAmountThree.Value - (Convert.ToDecimal(this.lbWS.Text) + Convert.ToDecimal(this.lbPWS.Text))).ToString();
                            }
                            else if (Convert.ToInt32(dtSalary.Rows[i]["GroupType"]) == 3)
                            {
                                this.lbOO.Text = dtSalary.Rows[i]["WithOutPer"].ToString();
                                this.lbPOO.Text = dtSalary.Rows[i]["PercentageAmount"].ToString();
                                this.lbExpOO.Text = (txtAmountFour.Value - (Convert.ToDecimal(this.lbOO.Text) + Convert.ToDecimal(this.lbPOO.Text))).ToString();
                            }
                            else if (Convert.ToInt32(dtSalary.Rows[i]["GroupType"]) == 4)
                            {
                                this.lbOE.Text = dtSalary.Rows[i]["WithOutPer"].ToString();
                                this.lbPOE.Text = dtSalary.Rows[i]["PercentageAmount"].ToString();
                                this.lbExpOE.Text = (txtAmountTwo.Value - (Convert.ToDecimal(this.lbOE.Text) + Convert.ToDecimal(this.lbPOE.Text))).ToString();
                            }
                            else if (Convert.ToInt32(dtSalary.Rows[i]["GroupType"]) == 5)
                            {
                                this.lbHBC.Text = dtSalary.Rows[i]["WithOutPer"].ToString();
                                //this.lbPHBC.Text = dtSalary.Rows[i]["PercentageAmount"].ToString();
                                //this.lbHBCMajor.Text = dtSalary.Rows[i]["MajorAmount"].ToString();
                                //this.lbExpHBC.Text = (Convert.ToDecimal(dtSalary.Rows[i]["MajorAmount"]) - (Convert.ToDecimal(this.lbHBC.Text) + Convert.ToDecimal(this.lbPHBC.Text))).ToString();

                                //this.lbExpHBC.Text = this.lbHBC.Text;

                            }
                        }
                        this.btnSave.Text = "Update";

                        //Only Exp Total
                        decimal omEx = Convert.ToDecimal(this.lbOM.Text) + Convert.ToDecimal(this.lbPOm.Text);
                        this.lbOmExpTotal.Text = omEx.ToString();

                        decimal ooEx = Convert.ToDecimal(this.lbOO.Text) + Convert.ToDecimal(this.lbPOO.Text);
                        this.lbOOExpTotal.Text = ooEx.ToString();

                        decimal wsEx = Convert.ToDecimal(this.lbWS.Text) + Convert.ToDecimal(this.lbPWS.Text);
                        this.lbWSexpTotal.Text = wsEx.ToString();

                        decimal oeEx = Convert.ToDecimal(this.lbOE.Text) + Convert.ToDecimal(this.lbPOE.Text);
                        this.lbOEExpTotal.Text = oeEx.ToString();

                        decimal hbcEx = Convert.ToDecimal(this.lbHBC.Text) + Convert.ToDecimal(this.lbPHBC.Text);
                        this.lbHbcExpTotal.Text = hbcEx.ToString();

                        decimal totalEx = Convert.ToDecimal(this.lbOM.Text) + Convert.ToDecimal(this.lbOO.Text) + Convert.ToDecimal(this.lbWS.Text) + Convert.ToDecimal(this.lbOE.Text) + Convert.ToDecimal(this.lbHBC.Text);
                        this.lbExp.Text = totalEx.ToString();

                        decimal totalPer = Convert.ToDecimal(this.lbPOm.Text) + Convert.ToDecimal(this.lbPOO.Text) + Convert.ToDecimal(this.lbPWS.Text) + Convert.ToDecimal(this.lbPOE.Text) + Convert.ToDecimal(this.lbPHBC.Text);
                        this.totalP.Text = totalPer.ToString();

                        decimal totalExpall = Convert.ToDecimal(this.lbExpOm.Text) + Convert.ToDecimal(this.lbExpOO.Text) + Convert.ToDecimal(this.lbExpWS.Text) + Convert.ToDecimal(this.lbExpOE.Text) + Convert.ToDecimal(this.lbExpHBC.Text) - Convert.ToDecimal(this.lbHBC.Text);
                        this.lbExpTotal.Text = totalExpall.ToString();

                        decimal totalSubExp = omEx + ooEx + wsEx + oeEx + hbcEx;
                        this.lbAllExpTotal.Text = totalSubExp.ToString();

                        this.totalMj();

                    }

                    if (e.ColumnIndex == this.dgv.Columns["Delete"].Index)
                    {
                        if (!CommonTask.Question(-1, true)) return;

                        string SelectedId = this.dgv["idShow", e.RowIndex].Value.ToString();

                        this.ObjCore.executeQuery("Delete from ProfitSharing where Id = " + SelectedId.ToString(), this.ObjCore.getHBCConnectionString());

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
            this.txtAmountOne.Value = this.txtAmountTwo.Value = this.txtAmountThree.Value = this.txtAmountFour.Value = 0;

            this.txtAmountOne.Value = this.Amount;
            //this.ObjCore.fillComboBoxOptioni(this.cmbBranch, "Select Id, GroupName from BranchesGroup", this.ObjCore.getHBCConnectionString());

            DataTable td = this.ObjCore.getDataSet("select dbo.funGetSalaries(1), dbo.funGetSalaries(2), dbo.funGetSalaries(3), dbo.funGetSalaries(4), dbo.funGetSalaries(5)").Tables[0];
            this.lbOM.Text = td.Rows[0][0].ToString();
            this.lbWS.Text = td.Rows[0][1].ToString();
            this.lbOO.Text = td.Rows[0][2].ToString();
            this.lbOE.Text = td.Rows[0][3].ToString();
            this.lbHBC.Text = td.Rows[0][4].ToString();

            this.lbPOm.Text = "0";
            this.lbPOO.Text = "0";
            this.lbPOE.Text = "0";
            this.lbPWS.Text = "0";
            this.lbPHBC.Text = "0";
            this.totalP.Text = "0";

            this.lbExpOm.Text = "0";
            this.lbExpOO.Text = "0";
            this.lbExpOE.Text = "0";
            this.lbExpWS.Text = "0";
            this.lbExpHBC.Text = "0";
            this.lbExpTotal.Text = "0";

            this.lbHBCMajor.Text = "0";

            decimal totalEx = Convert.ToDecimal(this.lbOM.Text) + Convert.ToDecimal(this.lbOO.Text) + Convert.ToDecimal(this.lbWS.Text) + Convert.ToDecimal(this.lbOE.Text) + Convert.ToDecimal(this.lbHBC.Text);
            this.lbExp.Text = totalEx.ToString();

            this.lbRe.Text = "0";

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

        private void txtAmountOne_ValueChanged(object sender, EventArgs e)
        {
            this.totalMj();
        }

        private void totalMj()
        {
            try
            {
                decimal hbcMajor = Convert.ToDecimal(this.lbHBCMajor.Text);

                decimal totalm = this.txtAmountOne.Value + this.txtAmountTwo.Value + this.txtAmountThree.Value + this.txtAmountFour.Value + hbcMajor;

                this.lbMajor.Text = totalm.ToString();

                this.lbRe.Text = (totalm - Convert.ToDecimal(this.lbExp.Text) - Convert.ToDecimal(this.totalP.Text) - Convert.ToDecimal(this.lbExpTotal.Text)).ToString();
            }
            catch(Exception ex)
            {

            }
        }

        private void txtAmountTwo_ValueChanged(object sender, EventArgs e)
        {
            this.totalMj();
        }

        private void txtAmountThree_ValueChanged(object sender, EventArgs e)
        {
            this.totalMj();
        }

        private void txtAmountFour_ValueChanged(object sender, EventArgs e)
        {
            this.totalMj();
        }
    }
}
