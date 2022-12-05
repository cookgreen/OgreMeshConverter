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

namespace OgreMeshConverter
{
    public partial class frmMain : Form
    {
        private BackgroundWorker worker;
        private List<IMeshConvetExporter> convetExporters;

        public frmMain()
        {
            InitializeComponent();

            convetExporters = new List<IMeshConvetExporter>();

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
                MessageBox.Show("Please select a valid Ogre3d mesh file!");
                return;
            }

            if (string.IsNullOrEmpty(txtExportFile.Text))
            {
                MessageBox.Show("Please select a valid export directory!");
                return;
            }

            btnConvert.Enabled = false;
            worker.RunWorkerAsync();
        }

        private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnConvert.Enabled = true;

            if ((bool)e.Result)
            {
                MessageBox.Show("Done!");
            }
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
            }
            catch
            {
                MessageBox.Show("Unspported Ogre3d Mesh Version!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Result = false;
            }
        }

        private void cmbOutputType_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnBrowseExport.Enabled = true;
        }
    }
}
