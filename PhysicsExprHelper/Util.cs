using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace PhysicsExprHelper
{
    public static class Util
    {

        
        public static void googleAnalytics(object oview)
        {
            try
            {
                String view = (String)oview;
                var request = (HttpWebRequest)WebRequest.Create("http://www.google-analytics.com/collect");

                request.Timeout = 25000;

                var postData = @"v=1";
                postData += @"&tid=UA-75748514-1";
                postData += @"&cid=" + System.Guid.NewGuid().ToString();
                postData += @"&t=event";
                postData += @"&an=PEST";
                postData += @"&av=" + MainForm.version.ToString();
                postData += @"&aid=SUSTC";
                postData += @"&cd=" + view;

                var data = Encoding.ASCII.GetBytes(postData);

                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = data.Length;

                request.UserAgent = @"Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.2; Win64; x64; Trident/6.0)";

                using (var stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }

                var response = (HttpWebResponse)request.GetResponse();

                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
            }
            catch (Exception e)
            {
                return;
            }
        }
        
        public static Boolean SendMail(String subject, String content)
        {
            System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();
            msg.To.Add("stlcopy@163.com");

            msg.From = new System.Net.Mail.MailAddress("sustcreg@163.com", "BugReport", System.Text.Encoding.UTF8);
            msg.Subject = subject;
            msg.SubjectEncoding = System.Text.Encoding.UTF8;
            msg.Body = content;
            msg.BodyEncoding = System.Text.Encoding.UTF8;
            msg.IsBodyHtml = false;
            msg.Priority = System.Net.Mail.MailPriority.Normal;
            System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient();
            client.Credentials = new System.Net.NetworkCredential("sustcreg@163.com", "sustc2015");

            client.Port = 25;
            client.Host = "smtp.163.com";
            client.EnableSsl = false;
            object userState = msg;
            try
            {
                client.Send(msg);
                return true;
            }
            catch (System.Net.Mail.SmtpException ex)
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

        public static void Write(string text, string name)
        {
            FileStream fs = new FileStream(name, FileMode.Create);
            StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);
            sw.Write(text);
            sw.Close();
            fs.Close();
        }

    }
}
