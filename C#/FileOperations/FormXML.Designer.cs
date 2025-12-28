namespace FileOperations
{
    partial class FormXML
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
            this.btnAppendXML = new System.Windows.Forms.Button();
            this.btnCreateXML = new System.Windows.Forms.Button();
            this.btnReadXMLByInnerText = new System.Windows.Forms.Button();
            this.btnReadXMLByInnerXML = new System.Windows.Forms.Button();
            this.btnReadXMLByInnerXML2 = new System.Windows.Forms.Button();
            this.btnReadXMLByInnerText2 = new System.Windows.Forms.Button();
            this.btnDeleteNode = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAppendXML
            // 
            this.btnAppendXML.AutoSize = true;
            this.btnAppendXML.Font = new System.Drawing.Font("宋体", 18F);
            this.btnAppendXML.Location = new System.Drawing.Point(170, 12);
            this.btnAppendXML.Name = "btnAppendXML";
            this.btnAppendXML.Size = new System.Drawing.Size(152, 34);
            this.btnAppendXML.TabIndex = 21;
            this.btnAppendXML.Text = "追加XML内容";
            this.btnAppendXML.UseVisualStyleBackColor = true;
            this.btnAppendXML.Click += new System.EventHandler(this.BtnAppendXML_Click);
            // 
            // btnCreateXML
            // 
            this.btnCreateXML.AutoSize = true;
            this.btnCreateXML.Font = new System.Drawing.Font("宋体", 18F);
            this.btnCreateXML.Location = new System.Drawing.Point(12, 12);
            this.btnCreateXML.Name = "btnCreateXML";
            this.btnCreateXML.Size = new System.Drawing.Size(152, 34);
            this.btnCreateXML.TabIndex = 20;
            this.btnCreateXML.Text = "创建XML文件";
            this.btnCreateXML.UseVisualStyleBackColor = true;
            this.btnCreateXML.Click += new System.EventHandler(this.BtnCreateXML_Click);
            // 
            // btnReadXMLByInnerText
            // 
            this.btnReadXMLByInnerText.AutoSize = true;
            this.btnReadXMLByInnerText.Font = new System.Drawing.Font("宋体", 18F);
            this.btnReadXMLByInnerText.Location = new System.Drawing.Point(12, 52);
            this.btnReadXMLByInnerText.Name = "btnReadXMLByInnerText";
            this.btnReadXMLByInnerText.Size = new System.Drawing.Size(284, 34);
            this.btnReadXMLByInnerText.TabIndex = 22;
            this.btnReadXMLByInnerText.Text = "读取XML文件：InnerText";
            this.btnReadXMLByInnerText.UseVisualStyleBackColor = true;
            this.btnReadXMLByInnerText.Click += new System.EventHandler(this.BtnReadXMLByInnerText_Click);
            // 
            // btnReadXMLByInnerXML
            // 
            this.btnReadXMLByInnerXML.AutoSize = true;
            this.btnReadXMLByInnerXML.Font = new System.Drawing.Font("宋体", 18F);
            this.btnReadXMLByInnerXML.Location = new System.Drawing.Point(302, 52);
            this.btnReadXMLByInnerXML.Name = "btnReadXMLByInnerXML";
            this.btnReadXMLByInnerXML.Size = new System.Drawing.Size(272, 34);
            this.btnReadXMLByInnerXML.TabIndex = 23;
            this.btnReadXMLByInnerXML.Text = "读取XML文件：InnerXML";
            this.btnReadXMLByInnerXML.UseVisualStyleBackColor = true;
            this.btnReadXMLByInnerXML.Click += new System.EventHandler(this.BtnReadXMLByInnerXML_Click);
            // 
            // btnReadXMLByInnerXML2
            // 
            this.btnReadXMLByInnerXML2.AutoSize = true;
            this.btnReadXMLByInnerXML2.Font = new System.Drawing.Font("宋体", 18F);
            this.btnReadXMLByInnerXML2.Location = new System.Drawing.Point(338, 92);
            this.btnReadXMLByInnerXML2.Name = "btnReadXMLByInnerXML2";
            this.btnReadXMLByInnerXML2.Size = new System.Drawing.Size(308, 34);
            this.btnReadXMLByInnerXML2.TabIndex = 24;
            this.btnReadXMLByInnerXML2.Text = "读取XML文件：InnerXML(2)";
            this.btnReadXMLByInnerXML2.UseVisualStyleBackColor = true;
            this.btnReadXMLByInnerXML2.Click += new System.EventHandler(this.BtnReadXMLByInnerXML2_Click);
            // 
            // btnReadXMLByInnerText2
            // 
            this.btnReadXMLByInnerText2.AutoSize = true;
            this.btnReadXMLByInnerText2.Font = new System.Drawing.Font("宋体", 18F);
            this.btnReadXMLByInnerText2.Location = new System.Drawing.Point(12, 92);
            this.btnReadXMLByInnerText2.Name = "btnReadXMLByInnerText2";
            this.btnReadXMLByInnerText2.Size = new System.Drawing.Size(320, 34);
            this.btnReadXMLByInnerText2.TabIndex = 25;
            this.btnReadXMLByInnerText2.Text = "读取XML文件：InnerText(2)";
            this.btnReadXMLByInnerText2.UseVisualStyleBackColor = true;
            this.btnReadXMLByInnerText2.Click += new System.EventHandler(this.BtnReadXMLByInnerText2_Click);
            // 
            // btnDeleteNode
            // 
            this.btnDeleteNode.AutoSize = true;
            this.btnDeleteNode.Font = new System.Drawing.Font("宋体", 18F);
            this.btnDeleteNode.Location = new System.Drawing.Point(12, 132);
            this.btnDeleteNode.Name = "btnDeleteNode";
            this.btnDeleteNode.Size = new System.Drawing.Size(152, 34);
            this.btnDeleteNode.TabIndex = 26;
            this.btnDeleteNode.Text = "删除XML节点";
            this.btnDeleteNode.UseVisualStyleBackColor = true;
            this.btnDeleteNode.Click += new System.EventHandler(this.BtnDeleteNode_Click);
            // 
            // FormXML
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnDeleteNode);
            this.Controls.Add(this.btnReadXMLByInnerText2);
            this.Controls.Add(this.btnReadXMLByInnerXML2);
            this.Controls.Add(this.btnReadXMLByInnerXML);
            this.Controls.Add(this.btnReadXMLByInnerText);
            this.Controls.Add(this.btnAppendXML);
            this.Controls.Add(this.btnCreateXML);
            this.Name = "FormXML";
            this.Text = "FormXML";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAppendXML;
        private System.Windows.Forms.Button btnCreateXML;
        private System.Windows.Forms.Button btnReadXMLByInnerText;
        private System.Windows.Forms.Button btnReadXMLByInnerXML;
        private System.Windows.Forms.Button btnReadXMLByInnerXML2;
        private System.Windows.Forms.Button btnReadXMLByInnerText2;
        private System.Windows.Forms.Button btnDeleteNode;
    }
}