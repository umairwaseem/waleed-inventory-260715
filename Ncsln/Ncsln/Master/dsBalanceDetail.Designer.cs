using System.Data;

namespace Ncsln.Master
{
    public partial class dsBalanceDetail : DataSet
    {
        private readonly DataTable tableBalanceDetail;

        public dsBalanceDetail()
        {
            this.DataSetName = "dsBalanceDetail";
            this.Namespace = "http://tempuri.org/dsBalanceDetail.xsd";
            this.tableBalanceDetail = new DataTable("BalanceDetail");
            this.tableBalanceDetail.Columns.Add("Id", typeof(int));
            this.tableBalanceDetail.Columns.Add("Title", typeof(string));
            this.tableBalanceDetail.Columns.Add("Notes", typeof(string));
            this.Tables.Add(this.tableBalanceDetail);
        }

        public DataTable BalanceDetail { get { return this.tableBalanceDetail; } }
    }
}
