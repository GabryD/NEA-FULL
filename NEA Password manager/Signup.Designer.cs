namespace NEA_Password_manager
{
    partial class Signup
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
            this.Pinword = new System.Windows.Forms.TextBox();
            this.Email = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.sup = new System.Windows.Forms.Button();
            this.Back = new System.Windows.Forms.Button();
            this.Generate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Pinword
            // 
            this.Pinword.Location = new System.Drawing.Point(79, 191);
            this.Pinword.Name = "Pinword";
            this.Pinword.Size = new System.Drawing.Size(100, 20);
            this.Pinword.TabIndex = 0;
            this.Pinword.Text = "Pin";
            this.Pinword.TextChanged += new System.EventHandler(this.Pinword_TextChanged);
            // 
            // Email
            // 
            this.Email.Location = new System.Drawing.Point(79, 147);
            this.Email.Name = "Email";
            this.Email.Size = new System.Drawing.Size(100, 20);
            this.Email.TabIndex = 1;
            this.Email.Text = "Email Address";
            this.Email.TextChanged += new System.EventHandler(this.Email_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 33F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(60, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 52);
            this.label1.TabIndex = 3;
            this.label1.Text = "SOSA";
            // 
            // sup
            // 
            this.sup.Location = new System.Drawing.Point(89, 245);
            this.sup.Name = "sup";
            this.sup.Size = new System.Drawing.Size(75, 23);
            this.sup.TabIndex = 4;
            this.sup.Text = "Sign Up";
            this.sup.UseVisualStyleBackColor = true;
            this.sup.Click += new System.EventHandler(this.sup_Click);
            // 
            // Back
            // 
            this.Back.BackColor = System.Drawing.SystemColors.Control;
            this.Back.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Back.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Back.ForeColor = System.Drawing.SystemColors.Desktop;
            this.Back.Location = new System.Drawing.Point(7, 67);
            this.Back.Name = "Back";
            this.Back.Size = new System.Drawing.Size(47, 18);
            this.Back.TabIndex = 5;
            this.Back.Text = "Back";
            this.Back.UseVisualStyleBackColor = false;
            this.Back.Click += new System.EventHandler(this.Back_Click);
            // 
            // Generate
            // 
            this.Generate.Location = new System.Drawing.Point(89, 217);
            this.Generate.Name = "Generate";
            this.Generate.Size = new System.Drawing.Size(75, 22);
            this.Generate.TabIndex = 6;
            this.Generate.Text = "Generate";
            this.Generate.UseVisualStyleBackColor = true;
            this.Generate.Click += new System.EventHandler(this.Generate_Click);
            // 
            // Signup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(271, 450);
            this.Controls.Add(this.Generate);
            this.Controls.Add(this.Back);
            this.Controls.Add(this.sup);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Email);
            this.Controls.Add(this.Pinword);
            this.Name = "Signup";
            this.Text = "Signup";
            this.Load += new System.EventHandler(this.Signup_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Pinword;
        private System.Windows.Forms.TextBox Email;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button sup;
        private System.Windows.Forms.Button Back;
        private System.Windows.Forms.Button Generate;
    }
}