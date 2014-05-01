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
        public LogOnForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            PhysicsExprHelper.Interop.UserSystem.interfaceLogin(txtUser.Text, txtPass.Text);
            this.Close();
        }


    }
}
