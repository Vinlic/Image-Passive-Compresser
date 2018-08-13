namespace Image_Auto_Compresser
{
    partial class HomeForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HomeForm));
            this.filterBox = new System.Windows.Forms.GroupBox();
            this.sizeFilterBox = new System.Windows.Forms.CheckBox();
            this.delImgMatchBtn = new System.Windows.Forms.Button();
            this.delExcludePathBtn = new System.Windows.Forms.Button();
            this.delImgTypeBtn = new System.Windows.Forms.Button();
            this.chooseExcludeFileBtn = new System.Windows.Forms.Button();
            this.chooseExcludeFolderBtn = new System.Windows.Forms.Button();
            this.excludeImgList = new System.Windows.Forms.ListBox();
            this.addImgMatchBtn = new System.Windows.Forms.Button();
            this.excludeImgText = new System.Windows.Forms.Label();
            this.addImgTypeBtn = new System.Windows.Forms.Button();
            this.imgNameMatchText = new System.Windows.Forms.Label();
            this.imgTypeSelector = new System.Windows.Forms.ComboBox();
            this.imgTypeBox = new System.Windows.Forms.TextBox();
            this.imgNameMatchList = new System.Windows.Forms.ListBox();
            this.imgSizeTipText = new System.Windows.Forms.Label();
            this.imgSizeUnitBox = new System.Windows.Forms.ComboBox();
            this.imgSizeValueBox = new System.Windows.Forms.NumericUpDown();
            this.imgTypeLabel = new System.Windows.Forms.Label();
            this.imgSizeLabel = new System.Windows.Forms.Label();
            this.watchChildFolderBox = new System.Windows.Forms.CheckBox();
            this.runCompresserBtn = new System.Windows.Forms.Button();
            this.compressibilityLabel = new System.Windows.Forms.Label();
            this.compressibilityTrack = new System.Windows.Forms.TrackBar();
            this.compressibilityValueLabel = new System.Windows.Forms.Label();
            this.sourceFolderLabel = new System.Windows.Forms.Label();
            this.outputFolderLabel = new System.Windows.Forms.Label();
            this.sourceFolderPathBox = new System.Windows.Forms.TextBox();
            this.sourceFolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.outputFolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.outputFolderPathBox = new System.Windows.Forms.TextBox();
            this.openSourceFolderBtn = new System.Windows.Forms.Button();
            this.openOutputFolderBtn = new System.Windows.Forms.Button();
            this.outputBox = new System.Windows.Forms.GroupBox();
            this.startedCompressImgBox = new System.Windows.Forms.CheckBox();
            this.losslessBox = new System.Windows.Forms.CheckBox();
            this.compressCoverBox = new System.Windows.Forms.CheckBox();
            this.compressLogText = new System.Windows.Forms.Label();
            this.showLogBtn = new System.Windows.Forms.Button();
            this.compressSuccessText = new System.Windows.Forms.Label();
            this.compressFailedText = new System.Windows.Forms.Label();
            this.compressSuccessValue = new System.Windows.Forms.Label();
            this.compressFailedValue = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.excludeImgFolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.excludeImgBrowserDialog = new System.Windows.Forms.OpenFileDialog();
            this.clearExcludeImgListStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.clearExcludeImgListBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.filterBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgSizeValueBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.compressibilityTrack)).BeginInit();
            this.outputBox.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.clearExcludeImgListStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // filterBox
            // 
            this.filterBox.Controls.Add(this.sizeFilterBox);
            this.filterBox.Controls.Add(this.delImgMatchBtn);
            this.filterBox.Controls.Add(this.delExcludePathBtn);
            this.filterBox.Controls.Add(this.delImgTypeBtn);
            this.filterBox.Controls.Add(this.chooseExcludeFileBtn);
            this.filterBox.Controls.Add(this.chooseExcludeFolderBtn);
            this.filterBox.Controls.Add(this.excludeImgList);
            this.filterBox.Controls.Add(this.addImgMatchBtn);
            this.filterBox.Controls.Add(this.excludeImgText);
            this.filterBox.Controls.Add(this.addImgTypeBtn);
            this.filterBox.Controls.Add(this.imgNameMatchText);
            this.filterBox.Controls.Add(this.imgTypeSelector);
            this.filterBox.Controls.Add(this.imgTypeBox);
            this.filterBox.Controls.Add(this.imgNameMatchList);
            this.filterBox.Controls.Add(this.imgSizeTipText);
            this.filterBox.Controls.Add(this.imgSizeUnitBox);
            this.filterBox.Controls.Add(this.imgSizeValueBox);
            this.filterBox.Controls.Add(this.imgTypeLabel);
            this.filterBox.Controls.Add(this.imgSizeLabel);
            this.filterBox.Location = new System.Drawing.Point(5, 33);
            this.filterBox.Name = "filterBox";
            this.filterBox.Size = new System.Drawing.Size(399, 281);
            this.filterBox.TabIndex = 0;
            this.filterBox.TabStop = false;
            this.filterBox.Text = "过滤设置";
            // 
            // sizeFilterBox
            // 
            this.sizeFilterBox.AutoSize = true;
            this.sizeFilterBox.Location = new System.Drawing.Point(295, 56);
            this.sizeFilterBox.Name = "sizeFilterBox";
            this.sizeFilterBox.Size = new System.Drawing.Size(96, 16);
            this.sizeFilterBox.TabIndex = 28;
            this.sizeFilterBox.Text = "图片体积过滤";
            this.sizeFilterBox.UseVisualStyleBackColor = true;
            this.sizeFilterBox.CheckedChanged += new System.EventHandler(this.SizeFilterBox_CheckedChanged);
            // 
            // delImgMatchBtn
            // 
            this.delImgMatchBtn.Location = new System.Drawing.Point(123, 246);
            this.delImgMatchBtn.Name = "delImgMatchBtn";
            this.delImgMatchBtn.Size = new System.Drawing.Size(67, 23);
            this.delImgMatchBtn.TabIndex = 26;
            this.delImgMatchBtn.Text = "删除";
            this.delImgMatchBtn.UseVisualStyleBackColor = true;
            this.delImgMatchBtn.Click += new System.EventHandler(this.DelImgMatchBtn_Click);
            // 
            // delExcludePathBtn
            // 
            this.delExcludePathBtn.Location = new System.Drawing.Point(339, 246);
            this.delExcludePathBtn.Name = "delExcludePathBtn";
            this.delExcludePathBtn.Size = new System.Drawing.Size(47, 23);
            this.delExcludePathBtn.TabIndex = 25;
            this.delExcludePathBtn.Text = "删除";
            this.delExcludePathBtn.UseVisualStyleBackColor = true;
            this.delExcludePathBtn.Click += new System.EventHandler(this.DelExcludePathBtn_Click);
            this.delExcludePathBtn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DelExcludePathBtn_MouseDown);
            // 
            // delImgTypeBtn
            // 
            this.delImgTypeBtn.Location = new System.Drawing.Point(334, 20);
            this.delImgTypeBtn.Name = "delImgTypeBtn";
            this.delImgTypeBtn.Size = new System.Drawing.Size(57, 23);
            this.delImgTypeBtn.TabIndex = 24;
            this.delImgTypeBtn.Text = "删除";
            this.delImgTypeBtn.UseVisualStyleBackColor = true;
            this.delImgTypeBtn.Click += new System.EventHandler(this.DelImgTypeBtn_Click);
            // 
            // chooseExcludeFileBtn
            // 
            this.chooseExcludeFileBtn.Location = new System.Drawing.Point(283, 246);
            this.chooseExcludeFileBtn.Name = "chooseExcludeFileBtn";
            this.chooseExcludeFileBtn.Size = new System.Drawing.Size(50, 23);
            this.chooseExcludeFileBtn.TabIndex = 23;
            this.chooseExcludeFileBtn.Text = "文件";
            this.chooseExcludeFileBtn.UseVisualStyleBackColor = true;
            this.chooseExcludeFileBtn.Click += new System.EventHandler(this.ChooseExcludeFileBtn_Click);
            // 
            // chooseExcludeFolderBtn
            // 
            this.chooseExcludeFolderBtn.Location = new System.Drawing.Point(207, 246);
            this.chooseExcludeFolderBtn.Name = "chooseExcludeFolderBtn";
            this.chooseExcludeFolderBtn.Size = new System.Drawing.Size(70, 23);
            this.chooseExcludeFolderBtn.TabIndex = 22;
            this.chooseExcludeFolderBtn.Text = "文件夹";
            this.chooseExcludeFolderBtn.UseVisualStyleBackColor = true;
            this.chooseExcludeFolderBtn.Click += new System.EventHandler(this.ChooseExcludeFolderBtn_Click);
            // 
            // excludeImgList
            // 
            this.excludeImgList.FormattingEnabled = true;
            this.excludeImgList.HorizontalScrollbar = true;
            this.excludeImgList.ItemHeight = 12;
            this.excludeImgList.Location = new System.Drawing.Point(207, 102);
            this.excludeImgList.Name = "excludeImgList";
            this.excludeImgList.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.excludeImgList.Size = new System.Drawing.Size(179, 136);
            this.excludeImgList.TabIndex = 21;
            // 
            // addImgMatchBtn
            // 
            this.addImgMatchBtn.Location = new System.Drawing.Point(11, 246);
            this.addImgMatchBtn.Name = "addImgMatchBtn";
            this.addImgMatchBtn.Size = new System.Drawing.Size(106, 23);
            this.addImgMatchBtn.TabIndex = 19;
            this.addImgMatchBtn.Text = "添加正则表达式";
            this.addImgMatchBtn.UseVisualStyleBackColor = true;
            this.addImgMatchBtn.Click += new System.EventHandler(this.AddImgMatchBtn_Click);
            // 
            // excludeImgText
            // 
            this.excludeImgText.AutoSize = true;
            this.excludeImgText.Location = new System.Drawing.Point(205, 83);
            this.excludeImgText.Name = "excludeImgText";
            this.excludeImgText.Size = new System.Drawing.Size(65, 12);
            this.excludeImgText.TabIndex = 16;
            this.excludeImgText.Text = "排除图片：";
            // 
            // addImgTypeBtn
            // 
            this.addImgTypeBtn.Location = new System.Drawing.Point(271, 20);
            this.addImgTypeBtn.Name = "addImgTypeBtn";
            this.addImgTypeBtn.Size = new System.Drawing.Size(57, 23);
            this.addImgTypeBtn.TabIndex = 14;
            this.addImgTypeBtn.Text = "添加";
            this.addImgTypeBtn.UseVisualStyleBackColor = true;
            this.addImgTypeBtn.Click += new System.EventHandler(this.AddImgTypeBtn_Click);
            // 
            // imgNameMatchText
            // 
            this.imgNameMatchText.AutoSize = true;
            this.imgNameMatchText.Location = new System.Drawing.Point(10, 83);
            this.imgNameMatchText.Name = "imgNameMatchText";
            this.imgNameMatchText.Size = new System.Drawing.Size(89, 12);
            this.imgNameMatchText.TabIndex = 15;
            this.imgNameMatchText.Text = "图片名称匹配：";
            // 
            // imgTypeSelector
            // 
            this.imgTypeSelector.FormattingEnabled = true;
            this.imgTypeSelector.Items.AddRange(new object[] {
            "jpg",
            "png",
            "gif"});
            this.imgTypeSelector.Location = new System.Drawing.Point(222, 21);
            this.imgTypeSelector.Name = "imgTypeSelector";
            this.imgTypeSelector.Size = new System.Drawing.Size(43, 20);
            this.imgTypeSelector.TabIndex = 13;
            this.imgTypeSelector.Text = "jpg";
            this.imgTypeSelector.SelectedIndexChanged += new System.EventHandler(this.ImgTypeSelector_SelectedIndexChanged);
            // 
            // imgTypeBox
            // 
            this.imgTypeBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.imgTypeBox.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.imgTypeBox.ForeColor = System.Drawing.Color.Black;
            this.imgTypeBox.Location = new System.Drawing.Point(80, 20);
            this.imgTypeBox.MaxLength = 300;
            this.imgTypeBox.Name = "imgTypeBox";
            this.imgTypeBox.ReadOnly = true;
            this.imgTypeBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.imgTypeBox.Size = new System.Drawing.Size(136, 23);
            this.imgTypeBox.TabIndex = 12;
            this.imgTypeBox.Text = "jpg png";
            // 
            // imgNameMatchList
            // 
            this.imgNameMatchList.FormattingEnabled = true;
            this.imgNameMatchList.ItemHeight = 12;
            this.imgNameMatchList.Location = new System.Drawing.Point(11, 102);
            this.imgNameMatchList.Name = "imgNameMatchList";
            this.imgNameMatchList.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.imgNameMatchList.Size = new System.Drawing.Size(179, 136);
            this.imgNameMatchList.TabIndex = 17;
            // 
            // imgSizeTipText
            // 
            this.imgSizeTipText.AutoSize = true;
            this.imgSizeTipText.Location = new System.Drawing.Point(78, 57);
            this.imgSizeTipText.Name = "imgSizeTipText";
            this.imgSizeTipText.Size = new System.Drawing.Size(65, 12);
            this.imgSizeTipText.TabIndex = 5;
            this.imgSizeTipText.Text = "大于或等于";
            // 
            // imgSizeUnitBox
            // 
            this.imgSizeUnitBox.Enabled = false;
            this.imgSizeUnitBox.FormattingEnabled = true;
            this.imgSizeUnitBox.Items.AddRange(new object[] {
            "B",
            "KB",
            "MB",
            "GB"});
            this.imgSizeUnitBox.Location = new System.Drawing.Point(225, 52);
            this.imgSizeUnitBox.Name = "imgSizeUnitBox";
            this.imgSizeUnitBox.Size = new System.Drawing.Size(40, 20);
            this.imgSizeUnitBox.TabIndex = 4;
            this.imgSizeUnitBox.Text = "KB";
            this.imgSizeUnitBox.SelectedIndexChanged += new System.EventHandler(this.ImgSizeUnitBox_SelectedIndexChanged);
            // 
            // imgSizeValueBox
            // 
            this.imgSizeValueBox.Enabled = false;
            this.imgSizeValueBox.Location = new System.Drawing.Point(152, 52);
            this.imgSizeValueBox.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.imgSizeValueBox.Name = "imgSizeValueBox";
            this.imgSizeValueBox.Size = new System.Drawing.Size(67, 21);
            this.imgSizeValueBox.TabIndex = 2;
            this.imgSizeValueBox.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.imgSizeValueBox.ValueChanged += new System.EventHandler(this.ImgSizeValueBox_ValueChanged);
            // 
            // imgTypeLabel
            // 
            this.imgTypeLabel.AutoSize = true;
            this.imgTypeLabel.Location = new System.Drawing.Point(9, 28);
            this.imgTypeLabel.Name = "imgTypeLabel";
            this.imgTypeLabel.Size = new System.Drawing.Size(65, 12);
            this.imgTypeLabel.TabIndex = 1;
            this.imgTypeLabel.Text = "图片类型：";
            // 
            // imgSizeLabel
            // 
            this.imgSizeLabel.AutoSize = true;
            this.imgSizeLabel.Location = new System.Drawing.Point(9, 57);
            this.imgSizeLabel.Name = "imgSizeLabel";
            this.imgSizeLabel.Size = new System.Drawing.Size(65, 12);
            this.imgSizeLabel.TabIndex = 0;
            this.imgSizeLabel.Text = "图片大小：";
            // 
            // watchChildFolderBox
            // 
            this.watchChildFolderBox.AutoSize = true;
            this.watchChildFolderBox.Location = new System.Drawing.Point(313, 470);
            this.watchChildFolderBox.Name = "watchChildFolderBox";
            this.watchChildFolderBox.Size = new System.Drawing.Size(96, 16);
            this.watchChildFolderBox.TabIndex = 27;
            this.watchChildFolderBox.Text = "监听子文件夹";
            this.watchChildFolderBox.UseVisualStyleBackColor = true;
            this.watchChildFolderBox.CheckedChanged += new System.EventHandler(this.WatchChildFolderBox_CheckedChanged);
            // 
            // runCompresserBtn
            // 
            this.runCompresserBtn.Location = new System.Drawing.Point(269, 492);
            this.runCompresserBtn.Name = "runCompresserBtn";
            this.runCompresserBtn.Size = new System.Drawing.Size(140, 35);
            this.runCompresserBtn.TabIndex = 1;
            this.runCompresserBtn.Text = "启动压缩器";
            this.runCompresserBtn.UseVisualStyleBackColor = true;
            this.runCompresserBtn.Click += new System.EventHandler(this.RunCompresserBtn_Click);
            // 
            // compressibilityLabel
            // 
            this.compressibilityLabel.AutoSize = true;
            this.compressibilityLabel.Location = new System.Drawing.Point(10, 28);
            this.compressibilityLabel.Name = "compressibilityLabel";
            this.compressibilityLabel.Size = new System.Drawing.Size(53, 12);
            this.compressibilityLabel.TabIndex = 2;
            this.compressibilityLabel.Text = "压缩率：";
            // 
            // compressibilityTrack
            // 
            this.compressibilityTrack.Location = new System.Drawing.Point(69, 19);
            this.compressibilityTrack.Maximum = 100;
            this.compressibilityTrack.Name = "compressibilityTrack";
            this.compressibilityTrack.Size = new System.Drawing.Size(210, 45);
            this.compressibilityTrack.TabIndex = 3;
            this.compressibilityTrack.Value = 50;
            this.compressibilityTrack.ValueChanged += new System.EventHandler(this.CompressibilityTrack_ValueChanged);
            this.compressibilityTrack.MouseUp += new System.Windows.Forms.MouseEventHandler(this.CompressibilityTrack_MouseUp);
            // 
            // compressibilityValueLabel
            // 
            this.compressibilityValueLabel.Location = new System.Drawing.Point(283, 23);
            this.compressibilityValueLabel.Name = "compressibilityValueLabel";
            this.compressibilityValueLabel.Size = new System.Drawing.Size(29, 23);
            this.compressibilityValueLabel.TabIndex = 4;
            this.compressibilityValueLabel.Text = "50%";
            this.compressibilityValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // sourceFolderLabel
            // 
            this.sourceFolderLabel.AutoSize = true;
            this.sourceFolderLabel.Location = new System.Drawing.Point(3, 9);
            this.sourceFolderLabel.Name = "sourceFolderLabel";
            this.sourceFolderLabel.Size = new System.Drawing.Size(77, 12);
            this.sourceFolderLabel.TabIndex = 5;
            this.sourceFolderLabel.Text = "监视文件夹：";
            // 
            // outputFolderLabel
            // 
            this.outputFolderLabel.AutoSize = true;
            this.outputFolderLabel.Location = new System.Drawing.Point(3, 9);
            this.outputFolderLabel.Name = "outputFolderLabel";
            this.outputFolderLabel.Size = new System.Drawing.Size(77, 12);
            this.outputFolderLabel.TabIndex = 6;
            this.outputFolderLabel.Text = "输出文件夹：";
            // 
            // sourceFolderPathBox
            // 
            this.sourceFolderPathBox.Location = new System.Drawing.Point(86, 6);
            this.sourceFolderPathBox.Name = "sourceFolderPathBox";
            this.sourceFolderPathBox.Size = new System.Drawing.Size(237, 21);
            this.sourceFolderPathBox.TabIndex = 7;
            this.sourceFolderPathBox.TextChanged += new System.EventHandler(this.SourceFolderPathBox_TextChanged);
            // 
            // outputFolderPathBox
            // 
            this.outputFolderPathBox.Location = new System.Drawing.Point(86, 6);
            this.outputFolderPathBox.Name = "outputFolderPathBox";
            this.outputFolderPathBox.Size = new System.Drawing.Size(237, 21);
            this.outputFolderPathBox.TabIndex = 8;
            this.outputFolderPathBox.TextChanged += new System.EventHandler(this.OutputFolderPathBox_TextChanged);
            // 
            // openSourceFolderBtn
            // 
            this.openSourceFolderBtn.Location = new System.Drawing.Point(329, 6);
            this.openSourceFolderBtn.Name = "openSourceFolderBtn";
            this.openSourceFolderBtn.Size = new System.Drawing.Size(75, 21);
            this.openSourceFolderBtn.TabIndex = 9;
            this.openSourceFolderBtn.Text = "浏览...";
            this.openSourceFolderBtn.UseVisualStyleBackColor = true;
            this.openSourceFolderBtn.Click += new System.EventHandler(this.OpenSourceFolderBtn_Click);
            // 
            // openOutputFolderBtn
            // 
            this.openOutputFolderBtn.Location = new System.Drawing.Point(329, 6);
            this.openOutputFolderBtn.Name = "openOutputFolderBtn";
            this.openOutputFolderBtn.Size = new System.Drawing.Size(75, 21);
            this.openOutputFolderBtn.TabIndex = 10;
            this.openOutputFolderBtn.Text = "浏览...";
            this.openOutputFolderBtn.UseVisualStyleBackColor = true;
            this.openOutputFolderBtn.Click += new System.EventHandler(this.OpenOutputFolderBtn_Click);
            // 
            // outputBox
            // 
            this.outputBox.Controls.Add(this.startedCompressImgBox);
            this.outputBox.Controls.Add(this.losslessBox);
            this.outputBox.Controls.Add(this.compressibilityLabel);
            this.outputBox.Controls.Add(this.compressCoverBox);
            this.outputBox.Controls.Add(this.compressibilityTrack);
            this.outputBox.Controls.Add(this.compressibilityValueLabel);
            this.outputBox.Location = new System.Drawing.Point(5, 33);
            this.outputBox.Name = "outputBox";
            this.outputBox.Size = new System.Drawing.Size(399, 106);
            this.outputBox.TabIndex = 11;
            this.outputBox.TabStop = false;
            this.outputBox.Text = "输出设置";
            // 
            // startedCompressImgBox
            // 
            this.startedCompressImgBox.AutoSize = true;
            this.startedCompressImgBox.Location = new System.Drawing.Point(11, 81);
            this.startedCompressImgBox.Name = "startedCompressImgBox";
            this.startedCompressImgBox.Size = new System.Drawing.Size(192, 16);
            this.startedCompressImgBox.TabIndex = 15;
            this.startedCompressImgBox.Text = "启动后先压缩文件夹内所有图片";
            this.startedCompressImgBox.UseVisualStyleBackColor = true;
            this.startedCompressImgBox.CheckedChanged += new System.EventHandler(this.StartedCompressImgBox_CheckedChanged);
            // 
            // losslessBox
            // 
            this.losslessBox.AutoSize = true;
            this.losslessBox.Location = new System.Drawing.Point(319, 27);
            this.losslessBox.Name = "losslessBox";
            this.losslessBox.Size = new System.Drawing.Size(72, 16);
            this.losslessBox.TabIndex = 22;
            this.losslessBox.Text = "无损压缩";
            this.losslessBox.UseVisualStyleBackColor = true;
            this.losslessBox.CheckedChanged += new System.EventHandler(this.LosslessBox_CheckedChanged);
            // 
            // compressCoverBox
            // 
            this.compressCoverBox.AutoSize = true;
            this.compressCoverBox.Location = new System.Drawing.Point(11, 59);
            this.compressCoverBox.Name = "compressCoverBox";
            this.compressCoverBox.Size = new System.Drawing.Size(132, 16);
            this.compressCoverBox.TabIndex = 24;
            this.compressCoverBox.Text = "压缩图片覆盖原图片";
            this.compressCoverBox.UseVisualStyleBackColor = true;
            this.compressCoverBox.CheckedChanged += new System.EventHandler(this.CompressCoverBox_CheckedChanged);
            // 
            // compressLogText
            // 
            this.compressLogText.AutoSize = true;
            this.compressLogText.Location = new System.Drawing.Point(12, 470);
            this.compressLogText.Name = "compressLogText";
            this.compressLogText.Size = new System.Drawing.Size(65, 12);
            this.compressLogText.TabIndex = 16;
            this.compressLogText.Text = "压缩报告：";
            // 
            // showLogBtn
            // 
            this.showLogBtn.Location = new System.Drawing.Point(10, 492);
            this.showLogBtn.Name = "showLogBtn";
            this.showLogBtn.Size = new System.Drawing.Size(140, 35);
            this.showLogBtn.TabIndex = 17;
            this.showLogBtn.Text = "帮助与日志";
            this.showLogBtn.UseVisualStyleBackColor = true;
            this.showLogBtn.Click += new System.EventHandler(this.ShowLogBtn_Click);
            // 
            // compressSuccessText
            // 
            this.compressSuccessText.AutoSize = true;
            this.compressSuccessText.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.compressSuccessText.ForeColor = System.Drawing.Color.Green;
            this.compressSuccessText.Location = new System.Drawing.Point(72, 466);
            this.compressSuccessText.Name = "compressSuccessText";
            this.compressSuccessText.Size = new System.Drawing.Size(51, 19);
            this.compressSuccessText.TabIndex = 18;
            this.compressSuccessText.Text = "成功：";
            // 
            // compressFailedText
            // 
            this.compressFailedText.AutoSize = true;
            this.compressFailedText.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.compressFailedText.ForeColor = System.Drawing.Color.Red;
            this.compressFailedText.Location = new System.Drawing.Point(156, 466);
            this.compressFailedText.Name = "compressFailedText";
            this.compressFailedText.Size = new System.Drawing.Size(51, 19);
            this.compressFailedText.TabIndex = 19;
            this.compressFailedText.Text = "失败：";
            // 
            // compressSuccessValue
            // 
            this.compressSuccessValue.AutoSize = true;
            this.compressSuccessValue.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.compressSuccessValue.ForeColor = System.Drawing.Color.Green;
            this.compressSuccessValue.Location = new System.Drawing.Point(108, 467);
            this.compressSuccessValue.Name = "compressSuccessValue";
            this.compressSuccessValue.Size = new System.Drawing.Size(18, 19);
            this.compressSuccessValue.TabIndex = 20;
            this.compressSuccessValue.Text = "0";
            // 
            // compressFailedValue
            // 
            this.compressFailedValue.AutoSize = true;
            this.compressFailedValue.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.compressFailedValue.ForeColor = System.Drawing.Color.Red;
            this.compressFailedValue.Location = new System.Drawing.Point(192, 467);
            this.compressFailedValue.Name = "compressFailedValue";
            this.compressFailedValue.Size = new System.Drawing.Size(18, 19);
            this.compressFailedValue.TabIndex = 21;
            this.compressFailedValue.Text = "0";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.outputFolderPathBox);
            this.panel3.Controls.Add(this.outputFolderLabel);
            this.panel3.Controls.Add(this.openOutputFolderBtn);
            this.panel3.Controls.Add(this.outputBox);
            this.panel3.Location = new System.Drawing.Point(5, 321);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(408, 140);
            this.panel3.TabIndex = 22;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.filterBox);
            this.panel4.Controls.Add(this.sourceFolderLabel);
            this.panel4.Controls.Add(this.sourceFolderPathBox);
            this.panel4.Controls.Add(this.openSourceFolderBtn);
            this.panel4.Location = new System.Drawing.Point(5, 4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(408, 317);
            this.panel4.TabIndex = 23;
            // 
            // excludeImgBrowserDialog
            // 
            this.excludeImgBrowserDialog.FileName = "Image";
            this.excludeImgBrowserDialog.Multiselect = true;
            // 
            // clearExcludeImgListStrip
            // 
            this.clearExcludeImgListStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearExcludeImgListBtn});
            this.clearExcludeImgListStrip.Name = "clearExcludeImgListStrip";
            this.clearExcludeImgListStrip.Size = new System.Drawing.Size(149, 26);
            this.clearExcludeImgListStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.ClearExcludeImgListStrip_ItemClicked);
            // 
            // clearExcludeImgListBtn
            // 
            this.clearExcludeImgListBtn.Name = "clearExcludeImgListBtn";
            this.clearExcludeImgListBtn.Size = new System.Drawing.Size(148, 22);
            this.clearExcludeImgListBtn.Text = "清空排除列表";
            // 
            // HomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 536);
            this.Controls.Add(this.watchChildFolderBox);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.compressFailedValue);
            this.Controls.Add(this.compressSuccessValue);
            this.Controls.Add(this.compressFailedText);
            this.Controls.Add(this.compressSuccessText);
            this.Controls.Add(this.showLogBtn);
            this.Controls.Add(this.compressLogText);
            this.Controls.Add(this.runCompresserBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(435, 575);
            this.MinimumSize = new System.Drawing.Size(435, 575);
            this.Name = "HomeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "图片被动压缩器";
            this.Load += new System.EventHandler(this.HomeForm_Load);
            this.filterBox.ResumeLayout(false);
            this.filterBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgSizeValueBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.compressibilityTrack)).EndInit();
            this.outputBox.ResumeLayout(false);
            this.outputBox.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.clearExcludeImgListStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox filterBox;
        private System.Windows.Forms.Button runCompresserBtn;
        private System.Windows.Forms.Label compressibilityLabel;
        private System.Windows.Forms.TrackBar compressibilityTrack;
        private System.Windows.Forms.Label compressibilityValueLabel;
        private System.Windows.Forms.Label sourceFolderLabel;
        private System.Windows.Forms.Label outputFolderLabel;
        private System.Windows.Forms.TextBox sourceFolderPathBox;
        private System.Windows.Forms.FolderBrowserDialog sourceFolderBrowserDialog;
        private System.Windows.Forms.FolderBrowserDialog outputFolderBrowserDialog;
        private System.Windows.Forms.TextBox outputFolderPathBox;
        private System.Windows.Forms.Button openSourceFolderBtn;
        private System.Windows.Forms.Button openOutputFolderBtn;
        private System.Windows.Forms.GroupBox outputBox;
        private System.Windows.Forms.Label imgSizeLabel;
        private System.Windows.Forms.ComboBox imgSizeUnitBox;
        private System.Windows.Forms.NumericUpDown imgSizeValueBox;
        private System.Windows.Forms.Label imgTypeLabel;
        private System.Windows.Forms.TextBox imgTypeBox;
        private System.Windows.Forms.Label imgSizeTipText;
        private System.Windows.Forms.Button addImgTypeBtn;
        private System.Windows.Forms.ComboBox imgTypeSelector;
        private System.Windows.Forms.Label compressFailedValue;
        private System.Windows.Forms.Label compressSuccessValue;
        private System.Windows.Forms.Label compressFailedText;
        private System.Windows.Forms.Label compressSuccessText;
        private System.Windows.Forms.Button showLogBtn;
        private System.Windows.Forms.Label compressLogText;
        private System.Windows.Forms.CheckBox startedCompressImgBox;
        private System.Windows.Forms.ListBox imgNameMatchList;
        private System.Windows.Forms.Label excludeImgText;
        private System.Windows.Forms.Label imgNameMatchText;
        private System.Windows.Forms.Button addImgMatchBtn;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ListBox excludeImgList;
        private System.Windows.Forms.Button chooseExcludeFileBtn;
        private System.Windows.Forms.Button chooseExcludeFolderBtn;
        private System.Windows.Forms.CheckBox compressCoverBox;
        private System.Windows.Forms.Button delImgTypeBtn;
        private System.Windows.Forms.FolderBrowserDialog excludeImgFolderBrowserDialog;
        private System.Windows.Forms.OpenFileDialog excludeImgBrowserDialog;
        private System.Windows.Forms.Button delExcludePathBtn;
        private System.Windows.Forms.Button delImgMatchBtn;
        private System.Windows.Forms.ContextMenuStrip clearExcludeImgListStrip;
        private System.Windows.Forms.ToolStripMenuItem clearExcludeImgListBtn;
        private System.Windows.Forms.CheckBox losslessBox;
        private System.Windows.Forms.CheckBox watchChildFolderBox;
        private System.Windows.Forms.CheckBox sizeFilterBox;
    }
}

