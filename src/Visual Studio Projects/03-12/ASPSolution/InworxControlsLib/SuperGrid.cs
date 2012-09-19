using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;

namespace InworxControlsLib
{
	/// <summary>
	/// Summary description for SuperGrid.
	/// </summary>
	[ToolboxData("<{0}:SuperGrid runat=server></{0}:SuperGrid>")]
	public class SuperGrid : System.Web.UI.WebControls.WebControl, IPostBackEventHandler
	{
		private int rows, cols;
		private Table table;

		public SuperGrid()
		{
			rows = 3;
			cols = 3;
			UpdateControl();
			this.Load += new EventHandler(SuperGrid_Load);
		}
		
		private void UpdateControl()
		{
			table = new Table();
            TableRow tr;
			TableCell td;

			table.BorderWidth = new Unit(1);
			table.Width = new Unit("100%");
			table.CellPadding = 0;
			table.CellSpacing = 0;
			for (int i = 0; i < rows; i++)
			{
				tr = new TableRow();
				for (int j = 0; j < cols; j++)
				{
					td = new TableCell();
					td.Text = "<input type='text' onchange=\"javascript:\"" + Page.GetPostBackEventReference(this, "") + " />";
					tr.Cells.Add(td);
				}
				table.Rows.Add(tr);
			}
			Controls.Clear();
			Controls.Add(table);
		}

		[Category("Appearance"),
		 DefaultValue(3)]
		public int Rows
		{
			get
			{
				return rows;
			}

			set
			{
				rows = value;
				UpdateControl();
			}
		}

		[Category("Appearance"),
		DefaultValue(3)]
		public int Cols
		{
			get
			{
				return cols;
			}

			set
			{
				cols = value;
				UpdateControl();
			}
		}

		/// <summary>
		/// Render this control to the output parameter specified.
		/// </summary>
		/// <param name="output"> The HTML writer to write out to </param>
		/*protected override void Render(HtmlTextWriter output)
		{
			
			output.Write(string.Format("[{0}, {1}]", rows, cols));
		}*/
		protected override object SaveViewState()
		{
			//devuelvo un objeto que el framework lo guarda
			object baseState = base.SaveViewState();
			object[] allState = new object[3];
            allState[0] = baseState;
			allState[1] = rows;
			allState[2] = cols;
			/*
			int z = 3;
			int j = 0;
			for (int i = 0; i < rows; i++)
			{
				for (j = 0; j < cols; j++)
				{
   				  allState[z] = ((TextBox)(table.Rows[i].Cells[j].Controls[0])).Text;
				  z++;
				}
			}

			//allState[3] = cajas;
			*/
			return allState;
		}

		protected override void LoadViewState(object savedState)
		{
			if (savedState != null)
			{
				object[] myState = (object[])savedState;
				if (myState[0] != null)
				    base.LoadViewState(myState[0]);
				if (myState[1] != null)
					rows = (int)myState[1];
			    if (myState[2] != null)
					cols = (int)myState[2];
				/*
				if (myState[3] != null)
				{
					int z = 3;
					int j = 0;
					for (int i = 0; i < rows; i++)
					{
						for (j = 0; j < cols; j++)
						{
							((TextBox)(table.Rows[i].Cells[j].Controls[0])).Text = (string)myState[z];
							z++;
						}
					}
				}
				*/
			}
		}

		private void SuperGrid_Load(object sender, EventArgs e)
		{
          UpdateControl();
		}
		#region IPostBackEventHandler Members

		public event EventHandler TextChange;

		public void RaisePostBackEvent(string eventArgument)
		{
			// TODO:  Add SuperGrid.RaisePostBackEvent implementation
TextChange(this, EventArgs.Empty);
		}

		#endregion
	}
}
