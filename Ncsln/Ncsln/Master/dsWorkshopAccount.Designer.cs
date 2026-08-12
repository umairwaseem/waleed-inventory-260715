using System.Data;

namespace Ncsln.Master
{
    public partial class dsWorkshopAccount : DataSet
    {
        private readonly DataTable tableWorkshopAccount;

        public dsWorkshopAccount()
        {
            this.DataSetName = "dsWorkshopAccount";
            this.Namespace = "http://tempuri.org/dsWorkshopAccount.xsd";
            this.tableWorkshopAccount = new DataTable("WorkshopAccount");
            this.tableWorkshopAccount.Columns.Add("Id", typeof(int));
            this.tableWorkshopAccount.Columns.Add("AccountName", typeof(string));
            this.tableWorkshopAccount.Columns.Add("Notes", typeof(string));
            this.Tables.Add(this.tableWorkshopAccount);
        }

        public DataTable WorkshopAccount { get { return this.tableWorkshopAccount; } }
    }
}
