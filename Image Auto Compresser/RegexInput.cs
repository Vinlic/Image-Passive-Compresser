using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Image_Auto_Compresser
{
    public partial class RegexInput : Form
    {
        private HomeForm home;

        public RegexInput(HomeForm form)
        {
            home = form;
            InitializeComponent();
        }

        private void RegexInputBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Regex.IsMatch("", regexInputBox.Text);
                regexCheckStatus.Text = "语法正确";
                regexCheckStatus.ForeColor = Color.Green;
                addRegExBtn.Enabled = true;
            }
            catch
            {
                regexCheckStatus.Text = "语法错误";
                regexCheckStatus.ForeColor = Color.Red;
                addRegExBtn.Enabled = false;
            }
        }

        private void RegexInput_FormClosing(object sender, FormClosingEventArgs e)
        {
            home.inputForm = null;
        }

        private void AddRegExBtn_Click(object sender, EventArgs e)
        {
            if (!home.sourceImgNameMatchList.Contains(regexInputBox.Text))
            {
                home.AddNewRegEx(regexInputBox.Text);
                this.Close();
            }
            else
                MessageBox.Show("列表中已存在此表达式");
        }

    }
}
