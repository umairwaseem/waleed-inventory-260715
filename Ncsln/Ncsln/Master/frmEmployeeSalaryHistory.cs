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
    public partial class frmEmployeeSalaryHistory : Form
    {
        CoreClass ObjCore;

        public frmEmployeeSalaryHistory()
        {
            InitializeComponent();
            this.ObjCore = new CoreClass();
        }

        private void frmEmployeeSalaryHistory_Load(object sender, EventArgs e)
        {
            try
            {
                this.ObjCore.fillGridComboBoxWithAddNewOption((DataGridViewComboBoxColumn)this.dgv.Columns["group"], "Select Id, GroupName From BranchesGroup", this.ObjCore.getHBCConnectionString());

                this.dsEmployeeSalaryHistory1.Clear();
                this.daEmployeeSalaryHistory.SelectCommand.Connection.ConnectionString = this.ObjCore.getHBCConnectionString();
                this.daEmployeeSalaryHistory.Fill(this.dsEmployeeSalaryHistory1);


            }
            catch (Exception ex)
            {

            }
        }

        private void gridPaint()
        {
            try
            {
                for (int i = 0; i < this.dgv.Rows.Count; i++)
                {
                    if (this.dgv["group", i].Value.ToString() == "1")
                    {
                        this.dgv.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
                    }
                    else if (this.dgv["group", i].Value.ToString() == "2")
                    {
                        this.dgv.Rows[i].DefaultCellStyle.BackColor = Color.Purple;
                        this.dgv.Rows[i].DefaultCellStyle.ForeColor = Color.White;
                    }
                    else if (this.dgv["group", i].Value.ToString() == "3")
                    {
                        this.dgv.Rows[i].DefaultCellStyle.BackColor = Color.Blue;
                        this.dgv.Rows[i].DefaultCellStyle.ForeColor = Color.White;
                    }
                    else if (this.dgv["group", i].Value.ToString() == "4")
                    {
                        this.dgv.Rows[i].DefaultCellStyle.BackColor = Color.SlateGray;
                        this.dgv.Rows[i].DefaultCellStyle.ForeColor = Color.White;
                    }
                    else if (this.dgv["group", i].Value.ToString() == "6")
                    {
                        this.dgv.Rows[i].DefaultCellStyle.BackColor = Color.Green;
                        this.dgv.Rows[i].DefaultCellStyle.ForeColor = Color.White;
                    }
                    else
                    {
                        this.dgv.Rows[i].DefaultCellStyle.BackColor = Color.Beige;
                        this.dgv.Rows[i].DefaultCellStyle.ForeColor = Color.Black;
                    }
                }

                //this.dgv.Rows[0].DefaultCellStyle.BackColor = Color.Green;
                //this.dgv.Rows[0].DefaultCellStyle.ForeColor = Color.White;
            }
            catch (Exception ex)
            {

            }
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            try
            {
                this.dsEmployeeSalaryHistory1.Clear();
                this.daEmployeeSalaryHistory.SelectCommand.Connection.ConnectionString = this.ObjCore.getHBCConnectionString();
                this.daEmployeeSalaryHistory.Fill(this.dsEmployeeSalaryHistory1);

                
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
                        int group = Convert.ToInt32(this.dgv["group", e.RowIndex].Value);

                        frmEmployeeSalary obj = new frmEmployeeSalary();
                        obj.Id = id;
                        obj.groupId = group;
                        obj.MdiParent = this.MdiParent;
                        obj.Show();
                    }

                    if (e.ColumnIndex == this.dgv.Columns["Delete"].Index)
                    {
                        DialogResult question = MessageBox.Show("Are you sure to delete?", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (question == System.Windows.Forms.DialogResult.No)
                            return;

                        if (!CommonTask.Question(-1, true)) return;

                        int id = Convert.ToInt32(this.dgv["id", e.RowIndex].Value);

                        this.DeleteSalary(id);
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void DeleteSalary(int Id)
        {
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
                    com.CommandText = "spDeleteEmployeeSalary";

                    com.Parameters.AddWithValue("@Id", Id.ToString());

                    com.Parameters.Add(new SqlParameter("@Success", SqlDbType.Bit, 1, ParameterDirection.Output, false, 1, 0, "Success", DataRowVersion.Default, null));
                    com.Parameters.Add(new SqlParameter("@Message", SqlDbType.NVarChar, 200, ParameterDirection.Output, false, 200, 0, "Message", DataRowVersion.Default, null));
                    com.UpdatedRowSource = UpdateRowSource.OutputParameters;
                    com.ExecuteNonQuery();

                    success = Convert.ToBoolean(com.Parameters["@Success"].Value);
                    string message = com.Parameters["@Message"].Value.ToString();
                    string itemIdStock = string.Empty;

                    tran.Commit();
                    if (success)
                    {
                        //this.dgDetail.ClearSelection();
                        MessageBox.Show(message, "Stop", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                this.dsEmployeeSalaryHistory1.Clear();
                this.daEmployeeSalaryHistory.SelectCommand.Connection.ConnectionString = this.ObjCore.getHBCConnectionString();
                this.daEmployeeSalaryHistory.Fill(this.dsEmployeeSalaryHistory1);
            }
        }

        private void dgv_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            this.gridPaint();
        }
    }
}
