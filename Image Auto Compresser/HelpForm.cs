using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Image_Auto_Compresser
{
    public partial class HelpForm : Form
    {

        private HomeForm home;

        public HelpForm(HomeForm form)
        {
            home = form;
            InitializeComponent();
        }

        private void BlogLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://blog.vinlic.com");
        }

        private void HelpForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            home.helpForm = null;
        }

        private void HelpForm_Load(object sender, EventArgs e)
        {
            if (File.Exists(@"compress.log"))
            {
                try
                {
                    FileStream fs = new FileStream(@"compress.log", FileMode.Open);
                    byte[] fsByte = new byte[fs.Length];
                    fs.Read(fsByte, 0, fsByte.Length);
                    logBox.Text = Encoding.UTF8.GetString(fsByte);
                    fs.Close();
                }
                catch
                {
                    logBox.Text = "读取失败，请稍后重试";
                }
            }
            else
                logBox.Text = "暂无日志";
        }
    }
}
