using System;
using System.Collections;
using System.Drawing;

namespace GraficadorLib
{
	/// <summary>
	/// Summary description for Dibujo.
	/// </summary>
	[Serializable()]
	public class Dibujo
	{
        //atributos
        private ArrayList trazos;        

		public Dibujo()
		{
            trazos = new ArrayList();
		}

        public void Add(Trazo trazo)
        {
            trazos.Add(trazo);
        }

        public void Draw(Graphics g)
        {   
            foreach (Trazo trazo in trazos)
            {
                trazo.Draw(g);
            }
        }
        
        public void Clear()
        {
            trazos = new ArrayList();
        }
	}
}
