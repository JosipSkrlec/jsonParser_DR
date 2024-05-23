
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
            this.DRGifLoader = new System.Windows.Forms.PictureBox();
            this.JsonFileLoader = new System.Windows.Forms.Panel();
            this.DropJsonText = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.DRGifLoader)).BeginInit();
            this.JsonFileLoader.SuspendLayout();
            this.SuspendLayout();
            // 
            // DRGifLoader
            // 
            this.DRGifLoader.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.DRGifLoader.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.DRGifLoader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DRGifLoader.Image = ((System.Drawing.Image)(resources.GetObject("DRGifLoader.Image")));
            this.DRGifLoader.InitialImage = null;
            this.DRGifLoader.Location = new System.Drawing.Point(0, 0);
            this.DRGifLoader.Name = "DRGifLoader";
            this.DRGifLoader.Size = new System.Drawing.Size(784, 461);
            this.DRGifLoader.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.DRGifLoader.TabIndex = 0;
            this.DRGifLoader.TabStop = false;
            // 
            // JsonFileLoader
            // 
            this.JsonFileLoader.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.JsonFileLoader.Controls.Add(this.DropJsonText);
            this.JsonFileLoader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.JsonFileLoader.Location = new System.Drawing.Point(0, 0);
            this.JsonFileLoader.Name = "JsonFileLoader";
            this.JsonFileLoader.Size = new System.Drawing.Size(784, 461);
            this.JsonFileLoader.TabIndex = 1;
            // 
            // DropJsonText
            // 
            this.DropJsonText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DropJsonText.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.DropJsonText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DropJsonText.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.DropJsonText.Enabled = false;
            this.DropJsonText.Font = new System.Drawing.Font("Microsoft Yi Baiti", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DropJsonText.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.DropJsonText.Location = new System.Drawing.Point(219, 207);
            this.DropJsonText.Name = "DropJsonText";
            this.DropJsonText.Size = new System.Drawing.Size(306, 36);
            this.DropJsonText.TabIndex = 1;
            this.DropJsonText.Text = "Drop .json file here!";
            this.DropJsonText.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // DeltaReality_JsonParser
            // 
            this.AllowDrop = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.DRGifLoader);
            this.Controls.Add(this.JsonFileLoader);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DeltaReality_JsonParser";
            this.Text = "Delta Reality Json Parser";
            ((System.ComponentModel.ISupportInitialize)(this.DRGifLoader)).EndInit();
            this.JsonFileLoader.ResumeLayout(false);
            this.JsonFileLoader.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox DRGifLoader;
        private System.Windows.Forms.Panel JsonFileLoader;
        private System.Windows.Forms.TextBox DropJsonText;
    }
}

