using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PhysicsExprHelper.ExprSystems;

namespace PhysicsExprHelper
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ExprSystems.UserSystem.logoutUser("11310129");
        }

        private void button1_Click(object sender, EventArgs e)
        {

            (new Form1()).Show();
            
        }

        private void tmrCheckLogin_Tick(object sender, EventArgs e)
        {
            if (ExprSystems.UserSystem.isUserOnline("11310129", true).DataString == "1")
            {
                tbLog.AppendText("Online" + "\n");
            }
        }
    }
}
