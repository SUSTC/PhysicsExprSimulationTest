using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PhysicsExprHelper.Interop;
using System.Runtime;

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
            Interop.UserSystem.logoutUser("11310129");
        }

        private void button1_Click(object sender, EventArgs e)
        {

            (new LogOnForm()).Show();

        }

        private void btnGetPaper_Click(object sender, EventArgs e)
        {
            String paperID = Microsoft.VisualBasic.Interaction.InputBox("Enter Paper ID", "951");
            tbLog.AppendText(Interop.ExamSystem.findPaperContentByPaperID(paperID).DataString);
        }

        private void btnGetExamScore_Click(object sender, EventArgs e)
        {
            String stuID = Microsoft.VisualBasic.Interaction.InputBox("Enter Student ID", "951");
            tbLog.AppendText(Interop.ExamSystem.findExamScoreByStudentIDNew(stuID).DataString);
        }

        private void btnGetPaperContent_Click(object sender, EventArgs e)
        {
            String stuID = Microsoft.VisualBasic.Interaction.InputBox("Enter Student ID", "11310129");
            String examID = Microsoft.VisualBasic.Interaction.InputBox("Enter Exam ID", "951");
            String paperContent;
            paperContent = Interop.ExamSystem.findPaperContent(examID, stuID).DataString;

            if (paperContent != "null") tbLog.AppendText(Newtonsoft.Json.JsonConvert.DeserializeObject<string>(paperContent));
        }

        private void btnGetSubmitted_Click(object sender, EventArgs e)
        {
            String examID = Microsoft.VisualBasic.Interaction.InputBox("Enter Exam ID", "951");


            tbLog.AppendText(Interop.ExamSystem.findSubmitStudentByExamID(examID).DataString);

        }

        private void btnStudyBug_Click(object sender, EventArgs e)
        {
            (new StudyBug()).Show();
        }



    }
}
