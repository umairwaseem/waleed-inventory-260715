using System.Data;

namespace Ncsln.Master
{
    public partial class dsWorkshopLedger : DataSet
    {
        private readonly DataTable tableWorkshopLedger;

        public dsWorkshopLedger()
        {
            this.DataSetName = "dsWorkshopLedger";
            this.Namespace = "http://tempuri.org/dsWorkshopLedger.xsd";
            this.tableWorkshopLedger = new DataTable("WorkshopLedger");
            this.tableWorkshopLedger.Columns.Add("SrNo", typeof(int));
            this.tableWorkshopLedger.Columns.Add("TranDate", typeof(System.DateTime));
            this.tableWorkshopLedger.Columns.Add("RowType", typeof(string));
            this.tableWorkshopLedger.Columns.Add("ReferenceId", typeof(int));
            this.tableWorkshopLedger.Columns.Add("AccountName", typeof(string));
            this.tableWorkshopLedger.Columns.Add("BankId", typeof(int));
            this.tableWorkshopLedger.Columns.Add("BankTitle", typeof(string));
            this.tableWorkshopLedger.Columns.Add("AccountNo", typeof(string));
            this.tableWorkshopLedger.Columns.Add("Detail", typeof(string));
            this.tableWorkshopLedger.Columns.Add("ReceiveAmount", typeof(decimal));
            this.tableWorkshopLedger.Columns.Add("PaymentAmount", typeof(decimal));
            this.Tables.Add(this.tableWorkshopLedger);
        }

        public DataTable WorkshopLedger { get { return this.tableWorkshopLedger; } }
    }
}
