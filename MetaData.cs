using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace inputApplication
{
    public partial class MetaData : Form
    {
        public MetaData()
        {
            InitializeComponent();
        }

        private void MetaData_Load(object sender, EventArgs e)
        {
            if (!File.Exists(Utility.dataFilePath))
            {
                MessageBox.Show("You don't have data files. categories can't be loaded with data. Please try to get latest updates under Tools menu.");
            }
            else
            {
                DataTable parentCategories = Utility.GetDataFromFile().Tables["Properties"].DefaultView.ToTable(true, "parentCategory"); 
                foreach (DataRow parentCategoryRow in parentCategories.Rows)
                    cbxParentCategory.Items.Add(parentCategoryRow[0]);
                cbxParentCategory.SelectedIndex = 0;
            }

        }

        private void cbxParentCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataView categoryView = new DataView(Utility.GetDataFromFile().Tables["Properties"]);
            categoryView.RowFilter = String.Format("parentCategory = '{0}'", cbxParentCategory.SelectedItem.ToString());
            categoryView.Sort = "category ASC";

            cbxCategory.Items.Clear();
            foreach (DataRow categoryRow in categoryView.ToTable(true,"category").Rows)
                cbxCategory.Items.Add(categoryRow[0]);
            cbxCategory.SelectedIndex = 0;
        }

        private void cbxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataView propertyNameView = new DataView(Utility.GetDataFromFile().Tables["Properties"]);
            propertyNameView.RowFilter = String.Format("parentCategory = '{0}' AND category = '{1}'", cbxParentCategory.SelectedItem.ToString(), cbxCategory.SelectedItem.ToString());
            propertyNameView.Sort = "propertyName ASC";

            cbxPropertyName.Items.Clear();
            foreach (DataRow propertyNameRow in propertyNameView.ToTable(true, "propertyName").Rows)
                cbxPropertyName.Items.Add(propertyNameRow[0]);
            cbxPropertyName.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataSet dataset = Utility.GetDataFromFile();
            DataView propertyValueView = new DataView(dataset.Tables["Properties"]);
            propertyValueView.RowFilter = String.Format("parentCategory = '{0}' AND category = '{1}' AND propertyName = '{2}' ", cbxParentCategory.SelectedItem.ToString(), cbxCategory.SelectedItem.ToString(),cbxPropertyName.SelectedItem.ToString());
            int propertyId = Convert.ToInt32(propertyValueView[0]["propertyId"]);


            DataTable propertyValuesDataTable = dataset.Tables["PropertyValues"];
            DataRow propertyValuesDataRow = propertyValuesDataTable.NewRow();
            propertyValuesDataRow["propertyId"] = propertyId;
            propertyValuesDataRow["propertyValue"] = tbxPropertyValue.Text;
            propertyValuesDataRow["rowStatus"] = 1;

            propertyValuesDataTable.Rows.Add(propertyValuesDataRow);

            Utility.WriteDataToFile(dataset);
            tbxPropertyValue.Text = string.Empty;
            MessageBox.Show("Success: Value is created & saved");
        }
    }
}
