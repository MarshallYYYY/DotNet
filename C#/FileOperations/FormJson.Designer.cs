namespace FileOperations
{
    partial class FormJson
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
            this.btnWriteJson = new System.Windows.Forms.Button();
            this.btnAppendJson = new System.Windows.Forms.Button();
            this.btnWriteJsonTwo = new System.Windows.Forms.Button();
            this.btnReadJson = new System.Windows.Forms.Button();
            this.btnReadJsonTwo = new System.Windows.Forms.Button();
            this.btnRemoveProperty = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnWriteJson
            // 
            this.btnWriteJson.AutoSize = true;
            this.btnWriteJson.Font = new System.Drawing.Font("宋体", 18F);
            this.btnWriteJson.Location = new System.Drawing.Point(12, 12);
            this.btnWriteJson.Name = "btnWriteJson";
            this.btnWriteJson.Size = new System.Drawing.Size(416, 34);
            this.btnWriteJson.TabIndex = 22;
            this.btnWriteJson.Text = "创建Json文件并写入内容（JObject）";
            this.btnWriteJson.UseVisualStyleBackColor = true;
            this.btnWriteJson.Click += new System.EventHandler(this.BtnWriteJson_Click);
            // 
            // btnAppendJson
            // 
            this.btnAppendJson.AutoSize = true;
            this.btnAppendJson.Font = new System.Drawing.Font("宋体", 18F);
            this.btnAppendJson.Location = new System.Drawing.Point(12, 92);
            this.btnAppendJson.Name = "btnAppendJson";
            this.btnAppendJson.Size = new System.Drawing.Size(164, 34);
            this.btnAppendJson.TabIndex = 23;
            this.btnAppendJson.Text = "追加Json内容";
            this.btnAppendJson.UseVisualStyleBackColor = true;
            this.btnAppendJson.Click += new System.EventHandler(this.BtnAppendJson_Click);
            // 
            // btnWriteJsonTwo
            // 
            this.btnWriteJsonTwo.AutoSize = true;
            this.btnWriteJsonTwo.Font = new System.Drawing.Font("宋体", 18F);
            this.btnWriteJsonTwo.Location = new System.Drawing.Point(12, 52);
            this.btnWriteJsonTwo.Name = "btnWriteJsonTwo";
            this.btnWriteJsonTwo.Size = new System.Drawing.Size(404, 34);
            this.btnWriteJsonTwo.TabIndex = 24;
            this.btnWriteJsonTwo.Text = "创建Json文件并写入内容（string）";
            this.btnWriteJsonTwo.UseVisualStyleBackColor = true;
            this.btnWriteJsonTwo.Click += new System.EventHandler(this.BtnWriteJsonTwo_Click);
            // 
            // btnReadJson
            // 
            this.btnReadJson.AutoSize = true;
            this.btnReadJson.Font = new System.Drawing.Font("宋体", 18F);
            this.btnReadJson.Location = new System.Drawing.Point(434, 12);
            this.btnReadJson.Name = "btnReadJson";
            this.btnReadJson.Size = new System.Drawing.Size(296, 34);
            this.btnReadJson.TabIndex = 25;
            this.btnReadJson.Text = "读取Json内容（JObject）";
            this.btnReadJson.UseVisualStyleBackColor = true;
            this.btnReadJson.Click += new System.EventHandler(this.BtnReadJson_Click);
            // 
            // btnReadJsonTwo
            // 
            this.btnReadJsonTwo.AutoSize = true;
            this.btnReadJsonTwo.Font = new System.Drawing.Font("宋体", 18F);
            this.btnReadJsonTwo.Location = new System.Drawing.Point(422, 52);
            this.btnReadJsonTwo.Name = "btnReadJsonTwo";
            this.btnReadJsonTwo.Size = new System.Drawing.Size(284, 34);
            this.btnReadJsonTwo.TabIndex = 26;
            this.btnReadJsonTwo.Text = "读取Json内容（string）";
            this.btnReadJsonTwo.UseVisualStyleBackColor = true;
            this.btnReadJsonTwo.Click += new System.EventHandler(this.BtnReadJsonTwo_Click);
            // 
            // btnRemoveProperty
            // 
            this.btnRemoveProperty.AutoSize = true;
            this.btnRemoveProperty.Font = new System.Drawing.Font("宋体", 18F);
            this.btnRemoveProperty.Location = new System.Drawing.Point(182, 92);
            this.btnRemoveProperty.Name = "btnRemoveProperty";
            this.btnRemoveProperty.Size = new System.Drawing.Size(104, 34);
            this.btnRemoveProperty.TabIndex = 27;
            this.btnRemoveProperty.Text = "移除Key";
            this.btnRemoveProperty.UseVisualStyleBackColor = true;
            this.btnRemoveProperty.Click += new System.EventHandler(this.BtnRemoveProperty_Click);
            // 
            // FormJson
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnRemoveProperty);
            this.Controls.Add(this.btnReadJsonTwo);
            this.Controls.Add(this.btnReadJson);
            this.Controls.Add(this.btnWriteJsonTwo);
            this.Controls.Add(this.btnAppendJson);
            this.Controls.Add(this.btnWriteJson);
            this.Name = "FormJson";
            this.Text = "FormJson";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnWriteJson;
        private System.Windows.Forms.Button btnAppendJson;
        private System.Windows.Forms.Button btnWriteJsonTwo;
        private System.Windows.Forms.Button btnReadJson;
        private System.Windows.Forms.Button btnReadJsonTwo;
        private System.Windows.Forms.Button btnRemoveProperty;
    }
}