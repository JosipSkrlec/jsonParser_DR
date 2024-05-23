
namespace JsonParser
{
    partial class DeltaReality_JsonParser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeltaReality_JsonParser));
            this.DeltaRealityGif = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.BrowseJsonButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DeltaRealityGif)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DeltaRealityGif
            // 
            resources.ApplyResources(this.DeltaRealityGif, "DeltaRealityGif");
            this.DeltaRealityGif.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.DeltaRealityGif.Name = "DeltaRealityGif";
            this.DeltaRealityGif.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.BrowseJsonButton);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // textBox1
            // 
            resources.ApplyResources(this.textBox1, "textBox1");
            this.textBox1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.textBox1.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.textBox1.Name = "textBox1";
            // 
            // BrowseJsonButton
            // 
            resources.ApplyResources(this.BrowseJsonButton, "BrowseJsonButton");
            this.BrowseJsonButton.Name = "BrowseJsonButton";
            this.BrowseJsonButton.UseVisualStyleBackColor = true;
            // 
            // DeltaReality_JsonParser
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            resources.ApplyResources(this, "$this");
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.DeltaRealityGif);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DeltaReality_JsonParser";
            this.Opacity = 0.9D;
            ((System.ComponentModel.ISupportInitialize)(this.DeltaRealityGif)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox DeltaRealityGif;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BrowseJsonButton;
        private System.Windows.Forms.TextBox textBox1;
    }
}

