using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
    public partial class LogOnForm : Form
    {
        public String userid { get; private set; }
        public Boolean status { get; private set; }
        public MainForm MainForm { get; private set; }
        public LogOnForm(MainForm _Form)
        {
            MainForm = _Form;
            status = false;
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUser.Text == "")
            {
                MessageBox.Show("噫！你现在不输入用户名，将来报道出了偏差怎么办？");
                return;
            }
            if (txtPass.Text == "")
            {
                MessageBox.Show("噫！你现在不输入密码，将来报道出了偏差怎么办？");
                return;
            }
            Interop.BizService.SvcResponse res = PhysicsExprHelper.Interop.UserSystem.interfaceLogin(txtUser.Text, txtPass.Text);
            JObject jreq = JObject.Parse(res.DataString);
            //MessageBox.Show(res.DataString);
            if (jreq["IsSeccess"].ToString() =="0")
            {
                MessageBox.Show("可以搞个大新闻了","Excited");
                userid = txtUser.Text;
                status = true;
                MainForm.user = userid;
                MainForm.status = status;
                MainForm.Visible = true;
                MainForm.Text = MainForm.Text + "  " + jreq["SchoolName"].ToString() + "  " + txtUser.Text;
                MainForm.disableLogin();
                MainForm.setStatus(status);
                this.Close();
            }
            else
            {
                MessageBox.Show("一定是你报道的不对","我怀疑你是香港记者");
                txtUser.Text = String.Empty;
                txtPass.Text = String.Empty;
            }

        }

        private void LogOnForm_Load(object sender, EventArgs e)
        {
            new System.Threading.Thread(
                new System.Threading.ParameterizedThreadStart(
                    Util.googleAnalytics)).Start("LogOn");
        }
    }
}
