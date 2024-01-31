
namespace NEA_Password_manager
{
    partial class Settings
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Saved = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // Saved
            // 
            this.Saved.ActiveLinkColor = System.Drawing.Color.Snow;
            this.Saved.AutoSize = true;
            this.Saved.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Saved.Location = new System.Drawing.Point(15, 74);
            this.Saved.Name = "Saved";
            this.Saved.Size = new System.Drawing.Size(64, 13);
            this.Saved.TabIndex = 0;
            this.Saved.TabStop = true;
            this.Saved.Text = "Saved Data";
            this.Saved.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.Controls.Add(this.Saved);
            this.Name = "Settings";
            this.Size = new System.Drawing.Size(810, 590);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel Saved;
    }
}
