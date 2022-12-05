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
            this.btnBrowseExport = new System.Windows.Forms.Button();
            this.txtExportFile = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnConvert = new System.Windows.Forms.Button();
            this.cmbOutputType = new System.Windows.Forms.ComboBox();
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
            this.txtOgreMesh.Location = new System.Drawing.Point(161, 15);
            this.txtOgreMesh.Name = "txtOgreMesh";
            this.txtOgreMesh.ReadOnly = true;
            this.txtOgreMesh.Size = new System.Drawing.Size(367, 25);
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
            // btnBrowseExport
            // 
            this.btnBrowseExport.Enabled = false;
            this.btnBrowseExport.Location = new System.Drawing.Point(534, 57);
            this.btnBrowseExport.Name = "btnBrowseExport";
            this.btnBrowseExport.Size = new System.Drawing.Size(55, 26);
            this.btnBrowseExport.TabIndex = 5;
            this.btnBrowseExport.Text = "...";
            this.btnBrowseExport.UseVisualStyleBackColor = true;
            this.btnBrowseExport.Click += new System.EventHandler(this.btnBrowseObj_Click);
            // 
            // txtExportFile
            // 
            this.txtExportFile.Location = new System.Drawing.Point(288, 58);
            this.txtExportFile.Name = "txtExportFile";
            this.txtExportFile.ReadOnly = true;
            this.txtExportFile.Size = new System.Drawing.Size(240, 25);
            this.txtExportFile.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Output File:";
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
            // cmbOutputType
            // 
            this.cmbOutputType.DisplayMember = "TypeName";
            this.cmbOutputType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOutputType.FormattingEnabled = true;
            this.cmbOutputType.Location = new System.Drawing.Point(161, 61);
            this.cmbOutputType.Name = "cmbOutputType";
            this.cmbOutputType.Size = new System.Drawing.Size(121, 23);
            this.cmbOutputType.TabIndex = 7;
            this.cmbOutputType.ValueMember = "TypeName";
            this.cmbOutputType.SelectedIndexChanged += new System.EventHandler(this.cmbOutputType_SelectedIndexChanged);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(606, 178);
            this.Controls.Add(this.cmbOutputType);
            this.Controls.Add(this.btnConvert);
            this.Controls.Add(this.btnBrowseExport);
            this.Controls.Add(this.txtExportFile);
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
            this.Text = "OgreMeshConverter - [<=1.7]";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtOgreMesh;
        private System.Windows.Forms.Button btnBrowseMesh;
        private System.Windows.Forms.Button btnBrowseExport;
        private System.Windows.Forms.TextBox txtExportFile;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.ComboBox cmbOutputType;
    }
}

