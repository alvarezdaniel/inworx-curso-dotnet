using System;
using System.Collections;
using System.Drawing;

namespace GraficadorLib
{
	/// <summary>
	/// Summary description for Trazo.
	/// </summary>
    [Serializable()]
    public class Trazo
    {
        //atributos
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
                g.DrawLine(pen, (Point)puntos[i-1], (Point)puntos[i]);
        }
    }
}
