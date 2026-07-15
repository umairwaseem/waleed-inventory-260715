using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Management;

namespace Ncsln.Forms
{
    public partial class frmTestQueries : Form
    {
        public frmTestQueries()
        {
            InitializeComponent();
            str = new StringBuilder();
        }
        StringBuilder str;
        private void frmTestQueries_Load(object sender, EventArgs e)
        {

        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            str.Clear();
            if (EnumerateSQLInstances())
            {
                str.Append("Sql Server instance found");
            }
            else
            {
                str.Append("There are no instances of SQL Server 2005 or SQL Server 2008 installed");
            }
            this.txtResult.Text = str.ToString();
        }

        public bool EnumerateSQLInstances()
        {
            string correctNamespace = GetCorrectWmiNameSpace();

            if (string.Equals(correctNamespace, string.Empty))
            {
                return false;
            }

            string query = string.Format("select * from SqlServiceAdvancedProperty where SQLServiceType = 1 and PropertyName = 'instanceID'");

            ManagementObjectSearcher getSqlEngine = new ManagementObjectSearcher(correctNamespace, query);

            if (getSqlEngine.Get().Count == 0)
            {
                return false;
            }

            //str.Append("SQL Server database instances discovered :");

            string instanceName = string.Empty;

            string serviceName = string.Empty;

            string version = string.Empty;

            string edition = string.Empty;

            //str.Append("\n\nInstance Name \t ServiceName \t Edition \t Version \t\n\n");

            bool found = false;

            foreach (ManagementObject sqlEngine in getSqlEngine.Get())
            {
                serviceName = sqlEngine["ServiceName"].ToString();

                instanceName = GetInstanceNameFromServiceName(serviceName);

                version = GetWmiPropertyValueForEngineService(serviceName, correctNamespace, "Version");

                edition = GetWmiPropertyValueForEngineService(serviceName, correctNamespace, "SKUNAME");

                if (instanceName == "AGT")
                {
                    found = true;
                    break;
                }
                //str.Append(instanceName + "\t");

                //str.Append(serviceName + "\t");

                //str.Append(edition + "\t");

                //str.Append(version + "\t");
            }
            return found;
        }

        public string GetCorrectWmiNameSpace()
        {
            String wmiNamespaceToUse = "root\\Microsoft\\sqlserver";

            List<string> namespaces = new List<string>();

            try
            {
                ManagementClass nsClass = new ManagementClass(new ManagementScope(wmiNamespaceToUse), new ManagementPath("__namespace"), null);

                foreach (ManagementObject ns in nsClass.GetInstances())
                {
                    namespaces.Add(ns["Name"].ToString());
                }
            }
            catch (ManagementException e)
            {
                str.Append("Exception = " + e.Message);
            }

            if (namespaces.Count > 0)
            {
                if (namespaces.Contains("ComputerManagement10"))
                {
                    //use katmai+ namespace
                    wmiNamespaceToUse = wmiNamespaceToUse + "\\ComputerManagement10";
                }
                else if (namespaces.Contains("ComputerManagement"))
                {
                    //use yukon namespace
                    wmiNamespaceToUse = wmiNamespaceToUse + "\\ComputerManagement";
                }
                else
                {
                    wmiNamespaceToUse = string.Empty;
                }
            }
            else
            {
                wmiNamespaceToUse = string.Empty;
            }

            return wmiNamespaceToUse;
        }

        public string GetInstanceNameFromServiceName(string serviceName)
        {
            if (!string.IsNullOrEmpty(serviceName))
            {
                if (string.Equals(serviceName, "MSSQLSERVER", StringComparison.OrdinalIgnoreCase))
                {
                    return serviceName;
                }
                else
                {
                    return serviceName.Substring(serviceName.IndexOf('$') + 1, serviceName.Length - serviceName.IndexOf('$') - 1);
                }
            }
            else
            {
                return string.Empty;
            }
        }

        public string GetWmiPropertyValueForEngineService(string serviceName, string wmiNamespace, string propertyName)
        {
            string propertyValue = string.Empty;

            string query = String.Format("select * from SqlServiceAdvancedProperty where SQLServiceType = 1 and PropertyName = '{0}' and ServiceName = '{1}'", propertyName, serviceName);

            ManagementObjectSearcher propertySearcher = new ManagementObjectSearcher(wmiNamespace, query);

            foreach (ManagementObject sqlEdition in propertySearcher.Get())
            {
                propertyValue = sqlEdition["PropertyStrValue"].ToString();
            }

            return propertyValue;
        }
    }
}
