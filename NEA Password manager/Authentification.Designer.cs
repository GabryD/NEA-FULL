namespace NEA_Password_manager
{
    partial class Authentification
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
            this.Phone = new System.Windows.Forms.TextBox();
            this.FAenabled = new System.Windows.Forms.CheckBox();
            this.Save = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Phone
            // 
            this.Phone.Location = new System.Drawing.Point(42, 126);
            this.Phone.Name = "Phone";
            this.Phone.Size = new System.Drawing.Size(157, 20);
            this.Phone.TabIndex = 0;
            // 
            // FAenabled
            // 
            this.FAenabled.AutoSize = true;
            this.FAenabled.Location = new System.Drawing.Point(42, 171);
            this.FAenabled.Name = "FAenabled";
            this.FAenabled.Size = new System.Drawing.Size(65, 17);
            this.FAenabled.TabIndex = 1;
            this.FAenabled.Text = "Enabled";
            this.FAenabled.UseVisualStyleBackColor = true;
            // 
            // Save
            // 
            this.Save.Location = new System.Drawing.Point(66, 296);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(119, 28);
            this.Save.TabIndex = 2;
            this.Save.Text = "Save";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // Authentification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(241, 406);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.FAenabled);
            this.Controls.Add(this.Phone);
            this.Name = "Authentification";
            this.Text = "Authentification";
            this.Load += new System.EventHandler(this.Authentification_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Phone;
        private System.Windows.Forms.CheckBox FAenabled;
        private System.Windows.Forms.Button Save;
    }
}