namespace OgreMeshConverter
{
	partial class frmLoading
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
			this.uiProgressIndicator1 = new Sunny.UI.UIProgressIndicator();
			this.SuspendLayout();
			// 
			// uiProgressIndicator1
			// 
			this.uiProgressIndicator1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.uiProgressIndicator1.Location = new System.Drawing.Point(0, 1);
			this.uiProgressIndicator1.MinimumSize = new System.Drawing.Size(1, 1);
			this.uiProgressIndicator1.Name = "uiProgressIndicator1";
			this.uiProgressIndicator1.Size = new System.Drawing.Size(100, 100);
			this.uiProgressIndicator1.TabIndex = 0;
			this.uiProgressIndicator1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
			// 
			// frmLoading
			// 
			this.AllowShowTitle = false;
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.ClientSize = new System.Drawing.Size(100, 100);
			this.Controls.Add(this.uiProgressIndicator1);
			this.Name = "frmLoading";
			this.Padding = new System.Windows.Forms.Padding(0);
			this.ShowTitle = false;
			this.Text = "frmLoading";
			this.ZoomScaleRect = new System.Drawing.Rectangle(19, 19, 100, 100);
			this.ResumeLayout(false);

		}

		#endregion

		private Sunny.UI.UIProgressIndicator uiProgressIndicator1;
	}
}