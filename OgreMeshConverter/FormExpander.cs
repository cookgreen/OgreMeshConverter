using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OgreMeshConverter
{
	public enum FormExpandState
	{
		Collapse,
		Expand,
	}

	public class FormExpander
	{
		private Form form;
		private int heightBeforeExpand;
		private int heightAfterExpand;
		private FormExpandState expandState;

		public FormExpandState CurrentExpandState { get { return expandState; } }

		public FormExpander(Form form, int heightBeforeExpand, int heightAfterExpand, FormExpandState initState)
		{
			this.form = form;
			this.heightBeforeExpand = heightBeforeExpand;
			this.heightAfterExpand = heightAfterExpand;
			expandState = initState;
		}

		public void ToggleExpand()
		{
			switch(expandState)
			{
				case FormExpandState.Collapse:
					form.Height = heightAfterExpand;
					expandState= FormExpandState.Expand;
					break;
				case FormExpandState.Expand:
					form.Height = heightBeforeExpand; 
					expandState= FormExpandState.Collapse;
					break;
			}
		}
	}
}
