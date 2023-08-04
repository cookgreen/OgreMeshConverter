using Mogre;
using OgreMeshConverter;
using OgreMeshConverter.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OgreMeshObjConverter
{
    public class OgreMeshObjConverter : IMeshConvetExporter
    {
        public string TypeName { get { return "obj"; } }

        public string Description { get { return "OBJ Model File"; } }

        public void Export(MeshPtr mesh, string outputFileName)
        {
            List<Vector3> vData;
            List<Vector3> vnData;
            List<Vector3> vtData;
            List<uint> iData;
            readMeshVertexDataAndIndexData(mesh, out vData, out vnData, out vtData, out iData);

            generateObjFile(vData, vnData, vtData, iData, outputFileName);
        }


        private void readMeshVertexDataAndIndexData(MeshPtr mesh, out List<Vector3> vData, out List<Vector3> vnData, out List<Vector3> vtData, out List<uint> iData)
        {
            StaticMeshData staticMeshData = new StaticMeshData(mesh);
            vData = staticMeshData.Vertices.ToList();
            vnData = staticMeshData.Norms.ToList();
            vtData = staticMeshData.TextureCoords.ToList();
            iData = staticMeshData.Indices.ToList();
        }

        private void generateObjFile(
            List<Vector3> vData,
            List<Vector3> vnData,
            List<Vector3> vtData,
            List<uint> iData,
            string outputFileName)
        {
            if (File.Exists(outputFileName))
                File.Delete(outputFileName);

            var writer = File.CreateText(outputFileName);

            for (int i = 0; i < vData.Count; i++)
            {
                var v = vData[i];
                writer.WriteLine(string.Format("v {0} {1} {2}", v.x, v.y, v.z));
            }

            for (int i = 0; i < vnData.Count; i++)
            {
                var vn = vnData[i];
                writer.WriteLine(string.Format("vn {0} {1} {2}", vn.x, vn.y, vn.z));
            }

            for (int i = 0; i < vtData.Count; i++)
            {
                var vt = vtData[i];
                writer.WriteLine(string.Format("vt {0} {1} {2}", vt.x, vt.y, vt.z));
            }

            int iLength = iData.Count / 3;
            for (int i = 0; i < iLength; i++)
            {
                uint v1 = iData[i * 3 + 0];
                uint v2 = iData[i * 3 + 1];
                uint v3 = iData[i * 3 + 2];

                writer.WriteLine(string.Format(
                    "f {0}/{3}/{6} {1}/{4}/{7} {2}/{5}/{8}",
                    v1 + 1, v2 + 1, v3 + 1,
                    v1 + 1, v2 + 1, v3 + 1,
                    v1 + 1, v2 + 1, v3 + 1));
            }

            writer.Dispose();
        }
    }
}
