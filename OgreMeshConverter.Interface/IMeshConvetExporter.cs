﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mogre;

namespace OgreMeshConverter.Interface
{
    public interface IMeshConvetExporter
	{
		event Action<string> ReportExportMessage;

		string TypeName { get; }
        string Description { get; }
        void Export(MeshPtr ogreMesh, string outputFileName);
    }
}
