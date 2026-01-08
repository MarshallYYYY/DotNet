namespace FileOperations
{
    partial class FormExcel
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnWriteExcel = new System.Windows.Forms.Button();
            this.btnReadExcel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnWriteExcel
            // 
            this.btnWriteExcel.AutoSize = true;
            this.btnWriteExcel.Font = new System.Drawing.Font("宋体", 18F);
            this.btnWriteExcel.Location = new System.Drawing.Point(12, 12);
            this.btnWriteExcel.Name = "btnWriteExcel";
            this.btnWriteExcel.Size = new System.Drawing.Size(296, 34);
            this.btnWriteExcel.TabIndex = 23;
            this.btnWriteExcel.Text = "创建Excel文件并写入内容";
            this.btnWriteExcel.UseVisualStyleBackColor = true;
            this.btnWriteExcel.Click += new System.EventHandler(this.BtnWriteExcel_Click);
            // 
            // btnReadExcel
            // 
            this.btnReadExcel.AutoSize = true;
            this.btnReadExcel.Font = new System.Drawing.Font("宋体", 18F);
            this.btnReadExcel.Location = new System.Drawing.Point(12, 52);
            this.btnReadExcel.Name = "btnReadExcel";
            this.btnReadExcel.Size = new System.Drawing.Size(128, 34);
            this.btnReadExcel.TabIndex = 24;
            this.btnReadExcel.Text = "读取Excel";
            this.btnReadExcel.UseVisualStyleBackColor = true;
            this.btnReadExcel.Click += new System.EventHandler(this.BtnReadExcel_Click);
            // 
            // FormExcel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnReadExcel);
            this.Controls.Add(this.btnWriteExcel);
            this.Name = "FormExcel";
            this.Text = "FormExcel";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnWriteExcel;
        private System.Windows.Forms.Button btnReadExcel;
    }
}