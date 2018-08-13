namespace Image_Auto_Compresser
{
    partial class RegexInput
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegexInput));
            this.regexInputBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.regexCheckStatus = new System.Windows.Forms.Label();
            this.addRegExBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // regexInputBox
            // 
            this.regexInputBox.Location = new System.Drawing.Point(12, 76);
            this.regexInputBox.Name = "regexInputBox";
            this.regexInputBox.Size = new System.Drawing.Size(360, 21);
            this.regexInputBox.TabIndex = 0;
            this.regexInputBox.TextChanged += new System.EventHandler(this.RegexInputBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(124, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "请输入正确的正则表达式";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(124, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "格式验证：";
            // 
            // regexCheckStatus
            // 
            this.regexCheckStatus.AutoSize = true;
            this.regexCheckStatus.ForeColor = System.Drawing.Color.Orange;
            this.regexCheckStatus.Location = new System.Drawing.Point(196, 47);
            this.regexCheckStatus.Name = "regexCheckStatus";
            this.regexCheckStatus.Size = new System.Drawing.Size(53, 12);
            this.regexCheckStatus.TabIndex = 3;
            this.regexCheckStatus.Text = "等待输入";
            // 
            // addRegExBtn
            // 
            this.addRegExBtn.Location = new System.Drawing.Point(155, 112);
            this.addRegExBtn.Name = "addRegExBtn";
            this.addRegExBtn.Size = new System.Drawing.Size(75, 23);
            this.addRegExBtn.TabIndex = 4;
            this.addRegExBtn.Text = "添加";
            this.addRegExBtn.UseVisualStyleBackColor = true;
            this.addRegExBtn.Click += new System.EventHandler(this.AddRegExBtn_Click);
            // 
            // RegexInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 147);
            this.Controls.Add(this.addRegExBtn);
            this.Controls.Add(this.regexCheckStatus);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.regexInputBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RegexInput";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "输入正则表达式";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RegexInput_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox regexInputBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label regexCheckStatus;
        private System.Windows.Forms.Button addRegExBtn;
    }
}