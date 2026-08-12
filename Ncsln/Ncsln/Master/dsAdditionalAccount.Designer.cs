namespace Ncsln.Master
{
    using System;
    using System.Data;

    [Serializable]
    public partial class dsAdditionalAccount : DataSet
    {
        private readonly DataTable tableAdditionalAccount;

        public dsAdditionalAccount()
        {
            this.DataSetName = "dsAdditionalAccount";
            this.Namespace = "http://tempuri.org/dsAdditionalAccount.xsd";
            this.tableAdditionalAccount = new DataTable("AdditionalAccount");
            this.tableAdditionalAccount.Columns.Add("Id", typeof(int));
            this.tableAdditionalAccount.Columns.Add("AccountName", typeof(string));
            this.tableAdditionalAccount.Columns.Add("Notes", typeof(string));
            this.Tables.Add(this.tableAdditionalAccount);
        }

        public DataTable AdditionalAccount { get { return this.tableAdditionalAccount; } }
    }
}
