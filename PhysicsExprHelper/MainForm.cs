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
        public static String updatePath { get; private set; }

        public string RegexStr { get; private set; }

        public static String user { get; set; }
        public static Boolean status { get; set; }
        public static Boolean check { get; set; }

        public static int version { get; set; }

        public void checkUpdate()
        {
            Boolean status = download(MainForm.updatePath, "update.json");
            if (status)
            {
                JObject info = readJson("update.json");
                if (info == null)
                {
                    return;
                }
                if (Int32.Parse(info["version"].ToString()) > MainForm.version)
                {
                    MessageBox.Show(info["LatestVersion"].ToString() + ":" + info["What's New"].ToString(), "发现新版本，即将更新");
                    System.Diagnostics.Process.Start(System.Environment.CurrentDirectory + @"\update\Update.exe");
                    Close();
                }

            }

        }

        public static Boolean download(String url, String name)
        {
            System.Net.WebClient myWebClient = new System.Net.WebClient();
            try
            {
                myWebClient.DownloadFile(url, name);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }


        public static JObject readJson(string path)
        {
            try
            {
                StreamReader sr = new StreamReader(path, Encoding.UTF8);
                String line = sr.ReadLine();
                sr.Close();
                File.Delete(path);
                JObject jreq = JObject.Parse(line);
                return jreq;

            }
            catch (Exception e)
            {
                return null;
            }

        }
        public void setStatus(Boolean status)
        {
            this.btnGetExamScore.Enabled = status;
            this.btnGetAns.Enabled = status;
            //this.btnGetPaper.Enabled = status;
            this.btnGetPaperContent.Enabled = status;
            this.btnGetSubmitted.Enabled = status;
            this.btnDanger.Enabled = status;
        }

        public void disableLogin()
        {
            btnLogin.Enabled = false;
        }


        public MainForm()
        {
            InitializeComponent();

            updatePath = "https://update.sustc.us/update.json";
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //Interop.UserSystem.logoutUser(user);

            //user = String.Empty;
            user = null;
            status = false;
            check = false;
            setStatus(check);
            version = 7;
            checkUpdate();
        }

        private void AdvancedFininishExam()
        {
            try
            {
                String undoExam = Interop.ExamSystem.FindUndoExamByStudentID(MainForm.user).DataString;
                JArray undoInfo = (JArray)JsonConvert.DeserializeObject(undoExam);
                if (undoInfo.Count == 0)
                {
                    MessageBox.Show("你怎么这么着急，明明还没有要预习的实验", "增强模式 beta");
                    return;
                }
                String studentJson = Interop.ExamSystem.FindStudentInfoByExamIDAndStudentID(undoInfo[0]["ExamID"].ToString(), MainForm.user).DataString;

                JObject studentInfo = JObject.Parse(studentJson);
                String origin = Interop.ExamSystem.GetExamStudentInfo(MainForm.user, undoInfo[0]["UsePapers"].ToString()).DataString;
                String text = origin.Replace("\\r\\n", "\n").Replace("\"<", "<").Replace(">\"", ">").Replace("\\\"", "\"").Replace("RealScoreRealScoreRealScore", "<RealScore />");
                //tbLog.AppendText(text);

                XmlDocument paperXML = new XmlDocument();
                paperXML.LoadXml(text);

                String FullScore = null;

                XmlNodeList Titles = paperXML.SelectSingleNode("/Paper/Title").ChildNodes;
                foreach (XmlNode title in Titles)
                {
                    XmlElement tElement = (XmlElement)title;
                    if (tElement.Name == "FullScore")
                    {
                        FullScore = tElement.InnerText;
                    }
                }
                XmlNode edit = paperXML.SelectSingleNode("/Paper/Content");
                XmlNode father = paperXML.SelectSingleNode("/Paper/Content");
                XmlNodeList Questions = father.ChildNodes;

                foreach (XmlNode questions in Questions)
                {
                    XmlElement qElement = (XmlElement)questions;
                    if (qElement.GetAttribute("Type") != "OP")
                    {
                        try
                        {
                            String ans = String.Empty;
                            String score = String.Empty;
                            foreach (XmlNode field in qElement.ChildNodes)
                            {
                                XmlElement fElement = (XmlElement)field;
                                if (fElement.Name == "StdAnswer")
                                {
                                    ans = fElement.InnerText;
                                }
                                else if (fElement.Name == "TotalScore")
                                {
                                    score = fElement.InnerText;
                                }
                                else if (fElement.Name == "StudentAnswer")
                                {
                                    fElement.InnerText = ans;
                                }
                                else if (fElement.Name == "StudentScore")
                                {
                                    fElement.InnerText = score;
                                }
                            }
                        }
                        catch (Exception e)
                        {

                        }
                    }
                    else
                    {
                        foreach (XmlNode field in qElement.ChildNodes)
                        {
                            if (field.NodeType == XmlNodeType.Element)
                            {
                                XmlElement fElement = (XmlElement)field;

                                if (fElement.Name == "Score")
                                {
                                    String score = String.Empty;
                                    foreach (XmlNode OPscore in fElement.ChildNodes)
                                    {
                                        XmlElement OPscoreElement = (XmlElement)OPscore;
                                        if (OPscoreElement.Name == "Total")
                                        {
                                            score = OPscoreElement.InnerText;
                                        }
                                        else
                                        {
                                            OPscoreElement.InnerText = score;
                                        }
                                    }
                                }
                                else if (fElement.Name == "CheckPoint")
                                {
                                    foreach (XmlNode OPans in fElement.ChildNodes)
                                    {
                                        try
                                        {
                                            XmlElement OPansElement = (XmlElement)OPans;
                                            if (OPansElement.Name == "TestTarget")
                                            {
                                                foreach (XmlNode target in OPansElement.ChildNodes)
                                                {
                                                    XmlElement targetElement = (XmlElement)target;
                                                    double targetScore = 0.0;
                                                    if (targetElement.Name == "Group")
                                                    {
                                                        foreach (XmlNode group in targetElement.ChildNodes)
                                                        {
                                                            XmlElement groupElement = (XmlElement)group;
                                                            if (group.Name == "Para")
                                                            {
                                                                String stdResult = String.Empty;
                                                                foreach (XmlNode para in groupElement.ChildNodes)
                                                                {
                                                                    XmlElement paraElement = (XmlElement)para;
                                                                    if (paraElement.Name == "StdResult")
                                                                    {
                                                                        stdResult = paraElement.InnerText;
                                                                    }
                                                                }
                                                                String totalScore = String.Empty;
                                                                foreach (XmlNode para in groupElement.ChildNodes)
                                                                {
                                                                    XmlElement paraElement = (XmlElement)para;
                                                                    if (paraElement.Name == "RealResult")
                                                                    {
                                                                        paraElement.InnerText = stdResult;
                                                                    }
                                                                    else if (paraElement.Name == "TotalScore")
                                                                    {
                                                                        totalScore = paraElement.InnerText;
                                                                    }
                                                                    else if (paraElement.Name == "RealScore")
                                                                    {
                                                                        paraElement.InnerText = totalScore;
                                                                        targetScore += Double.Parse(totalScore);
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                    else if (targetElement.Name == "RealScore")
                                                    {
                                                        targetElement.InnerText = targetScore.ToString();
                                                    }

                                                }
                                            }
                                        }
                                        catch (Exception op)
                                        {

                                        }
                                    }

                                }
                            }
                        }
                    }
                }

                String update = paperXML.InnerXml;
                studentInfo["PaperContentXml"] = update;
                studentInfo["GainPoint"] = FullScore;
                studentInfo["GainShowPoint"] = FullScore;
                studentInfo["IsSubmit"] = "true";

                Interop.ExamSystem.UpdateStudentPaperContent(studentInfo.ToString());
                MessageBox.Show("已经完成实验预习：" + studentInfo["ExamName"].ToString(), "增强模式 beta");
            }
            catch (Exception e)
            {
                MessageBox.Show("完成实验预习出错！\n请重试", "增强模式 beta");
            }
        }

        public static String findStudentNameByStudentID(string studentID)
        {
            Interop.BizService.SvcResponse user = Interop.ExamSystem.FindExamScoreByStudentIDNew(studentID);

            if (user.DataString != "[]")
            {
                Interop.ExamScoreEntry[] userdata = Newtonsoft.Json.JsonConvert.DeserializeObject<Interop.ExamScoreEntry[]>(user.DataString);
                return userdata[0].StudentName;
            }
            return null;
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
            String examID = Microsoft.VisualBasic.Interaction.InputBox("试卷编号：", "蛤蛤，你想看哪场考试的答案？");
            if (examID == "")
            {
                MessageBox.Show("Naive,不知道先戳下查成绩看看考试编号么？", "Too Young");
                return;
            }

            String text = Interop.ExamSystem.GetExamStudentInfo(user, examID).DataString;
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
            String score = Interop.ExamSystem.FindExamScoreByStudentIDNew(stuID).DataString;
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
                    tbLog.AppendText((i + 1) + ":");
                    tbLog.AppendText("\t考试编号:" + ja[i]["ExamID"].ToString() + "\n");
                    tbLog.AppendText("\t考试名称:" + ja[i]["ExamName"].ToString() + "\n");
                    tbLog.AppendText("\t试卷编号:" + ja[i]["PaperID"].ToString() + "\n");
                    tbLog.AppendText("\t试卷名称:" + ja[i]["PaperName"].ToString() + "\n");
                    tbLog.AppendText("\t得分:" + ja[i]["GainPoint"].ToString() + "\n");
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
            paperContent = Interop.ExamSystem.FindPaperContent(examID, stuID).DataString;
            if (paperContent == null)
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
            String studentList = Interop.ExamSystem.FindSubmitStudentByExamID(examID).DataString;

            printJson(studentList, "ExamName", "StudentName", "GainPoint");

        }

        private void printJson(String json, String mainKey, String firstKey, String secondKey)
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
        
        private void btnExit_Click(object sender, EventArgs e)
        {
            if (user != null)
            {
                Interop.UserSystem.LogoutUser(user);
            }
            Close();
        }

        private void menuAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("科大奥锐实验教学系统信息提取工具（Build:" + MainForm.version.ToString() + ")\n使用软件所造成的一切后果由用户承担\n请酌情使用\nGPL协议", "关于");
        }
        

        private void menuExit_Click(object sender, EventArgs e)
        {
            if (user != null)
            {
                Interop.UserSystem.LogoutUser(user);
            }
            Close();
        }
        
        private void btnDanger_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("增强模式仍然在测试中，可能带来不可预料的后果\r\n确认继续么？", "Warning!", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                if (MessageBox.Show("真的确认继续么？", "Warning x2", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    if (MessageBox.Show("既然你确认了，万一将来报道出了偏差，就是你的错", "Warning x3", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        //(new AdvancedMode()).Show();
                        AdvancedFininishExam();
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    //(new AdvancedMode()).Show();
                }
            }
            else
            {
                return;
            }

        }
    }
}
