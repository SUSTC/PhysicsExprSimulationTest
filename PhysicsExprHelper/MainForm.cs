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

namespace PhysicsExprHelper
{
    public partial class MainForm : Form
    {
        public string RegexStr { get; private set; }

        public String user { get; set; }
        public Boolean status { get; set; }
        public Boolean check { get; set; }

        public int version { get;}

        public MainForm()
        {
            InitializeComponent();
            user = String.Empty;
            status = false;
            check = false;
            setStatus(check);
            version = 1;
        }

        private Boolean download(String url,String name)
        {
            System.Net.WebClient myWebClient = new System.Net.WebClient();
            try
            {
                myWebClient.DownloadFile(url, name);
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
            
        }

        private void setStatus(Boolean b)
        {
            this.btnGetAns.Enabled = b;
            this.btnGetPaper.Enabled = b;
            this.btnGetPaperContent.Enabled = b;
            this.btnGetSubmitted.Enabled = b;
            this.btnStudyBug.Enabled = b;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Interop.UserSystem.logoutUser(user);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LogOnForm FormLogin = new LogOnForm(this);
            FormLogin.Show();
            this.Visible = false;
        }
        
        private void btnGetPaper_Click(object sender, EventArgs e)
        {
            String paperID = Microsoft.VisualBasic.Interaction.InputBox("试卷编号：", "蛤蛤，你想看哪张卷子？");
            String paper = Interop.ExamSystem.findPaperContentByPaperID(paperID).DataString;
            paper = paper.Replace("\\r\\n", String.Empty).Replace("\"", String.Empty);
            tbLog.AppendText(paper);
        }

        private void btnGetAns_Click(object sender, EventArgs e)
        {
            String paperID = Microsoft.VisualBasic.Interaction.InputBox("试卷编号：", "蛤蛤，你想看哪张卷子答案？");
            if(paperID == "")
            {
                MessageBox.Show("Naive,不知道先戳下查成绩看看试卷编号么？", "Too Young");
            }
            String text = Interop.ExamSystem.findPaperContentByPaperID(paperID).DataString;
            text = text.Replace("\\r\\n", String.Empty).Replace("\"", String.Empty);

            Match mat = Regex.Match(text, @"<PaperName>(.+?)</PaperName>");
            tbLog.AppendText(mat.Groups[1].Value+"\n");

            string pat = @"<StdAnswer>(.+?)</StdAnswer>";
            Regex r = new Regex(pat, RegexOptions.IgnoreCase);
            Match m = r.Match(text);
            int matchCount = 0;
            while (m.Success)
            {
                tbLog.AppendText("第"+(++matchCount)+"题" + ".");
                for (int i = 1; i <= 2; i++)
                {
                    Group g = m.Groups[i];
                    CaptureCollection cc = g.Captures;
                    for (int j = 0; j < cc.Count; j++)
                    {
                        Capture c = cc[j];
                        tbLog.AppendText(c+ "\n");
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
            //String stuID = Microsoft.VisualBasic.Interaction.InputBox("学号：", "Excited!你想看谁的成绩？");
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
            setStatus(status);
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
            Close();
        }

        private void menuAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("科大奥锐实验教学系统信息提取工具\n使用软件所造成的一切后果由用户承担\n请酌情使用\nGPL协议","关于");
        }

        private void menuBug_Click(object sender, EventArgs e)
        {
            (new BugReportForm()).Show();
        }

        private void menuExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void menuUpdate_Click(object sender, EventArgs e)
        {
            Boolean status = download("http://tsingedu.com/update/update.json", "update.json");
            if (status)
            {
                JObject info = readJson("update.json");
                if (info == null)
                {
                    return;
                }
                if (Int32.Parse(info["version"].ToString()) > this.version)
                {
                    MessageBox.Show(info["LatestVersion"].ToString()+":"+info["What's New"].ToString(),"发现新版本，即将更新");
                    System.Diagnostics.Process.Start(System.Environment.CurrentDirectory+@"\update\Update.exe");
                    Close();
                }
                else
                {
                    MessageBox.Show("已经是最新版本");
                }
               
            }
        }

        private JObject readJson(string path)
        {
            StreamReader sr = new StreamReader(path, Encoding.UTF8);
            try
            {
                String line = sr.ReadLine();
                sr.Close();
                File.Delete(path);
                JObject jreq = JObject.Parse(line);
                return jreq;

            }catch(Exception e)
            {
                sr.Close();
                return null;
            }
            
        }
    }
}
