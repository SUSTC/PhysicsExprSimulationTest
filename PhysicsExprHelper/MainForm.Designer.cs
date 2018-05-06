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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tbLog = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnGetExamScore = new System.Windows.Forms.Button();
            this.btnGetPaperContent = new System.Windows.Forms.Button();
            this.btnGetSubmitted = new System.Windows.Forms.Button();
            this.btnGetAns = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSet = new System.Windows.Forms.ToolStripMenuItem();
            this.menuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDanger = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbLog
            // 
            this.tbLog.Location = new System.Drawing.Point(292, 43);
            this.tbLog.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbLog.Multiline = true;
            this.tbLog.Name = "tbLog";
            this.tbLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbLog.Size = new System.Drawing.Size(531, 317);
            this.tbLog.TabIndex = 0;
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(12, 42);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(272, 37);
            this.btnLogin.TabIndex = 1;
            this.btnLogin.Text = "登录实验大厅";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnGetExamScore
            // 
            this.btnGetExamScore.Location = new System.Drawing.Point(12, 87);
            this.btnGetExamScore.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnGetExamScore.Name = "btnGetExamScore";
            this.btnGetExamScore.Size = new System.Drawing.Size(272, 37);
            this.btnGetExamScore.TabIndex = 3;
            this.btnGetExamScore.Text = "查看成绩";
            this.btnGetExamScore.UseVisualStyleBackColor = true;
            this.btnGetExamScore.Click += new System.EventHandler(this.btnGetExamScore_Click);
            // 
            // btnGetPaperContent
            // 
            this.btnGetPaperContent.Location = new System.Drawing.Point(12, 176);
            this.btnGetPaperContent.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnGetPaperContent.Name = "btnGetPaperContent";
            this.btnGetPaperContent.Size = new System.Drawing.Size(272, 37);
            this.btnGetPaperContent.TabIndex = 4;
            this.btnGetPaperContent.Text = "查看答卷内容";
            this.btnGetPaperContent.UseVisualStyleBackColor = true;
            this.btnGetPaperContent.Click += new System.EventHandler(this.btnGetPaperContent_Click);
            // 
            // btnGetSubmitted
            // 
            this.btnGetSubmitted.Enabled = false;
            this.btnGetSubmitted.Location = new System.Drawing.Point(12, 218);
            this.btnGetSubmitted.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnGetSubmitted.Name = "btnGetSubmitted";
            this.btnGetSubmitted.Size = new System.Drawing.Size(272, 37);
            this.btnGetSubmitted.TabIndex = 5;
            this.btnGetSubmitted.Text = "看看学霸们的成绩";
            this.btnGetSubmitted.UseVisualStyleBackColor = true;
            this.btnGetSubmitted.Click += new System.EventHandler(this.btnGetSubmitted_Click);
            // 
            // btnGetAns
            // 
            this.btnGetAns.Location = new System.Drawing.Point(12, 131);
            this.btnGetAns.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnGetAns.Name = "btnGetAns";
            this.btnGetAns.Size = new System.Drawing.Size(272, 37);
            this.btnGetAns.TabIndex = 7;
            this.btnGetAns.Text = "查看选择题答案";
            this.btnGetAns.UseVisualStyleBackColor = true;
            this.btnGetAns.Click += new System.EventHandler(this.btnGetAns_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(12, 323);
            this.btnExit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(272, 37);
            this.btnExit.TabIndex = 9;
            this.btnExit.Text = "退出实验大厅";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFile,
            this.menuHelp});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(835, 28);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuFile
            // 
            this.menuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuSet,
            this.menuExit});
            this.menuFile.Name = "menuFile";
            this.menuFile.Size = new System.Drawing.Size(51, 24);
            this.menuFile.Text = "文件";
            // 
            // menuSet
            // 
            this.menuSet.Enabled = false;
            this.menuSet.Name = "menuSet";
            this.menuSet.Size = new System.Drawing.Size(114, 26);
            this.menuSet.Text = "设置";
            // 
            // menuExit
            // 
            this.menuExit.Name = "menuExit";
            this.menuExit.Size = new System.Drawing.Size(114, 26);
            this.menuExit.Text = "退出";
            this.menuExit.Click += new System.EventHandler(this.menuExit_Click);
            // 
            // menuHelp
            // 
            this.menuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuAbout});
            this.menuHelp.Name = "menuHelp";
            this.menuHelp.Size = new System.Drawing.Size(51, 24);
            this.menuHelp.Text = "帮助";
            // 
            // menuAbout
            // 
            this.menuAbout.Name = "menuAbout";
            this.menuAbout.Size = new System.Drawing.Size(114, 26);
            this.menuAbout.Text = "关于";
            this.menuAbout.Click += new System.EventHandler(this.menuAbout_Click);
            // 
            // btnDanger
            // 
            this.btnDanger.BackColor = System.Drawing.Color.Red;
            this.btnDanger.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDanger.ForeColor = System.Drawing.Color.White;
            this.btnDanger.Location = new System.Drawing.Point(12, 271);
            this.btnDanger.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDanger.Name = "btnDanger";
            this.btnDanger.Size = new System.Drawing.Size(272, 37);
            this.btnDanger.TabIndex = 12;
            this.btnDanger.Text = "增强模式";
            this.btnDanger.UseVisualStyleBackColor = false;
            this.btnDanger.Click += new System.EventHandler(this.btnDanger_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(835, 369);
            this.Controls.Add(this.btnDanger);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnGetAns);
            this.Controls.Add(this.btnGetSubmitted);
            this.Controls.Add(this.btnGetPaperContent);
            this.Controls.Add(this.btnGetExamScore);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.tbLog);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "物理实验大厅工具箱";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbLog;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnGetExamScore;
        private System.Windows.Forms.Button btnGetPaperContent;
        private System.Windows.Forms.Button btnGetSubmitted;
        private System.Windows.Forms.Button btnGetAns;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuFile;
        private System.Windows.Forms.ToolStripMenuItem menuHelp;
        private System.Windows.Forms.ToolStripMenuItem menuAbout;
        private System.Windows.Forms.ToolStripMenuItem menuSet;
        private System.Windows.Forms.ToolStripMenuItem menuExit;
        private System.Windows.Forms.Button btnDanger;
    }
}

