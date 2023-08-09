using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mogre;
using OgreMeshConverter.Interface;
using Sunny.UI;

namespace OgreMeshConverter
{
    public partial class frmMain : UIForm
    {
        private frmLoading loadingForm;
        private FormExpander expander;
        private BackgroundWorker worker;
		private IMeshConvetExporter currentSelectedExporter;
		private List<IMeshConvetExporter> convetExporters;

        public frmMain()
        {
            InitializeComponent();

            convetExporters = new List<IMeshConvetExporter>();
			expander = new FormExpander(this, 250, 555, FormExpandState.Collapse);

			loadExporters();

            worker = new BackgroundWorker();
            worker.DoWork += Worker_DoWork;
            worker.RunWorkerCompleted += Worker_RunWorkerCompleted;
        }

        private void initMogre()
        {
            Mogre.Root root = new Mogre.Root("", "", "MainForm.log");

            root.LoadPlugin("RenderSystem_Direct3D9");
            root.LoadPlugin("Plugin_OctreeSceneManager");
            root.LoadPlugin("Plugin_CgProgramManager");

            Mogre.RenderSystem renderSystem = root.GetRenderSystemByName("Direct3D9 Rendering Subsystem");
            root.RenderSystem = renderSystem;

            root.Initialise(false);
        }

        private void loadExporters()
        {
            cmbOutputType.Items.Clear();
            convetExporters = new List<IMeshConvetExporter>();
            string ExporterFolder = "Exporters";
            string fullPath = Path.Combine(Environment.CurrentDirectory, ExporterFolder);
            DirectoryInfo di = new DirectoryInfo(fullPath);
            foreach (var fsi in di.EnumerateFiles())
            {
                if (fsi.Extension == ".dll")
                {
                    try
                    {
                        Assembly assembly = Assembly.LoadFile(fsi.FullName);
                        var assemblyTypes = assembly.GetTypes();
                        for (int i = 0; i < assemblyTypes.Length; i++)
                        {
                            var assemblyType = assemblyTypes[i];
                            if (assemblyType.GetInterface("IMeshConvetExporter") != null)
                            {
                                IMeshConvetExporter meshConvetExporter = assembly.CreateInstance(assemblyType.FullName) as IMeshConvetExporter;
                                convetExporters.Add(meshConvetExporter);
                                cmbOutputType.Items.Add(meshConvetExporter);
                            }
                        }
                    }
                    catch { continue; }
                }
            }

            if(cmbOutputType.Items.Count > 0)
            {
                cmbOutputType.SelectedIndex = 0;
            }
        }

        private void btnBrowseMesh_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Ogre3d Mesh|*.mesh";
            if(dialog.ShowDialog() == DialogResult.OK)
            {
                txtOgreMesh.Text = dialog.FileName;
            }
        }

        private void btnBrowseObj_Click(object sender, EventArgs e)
        {
            IMeshConvetExporter meshConvetExporter = cmbOutputType.SelectedItem as IMeshConvetExporter;

            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = string.Format("{0}|*.{1}",meshConvetExporter.Description, meshConvetExporter.TypeName);
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                txtExportFile.Text = dialog.FileName;
            }
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            if (!File.Exists(txtOgreMesh.Text))
            {
                UIMessageDialog.ShowErrorDialog(this, "Please select a valid Ogre3d mesh file!", UIStyle.Blue);
                return;
            }

            if (string.IsNullOrEmpty(txtExportFile.Text))
			{
				UIMessageDialog.ShowErrorDialog(this, "Please select a valid export directory!", UIStyle.Blue);
                return;
			}

			currentSelectedExporter = cmbOutputType.SelectedItem as IMeshConvetExporter;
			currentSelectedExporter.ReportExportMessage += CurrentSelectedExporter_ReportExportMessage;

            if (expander.CurrentExpandState == FormExpandState.Collapse)
            {
                btnDetailsExpander_Click(sender, e);
            }

			loadingForm = new frmLoading();
            loadingForm.Show();

            btnConvert.Enabled = false;
            worker.RunWorkerAsync();
        }

		private void CurrentSelectedExporter_ReportExportMessage(string message)
		{
            txtOutputMessage.AppendText(message);
		}

		private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            DirectoryInfo di = new DirectoryInfo(txtOgreMesh.Text);

            initMogre();

            ResourceGroupManager.Singleton.AddResourceLocation(di.Parent.FullName, "FileSystem", "General");
            ResourceGroupManager.Singleton.InitialiseAllResourceGroups();

            try
            {
                MeshPtr mesh = MeshManager.Singleton.Load(Path.GetFileName(txtOgreMesh.Text), "General");
                ((IMeshConvetExporter)cmbOutputType.SelectedItem).Export(mesh, txtExportFile.Text);
                e.Result = true;
            }
            catch
            {
				UIMessageDialog.ShowErrorDialog(this, "Unspported Ogre3d Mesh Version!", UIStyle.Blue);
                e.Result = false;
            }
		}

		private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			loadingForm.Close();
			btnConvert.Enabled = true;
            currentSelectedExporter.ReportExportMessage -= CurrentSelectedExporter_ReportExportMessage;
            currentSelectedExporter = null;

			if ((bool)e.Result)
			{
				UIMessageDialog.ShowMessageDialog(this, "Export Done!", "Notice", false, UIStyle.Blue);
			}
		}

		private void cmbOutputType_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnBrowseExport.Enabled = true;
        }

		private void btnDetailsExpander_Click(object sender, EventArgs e)
		{
            expander.ToggleExpand();
            switch(expander.CurrentExpandState)
            {
                case FormExpandState.Expand:
                    btnDetailsExpander.Text = "Details <<";
                    break;
                case FormExpandState.Collapse:
					btnDetailsExpander.Text = "Details >>";
					break;
            }
		}
	}
}
