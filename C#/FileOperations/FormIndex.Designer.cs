namespace FileOperations
{
    partial class FormIndex
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
            this.btnCreateDirectory = new System.Windows.Forms.Button();
            this.textBoxPath = new System.Windows.Forms.TextBox();
            this.btnDeleteDirectory = new System.Windows.Forms.Button();
            this.btnCreateFile = new System.Windows.Forms.Button();
            this.btnDeleteFile = new System.Windows.Forms.Button();
            this.checkBox = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxContent = new System.Windows.Forms.TextBox();
            this.btnWrite = new System.Windows.Forms.Button();
            this.btnRead = new System.Windows.Forms.Button();
            this.btnAppend = new System.Windows.Forms.Button();
            this.btnRead2 = new System.Windows.Forms.Button();
            this.btnRead3 = new System.Windows.Forms.Button();
            this.btnCopy = new System.Windows.Forms.Button();
            this.btnMove = new System.Windows.Forms.Button();
            this.btnRename = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCreateDirectory
            // 
            this.btnCreateDirectory.AutoSize = true;
            this.btnCreateDirectory.Font = new System.Drawing.Font("宋体", 18F);
            this.btnCreateDirectory.Location = new System.Drawing.Point(9, 100);
            this.btnCreateDirectory.Name = "btnCreateDirectory";
            this.btnCreateDirectory.Size = new System.Drawing.Size(140, 34);
            this.btnCreateDirectory.TabIndex = 0;
            this.btnCreateDirectory.Text = "创建目录";
            this.btnCreateDirectory.UseVisualStyleBackColor = true;
            this.btnCreateDirectory.Click += new System.EventHandler(this.BtnCreateDirectory_Click);
            // 
            // textBoxPath
            // 
            this.textBoxPath.Font = new System.Drawing.Font("宋体", 18F);
            this.textBoxPath.Location = new System.Drawing.Point(76, 12);
            this.textBoxPath.Name = "textBoxPath";
            this.textBoxPath.Size = new System.Drawing.Size(485, 35);
            this.textBoxPath.TabIndex = 1;
            // 
            // btnDeleteDirectory
            // 
            this.btnDeleteDirectory.AutoSize = true;
            this.btnDeleteDirectory.Font = new System.Drawing.Font("宋体", 18F);
            this.btnDeleteDirectory.Location = new System.Drawing.Point(155, 100);
            this.btnDeleteDirectory.Name = "btnDeleteDirectory";
            this.btnDeleteDirectory.Size = new System.Drawing.Size(140, 34);
            this.btnDeleteDirectory.TabIndex = 2;
            this.btnDeleteDirectory.Text = "删除目录";
            this.btnDeleteDirectory.UseVisualStyleBackColor = true;
            this.btnDeleteDirectory.Click += new System.EventHandler(this.BtnDeleteDirectory_Click);
            // 
            // btnCreateFile
            // 
            this.btnCreateFile.AutoSize = true;
            this.btnCreateFile.Font = new System.Drawing.Font("宋体", 18F);
            this.btnCreateFile.Location = new System.Drawing.Point(9, 140);
            this.btnCreateFile.Name = "btnCreateFile";
            this.btnCreateFile.Size = new System.Drawing.Size(140, 34);
            this.btnCreateFile.TabIndex = 3;
            this.btnCreateFile.Text = "创建文件";
            this.btnCreateFile.UseVisualStyleBackColor = true;
            this.btnCreateFile.Click += new System.EventHandler(this.BtnCreateFile_Click);
            // 
            // btnDeleteFile
            // 
            this.btnDeleteFile.AutoSize = true;
            this.btnDeleteFile.Font = new System.Drawing.Font("宋体", 18F);
            this.btnDeleteFile.Location = new System.Drawing.Point(155, 140);
            this.btnDeleteFile.Name = "btnDeleteFile";
            this.btnDeleteFile.Size = new System.Drawing.Size(140, 34);
            this.btnDeleteFile.TabIndex = 4;
            this.btnDeleteFile.Text = "删除文件";
            this.btnDeleteFile.UseVisualStyleBackColor = true;
            this.btnDeleteFile.Click += new System.EventHandler(this.BtnDeleteFile_Click);
            // 
            // checkBox
            // 
            this.checkBox.AutoSize = true;
            this.checkBox.Font = new System.Drawing.Font("宋体", 18F);
            this.checkBox.Location = new System.Drawing.Point(567, 15);
            this.checkBox.Name = "checkBox";
            this.checkBox.Size = new System.Drawing.Size(221, 28);
            this.checkBox.TabIndex = 5;
            this.checkBox.Text = "以桌面为基础目录";
            this.checkBox.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 18F);
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 24);
            this.label1.TabIndex = 6;
            this.label1.Text = "路径";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 18F);
            this.label2.Location = new System.Drawing.Point(12, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 24);
            this.label2.TabIndex = 8;
            this.label2.Text = "内容";
            // 
            // textBoxContent
            // 
            this.textBoxContent.Font = new System.Drawing.Font("宋体", 18F);
            this.textBoxContent.Location = new System.Drawing.Point(76, 53);
            this.textBoxContent.Name = "textBoxContent";
            this.textBoxContent.Size = new System.Drawing.Size(485, 35);
            this.textBoxContent.TabIndex = 7;
            // 
            // btnWrite
            // 
            this.btnWrite.AutoSize = true;
            this.btnWrite.Font = new System.Drawing.Font("宋体", 18F);
            this.btnWrite.Location = new System.Drawing.Point(301, 140);
            this.btnWrite.Name = "btnWrite";
            this.btnWrite.Size = new System.Drawing.Size(140, 34);
            this.btnWrite.TabIndex = 9;
            this.btnWrite.Text = "写入内容";
            this.btnWrite.UseVisualStyleBackColor = true;
            this.btnWrite.Click += new System.EventHandler(this.BtnWrite_Click);
            // 
            // btnRead
            // 
            this.btnRead.AutoSize = true;
            this.btnRead.Font = new System.Drawing.Font("宋体", 18F);
            this.btnRead.Location = new System.Drawing.Point(9, 180);
            this.btnRead.Name = "btnRead";
            this.btnRead.Size = new System.Drawing.Size(284, 34);
            this.btnRead.TabIndex = 10;
            this.btnRead.Text = "读取所有内容：通过File";
            this.btnRead.UseVisualStyleBackColor = true;
            this.btnRead.Click += new System.EventHandler(this.BtnRead_Click);
            // 
            // btnAppend
            // 
            this.btnAppend.AutoSize = true;
            this.btnAppend.Font = new System.Drawing.Font("宋体", 18F);
            this.btnAppend.Location = new System.Drawing.Point(447, 140);
            this.btnAppend.Name = "btnAppend";
            this.btnAppend.Size = new System.Drawing.Size(140, 34);
            this.btnAppend.TabIndex = 11;
            this.btnAppend.Text = "追加内容";
            this.btnAppend.UseVisualStyleBackColor = true;
            this.btnAppend.Click += new System.EventHandler(this.BtnAppend_Click);
            // 
            // btnRead2
            // 
            this.btnRead2.AutoSize = true;
            this.btnRead2.Font = new System.Drawing.Font("宋体", 18F);
            this.btnRead2.Location = new System.Drawing.Point(301, 180);
            this.btnRead2.Name = "btnRead2";
            this.btnRead2.Size = new System.Drawing.Size(380, 34);
            this.btnRead2.TabIndex = 12;
            this.btnRead2.Text = "读取所有内容：通过StreamReader";
            this.btnRead2.UseVisualStyleBackColor = true;
            this.btnRead2.Click += new System.EventHandler(this.BtnRead2_Click);
            // 
            // btnRead3
            // 
            this.btnRead3.AutoSize = true;
            this.btnRead3.Font = new System.Drawing.Font("宋体", 18F);
            this.btnRead3.Location = new System.Drawing.Point(9, 220);
            this.btnRead3.Name = "btnRead3";
            this.btnRead3.Size = new System.Drawing.Size(380, 34);
            this.btnRead3.TabIndex = 13;
            this.btnRead3.Text = "通过StreamReader，按行读取内容";
            this.btnRead3.UseVisualStyleBackColor = true;
            this.btnRead3.Click += new System.EventHandler(this.BtnRead3_Click);
            // 
            // btnCopy
            // 
            this.btnCopy.AutoSize = true;
            this.btnCopy.Font = new System.Drawing.Font("宋体", 18F);
            this.btnCopy.Location = new System.Drawing.Point(9, 260);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(140, 34);
            this.btnCopy.TabIndex = 14;
            this.btnCopy.Text = "复制文件";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.BtnCopy_Click);
            // 
            // btnMove
            // 
            this.btnMove.AutoSize = true;
            this.btnMove.Font = new System.Drawing.Font("宋体", 18F);
            this.btnMove.Location = new System.Drawing.Point(155, 260);
            this.btnMove.Name = "btnMove";
            this.btnMove.Size = new System.Drawing.Size(140, 34);
            this.btnMove.TabIndex = 15;
            this.btnMove.Text = "移动文件";
            this.btnMove.UseVisualStyleBackColor = true;
            this.btnMove.Click += new System.EventHandler(this.BtnMove_Click);
            // 
            // btnRename
            // 
            this.btnRename.AutoSize = true;
            this.btnRename.Font = new System.Drawing.Font("宋体", 18F);
            this.btnRename.Location = new System.Drawing.Point(301, 260);
            this.btnRename.Name = "btnRename";
            this.btnRename.Size = new System.Drawing.Size(140, 34);
            this.btnRename.TabIndex = 16;
            this.btnRename.Text = "重命名文件";
            this.btnRename.UseVisualStyleBackColor = true;
            this.btnRename.Click += new System.EventHandler(this.BtnRename_Click);
            // 
            // FormIndex
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnRename);
            this.Controls.Add(this.btnMove);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.btnRead3);
            this.Controls.Add(this.btnRead2);
            this.Controls.Add(this.btnAppend);
            this.Controls.Add(this.btnRead);
            this.Controls.Add(this.btnWrite);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxContent);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkBox);
            this.Controls.Add(this.btnDeleteFile);
            this.Controls.Add(this.btnCreateFile);
            this.Controls.Add(this.btnDeleteDirectory);
            this.Controls.Add(this.textBoxPath);
            this.Controls.Add(this.btnCreateDirectory);
            this.Name = "FormIndex";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "文件操作";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCreateDirectory;
        private System.Windows.Forms.TextBox textBoxPath;
        private System.Windows.Forms.Button btnDeleteDirectory;
        private System.Windows.Forms.Button btnCreateFile;
        private System.Windows.Forms.Button btnDeleteFile;
        private System.Windows.Forms.CheckBox checkBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxContent;
        private System.Windows.Forms.Button btnWrite;
        private System.Windows.Forms.Button btnRead;
        private System.Windows.Forms.Button btnAppend;
        private System.Windows.Forms.Button btnRead2;
        private System.Windows.Forms.Button btnRead3;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.Button btnMove;
        private System.Windows.Forms.Button btnRename;
    }
}

