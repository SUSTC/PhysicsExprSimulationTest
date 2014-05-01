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
            for (int i = 1; i < 1000; i++)
            {
                Interop.BizService.SvcResponse resp;
                resp = Interop.UserSystem.isUserOnline("11310" + i.ToString("D3", System.Globalization.CultureInfo.InvariantCulture), true);
                if ((resp.DataString == "1"))
                {
                    Interop.BizService.SvcResponse user;
                    user = Interop.ExamSystem.findExamScoreByStudentIDNew("11310" + i.ToString("D3"));

                    if (user.DataString != "[]")
                    {
                        Interop.ExamScoreEntry[] userdata = Newtonsoft.Json.JsonConvert.DeserializeObject<Interop.ExamScoreEntry[]>(user.DataString);
                        listView1.Items.Add(new ListViewItem(userdata[0].StudentName));
                    }
                }
            }
        }
    }
}
