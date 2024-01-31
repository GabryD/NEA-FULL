namespace NEA_Password_manager
{
    partial class EditDelete
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
            this.Editweb = new System.Windows.Forms.TextBox();
            this.Edituser = new System.Windows.Forms.TextBox();
            this.Editpass = new System.Windows.Forms.TextBox();
            this.Update = new System.Windows.Forms.Button();
            this.Delete = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Editweb
            // 
            this.Editweb.Location = new System.Drawing.Point(46, 78);
            this.Editweb.Name = "Editweb";
            this.Editweb.Size = new System.Drawing.Size(132, 20);
            this.Editweb.TabIndex = 0;
            // 
            // Edituser
            // 
            this.Edituser.Location = new System.Drawing.Point(46, 120);
            this.Edituser.Name = "Edituser";
            this.Edituser.Size = new System.Drawing.Size(132, 20);
            this.Edituser.TabIndex = 1;
            // 
            // Editpass
            // 
            this.Editpass.Location = new System.Drawing.Point(46, 159);
            this.Editpass.Name = "Editpass";
            this.Editpass.Size = new System.Drawing.Size(132, 20);
            this.Editpass.TabIndex = 2;
            // 
            // Update
            // 
            this.Update.Location = new System.Drawing.Point(72, 225);
            this.Update.Name = "Update";
            this.Update.Size = new System.Drawing.Size(75, 23);
            this.Update.TabIndex = 3;
            this.Update.Text = "Update";
            this.Update.UseVisualStyleBackColor = true;
            this.Update.Click += new System.EventHandler(this.Update_Click);
            // 
            // Delete
            // 
            this.Delete.Location = new System.Drawing.Point(72, 254);
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(75, 23);
            this.Delete.TabIndex = 4;
            this.Delete.Text = "Delete";
            this.Delete.UseVisualStyleBackColor = true;
            this.Delete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // EditDelete
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(215, 450);
            this.Controls.Add(this.Delete);
            this.Controls.Add(this.Update);
            this.Controls.Add(this.Editpass);
            this.Controls.Add(this.Edituser);
            this.Controls.Add(this.Editweb);
            this.Name = "EditDelete";
            this.Text = "EditDelete";
            this.Load += new System.EventHandler(this.EditDelete_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.TextBox Editweb;
        internal System.Windows.Forms.TextBox Edituser;
        internal System.Windows.Forms.TextBox Editpass;
#pragma warning disable CS0108 // Member hides inherited member; missing new keyword
        internal System.Windows.Forms.Button Update;
#pragma warning restore CS0108 // Member hides inherited member; missing new keyword
        internal System.Windows.Forms.Button Delete;
    }
}