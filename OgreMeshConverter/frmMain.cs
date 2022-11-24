using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mogre;

namespace OgreMeshConverter
{
    public partial class frmMain : Form
    {
        private BackgroundWorker worker;

        public frmMain()
        {
            InitializeComponent(); 

            worker = new BackgroundWorker();
            worker.DoWork += Worker_DoWork;
            worker.RunWorkerCompleted += Worker_RunWorkerCompleted;
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
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Obj file|*.obj";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                txtObjFile.Text = dialog.FileName;
            }
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            if (!File.Exists(txtOgreMesh.Text))
                return;

            btnConvert.Enabled = false;
            worker.RunWorkerAsync();
        }

        private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnConvert.Enabled = true;
            MessageBox.Show("Done!");
        }

        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            Mogre.Root root = new Mogre.Root("", "", "MainForm.log");

            root.LoadPlugin("RenderSystem_Direct3D9");
            root.LoadPlugin("Plugin_OctreeSceneManager");
            root.LoadPlugin("Plugin_CgProgramManager");

            Mogre.RenderSystem renderSystem = root.GetRenderSystemByName("Direct3D9 Rendering Subsystem");
            root.RenderSystem = renderSystem;

            root.Initialise(false);

            DirectoryInfo di = new DirectoryInfo(txtOgreMesh.Text);

            ResourceGroupManager.Singleton.AddResourceLocation(di.Parent.FullName, "FileSystem", "General");
            ResourceGroupManager.Singleton.InitialiseAllResourceGroups();

            MeshPtr mesh = MeshManager.Singleton.Load(Path.GetFileName(txtOgreMesh.Text), "General");

            MeshToObj(mesh, txtObjFile.Text);
        }

        private void MeshToObj(MeshPtr mesh, string outputFileName)
        {
            DirectoryInfo di = new DirectoryInfo(outputFileName);

            List<Vector3> vData;
            List<uint> iData;
            readMeshVertexDataAndIndexData(mesh, out vData, out iData);

            generateObjFile(vData, iData, outputFileName);
        }

        private void readMeshVertexDataAndIndexData(MeshPtr mesh, out List<Vector3> vData, out List<uint> iData)
        {
            StaticMeshData staticMeshData = new StaticMeshData(mesh);
            vData = staticMeshData.Vertices.ToList();
            iData = staticMeshData.Indices.ToList();
        }

        private void generateObjFile(List<Vector3> vData, List<uint> iData, string outputFileName)
        {
            if (File.Exists(outputFileName))
                File.Delete(outputFileName);

            var writer = File.CreateText(outputFileName);

            for(int i = 0; i < vData.Count; i++)
            {
                var v = vData[i];
                writer.WriteLine(string.Format("v {0} {1} {2}", v.x, v.y, v.z));
            }

            int iLength = iData.Count / 3;
            for (int i = 0; i < iLength; i++)
            {
                uint i1 = iData[i * 3 + 0];
                uint i2 = iData[i * 3 + 1];
                uint i3 = iData[i * 3 + 2];

                Vector3 v1 = vData[(int)i1];
                Vector3 v2 = vData[(int)i2];
                Vector3 v3 = vData[(int)i3];

                writer.WriteLine(string.Format("f {0} {1} {2}", i1 + 1, i2 + 1, i3 + 1));
            }

            writer.Dispose();
        }
    }
}
