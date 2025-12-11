namespace BuyiFFmpegUI
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            txtSourceDir = new TextBox();
            label2 = new Label();
            txtSearch = new TextBox();
            pnInput = new Panel();
            ListSearchs = new ComboBox();
            label4 = new Label();
            txtOutputDir = new TextBox();
            label3 = new Label();
            pnTemplate = new Panel();
            txtParams = new TextBox();
            pnTemplateUp = new Panel();
            BtnDownloadFFmpeg = new Button();
            ListTemplates = new ComboBox();
            BtnOpenDir = new Button();
            BtnSaveTemplate = new Button();
            label5 = new Label();
            txtFormat = new TextBox();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            txtTaskNum = new NumericUpDown();
            BtnStart = new Button();
            checkEndPause = new CheckBox();
            BtnOpenLastDest = new Button();
            BtnKillCmd = new Button();
            checkUseWt = new CheckBox();
            pnInput.SuspendLayout();
            pnTemplate.SuspendLayout();
            pnTemplateUp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txtTaskNum).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(95, 21);
            label1.TabIndex = 0;
            label1.Text = "源 文件夹：";
            // 
            // txtSourceDir
            // 
            txtSourceDir.Location = new Point(118, 9);
            txtSourceDir.Name = "txtSourceDir";
            txtSourceDir.Size = new Size(838, 28);
            txtSourceDir.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 55);
            label2.Name = "label2";
            label2.Size = new Size(58, 21);
            label2.TabIndex = 2;
            label2.Text = "搜索：";
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(92, 55);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(512, 28);
            txtSearch.TabIndex = 3;
            txtSearch.Text = "*";
            // 
            // pnInput
            // 
            pnInput.BorderStyle = BorderStyle.FixedSingle;
            pnInput.Controls.Add(ListSearchs);
            pnInput.Controls.Add(label4);
            pnInput.Controls.Add(txtOutputDir);
            pnInput.Controls.Add(label3);
            pnInput.Controls.Add(label2);
            pnInput.Controls.Add(txtSearch);
            pnInput.Controls.Add(label1);
            pnInput.Controls.Add(txtSourceDir);
            pnInput.Dock = DockStyle.Top;
            pnInput.Location = new Point(0, 0);
            pnInput.Name = "pnInput";
            pnInput.Size = new Size(979, 204);
            pnInput.TabIndex = 4;
            // 
            // ListSearchs
            // 
            ListSearchs.DropDownStyle = ComboBoxStyle.DropDownList;
            ListSearchs.FormattingEnabled = true;
            ListSearchs.Items.AddRange(new object[] { "*", "*.jpg|*.png|*.bmp|*.jpeg|*.gif|*.webp|*.tif|*.raw|*.heif", "*.mp4|*.avi|*.mkv|*.mov|*.webm|*.wmv|*.m4v", "*.mp3|*.ogg|*.wav|*.m4a|*.flac|*.aac|*.aiff|*.opus" });
            ListSearchs.Location = new Point(639, 52);
            ListSearchs.Name = "ListSearchs";
            ListSearchs.Size = new Size(191, 29);
            ListSearchs.TabIndex = 9;
            ListSearchs.SelectedIndexChanged += ListSearchs_SelectedIndexChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft YaHei UI", 10F);
            label4.Location = new Point(12, 129);
            label4.Name = "label4";
            label4.Size = new Size(539, 60);
            label4.TabIndex = 6;
            label4.Text = "从源文件夹里搜索匹配名字的文件（包括子文件夹里的那些），搜索多种匹配用 | 分隔\r\n然后按源文件夹的结构进行输出到新文件夹里。\r\n输出文件夹如果是 * 则会自动生成文件夹 ffmpeg_xxx 在源文件夹旁边。";
            // 
            // txtOutputDir
            // 
            txtOutputDir.Location = new Point(130, 98);
            txtOutputDir.Name = "txtOutputDir";
            txtOutputDir.Size = new Size(826, 28);
            txtOutputDir.TabIndex = 5;
            txtOutputDir.Text = "*";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 104);
            label3.Name = "label3";
            label3.Size = new Size(106, 21);
            label3.TabIndex = 4;
            label3.Text = "输出文件夹：";
            // 
            // pnTemplate
            // 
            pnTemplate.BorderStyle = BorderStyle.FixedSingle;
            pnTemplate.Controls.Add(txtParams);
            pnTemplate.Controls.Add(pnTemplateUp);
            pnTemplate.Dock = DockStyle.Top;
            pnTemplate.Location = new Point(0, 204);
            pnTemplate.Name = "pnTemplate";
            pnTemplate.Size = new Size(979, 443);
            pnTemplate.TabIndex = 5;
            // 
            // txtParams
            // 
            txtParams.Dock = DockStyle.Fill;
            txtParams.Location = new Point(0, 114);
            txtParams.Multiline = true;
            txtParams.Name = "txtParams";
            txtParams.ScrollBars = ScrollBars.Both;
            txtParams.Size = new Size(977, 327);
            txtParams.TabIndex = 6;
            txtParams.WordWrap = false;
            // 
            // pnTemplateUp
            // 
            pnTemplateUp.Controls.Add(BtnDownloadFFmpeg);
            pnTemplateUp.Controls.Add(ListTemplates);
            pnTemplateUp.Controls.Add(BtnOpenDir);
            pnTemplateUp.Controls.Add(BtnSaveTemplate);
            pnTemplateUp.Controls.Add(label5);
            pnTemplateUp.Controls.Add(txtFormat);
            pnTemplateUp.Controls.Add(label6);
            pnTemplateUp.Controls.Add(label7);
            pnTemplateUp.Dock = DockStyle.Top;
            pnTemplateUp.Location = new Point(0, 0);
            pnTemplateUp.Name = "pnTemplateUp";
            pnTemplateUp.Size = new Size(977, 114);
            pnTemplateUp.TabIndex = 11;
            // 
            // BtnDownloadFFmpeg
            // 
            BtnDownloadFFmpeg.Location = new Point(546, 50);
            BtnDownloadFFmpeg.Name = "BtnDownloadFFmpeg";
            BtnDownloadFFmpeg.Size = new Size(139, 34);
            BtnDownloadFFmpeg.TabIndex = 11;
            BtnDownloadFFmpeg.Text = "FFmpeg官网";
            BtnDownloadFFmpeg.UseVisualStyleBackColor = true;
            BtnDownloadFFmpeg.Click += BtnDownloadFFmpeg_Click;
            // 
            // ListTemplates
            // 
            ListTemplates.DropDownStyle = ComboBoxStyle.DropDownList;
            ListTemplates.FormattingEnabled = true;
            ListTemplates.Location = new Point(76, 7);
            ListTemplates.Name = "ListTemplates";
            ListTemplates.Size = new Size(378, 29);
            ListTemplates.TabIndex = 8;
            ListTemplates.SelectedIndexChanged += ListTemplates_SelectedIndexChanged;
            // 
            // BtnOpenDir
            // 
            BtnOpenDir.Location = new Point(691, 10);
            BtnOpenDir.Name = "BtnOpenDir";
            BtnOpenDir.Size = new Size(139, 34);
            BtnOpenDir.TabIndex = 10;
            BtnOpenDir.Text = "打开软件目录";
            BtnOpenDir.UseVisualStyleBackColor = true;
            BtnOpenDir.Click += BtnOpenDir_Click;
            // 
            // BtnSaveTemplate
            // 
            BtnSaveTemplate.Location = new Point(546, 10);
            BtnSaveTemplate.Name = "BtnSaveTemplate";
            BtnSaveTemplate.Size = new Size(139, 34);
            BtnSaveTemplate.TabIndex = 9;
            BtnSaveTemplate.Text = "保存为新模板";
            BtnSaveTemplate.UseVisualStyleBackColor = true;
            BtnSaveTemplate.Click += BtnSaveTemplate_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 50);
            label5.Name = "label5";
            label5.Size = new Size(90, 21);
            label5.TabIndex = 0;
            label5.Text = "输出格式：";
            // 
            // txtFormat
            // 
            txtFormat.Location = new Point(113, 47);
            txtFormat.Name = "txtFormat";
            txtFormat.Size = new Size(274, 28);
            txtFormat.TabIndex = 4;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(12, 78);
            label6.Name = "label6";
            label6.Size = new Size(412, 21);
            label6.TabIndex = 5;
            label6.Text = "自定义参数，换行视为空格， #或//开头的行 视为注释：";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(12, 10);
            label7.Name = "label7";
            label7.Size = new Size(58, 21);
            label7.TabIndex = 7;
            label7.Text = "模板：";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(12, 657);
            label8.Name = "label8";
            label8.Size = new Size(146, 21);
            label8.TabIndex = 6;
            label8.Text = "同时执行x个任务：";
            // 
            // txtTaskNum
            // 
            txtTaskNum.Location = new Point(164, 655);
            txtTaskNum.Maximum = new decimal(new int[] { 64, 0, 0, 0 });
            txtTaskNum.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            txtTaskNum.Name = "txtTaskNum";
            txtTaskNum.Size = new Size(73, 28);
            txtTaskNum.TabIndex = 7;
            txtTaskNum.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // BtnStart
            // 
            BtnStart.Location = new Point(286, 655);
            BtnStart.Name = "BtnStart";
            BtnStart.Size = new Size(139, 34);
            BtnStart.TabIndex = 10;
            BtnStart.Text = "启动 ffmpeg";
            BtnStart.UseVisualStyleBackColor = true;
            BtnStart.Click += BtnStart_Click;
            // 
            // checkEndPause
            // 
            checkEndPause.AutoSize = true;
            checkEndPause.Location = new Point(13, 698);
            checkEndPause.Name = "checkEndPause";
            checkEndPause.Size = new Size(206, 25);
            checkEndPause.TabIndex = 11;
            checkEndPause.Text = "执行完成后保留cmd窗口";
            checkEndPause.UseVisualStyleBackColor = true;
            // 
            // BtnOpenLastDest
            // 
            BtnOpenLastDest.Enabled = false;
            BtnOpenLastDest.Location = new Point(446, 655);
            BtnOpenLastDest.Name = "BtnOpenLastDest";
            BtnOpenLastDest.Size = new Size(207, 34);
            BtnOpenLastDest.TabIndex = 12;
            BtnOpenLastDest.Text = "打开上一次输出文件夹";
            BtnOpenLastDest.UseVisualStyleBackColor = true;
            BtnOpenLastDest.Click += BtnOpenLastDest_Click;
            // 
            // BtnKillCmd
            // 
            BtnKillCmd.Enabled = false;
            BtnKillCmd.Location = new Point(286, 698);
            BtnKillCmd.Name = "BtnKillCmd";
            BtnKillCmd.Size = new Size(169, 34);
            BtnKillCmd.TabIndex = 13;
            BtnKillCmd.Text = "杀死进行中的cmd";
            BtnKillCmd.UseVisualStyleBackColor = true;
            BtnKillCmd.Click += BtnKillCmd_Click;
            // 
            // checkUseWt
            // 
            checkUseWt.AutoSize = true;
            checkUseWt.Checked = true;
            checkUseWt.CheckState = CheckState.Checked;
            checkUseWt.Location = new Point(12, 729);
            checkUseWt.Name = "checkUseWt";
            checkUseWt.Size = new Size(276, 25);
            checkUseWt.TabIndex = 14;
            checkUseWt.Text = "使用 Windows Terminal 多标签页";
            checkUseWt.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(979, 767);
            Controls.Add(checkUseWt);
            Controls.Add(BtnKillCmd);
            Controls.Add(BtnOpenLastDest);
            Controls.Add(checkEndPause);
            Controls.Add(BtnStart);
            Controls.Add(txtTaskNum);
            Controls.Add(label8);
            Controls.Add(pnTemplate);
            Controls.Add(pnInput);
            Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Buyi FFmpeg UI 2025.10.23";
            Load += MainForm_Load;
            pnInput.ResumeLayout(false);
            pnInput.PerformLayout();
            pnTemplate.ResumeLayout(false);
            pnTemplate.PerformLayout();
            pnTemplateUp.ResumeLayout(false);
            pnTemplateUp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)txtTaskNum).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtSourceDir;
        private Label label2;
        private TextBox txtSearch;
        private Panel pnInput;
        private Label label3;
        private TextBox txtOutputDir;
        private Label label4;
        private Panel pnTemplate;
        private Label label5;
        private TextBox txtFormat;
        private Label label6;
        private TextBox txtParams;
        private Label label7;
        private ComboBox ListTemplates;
        private Button BtnSaveTemplate;
        private Button BtnOpenDir;
        private Label label8;
        private NumericUpDown txtTaskNum;
        private Button BtnStart;
        private Panel pnTemplateUp;
        private CheckBox checkEndPause;
        private Button BtnDownloadFFmpeg;
        private Button BtnOpenLastDest;
        private ComboBox ListSearchs;
        private Button BtnKillCmd;
        private CheckBox checkUseWt;
    }
}
