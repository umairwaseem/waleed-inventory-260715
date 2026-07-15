using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ncsln.Classes
{
    class GetCompanyInfo
    {
        public GetCompanyInfo()
        {
        }

        public dsCompanyName fillCompanyInfo()
        {
            dsCompanyName ds = new dsCompanyName();
            System.Data.DataRow newRow = ds.tbl_CompanySettings.NewRow();
            newRow["CompanyId"] = 1;
            newRow["CompanyName"] = Ncsln.Classes.companyInfo.companyName;
            newRow["PhoneNo"] = Ncsln.Classes.companyInfo.phone;
            newRow["Address"] = Ncsln.Classes.companyInfo.address;
            ds.tbl_CompanySettings.Rows.Add(newRow);
            //CoreControl.CoreClass core = new CoreControl.CoreClass();
            //System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter();
            //da.SelectCommand = new System.Data.SqlClient.SqlCommand();
            //da.SelectCommand.Connection = new System.Data.SqlClient.SqlConnection();
            //da.SelectCommand.Connection.ConnectionString = core.getConnectionString();
            //da.SelectCommand.CommandText = "Select CompanyId, CompanyLogo from tbl_CompanySettings Where CompanyId = 1";
            //da.SelectCommand.Connection.Open();
            //da.Fill(ds.tbl_CompanySettings);
            //da.SelectCommand.Connection.Close();

            //ds.tbl_CompanySettings.Rows[0]["CompanyName"] = Ncsln.Classes.companyInfo.companyName;
            //ds.tbl_CompanySettings.Rows[0]["PhoneNo"] = Ncsln.Classes.companyInfo.phone;
            //ds.tbl_CompanySettings.Rows[0]["Address"] = Ncsln.Classes.companyInfo.address;
            return ds;
        }
    }
}
