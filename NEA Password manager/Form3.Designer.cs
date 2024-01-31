namespace NEA_Password_manager
{
    partial class Form3
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
            this.settings1 = new NEA_Password_manager.Settings();
            this.SuspendLayout();
            // 
            // settings1
            // 
            this.settings1.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.settings1.Location = new System.Drawing.Point(2, 2);
            this.settings1.Name = "settings1";
            this.settings1.Size = new System.Drawing.Size(977, 600);
            this.settings1.TabIndex = 0;
            this.settings1.Load += new System.EventHandler(this.settings1_Load);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(978, 604);
            this.Controls.Add(this.settings1);
            this.Name = "Form3";
            this.Text = "Form3";
            this.ResumeLayout(false);

        }

        #endregion

        private Settings settings1;
    }
}