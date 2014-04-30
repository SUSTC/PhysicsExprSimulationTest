namespace PhysicsExprHelper
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.tbLog = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnGetPaper = new System.Windows.Forms.Button();
            this.btnGetExamScore = new System.Windows.Forms.Button();
            this.btnGetPaperContent = new System.Windows.Forms.Button();
            this.btnGetSubmitted = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbLog
            // 
            this.tbLog.Location = new System.Drawing.Point(12, 12);
            this.tbLog.Multiline = true;
            this.tbLog.Name = "tbLog";
            this.tbLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbLog.Size = new System.Drawing.Size(753, 335);
            this.tbLog.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 353);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 31);
            this.button1.TabIndex = 1;
            this.button1.Text = "Login";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnGetPaper
            // 
            this.btnGetPaper.Location = new System.Drawing.Point(95, 353);
            this.btnGetPaper.Name = "btnGetPaper";
            this.btnGetPaper.Size = new System.Drawing.Size(77, 31);
            this.btnGetPaper.TabIndex = 2;
            this.btnGetPaper.Text = "GetPaper";
            this.btnGetPaper.UseVisualStyleBackColor = true;
            this.btnGetPaper.Click += new System.EventHandler(this.btnGetPaper_Click);
            // 
            // btnGetExamScore
            // 
            this.btnGetExamScore.Location = new System.Drawing.Point(179, 353);
            this.btnGetExamScore.Name = "btnGetExamScore";
            this.btnGetExamScore.Size = new System.Drawing.Size(89, 31);
            this.btnGetExamScore.TabIndex = 3;
            this.btnGetExamScore.Text = "GetExamScore";
            this.btnGetExamScore.UseVisualStyleBackColor = true;
            this.btnGetExamScore.Click += new System.EventHandler(this.btnGetExamScore_Click);
            // 
            // btnGetPaperContent
            // 
            this.btnGetPaperContent.Location = new System.Drawing.Point(274, 353);
            this.btnGetPaperContent.Name = "btnGetPaperContent";
            this.btnGetPaperContent.Size = new System.Drawing.Size(105, 31);
            this.btnGetPaperContent.TabIndex = 4;
            this.btnGetPaperContent.Text = "GetPaperContent";
            this.btnGetPaperContent.UseVisualStyleBackColor = true;
            this.btnGetPaperContent.Click += new System.EventHandler(this.btnGetPaperContent_Click);
            // 
            // btnGetSubmitted
            // 
            this.btnGetSubmitted.Location = new System.Drawing.Point(385, 353);
            this.btnGetSubmitted.Name = "btnGetSubmitted";
            this.btnGetSubmitted.Size = new System.Drawing.Size(105, 31);
            this.btnGetSubmitted.TabIndex = 5;
            this.btnGetSubmitted.Text = "GetSubmitted";
            this.btnGetSubmitted.UseVisualStyleBackColor = true;
            this.btnGetSubmitted.Click += new System.EventHandler(this.btnGetSubmitted_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(777, 396);
            this.Controls.Add(this.btnGetSubmitted);
            this.Controls.Add(this.btnGetPaperContent);
            this.Controls.Add(this.btnGetExamScore);
            this.Controls.Add(this.btnGetPaper);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tbLog);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbLog;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnGetPaper;
        private System.Windows.Forms.Button btnGetExamScore;
        private System.Windows.Forms.Button btnGetPaperContent;
        private System.Windows.Forms.Button btnGetSubmitted;
    }
}

