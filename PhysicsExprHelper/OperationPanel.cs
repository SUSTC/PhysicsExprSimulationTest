using Newtonsoft.Json.Linq;
using PhysicsExprHelper.Interop;
using PhysicsExprHelper.Interop.BizService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhysicsExprHelper
{
    public partial class OperationPanel : Form
    {
        private String userID = null;
 
        public OperationPanel()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, EventArgs e) {
            if (UserIDBox.Text == "") {
                MessageBox.Show("噫！你现在不输入用户名，将来报道出了偏差怎么办？");
                return;
            }
            if (PasswordBox.Text == "") {
                MessageBox.Show("噫！你现在不输入密码，将来报道出了偏差怎么办？");
                return;
            }
            SvcResponse res = UserSystem.InterfaceLogin(UserIDBox.Text, PasswordBox.Text);
            JObject jreq = JObject.Parse(res.DataString);
            MessageBox.Show(res.DataString);
            if (jreq["IsSeccess"].ToString() == "0") {
                MessageBox.Show("可以搞个大新闻了", "Excited");
                userID = UserIDBox.Text;
                LoginPanel.Visible = false;
            }
            else
            {
                MessageBox.Show("一定是你报道的不对", "我怀疑你是香港记者");
            }
            PasswordBox.Text = String.Empty;
        }
    }
}
