using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using System.Xml;

namespace Image_Auto_Compresser
{
    public partial class HomeForm : Form
    {

        private String sourceFolderPath = "";   //监视文件夹路径
        private String outputFolderPath = "";   //输出文件夹路径
        private List<String> sourceImgTypeList = new List<String>() { "jpg", "png" };   //监视图片类型列表
        private Boolean enableSourceImgFilter = false;  //开启源图片大小过滤器
        private Decimal sourceImgSize = 100;    //监视图片大小
        private String sourceImgSizeUnit = "KB";    //监视图片大小单位
        private Boolean enableWatchChildFolder = false;    //开启监视子文件夹
        public List<String> sourceImgNameMatchList = new List<String>();    //匹配表达式列表
        private List<String> excludeImgPathList = new List<String>();   //排除图片文件路径列表
        private Byte compressibility = 50; //图片压缩率
        private Boolean enableLosslessCompress = false;   //开启无损压缩
        private Boolean enableRewriteSourceImg = false;    //开启源图片覆盖
        private Boolean enableStartedCompressImg = false;   //开启启动后先压缩文件夹内所有图片
        private int imgCompressSuccessCount = 0;    //成功压缩图片个数
        private int imgCompressFailedCount = 0;    //失败压缩图片个数
        private Boolean compresserRunning = false;    //压缩器是否正在运行
        private List<String> compressTasks = new List<String>();    //压缩任务列表
        private List<String> compressedList = new List<String>();    //已压缩的任务列表
        private List<String> compressFailedList = new List<String>();    //压缩失败项
        private System.Timers.Timer compressTaskTimer = new System.Timers.Timer(500);   //轮询器
        private int lastCompressTime = 0;   //最后一次执行压缩的时间戳
        private Boolean CompressLock = false;   //压缩线程锁
        private FileSystemWatcher sourceFolderWatcherForJPEG = new FileSystemWatcher();   //JPEG图片监听器
        private FileSystemWatcher sourceFolderWatcherForPNG = new FileSystemWatcher();   //PNG图片监听器
        private FileSystemWatcher sourceFolderWatcherForGIF = new FileSystemWatcher();   //GIF图片监听器
        private ImageCompresser compresser;   //压缩器实例
        public RegexInput inputForm;   //正则输入器实例
        public HelpForm helpForm;   //正则输入器实例
        public String RegExTemp;   //正则表达式Temp


        public HomeForm()
        {
            InitializeComponent();
            compresser = new ImageCompresser(this);
        }

        /*
         * 选择监视文件夹
         */

        private void OpenSourceFolderBtn_Click(object sender, EventArgs e)
        {
            if(sourceFolderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                sourceFolderPathBox.Text = sourceFolderPath = sourceFolderBrowserDialog.SelectedPath;
                UpdateConfigFile();
            }
        }

        /*
         * 选择输出文件夹
         */

        private void OpenOutputFolderBtn_Click(object sender, EventArgs e)
        {
            if (outputFolderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                outputFolderPathBox.Text = outputFolderPath = outputFolderBrowserDialog.SelectedPath;
                UpdateConfigFile();
            }
        }

        /*
         * 运行压缩器
         */

        private void RunCompresserBtn_Click(object sender, EventArgs e)
        {
            if(compresserRunning)
            { 
                this.Text = "图片被动压缩器";
                runCompresserBtn.Text = "启动压缩器";
                CloseImageWatchers(sourceImgTypeList);
                compresserRunning = false;
                compressTaskTimer.Stop();
                compressTasks.Clear();
                compressedList.Clear();
                compressFailedList.Clear();
                lastCompressTime = 0;
                enableStartedCompressImg = startedCompressImgBox.Checked;
                startedCompressImgBox.Enabled = true;
                AddLog("压缩器已停止");
            }
            else
            {
                String result;
                if ((result = CheckReadyStart()) != "OK")
                {
                    MessageBox.Show(result);
                    return;
                }
                this.Text = "图片被动压缩器（运行中)";
                runCompresserBtn.Text = "停止运行";
                StartImageWatchers(sourceImgTypeList);
                compresserRunning = true;
                startedCompressImgBox.Enabled = false;
                compressTaskTimer.Start();
                AddLog("压缩器启动成功");
            }
        }

        private String CheckReadyStart()
        {
            if (sourceFolderPath == "" || !Directory.Exists(sourceFolderPath))
                return "监视文件夹路径不存在，请重新指定";
            if (outputFolderPath == "" || !Directory.Exists(outputFolderPath))
                return "输出文件夹路径不存在，请重新指定";
            return "OK";
        }

        private void CompressAllSourceImg(string path)
        {
            try
            {
                DirectoryInfo baseFolder = new DirectoryInfo(path);

                foreach (FileInfo file in baseFolder.GetFiles())
                {
                    if (!file.Name.Contains(".iac.") && (Path.GetExtension(file.Name).Equals(".jpg") || Path.GetExtension(file.Name).Equals(".png") || Path.GetExtension(file.Name).Equals(".gif")))
                    {
                        if (!compressTasks.Contains(file.FullName))
                            compressTasks.Add(file.FullName);
                        CompressTaskHandler();
                    }  
                }

                foreach (DirectoryInfo folder in baseFolder.GetDirectories())
                {
                    CompressAllSourceImg(folder.FullName);
                }
            }
            catch
            {
                AddLog("启动后压缩失败");
            }
        }

        /*
         * 压缩任务事件
         */

        private void CompressTaskHandlerEvent(object sender, System.Timers.ElapsedEventArgs e)
        {
            CompressTaskHandler();
        }

        private void CompressTaskHandler(Boolean fristStart)
        {
            if (enableStartedCompressImg)
                CompressAllSourceImg(sourceFolderPath);
        }

        /*
         * 压缩任务处理
         */

        private void CompressTaskHandler()
        {
            if (enableStartedCompressImg)
            {
                enableStartedCompressImg = false;
                CompressAllSourceImg(sourceFolderPath);
            }
            if (CompressLock)
                return;
            CompressLock = true;
            if (compressTasks.Count > 0)
            {
                if (!compressTaskTimer.Enabled)
                    compressTaskTimer.Start();
                for (int i = 0; i < compressTasks.Count; i++)
                {
                    String path = compressTasks[i];

                    //正则文件名匹配
                    for (int m = 0; m < sourceImgNameMatchList.Count; m++)
                    {
                        AddLog("正则匹配" + Path.GetFileName(path) + "|" + sourceImgNameMatchList[m] + "|" + Regex.IsMatch(Path.GetFileName(path), sourceImgNameMatchList[m]));
                        if (!Regex.IsMatch(Path.GetFileName(path), sourceImgNameMatchList[m]))
                            compressTasks.RemoveAll(o => o == path);
                    }

                    if (FileCanRW(path) && compressTasks.Contains(path))
                    {

                        //过滤掉大小不符合要求的路径
                        if (enableSourceImgFilter)
                        {
                            Boolean pass = false;
                            FileInfo fi = new FileInfo(path);
                            long fileSize = fi.Length;
                            AddLog("文件大小检测 " + fileSize + "|" + path);
                            switch (sourceImgSizeUnit)
                            {
                                case "B":
                                    pass = sourceImgSize > fileSize;
                                    break;
                                case "KB":
                                    pass = sourceImgSize > fileSize / 1024;
                                    break;
                                case "MB":
                                    pass = sourceImgSize > fileSize / (1024 * 1024);
                                    break;
                                case "GB":
                                    pass = sourceImgSize > fileSize / (1024 * 1024 * 1024);
                                    break;
                            }
                            if (pass)
                            {
                                compressTasks.RemoveAll(o => o == path);
                                continue;
                            }
                        }

                        AddLog(path + " 可压缩");
                        CompressImg(path);

                    }
                }
                CompressLock = false;
            }
            else
            {
                if(CompressLock)
                    CompressLock = false;
                if(compressedList.Count > 0)
                {
                    AddLog("清除压缩列表");
                    compressedList.Clear();
                }
                if (GetNowTimestamp() - lastCompressTime > 6)
                {
                    AddLog("清除压缩临时文件");
                    ClearTempFiles(outputFolderPath);
                    if(compressTaskTimer.Enabled)
                        compressTaskTimer.Stop();
                }
            }

        }

        /*
         * 压缩图片
         */

        private void CompressImg(string path)
        {
            String imgExt = Path.GetExtension(path);
            imgExt = imgExt.Substring(1, imgExt.Length - 1);
            for (int i = 0; i < sourceImgTypeList.Count; i++)
            {
                String type = sourceImgTypeList[i];
                if (imgExt.Equals(type))
                {
                    Boolean result = false;
                    switch (imgExt)
                    {
                        case "jpg":
                        case "jpeg":
                            ImageCompresser.CompressInfo jpegInfo = new ImageCompresser.CompressInfo()
                            {
                                path = path,
                                outputPath = outputFolderPath,
                                compressibility = compressibility,
                                rewrite = enableRewriteSourceImg,
                                losslessCompress = enableLosslessCompress,
                                newImgType = "jpg"
                            };
                            result = compresser.Compress_JPEG_File(jpegInfo);
                            break;
                        case "png":
                            ImageCompresser.CompressInfo pngInfo = new ImageCompresser.CompressInfo()
                            {
                                path = path,
                                outputPath = outputFolderPath,
                                compressibility = compressibility,
                                rewrite = enableRewriteSourceImg,
                                losslessCompress = enableLosslessCompress,
                                newImgType = "png",
                            };
                            result = compresser.Compress_PNG_File(pngInfo);
                            break;
                        case "gif":
                            ImageCompresser.CompressInfo gifInfo = new ImageCompresser.CompressInfo()
                            {
                                path = path,
                                outputPath = outputFolderPath,
                                compressibility = compressibility,
                                rewrite = enableRewriteSourceImg,
                                losslessCompress = enableLosslessCompress,
                                newImgType = "gif",
                            };
                            result = compresser.Compress_GIF_File(gifInfo);
                            break;
                    }
                    if (result)
                    {
                        AddLog(path + "已压缩");
                        imgCompressSuccessCount++;
                        if (!compressedList.Contains(path))
                            compressedList.Add(path);
                        compressTasks.RemoveAll(o => o == path);
                        UpdateCompressCount();
                    }
                    else
                    {
                        compressFailedList.Add(path);
                        if (CompressFailedHandler(path))
                        {
                            imgCompressFailedCount++;
                            compressTasks.RemoveAll(f => f == path);
                            UpdateCompressCount();
                        }
                    }
                    lastCompressTime = GetNowTimestamp();
                    break;
                }
            }
        }

        private Boolean CompressFailedHandler(String path)
        {
            int errorCount = 0;
            for (int e = 0; e < compressFailedList.Count; e++)
            {
                if(compressFailedList.Contains(path))
                    errorCount++;

                if(errorCount > 4)
                {
                    compressFailedList.RemoveAll(f => f.Contains(path));
                    return true;
                }   
            }
            return false;
        }

        private FileSystemWatcher GetImageWatcher(String imgType)
        {
            FileSystemWatcher watcher;
            switch (imgType)
            {
                case "jpg":
                    watcher = sourceFolderWatcherForJPEG;
                    watcher.Filter = "*.jpg";
                    break;
                case "png":
                    watcher = sourceFolderWatcherForPNG;
                    watcher.Filter = "*.png";
                    break;
                case "gif":
                    watcher = sourceFolderWatcherForGIF;
                    watcher.Filter = "*.gif";
                    break;
                default:
                    return new FileSystemWatcher();
            }
            return watcher;
        }

        /*
         * 启动图片监听器
         */

        private void StartImageWatchers(List<String> imgTypes)
        {
            foreach(String imgType in imgTypes)
            {
                FileSystemWatcher watcher = GetImageWatcher(imgType);
                watcher.Path = sourceFolderPath;
                watcher.InternalBufferSize = 65536;
                watcher.IncludeSubdirectories = enableWatchChildFolder;
                watcher.NotifyFilter = NotifyFilters.FileName | NotifyFilters.LastWrite | NotifyFilters.CreationTime | NotifyFilters.Size;
                watcher.Created += new FileSystemEventHandler(this.SourceFileOnCreated);
                watcher.Renamed += new RenamedEventHandler(this.SourceFileOnCreated);
                watcher.EnableRaisingEvents = true;
            }
        }

        private void CloseImageWatchers(List<String> imgTypes)
        {
            foreach (String imgType in imgTypes)
            {
                FileSystemWatcher watcher = GetImageWatcher(imgType);
                watcher.Created -= new FileSystemEventHandler(this.SourceFileOnCreated);
                watcher.Renamed -= new RenamedEventHandler(this.SourceFileOnCreated);
                watcher.EnableRaisingEvents = false;
            }
        }

        private void OpenImageWatcher(List<String> imgTypes)
        {
            foreach (String imgType in imgTypes)
            {
                FileSystemWatcher watcher = GetImageWatcher(imgType);
                watcher.EnableRaisingEvents = true;
            }
        }

        private void StopImageWatcher(List<String> imgTypes)
        {
            foreach (String imgType in imgTypes)
            {
                FileSystemWatcher watcher = GetImageWatcher(imgType);
                watcher.EnableRaisingEvents = false;
            }
        }

        /*
         * 查看日志
         */

        private void ShowLogBtn_Click(object sender, EventArgs e)
        {
            if (helpForm == null)
            {
                helpForm = new HelpForm(this);
                helpForm.Show();
            }
            else
                helpForm.Activate();
        }

        /*
         * 选择排除的图片文件
         */

        private void ChooseExcludeFileBtn_Click(object sender, EventArgs e)
        {
            if (excludeImgPathList.Count > 300)
                MessageBox.Show("当前排除文件个数已达300个以上，太多可能影响压缩效率，请尽量使用文件夹进行排除");
            if (excludeImgBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                String[] paths = excludeImgBrowserDialog.FileNames;
                foreach(String path in paths)
                {
                    if (!excludeImgPathList.Contains(path))
                    {
                        excludeImgPathList.Add(path);
                        excludeImgList.Items.Add(path);
                    }
                    else
                        MessageBox.Show("路径已存在，无需重复添加");
                }
                MessageBox.Show("已添加" + paths.Length + "个需要的排除图片");
                UpdateConfigFile();
            }
        }

        /*
         * 选择排除的图片文件夹
         */

        private void ChooseExcludeFolderBtn_Click(object sender, EventArgs e)
        {
            if(excludeImgFolderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                String path = excludeImgFolderBrowserDialog.SelectedPath;
                if (!excludeImgPathList.Contains(path))
                {
                    excludeImgPathList.Add(path);
                    UpdateExcludeImgPathList();
                    UpdateConfigFile();
                    MessageBox.Show("已添加：" + path);
                }
                else
                    MessageBox.Show("路径已存在，无需重复添加");
            }
        }

        /*
         * 添加图片名称匹配表达式
         */

        private void AddImgMatchBtn_Click(object sender, EventArgs e)
        {
            if (inputForm == null)
            {
                inputForm = new RegexInput(this);
                inputForm.Show();
            }
            else
                inputForm.Activate();
        }

        /*
         * 添加指定图片类型
         */

        private void AddImgTypeBtn_Click(object sender, EventArgs e)
        {
            String imgType = imgTypeSelector.Text;
            if (!sourceImgTypeList.Contains(imgType))
            {
                sourceImgTypeList.Add(imgType);
                imgTypeBox.Text = String.Join(" ", sourceImgTypeList);
                UpdateImgTypeBtnStatus();
                List<String> types = new List<String>() { imgType };
                StartImageWatchers(types);
                UpdateConfigFile();
                if (imgTypeSelector.SelectedItem.ToString() == "gif")
                    MessageBox.Show("gif格式目前只支持无损压缩，因此对于GIF图片压缩率将不会生效");
            }
        }

        /*
         * 删除指定图片类型
         */

        private void DelImgTypeBtn_Click(object sender, EventArgs e)
        {
            String imgType = imgTypeSelector.Text;
            if (sourceImgTypeList.Contains(imgType))
            {
                sourceImgTypeList.Remove(imgType);
                imgTypeBox.Text = String.Join(" ", sourceImgTypeList);
                UpdateImgTypeBtnStatus();
                List<String> types = new List<String>(){ imgType };
                CloseImageWatchers(types);
                UpdateConfigFile();
            }
        }

        /*
         * 更改图片类型选项
         */

        private void ImgTypeSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateImgTypeBtnStatus();
        }

        /*
         * 更改监视图片大小
         */

        private void ImgSizeValueBox_ValueChanged(object sender, EventArgs e)
        {
            sourceImgSize = imgSizeValueBox.Value;
            UpdateImgSizeBoxDec();
            UpdateConfigFile();
        }

        /*
         * 更改监视图片大小单位
         */

        private void ImgSizeUnitBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            sourceImgSizeUnit = imgSizeUnitBox.Text;
            UpdateImgSizeBoxDec();
            UpdateConfigFile();
        }

        /*
         * 删除图片名称匹配表达式
         */

        private void DelImgMatchBtn_Click(object sender, EventArgs e)
        {
            if (imgNameMatchList.SelectedItems.Count == 0)
                return;
            String[] matchs = new String[imgNameMatchList.SelectedItems.Count];
            imgNameMatchList.SelectedItems.CopyTo(matchs, 0);
            foreach (String match in matchs)
            {
                if (sourceImgNameMatchList.Contains(match))
                    sourceImgNameMatchList.Remove(match);
                imgNameMatchList.Items.Remove(match);
            }
            UpdateConfigFile();
        }

        /*
         * 删除排除图片或文件夹路径
         */

        private void DelExcludePathBtn_Click(object sender, EventArgs e)
        {
            if (excludeImgList.SelectedItems.Count == 0)
                return;
            String[] paths = new String[excludeImgList.SelectedItems.Count];
            excludeImgList.SelectedItems.CopyTo(paths, 0);
            foreach (String path in paths)
            {
                if (excludeImgPathList.Contains(path))
                    excludeImgPathList.Remove(path);
                excludeImgList.Items.Remove(path);
            }
            UpdateConfigFile();
        }

        private void DelExcludePathBtn_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                clearExcludeImgListStrip.Show((Button)sender, new Point(e.X, e.Y));
        }

        private void ClearExcludeImgListStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if(e.ClickedItem.Text == "清空排除列表")
            {
                excludeImgPathList.Clear();
                excludeImgList.Items.Clear();
            }
        }

        private void HomeForm_Load(object sender, EventArgs e)
        {
            compressTaskTimer.AutoReset = true;
            compressTaskTimer.Elapsed += new System.Timers.ElapsedEventHandler(CompressTaskHandlerEvent);
            LoadConfigFile();
        }

        /*
         * 开启监听子文件夹
         */

        private void WatchChildFolderBox_CheckedChanged(object sender, EventArgs e)
        {
            enableWatchChildFolder = watchChildFolderBox.Checked;
            UpdateConfigFile();
            if (watchChildFolderBox.Checked)
                MessageBox.Show((compresserRunning ? "压缩器正在运行中，重新启动压缩器后才会生效，" : "") + "开启此选项请确保你的子文件夹没有太多需要监听的图片文件，图片文件过多可能会导致部分文件无法被监听，多图片情况下请修改监听文件夹为你的子文件夹");
        }

        private void CompressCoverBox_CheckedChanged(object sender, EventArgs e)
        {
            enableRewriteSourceImg = compressCoverBox.Checked;
            UpdateConfigFile();
            if (compressCoverBox.Checked && startedCompressImgBox.Checked)
            {
                MessageBox.Show("您已同时开启覆盖和启动后自动压缩，意味着启动后将会对文件夹内所有可压缩图片进行覆盖压缩，不保留副本，如果您不希望原图被覆盖请勿开启覆盖选项");
            }
        }

        private void StartedCompressImgBox_CheckedChanged(object sender, EventArgs e)
        {
            enableStartedCompressImg = startedCompressImgBox.Checked;
            UpdateConfigFile();
            if (compressCoverBox.Checked && startedCompressImgBox.Checked)
            {
                MessageBox.Show("您已同时开启覆盖和启动后自动压缩，意味着启动后将会对文件夹内所有可压缩图片进行覆盖压缩，不保留副本，如果您不希望原图被覆盖请勿开启覆盖选项");
            }
        }

        /*
         * 开启无损压缩
         */

        private void LosslessBox_CheckedChanged(object sender, EventArgs e)
        {
            enableLosslessCompress = losslessBox.Checked;
            compressibilityTrack.Enabled = !losslessBox.Checked;
            UpdateConfigFile();
        }

        /*
         * 更新图片正则表达式列表
         */

        private void UpdateImgNameMatchList()
        {
            for (int i = 0;i < sourceImgNameMatchList.Count;i++)
            {
                if(!imgNameMatchList.Items.Contains(sourceImgNameMatchList[i]))
                    imgNameMatchList.Items.Add(sourceImgNameMatchList[i]);
            }
        }

        private void UpdateExcludeImgPathList()
        {
            for(int i = 0;i < excludeImgPathList.Count;i++)
            {
                if (!excludeImgList.Items.Contains(excludeImgPathList[i]))
                    excludeImgList.Items.Add(excludeImgPathList[i]);
            }
        }

        /*
         * 更新图片压缩率
         */

        private void UpdateImgCompressibility(byte value)
        {
            compressibility = value;
            compressibilityValueLabel.Text = compressibility.ToString() + '%';
        }

        /*
         * 更新图片类型
         */

        private void UpdateImgTypeBtnStatus()
        {
            String[] imgTypes = new String[imgTypeSelector.Items.Count];
            imgTypeSelector.Items.CopyTo(imgTypes, 0);
            Boolean imgTypeExists = sourceImgTypeList.Contains(imgTypes[imgTypeSelector.SelectedIndex]);
            addImgTypeBtn.Enabled = !imgTypeExists;
            delImgTypeBtn.Enabled = imgTypeExists;
        }

        /*
         * 更新图片大小状态
         */

        private void UpdateImgSizeBoxDec()
        {
            imgSizeValueBox.Value = sourceImgSize;
            if (sourceImgSizeUnit == "KB")
                imgSizeValueBox.DecimalPlaces = 1;
            else if (sourceImgSizeUnit == "MB" || sourceImgSizeUnit == "GB")
                imgSizeValueBox.DecimalPlaces = 2;
            else
                imgSizeValueBox.DecimalPlaces = 0;
        }

        /*
         * 更新压缩个数
         */

        //声明委托
        private delegate void UpdateCompressCountDelegate();
        private void UpdateCompressCount()
        {
            try
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new UpdateCompressCountDelegate(UpdateCompressCount));
                }
                else
                {
                    compressSuccessValue.Text = imgCompressSuccessCount.ToString();
                    compressFailedValue.Text = imgCompressFailedCount.ToString();
                }
            }
            catch
            {
                AddLog("更新压缩数量失败");
            }
        }

        /*
         * 检查文件是否可读写
         */

        public Boolean FileCanRW(string path)
        {
            if (File.Exists(path))
            {
                Boolean isUse = true;
                FileStream fs = null;
                try
                {
                    fs = new FileStream(path, FileMode.Open, FileAccess.ReadWrite, FileShare.Delete);
                    isUse = false;
                }
                catch {
                    AddLog("文件暂不可读写");
                }
                finally
                {
                    if (fs != null)
                        fs.Close();
                }
                return !isUse;
            }
            else
            {
                return false;
            }
        }

        /*
         * 清除临时文件
         */

        private void ClearTempFiles(string path)
        {
            try
            {
                DirectoryInfo baseFolder = new DirectoryInfo(path);

                foreach (FileInfo file in baseFolder.GetFiles())
                {
                    if (Path.GetExtension(file.Name).Equals(".tmp") && FileCanRW(file.FullName))
                        File.Delete(file.FullName);
                }

                foreach (DirectoryInfo folder in baseFolder.GetDirectories())
                {
                    ClearTempFiles(folder.FullName);
                }
            }
            catch
            {
                AddLog("清除临时文件失败");
            }
        }

        /*
         * 获取当前时间戳（秒）
         */

        public static int GetNowTimestamp()
        {
            TimeSpan ts = DateTime.Now.ToUniversalTime() - new DateTime(1970, 1, 1);
            return (int)ts.TotalSeconds;
        }

        /*
         * 添加日志
         */

        public static void AddLog(string logText)
        {
            try
            {
                DateTime date = DateTime.Now;
                logText = date.ToString() + " " + logText + "\r\n";
                Console.WriteLine(logText);
                byte[] logData = Encoding.UTF8.GetBytes(logText);
                if (File.Exists(@"compress.log"))
                {
                    FileInfo fi = new FileInfo(@"compress.log");
                    if (fi.Length > 5242880)
                        File.Delete(@"compress.log");
                }
                FileStream fs = new FileStream(@"compress.log", FileMode.Append, FileAccess.Write, FileShare.Write);
                fs.Write(logData, 0, logData.Length);
                fs.Close();
            }
            catch
            {
                Console.WriteLine("添加日志失败");
            }
        }

        /*
         * 检查文件是否可读写
         */

        private void SourceFileOnCreated(object sender, FileSystemEventArgs e)
        {
            if (e.FullPath.Contains(".iac."))
                return;
            if (enableRewriteSourceImg && compressedList.Contains(e.FullPath))
            {
                compressedList.RemoveAll(o => o == e.FullPath);
                AddLog("拒绝" + e.FullPath + " " + compressedList.Count);
                return;
            }
            if (IsExcludePath(e.FullPath)) {
                AddLog("排除" + e.FullPath);
                return;
            }
            AddLog("新文件" + e.FullPath);
            if (!compressTasks.Contains(e.FullPath))
                compressTasks.Add(e.FullPath);
            CompressTaskHandler();
        }

        private Boolean IsExcludePath(string path)
        {

            //排除路径匹配
            for (int i = 0; i < excludeImgPathList.Count; i++)
            {
                if (path.Contains(excludeImgPathList[i]))
                    return true;
            }

            return false;
            
        }

        private void SizeFilterBox_CheckedChanged(object sender, EventArgs e)
        {
            imgSizeValueBox.Enabled = imgSizeUnitBox.Enabled = enableSourceImgFilter = sizeFilterBox.Checked;
            UpdateConfigFile();
        }

        public void AddNewRegEx(String RegExStr)
        {
            sourceImgNameMatchList.Add(RegExStr);
            UpdateImgNameMatchList();
            UpdateConfigFile();
        }

        private void LoadConfigFile()
        {
            if (!File.Exists("config.xml"))
            {
                UpdateImgTypeBtnStatus();
                UpdateImgSizeBoxDec();
                UpdateImgCompressibility(compressibility);
                AddLog("未找到配置文件");
                return;
            }
            try
            {
                XmlDocument configDoc = new XmlDocument();
                String temp = "";
                configDoc.Load("config.xml");
                sourceFolderPath = configDoc.GetElementsByTagName("sourceFolderPath")[0].InnerText.Trim(' ');
                sourceFolderPathBox.Text = sourceFolderPath;
                outputFolderPath = configDoc.GetElementsByTagName("outputFolderPath")[0].InnerText.Trim(' ');
                outputFolderPathBox.Text = outputFolderPath;
                temp = configDoc.GetElementsByTagName("sourceImgTypeList")[0].InnerText.Trim(' ');
                if(temp != "")
                    sourceImgTypeList = new List<String>(temp.Split(','));
                imgTypeBox.Text = String.Join(" ", sourceImgTypeList);
                UpdateImgTypeBtnStatus();
                enableSourceImgFilter = Convert.ToBoolean(configDoc.GetElementsByTagName("enableSourceImgFilter")[0].InnerText.Trim(' '));
                sizeFilterBox.Checked = enableSourceImgFilter;
                sourceImgSize = Convert.ToDecimal(configDoc.GetElementsByTagName("sourceImgSize")[0].InnerText.Trim(' '));
                sourceImgSizeUnit = configDoc.GetElementsByTagName("sourceImgSizeUnit")[0].InnerText.Trim(' ');
                UpdateImgSizeBoxDec();
                enableWatchChildFolder = Convert.ToBoolean(configDoc.GetElementsByTagName("enableWatchChildFolder")[0].InnerText.Trim(' '));
                watchChildFolderBox.Checked = enableWatchChildFolder;
                temp = configDoc.GetElementsByTagName("sourceImgNameMatchList")[0].InnerText.Trim(' ');
                if(temp != "")
                    sourceImgNameMatchList = new List<String>(temp.Split(','));
                UpdateImgNameMatchList();
                temp = configDoc.GetElementsByTagName("excludeImgPathList")[0].InnerText.Trim(' ');
                if (temp != "")
                    excludeImgPathList = new List<String>(temp.Split(','));
                UpdateExcludeImgPathList();
                compressibility = Convert.ToByte(configDoc.GetElementsByTagName("compressibility")[0].InnerText.Trim(' '));
                UpdateImgCompressibility(compressibility);
                enableLosslessCompress = Convert.ToBoolean(configDoc.GetElementsByTagName("enableLosslessCompress")[0].InnerText.Trim(' '));
                losslessBox.Checked = enableLosslessCompress;
                enableRewriteSourceImg = Convert.ToBoolean(configDoc.GetElementsByTagName("enableRewriteSourceImg")[0].InnerText.Trim(' '));
                compressCoverBox.Checked = enableRewriteSourceImg;
                enableStartedCompressImg = Convert.ToBoolean(configDoc.GetElementsByTagName("enableStartedCompressImg")[0].InnerText.Trim(' '));
                startedCompressImgBox.Checked = enableStartedCompressImg;
            }
            catch
            {
                UpdateImgTypeBtnStatus();
                UpdateImgSizeBoxDec();
                UpdateImgCompressibility(compressibility);
                AddLog("配置文件损坏无法读取");
                MessageBox.Show("配置文件损坏无法读取，将无法记忆操作，请重新安装本工具");
            }
        }

        private void UpdateConfigFile()
        {
            if (!File.Exists("config.xml"))
            {
                AddLog("未找到配置文件");
                return;
            }
            try
            {
                XmlDocument configDoc = new XmlDocument();
                configDoc.Load("config.xml");
                configDoc.SelectSingleNode("/iac/sourceFolderPath").InnerText = sourceFolderPath;
                configDoc.SelectSingleNode("/iac/outputFolderPath").InnerText = outputFolderPath;
                configDoc.SelectSingleNode("/iac/sourceImgTypeList").InnerText = String.Join(",", sourceImgTypeList);
                configDoc.SelectSingleNode("/iac/enableSourceImgFilter").InnerText = String.Join(",", enableSourceImgFilter);
                configDoc.SelectSingleNode("/iac/sourceImgSize").InnerText = sourceImgSize.ToString();
                configDoc.SelectSingleNode("/iac/sourceImgSizeUnit").InnerText = sourceImgSizeUnit;
                configDoc.SelectSingleNode("/iac/enableWatchChildFolder").InnerText = enableWatchChildFolder.ToString();
                configDoc.SelectSingleNode("/iac/sourceImgNameMatchList").InnerText = String.Join(",", sourceImgNameMatchList);
                configDoc.SelectSingleNode("/iac/excludeImgPathList").InnerText = String.Join(",", excludeImgPathList);
                configDoc.SelectSingleNode("/iac/compressibility").InnerText = compressibility.ToString();
                configDoc.SelectSingleNode("/iac/enableLosslessCompress").InnerText = enableLosslessCompress.ToString();
                configDoc.SelectSingleNode("/iac/enableRewriteSourceImg").InnerText = enableRewriteSourceImg.ToString();
                configDoc.SelectSingleNode("/iac/enableStartedCompressImg").InnerText = enableStartedCompressImg.ToString();
                configDoc.Save("config.xml");
                AddLog("写入配置成功");
            }
            catch
            {
                AddLog("加载配置文件失败");
            }
        }

        private void SourceFolderPathBox_TextChanged(object sender, EventArgs e)
        {
            sourceFolderPath = sourceFolderPathBox.Text;
        }

        private void OutputFolderPathBox_TextChanged(object sender, EventArgs e)
        {
            outputFolderPath = outputFolderPathBox.Text;
        }

        /*
         * 更改图片压缩率
         */

        private void CompressibilityTrack_ValueChanged(object sender, EventArgs e)
        {
            UpdateImgCompressibility((byte)compressibilityTrack.Value);
        }

        private void CompressibilityTrack_MouseUp(object sender, MouseEventArgs e)
        {
            UpdateConfigFile();
        }
    }
}
