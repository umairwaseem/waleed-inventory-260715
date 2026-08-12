using System;
using System.Data;

namespace Ncsln.Master
{
    public partial class dsBalanceDetailTransaction : DataSet
    {
        private readonly DataTable tableBalanceDetailTransaction;

        public dsBalanceDetailTransaction()
        {
            this.DataSetName = "dsBalanceDetailTransaction";
            this.Namespace = "http://tempuri.org/dsBalanceDetailTransaction.xsd";
            this.tableBalanceDetailTransaction = new DataTable("BalanceDetailTransaction");
            this.tableBalanceDetailTransaction.Columns.Add("Id", typeof(int));
            this.tableBalanceDetailTransaction.Columns.Add("BalanceDetailId", typeof(int));
            this.tableBalanceDetailTransaction.Columns.Add("Title", typeof(string));
            this.tableBalanceDetailTransaction.Columns.Add("TransactionDate", typeof(DateTime));
            this.tableBalanceDetailTransaction.Columns.Add("Description", typeof(string));
            this.tableBalanceDetailTransaction.Columns.Add("Amount", typeof(decimal));
            this.Tables.Add(this.tableBalanceDetailTransaction);
        }

        public DataTable BalanceDetailTransaction { get { return this.tableBalanceDetailTransaction; } }
    }
}
