namespace inputApplication
{
    partial class ParentForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setWorkingDirectoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createMetaDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.catgoriesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mergeDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.workingDirectoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inputApplicationDS = new System.Data.DataSet();
            this.dataTable1 = new System.Data.DataTable();
            this.parentCategory = new System.Data.DataColumn();
            this.category = new System.Data.DataColumn();
            this.property = new System.Data.DataColumn();
            this.dataColumn3 = new System.Data.DataColumn();
            this.values = new System.Data.DataTable();
            this.dataColumn1 = new System.Data.DataColumn();
            this.dataColumn2 = new System.Data.DataColumn();
            this.workingDirectory = new System.Windows.Forms.FolderBrowserDialog();
            this.mainMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.inputApplicationDS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.values)).BeginInit();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.catgoriesToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.workingDirectoryToolStripMenuItem});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Padding = new System.Windows.Forms.Padding(8, 3, 0, 3);
            this.mainMenu.Size = new System.Drawing.Size(1211, 25);
            this.mainMenu.TabIndex = 0;
            this.mainMenu.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setWorkingDirectoryToolStripMenuItem,
            this.createMetaDataToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 19);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // setWorkingDirectoryToolStripMenuItem
            // 
            this.setWorkingDirectoryToolStripMenuItem.Name = "setWorkingDirectoryToolStripMenuItem";
            this.setWorkingDirectoryToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.setWorkingDirectoryToolStripMenuItem.Text = "Set Working Directory";
            this.setWorkingDirectoryToolStripMenuItem.Click += new System.EventHandler(this.setWorkingDirectoryToolStripMenuItem_Click);
            // 
            // createMetaDataToolStripMenuItem
            // 
            this.createMetaDataToolStripMenuItem.Name = "createMetaDataToolStripMenuItem";
            this.createMetaDataToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.createMetaDataToolStripMenuItem.Text = "Create New Values";
            this.createMetaDataToolStripMenuItem.Click += new System.EventHandler(this.createMetaDataToolStripMenuItem_Click);
            // 
            // catgoriesToolStripMenuItem
            // 
            this.catgoriesToolStripMenuItem.Name = "catgoriesToolStripMenuItem";
            this.catgoriesToolStripMenuItem.Size = new System.Drawing.Size(69, 19);
            this.catgoriesToolStripMenuItem.Text = "Catgories";
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mergeDataToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(48, 19);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // mergeDataToolStripMenuItem
            // 
            this.mergeDataToolStripMenuItem.Name = "mergeDataToolStripMenuItem";
            this.mergeDataToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.mergeDataToolStripMenuItem.Text = "Get Updates";
            this.mergeDataToolStripMenuItem.Click += new System.EventHandler(this.mergeDataToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 19);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // workingDirectoryToolStripMenuItem
            // 
            this.workingDirectoryToolStripMenuItem.ForeColor = System.Drawing.Color.Red;
            this.workingDirectoryToolStripMenuItem.Name = "workingDirectoryToolStripMenuItem";
            this.workingDirectoryToolStripMenuItem.Size = new System.Drawing.Size(281, 19);
            this.workingDirectoryToolStripMenuItem.Text = "Please Choose working directory under file menu ";
            // 
            // inputApplicationDS
            // 
            this.inputApplicationDS.DataSetName = "inputApplicationDS";
            this.inputApplicationDS.EnforceConstraints = false;
            this.inputApplicationDS.Locale = new System.Globalization.CultureInfo("en");
            this.inputApplicationDS.Tables.AddRange(new System.Data.DataTable[] {
            this.dataTable1,
            this.values});
            // 
            // dataTable1
            // 
            this.dataTable1.Columns.AddRange(new System.Data.DataColumn[] {
            this.parentCategory,
            this.category,
            this.property,
            this.dataColumn3});
            this.dataTable1.Constraints.AddRange(new System.Data.Constraint[] {
            new System.Data.UniqueConstraint("Constraint1", new string[] {
                        "propertyId"}, true)});
            this.dataTable1.PrimaryKey = new System.Data.DataColumn[] {
        this.dataColumn3};
            this.dataTable1.TableName = "Properties";
            // 
            // parentCategory
            // 
            this.parentCategory.AllowDBNull = false;
            this.parentCategory.ColumnName = "parentCategory";
            // 
            // category
            // 
            this.category.AllowDBNull = false;
            this.category.Caption = "category";
            this.category.ColumnName = "category";
            // 
            // property
            // 
            this.property.AllowDBNull = false;
            this.property.ColumnName = "propertyName";
            // 
            // dataColumn3
            // 
            this.dataColumn3.AllowDBNull = false;
            this.dataColumn3.ColumnName = "propertyId";
            this.dataColumn3.DataType = typeof(int);
            // 
            // values
            // 
            this.values.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn1,
            this.dataColumn2});
            this.values.Constraints.AddRange(new System.Data.Constraint[] {
            new System.Data.UniqueConstraint("Constraint1", new string[] {
                        "propertyId",
                        "propertyValue"}, true),
            new System.Data.ForeignKeyConstraint("foreignkey", "Properties", new string[] {
                        "propertyId"}, new string[] {
                        "propertyId"}, System.Data.AcceptRejectRule.None, System.Data.Rule.Cascade, System.Data.Rule.Cascade)});
            this.values.PrimaryKey = new System.Data.DataColumn[] {
        this.dataColumn1,
        this.dataColumn2};
            this.values.TableName = "PropertyValues";
            // 
            // dataColumn1
            // 
            this.dataColumn1.AllowDBNull = false;
            this.dataColumn1.ColumnName = "propertyId";
            this.dataColumn1.DataType = typeof(int);
            // 
            // dataColumn2
            // 
            this.dataColumn2.AllowDBNull = false;
            this.dataColumn2.ColumnName = "propertyValue";
            // 
            // workingDirectory
            // 
            this.workingDirectory.RootFolder = System.Environment.SpecialFolder.MyComputer;
            // 
            // ParentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1211, 660);
            this.Controls.Add(this.mainMenu);
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.mainMenu;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ParentForm";
            this.Text = "Compare";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.inputApplicationDS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.values)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripMenuItem catgoriesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Data.DataSet inputApplicationDS;
        private System.Data.DataTable dataTable1;
        private System.Data.DataColumn parentCategory;
        private System.Data.DataColumn category;
        private System.Data.DataColumn property;
        private System.Data.DataTable values;
        private System.Data.DataColumn dataColumn1;
        private System.Data.DataColumn dataColumn2;
        private System.Windows.Forms.FolderBrowserDialog workingDirectory;
        private System.Windows.Forms.ToolStripMenuItem workingDirectoryToolStripMenuItem;
        private System.Data.DataColumn dataColumn3;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setWorkingDirectoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createMetaDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mergeDataToolStripMenuItem;
    }
}

