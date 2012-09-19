using System;
using System.Collections;
using System.Drawing;

namespace ScribbleLib
{
	/// <summary>
	/// Summary description for Trazo.
	/// </summary>
	[Serializable()]
	public class Trazo
	{
		/*[NonSerialized()]*/ private ArrayList puntos;
		private Color color;
		private float width;

		public Trazo(Color Color, float Width)
		{
			puntos = new ArrayList();
			color = Color;
			width = Width;
		}

		//public ColorTrazo; 

		public void Add(Point punto)
		{
			puntos.Add(punto);
		}

		public void Draw(Graphics g)
		{
			Pen pen = new Pen(color, width);

			/*//Correcci�m por �nico punto
			if (puntos.Count == 1)
				g.DrawLine(pen, (Point)puntos[0], (Point)puntos[0]);*/

			for (int i = 1; i < puntos.Count; i++)
			{
				g.DrawLine(pen, (Point)puntos[i - 1], (Point)puntos[i]);
			}
		}
	}
}
