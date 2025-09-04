using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyiFFmpegUI
{
    internal static class Utils
    {
        public static readonly UTF8Encoding UTF8Nobom = new(false);

        public static readonly UTF8Encoding UTF8Withbom = new(true);

        /// <summary>
        /// 整理文件路径，全小写，并把斜杠转换为/
        /// </summary>
        public static string CleanPath(string? f)
        {
            if (string.IsNullOrWhiteSpace(f)) { return string.Empty; }
            f = f.Replace("\\", "/").Trim().Trim('\\', '/', '"');
            return f;
        }

        /// <summary>
        /// 注册文本控件，让他支持拖拽文件文件夹
        /// </summary>
        public static void RegisterTextboxDropFilePath(params TextBoxBase[] controls)
        {
            void OnDragOver(object? sender, DragEventArgs e)
            {
                e.Effect = DragDropEffects.Copy;
            }
            void OnDragDrop(object? sender, DragEventArgs e)
            {
                if (sender == null || sender is not TextBoxBase) { return; }
                var txt = (TextBoxBase)sender;
                var data = e.Data?.GetData(DataFormats.FileDrop);
                if (data == null || data is not IEnumerable<string>) { return; }
                var array = (IEnumerable<string>)data;
                var sb = new StringBuilder();
                if (txt.TextLength > 0 && !txt.Text.EndsWith('\n'))
                {
                    sb.AppendLine();
                }
                foreach (var v in array)
                {
                    if (string.IsNullOrEmpty(v)) { continue; }
                    sb.AppendLine(v);
                    if (!txt.Multiline) { break; }
                }
                if (sb.Length > 0) { txt.Text += sb.ToString(); }
            }
            foreach (var ct in controls)
            {
                ct.AllowDrop = true;
                ct.DragOver += OnDragOver;
                ct.DragDrop += OnDragDrop;
            }
        }

        /// <summary>
        /// 打开文件浏览器
        /// </summary>
        public static void OpenExplorerDirectory(string path)
        {
            var info = new ProcessStartInfo()
            {
                UseShellExecute = true,
                FileName = "explorer.exe"
            };
            info.ArgumentList.Add(path);
            using var v = Process.Start(info);
        }

        public static string VBInputBox(string prompt, string? title = null, string? defaultResponse = null)
        {
            title ??= nameof(BuyiFFmpegUI);
            defaultResponse ??= "";
            return Microsoft.VisualBasic.Interaction.InputBox(prompt, title, defaultResponse);
        }

        public static void ShowErrorMessageBox(string message, string? title = null)
        {
            title ??= nameof(BuyiFFmpegUI);
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void ShowInfoMessageBox(string message, string? title = null)
        {
            title ??= nameof(BuyiFFmpegUI);
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

    }
}
