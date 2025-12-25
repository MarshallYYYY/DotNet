using System;
using System.IO;
using System.IO.Pipes;
using System.Text;
using System.Windows.Forms;

namespace FileOperations
{
    public partial class FormIndex : Form
    {
        public FormIndex()
        {
            InitializeComponent();
            checkBox.Checked = true;
            textBoxPath.Text = @"a.txt";
        }
        private string GetPath()
        {
            // 使用绝对路径举例：C:\Users\YYYXB\Desktop\
            if (string.IsNullOrWhiteSpace(textBoxPath.Text))
            {
                MessageBox.Show("输入框不能为空！");
                return string.Empty;
            }
            string desktopPath = string.Empty;
            if (checkBox.Checked)
                desktopPath = @"C:\Users\YYYXB\Desktop\";
            // 移除所有空白字符和尾部空白字符
            string path = desktopPath + textBoxPath.Text.Trim();
            return path;
        }

        #region 目录的创建和删除
        private void BtnCreateDirectory_Click(object sender, EventArgs e)
        {
            string path = GetPath();
            if (string.IsNullOrEmpty(path))
                return;
            //CreateDirectoryByDirectoryInfo(path);
            CreateDirectoryByDirectory(path);
        }
        private void CreateDirectoryByDirectoryInfo(string path)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(path);
            if (dirInfo.Exists)
            {
                MessageBox.Show("目录已存在，不可重复创建！");
                return;
                //如果存在删除目录
                //dirInfo.Delete();
            }
            // 创建目录
            // 相对路径时的情况：FileOperations\bin\Debug\path
            dirInfo.Create();
            MessageBox.Show($"目录 \"{path}\" 创建成功！");
        }
        private void CreateDirectoryByDirectory(string path)
        {
            if (Directory.Exists(path))
            {
                MessageBox.Show("目录已存在，不可重复创建！");
                return;
            }
            Directory.CreateDirectory(path);
            MessageBox.Show($"目录 \"{path}\" 创建成功！");
        }

        private void BtnDeleteDirectory_Click(object sender, EventArgs e)
        {
            string path = GetPath();
            if (string.IsNullOrEmpty(path))
                return;
            DirectoryInfo dirInfo = new DirectoryInfo(path);
            if (dirInfo.Exists != true)
            {
                MessageBox.Show("该目录不存在，不可删除！");
                return;
            }
            dirInfo.Delete();
            MessageBox.Show($"目录 \"{path}\" 已成功删除！");
        }
        #endregion

        #region 文件的创建和删除
        private void BtnCreateFile_Click(object sender, EventArgs e)
        {
            string path = GetPath();
            if (string.IsNullOrEmpty(path))
                return;
            if (File.Exists(path))
            {
                MessageBox.Show("文件已存在，不可重复创建！");
                return;
            }
            FileStream fileStream = File.Create(path);
            MessageBox.Show($"文件 \"{path}\" 创建成功！");
            fileStream.Dispose();
        }

        private void BtnDeleteFile_Click(object sender, EventArgs e)
        {
            string path = GetPath();
            if (string.IsNullOrEmpty(path))
                return;
            if (File.Exists(path) == false)
            {
                MessageBox.Show("该文件不存在，不可删除！");
                return;
            }
            File.Delete(path);
            MessageBox.Show($"文件 \"{path}\" 已成功删除！");
        }
        #endregion

        #region 文件内容的写入和追加
        private void BtnWrite_Click(object sender, EventArgs e)
        {
            string path = GetPath();
            if (string.IsNullOrEmpty(path))
                return;
            string content = textBoxContent.Text;
            if (string.IsNullOrWhiteSpace(content))
            {
                MessageBox.Show("内容框不可为空！");
                return;
            }
            File.WriteAllText(path, content);
            //File.WriteAllText(path, content, Encoding.UTF8);
            MessageBox.Show($"{content} 写入 {path} 成功！");
        }

        private void BtnAppend_Click(object sender, EventArgs e)
        {
            string path = GetPath();
            if (string.IsNullOrEmpty(path))
                return;
            string content = textBoxContent.Text;
            if (string.IsNullOrWhiteSpace(content))
            {
                MessageBox.Show("内容框不可为空！");
                return;
            }
            File.AppendAllText(path, content, Encoding.UTF8);
            MessageBox.Show($"{content} 追加到 {path} 成功！");
        }
        #endregion

        #region 文件内容的读取
        private void BtnRead_Click(object sender, EventArgs e)
        {
            string path = GetPath();
            if (string.IsNullOrEmpty(path))
                return;
            string content = File.ReadAllText(path, Encoding.UTF8);
            MessageBox.Show(content);
        }

        private void BtnRead2_Click(object sender, EventArgs e)
        {
            string path = GetPath();
            if (string.IsNullOrEmpty(path))
                return;
            StreamReader streamReader = new StreamReader(path, Encoding.UTF8);
            string content = streamReader.ReadToEnd();
            MessageBox.Show(content);
            streamReader.Close();
        }

        private void BtnRead3_Click(object sender, EventArgs e)
        {
            string path = GetPath();
            if (string.IsNullOrEmpty(path))
                return;
            using (StreamReader streamReader = new StreamReader(path, Encoding.UTF8))
            {
                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    MessageBox.Show(line);
                }
            }
            //using (FileStream fileStream =
            //    new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.None))
            //{
            //    StreamReader streamReader = new StreamReader(fileStream, Encoding.UTF8);
            //    string line;
            //    while ((line = streamReader.ReadLine()) != null)
            //    {
            //        MessageBox.Show(line);
            //    }
            //}
        }
        #endregion

        #region 复制、移动、重命名 文件
        private void BtnCopy_Click(object sender, EventArgs e)
        {
            // 需要桌面有 a.txt
            string sourceFilePath = @"C:\Users\YYYXB\Desktop\a.txt";
            string destinationFilePath = @"C:\Users\YYYXB\Desktop\a_copy.txt";
            File.Copy(sourceFilePath, destinationFilePath);
        }

        private void BtnMove_Click(object sender, EventArgs e)
        {
            // 需要桌面有 a.txt 和 Test 文件夹
            string sourceFilePath = @"C:\Users\YYYXB\Desktop\a.txt";
            string destinationFilePath = @"C:\Users\YYYXB\Desktop\Test\a.txt";
            File.Move(sourceFilePath, destinationFilePath);
        }

        private void BtnRename_Click(object sender, EventArgs e)
        {
            // 需要桌面有 a.txt
            string filePath = @"C:\Users\YYYXB\Desktop\a.txt";
            string newFilePath = @"C:\Users\YYYXB\Desktop\a_new.txt";
            File.Move(filePath, newFilePath);
        }
        #endregion
    }
}