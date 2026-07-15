using System;
using System.Collections.Generic;
using System.Text;

namespace Ncsln.Classes
{
    class companyInfo
    {
        //public static string companyName = "World Style";
        //public static string invoiceCode = "W";

        //public static string companyName = "Office N Office";
        //public static string invoiceCode = "O";

        //public static string companyName = "Office Empire";
        //public static string invoiceCode = "E";

        public static string companyName = (SetupType.SoftType == SoftwareType.Master) ? CoreClass.GetSettings(2) : (SetupType.SoftType == SoftwareType.OfficeEmpire) ? "Office Empire" : (SetupType.SoftType == SoftwareType.OfficeMaster) ? "Office Master" : (SetupType.SoftType == SoftwareType.OfficenOffice) ? "Office N Office" : "World Style";
        public static string invoiceCode = (SetupType.SoftType == SoftwareType.Master) ? CoreClass.GetSettings(3) : (SetupType.SoftType == SoftwareType.OfficeEmpire) ? "E" : (SetupType.SoftType == SoftwareType.OfficeMaster) ? "Q" : (SetupType.SoftType == SoftwareType.OfficenOffice) ? "O" : "W";
        public static string branchCode = (SetupType.SoftType == SoftwareType.Master) ? CoreClass.GetSettings(4) : (SetupType.SoftType == SoftwareType.OfficeEmpire) ? "4" : (SetupType.SoftType == SoftwareType.OfficeMaster) ? "1" : (SetupType.SoftType == SoftwareType.OfficenOffice) ? "3" : "2";

        public static string address = "-";
        public static string phone = "-";
        public static string email = "";
        public static string web = "-";
        public static string faxNo = "";
    }
}
