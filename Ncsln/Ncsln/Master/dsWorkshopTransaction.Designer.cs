using System.Data;

namespace Ncsln.Master
{
    public partial class dsWorkshopTransaction : DataSet
    {
        private readonly DataTable tableWorkshopTransaction;

        public dsWorkshopTransaction()
        {
            this.DataSetName = "dsWorkshopTransaction";
            this.Namespace = "http://tempuri.org/dsWorkshopTransaction.xsd";
            this.tableWorkshopTransaction = new DataTable("WorkshopTransaction");
            this.tableWorkshopTransaction.Columns.Add("Id", typeof(int));
            this.tableWorkshopTransaction.Columns.Add("WorkshopAccountId", typeof(int));
            this.tableWorkshopTransaction.Columns.Add("AccountName", typeof(string));
            this.tableWorkshopTransaction.Columns.Add("BankId", typeof(int));
            this.tableWorkshopTransaction.Columns.Add("BankTitle", typeof(string));
            this.tableWorkshopTransaction.Columns.Add("AccountNo", typeof(string));
            this.tableWorkshopTransaction.Columns.Add("TransactionDate", typeof(System.DateTime));
            this.tableWorkshopTransaction.Columns.Add("Description", typeof(string));
            this.tableWorkshopTransaction.Columns.Add("Amount", typeof(decimal));
            this.tableWorkshopTransaction.Columns.Add("IsPayment", typeof(bool));
            this.tableWorkshopTransaction.Columns.Add("TransactionType", typeof(string));
            this.Tables.Add(this.tableWorkshopTransaction);
        }

        public DataTable WorkshopTransaction { get { return this.tableWorkshopTransaction; } }
    }
}
