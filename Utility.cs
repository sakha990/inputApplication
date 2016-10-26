using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Net;
using System.Data;
using System.Xml;

namespace inputApplication
{
    public static class Utility
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static string baseUrl = "http://sakha.somee.com"; /*http://localhost:65184*/
        public static string dataFilePath = "dataset";
        public static string templateFilePath = "templatesdata";
        public static string templateFolderPath = "templates/";

        public static DataSet GetDataSet()
        {
            DataSet dataset = new DataSet("applicationDataSet");

            // Create Table Properties 
            DataTable properties = new DataTable("Properties");

            DataColumn propertyId = new DataColumn("propertyId", typeof(Int32));
            properties.Columns.Add(propertyId);

            DataColumn parentCategory = new DataColumn("parentCategory", typeof(string));
            properties.Columns.Add(parentCategory);

            DataColumn category = new DataColumn("category", typeof(string));
            properties.Columns.Add(category);

            DataColumn propertyName = new DataColumn("propertyName", typeof(string));
            properties.Columns.Add(propertyName);

            dataset.Tables.Add(properties);

            // Create Table PropertyValues

            DataTable propertyValues = new DataTable("PropertyValues");

            DataColumn propertyId_1 = new DataColumn("propertyId", typeof(Int32));
            propertyValues.Columns.Add(propertyId_1);

            DataColumn propertyValue = new DataColumn("propertyValue", typeof(string));
            propertyValues.Columns.Add(propertyValue);

            DataColumn rowStatus = new DataColumn("rowStatus", typeof(Int32));
            rowStatus.DefaultValue = 0;
            propertyValues.Columns.Add(rowStatus);

            dataset.Tables.Add(propertyValues);

            return dataset;
        }
        public static string GetJsonFromFile(string fileName)
        {
            log.Info("GetJsonFromFile:: Start");
            string jsonString = string.Empty;
                try
            {
                jsonString = System.IO.File.ReadAllText(templateFolderPath + fileName);
                log.Info("GetJsonFromFile:: Ends");
            }
            catch (Exception exception)
            {
                log.Error("GetJsonFromFile:: ", exception);

            }
            return jsonString;
        }
        public static DataSet GetDataFromFile()
        {
            log.Info("GetDataFromFile:: Start");
            DataSet dataset = GetDataSet();
                try
                {
                    dataset.ReadXml(dataFilePath, XmlReadMode.IgnoreSchema);
                    log.Info("GetDataFromFile:: Ends");
                }
                catch (Exception exception)
                {
                    log.Error("GetDataFromFile:: ",exception);

                }

            return dataset;
        }

        public static DataTable GetTemplateDataTable()
        {

            DataTable templates = new DataTable("Templates");

            DataColumn templateId = new DataColumn("templateId", typeof(Int32));
            templates.Columns.Add(templateId);

            DataColumn parentCategory = new DataColumn("parentCategory", typeof(string));
            templates.Columns.Add(parentCategory);

            DataColumn parentCategoryDisplay = new DataColumn("parentCategoryDisplay", typeof(string));
            templates.Columns.Add(parentCategoryDisplay);

            DataColumn category = new DataColumn("category", typeof(string));
            templates.Columns.Add(category);

            DataColumn categoryDisplay = new DataColumn("categoryDisplay", typeof(string));
            templates.Columns.Add(categoryDisplay);

            return templates;

        }
        public static DataTable GetTemplateDataFromFile()
        {
            DataTable templates = GetTemplateDataTable();
            log.Info("GetTemplateDataFromFile:: Start");

            try
            {
                templates.ReadXml(templateFilePath);
                log.Info("GetTemplateDataFromFile:: Ends");
            }
            catch (Exception exception)
            {
                log.Error("GetTemplateDataFromFile:: ", exception);

            }

            return templates;
        }
        public static void WriteDataToFile(DataSet dataset)
        {
            log.Info("WriteDataToFile:: Start");
            if (File.Exists(dataFilePath))
            {
                try
                {
                    dataset.WriteXml(dataFilePath);
                    log.Info("WriteDataToFile:: Ends");
                }
                catch (Exception exception)
                {
                    log.Error("WriteDataToFile:: ", exception);
                }
            }
            else
            {
                log.Error("Data writing to file failed:: File does not exists");
            }
        }

        public static void GetTemplateFromService()
        {
            log.Info("GetTemplateFromService:: Start");
            try
            {
                using (var client = new WebClient())
                {
                    var reader = new StreamReader(client.OpenRead( baseUrl + "/api/DataService/Template"));
                    string templateData = reader.ReadToEnd();
                    File.WriteAllText(templateFilePath, templateData);
                    log.Info("GetTemplateFromService:: Ends");
                }
            }
            catch (Exception exception)
            {
                log.Error("GetTemplateFromService:: " + exception);
                Global.MergeError = true;
            }

        }

        public static void GetTemplateFileFromService(string fileId)
        {
            log.Info("GetTemplateFileFromService:: Start");
            try
            {
                using (var client = new WebClient())
                {
                    var reader = new StreamReader(client.OpenRead(baseUrl + "/api/DataService/GetTemplateFile/" + fileId));
                    string filedata = reader.ReadToEnd();
                    FileInfo file = new FileInfo(templateFolderPath + fileId);
                    file.Directory.Create();
                    File.WriteAllText(templateFolderPath + fileId, filedata);
                    log.Info("GetTemplateFileFromService:: Ends");
                }
            }
            catch (Exception exception)
            {
                log.Error("GetTemplateFileFromService:: " + exception);
                Global.MergeError = true;
            }

        }
        public static void GetDataFromService()
        {
            log.Info("GetDataFromservice:: Start" );
            
            try
            {
                using (var client = new WebClient())
                {
                    client.Headers[HttpRequestHeader.ContentType] = "text/xml";
                    var reader = new StreamReader(client.OpenRead(baseUrl + "/api/DataService/GetPropertiesData"));
                    string xmlData = reader.ReadToEnd();
                    File.WriteAllText(dataFilePath, xmlData);
                    log.Info("GetDataFromservice:: Ends");
                }
            }
            catch (Exception exception)
            {
                log.Error("GetDataFromservice:: " + exception);
                Global.MergeError = true;
            }

        }

        public static void GetTemplateDataFromService()
        {
            log.Info("GetTemplateDataFromService:: Start");
            //DataTable currentDataTable = GetTemplateDataFromFile();
            DataTable serviceDataTable = GetTemplateDataTable();
            try
            {
                using (var client = new WebClient())
                {
                    client.Headers[HttpRequestHeader.ContentType] = "text/xml";
                    var reader = new StreamReader(client.OpenRead(baseUrl + "/api/DataService/GetTemplateData"));
                    string xmlData = reader.ReadToEnd();
                    using (TextReader serviceData = new StringReader(xmlData))
                    {
                        //serviceData.ReadToEnd();
                        serviceDataTable.ReadXml(serviceData);
                    }
                    
                    foreach (DataRow dr in serviceDataTable.Rows)
                    {
                        if (!File.Exists( templateFolderPath + dr["templateId"].ToString()))
                            {
                                GetTemplateFileFromService(dr[0].ToString());
                        }
                    }
                    File.WriteAllText(templateFilePath, xmlData);
                    log.Info("GetTemplateDataFromService:: Ends");
                }
            }
            catch (Exception exception)
            {
                log.Error("GetTemplateDataFromService:: " + exception);
                Global.MergeError = true;
            }

        }
        public static void WriteDataToService(string propertyValuesString)
        {
            bool success = false;
            log.Info("WriteDataToService:: Start inputparam = " + propertyValuesString);
            try
            {
                using (var client = new WebClient())
                {
                    client.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                    var result = client.UploadString(baseUrl + "/api/DataService/MergePropertyValues", "POST", propertyValuesString);
                    success = Convert.ToBoolean(result);
                    log.Info("WriteDataToService:: Ends ");
                    if (!success)
                        Global.MergeError = true;
                }
            }
            catch (Exception exception)
            {
                log.Error("WriteDataToService:: " + exception);
                Global.MergeError = true;
            }

        }

        public static void ResetAllControls(Control form)
        {

            foreach (Control control in form.Controls)
            {
                if (control is TextBox)
                {
                    TextBox textBox = (TextBox)control;
                    textBox.Text = null;
                }

                if (control is ComboBox)
                {
                    ComboBox comboBox = (ComboBox)control;
                    if (comboBox.Items.Count > 0)
                        comboBox.SelectedIndex = 0;
                }

                if (control is CheckBox)
                {
                    CheckBox checkBox = (CheckBox)control;
                    checkBox.Checked = false;
                }

                if (control is ListBox)
                {
                    ListBox listBox = (ListBox)control;
                    listBox.ClearSelected();
                }
            }

        }

        public static string GetFileName(string fileName)
        {
            log.Info("GetFileName:: Start inputparam = " + fileName);

            if (!(File.Exists(Global.WorkingDirectory + "\\" + fileName )))
            {
                return fileName;
            }

            List<string> fileNameParts = fileName.Split(".".ToCharArray()).First().Split("-".ToCharArray()).ToList<string>();

            int fileVersion = 0;
            bool result = int.TryParse(fileNameParts.Last(), out fileVersion);
            fileVersion++;
            if (result)
            {
                fileNameParts[fileNameParts.Count - 1] = fileVersion.ToString();
                
            }
            else
            {
                fileNameParts.Add(fileVersion.ToString());
            }

            log.Info("GetFileName:: Ends:: " + string.Join("-", fileNameParts) + ".json");

            return GetFileName(string.Join("-", fileNameParts) + ".json");
        }
    }

}