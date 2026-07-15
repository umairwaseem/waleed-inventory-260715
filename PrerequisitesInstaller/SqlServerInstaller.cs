using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.Text;
using System.Management;


namespace PrerequisitesInstaller
{
    [RunInstaller(true)]
    public partial class SqlServerInstaller : System.Configuration.Install.Installer
    {
        public SqlServerInstaller()
        {
            InitializeComponent();
        }

        public override void Install(IDictionary stateSaver)
        {
            base.Install(stateSaver);

            if (EnumerateSQLInstances())
            {
                //Console.WriteLine("There are no instances of SQL Server 2005 or SQL Server 2008 installed");
                //System.Windows.Forms.MessageBox.Show("AGT Instance found.");
                
            }
            else
            {
                //System.Windows.Forms.MessageBox.Show("AGT Instance not found.");
            }
        }

        public static bool EnumerateSQLInstances()
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

            //Console.WriteLine("SQL Server database instances discovered :");

            string instanceName = string.Empty;

            string serviceName = string.Empty;

            string version = string.Empty;

            string edition = string.Empty;

            //Console.WriteLine("Instance Name \t ServiceName \t Edition \t Version \t");

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

                //Console.Write("{0} \t", instanceName);

                //Console.Write("{0} \t", serviceName);

                //Console.Write("{0} \t", edition);

                //Console.WriteLine("{0} \t", version);
            }
            return found;
        }

        /// Method returns the correct SQL namespace to use to detect SQL Server instances.      

        public static string GetCorrectWmiNameSpace()
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
                Console.WriteLine("Exception = " + e.Message);
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
        /// method extracts the instance name from the service name

        public static string GetInstanceNameFromServiceName(string serviceName)
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

        /// Returns the WMI property value for a given property name for a particular SQL Server service Name

        /// <param name="serviceName">The service name for the SQL Server engine service to query for</param>

        /// <param name="wmiNamespace">The wmi namespace to connect to </param>

        /// <param name="propertyName">The property name whose value is required</param>

        public static string GetWmiPropertyValueForEngineService(string serviceName, string wmiNamespace, string propertyName)
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
