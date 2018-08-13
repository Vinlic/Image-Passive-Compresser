using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Diagnostics;
using System.IO;

namespace Image_Auto_Compresser
{
    public class ImageCompresser
    {

        private static String toolsPath = @"tools\";
        public static String[] JPEGSupportSaveType = { "jpg", "png", "gif", "svg", "webp", "bmp" };

        public static string ToolsPath { get => toolsPath; set => toolsPath = value; }
        public HomeForm Home { get => home; set => home = value; }

        public struct CompressInfo
        {
            public String path;
            public String outputPath;
            public int compressibility;
            public Boolean losslessCompress;
            public Boolean rewrite;
            public String newImgType;
        }

        private HomeForm home;

        public ImageCompresser(HomeForm form)
        {
            Home = form;
        }

        public Boolean Compress_JPEG_File(CompressInfo info)
        {
            Process process = CreateProcess();
            process.StandardInput.AutoFlush = true;

            String path = "";

            if (!info.rewrite) {

                path = Path.Combine(info.outputPath, Path.GetFileNameWithoutExtension(info.path));

                if (File.Exists(path + ".jpg"))
                    path += ".iac.jpg";
                else
                    path += ".jpg";

                if (File.Exists(path) && home.FileCanRW(path))
                    File.Delete(path);

                if (File.Exists(info.path) && !File.Exists(path))
                {
                    File.Copy(info.path, path);
                }

                info.path = path;
            }

            if (info.losslessCompress)
            {
                process.StandardInput.WriteLine(ToolsPath + "jpegoptim.exe --strip-none \"" + info.path + "\"&exit");
            }
            else
            {
                process.StandardInput.WriteLine(ToolsPath + "jpegoptim.exe --strip-none -m " + (100 - info.compressibility) + " \"" + info.path + "\"&exit");
            }
            
            String output = process.StandardOutput.ReadToEnd();
            String error = process.StandardError.ReadToEnd();
            CloseProcess(process);
            return output.Contains("OK") || error.Contains("OK");

        }

        public Boolean Compress_PNG_File(CompressInfo info)
        {
            Process process = CreateProcess();
            process.StandardInput.AutoFlush = true;

            String path = "";

            if (!info.rewrite)
            {

                path = Path.Combine(info.outputPath, Path.GetFileNameWithoutExtension(info.path));

                if (File.Exists(path + ".png"))
                    path += ".iac.png";
                else
                    path += ".png";

                if (File.Exists(path) && home.FileCanRW(path))
                    File.Delete(path);

                if (File.Exists(info.path) && !File.Exists(path))
                {
                    File.Copy(info.path, path);
                }

                info.path = path;

            }

            if (info.losslessCompress)
            {
                process.StandardInput.WriteLine(ToolsPath + "pngquant.exe -v -f --strip -o \"" + info.path + "\" \"" + info.path + "\"&exit");
            }
            else
            {
                process.StandardInput.WriteLine(ToolsPath + "pngquant.exe -v -f --strip -o \"" + info.path  + "\" --quality=" + (100 - (info.compressibility > 90 ? 100 : info.compressibility)) + " \"" + info.path + "\"&exit");
            }
            
            String output = process.StandardOutput.ReadToEnd();
            String error = process.StandardError.ReadToEnd();
            CloseProcess(process);
            return output.Contains("Quantized") || error.Contains("Quantized");

        }

        public Boolean Compress_GIF_File(CompressInfo info)
        {
            Process process = CreateProcess();
            process.StandardInput.AutoFlush = true;

            String path = "";

            if (!info.rewrite)
            {
                path = Path.Combine(info.outputPath, Path.GetFileNameWithoutExtension(info.path));

                if (File.Exists(path + ".gif"))
                    path += ".iac.gif";
                else
                    path += ".gif";

                if (File.Exists(path) && home.FileCanRW(path))
                    File.Delete(path);

                if (File.Exists(info.path) && !File.Exists(path))
                {
                    File.Copy(info.path, path);
                }

                info.path = path;
            }

            //只支持无损压缩
            process.StandardInput.WriteLine(ToolsPath + "gifsicle.exe -O3 -V -w -i \"" + info.path + "\" -o \"" + info.path + "\"&exit");

            String output = process.StandardOutput.ReadToEnd();
            String error = process.StandardError.ReadToEnd();
            CloseProcess(process);
            return output.Contains(Path.GetFileName(info.path) + "]") || error.Contains(Path.GetFileName(info.path) + "]");
        }

        private Process CreateProcess()
        {
            Process process = new Process();
            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.UseShellExecute = false;     //是否使用操作系统shell启动
            process.StartInfo.CreateNoWindow = true;        //不显示程序窗口
            process.StartInfo.RedirectStandardOutput = true;  //由调用程序获取输出信息
            process.StartInfo.RedirectStandardInput = true;  //接受来自调用程序的输入信息
            process.StartInfo.RedirectStandardError = true;  //重定向标准错误输出
            process.Start();
            return process;
        }

        private void CloseProcess(Process process)
        {
            process.WaitForExit();
            process.Close();
            process.Dispose();
        }

    }

}
