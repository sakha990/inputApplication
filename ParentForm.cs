using System;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace inputApplication
{
    public partial class ParentForm : Form
    {
        public ParentForm()
        {
            InitializeComponent();
        }

        public void Initialize_Categories()
        {
            DataTable templateData = Utility.GetTemplateDataFromFile();
            

            DataTable parentCategoriesDataTable = templateData.DefaultView.ToTable(true, "parentCategory", "parentCategoryDisplay");
            foreach (DataRow parentCategoryRow in parentCategoriesDataTable.Rows)
            {
                var parentCategory = new System.Windows.Forms.ToolStripMenuItem();
                parentCategory.Name = parentCategoryRow["parentCategory"].ToString();
                parentCategory.Text = parentCategoryRow["parentCategoryDisplay"].ToString();


                DataView categoryView = new DataView(templateData);
                categoryView.RowFilter = String.Format("parentCategory = '{0}'", parentCategoryRow["parentCategory"]);

                foreach (DataRow categoryRow in categoryView.ToTable().Rows)
                {
                    string[] categoryProperties = new string[3];
                    categoryProperties[0] = categoryRow["templateId"].ToString();
                    categoryProperties[1] = categoryRow["parentCategory"].ToString();
                    categoryProperties[2] = categoryRow["parentCategoryDisplay"].ToString();

                    var category = new System.Windows.Forms.ToolStripMenuItem();
                    category.Name = categoryRow["category"].ToString();
                    category.Text = categoryRow["categoryDisplay"].ToString();
                    category.Tag = categoryProperties; 

                    category.Click += new EventHandler(Category_Click);
                    parentCategory.DropDownItems.Add(category);
                }

                catgoriesToolStripMenuItem.DropDownItems.Add(parentCategory);
            }

        }
        
        protected void Category_Click(object sender, EventArgs e)
        {
            var categoryMenuItem = (ToolStripMenuItem)sender;

            string[] categoryArgs        = (string[])categoryMenuItem.Tag;
            Global.TemplateFileName      = categoryArgs[0];
            Global.ParentCategory        = categoryArgs[1];
            Global.Category = categoryMenuItem.Name;

            CategoryForm categoryForm = new CategoryForm();
            categoryForm.Text = categoryArgs[2] + " >>> " + categoryMenuItem.Text;
            categoryForm.Show();
            categoryForm.MdiParent = this;

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            if (!File.Exists(Utility.dataFilePath) && !File.Exists(Utility.templateFilePath))
            { 
                MessageBox.Show("You don't have latest data files. Please try to get latest updates under Tools menu.");
            }
            else
            { 
            Initialize_Categories();
            }
        }
        private void setWorkingDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = workingDirectory.ShowDialog();
            if (result == DialogResult.OK)
            {
                Global.WorkingDirectory = workingDirectory.SelectedPath;
                workingDirectoryToolStripMenuItem.Text = " Working Directory:  " + workingDirectory.SelectedPath;
            }
        }

        private void createMetaDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MetaData metadata = new MetaData();
            metadata.Show();
            metadata.MdiParent = this;
        }
        private void mergeDataToolStripMenuItem_Click(object sender, EventArgs e)
        {

            // rewrite templatedata file and fetch all missing template files
            Utility.GetTemplateDataFromService();

            if (File.Exists(Utility.dataFilePath))
            {
                DataSet dataset = Utility.GetDataFromFile();
                DataRow[] rowsToMerge = dataset.Tables["PropertyValues"].Select("rowStatus = 1");
                if(rowsToMerge.Length > 0)
                { 
                    // prepare string
                    string inputString = "=";
                    foreach (var row in rowsToMerge)
                        inputString += row[0] + ":" + row[1] + ",";
                    inputString.Remove(inputString.Length - 1);

                    // Finally call web service to merge data                                 
                    Utility.WriteDataToService(inputString);
                }
                // get latest data and Rewrite dataset file 
                Utility.GetDataFromService();
            
            } else
                {
                    // get latest data and Rewrite dataset file 
                    Utility.GetDataFromService();
            }

            if (!Global.MergeError)
            {
                MessageBox.Show("Success! Data Files are updated");
                catgoriesToolStripMenuItem.DropDownItems.Clear();
                Initialize_Categories();
            }
            else
            {
                MessageBox.Show("Failure. Data Files are NOT updated. There are some errors! Contact administrator");
            }

        }           

    }

}