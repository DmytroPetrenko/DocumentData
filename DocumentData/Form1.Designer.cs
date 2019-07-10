namespace DocumentData
{
    partial class Form1
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.StartBtn = new System.Windows.Forms.Button();
            this.YearComboBox = new System.Windows.Forms.ComboBox();
            this.OvuNumberComboBox = new System.Windows.Forms.ComboBox();
            this.SelectFolderToSaveBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(68, 69);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(656, 203);
            this.textBox1.TabIndex = 0;
            // 
            // StartBtn
            // 
            this.StartBtn.Location = new System.Drawing.Point(396, 321);
            this.StartBtn.Name = "StartBtn";
            this.StartBtn.Size = new System.Drawing.Size(119, 23);
            this.StartBtn.TabIndex = 1;
            this.StartBtn.Text = "Start";
            this.StartBtn.UseVisualStyleBackColor = true;
            this.StartBtn.Click += new System.EventHandler(this.StartBtn_Click);
            // 
            // YearComboBox
            // 
            this.YearComboBox.FormattingEnabled = true;
            this.YearComboBox.Location = new System.Drawing.Point(142, 323);
            this.YearComboBox.Name = "YearComboBox";
            this.YearComboBox.Size = new System.Drawing.Size(121, 21);
            this.YearComboBox.TabIndex = 2;
            // 
            // OvuNumberComboBox
            // 
            this.OvuNumberComboBox.FormattingEnabled = true;
            this.OvuNumberComboBox.Location = new System.Drawing.Point(269, 323);
            this.OvuNumberComboBox.Name = "OvuNumberComboBox";
            this.OvuNumberComboBox.Size = new System.Drawing.Size(121, 21);
            this.OvuNumberComboBox.TabIndex = 3;
            // 
            // SelectFolderToSaveBtn
            // 
            this.SelectFolderToSaveBtn.Location = new System.Drawing.Point(522, 321);
            this.SelectFolderToSaveBtn.Name = "SelectFolderToSaveBtn";
            this.SelectFolderToSaveBtn.Size = new System.Drawing.Size(134, 23);
            this.SelectFolderToSaveBtn.TabIndex = 4;
            this.SelectFolderToSaveBtn.Text = "Select folder to save";
            this.SelectFolderToSaveBtn.UseVisualStyleBackColor = true;
            this.SelectFolderToSaveBtn.Click += new System.EventHandler(this.SelectFolderToSaveBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.SelectFolderToSaveBtn);
            this.Controls.Add(this.OvuNumberComboBox);
            this.Controls.Add(this.YearComboBox);
            this.Controls.Add(this.StartBtn);
            this.Controls.Add(this.textBox1);
            this.Name = "Form1";
            this.Text = "DocumentData";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button StartBtn;
        private System.Windows.Forms.ComboBox YearComboBox;
        private System.Windows.Forms.ComboBox OvuNumberComboBox;
        private System.Windows.Forms.Button SelectFolderToSaveBtn;
    }
}

