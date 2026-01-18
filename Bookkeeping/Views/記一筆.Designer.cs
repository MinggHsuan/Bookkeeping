namespace Bookkeeping
{
    partial class 記一筆
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
            this.button1 = new System.Windows.Forms.Button();
            this.navbar1 = new Bookkeeping.Components.Navbar();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(775, 28);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(126, 58);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // navbar1
            // 
            this.navbar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.navbar1.Location = new System.Drawing.Point(0, 359);
            this.navbar1.Name = "navbar1";
            this.navbar1.Size = new System.Drawing.Size(929, 91);
            this.navbar1.TabIndex = 2;
            // 
            // 記一筆
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(929, 450);
            this.Controls.Add(this.navbar1);
            this.Controls.Add(this.button1);
            this.Name = "記一筆";
            this.Text = "記一筆";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private Components.Navbar navbar1;
    }
}