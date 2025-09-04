using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace BuyiFFmpegUI
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private readonly DirectoryInfo dirTemplates = Directory.CreateDirectory(Path.Combine(AppContext.BaseDirectory, "templates"));
        private readonly DirectoryInfo dirScripts = Directory.CreateDirectory(Path.Combine(AppContext.BaseDirectory, "scripts"));

        private void MainForm_Load(object sender, EventArgs e)
        {
            Environment.CurrentDirectory = AppContext.BaseDirectory;

            var fontMono = new Font("Consolas", 11);
            txtOutputDir.Font = fontMono;
            txtSourceDir.Font = fontMono;
            txtSearch.Font = fontMono;
            txtFormat.Font = fontMono;
            txtParams.Font = fontMono;
            txtTaskNum.Font = fontMono;

            Utils.RegisterTextboxDropFilePath(txtOutputDir, txtSourceDir);
            LoadTemplates();
            CleanOldScriptFiles();
        }

        private void BtnOpenDir_Click(object sender, EventArgs e)
        {
            Utils.OpenExplorer(AppContext.BaseDirectory);
        }

        private void BtnDownloadFFmpeg_Click(object sender, EventArgs e)
        {
            Utils.OpenExplorer("https://ffmpeg.org/");
        }

        private void LoadTemplates()
        {
            ListTemplates.BeginUpdate();
            ListTemplates.Items.Clear();
            foreach (var i in dirTemplates.EnumerateFiles("*.txt"))
            {
                var text = File.ReadAllText(i.FullName);
                if (string.IsNullOrWhiteSpace(text)) { continue; }
                var lines = text.Trim().ReplaceLineEndings("\n").Split('\r', '\n');
                if (lines.Length < 1) { continue; }
                var format = lines[0];
                var paramsText = string.Join("\r\n", lines.Skip(1));
                var t = new TemplateInfo();
                t.Format = format;
                t.Params = paramsText;
                t.Name = Path.ChangeExtension(i.Name, null);
                ListTemplates.Items.Add(t);
            }
            ListTemplates.EndUpdate();
        }

        private void BtnSaveTemplate_Click(object sender, EventArgs e)
        {
            try
            {
                var t = new TemplateInfo();
                t.Format = txtFormat.Text.Trim();
                if (string.IsNullOrWhiteSpace(t.Format)) { throw new Exception("保存的格式名不能是空白"); }
                t.Params = txtParams.Text.Trim();
                var name = Utils.VBInputBox($"请输入这个模板的名字，如果和原有的同名会直接覆盖  ({t.Format})").Trim();
                if (string.IsNullOrEmpty(name)) { throw new Exception("没有输入文件名"); }
                var path = Path.Combine(dirTemplates.FullName, $"{name}.txt");
                var text = $"{t.Format}\r\n{t.Params}";
                File.WriteAllText(path, text);
                t.Name = name;
                foreach (var obj in ListTemplates.Items)
                {
                    if (obj is TemplateInfo i && i.Name.Equals(name, StringComparison.CurrentCultureIgnoreCase))
                    {
                        ListTemplates.Items.Remove(obj);
                        break;
                    }
                }
                ListTemplates.Items.Add(t);
                ListTemplates.SelectedItem = t;
                Utils.ShowInfoMessageBox($"模板保存成功： \n{path}");
            }
            catch (Exception ex)
            {
                Utils.ShowErrorMessageBox($"保存模板失败：\n{ex.Message}");
            }
        }

        private void ListTemplates_SelectedIndexChanged(object sender, EventArgs e)
        {
            var obj = ListTemplates.SelectedItem;
            if (obj == null || obj is not TemplateInfo template) { return; }
            txtFormat.Text = template.Format;
            txtParams.Text = template.Params;
        }

        private string ParseParamsText()
        {
            var lines = txtParams.Lines;
            var sb = new StringBuilder();
            foreach (var line in lines)
            {
                sb.Append(' ');
                if (string.IsNullOrEmpty(line)) { continue; }
                if (line.StartsWith('#') || line.StartsWith("//")) { continue; }
                sb.Append(line);
            }
            return sb.ToString();
        }

        private int doeventsCounter = 0;

        private void CheckDoEvents()
        {
            doeventsCounter += 1;
            if (doeventsCounter >= 1000)
            {
                doeventsCounter = 0;
                Application.DoEvents();
            }
        }

        private void CleanOldScriptFiles()
        {
            try
            {
                var time = DateTime.Today.AddDays(-3);
                foreach (var file in dirScripts.GetFiles("*.cmd", SearchOption.TopDirectoryOnly))
                {
                    if (file.LastWriteTime < time)
                    {
                        file.Delete();
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            try
            {
                var taskNum = (int)Math.Clamp(txtTaskNum.Value, 1, 999);
                bool pauseOnEnd = checkEndPause.Checked;
                var now = DateTime.Now;
                var nowStr = now.ToString("yy-MM-dd_HH-mm-ss");
                var sourceDirPath = Utils.CleanPath(txtSourceDir.Text);
                if (string.IsNullOrEmpty(sourceDirPath)) { throw new Exception("源文件夹是空白"); }
                var sourceDir = new DirectoryInfo(sourceDirPath);
                if (!sourceDir.Exists) { throw new Exception($"源文件夹不存在 {sourceDir.FullName}"); }
                var search = txtSearch.Text.Trim();
                if (string.IsNullOrEmpty(search)) { search = "*"; }
                var outputDirPath = Utils.CleanPath(txtOutputDir.Text);
                if (string.IsNullOrEmpty(outputDirPath) || outputDirPath.Equals("*"))
                {
                    outputDirPath = Path.Combine(sourceDir.Parent!.FullName, $"ffmpeg_{nowStr}");
                }
                else
                {
                    if (!Directory.Exists(outputDirPath)) { throw new Exception($"输出文件夹不存在 {outputDirPath}"); }
                }
                var outputFormat = txtFormat.Text.Trim().Trim('.');
                if (string.IsNullOrEmpty(outputFormat)) { throw new Exception($"没有要输出的格式"); }
                var listTargets = new List<string>();
                var sourceFormats = new HashSet<string>();
                foreach (var item in sourceDir.EnumerateFiles(search, SearchOption.AllDirectories))
                {
                    listTargets.Add(Utils.CleanPath(item.FullName));
                    sourceFormats.Add(item.Extension.ToLower());
                    CheckDoEvents();
                }
                if (listTargets.Count < 1) { throw new Exception($"找不到任何要转码的文件\n{sourceDir.FullName}\n{search}"); }

                var msg = $"你确定要开始转码吗？\n同时运行 {taskNum} 个任务\n源： {sourceDir.FullName}\n输出： {outputDirPath}\n输出格式： {outputFormat}\n源文件个数： {listTargets.Count}\n源文件格式： {string.Join("  ", sourceFormats)}";
                var ask = MessageBox.Show(msg, this.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (ask != DialogResult.OK) { return; }

                var outputParamsRaw = ParseParamsText();
                int chunkSize = (int)Math.Ceiling(listTargets.Count / (float)taskNum);
                var targetGroups = listTargets.Chunk(chunkSize).ToArray();
                int scriptIndex = 0;
                var scriptFiles = new List<string>();
                foreach (var targetGroup in targetGroups)
                {
                    scriptIndex += 1;
                    var scriptPath = Path.Combine(dirScripts.FullName, $"{nowStr}_{scriptIndex}.cmd");
                    scriptFiles.Add(scriptPath);
                    using var stream = File.Create(scriptPath);
                    using var writer = new StreamWriter(stream, Utils.UTF8Nobom);
                    writer.WriteLine($"chcp 65001 "); // 切换到 utf8 字符集
                    int targetIndex = 0;
                    foreach (var target in targetGroup)
                    {
                        targetIndex += 1;
                        CheckDoEvents();
                        var relPath = Path.GetRelativePath(sourceDir.FullName, target);
                        relPath = Path.ChangeExtension(relPath, outputFormat);
                        var outputPath = Path.Combine(outputDirPath, relPath);
                        var newDir = Path.GetDirectoryName(outputPath);
                        if (!string.IsNullOrEmpty(newDir))
                        {
                            Directory.CreateDirectory(newDir);
                        }
                        var progress = targetIndex / (float)targetGroup.Length;
                        writer.WriteLine($"title 进度 {targetIndex} / {targetGroup.Length} ");
                        writer.WriteLine($"ffmpeg.exe -i \"{target}\" {outputParamsRaw} \"{outputPath}\"");
                    }
                    writer.Dispose();
                    stream.Dispose();
                }
                foreach (var path in scriptFiles)
                {
                    var info = new ProcessStartInfo()
                    {
                        UseShellExecute = true,
                        FileName = "cmd.exe",
                        WorkingDirectory = sourceDir.FullName,
                        WindowStyle = ProcessWindowStyle.Normal
                    };
                    info.ArgumentList.Add(pauseOnEnd ? "/k" : "/c");
                    info.ArgumentList.Add(path);
                    using var v = Process.Start(info);
                }
            }
            catch (Exception ex)
            {
                Utils.ShowErrorMessageBox($"生成脚本出错： \n{ex.Message}");
            }
        }

    }
}
