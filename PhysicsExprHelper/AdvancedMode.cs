using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;

namespace PhysicsExprHelper
{
    public partial class AdvancedMode : Form
    {
        public AdvancedMode()
        {
            InitializeComponent();
        }

        private void AdvancedMode_Load(object sender, EventArgs e)
        {
            getUndoExamPapersByStudentID();
        }

        private String getUndoExamPapersByStudentID()
        {
            String undoExam = PhysicsExprHelper.Interop.ExamSystem.FindUndoExamByStudentID(MainForm.user).DataString;
            tbLog.AppendText(undoExam + "\n");
            //printJson(undoExam, "ExamName", "ExamID", "UsePapers");
            JArray ja = (JArray)JsonConvert.DeserializeObject(undoExam);
            if (ja == null)
            {
                return null;
            }
            String origin = PhysicsExprHelper.Interop.ExamSystem.findPaperContentByPaperID(ja[0]["UsePapers"].ToString()).DataString;
            String text = origin.Replace("\\r\\n", "\n").Replace("\"<", "<").Replace(">\"", ">").Replace("\\\"","\"");
            XmlDocument xml = new XmlDocument();
            xml.LoadXml(text);

            tbLog.AppendText(xml.InnerXml);
            return origin;
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
                tbLog.AppendText(ja[0][mainKey].ToString() + "\n");
                for (int i = 0; i < number; ++i)
                {
                    tbLog.AppendText(ja[i][firstKey].ToString() + ":");
                    tbLog.AppendText(ja[i][secondKey].ToString() + "\n");
                }
            }
        }
    }
}
