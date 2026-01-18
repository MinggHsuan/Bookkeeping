namespace Bookkeeping
{
    partial class 記帳本
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

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.navbar1 = new Bookkeeping.Components.Navbar();
            this.SuspendLayout();
            // 
            // navbar1
            // 
            this.navbar1.Location = new System.Drawing.Point(1, 360);
            this.navbar1.Name = "navbar1";
            this.navbar1.Size = new System.Drawing.Size(384, 91);
            this.navbar1.TabIndex = 0;
            // 
            // 記帳本
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.navbar1);
            this.Name = "記帳本";
            this.Text = "記帳本";
            this.ResumeLayout(false);

        }

        #endregion

        private Components.Navbar navbar1;
    }
}

