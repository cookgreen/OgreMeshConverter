namespace OgreMeshConverter
{
    partial class frmMain
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtOgreMesh = new System.Windows.Forms.TextBox();
            this.btnBrowseMesh = new System.Windows.Forms.Button();
            this.btnBrowseObj = new System.Windows.Forms.Button();
            this.txtObjFile = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnConvert = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ogre3d Mesh File:";
            // 
            // txtOgreMesh
            // 
            this.txtOgreMesh.Location = new System.Drawing.Point(169, 15);
            this.txtOgreMesh.Name = "txtOgreMesh";
            this.txtOgreMesh.ReadOnly = true;
            this.txtOgreMesh.Size = new System.Drawing.Size(359, 25);
            this.txtOgreMesh.TabIndex = 1;
            // 
            // btnBrowseMesh
            // 
            this.btnBrowseMesh.Location = new System.Drawing.Point(534, 14);
            this.btnBrowseMesh.Name = "btnBrowseMesh";
            this.btnBrowseMesh.Size = new System.Drawing.Size(55, 26);
            this.btnBrowseMesh.TabIndex = 2;
            this.btnBrowseMesh.Text = "...";
            this.btnBrowseMesh.UseVisualStyleBackColor = true;
            this.btnBrowseMesh.Click += new System.EventHandler(this.btnBrowseMesh_Click);
            // 
            // btnBrowseObj
            // 
            this.btnBrowseObj.Location = new System.Drawing.Point(534, 57);
            this.btnBrowseObj.Name = "btnBrowseObj";
            this.btnBrowseObj.Size = new System.Drawing.Size(55, 26);
            this.btnBrowseObj.TabIndex = 5;
            this.btnBrowseObj.Text = "...";
            this.btnBrowseObj.UseVisualStyleBackColor = true;
            this.btnBrowseObj.Click += new System.EventHandler(this.btnBrowseObj_Click);
            // 
            // txtObjFile
            // 
            this.txtObjFile.Location = new System.Drawing.Point(169, 58);
            this.txtObjFile.Name = "txtObjFile";
            this.txtObjFile.ReadOnly = true;
            this.txtObjFile.Size = new System.Drawing.Size(359, 25);
            this.txtObjFile.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(151, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Wavefont Obj File:";
            // 
            // btnConvert
            // 
            this.btnConvert.Location = new System.Drawing.Point(431, 98);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(158, 59);
            this.btnConvert.TabIndex = 6;
            this.btnConvert.Text = "Convert";
            this.btnConvert.UseVisualStyleBackColor = true;
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(606, 178);
            this.Controls.Add(this.btnConvert);
            this.Controls.Add(this.btnBrowseObj);
            this.Controls.Add(this.txtObjFile);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnBrowseMesh);
            this.Controls.Add(this.txtOgreMesh);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMain";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OgreMeshConverter - [1.7]";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtOgreMesh;
        private System.Windows.Forms.Button btnBrowseMesh;
        private System.Windows.Forms.Button btnBrowseObj;
        private System.Windows.Forms.TextBox txtObjFile;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnConvert;
    }
}

