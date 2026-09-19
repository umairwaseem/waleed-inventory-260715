using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Xml;
using System.Text.RegularExpressions;
using System.Security.Cryptography;


namespace Ncsln.Classes
{
    public class CoreClass
    {
        private static readonly object RightsCacheLock = new object();
        private static readonly Dictionary<string, DataTable> RightsCache = new Dictionary<string, DataTable>(StringComparer.OrdinalIgnoreCase);
        private static readonly Dictionary<string, int> FormIdCache = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

        public SqlConnection con;
        public SqlCommand com;
        public CoreClass()
        {
            //
            // TODO: Add constructor logic here
            //
            con = new SqlConnection(this.getConnectionString());

        }

        public string getHBCConnectionString()
        {
            return "Data Source=202.165.249.169;Initial Catalog=waleedinventoryServer;User ID=cruxtech;Password=crux123";
            //return "Data Source=.;Initial Catalog=InventoryServer;Integrated Security=True";
        }

        public static string getHBCConnectionStrings()
        {
            return "Data Source=202.165.249.169;Initial Catalog=waleedinventoryServer;User ID=cruxtech;Password=crux123";
            //return "Data Source=.;Initial Catalog=InventoryServer;Integrated Security=True";
       } 

        public string getConnectionString()
        {
            return Ncsln.Properties.Settings.Default.constring;
        }

        public string getClientConnectionString()
        {
            if (SetupType.SoftType == SoftwareType.Master)
            {
                return Ncsln.Properties.Settings.Default.ClientConString;
            }
            else
            {
                return Ncsln.Properties.Settings.Default.constring;
            }
            
        }

        public string getClientConnectionStringName()
        {
            if (SetupType.SoftType == SoftwareType.Master)
            {
                string temp = Ncsln.Properties.Settings.Default.ClientConStringName;
                return Ncsln.Properties.Settings.Default.ClientConStringName;
            }
            else
            {
                if (SetupType.SoftType == SoftwareType.OfficeEmpire)
                {
                    return "InventoryEntities-oe";
                }
                else if (SetupType.SoftType == SoftwareType.OfficeMaster)
                {
                    return "InventoryEntities-om";
                }
                else if (SetupType.SoftType == SoftwareType.OfficenOffice)
                {
                    return "InventoryEntities-oo";
                }
                else
                {
                    return "InventoryEntities-ws";
                }
            }
        }

        public string getHBCConnectionStringName()
        {
            return "InventoryEntities-hbc";
        }

        public string getServerName()
        {            
            if (SetupType.SoftType == SoftwareType.Master)
            {
                return Ncsln.Properties.Settings.Default.ServerName;
            }
            else
            {
                if (SetupType.SoftType == SoftwareType.OfficeEmpire)
                {
                    return "Flex world";
                }
                else if (SetupType.SoftType == SoftwareType.OfficeMaster)
                {
                    return "Flex world";
                }
                else if (SetupType.SoftType == SoftwareType.OfficenOffice)
                {
                    return "Flex world 2";
                }
                else
                {
                    return "Flex world";
                }
            }
        }

        public bool ConnectionCheck(string ConString)
        {
            try
            {
                SqlConnection NewCon = new SqlConnection();
                NewCon.ConnectionString = ConString;
                NewCon.Open();

                NewCon.Close();

                return true;
            }
            catch (Exception Ex)
            {
                return false;
            }
        }

        public SqlDataReader getDataReader(string query, string ConString)
        {
            SqlDataReader dr;
            try
            {
                //if (this.con.State == ConnectionState.Open)
                //    this.con.Close();
                SqlConnection NewCon = new SqlConnection(ConString);

                this.com = new SqlCommand(query, NewCon);
                NewCon.Open();
                dr = this.com.ExecuteReader();
                //NewCon.Close();
                return dr;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet getDataSet(string query)
        {
            DataSet ds;
            try
            {
                ds = new DataSet();
                if (this.con.State == ConnectionState.Open)
                    this.con.Close();
                
                SqlDataAdapter da = new SqlDataAdapter(query, this.con);
                this.con.Open();
                da.Fill(ds);
                this.con.Close();
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public DataSet getDataSet(string query, string ConString)
        {
            DataSet ds;
            try
            {
                ds = new DataSet();
                //if (this.con.State == ConnectionState.Open)
                //    this.con.Close();

                SqlConnection NewCon = new SqlConnection(ConString);
                
                SqlDataAdapter da = new SqlDataAdapter(query, NewCon);
                da.SelectCommand.CommandTimeout = 120;
                NewCon.Open();
                da.Fill(ds);
                NewCon.Close();
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void executeQuery(string query)
        {
            try
            {
                if (this.con.State == ConnectionState.Open)
                    this.con.Close();
                this.com = new SqlCommand(query, this.con);
                this.con.Open();
                this.com.ExecuteNonQuery();
                this.con.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void executeQuery(string query, string ConString)
        {
            try
            {
                SqlConnection con = new SqlConnection(ConString);


                this.com = new SqlCommand(query, con);
                con.Open();
                this.com.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string getUserId()
        {
            return DecryptSetting(Ncsln.Properties.Settings.Default.user);
        }

        public string getUserName()
        {
            return DecryptSetting(Ncsln.Properties.Settings.Default.UserName);
        }

        public bool getDefaultEntry()
        {
            bool value;
            return Boolean.TryParse(DecryptSetting(Ncsln.Properties.Settings.Default.DefaultEntry), out value) && value;
        }

        public int getGroupId()
        {
            int value;
            return Int32.TryParse(DecryptSetting(Ncsln.Properties.Settings.Default.Group_Id), out value) ? value : 0;
        }

        public void SaveUserSession(string userId, string userName, bool defaultEntry, int groupId)
        {
            Ncsln.Properties.Settings.Default.user = EncryptSetting(userId);
            Ncsln.Properties.Settings.Default.UserName = EncryptSetting(userName);
            Ncsln.Properties.Settings.Default.DefaultEntry = EncryptSetting(defaultEntry.ToString());
            Ncsln.Properties.Settings.Default.Group_Id = EncryptSetting(groupId.ToString());
            Ncsln.Properties.Settings.Default.Save();
            ClearUserRightsCache();
        }

        private static string EncryptSetting(string value)
        {
            if (value == null) return String.Empty;
            byte[] protectedValue = ProtectedData.Protect(Encoding.UTF8.GetBytes(value), null, DataProtectionScope.CurrentUser);
            return Convert.ToBase64String(protectedValue);
        }

        private static string DecryptSetting(string value)
        {
            if (String.IsNullOrWhiteSpace(value)) return String.Empty;
            try
            {
                byte[] encryptedValue = Convert.FromBase64String(value);
                byte[] plainValue = ProtectedData.Unprotect(encryptedValue, null, DataProtectionScope.CurrentUser);
                return Encoding.UTF8.GetString(plainValue);
            }
            catch (Exception)
            {
                return String.Empty;
            }
        }

        public void ClearUserRightsCache()
        {
            lock (RightsCacheLock)
            {
                RightsCache.Clear();
                FormIdCache.Clear();
            }
        }

        public void RefreshUserRightsCache()
        {
            ClearUserRightsCache();
            EnsureRightsLoaded(this.getClientConnectionString());
            EnsureRightsLoaded(this.getHBCConnectionString());
        }

        private DataTable EnsureRightsLoaded(string conString)
        {
            if (String.IsNullOrWhiteSpace(conString)) return null;
            lock (RightsCacheLock)
            {
                DataTable cached;
                if (RightsCache.TryGetValue(conString, out cached)) return cached;
                try
                {
                    DataSet rights = this.getDataSet("Select * from UserGroupRight", conString);
                    cached = rights.Tables.Count == 0 ? new DataTable() : rights.Tables[0];
                }
                catch (Exception)
                {
                    // A null value is intentionally cached as the failed-load marker.
                    // TryGetValue will prevent another database attempt for this connection.
                    cached = null;
                }
                RightsCache[conString] = cached;
                return cached;
            }
        }

        private bool GetCachedRight(int formId, string rightName, string conString)
        {
            if (formId <= 0 || String.IsNullOrWhiteSpace(rightName)) return false;
            if (this.getDefaultEntry()) return true;
            DataTable rights = EnsureRightsLoaded(conString);
            if (rights == null || !rights.Columns.Contains("Form_Id") || !rights.Columns.Contains("Group_Id") || !rights.Columns.Contains(rightName))
                return false;
            DataRow[] rows = rights.Select("Form_Id = " + formId + " AND Group_Id = " + this.getGroupId());
            return rows.Length > 0 && rows[0][rightName] != DBNull.Value && Convert.ToBoolean(rows[0][rightName]);
        }

        public bool getUserRight(int formId, string rightName)
        {
            return GetCachedRight(formId, rightName, this.getClientConnectionString());
        }

        public bool getUserRight(int formId, string rightName, string conString)
        {
            return GetCachedRight(formId, rightName, conString);
        }

        public int getFormId(string formName, string conString)
        {
            if (string.IsNullOrWhiteSpace(formName)) return -1;

            string cacheKey = conString + "\n" + formName.Trim();
            lock (RightsCacheLock)
            {
                int cachedFormId;
                if (FormIdCache.TryGetValue(cacheKey, out cachedFormId)) return cachedFormId;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(conString))
                using (SqlCommand command = new SqlCommand("SELECT TOP 1 Id FROM UserForms WHERE FromName = @FromName", connection))
                {
                    command.Parameters.Add("@FromName", SqlDbType.NVarChar, 200).Value = formName.Trim();
                    connection.Open();
                    object value = command.ExecuteScalar();
                    int formId = value == null || value == DBNull.Value ? -1 : Convert.ToInt32(value);
                    lock (RightsCacheLock)
                    {
                        FormIdCache[cacheKey] = formId;
                    }
                    return formId;
                }
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public bool getUserRight(string formName, string rightName, string conString)
        {
            int formId = this.getFormId(formName, conString);
            return formId > 0 && this.getUserRight(formId, rightName, conString);
        }

        public bool CheckRight(int Form_Id, int DataId, bool delete = false)
        {
            bool right = false;
            if (delete)
            {
                if (!this.getUserRight(Form_Id, "CanDelete"))
                {
                    MessageBox.Show("You have no right to Delete", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    right = false;
                }
                else right = true;
            }
            else
            {
                if (DataId == -1)
                {
                    if (!this.getUserRight(Form_Id, "CanAdd"))
                    {
                        MessageBox.Show("You have no right to Add", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        right = false;
                    }
                    else right = true;
                }
                else
                {
                    if (!this.getUserRight(Form_Id, "CanUpdate"))
                    {
                        MessageBox.Show("You have no right to Update", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        right = false;
                    }
                    else right = true;
                }
            }

            return right;
        }

        public bool CheckRightServer(int Form_Id, int DataId, bool delete = false)
        {
            bool right = false;
            if (delete)
            {
                if (!this.getUserRight(Form_Id, "CanDelete", this.getHBCConnectionString()))
                {
                    MessageBox.Show("You have no right to Delete", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    right = false;
                }
                else right = true;
            }
            else
            {
                if (DataId == -1)
                {
                    if (!this.getUserRight(Form_Id, "CanAdd", this.getHBCConnectionString()))
                    {
                        MessageBox.Show("You have no right to Add", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        right = false;
                    }
                    else right = true;
                }
                else
                {
                    if (!this.getUserRight(Form_Id, "CanUpdate", this.getHBCConnectionString()))
                    {
                        MessageBox.Show("You have no right to Update", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        right = false;
                    }
                    else right = true;
                }
            }

            return right;
        }

        public bool CheckRightServer(string formName, int dataId, bool delete = false)
        {
            string rightName = delete ? "CanDelete" : (dataId == -1 ? "CanAdd" : "CanUpdate");
            bool right = this.getUserRight(formName, rightName, this.getHBCConnectionString());
            if (!right)
            {
                MessageBox.Show("You have no right to " + rightName.Substring(3), "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return right;
        }

        public bool CheckRight(int Form_Id, int DataId, DateTime UserDateTime)
        {
            bool right = false;

            

            if (DataId == -1)
            {
                if (!this.getUserRight(Form_Id, "CanAdd"))
                {
                    MessageBox.Show("You have no right to Add", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    right = false;
                }
                else right = true;
            }
            else
            {
                if (UserDateTime.Year == DateTime.Now.Year && UserDateTime.Month == DateTime.Now.Month && UserDateTime.Day == DateTime.Now.Day)
                {
                    right = true;
                }
                else if (!this.getUserRight(Form_Id, "CanUpdate"))
                {
                    MessageBox.Show("You have no right to Update", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    right = false;
                }
                else right = true;
            }

            return right;
        }

        public void closeConnection()
        {
            if (con.State == ConnectionState.Open)
                con.Close();
        }

        public void fillComboBoxWithAddNewOptioni(ComboBox cmb, string query)
        {
            try
            {
                cmb.DataSource = null;
                cmb.Text = "";
                DataSet dsData = this.getDataSet(query);
                DataRow newRow = dsData.Tables[0].NewRow();
                newRow[0] = -1;
                newRow[1] = "<<--Add New-->>";
                dsData.Tables[0].Rows.InsertAt(newRow, 0);
                cmb.DataSource = dsData.Tables[0];
                cmb.DisplayMember = dsData.Tables[0].Columns[1].ToString();
                cmb.ValueMember = dsData.Tables[0].Columns[0].ToString();
                cmb.Text = "";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void fillComboBoxWithAddNewOptioni(ComboBox cmb, string query, string ConString)
        {
            try
            {
                cmb.DataSource = null;
                cmb.Text = "";
                DataSet dsData = this.getDataSet(query, ConString);
                DataRow newRow = dsData.Tables[0].NewRow();
                newRow[0] = -1;
                newRow[1] = "<<--Add New-->>";
                dsData.Tables[0].Rows.InsertAt(newRow, 0);
                cmb.DataSource = dsData.Tables[0];
                cmb.DisplayMember = dsData.Tables[0].Columns[1].ToString();
                cmb.ValueMember = dsData.Tables[0].Columns[0].ToString();
                cmb.Text = "";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void fillComboBoxOptioni(ComboBox cmb, string query)
        {
            try
            {
                cmb.DataSource = null;
                cmb.Text = "";
                DataSet dsData = this.getDataSet(query);
                cmb.DataSource = dsData.Tables[0];
                cmb.DisplayMember = dsData.Tables[0].Columns[1].ToString();
                cmb.ValueMember = dsData.Tables[0].Columns[0].ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void fillComboBoxOptioni(ComboBox cmb, string query, string ConString)
        {
            try
            {
                cmb.DataSource = null;
                cmb.Text = "";
                DataSet dsData = this.getDataSet(query, ConString);
                cmb.DataSource = dsData.Tables[0];
                cmb.DisplayMember = dsData.Tables[0].Columns[1].ToString();
                cmb.ValueMember = dsData.Tables[0].Columns[0].ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void fillComboBoxWithReports(ComboBox cmb, string query)
        {
            try
            {
                cmb.DataSource = null;
                cmb.Text = "";
                DataSet dsData = this.getDataSet(query);
                DataRow newRow = dsData.Tables[0].NewRow();
                newRow[0] = -1;
                newRow[1] = "<<--Select All-->>";
                dsData.Tables[0].Rows.InsertAt(newRow, 0);
                cmb.DataSource = dsData.Tables[0];
                cmb.DisplayMember = dsData.Tables[0].Columns[1].ToString();
                cmb.ValueMember = dsData.Tables[0].Columns[0].ToString();
                cmb.Text = "";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void fillComboBoxWithReports(ComboBox cmb, string query, string ConString)
        {
            try
            {
                cmb.DataSource = null;
                cmb.Text = "";
                DataSet dsData = this.getDataSet(query, ConString);
                DataRow newRow = dsData.Tables[0].NewRow();
                newRow[0] = -1;
                newRow[1] = "<<--Select All-->>";
                dsData.Tables[0].Rows.InsertAt(newRow, 0);
                cmb.DataSource = dsData.Tables[0];
                cmb.DisplayMember = dsData.Tables[0].Columns[1].ToString();
                cmb.ValueMember = dsData.Tables[0].Columns[0].ToString();
                cmb.Text = "";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void fillComboBoxWithReports2(ComboBox cmb, string query)
        {
            try
            {
                cmb.DataSource = null;
                DataSet dsData = this.getDataSet(query);
                DataRow newRow = dsData.Tables[0].NewRow();
                cmb.DataSource = dsData.Tables[0];
                cmb.DisplayMember = dsData.Tables[0].Columns[1].ToString();
                cmb.ValueMember = dsData.Tables[0].Columns[0].ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void fillComboBoxWithReports2(ComboBox cmb, string query, string ConString)
        {
            try
            {
                cmb.DataSource = null;
                DataSet dsData = this.getDataSet(query, ConString);
                DataRow newRow = dsData.Tables[0].NewRow();
                cmb.DataSource = dsData.Tables[0];
                cmb.DisplayMember = dsData.Tables[0].Columns[1].ToString();
                cmb.ValueMember = dsData.Tables[0].Columns[0].ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void fillGridComboBoxWithAddNewOption(DataGridViewComboBoxColumn cmb, string query)
        {
            try
            {
                cmb.DataSource = null;
                DataSet dsData = this.getDataSet(query);
                DataRow newRow = dsData.Tables[0].NewRow();
                newRow[0] = -1;
                newRow[1] = "<<--Add New-->>";
                dsData.Tables[0].Rows.InsertAt(newRow, 0);
                cmb.DataSource = dsData.Tables[0];
                cmb.DisplayMember = dsData.Tables[0].Columns[1].ToString();
                cmb.ValueMember = dsData.Tables[0].Columns[0].ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void fillGridComboBoxWithAddNewOption(DataGridViewComboBoxColumn cmb, string query, string ConString)
        {
            try
            {
                cmb.DataSource = null;
                DataSet dsData = this.getDataSet(query, ConString);
                DataRow newRow = dsData.Tables[0].NewRow();
                newRow[0] = -1;
                newRow[1] = "<<--Add New-->>";
                dsData.Tables[0].Rows.InsertAt(newRow, 0);
                cmb.DataSource = dsData.Tables[0];
                cmb.DisplayMember = dsData.Tables[0].Columns[1].ToString();
                cmb.ValueMember = dsData.Tables[0].Columns[0].ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void RecoardLogs(string Detail, string FormName)
        {
            try
            {
                string userId = this.getUserId();
                string userName = this.getUserName();
                string command = "Insert into UserLogs (UserId, UserName, FormName, Detail, Created_at) Values ('" + userId + "','" + userName + "','" + FormName + "','" + Detail + "', GetDate())";
                this.executeQuery(command, this.getConnectionString());
            }
            catch (Exception ex)
            {

            }
        }

        public void updateSettings(int id, string value)
        {
            try
            {
                string command = "Update Settings set Value = '" + value + "' where Id = " + id;
                this.executeQuery(command, this.getHBCConnectionString());
                
            }
            catch (Exception ex)
            {

            }
        }

        public string GetSetting(int id)
        {
            try
            {
                DataTable dt = this.getDataSet("Select Value from Settings where Id = " + id.ToString(), this.getHBCConnectionString()).Tables[0];
                return dt.Rows[0][0].ToString();
            }
            catch (Exception ex)
            {
                return "";
            }
        }

        public static string GetSettings(int id)
        {
            try
            {
                DataTable dt = getDataSets("Select Value from Settings where Id = " + id.ToString(), getHBCConnectionStrings()).Tables[0];
                return dt.Rows[0][0].ToString();
            }
            catch (Exception ex)
            {
                return "";
            }
        }

        public static DataSet getDataSets(string query, string ConString)
        {
            DataSet ds;
            try
            {
                ds = new DataSet();
                //if (this.con.State == ConnectionState.Open)
                //    this.con.Close();

                SqlConnection NewCon = new SqlConnection(ConString);

                SqlDataAdapter da = new SqlDataAdapter(query, NewCon);
                NewCon.Open();
                da.Fill(ds);
                NewCon.Close();
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public bool TimeEntryLock(DateTime trDate)
        {
            try
            {
                bool defaultEntry = false;
                SqlDataReader dr = this.getDataReader("Select DefaultEntry, Group_Id from AISYS Where UserId = " + this.getUserId(), this.getConnectionString());
                if (dr.HasRows)
                {
                    dr.Read();
                    if (Convert.ToBoolean(dr.GetValue(0)))
                        defaultEntry = true;
                }
                dr.Close();
                this.closeConnection();
                if (defaultEntry)
                {
                    return true;
                }
                else
                {
                    DataTable dt = this.getDataSet("Select CONVERT(datetime, CONVERT(nvarchar(10), GetDate(), 111))", this.getHBCConnectionString()).Tables[0];
                    DateTime currentDate = Convert.ToDateTime(dt.Rows[0][0]);

                    if (trDate < currentDate)
                    {
                        MessageBox.Show("Old entries cannot be changed", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }               

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool AdminLock()
        {
            try
            {
                bool defaultEntry = false;
                SqlDataReader dr = this.getDataReader("Select DefaultEntry, Group_Id from AISYS Where UserId = " + this.getUserId(), this.getConnectionString());
                if (dr.HasRows)
                {
                    dr.Read();
                    if (Convert.ToBoolean(dr.GetValue(0)))
                        defaultEntry = true;
                }
                dr.Close();
                this.closeConnection();
                if (defaultEntry)
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("Old entries cannot be changed", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return false;
                }

            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}
