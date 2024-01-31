
namespace NEA_Password_manager
{
    partial class Form2
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
            this.F2Website = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.F2Username = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.F2Password = new System.Windows.Forms.TextBox();
            this.Save = new System.Windows.Forms.Button();
            this.Location = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // F2Website
            // 
            this.F2Website.AllowDrop = true;
            this.F2Website.AutoCompleteCustomSource.AddRange(new string[] {
            "Google",
            "Youtube",
            "Facebook",
            "Instagram",
            "Twitter",
            "Wikipedia",
            "Yahoo",
            "Yandex",
            "Amazon",
            "TikTok",
            "OutLook",
            "Reddit",
            "OpenAi",
            "ChatGpt",
            "Linkedin",
            "Office",
            "Netflix",
            "Microsoft",
            "Apple",
            "Discord",
            "Twitch",
            "PayPal",
            "Imdb",
            "BBC",
            "Bloomberg",
            "Snapchat",
            "Spotify",
            "Uber",
            "McDonalds",
            "NordVPN",
            "Bolt",
            ""});
            this.F2Website.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.F2Website.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.F2Website.Location = new System.Drawing.Point(101, 76);
            this.F2Website.Name = "F2Website";
            this.F2Website.Size = new System.Drawing.Size(141, 20);
            this.F2Website.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Website";
            // 
            // F2Username
            // 
            this.F2Username.Location = new System.Drawing.Point(101, 109);
            this.F2Username.Name = "F2Username";
            this.F2Username.Size = new System.Drawing.Size(141, 20);
            this.F2Username.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "User Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 146);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Password";
            // 
            // F2Password
            // 
            this.F2Password.Location = new System.Drawing.Point(101, 143);
            this.F2Password.Name = "F2Password";
            this.F2Password.Size = new System.Drawing.Size(141, 20);
            this.F2Password.TabIndex = 6;
            // 
            // Save
            // 
            this.Save.Location = new System.Drawing.Point(110, 218);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(75, 23);
            this.Save.TabIndex = 8;
            this.Save.Text = "Save";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // Location
            // 
            this.Location.FormattingEnabled = true;
            this.Location.Items.AddRange(new object[] {
            "Favourite",
            "Work",
            "School"});
            this.Location.Location = new System.Drawing.Point(101, 180);
            this.Location.Name = "Location";
            this.Location.Size = new System.Drawing.Size(141, 21);
            this.Location.TabIndex = 9;
            this.Location.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 183);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Location";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(302, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Location);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.F2Password);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.F2Username);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.F2Website);
            this.Name = "Form2";
            this.Text = "New Password";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox F2Website;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox F2Username;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox F2Password;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.ComboBox Location;
        private System.Windows.Forms.Label label1;
    }
}