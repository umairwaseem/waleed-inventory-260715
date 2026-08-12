namespace Ncsln.Master
{
    using System;
    using System.Data;

    [Serializable]
    public partial class dsAdditionalAccountLedger : DataSet
    {
        private readonly DataTable tableAdditionalAccountLedger;

        public dsAdditionalAccountLedger()
        {
            this.DataSetName = "dsAdditionalAccountLedger";
            this.Namespace = "http://tempuri.org/dsAdditionalAccountLedger.xsd";
            this.tableAdditionalAccountLedger = new DataTable("AdditionalAccountLedger");
            this.tableAdditionalAccountLedger.Columns.Add("SrNo", typeof(int));
            this.tableAdditionalAccountLedger.Columns.Add("TranDate", typeof(DateTime));
            this.tableAdditionalAccountLedger.Columns.Add("SourceType", typeof(string));
            this.tableAdditionalAccountLedger.Columns.Add("ReferenceId", typeof(int));
            this.tableAdditionalAccountLedger.Columns.Add("AccountName", typeof(string));
            this.tableAdditionalAccountLedger.Columns.Add("BankId", typeof(int));
            this.tableAdditionalAccountLedger.Columns.Add("BankTitle", typeof(string));
            this.tableAdditionalAccountLedger.Columns.Add("AccountNo", typeof(string));
            this.tableAdditionalAccountLedger.Columns.Add("Detail", typeof(string));
            this.tableAdditionalAccountLedger.Columns.Add("ReceiveAmount", typeof(decimal));
            this.tableAdditionalAccountLedger.Columns.Add("PaymentAmount", typeof(decimal));
            this.tableAdditionalAccountLedger.Columns.Add("Balance", typeof(decimal));
            this.Tables.Add(this.tableAdditionalAccountLedger);
        }

        public DataTable AdditionalAccountLedger { get { return this.tableAdditionalAccountLedger; } }
    }
}
