namespace Bookkeeping.Components
{
    partial class Navbar
    {
        /// <summary> 
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 元件設計工具產生的程式碼

        /// <summary> 
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(96, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(99, 91);
            this.button1.TabIndex = 0;
            this.button1.Text = "記一筆";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.ChoosePage);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(0, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(99, 91);
            this.button2.TabIndex = 1;
            this.button2.Text = "記帳本";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.ChoosePage);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(191, 0);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(99, 91);
            this.button3.TabIndex = 2;
            this.button3.Text = "圖表分析";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.ChoosePage);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(286, 0);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(99, 91);
            this.button4.TabIndex = 3;
            this.button4.Text = "帳戶分析";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.ChoosePage);
            // 
            // Navbar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Navbar";
            this.Size = new System.Drawing.Size(384, 91);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
    }
}
