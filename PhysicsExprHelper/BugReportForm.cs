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
            if (SendMail("BugReport", this.bugContext.Text) == true)
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

        private Boolean SendMail(String subject, String content)
        {
            System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();
            msg.To.Add("stlcopy@163.com");

            msg.From = new System.Net.Mail.MailAddress("sustcreg@163.com", "BugReport", System.Text.Encoding.UTF8);
            msg.Subject = subject;
            msg.SubjectEncoding = System.Text.Encoding.UTF8;
            msg.Body = content;
            msg.BodyEncoding = System.Text.Encoding.UTF8;
            msg.IsBodyHtml = false;
            msg.Priority = System.Net.Mail.MailPriority.Normal;
            System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient();
            client.Credentials = new System.Net.NetworkCredential("sustcreg@163.com", "sustc2015");

            client.Port = 25;
            client.Host = "smtp.163.com";
            client.EnableSsl = false;
            object userState = msg;
            try
            {
                client.Send(msg);
                return true;
            }
            catch (System.Net.Mail.SmtpException ex)
            {
                return false;
            }
        }
    }
}
