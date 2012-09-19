using System;
using System.Drawing;
using System.Collections;

namespace ScribbleLib
{
	/// <summary>
	/// Summary description for Trazo.
	/// </summary>
	[Serializable()]
	public class Trazo
	{
		private ArrayList puntos;
		private Color color;
		private float width;

		public Trazo(Color Color, float Width)
		{
			puntos = new ArrayList();
			color = Color;
			width = Width;
		}

		public void Add(Point punto)
		{
			puntos.Add(punto);
		}

		public void Draw(Graphics g)
		{
			Pen pen = new Pen(color, width);
			for (int i = 1; i < puntos.Count; i++)
			{
				g.DrawLine(pen, 
					(Point) puntos[i-1], 
					(Point) puntos[i]);
			}
		}
	}
}











