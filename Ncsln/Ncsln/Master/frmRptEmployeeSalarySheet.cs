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
    public partial class frmRptEmployeeSalarySheet : Form
    {
        CoreClass ObjCore;
        public int id;
        public int branch_id;

        public frmRptEmployeeSalarySheet()
        {
            InitializeComponent();
            this.ObjCore = new CoreClass();
        }

        private void frmRptEmployeeSalarySheet_Load(object sender, EventArgs e)
        {
            try
            {
                if (this.branch_id == 6)
                {
                    this.dsEmployeeSalarySheet1.Clear();
                    this.dsEmployeeSalarySheet1.EnforceConstraints = false;
                    this.daEmployeeSalarySheetAll.SelectCommand.Connection.ConnectionString = this.ObjCore.getHBCConnectionString();
                    this.daEmployeeSalarySheetAll.SelectCommand.Parameters["@Id"].Value = this.id.ToString();
                    this.daEmployeeSalarySheetAll.Fill(this.dsEmployeeSalarySheet1);
                }
                else
                {
                    this.dsEmployeeSalarySheet1.Clear();
                    this.dsEmployeeSalarySheet1.EnforceConstraints = false;
                    this.daEmployeeSalarySheet.SelectCommand.Connection.ConnectionString = this.ObjCore.getHBCConnectionString();
                    this.daEmployeeSalarySheet.SelectCommand.Parameters["@Id"].Value = this.id.ToString();
                    this.daEmployeeSalarySheet.SelectCommand.Parameters["@Branch_Id"].Value = this.branch_id.ToString();
                    this.daEmployeeSalarySheet.Fill(this.dsEmployeeSalarySheet1);
                }

                docEmployeeSalarySheet rpt = new docEmployeeSalarySheet();                
                rpt.SetDataSource(this.dsEmployeeSalarySheet1);
                rpt.SetParameterValue("BranchName", this.BranchName());
                this.crv.ReportSource = rpt;
            }
            catch (Exception ex)
            {

            }
        }

        private string BranchName()
        {
            string BranchName = "ALL";

            if (this.branch_id == 1)
            {
                BranchName = "Office Master";
            } 
            else if (this.branch_id == 2)
            {
                BranchName = "World Style";
            }
            else if (this.branch_id == 3)
            {
                BranchName = "Office N Office";
            }
            else if (this.branch_id == 4)
            {
                BranchName = "Office Empire";
            }
            else if (this.branch_id == 5)
            {
                BranchName = "HBC";
            }

            return BranchName;
        }
    }
}
