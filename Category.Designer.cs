namespace inputApplication
{
    partial class CategoryForm
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
            this.components = new System.ComponentModel.Container();
            this.categoryPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.categoryErrors = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.categoryErrors)).BeginInit();
            this.SuspendLayout();
            // 
            // categoryPanel
            // 
            this.categoryPanel.AutoSize = true;
            this.categoryPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.categoryPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.categoryPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.categoryPanel.Location = new System.Drawing.Point(0, 0);
            this.categoryPanel.Name = "categoryPanel";
            this.categoryPanel.Size = new System.Drawing.Size(481, 293);
            this.categoryPanel.TabIndex = 0;
            // 
            // categoryErrors
            // 
            this.categoryErrors.ContainerControl = this;
            // 
            // CategoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(481, 293);
            this.Controls.Add(this.categoryPanel);
            this.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.Name = "CategoryForm";
            this.Text = "Category";
            this.Load += new System.EventHandler(this.CategoryForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.categoryErrors)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel categoryPanel;
        private System.Windows.Forms.ErrorProvider categoryErrors;
    }
}