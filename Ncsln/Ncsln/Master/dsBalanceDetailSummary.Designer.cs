using System;
using System.Data;

namespace Ncsln.Master
{
    public partial class dsBalanceDetailSummary : DataSet
    {
        private readonly DataTable tableBalanceDetailSummary;

        public dsBalanceDetailSummary()
        {
            this.DataSetName = "dsBalanceDetailSummary";
            this.Namespace = "http://tempuri.org/dsBalanceDetailSummary.xsd";
            this.tableBalanceDetailSummary = new DataTable("BalanceDetailSummary");
            this.tableBalanceDetailSummary.Columns.Add("RowType", typeof(string));
            this.tableBalanceDetailSummary.Columns.Add("DisplayOrder", typeof(int));
            this.tableBalanceDetailSummary.Columns.Add("TranDate", typeof(DateTime));
            this.tableBalanceDetailSummary.Columns.Add("Title", typeof(string));
            this.tableBalanceDetailSummary.Columns.Add("Description", typeof(string));
            this.tableBalanceDetailSummary.Columns.Add("Amount", typeof(decimal));
            this.tableBalanceDetailSummary.Columns.Add("Balance", typeof(decimal));
            this.tableBalanceDetailSummary.Columns.Add("BalanceDetailId", typeof(int));
            this.tableBalanceDetailSummary.Columns.Add("ActionText", typeof(string));
            this.Tables.Add(this.tableBalanceDetailSummary);
        }

        public DataTable BalanceDetailSummary { get { return this.tableBalanceDetailSummary; } }
    }
}
