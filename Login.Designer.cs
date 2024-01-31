namespace NEA_Password_manager
{
    partial class Login
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
            this.Pin = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Log = new System.Windows.Forms.Button();
            this.Signup = new System.Windows.Forms.LinkLabel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // Pin
            // 
            this.Pin.BackColor = System.Drawing.SystemColors.Window;
            this.Pin.Location = new System.Drawing.Point(59, 138);
            this.Pin.Name = "Pin";
            this.Pin.Size = new System.Drawing.Size(135, 20);
            this.Pin.TabIndex = 0;
            this.Pin.Text = "Pin";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 33F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(51, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 52);
            this.label1.TabIndex = 2;
            this.label1.Text = "SOSA";
            // 
            // Log
            // 
            this.Log.Location = new System.Drawing.Point(88, 176);
            this.Log.Name = "Log";
            this.Log.Size = new System.Drawing.Size(75, 23);
            this.Log.TabIndex = 3;
            this.Log.Text = "Log In";
            this.Log.UseVisualStyleBackColor = true;
            this.Log.Click += new System.EventHandler(this.Log_Click);
            // 
            // Signup
            // 
            this.Signup.AutoSize = true;
            this.Signup.Location = new System.Drawing.Point(57, 233);
            this.Signup.Name = "Signup";
            this.Signup.Size = new System.Drawing.Size(45, 13);
            this.Signup.TabIndex = 4;
            this.Signup.TabStop = true;
            this.Signup.Text = "Sign Up";
            this.Signup.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Signup_LinkClicked);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(56, 211);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(107, 13);
            this.linkLabel1.TabIndex = 5;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Forgotten Password?";
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(257, 450);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.Signup);
            this.Controls.Add(this.Log);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Pin);
            this.Name = "Login";
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Login_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Pin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Log;
        private System.Windows.Forms.LinkLabel Signup;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}