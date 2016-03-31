using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PhysicsExprHelper
{
    public partial class AnsSafeGet : Form
    {
        private int start { set; get; }

        public AnsSafeGet()
        {
            InitializeComponent();
        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            tbLog.Text = "";
            Boolean status = download("http://tsingedu.com/anslist/"+(listBox.SelectedIndex+start).ToString()+".json", "ans.json");
            if (status)
            {
                JObject info = readJson("ans.json");
                if (info == null)
                {
                    MessageBox.Show("卧槽出错了");
                    return;
                }
                addLog(info["title"].ToString());
                int num = info.Count;
                for (int i = 1; i < num - 1; ++i)
                {
                    addLog(i.ToString() + ":" + info[i.ToString()].ToString());
                }
            }
            else
            {
                MessageBox.Show("卧槽出错了");
            }
        }

        private void addLog(String s)
        {
            tbLog.Text += s + "\r\n";
        }

        private void AnsSafeGet_Load(object sender, EventArgs e)
        {
            Boolean status = download("http://tsingedu.com/anslist/index.json", "index.json");
            if (status)
            {
                JObject info = readJson("index.json");
                if (info == null)
                {
                    MessageBox.Show("卧槽出错了");
                    return;
                }
                start = int.Parse(info["start"].ToString());
                int num = info.Count;
                for(int i = 0;i < num-1; ++i)
                {
                    listBox.Items.Add((i + start).ToString()+":"+info[(i + start).ToString()].ToString());
                }
            }
            else
            {
                MessageBox.Show("卧槽出错了");
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

            }
            catch (Exception e)
            {
                sr.Close();
                return null;
            }

        }

        private Boolean download(String url, String name)
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

        private void listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnGet.Enabled = true;
        }
    }
}
