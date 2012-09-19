using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;

namespace InworxControlsLib
{

	public class TextChangedEventArgs : EventArgs
	{
		private int row, col;

		public TextChangedEventArgs(int row, int col)
		{
			this.row = row;
			this.col = col;
		}

		public
	}

	/// <summary>
	/// Summary description for SuperGrid.
	/// </summary>
	[ToolboxData("<{0}:SuperGrid runat=server></{0}:SuperGrid>")]
	public class SuperGrid : System.Web.UI.WebControls.WebControl, IPostBackEventHandler
	{
		private int rows = 1;
		private int cols = 1;
		private Table table;

		protected override object SaveViewState()
		{
			object baseState = base.SaveViewState();
			object[] allStates = new object[4];
			allStates[0] = baseState;
			allStates[1] = cols;
			allStates[2] = rows;
/*			if ((rows > 0) && (cols > 0))
			{
*/
				allStates[3] = new object[rows];
				for (int i = 0; i < table.Rows.Count; i++)
				{
					((object[])allStates[3])[i] = new object[cols];
					for (int j = 0; j < table.Rows[i].Cells.Count; j++)
					{
						//((object[])((object[])allStates[3])[i])[j] = ((TextBox) table.Rows[i].Cells[j].Controls[0]).Text;
					}
				}
/*			}
			else
				allStates[3] = null;
*/
			return allStates;
		}

		protected override void LoadViewState(object savedState)
		{
			if (savedState != null)
			{
				object[] myState = (object[]) savedState;
				if (myState[0] != null)
					base.LoadViewState(myState[0]);
				if (myState[1] != null)
					Cols = int.Parse(myState[1].ToString());
				if (myState[2] != null)
					Rows = int.Parse(myState[2].ToString());

				if (myState[3] != null)
				{
					for (int i = 0; (i < ((object[])myState[3]).Length) && (i < table.Rows.Count); i++)
					{
						for (int j = 0; (j < ((object[])((object[])myState[3])[i]).Length) && (j < table.Rows[i].Cells.Count); j++)
						{
							if (table.Rows[i].Cells[j].Controls.Count == 1)
							{
								//((TextBox) table.Rows[i].Cells[j].Controls[0]).Text = ((object[]) ((object[])myState[3]) [i])[j].ToString();
							}
						}
					}
				}
			}
		}

		public delegate void TextChangedEventHandler(object sender, TextChangedEventArgs e);
		public event TextChangedEventHandler TextChanged;

		private void updateControl()
		{
			TableRow tr;
			TableCell td;
			TextBox tb;

			table = new Table();
			table.BorderWidth = new Unit("1");
			table.Width = new Unit("100%");
			table.CellPadding = 0;
			table.CellSpacing = 0;
			for (int i = 0; i < rows; i++)
			{
				tr = new TableRow();
				for (int j = 0; j < cols; j++)
				{
					td = new TableCell();
					string jsBlk  = "javascript: " + Page.GetPostBackEventReference(this, string.Format("[{0}, {1}]", i, j));
					//td.Text = string.Format("{0, 1}", i, j);
					tb = new TextBox();
					tb.Width = new Unit("100%");
					tb.Attributes["onchange"] = jsBlk;
					td.Controls.Add(tb);
					tr.Cells.Add(td);
				}
				table.Rows.Add(tr);
			}
			Controls.Clear();
			Controls.Add(table);
		}

		public SuperGrid()
		{
			//updateControl();
			this.Load += new EventHandler(SuperGrid_Load);
		}

		[Category("Appearance"), DefaultValue("1")]
		public int Rows
		{
			get { return rows; }
			set 
			{ 
				rows = value;	
				//updateControl();
			}
		}

		[Category("Appearance"), DefaultValue("1")]
		public int Cols
		{
			get { return cols; }
			set 
			{ 
				cols = value;	
				//updateControl();
			}
		}

		/// <summary>
		/// Render this control to the output parameter specified.
		/// </summary>
		/// <param name="output"> The HTML writer to write out to </param>
		/*
		protected override void Render(HtmlTextWriter output)
		{
			output.Write(string.Format("{0},{1}", rows, cols));
		}
		*/

		private void SuperGrid_Load(object sender, EventArgs e)
		{
			updateControl();
		}
		#region IPostBackEventHandler Members

		public void RaisePostBackEvent(string eventArgument)
		{
			// TODO:  Add SuperGrid.RaisePostBackEvent implementation
			int row, col;
		
			if (TextChanged != null)
			{
					
			}
		}

		#endregion

	}
}
