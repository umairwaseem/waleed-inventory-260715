using Ncsln.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Ncsln.Inventory.Reports
{
    public partial class frmRptHBCChallan : Form
    {
        CoreClass ObjCore;
        public string Id;
        public frmRptHBCChallan()
        {
            InitializeComponent();
            this.ObjCore = new CoreClass();
        }

        private void frmRptHBCChallan_Load(object sender, EventArgs e)
        {
            try
            {
                string BranchCode = string.Empty;
                if (SetupType.SoftType == SoftwareType.Master)
                {
                    BranchCode = this.ObjCore.GetSetting(4);
                }
                else
                {
                    BranchCode = companyInfo.branchCode.ToString();
                }

                this.dsHBCChallan1.Clear();
                this.dsHBCChallan1.EnforceConstraints = false;
                this.daHBCChallan.SelectCommand.Connection.ConnectionString = this.ObjCore.getClientConnectionString();
                this.daHBCChallan.SelectCommand.Parameters["@Id"].Value = this.Id;
                this.daHBCChallan.SelectCommand.Parameters["@BId"].Value = BranchCode;
                this.daHBCChallan.Fill(this.dsHBCChallan1);

                docHBCChallan rpt = new docHBCChallan();
                rpt.SetDataSource(this.dsHBCChallan1);
                if (SetupType.SoftType == SoftwareType.Master)
                {
                    rpt.SetParameterValue("BranchName", this.ObjCore.GetSetting(2));
                }
                else
                {
                    rpt.SetParameterValue("BranchName", companyInfo.companyName);
                }

                this.crv.ReportSource = rpt;
            }
            catch (Exception ex)
            {

            }
        }
    }
}
