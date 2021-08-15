namespace Duplicate
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dir_text = new System.Windows.Forms.TextBox();
            this.dir_button = new System.Windows.Forms.Button();
            this.start_button = new System.Windows.Forms.Button();
            this.listbox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // dir_text
            // 
            this.dir_text.Location = new System.Drawing.Point(30, 44);
            this.dir_text.Name = "dir_text";
            this.dir_text.Size = new System.Drawing.Size(546, 23);
            this.dir_text.TabIndex = 0;
            // 
            // dir_button
            // 
            this.dir_button.Location = new System.Drawing.Point(644, 44);
            this.dir_button.Name = "dir_button";
            this.dir_button.Size = new System.Drawing.Size(116, 23);
            this.dir_button.TabIndex = 1;
            this.dir_button.Text = "Select Folder";
            this.dir_button.UseVisualStyleBackColor = true;
            this.dir_button.Click += new System.EventHandler(this.Dir_Button_Click);
            // 
            // start_button
            // 
            this.start_button.Location = new System.Drawing.Point(644, 92);
            this.start_button.Name = "start_button";
            this.start_button.Size = new System.Drawing.Size(116, 23);
            this.start_button.TabIndex = 2;
            this.start_button.Text = "Find Duplicates";
            this.start_button.UseVisualStyleBackColor = true;
            this.start_button.Click += new System.EventHandler(this.start_button_Click);
            // 
            // listbox
            // 
            this.listbox.FormattingEnabled = true;
            this.listbox.HorizontalScrollbar = true;
            this.listbox.ItemHeight = 15;
            this.listbox.Location = new System.Drawing.Point(30, 92);
            this.listbox.Name = "listbox";
            this.listbox.Size = new System.Drawing.Size(597, 334);
            this.listbox.TabIndex = 3;
            this.listbox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listbox_MouseDoubleClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.listbox);
            this.Controls.Add(this.start_button);
            this.Controls.Add(this.dir_button);
            this.Controls.Add(this.dir_text);
            this.Name = "Form1";
            this.Text = "Duplicate";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox dir_text;
        private System.Windows.Forms.Button dir_button;
        private System.Windows.Forms.Button start_button;
        private System.Windows.Forms.ListBox listbox;
    }
}

