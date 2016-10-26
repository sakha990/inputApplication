using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;

namespace inputApplication
{
    public static class DBManager
    {
        

        public static DataSet GetDataSetFromFile()
        {
            DataSet applicationDataSet = new DataSet("applicationDataSet");
            DataTable propertiesDataTable = new DataTable("Properties");
            DataTable propertyvaluesDataTable = new DataTable("PropertyValues");
            applicationDataSet.Tables.Add(propertiesDataTable);
            applicationDataSet.Tables.Add(propertyvaluesDataTable);

            using (MemoryStream stream = new MemoryStream(Encoding.Unicode.GetBytes(Properties.Resources.dataset)))
            {
                applicationDataSet.ReadXml(stream, XmlReadMode.IgnoreSchema);
            }
            return applicationDataSet;
        }

        public static bool WriteDataSetToFile(DataSet dataset)
        {
            bool success = false;
            using (MemoryStream stream = new MemoryStream(Encoding.Unicode.GetBytes(Properties.Resources.dataset)))
            {
                dataset.WriteXml(stream, XmlWriteMode.IgnoreSchema);
                success = true;
            }
            return success;
        }

        public static DataSet GetDataSetFromDataBase()
        {

            DataSet applicationDataSet = new DataSet("applicationDataSet");

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["dbString"].ToString()))
            { 
                SqlDataAdapter propertiesAdapter = new SqlDataAdapter("SELECT * FROM dbo.Properties", connection);
                SqlDataAdapter propertyvaluesAdapter = new SqlDataAdapter("SELECT * FROM dbo.PropertyValues", connection);
                try
                {
                    connection.Open();
                    propertiesAdapter.Fill(applicationDataSet, "Properties");
                    propertiesAdapter.Fill(applicationDataSet, "PropertyValues");

                    DataRelation relation = applicationDataSet.Relations.Add("fk_relation", applicationDataSet.Tables["properties"].Columns["propertyId"], applicationDataSet.Tables["Orders"].Columns["propertyId"]);
                }
                catch (Exception exception)
                {
                    throw;

                }
            }

            return applicationDataSet;
        }

        public static bool TestDataBaseConnection()
        {
            bool success = false;
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["dbString"].ToString()))
            {
                try
                {
                    connection.Open();
                    success = true;
                }
                catch (Exception exception)
                {
                    throw;
                }
            }
            return success;
        }

        public static bool InsertPropertyValueToDatabase(int propertyId,string propertyValue)
        {
            bool success = false;
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["dbString"].ToString()))
            {
                using (SqlCommand cmd = new SqlCommand("insertPropertyValues", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@propertyId", SqlDbType.SmallInt).Value = propertyId;
                    cmd.Parameters.Add("@propertyValue", SqlDbType.VarChar).Value = propertyValue;
                    try
                    {
                        connection.Open();
                        cmd.ExecuteNonQuery();
                        success = true;
                    }
                    catch (Exception ex)
                    {
                        success = false;
                    }
                }
            }
            return success;        
        }

        
    }

}
