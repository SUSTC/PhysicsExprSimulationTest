namespace PhysicsExprHelper
{
    partial class BugReportForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BugReportForm));
            this.bugContext = new System.Windows.Forms.TextBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.labelBug = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // bugContext
            // 
            this.bugContext.Location = new System.Drawing.Point(21, 42);
            this.bugContext.Multiline = true;
            this.bugContext.Name = "bugContext";
            this.bugContext.Size = new System.Drawing.Size(578, 361);
            this.bugContext.TabIndex = 0;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Font = new System.Drawing.Font("宋体", 9F);
            this.btnSubmit.Location = new System.Drawing.Point(470, 409);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(129, 32);
            this.btnSubmit.TabIndex = 1;
            this.btnSubmit.Text = "帕秋莉♂Go";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // labelBug
            // 
            this.labelBug.AutoSize = true;
            this.labelBug.Location = new System.Drawing.Point(18, 12);
            this.labelBug.Name = "labelBug";
            this.labelBug.Size = new System.Drawing.Size(89, 18);
            this.labelBug.TabIndex = 2;
            this.labelBug.Text = "Bug描述：";
            // 
            // BugReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 455);
            this.Controls.Add(this.labelBug);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.bugContext);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BugReportForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bug反馈";
            this.Load += new System.EventHandler(this.BugReportForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox bugContext;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Label labelBug;
    }
}