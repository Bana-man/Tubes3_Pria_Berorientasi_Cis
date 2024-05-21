using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Diagnostics;

namespace Tubes3GUI
{
    public class DBHandler
    {

        public string m_strMySQLConnectionString = "server=localhost;userid=root;database=dbname";
        public string GetValueFromDBUsing(string strQuery)
        {
            string strData = "";

            try
            {
                if (string.IsNullOrEmpty(strQuery) == true)
                    return string.Empty;

                using (var mysqlconnection = new MySqlConnection(m_strMySQLConnectionString))
                {
                    mysqlconnection.Open();
                    using (MySqlCommand cmd = mysqlconnection.CreateCommand())
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandTimeout = 300;
                        cmd.CommandText = strQuery;

                        object objValue = cmd.ExecuteScalar();
                        if (objValue == null)
                        {
                            cmd.Dispose();
                            return string.Empty;
                        }
                        else
                        {
                            strData = (string)cmd.ExecuteScalar();
                            cmd.Dispose();
                        }

                        mysqlconnection.Close();

                        if (strData == null)
                            return string.Empty;
                        else
                            return strData;
                    }
                }
            }
            catch (MySqlException ex)
            {
                Debug.WriteLine(ex.Message);
                return string.Empty;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return string.Empty;
            }
            finally
            {

            }
        }
    }
}
