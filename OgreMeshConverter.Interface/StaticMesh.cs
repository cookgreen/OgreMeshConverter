﻿using Mogre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OgreMeshConverter
{
	public class StaticMeshData
	{
		private Vector3[] vertices;
        private Vector3[] norms;
        private Vector3[] texturecoords;
        private uint[] indices;
		private MeshPtr meshPtr;
		private Vector3 scale = Vector3.UNIT_SCALE;

		public float[] Points
		{
			get
			{
				// extract the points out of the vertices
				float[] points = new float[this.Vertices.Length * 3];
				int i = 0;

				foreach (Vector3 vertex in this.Vertices)
				{
					points[i + 0] = vertex.x;
					points[i + 1] = vertex.y;
					points[i + 2] = vertex.z;
					i += 3;
				}

				return points;
			}
		}

		public Vector3[] Vertices
		{
			get
			{
				return this.vertices;
			}
        }

        public Vector3[] Norms
        {
            get
            {
                return this.norms;
            }
        }

        public Vector3[] TextureCoords
        {
            get
            {
                return this.texturecoords;
            }
        }

        public uint[] Indices
		{
			get
			{
				return this.indices;
			}
		}

		public int TriangleCount
		{
			get
			{
				return this.indices.Length / 3;
			}
		}

		public StaticMeshData(MeshPtr meshPtr)
		{
			Initiliase(meshPtr, Vector3.UNIT_SCALE);
		}

		public StaticMeshData(MeshPtr meshPtr, float unitScale)
		{
			Initiliase(meshPtr, Vector3.UNIT_SCALE * unitScale);
		}

		public StaticMeshData(MeshPtr meshPtr, Vector3 scale)
		{
			Initiliase(meshPtr, scale);
		}

		private void Initiliase(MeshPtr meshPtr, Vector3 scale)
		{
			this.scale = scale;
			this.meshPtr = meshPtr;

			PrepareBuffers();
			ReadData();
		}

		private void ReadData()
		{
			int indexOffset = 0;
			uint vertexOffset = 0;

			// read the index and vertex data from the mesh
			for (ushort i = 0; i < meshPtr.NumSubMeshes; i++)
			{
				SubMesh subMesh = meshPtr.GetSubMesh(i);

				indexOffset = ReadIndexData(indexOffset, vertexOffset, subMesh.indexData);

				if (subMesh.useSharedVertices == false)
					vertexOffset = ReadVertexData(vertexOffset, subMesh.vertexData);
			}

			// add the shared vertex data
			if (meshPtr.sharedVertexData != null)
				vertexOffset = ReadVertexData(vertexOffset, meshPtr.sharedVertexData);
		}

		private void PrepareBuffers()
		{
			uint indexCount = 0;
			uint vertexCount = 0;

			// Add any shared vertices
			if (meshPtr.sharedVertexData != null)
				vertexCount = meshPtr.sharedVertexData.vertexCount;

			// Calculate the number of vertices and indices in the sub meshes
			for (ushort i = 0; i < meshPtr.NumSubMeshes; i++)
			{
				SubMesh subMesh = meshPtr.GetSubMesh(i);

				// we have already counted the vertices that are shared
				if (subMesh.useSharedVertices == false)
					vertexCount += subMesh.vertexData.vertexCount;

				indexCount += subMesh.indexData.indexCount;
			}

			// Allocate space for the vertices and indices
			vertices = new Vector3[vertexCount];
			norms = new Vector3[vertexCount];
			texturecoords = new Vector3[vertexCount];
			indices = new uint[indexCount];
		}

		private unsafe uint ReadVertexData(uint vertexOffset, VertexData vertexData)
		{
			VertexElement posElem = vertexData.vertexDeclaration.FindElementBySemantic(VertexElementSemantic.VES_POSITION);
            VertexElement normanElem = vertexData.vertexDeclaration.FindElementBySemantic(VertexElementSemantic.VES_NORMAL);
            VertexElement textcoordElem = vertexData.vertexDeclaration.FindElementBySemantic(VertexElementSemantic.VES_TEXTURE_COORDINATES);
            
			float* pElem;
            float* nElem;
            float* tElem;

            HardwareVertexBufferSharedPtr vertexBuffer = vertexData.vertexBufferBinding.GetBuffer(posElem.Source);
            HardwareVertexBufferSharedPtr vertexNormalBuffer = vertexData.vertexBufferBinding.GetBuffer(normanElem.Source);
            HardwareVertexBufferSharedPtr vertexTextureCoordBuffer = vertexData.vertexBufferBinding.GetBuffer(textcoordElem.Source);
			
			byte* vertexMemory = (byte*)vertexBuffer.Lock(HardwareBuffer.LockOptions.HBL_READ_ONLY);
            byte* vertexNormMemory = (byte*)vertexNormalBuffer.Lock(HardwareBuffer.LockOptions.HBL_READ_ONLY);
            byte* vertexTextureCoordMemory = (byte*)vertexTextureCoordBuffer.Lock(HardwareBuffer.LockOptions.HBL_READ_ONLY);

            for (uint i = 0; i < vertexData.vertexCount; i++)
			{
				posElem.BaseVertexPointerToElement(vertexMemory, &pElem);
                normanElem.BaseVertexPointerToElement(vertexNormMemory, &nElem);
                textcoordElem.BaseVertexPointerToElement(vertexTextureCoordMemory, &tElem);

                Vector3 point = new Vector3(pElem[0], pElem[1], pElem[2]);
				vertices[vertexOffset] = point * this.scale;
                Vector3 norm = new Vector3(nElem[0], nElem[1], nElem[2]);
				norms[vertexOffset] = norm;
                Vector3 texturecoord = new Vector3(tElem[0], tElem[1], tElem[2]);
				texturecoords[vertexOffset] = texturecoord;

                vertexMemory += vertexBuffer.VertexSize;
                vertexNormMemory += vertexNormalBuffer.VertexSize;
                vertexTextureCoordMemory += vertexTextureCoordBuffer.VertexSize;

                vertexOffset++;
			}

			vertexBuffer.Unlock();
			vertexNormalBuffer.Unlock();
			vertexTextureCoordBuffer.Unlock();

            return vertexOffset;
		}
		private unsafe int ReadIndexData(int indexOffset, uint vertexOffset, IndexData indexData)
		{
			// get index data
			HardwareIndexBufferSharedPtr indexBuf = indexData.indexBuffer;
			HardwareIndexBuffer.IndexType indexType = indexBuf.Type;
			uint* pLong = (uint*)(indexBuf.Lock(HardwareBuffer.LockOptions.HBL_READ_ONLY));
			ushort* pShort = (ushort*)pLong;

			for (uint i = 0; i < indexData.indexCount; i++)
			{
				if (indexType == HardwareIndexBuffer.IndexType.IT_32BIT)
					indices[indexOffset] = pLong[i] + vertexOffset;
				else
					indices[indexOffset] = pShort[i] + vertexOffset;

				indexOffset++;
			}

			indexBuf.Unlock();
			return indexOffset;
		}
	}
}
