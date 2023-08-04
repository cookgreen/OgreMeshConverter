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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
			this.label1 = new Sunny.UI.UILabel();
			this.txtOgreMesh = new Sunny.UI.UITextBox();
			this.btnBrowseMesh = new Sunny.UI.UIButton();
			this.btnBrowseExport = new Sunny.UI.UIButton();
			this.txtExportFile = new Sunny.UI.UITextBox();
			this.label2 = new Sunny.UI.UILabel();
			this.btnConvert = new Sunny.UI.UIButton();
			this.cmbOutputType = new Sunny.UI.UIComboBox();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label1.Location = new System.Drawing.Point(12, 48);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(186, 27);
			this.label1.TabIndex = 0;
			this.label1.Text = "Ogre3d Mesh File:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.label1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
			// 
			// txtOgreMesh
			// 
			this.txtOgreMesh.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtOgreMesh.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.txtOgreMesh.Location = new System.Drawing.Point(204, 48);
			this.txtOgreMesh.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.txtOgreMesh.MinimumSize = new System.Drawing.Size(1, 16);
			this.txtOgreMesh.Name = "txtOgreMesh";
			this.txtOgreMesh.ReadOnly = true;
			this.txtOgreMesh.ShowText = false;
			this.txtOgreMesh.Size = new System.Drawing.Size(367, 34);
			this.txtOgreMesh.TabIndex = 1;
			this.txtOgreMesh.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
			this.txtOgreMesh.Watermark = "";
			this.txtOgreMesh.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
			// 
			// btnBrowseMesh
			// 
			this.btnBrowseMesh.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnBrowseMesh.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.btnBrowseMesh.Location = new System.Drawing.Point(577, 49);
			this.btnBrowseMesh.MinimumSize = new System.Drawing.Size(1, 1);
			this.btnBrowseMesh.Name = "btnBrowseMesh";
			this.btnBrowseMesh.Size = new System.Drawing.Size(55, 33);
			this.btnBrowseMesh.TabIndex = 2;
			this.btnBrowseMesh.Text = "...";
			this.btnBrowseMesh.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.btnBrowseMesh.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
			this.btnBrowseMesh.Click += new System.EventHandler(this.btnBrowseMesh_Click);
			// 
			// btnBrowseExport
			// 
			this.btnBrowseExport.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnBrowseExport.Enabled = false;
			this.btnBrowseExport.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.btnBrowseExport.Location = new System.Drawing.Point(577, 110);
			this.btnBrowseExport.MinimumSize = new System.Drawing.Size(1, 1);
			this.btnBrowseExport.Name = "btnBrowseExport";
			this.btnBrowseExport.Size = new System.Drawing.Size(55, 34);
			this.btnBrowseExport.TabIndex = 5;
			this.btnBrowseExport.Text = "...";
			this.btnBrowseExport.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.btnBrowseExport.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
			this.btnBrowseExport.Click += new System.EventHandler(this.btnBrowseObj_Click);
			// 
			// txtExportFile
			// 
			this.txtExportFile.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtExportFile.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.txtExportFile.Location = new System.Drawing.Point(331, 110);
			this.txtExportFile.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.txtExportFile.MinimumSize = new System.Drawing.Size(1, 16);
			this.txtExportFile.Name = "txtExportFile";
			this.txtExportFile.ReadOnly = true;
			this.txtExportFile.ShowText = false;
			this.txtExportFile.Size = new System.Drawing.Size(240, 34);
			this.txtExportFile.TabIndex = 4;
			this.txtExportFile.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
			this.txtExportFile.Watermark = "";
			this.txtExportFile.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label2.Location = new System.Drawing.Point(12, 113);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(122, 27);
			this.label2.TabIndex = 3;
			this.label2.Text = "Output File:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.label2.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
			// 
			// btnConvert
			// 
			this.btnConvert.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnConvert.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.btnConvert.Location = new System.Drawing.Point(474, 179);
			this.btnConvert.MinimumSize = new System.Drawing.Size(1, 1);
			this.btnConvert.Name = "btnConvert";
			this.btnConvert.Size = new System.Drawing.Size(158, 59);
			this.btnConvert.TabIndex = 6;
			this.btnConvert.Text = "Convert";
			this.btnConvert.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.btnConvert.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
			this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
			// 
			// cmbOutputType
			// 
			this.cmbOutputType.DataSource = null;
			this.cmbOutputType.DisplayMember = "TypeName";
			this.cmbOutputType.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
			this.cmbOutputType.FillColor = System.Drawing.Color.White;
			this.cmbOutputType.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.cmbOutputType.FormattingEnabled = true;
			this.cmbOutputType.Location = new System.Drawing.Point(204, 110);
			this.cmbOutputType.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.cmbOutputType.MinimumSize = new System.Drawing.Size(63, 0);
			this.cmbOutputType.Name = "cmbOutputType";
			this.cmbOutputType.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
			this.cmbOutputType.Size = new System.Drawing.Size(121, 35);
			this.cmbOutputType.TabIndex = 7;
			this.cmbOutputType.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
			this.cmbOutputType.ValueMember = "TypeName";
			this.cmbOutputType.Watermark = "";
			this.cmbOutputType.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
			this.cmbOutputType.SelectedIndexChanged += new System.EventHandler(this.cmbOutputType_SelectedIndexChanged);
			// 
			// frmMain
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.ClientSize = new System.Drawing.Size(647, 255);
			this.Controls.Add(this.cmbOutputType);
			this.Controls.Add(this.btnConvert);
			this.Controls.Add(this.btnBrowseExport);
			this.Controls.Add(this.txtExportFile);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.btnBrowseMesh);
			this.Controls.Add(this.txtOgreMesh);
			this.Controls.Add(this.label1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmMain";
			this.Text = "OgreMeshConverter - [<=1.7]";
			this.ZoomScaleRect = new System.Drawing.Rectangle(19, 19, 606, 178);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private Sunny.UI.UILabel label1;
        private Sunny.UI.UITextBox txtOgreMesh;
        private Sunny.UI.UIButton btnBrowseMesh;
        private Sunny.UI.UIButton btnBrowseExport;
        private Sunny.UI.UITextBox txtExportFile;
        private Sunny.UI.UILabel label2;
        private Sunny.UI.UIButton btnConvert;
        private Sunny.UI.UIComboBox cmbOutputType;
    }
}

