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
			//updateControl();
			this.Load += new EventHandler(SuperGrid_Load);
		}

		public class TextChangedEventArgs : EventArgs
		{
			private int row, col;

			public TextChangedEventArgs(int Row, int Col)
			{
				row = Row;
				col = Col;
			}

			public int Row
			{
				get { return row; }
				set { row = value; }
			}

			public int Col
			{
				get { return col; }
				set { col = value; }
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
					string jsBlk = "javascript: " + Page.GetPostBackEventReference(this, string.Format("[{0},{1}]", i, j));
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

		[Category("Appearance"), DefaultValue(3)]
		public int Rows
		{
			get
			{
				return rows;
			}

			set
			{
				rows = value;
				//updateControl();
			}
		}


		[Category("Appearance"), DefaultValue(3)]
		public int Cols
		{
			get
			{
				return cols;
			}

			set
			{
				cols = value;
				//updateControl();
			}
		}

		private void SuperGrid_Load(object sender, EventArgs e)
		{
			updateControl();
		}

		protected override object SaveViewState()
		{
			object[] a = new object[3];
			a[0] = base.SaveViewState();
			a[1] = rows;
			a[2] = cols;
			return a;
		}

		protected override void LoadViewState(object savedState)
		{
			object[] a;
			if (savedState != null)
			{
				a = (object[]) savedState;
				base.LoadViewState(a[0]);
				rows = int.Parse(a[1].ToString());
				cols = int.Parse(a[2].ToString());
			}
		}
		#region IPostBackEventHandler Members

		public void RaisePostBackEvent(string eventArgument)
		{
			// TODO:  Add SuperGrid.RaisePostBackEvent implementation
			int row, col;
			row = int.Parse(eventArgument.Substring(1,1));
			col = int.Parse(eventArgument.Substring(3,1));
			if (TextChanged != null)
			{
				TextChanged(this, new TextChangedEventArgs(row, col));
			}
		}

		#endregion
	}
}








