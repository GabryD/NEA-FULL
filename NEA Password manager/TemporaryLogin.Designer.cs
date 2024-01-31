namespace NEA_Password_manager
{
    partial class TemporaryLogin
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
            this.Temporary = new System.Windows.Forms.TextBox();
            this.TLOG = new System.Windows.Forms.Button();
            this.Back = new System.Windows.Forms.Label();
            this.TIMER = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // Temporary
            // 
            this.Temporary.Location = new System.Drawing.Point(99, 94);
            this.Temporary.Name = "Temporary";
            this.Temporary.Size = new System.Drawing.Size(100, 20);
            this.Temporary.TabIndex = 0;
            this.Temporary.Text = "Temporary Pin";
            // 
            // TLOG
            // 
            this.TLOG.Location = new System.Drawing.Point(108, 120);
            this.TLOG.Name = "TLOG";
            this.TLOG.Size = new System.Drawing.Size(75, 23);
            this.TLOG.TabIndex = 1;
            this.TLOG.Text = "TLOG";
            this.TLOG.UseVisualStyleBackColor = true;
            this.TLOG.Click += new System.EventHandler(this.TLOG_Click);
            // 
            // Back
            // 
            this.Back.AutoSize = true;
            this.Back.Location = new System.Drawing.Point(11, 7);
            this.Back.Name = "Back";
            this.Back.Size = new System.Drawing.Size(32, 13);
            this.Back.TabIndex = 2;
            this.Back.Text = "Back";
            this.Back.Click += new System.EventHandler(this.Back_Click);
            // 
            // TIMER
            // 
            this.TIMER.Enabled = true;
            this.TIMER.Interval = 60000;
            this.TIMER.Tick += new System.EventHandler(this.TIMER_Tick);
            // 
            // TemporaryLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 149);
            this.Controls.Add(this.Back);
            this.Controls.Add(this.TLOG);
            this.Controls.Add(this.Temporary);
            this.Name = "TemporaryLogin";
            this.Text = "TemporaryLogin";
            this.Load += new System.EventHandler(this.TemporaryLogin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Temporary;
        private System.Windows.Forms.Button TLOG;
        private System.Windows.Forms.Label Back;
        private System.Windows.Forms.Timer TIMER;
    }
}