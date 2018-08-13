using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Image_Auto_Compresser
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {

            System.Threading.Mutex run = new System.Threading.Mutex(true, "single_test", out bool runone);

            if (runone)
            {
                run.ReleaseMutex();

                Application.EnableVisualStyles();

                Application.SetCompatibleTextRenderingDefault(false);

                HomeForm form = new HomeForm();

                int hdc = form.Handle.ToInt32();

                Application.Run(form);

                IntPtr a = new IntPtr(hdc);

            }
            else
                MessageBox.Show("压缩器已在运行");

        }
    }
}
