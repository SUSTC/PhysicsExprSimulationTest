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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            PhysicsExprHelper.ExprSystems.UserSystem.interfaceLogin(txtUser.Text, txtPass.Text);
            this.Close();
        }

        
    }
}
