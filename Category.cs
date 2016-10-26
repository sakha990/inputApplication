using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Dynamic;
using System.Linq;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace inputApplication
{
    public partial class CategoryForm : Form
    {
        public CategoryForm()
        {
            InitializeComponent();
        }

        public void LoadData(Control control,string parentCategory,string category,string propertyName)
        {
            DataSet dataset          = Utility.GetDataFromFile();
            DataTable properties     = dataset.Tables["Properties"];
            DataTable propertyValues = dataset.Tables["PropertyValues"];

            List<string> items = (from p in properties.AsEnumerable()
                                          join v in propertyValues.AsEnumerable() on (int)p["propertyId"] equals (int)v["propertyId"]
                                          where p.Field<string>("parentCategory") == parentCategory
                                                && p.Field<string>("category") == category
                                                && p.Field<string>("propertyName") == propertyName
                                          select v.Field<string>("propertyValue")).ToList<string>();

            if (control is ComboBox)
            { 
                ((ComboBox)control).Items.Clear();
                foreach (string item in items)
                    ((ComboBox)control).Items.Add(item);
            }
            else if(control is ListBox)
                {
                ((ListBox)control).Items.Clear();
                foreach (string item in items)
                    ((ListBox)control).Items.Add(item);
            }
        }
        private void CategoryForm_Load(object sender, EventArgs e)
        {
            string jsonString = Utility.GetJsonFromFile(Global.TemplateFileName);
            IList<ControlTemplate> controls = JsonConvert.DeserializeObject<IList<ControlTemplate>>(jsonString);

            foreach (ControlTemplate controlTemplate in controls)
            { 
                if (controlTemplate.ControlType == "combobox")
                {
                    FlowLayoutPanel panel = new FlowLayoutPanel();
                    panel.FlowDirection = FlowDirection.LeftToRight;
                    panel.AutoSize = true;
                    panel.AutoSizeMode = AutoSizeMode.GrowAndShrink;

                    Label label = new Label();
                    label.Text = controlTemplate.Display;
                    label.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

                    ComboBox comboBox = new ComboBox();
                    comboBox.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    comboBox.Name = controlTemplate.ID;

                    List<string> data = new List<string>();
                    data.Add(controlTemplate.DataType);
                    data.Add(controlTemplate.PropertyName);
                    comboBox.Tag = new KeyValuePair<List<string>, bool>(data, controlTemplate.Required);

                    comboBox.Height = 100;
                    comboBox.Width = 200;
                    LoadData(comboBox, Global.ParentCategory, Global.Category, controlTemplate.PropertyName);
                    if(comboBox.Items.Count > 0 )
                        comboBox.SelectedIndex = 0;

                    panel.Controls.Add(label);
                    panel.Controls.Add(comboBox);
                    categoryPanel.Controls.Add(panel);


                }
                else if (controlTemplate.ControlType == "textbox")
                {
                    FlowLayoutPanel panel = new FlowLayoutPanel();
                    panel.FlowDirection = FlowDirection.LeftToRight;
                    panel.AutoSize = true;
                    panel.AutoSizeMode = AutoSizeMode.GrowAndShrink;

                    Label label1 = new Label();
                    label1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    label1.Text = controlTemplate.Display;
                    
                    TextBox tbx = new TextBox();
                    tbx.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    tbx.Name = controlTemplate.ID;
                    tbx.Multiline = controlTemplate.Multiline;

                    List<string> data = new List<string>();
                    data.Add(controlTemplate.DataType);
                    data.Add(controlTemplate.PropertyName);
                    tbx.Tag = new KeyValuePair<List<string>, bool>(data, controlTemplate.Required);

                    tbx.Width = 200;
                    tbx.Height = 200;

                    Label label2 = new Label();
                    label2.Font = new System.Drawing.Font("Arial", 8F);
                    label2.ForeColor = Color.Red;
                    label2.Text = controlTemplate.Units;
                    label2.Width = 150;
                    panel.Controls.Add(label1);
                    panel.Controls.Add(tbx);
                    panel.Controls.Add(label2);
                    categoryPanel.Controls.Add(panel);

                }
                else if (controlTemplate.ControlType == "listbox")
                {
                    FlowLayoutPanel panel = new FlowLayoutPanel();
                    panel.FlowDirection = FlowDirection.LeftToRight;
                    panel.AutoSize = true;
                    panel.AutoSizeMode = AutoSizeMode.GrowAndShrink;


                    Label label = new Label();
                    label.Text = controlTemplate.Display;
                    label.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

                    ListBox listbox = new ListBox();
                    listbox.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    listbox.Width = 200;
                    listbox.Height = 200;

                    listbox.Name = controlTemplate.ID;
                    listbox.SelectionMode = SelectionMode.MultiSimple;

                    List<string> data = new List<string>();
                    data.Add(controlTemplate.DataType);
                    data.Add(controlTemplate.PropertyName);
                    listbox.Tag = new KeyValuePair<List<string>, bool>(data, controlTemplate.Required);

                    LoadData(listbox, Global.ParentCategory, Global.Category, controlTemplate.PropertyName);

                    panel.Controls.Add(label);
                    panel.Controls.Add(listbox);
                    categoryPanel.Controls.Add(panel);


                }

            }
            FlowLayoutPanel buttonpanel = new FlowLayoutPanel();
            buttonpanel.FlowDirection = FlowDirection.LeftToRight;
            buttonpanel.AutoSize = true;
            buttonpanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;

            Button btnCreateDocument = new Button();
            btnCreateDocument.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            btnCreateDocument.Text = "Create Document";
            btnCreateDocument.Width = 200;
            btnCreateDocument.Height = 40;
            btnCreateDocument.Click += new EventHandler(btnCreateDocument_Click);
            buttonpanel.Controls.Add(btnCreateDocument);
            

            Button btnReset = new Button();
            btnReset.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            btnReset.Text = "Reset";
            btnReset.Width = 200;
            btnReset.Height = 40;
            btnReset.Click += new EventHandler(btnReset_Click);
            buttonpanel.Controls.Add(btnReset);

            Button btnReload = new Button();
            btnReload.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            btnReload.Text = "Reload";
            btnReload.Width = 200;
            btnReload.Height = 40;
            btnReload.Click += new EventHandler(btnReload_Click);
            buttonpanel.Controls.Add(btnReload);

            categoryPanel.Controls.Add(buttonpanel);


        }
        protected void btnReload_Click(object sender, EventArgs e)
        {
            foreach (Control panelControls in categoryPanel.Controls)
            {
                foreach (Control control in panelControls.Controls)
                {

                    if (control is ComboBox)
                    {
                        LoadData(control, Global.ParentCategory, Global.Category, ((KeyValuePair<List<string>, bool>)control.Tag).Key[1]);
                        if (((ComboBox)control).Items.Count > 0)
                            ((ComboBox)control).SelectedIndex = 0;
                    }

                    else if (control is ListBox)
                    {
                        LoadData(control, Global.ParentCategory, Global.Category, ((KeyValuePair<List<string>, bool>)control.Tag).Key[1]);
                        if (((ListBox)control).Items.Count > 0)
                            ((ListBox)control).SelectedIndex = 0;

                    }
                }

            }
        }
        protected void btnReset_Click(object sender, EventArgs e)
        {
            foreach (Control panelControls in categoryPanel.Controls)
            {
                Utility.ResetAllControls(panelControls);
            }


    }
    protected void btnCreateDocument_Click(object sender, EventArgs e) {

            categoryErrors.Clear();

            if (RequiredValidation() && NumberValidation())
            {
                createDocument();
                // create doc
            }
        }
        public bool RequiredValidation()
        {
            bool validation = true;
            foreach (Control panelControls in categoryPanel.Controls)
            {
                foreach (Control control in panelControls.Controls)
                {
                    if (!(control is Label) && !(control is Button) && !(control is FlowLayoutPanel) && ((KeyValuePair<List<string>,bool>)control.Tag).Value == true)
                    {
                        if ((control is TextBox && string.IsNullOrWhiteSpace(((TextBox)control).Text)) ||
                    (control is ListBox && ((ListBox)control).SelectedItems.Count == 0) ||
                    (control is ComboBox && string.IsNullOrWhiteSpace(((ComboBox)control).SelectedItem.ToString())))
                        {
                            categoryErrors.SetError(control, "Please fill the required field");
                            validation = false;
                        }

                    }
                }
            }
            return validation;

        }

        public bool NumberValidation()
        {
            bool validation = true;
            foreach (Control panelControls in categoryPanel.Controls)
            {
                foreach (Control control in panelControls.Controls)
                {
                     if ((control is TextBox && !string.IsNullOrWhiteSpace(control.Text)  && ((KeyValuePair<List<string>, bool>)control.Tag).Key[0] == "number"))
                        {
                            int parsedValue;
                            if (!int.TryParse(control.Text, out parsedValue))
                            {
                                categoryErrors.SetError(control, "Please provide valid number");
                                validation = false;
                            }
                        }
                    

                 }
            }
            return validation;

        }

        public void createDocument()
        {
            var document = new ExpandoObject() as IDictionary<string, Object>;
            foreach (Control panelControls in categoryPanel.Controls)
            {
                foreach (Control control in panelControls.Controls)
                {
                    if (!(control is Label) && !(control is Button) && !(control is FlowLayoutPanel))
                    {
                        if (control is TextBox)
                        {
                            if (((TextBox)control).Multiline)
                            {
                                List<string> listItems = new List<string>();
                                foreach (string item in ((TextBox)control).Text.Split(','))
                                   listItems.Add(item.Trim());

                                document.Add(control.Name, listItems);
                            }
                            else
                            {
                                if (!string.IsNullOrWhiteSpace(control.Text))
                                {
                                    if (((KeyValuePair<List<string>, bool>)control.Tag).Key[0] == "number")
                                    { 
                                        document.Add(control.Name, Convert.ToInt32(control.Text));
                                    }
                                    else
                                    { 
                                        document.Add(control.Name, control.Text);
                                    }
                                }
                            }

                        }
                        else if (control is ListBox)
                        {
                            List<string> listItems = new List<string>();
                            foreach (var item in ((ListBox)control).SelectedItems)
                            {
                                listItems.Add(item.ToString());
                            }
                            document.Add(control.Name, listItems);
                        }
                        else if (control is ComboBox)
                        {
                            document.Add(control.Name, ((ComboBox)control).SelectedItem.ToString());

                        }
                    }
                }
            }

            // Add CreateDate 
            document.Add("createddate", DateTime.Now);
            string output = JsonConvert.SerializeObject(document,
                                Newtonsoft.Json.Formatting.None,
                                new JsonSerializerSettings
                                {
                                    NullValueHandling = NullValueHandling.Ignore
                                });

                string fileName = Global.ParentCategory + "-" + Global.Category + "-" + ((dynamic)document).manufacturer + "-"  + ((dynamic)document).model + ".json";

            if (Global.WorkingDirectory == string.Empty)
                {
                    MessageBox.Show("You have not set working directory yet! Please choose working directory under File");
                }
             else
                {
                    System.IO.File.WriteAllText(Global.WorkingDirectory + "\\" + Utility.GetFileName(fileName), output);
                    MessageBox.Show("Document Created!");
                }
        }

    }
}
