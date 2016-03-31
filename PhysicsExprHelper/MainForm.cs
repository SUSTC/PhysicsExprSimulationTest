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
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Xml;
using System.IO;
using System.Text.RegularExpressions;
using System.Net;
using System.Threading;

namespace PhysicsExprHelper
{
    public partial class MainForm : Form
    {
        public static String updatePath {get; private set; }

        public string RegexStr { get; private set; }

        public String user { get; set; }
        public Boolean status { get; set; }
        public Boolean check { get; set; }

        public static int version { get; set;}

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //Interop.UserSystem.logoutUser(user);
            updatePath = "http://tsingedu.com/update/update.json";

            user = String.Empty;
            status = false;
            check = false;
            setStatus(check);
            version = 4;
            new Thread(new ParameterizedThreadStart(Util.googleAnalytics)).Start("Main");
            //PhysicsExprHelper.Interop.UserSystem.googleAnalytics("Main", version.ToString());
            if (Util.checkUpdate())
            {
                Close();
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            LogOnForm FormLogin = new LogOnForm(this);
            FormLogin.Show();
            this.Visible = false;

        }
        /*
        private void btnGetPaper_Click(object sender, EventArgs e)
        {
            String paperID = Microsoft.VisualBasic.Interaction.InputBox("试卷编号：", "蛤蛤，你想看哪张卷子？");
            String paper = Interop.ExamSystem.findPaperContentByPaperID(paperID).DataString;
            paper = paper.Replace("\\r\\n", String.Empty).Replace("\"", String.Empty);
            tbLog.AppendText(paper);
        }
        */
        private void btnGetAns_Click(object sender, EventArgs e)
        {
            String paperID = Microsoft.VisualBasic.Interaction.InputBox("试卷编号：", "蛤蛤，你想看哪张卷子答案？");
            if(paperID == "")
            {
                MessageBox.Show("Naive,不知道先戳下查成绩看看试卷编号么？", "Too Young");
                return;
            }

            String text = Interop.ExamSystem.findPaperContentByPaperID(paperID).DataString;
            text = text.Replace("\\r\\n", String.Empty).Replace("\"", String.Empty);

            Match mat = Regex.Match(text, @"<PaperName>(.+?)</PaperName>");
            tbLog.AppendText(mat.Groups[1].Value + "答卷内容：\n");

            string pat = @"<StdAnswer>(.+?)</StdAnswer>";
            Regex r = new Regex(pat, RegexOptions.IgnoreCase);
            Match m = r.Match(text);
            int matchCount = 0;
            while (m.Success)
            {
                tbLog.AppendText("第" + (++matchCount) + "题" + ".");
                for (int i = 1; i <= 2; i++)
                {
                    Group g = m.Groups[i];
                    CaptureCollection cc = g.Captures;
                    for (int j = 0; j < cc.Count; j++)
                    {
                        Capture c = cc[j];
                        tbLog.AppendText(c + "\n");
                    }
                }
                m = m.NextMatch();
            }
        }

        private void btnGetExamScore_Click(object sender, EventArgs e)
        {
            if (status == false)
            {
                MessageBox.Show("Naive,不登录还咋玩？", "开挂也要按照基本法");
                return;
            }
            String stuID = user;
            String score = Interop.ExamSystem.findExamScoreByStudentIDNew(stuID).DataString;
            JArray ja = (JArray)JsonConvert.DeserializeObject(score);
            if (ja == null)
            {
                return;
            }
            int number = (int)ja.Count();
            if (number != 0)
            {
                tbLog.AppendText(ja[1]["StudentName"].ToString() + ":\n");
                for (int i = 0; i < number; ++i)
                {
                    tbLog.AppendText((i+1) + ":");
                    tbLog.AppendText("\t考试编号:"+ja[i]["ExamID"].ToString() + "\n");
                    tbLog.AppendText("\t考试名称:"+ja[i]["ExamName"].ToString() + "\n");
                    tbLog.AppendText("\t试卷编号:"+ja[i]["PaperID"].ToString() + "\n");
                    tbLog.AppendText("\t试卷名称:"+ja[i]["PaperName"].ToString() + "\n");
                    tbLog.AppendText("\t得分:"+ja[i]["GainPoint"].ToString() + "\n");
                }
            }
            status = true;
            
        }

        private void btnGetPaperContent_Click(object sender, EventArgs e)
        {
            //String stuID = Microsoft.VisualBasic.Interaction.InputBox("学号：", "蛤蛤，你想看谁的答卷？");
            String stuID = user;
            String examID = Microsoft.VisualBasic.Interaction.InputBox("考试编号：", "你要看哪次试卷？");
            String paperContent;
            paperContent = Interop.ExamSystem.findPaperContent(examID, stuID).DataString;
            if(paperContent == null)
            {
                return;
            }
            String text = paperContent.Replace("\\r\\n", String.Empty).Replace("\"", String.Empty);

            Match mat = Regex.Match(text, @"<PaperName>(.+?)</PaperName>");
            tbLog.AppendText(mat.Groups[1].Value + "答卷内容：\n");

            string pat = @"<StudentAnswer>(.+?)</StudentAnswer>";
            Regex r = new Regex(pat, RegexOptions.IgnoreCase);
            Match m = r.Match(text);
            int matchCount = 0;
            while (m.Success)
            {
                tbLog.AppendText("第" + (++matchCount) + "题" + ".");
                for (int i = 1; i <= 2; i++)
                {
                    Group g = m.Groups[i];
                    CaptureCollection cc = g.Captures;
                    for (int j = 0; j < cc.Count; j++)
                    {
                        Capture c = cc[j];
                        tbLog.AppendText(c + "\n");
                    }
                }
                m = m.NextMatch();
            }
            //if (paperContent != "null") tbLog.AppendText(Newtonsoft.Json.JsonConvert.DeserializeObject<string>(paperContent));
        }

        private void btnGetSubmitted_Click(object sender, EventArgs e)
        {
            String examID = Microsoft.VisualBasic.Interaction.InputBox("考试编号：", "蛤蛤，你想看哪次的试卷？");
            String studentList = Interop.ExamSystem.findSubmitStudentByExamID(examID).DataString;

            printJson(studentList, "ExamName", "StudentName", "GainPoint");

        }

        private void printJson(String json, String mainKey, String firstKey, String secondKey)
        {
            JArray ja = (JArray)JsonConvert.DeserializeObject(json);
            if(ja == null)
            {
                return;
            }
            int number = (int)ja.Count();
            if (number != 0)
            {
                tbLog.AppendText(ja[1][mainKey].ToString() + "\n");
                for (int i = 0; i < number; ++i)
                {
                    tbLog.AppendText(ja[i][firstKey].ToString() + ":");
                    tbLog.AppendText(ja[i][secondKey].ToString() + "\n");
                }
            }
        }

        private void printJson(String json, String mainKey, String firstKey)
        {
            JArray ja = (JArray)JsonConvert.DeserializeObject(json);
            if (ja == null)
            {
                return;
            }
            int number = (int)ja.Count();
            if (number != 0)
            {
                tbLog.AppendText(ja[1][mainKey].ToString() + "\n");
                for (int i = 0; i < number; ++i)
                {
                    tbLog.AppendText(ja[i][firstKey].ToString() + "\n");
                }
            }
        }

        private void btnStudyBug_Click(object sender, EventArgs e)
        {
            (new StudyBug()).Show();
        }
        

        private void btnExit_Click(object sender, EventArgs e)
        {
            Interop.UserSystem.logoutUser(user);
            Close();
        }

        private void menuAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("科大奥锐实验教学系统信息提取工具（Build:"+MainForm.version.ToString()+")\n使用软件所造成的一切后果由用户承担\n请酌情使用\nGPL协议","关于");
        }

        private void menuBug_Click(object sender, EventArgs e)
        {
            (new BugReportForm()).Show();
        }

        private void menuExit_Click(object sender, EventArgs e)
        {
            Interop.UserSystem.logoutUser(user);
            Close();
        }

        private void menuUpdate_Click(object sender, EventArgs e)
        {
            if(Util.checkUpdate())
            {
                MessageBox.Show("已经是最新版本");
            }
            else
            {
                Close();
            }
        }


        

        private void btnGetAnsFromGitHub_Click(object sender, EventArgs e)
        {
            (new AnsSafeGet()).Show();
        }

        private void btnDanger_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("增强模式仍然在测试中，可能带来不可预料的后果\r\n确认继续么？","Warning!", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                if (MessageBox.Show("真的确认继续么？", "Warning x2", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    if (MessageBox.Show("既然你确认了，万一将来报道出了偏差，就是你的错", "Warning x3", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        (new AdvancedMode()).Show();
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    return;
                }
            }
            else
            {
                return;
            }
            
        }

        public void setStatus(Boolean status)
        {
            this.btnGetExamScore.Enabled = status;
            this.btnGetAns.Enabled = status;
            //this.btnGetPaper.Enabled = status;
            this.btnGetPaperContent.Enabled = status;
            this.btnGetSubmitted.Enabled = status;
            this.btnStudyBug.Enabled = status;
            //this.btnDanger.Enabled = status;

        }

        public void disableLogin()
        {
            btnLogin.Enabled = false;
        }
    }
}
