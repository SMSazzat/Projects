namespace StockManagementSystem
{
    partial class Action
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
            this.CategoryButton = new System.Windows.Forms.Button();
            this.CompanyButton = new System.Windows.Forms.Button();
            this.ItemButton = new System.Windows.Forms.Button();
            this.StockInButton = new System.Windows.Forms.Button();
            this.StockOutButton = new System.Windows.Forms.Button();
            this.SearchViewButton = new System.Windows.Forms.Button();
            this.ViewDatesButton = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // CategoryButton
            // 
            this.CategoryButton.Location = new System.Drawing.Point(143, 76);
            this.CategoryButton.Name = "CategoryButton";
            this.CategoryButton.Size = new System.Drawing.Size(212, 23);
            this.CategoryButton.TabIndex = 0;
            this.CategoryButton.Text = "Category Setup";
            this.CategoryButton.UseVisualStyleBackColor = true;
            this.CategoryButton.Click += new System.EventHandler(this.CategoryButton_Click);
            // 
            // CompanyButton
            // 
            this.CompanyButton.Location = new System.Drawing.Point(143, 105);
            this.CompanyButton.Name = "CompanyButton";
            this.CompanyButton.Size = new System.Drawing.Size(212, 23);
            this.CompanyButton.TabIndex = 0;
            this.CompanyButton.Text = "Company Setup";
            this.CompanyButton.UseVisualStyleBackColor = true;
            this.CompanyButton.Click += new System.EventHandler(this.CompanyButton_Click);
            // 
            // ItemButton
            // 
            this.ItemButton.Location = new System.Drawing.Point(143, 134);
            this.ItemButton.Name = "ItemButton";
            this.ItemButton.Size = new System.Drawing.Size(212, 23);
            this.ItemButton.TabIndex = 0;
            this.ItemButton.Text = "Item Setup";
            this.ItemButton.UseVisualStyleBackColor = true;
            this.ItemButton.Click += new System.EventHandler(this.ItemButton_Click);
            // 
            // StockInButton
            // 
            this.StockInButton.Location = new System.Drawing.Point(143, 163);
            this.StockInButton.Name = "StockInButton";
            this.StockInButton.Size = new System.Drawing.Size(212, 23);
            this.StockInButton.TabIndex = 0;
            this.StockInButton.Text = "Stock In";
            this.StockInButton.UseVisualStyleBackColor = true;
            this.StockInButton.Click += new System.EventHandler(this.StockInButton_Click);
            // 
            // StockOutButton
            // 
            this.StockOutButton.Location = new System.Drawing.Point(143, 192);
            this.StockOutButton.Name = "StockOutButton";
            this.StockOutButton.Size = new System.Drawing.Size(212, 23);
            this.StockOutButton.TabIndex = 0;
            this.StockOutButton.Text = "Stock Out";
            this.StockOutButton.UseVisualStyleBackColor = true;
            this.StockOutButton.Click += new System.EventHandler(this.StockOutButton_Click);
            // 
            // SearchViewButton
            // 
            this.SearchViewButton.Location = new System.Drawing.Point(143, 221);
            this.SearchViewButton.Name = "SearchViewButton";
            this.SearchViewButton.Size = new System.Drawing.Size(212, 23);
            this.SearchViewButton.TabIndex = 0;
            this.SearchViewButton.Text = "Search and View Summary";
            this.SearchViewButton.UseVisualStyleBackColor = true;
            this.SearchViewButton.Click += new System.EventHandler(this.SearchViewButton_Click);
            // 
            // ViewDatesButton
            // 
            this.ViewDatesButton.Location = new System.Drawing.Point(143, 250);
            this.ViewDatesButton.Name = "ViewDatesButton";
            this.ViewDatesButton.Size = new System.Drawing.Size(212, 23);
            this.ViewDatesButton.TabIndex = 0;
            this.ViewDatesButton.Text = "View Between Two Dates Report";
            this.ViewDatesButton.UseVisualStyleBackColor = true;
            this.ViewDatesButton.Click += new System.EventHandler(this.ViewDatesButton_Click);
            // 
            // ExitButton
            // 
            this.ExitButton.Location = new System.Drawing.Point(280, 279);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(75, 23);
            this.ExitButton.TabIndex = 0;
            this.ExitButton.Text = "Exit";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.DarkCyan;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(114, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(269, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "ABC STOCK MANAGEMENT SYSTEM";
            // 
            // Action
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(512, 333);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.ViewDatesButton);
            this.Controls.Add(this.SearchViewButton);
            this.Controls.Add(this.StockOutButton);
            this.Controls.Add(this.StockInButton);
            this.Controls.Add(this.ItemButton);
            this.Controls.Add(this.CompanyButton);
            this.Controls.Add(this.CategoryButton);
            this.Name = "Action";
            this.Text = "Action";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CategoryButton;
        private System.Windows.Forms.Button CompanyButton;
        private System.Windows.Forms.Button ItemButton;
        private System.Windows.Forms.Button StockInButton;
        private System.Windows.Forms.Button StockOutButton;
        private System.Windows.Forms.Button SearchViewButton;
        private System.Windows.Forms.Button ViewDatesButton;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Label label1;
    }
}