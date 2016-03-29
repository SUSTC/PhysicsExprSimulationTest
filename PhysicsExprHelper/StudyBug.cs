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
    public partial class StudyBug : Form
    {
        public StudyBug()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox.Items.Clear();
            for (int i = 1; i < 1000; i++)
            {
                
                Interop.BizService.SvcResponse resp;
                resp = Interop.UserSystem.isUserOnline("11510" + i.ToString("D3", System.Globalization.CultureInfo.InvariantCulture), true);
                if ((resp.DataString == "1"))
                {
                    Interop.BizService.SvcResponse user;
                    user = Interop.ExamSystem.findExamScoreByStudentIDNew("11510" + i.ToString("D3"));

                    if (user.DataString != "[]")
                    {
                        Interop.ExamScoreEntry[] userdata = Newtonsoft.Json.JsonConvert.DeserializeObject<Interop.ExamScoreEntry[]>(user.DataString);
                        //listView1.Items.Add(new ListViewItem(userdata[0].StudentName));
                        //listBox.Items.Add(userdata[0].StudentID+userdata[0].StudentName + ":最新实验" + userdata[0].ExamName);
                        listBox.Items.Add(userdata[0].StudentName);
                    }
                }
                progressBar.Value = (int)((double)i / 100.0);
            }
            progressBar.Value = 100;
        }
    }
}
