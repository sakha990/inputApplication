namespace inputApplication
{
    partial class MetaData
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
            this.label1 = new System.Windows.Forms.Label();
            this.cbxParentCategory = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxCategory = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbxPropertyName = new System.Windows.Forms.ComboBox();
            this.tbxPropertyValue = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(131, 46);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 18);
            this.label1.TabIndex = 3;
            this.label1.Text = "Parent Category";
            // 
            // cbxParentCategory
            // 
            this.cbxParentCategory.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbxParentCategory.FormattingEnabled = true;
            this.cbxParentCategory.Location = new System.Drawing.Point(277, 46);
            this.cbxParentCategory.Margin = new System.Windows.Forms.Padding(4);
            this.cbxParentCategory.Name = "cbxParentCategory";
            this.cbxParentCategory.Size = new System.Drawing.Size(232, 21);
            this.cbxParentCategory.TabIndex = 2;
            this.cbxParentCategory.SelectedIndexChanged += new System.EventHandler(this.cbxParentCategory_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(132, 115);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 18);
            this.label2.TabIndex = 5;
            this.label2.Text = "Category";
            // 
            // cbxCategory
            // 
            this.cbxCategory.FormattingEnabled = true;
            this.cbxCategory.Location = new System.Drawing.Point(277, 115);
            this.cbxCategory.Margin = new System.Windows.Forms.Padding(4);
            this.cbxCategory.Name = "cbxCategory";
            this.cbxCategory.Size = new System.Drawing.Size(232, 21);
            this.cbxCategory.TabIndex = 4;
            this.cbxCategory.SelectedIndexChanged += new System.EventHandler(this.cbxCategory_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(132, 177);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 18);
            this.label3.TabIndex = 7;
            this.label3.Text = "Property";
            // 
            // cbxPropertyName
            // 
            this.cbxPropertyName.FormattingEnabled = true;
            this.cbxPropertyName.Location = new System.Drawing.Point(277, 177);
            this.cbxPropertyName.Margin = new System.Windows.Forms.Padding(4);
            this.cbxPropertyName.Name = "cbxPropertyName";
            this.cbxPropertyName.Size = new System.Drawing.Size(232, 21);
            this.cbxPropertyName.TabIndex = 6;
            // 
            // tbxPropertyValue
            // 
            this.tbxPropertyValue.Location = new System.Drawing.Point(277, 240);
            this.tbxPropertyValue.Name = "tbxPropertyValue";
            this.tbxPropertyValue.Size = new System.Drawing.Size(273, 20);
            this.tbxPropertyValue.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(131, 242);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 18);
            this.label4.TabIndex = 9;
            this.label4.Text = "New Value";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.button1.Location = new System.Drawing.Point(277, 289);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(150, 50);
            this.button1.TabIndex = 10;
            this.button1.Text = "Add Value";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MetaData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(755, 351);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbxPropertyValue);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbxPropertyName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbxCategory);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbxParentCategory);
            this.Name = "MetaData";
            this.Text = "MetaData";
            this.Load += new System.EventHandler(this.MetaData_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxParentCategory;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbxCategory;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbxPropertyName;
        private System.Windows.Forms.TextBox tbxPropertyValue;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
    }
}