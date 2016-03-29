using Newtonsoft.Json;
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

namespace update
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
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

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.Visible = true;
            Boolean status = download("http://tsingedu.com/update/update.json", "update.json");
            if (status)
            {
                JObject info = readJson("update.json");
                if (info == null)
                {
                    MessageBox.Show("更新发生错误！程序即将退出", "ERROR");
                    Close();
                }
                status = download("http://tsingedu.com/update/" + info["LatestVersion"].ToString() + ".json", "update.json");
                if (status)
                {
                    StreamReader sr = new StreamReader("update.json", Encoding.UTF8);
                    try
                    {
                        String line = sr.ReadLine();
                        sr.Close();
                        File.Delete("update.json");
                        JArray ja = (JArray)JsonConvert.DeserializeObject(line);
                        if (ja == null)
                        {
                            return;
                        }
                        int number = (int)ja.Count();
                        progressBar.Maximum = number - 1;
                        if (number != 0)
                        {
                            for (int i = 0; i < number; ++i)
                            {
                                status = false;
                                int attemp = 0;
                                while ((!status) && (attemp < 10))
                                {
                                    status = download(ja[i]["path"].ToString(), ja[i]["name"].ToString());
                                    attemp++;
                                }
                                if (!(attemp < 10))
                                {
                                    MessageBox.Show("下载文件出错，请检查网络\n程序即将退出，如果主程序无法打开请手动运行update.exe", "ERROR");
                                }
                                progressBar.Value = i;
                            }
                        }
                        MessageBox.Show("成功更新！可以开始赛艇了！", "Update");
                        Close();

                    }
                    catch (Exception e2)
                    {
                        Close();
                        MessageBox.Show("更新发生错误！程序即将退出", "ERROR");
                    }


                }
            }
        }
    }
}
