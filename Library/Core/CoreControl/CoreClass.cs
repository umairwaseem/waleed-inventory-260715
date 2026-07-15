using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Xml;
using System.Text.RegularExpressions;


namespace CoreControl
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

        public string getConnectionString()
        {
            string path = string.Empty;
            XmlTextReader xReader = new XmlTextReader(Application.StartupPath + "\\datasource.xml");
            while (xReader.Read())
            {
                if(xReader.n
            }
            return path;
        }

        public SqlDataReader funSelectRD(string srchQry)
        {
            SqlDataReader dr = null;
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
                SqlCommand cmd = new SqlCommand(srchQry, con);
                dr = cmd.ExecuteReader();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dr;
        }

        public DataSet funSelectDs(string srchQry)
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
                daMyAdapter = new SqlDataAdapter(srchQry, con);
                dsMyDataSet = new DataSet();
                daMyAdapter.Fill(dsMyDataSet);
                if (dsMyDataSet.Tables[0].Rows.Count < 1)
                {
                }
                else
                {
                    return dsMyDataSet;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return dsMyDataSet;
        }

        public void funVoidCommand(string srchQry)
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();//Open Connection
                SqlCommand cmd = new SqlCommand(srchQry, con);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        public void closeConnection()
        {
            if (con.State == ConnectionState.Open)
                con.Close();
        }
    }
}
