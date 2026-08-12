namespace Ncsln.Master
{
    using System;
    using System.Data;

    [Serializable]
    public partial class dsAdditionalAccountTransaction : DataSet
    {
        private readonly DataTable tableAdditionalAccountTransaction;

        public dsAdditionalAccountTransaction()
        {
            this.DataSetName = "dsAdditionalAccountTransaction";
            this.Namespace = "http://tempuri.org/dsAdditionalAccountTransaction.xsd";
            this.tableAdditionalAccountTransaction = new DataTable("AdditionalAccountTransaction");
            this.tableAdditionalAccountTransaction.Columns.Add("Id", typeof(int));
            this.tableAdditionalAccountTransaction.Columns.Add("AdditionalAccountId", typeof(int));
            this.tableAdditionalAccountTransaction.Columns.Add("AccountName", typeof(string));
            this.tableAdditionalAccountTransaction.Columns.Add("BankId", typeof(int));
            this.tableAdditionalAccountTransaction.Columns.Add("BankTitle", typeof(string));
            this.tableAdditionalAccountTransaction.Columns.Add("AccountNo", typeof(string));
            this.tableAdditionalAccountTransaction.Columns.Add("TransactionDate", typeof(DateTime));
            this.tableAdditionalAccountTransaction.Columns.Add("Description", typeof(string));
            this.tableAdditionalAccountTransaction.Columns.Add("Amount", typeof(decimal));
            this.tableAdditionalAccountTransaction.Columns.Add("IsPayment", typeof(bool));
            this.Tables.Add(this.tableAdditionalAccountTransaction);
        }

        public DataTable AdditionalAccountTransaction { get { return this.tableAdditionalAccountTransaction; } }
    }
}
