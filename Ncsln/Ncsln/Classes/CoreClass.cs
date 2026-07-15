using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Xml;
using System.Text.RegularExpressions;


namespace Ncsln.Classes
{
    public class CoreClass
    {
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
            return Ncsln.Properties.Settings.Default.user;
        }

        public bool getUserRight(int formId, string rightName)
        {
            bool right = false;
            bool defaultEntry = false;
            int Group_Id = 0;
            try
            {
                SqlDataReader dr = this.getDataReader("Select DefaultEntry, Group_Id from AISYS Where UserId = " + this.getUserId(), this.getClientConnectionString());
                if (dr.HasRows)
                {
                    dr.Read();
                    if (Convert.ToBoolean(dr.GetValue(0)))
                        defaultEntry = true;
                    Group_Id = Convert.ToInt32(dr.GetValue(1));
                }
                dr.Close();
                this.closeConnection();
                if (defaultEntry)
                {
                    right = true;
                }
                else
                {
                    string con = this.getClientConnectionString();
                    dr = this.getDataReader("Select IsNull((Select " + rightName + " from UserGroupRight Where Form_Id = " + formId + " And Group_Id = " + Group_Id + "), '0')", this.getClientConnectionString());
                    if (dr.HasRows)
                    {
                        dr.Read();
                        right = Convert.ToBoolean(dr.GetValue(0));
                    }
                    dr.Close();
                    this.closeConnection();
                }
            }
            catch (Exception ex)
            {
            }
            return right;
        }

        public bool getUserRight(int formId, string rightName, string conString)
        {
            bool right = false;
            bool defaultEntry = false;
            int Group_Id = 0;
            try
            {
                SqlDataReader dr = this.getDataReader("Select DefaultEntry, Group_Id from AISYS Where UserId = " + this.getUserId(), conString);
                if (dr.HasRows)
                {
                    dr.Read();
                    if (Convert.ToBoolean(dr.GetValue(0)))
                        defaultEntry = true;
                    Group_Id = Convert.ToInt32(dr.GetValue(1));
                }
                dr.Close();
                this.closeConnection();
                if (defaultEntry)
                {
                    right = true;
                }
                else
                {
                    dr = this.getDataReader("Select IsNull((Select " + rightName + " from UserGroupRight Where Form_Id = " + formId + " And Group_Id = " + Group_Id + "), '0')", conString);
                    if (dr.HasRows)
                    {
                        dr.Read();
                        right = Convert.ToBoolean(dr.GetValue(0));
                    }
                    dr.Close();
                    this.closeConnection();
                }
            }
            catch (Exception ex)
            {
            }
            return right;
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
                string userId = Ncsln.Properties.Settings.Default.user;
                string userName = Ncsln.Properties.Settings.Default.UserName;
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
