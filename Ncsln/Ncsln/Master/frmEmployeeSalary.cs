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
    public partial class frmEmployeeSalary : Form
    {
        CoreClass ObjCore;
        public int groupId;
        public int allGroup;
        public int Id = -1;

        public frmEmployeeSalary()
        {
            InitializeComponent();
            this.ObjCore = new CoreClass();
        }

        private void frmEmployeeSalary_Load(object sender, EventArgs e)
        {
            try
            {
                this.ObjCore.fillGridComboBoxWithAddNewOption((DataGridViewComboBoxColumn)this.dgv.Columns["employee"], "Select Id, Name From Employee", this.ObjCore.getHBCConnectionString());
                this.ObjCore.fillGridComboBoxWithAddNewOption((DataGridViewComboBoxColumn)this.dgv.Columns["branch"], "Select Id, GroupName from BranchesGroup", this.ObjCore.getHBCConnectionString());

                this.ObjCore.fillComboBoxOptioni(this.cmbGroup, "Select Id, GroupName from BranchesGroup", this.ObjCore.getHBCConnectionString());

                if (this.Id == -1)
                {
                    this.GetLoadEmployee();

                    if (this.allGroup == 0)
                    {
                        if (this.groupId == 1)
                        {
                            DataTable dt = this.ObjCore.getDataSet("Select AmountOne, dbo.funGetSalaries(1) from ProfitSharing where MONTH(Date) = MONTH('" + this.dtp.Value.ToString() + "') and  Year(Date) = Year('" + this.dtp.Value.ToString() + "')", this.ObjCore.getHBCConnectionString()).Tables[0];

                            this.txtMajorAmount.Value = Convert.ToDecimal(dt.Rows[0][0]);
                            this.txtExpanse.Value = Convert.ToDecimal(dt.Rows[0][1]);
                        }
                        else if (this.groupId == 2)
                        {
                            DataTable dt = this.ObjCore.getDataSet("Select AmountThree, dbo.funGetSalaries(2) from ProfitSharing where MONTH(Date) = MONTH('" + this.dtp.Value.ToString() + "') and  Year(Date) = Year('" + this.dtp.Value.ToString() + "')", this.ObjCore.getHBCConnectionString()).Tables[0];

                            this.txtMajorAmount.Value = Convert.ToDecimal(dt.Rows[0][0]);
                            this.txtExpanse.Value = Convert.ToDecimal(dt.Rows[0][1]);
                        }
                        else if (this.groupId == 3)
                        {
                            DataTable dt = this.ObjCore.getDataSet("Select AmountFour, dbo.funGetSalaries(3) from ProfitSharing where MONTH(Date) = MONTH('" + this.dtp.Value.ToString() + "') and  Year(Date) = Year('" + this.dtp.Value.ToString() + "')", this.ObjCore.getHBCConnectionString()).Tables[0];

                            this.txtMajorAmount.Value = Convert.ToDecimal(dt.Rows[0][0]);
                            this.txtExpanse.Value = Convert.ToDecimal(dt.Rows[0][1]);
                        }
                        else
                        {
                            DataTable dt = this.ObjCore.getDataSet("Select AmountTwo, dbo.funGetSalaries(4) from ProfitSharing where MONTH(Date) = MONTH('" + this.dtp.Value.ToString() + "') and  Year(Date) = Year('" + this.dtp.Value.ToString() + "')", this.ObjCore.getHBCConnectionString()).Tables[0];

                            this.txtMajorAmount.Value = Convert.ToDecimal(dt.Rows[0][0]);
                            this.txtExpanse.Value = Convert.ToDecimal(dt.Rows[0][1]);
                        }
                    }
                    else
                    {
                        decimal totalMajorAmount = 0;
                        decimal totalExpense = 0;

                        DataTable dt = this.ObjCore.getDataSet("Select AmountOne, dbo.funGetSalaries(1) from ProfitSharing where MONTH(Date) = MONTH('" + this.dtp.Value.ToString() + "') and  Year(Date) = Year('" + this.dtp.Value.ToString() + "')", this.ObjCore.getHBCConnectionString()).Tables[0];

                        totalMajorAmount += Convert.ToDecimal(dt.Rows[0][0]);
                        totalExpense += Convert.ToDecimal(dt.Rows[0][1]);

                        DataTable dtt = this.ObjCore.getDataSet("Select AmountThree, dbo.funGetSalaries(2) from ProfitSharing where MONTH(Date) = MONTH('" + this.dtp.Value.ToString() + "') and  Year(Date) = Year('" + this.dtp.Value.ToString() + "')", this.ObjCore.getHBCConnectionString()).Tables[0];

                        totalMajorAmount += Convert.ToDecimal(dtt.Rows[0][0]);
                        totalExpense += Convert.ToDecimal(dtt.Rows[0][1]);

                        DataTable dttt = this.ObjCore.getDataSet("Select AmountFour, dbo.funGetSalaries(3) from ProfitSharing where MONTH(Date) = MONTH('" + this.dtp.Value.ToString() + "') and  Year(Date) = Year('" + this.dtp.Value.ToString() + "')", this.ObjCore.getHBCConnectionString()).Tables[0];

                        totalMajorAmount += Convert.ToDecimal(dttt.Rows[0][0]);
                        totalExpense += Convert.ToDecimal(dttt.Rows[0][1]);

                        DataTable dtttt = this.ObjCore.getDataSet("Select AmountTwo, dbo.funGetSalaries(4) from ProfitSharing where MONTH(Date) = MONTH('" + this.dtp.Value.ToString() + "') and  Year(Date) = Year('" + this.dtp.Value.ToString() + "')", this.ObjCore.getHBCConnectionString()).Tables[0];

                        totalMajorAmount += Convert.ToDecimal(dtttt.Rows[0][0]);
                        totalExpense += Convert.ToDecimal(dtttt.Rows[0][1]);

                        this.txtMajorAmount.Value = totalMajorAmount;
                        this.txtExpanse.Value = totalExpense;
                    }

                    //if (this.groupId != 4)
                    //{
                    //    DataTable dt = this.ObjCore.getDataSet("Select AmountOne, dbo.funGetSalaries(1) from ProfitSharing where MONTH(Date) = MONTH('" + this.dtp.Value.ToString() + "') and  Year(Date) = Year('" + this.dtp.Value.ToString() + "')", this.ObjCore.getHBCConnectionString()).Tables[0];

                    //    this.txtMajorAmount.Value = Convert.ToDecimal(dt.Rows[0][0]);
                    //    this.txtExpanse.Value = Convert.ToDecimal(dt.Rows[0][1]);
                    //}
                    //else
                    //{
                    //    DataTable dt = this.ObjCore.getDataSet("Select AmountTwo, dbo.funGetSalaries(0) from ProfitSharing where MONTH(Date) = MONTH('" + this.dtp.Value.ToString() + "') and  Year(Date) = Year('" + this.dtp.Value.ToString() + "')", this.ObjCore.getHBCConnectionString()).Tables[0];

                    //    this.txtMajorAmount.Value = Convert.ToDecimal(dt.Rows[0][0]);
                    //    this.txtExpanse.Value = Convert.ToDecimal(dt.Rows[0][1]);
                    //}
                }
                else
                {
                    //this.dtp.Enabled = false;
                    DataTable dt = this.ObjCore.getDataSet("Select * from EmployeeSalary where Id = " + this.Id.ToString(), this.ObjCore.getHBCConnectionString()).Tables[0];

                    this.dtp.Value = Convert.ToDateTime(dt.Rows[0]["SalaryMonth"]);
                    this.txtDescription.Text = dt.Rows[0]["Description"].ToString();
                    this.txtMajorAmount.Value = Convert.ToDecimal(dt.Rows[0]["MajorAmount"]);
                    this.txtExpanse.Value = Convert.ToDecimal(dt.Rows[0]["Expense"]);
                    this.txtRemaining.Value = Convert.ToDecimal(dt.Rows[0]["Remaining"]);
                    this.txtTotalPay.Text = dt.Rows[0]["TotalPay"].ToString();

                    this.dsEmployeeSalaryDetail1.Clear();
                    this.daEmployeeSalaryDetail.SelectCommand.Connection.ConnectionString = this.ObjCore.getHBCConnectionString();
                    this.daEmployeeSalaryDetail.SelectCommand.Parameters["@Id"].Value = this.Id.ToString();
                    this.daEmployeeSalaryDetail.Fill(this.dsEmployeeSalaryDetail1);

                    this.btnSave.Text = "Update";
                    this.GetTotalPay();

                }

                this.setFonts();
                this.CmbFont.SelectedItem = this.ObjCore.GetSetting(1);

            }
            catch (Exception ex)
            {

            }
            finally
            {
                if (this.groupId == 6)
                {
                    this.label4.Visible = true;
                    this.cmbGroup.Visible = true;
                }
            }
        }

        private void setFonts()
        {
            this.dgv.DefaultCellStyle.Font = new Font("Arial", Convert.ToInt32(this.ObjCore.GetSetting(1)));
            this.dgv.AlternatingRowsDefaultCellStyle.Font = new Font("Arial", Convert.ToInt32(this.ObjCore.GetSetting(1)));
        }

        private void GetLoadEmployee()
        {
            try
            {
                this.dsEmployeeSalaryDetail1.Clear();

                string command = "";

                if (this.allGroup == 1)
                {
                    command = "Select * from Employee where Status = 1";
                }
                else
                {
                    command = "Select * from Employee where Status = 1 and Branch_Id = " + this.groupId.ToString();
                }
                
                //if (this.groupId == 1)
                //{
                //    command = "Select * from Employee where Branch_Id in (1,2,3) and Status = 1 order by Branch_Id";
                //}
                //else
                //{
                //    command = "Select * from Employee where Branch_Id in (4) and Status = 1 order by Branch_Id";
                //}

                DataTable dt = this.ObjCore.getDataSet(command, this.ObjCore.getHBCConnectionString()).Tables[0];

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dr = this.dsEmployeeSalaryDetail1.EmployeeSalaryDetail.NewRow();
                    dr["Employee_Id"] = dt.Rows[i]["Id"];
                    dr["Branch_Id"] = dt.Rows[i]["Branch_Id"];
                    dr["Salary"] = dt.Rows[i]["Salary"];
                    dr["GrowsAmount"] = dt.Rows[i]["Salary"];
                    dr["Percentage"] = dt.Rows[i]["Precentage"];
                    dr["PercentAmount"] = "0";
                    dr["AbsentDays"] = "0";
                    dr["AbsentAmount"] = "0";
                    dr["Bonus"] = "0";
                    dr["FinalAmount"] = dt.Rows[i]["Salary"];
                    this.dsEmployeeSalaryDetail1.EmployeeSalaryDetail.Rows.InsertAt(dr, this.dsEmployeeSalaryDetail1.EmployeeSalaryDetail.Rows.Count);
                }

                //decimal totalSalary = 0;

                //for (int i = 0; i < this.dgv.Rows.Count; i++)
                //{
                //    totalSalary += Convert.ToDecimal(this.dgv["salary", i].Value);
                //}

                //this.txtExpanse.Value = totalSalary;

                this.GetTotalPay();
            }
            catch (Exception ex)
            {

            }
        }

        private void cmbGroup_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //try
            //{
            //    this.dsEmployeeSalaryDetail1.Clear();

            //    string command;

            //    if (this.cmbGroup.SelectedValue.ToString() == "1")
            //    {
            //        command = "Select * from Employee where Branch_Id in (1,2,3) order by Branch_Id";
            //    }
            //    else
            //    {
            //        command = "Select * from Employee where Branch_Id in (4) order by Branch_Id";
            //    }
                
            //    DataTable dt = this.ObjCore.getDataSet(command, this.ObjCore.getHBCConnectionString()).Tables[0];

            //    for (int i = 0; i < dt.Rows.Count; i++)
            //    {
            //        DataRow dr = this.dsEmployeeSalaryDetail1.EmployeeSalaryDetail.NewRow();
            //        dr["Employee_Id"] = dt.Rows[i]["Id"];
            //        dr["Branch_Id"] = dt.Rows[i]["Branch_Id"];
            //        dr["Salary"] = dt.Rows[i]["Salary"];
            //        dr["GrowsAmount"] = dt.Rows[i]["Salary"];
            //        dr["Percentage"] = "0";
            //        dr["PercentAmount"] = "0";
            //        dr["AbsentDays"] = "0";
            //        dr["AbsentAmount"] = "0";
            //        dr["FinalAmount"] = dt.Rows[i]["Salary"];
            //        this.dsEmployeeSalaryDetail1.EmployeeSalaryDetail.Rows.InsertAt(dr, this.dsEmployeeSalaryDetail1.EmployeeSalaryDetail.Rows.Count);
            //    }
            //}
            //catch (Exception ex)
            //{

            //}
        }

        private void dgv_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    if (e.ColumnIndex == this.dgv.Columns["percentage"].Index)
                    {
                        if (this.txtRemaining.Value > 0)
                        {
                            decimal salary = Convert.ToDecimal(this.dgv["salary", e.RowIndex].Value);
                            decimal value = this.txtRemaining.Value;
                            decimal per = Convert.ToDecimal(this.dgv["percentage", e.RowIndex].Value);
                            int amount = Convert.ToInt32(value * (per / 100));
                            this.dgv["percentAmount", e.RowIndex].Value = amount.ToString();

                            this.Calculate(e.RowIndex);

                        }
                    }

                    if (e.ColumnIndex == this.dgv.Columns["absentDays"].Index)
                    {
                        decimal growAmount = Convert.ToDecimal(this.dgv["growsAmount", e.RowIndex].Value);
                        int Absentday = Convert.ToInt32(this.dgv["absentDays", e.RowIndex].Value);
                        decimal DaySalary = growAmount / 30;
                        int amount = (Int32)DaySalary * Absentday;
                        this.dgv["absentAmount", e.RowIndex].Value = amount.ToString();
                        this.Calculate(e.RowIndex);
                    }

                    if (e.ColumnIndex == this.dgv.Columns["Bonus"].Index)
                    {
                        this.Calculate(e.RowIndex);
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void Calculate(int RowIndex)
        {
            decimal salary = Convert.ToDecimal(this.dgv["salary", RowIndex].Value);
            decimal value = this.txtRemaining.Value;
            decimal per = Convert.ToDecimal(this.dgv["percentage", RowIndex].Value);
            int amount = Convert.ToInt32(value * (per / 100));
            this.dgv["percentAmount", RowIndex].Value = amount.ToString();

            int growAmount = (Int32)salary + amount;
            this.dgv["growsAmount", RowIndex].Value = growAmount.ToString();
            decimal AbsentAmount = Convert.ToDecimal(this.dgv["absentAmount", RowIndex].Value);

            decimal bonus = Convert.ToDecimal(this.dgv["Bonus", RowIndex].Value);

            int finalAmount = (((Int32)salary + amount) - (Int32)AbsentAmount) + (Int32)bonus;
            this.dgv["finalAmount", RowIndex].Value = finalAmount.ToString();

            this.GetTotalPay();
        }

        private void txtMajorAmount_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.txtRemaining.Value = this.txtMajorAmount.Value - this.txtExpanse.Value;
                this.ResetGrid();
            }
            catch (Exception ex)
            {

            }
        }

        private void txtExpanse_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.txtRemaining.Value = this.txtMajorAmount.Value - this.txtExpanse.Value;
                this.ResetGrid();
            }
            catch (Exception ex)
            {

            }
        }

        private void ResetGrid()
        {
            try
            {
                for (int i = 0; i < this.dgv.Rows.Count; i++)
                {
                    this.Calculate(i);
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void GetTotalPay()
        {
            try
            {
                decimal totalSalary = 0;
                decimal totalShare = 0;
                decimal finalPay = 0;
                for (int i = 0; i < this.dgv.Rows.Count; i++)
                {
                    finalPay += Convert.ToDecimal(this.dgv["finalAmount", i].Value);
                    totalSalary += Convert.ToDecimal(this.dgv["Salary", i].Value) + Convert.ToDecimal(this.dgv["Bonus", i].Value) - Convert.ToDecimal(this.dgv["AbsentAmount", i].Value);
                    totalShare += Convert.ToDecimal(this.dgv["PercentAmount", i].Value);
                }

                this.txtTotalPay.Text = finalPay.ToString();
                this.lbTotalSalary.Text = totalSalary.ToString();
                this.lbTotalPercentage.Text = totalShare.ToString();
            }
            catch (Exception ex)
            {

            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                this.cmbGroup.SelectedValue = 6;
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
                    com.CommandText = "spCreateEmployeeSalary";

                    com.Parameters.AddWithValue("@SalaryMonth", this.dtp.Value.ToString());
                    com.Parameters.AddWithValue("@MajorAmount", this.txtMajorAmount.Value.ToString());
                    com.Parameters.AddWithValue("@Expense", this.txtExpanse.Value.ToString());
                    com.Parameters.AddWithValue("@Remaining", this.txtRemaining.Value.ToString());
                    com.Parameters.AddWithValue("@GroupType", this.groupId);
                    com.Parameters.AddWithValue("@Description", this.txtDescription.Text.Trim());
                    com.Parameters.AddWithValue("@TotalPay", this.txtTotalPay.Text.Trim());

                    DataTable dt = new DataTable("Detail");
                    dt.Columns.Add(new DataColumn("Employee_Id", Type.GetType("System.Decimal")));
                    dt.Columns.Add(new DataColumn("Salary", Type.GetType("System.Decimal")));
                    dt.Columns.Add(new DataColumn("Percentage", Type.GetType("System.Decimal")));
                    dt.Columns.Add(new DataColumn("PercentAmount", Type.GetType("System.Decimal")));
                    dt.Columns.Add(new DataColumn("GrowsAmount", Type.GetType("System.Decimal")));
                    dt.Columns.Add(new DataColumn("AbsentDays", Type.GetType("System.Decimal")));
                    dt.Columns.Add(new DataColumn("AbsentAmount", Type.GetType("System.Decimal")));
                    dt.Columns.Add(new DataColumn("FinalAmount", Type.GetType("System.Decimal")));
                    dt.Columns.Add(new DataColumn("Branch_Id", Type.GetType("System.Decimal")));
                    dt.Columns.Add(new DataColumn("Bonus", Type.GetType("System.Decimal")));
                    for (int i = 0; i < this.dgv.Rows.Count; i++)
                    {
                        DataRow newRow = dt.NewRow();
                        newRow["Employee_Id"] = this.dgv["employee", i].Value;
                        newRow["Salary"] = this.dgv["salary", i].Value;
                        newRow["Percentage"] = this.dgv["percentage", i].Value;
                        newRow["PercentAmount"] = this.dgv["percentAmount", i].Value;
                        newRow["GrowsAmount"] = this.dgv["growsAmount", i].Value;
                        newRow["AbsentDays"] = this.dgv["absentDays", i].Value;
                        newRow["AbsentAmount"] = this.dgv["absentAmount", i].Value;
                        newRow["FinalAmount"] = this.dgv["finalAmount", i].Value;
                        newRow["Branch_Id"] = this.dgv["branch", i].Value;
                        newRow["Bonus"] = this.dgv["Bonus", i].Value;
                        dt.Rows.InsertAt(newRow, dt.Rows.Count);
                    }

                    System.IO.StringWriter sw = new System.IO.StringWriter();
                    dt.WriteXml(sw);
                    string xmlData = sw.ToString();

                    com.Parameters.AddWithValue("@Detail", xmlData);

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
                    com.CommandText = "spUpdateEmployeeSalary";

                    com.Parameters.AddWithValue("@Id", this.Id);
                    com.Parameters.AddWithValue("@SalaryMonth", this.dtp.Value.ToString());
                    com.Parameters.AddWithValue("@MajorAmount", this.txtMajorAmount.Value.ToString());
                    com.Parameters.AddWithValue("@Expense", this.txtExpanse.Value.ToString());
                    com.Parameters.AddWithValue("@Remaining", this.txtRemaining.Value.ToString());
                    com.Parameters.AddWithValue("@GroupType", this.groupId);
                    com.Parameters.AddWithValue("@Description", this.txtDescription.Text.Trim());
                    com.Parameters.AddWithValue("@TotalPay", this.txtTotalPay.Text.Trim());

                    DataTable dt = new DataTable("Detail");
                    dt.Columns.Add(new DataColumn("Employee_Id", Type.GetType("System.Decimal")));
                    dt.Columns.Add(new DataColumn("Salary", Type.GetType("System.Decimal")));
                    dt.Columns.Add(new DataColumn("Percentage", Type.GetType("System.Decimal")));
                    dt.Columns.Add(new DataColumn("PercentAmount", Type.GetType("System.Decimal")));
                    dt.Columns.Add(new DataColumn("GrowsAmount", Type.GetType("System.Decimal")));
                    dt.Columns.Add(new DataColumn("AbsentDays", Type.GetType("System.Decimal")));
                    dt.Columns.Add(new DataColumn("AbsentAmount", Type.GetType("System.Decimal")));
                    dt.Columns.Add(new DataColumn("FinalAmount", Type.GetType("System.Decimal")));
                    dt.Columns.Add(new DataColumn("Branch_Id", Type.GetType("System.Decimal")));
                    dt.Columns.Add(new DataColumn("Bonus", Type.GetType("System.Decimal")));
                    for (int i = 0; i < this.dgv.Rows.Count; i++)
                    {
                        DataRow newRow = dt.NewRow();
                        newRow["Employee_Id"] = this.dgv["employee", i].Value;
                        newRow["Salary"] = this.dgv["salary", i].Value;
                        newRow["Percentage"] = this.dgv["percentage", i].Value;
                        newRow["PercentAmount"] = this.dgv["percentAmount", i].Value;
                        newRow["GrowsAmount"] = this.dgv["growsAmount", i].Value;
                        newRow["AbsentDays"] = this.dgv["absentDays", i].Value;
                        newRow["AbsentAmount"] = this.dgv["absentAmount", i].Value;
                        newRow["FinalAmount"] = this.dgv["finalAmount", i].Value;
                        newRow["Branch_Id"] = this.dgv["branch", i].Value;
                        newRow["Bonus"] = this.dgv["Bonus", i].Value;
                        dt.Rows.InsertAt(newRow, dt.Rows.Count);
                    }

                    System.IO.StringWriter sw = new System.IO.StringWriter();
                    dt.WriteXml(sw);
                    string xmlData = sw.ToString();

                    com.Parameters.AddWithValue("@Detail", xmlData);

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
            }
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.Id != -1)
                {
                    frmExpensePayment obj = new frmExpensePayment();
                    obj.Amount = Convert.ToDecimal(this.txtTotalPay.Text);
                    obj.Invoice_Id = this.Id;
                    obj.TypeId = 1;
                    obj.StartPosition = FormStartPosition.CenterScreen;
                    obj.ShowDialog();
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
                if (this.Id != -1)
                {
                    frmRptEmployeeSalarySheet obj = new frmRptEmployeeSalarySheet();
                    obj.id = this.Id;
                    obj.branch_id = Convert.ToInt32(this.cmbGroup.SelectedValue.ToString());
                    obj.MdiParent = this.MdiParent;
                    obj.Show();
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void CmbFont_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                string command = "Update Settings set Value = '" + this.CmbFont.SelectedItem + "' where Id = 1";
                this.ObjCore.executeQuery(command, this.ObjCore.getHBCConnectionString());
                this.setFonts();
            }
            catch (Exception ex)
            {

            }
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //try
            //{
            //    DataTable dt = this.ObjCore.getDataSet("Select * from Employee where Id = " + this.dgv["employee", e.RowIndex].Value.ToString(), this.ObjCore.getHBCConnectionString()).Tables[0];

            //    System.IO.MemoryStream photoStream = new System.IO.MemoryStream((byte[])dt.Rows[0]["Photo"]);
            //    this.pbEmployee.Image = Image.FromStream(photoStream, true, true);
            //    this.pbEmployee.SizeMode = PictureBoxSizeMode.StretchImage;

            //    this.dgv.ClearSelection();
            //    this.dgv.Rows[e.RowIndex].Selected = true;
            //}
            //catch (Exception ex)
            //{

            //}
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //try
            //{
            //    DataTable dt = this.ObjCore.getDataSet("Select * from Employee where Id = " + this.dgv["employee", e.RowIndex].Value.ToString(), this.ObjCore.getHBCConnectionString()).Tables[0];

            //    System.IO.MemoryStream photoStream = new System.IO.MemoryStream((byte[])dt.Rows[0]["Photo"]);
            //    this.pbEmployee.Image = Image.FromStream(photoStream, true, true);
            //    this.pbEmployee.SizeMode = PictureBoxSizeMode.StretchImage;

            //    this.dgv.ClearSelection();
            //    this.dgv.Rows[e.RowIndex].Selected = true;
            //}
            //catch (Exception ex)
            //{

            //}

            //try
            //{
            //    this.dgv.ClearSelection();
            //    this.dgv.Rows[e.RowIndex].Selected = true;


            //}
            //catch (Exception ex)
            //{

            //}
        }

        private void dtp_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.Id == -1)
                {
                    //this.GetLoadEmployee();
                    if (this.groupId != 4)
                    {
                        //DataTable dt = this.ObjCore.getDataSet("Select AmountOne, dbo.funGetSalaries(1) from ProfitSharing where MONTH(Date) = MONTH('" + this.dtp.Value.ToString() + "') and  Year(Date) = Year('" + this.dtp.Value.ToString() + "')", this.ObjCore.getHBCConnectionString()).Tables[0];

                        //this.txtMajorAmount.Value = Convert.ToDecimal(dt.Rows[0][0]);
                        //this.txtExpanse.Value = Convert.ToDecimal(dt.Rows[0][1]);

                        if (this.allGroup == 0)
                        {
                            if (this.groupId == 1)
                            {
                                DataTable dt = this.ObjCore.getDataSet("Select AmountOne, dbo.funGetSalaries(1) from ProfitSharing where MONTH(Date) = MONTH('" + this.dtp.Value.ToString() + "') and  Year(Date) = Year('" + this.dtp.Value.ToString() + "')", this.ObjCore.getHBCConnectionString()).Tables[0];

                                this.txtMajorAmount.Value = Convert.ToDecimal(dt.Rows[0][0]);
                                this.txtExpanse.Value = Convert.ToDecimal(dt.Rows[0][1]);
                            }
                            else if (this.groupId == 2)
                            {
                                DataTable dt = this.ObjCore.getDataSet("Select AmountThree, dbo.funGetSalaries(2) from ProfitSharing where MONTH(Date) = MONTH('" + this.dtp.Value.ToString() + "') and  Year(Date) = Year('" + this.dtp.Value.ToString() + "')", this.ObjCore.getHBCConnectionString()).Tables[0];

                                this.txtMajorAmount.Value = Convert.ToDecimal(dt.Rows[0][0]);
                                this.txtExpanse.Value = Convert.ToDecimal(dt.Rows[0][1]);
                            }
                            else if (this.groupId == 3)
                            {
                                DataTable dt = this.ObjCore.getDataSet("Select AmountFour, dbo.funGetSalaries(3) from ProfitSharing where MONTH(Date) = MONTH('" + this.dtp.Value.ToString() + "') and  Year(Date) = Year('" + this.dtp.Value.ToString() + "')", this.ObjCore.getHBCConnectionString()).Tables[0];

                                this.txtMajorAmount.Value = Convert.ToDecimal(dt.Rows[0][0]);
                                this.txtExpanse.Value = Convert.ToDecimal(dt.Rows[0][1]);
                            }
                            else if (this.groupId == 4)
                            {
                                DataTable dt = this.ObjCore.getDataSet("Select AmountTwo, dbo.funGetSalaries(4) from ProfitSharing where MONTH(Date) = MONTH('" + this.dtp.Value.ToString() + "') and  Year(Date) = Year('" + this.dtp.Value.ToString() + "')", this.ObjCore.getHBCConnectionString()).Tables[0];

                                this.txtMajorAmount.Value = Convert.ToDecimal(dt.Rows[0][0]);
                                this.txtExpanse.Value = Convert.ToDecimal(dt.Rows[0][1]);
                            }
                            else if (this.groupId == 6)
                            {
                                DataTable dt = this.ObjCore.getDataSet("Select AmountOne + AmountThree + AmountFour + AmountTwo, dbo.funGetSalaries(1) + dbo.funGetSalaries(2) + dbo.funGetSalaries(3) + dbo.funGetSalaries(4) from ProfitSharing where MONTH(Date) = MONTH('" + this.dtp.Value.ToString() + "') and  Year(Date) = Year('" + this.dtp.Value.ToString() + "')", this.ObjCore.getHBCConnectionString()).Tables[0];

                                this.txtMajorAmount.Value = Convert.ToDecimal(dt.Rows[0][0]);
                                this.txtExpanse.Value = Convert.ToDecimal(dt.Rows[0][1]);
                            }
                        }
                        else
                        {

                            //DataTable dt = this.ObjCore.getDataSet("Select AmountOne, dbo.funGetSalaries(1) from ProfitSharing where MONTH(Date) = MONTH('" + this.dtp.Value.ToString() + "') and  Year(Date) = Year('" + this.dtp.Value.ToString() + "')", this.ObjCore.getHBCConnectionString()).Tables[0];

                            //this.txtMajorAmount.Value += Convert.ToDecimal(dt.Rows[0][0]);
                            //this.txtExpanse.Value += Convert.ToDecimal(dt.Rows[0][1]);

                            //DataTable dtt = this.ObjCore.getDataSet("Select AmountThree, dbo.funGetSalaries(2) from ProfitSharing where MONTH(Date) = MONTH('" + this.dtp.Value.ToString() + "') and  Year(Date) = Year('" + this.dtp.Value.ToString() + "')", this.ObjCore.getHBCConnectionString()).Tables[0];

                            //this.txtMajorAmount.Value += Convert.ToDecimal(dtt.Rows[0][0]);
                            //this.txtExpanse.Value += Convert.ToDecimal(dtt.Rows[0][1]);

                            //DataTable dttt = this.ObjCore.getDataSet("Select AmountFour, dbo.funGetSalaries(3) from ProfitSharing where MONTH(Date) = MONTH('" + this.dtp.Value.ToString() + "') and  Year(Date) = Year('" + this.dtp.Value.ToString() + "')", this.ObjCore.getHBCConnectionString()).Tables[0];

                            //this.txtMajorAmount.Value += Convert.ToDecimal(dttt.Rows[0][0]);
                            //this.txtExpanse.Value += Convert.ToDecimal(dttt.Rows[0][1]);

                            //DataTable dtttt = this.ObjCore.getDataSet("Select AmountTwo, dbo.funGetSalaries(4) from ProfitSharing where MONTH(Date) = MONTH('" + this.dtp.Value.ToString() + "') and  Year(Date) = Year('" + this.dtp.Value.ToString() + "')", this.ObjCore.getHBCConnectionString()).Tables[0];

                            //this.txtMajorAmount.Value += Convert.ToDecimal(dtttt.Rows[0][0]);
                            //this.txtExpanse.Value += Convert.ToDecimal(dtttt.Rows[0][1]);

                            //DataTable dttttt = this.ObjCore.getDataSet("Select AmountTwo, dbo.funGetSalaries(0) from ProfitSharing where MONTH(Date) = MONTH('" + this.dtp.Value.ToString() + "') and  Year(Date) = Year('" + this.dtp.Value.ToString() + "')", this.ObjCore.getHBCConnectionString()).Tables[0];

                            //this.txtMajorAmount.Value += Convert.ToDecimal(dttttt.Rows[0][0]);
                            //this.txtExpanse.Value += Convert.ToDecimal(dttttt.Rows[0][1]);

                            DataTable dt = this.ObjCore.getDataSet("Select AmountOne + AmountThree + AmountFour + AmountTwo, dbo.funGetSalaries(1) + dbo.funGetSalaries(2) + dbo.funGetSalaries(3) + dbo.funGetSalaries(4) + dbo.funGetSalaries(0) from ProfitSharing where MONTH(Date) = MONTH('" + this.dtp.Value.ToString() + "') and  Year(Date) = Year('" + this.dtp.Value.ToString() + "')", this.ObjCore.getHBCConnectionString()).Tables[0];

                            this.txtMajorAmount.Value = Convert.ToDecimal(dt.Rows[0][0]);
                            this.txtExpanse.Value = Convert.ToDecimal(dt.Rows[0][1]);

                        }

                        
                    }
                    else
                    {
                        DataTable dt = this.ObjCore.getDataSet("Select AmountTwo, dbo.funGetSalaries(0) from ProfitSharing where MONTH(Date) = MONTH('" + this.dtp.Value.ToString() + "') and  Year(Date) = Year('" + this.dtp.Value.ToString() + "')", this.ObjCore.getHBCConnectionString()).Tables[0];

                        this.txtMajorAmount.Value = Convert.ToDecimal(dt.Rows[0][0]);
                        this.txtExpanse.Value = Convert.ToDecimal(dt.Rows[0][1]);

                        
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void dgv_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataTable dt = this.ObjCore.getDataSet("Select * from Employee where Id = " + this.dgv["employee", e.RowIndex].Value.ToString(), this.ObjCore.getHBCConnectionString()).Tables[0];

                System.IO.MemoryStream photoStream = new System.IO.MemoryStream((byte[])dt.Rows[0]["Photo"]);
                this.pbEmployee.Image = Image.FromStream(photoStream, true, true);
                this.pbEmployee.SizeMode = PictureBoxSizeMode.StretchImage;

                this.dgv.ClearSelection();
                this.dgv.Rows[e.RowIndex].Selected = true;
            }
            catch (Exception ex)
            {

            }
        }

        private void cmbGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string groupid = this.cmbGroup.SelectedValue.ToString();

                if (groupid == "6")
                {
                    this.employeeSalaryDetailBindingSource.Filter = string.Empty;
                }
                else
                {
                    this.employeeSalaryDetailBindingSource.Filter = "Branch_Id = " + groupid;
                }

                this.GetTotalPay();                
            }
            catch (Exception)
            {
            }            
        }


    }
}
