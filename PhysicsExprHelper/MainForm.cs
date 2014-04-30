using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PhysicsExprHelper.Interop;

namespace PhysicsExprHelper
{
    public partial class MainForm : Form
    {
        int id = 11310001;

        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Interop.UserSystem.logoutUser("11310129");
        }

        private void button1_Click(object sender, EventArgs e)
        {

            (new LoginForm()).Show();
            
        }



    }
}
