using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PhysicsExprHelper
{
    public partial class BugReportForm : Form
    {
        public BugReportForm()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (this.bugContext.Text == "")
            {
                MessageBox.Show("不填内容就想报道？","我怀疑你是香港记者");
                return;
            }
            this.Text = "Bug反馈——正在发送...请不要关闭窗口";
            if (Util.SendMail("BugReport", this.bugContext.Text) == true)
            {
                MessageBox.Show("交易已经完成了", "发送完成");
                this.Close();
            }
            else
            {
                MessageBox.Show("交易失败，请检查你的网络情况", "发送失败");
            }
            this.Text = "Bug反馈";
        }

        private void BugReportForm_Load(object sender, EventArgs e)
        {
            new System.Threading.Thread(
                new System.Threading.ParameterizedThreadStart(
                    Util.googleAnalytics)).Start("BugReport");
        }
    }
}
