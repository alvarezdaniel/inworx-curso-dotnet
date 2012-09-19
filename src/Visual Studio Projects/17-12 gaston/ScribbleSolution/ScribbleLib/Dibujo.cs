using System;
using System.Collections;
using System.Drawing;

namespace ScribbleLib
{
	/// <summary>
	/// Summary description for Dibujo.
	/// </summary>
	[Serializable()]
	public class Dibujo/*: System.Runtime.Serialization.ISerializable*/
	{
		//private Queue trazos;
		//private Stack trazos;
		//private Hashtable trazos;
		/*[NonSerialized()] */private ArrayList trazos;

		public Dibujo()
		{
			/*
			//----Hasttable----
			trazos = new Hashtable();
			trazos.Add(12, true);
			trazos.Add("Hola", DateTime.Today);
			//Internamente se le llama al GetHashCode del objeto para obtener
			//el entero como clave.
			object pipo = trazos["Hola"];
			if (trazos.ContainsKey("Hola"));
			if (trazos.Contains("Hola"))
			{
				trazos.ContainsValue("Chau");
				trazos.Remove("Hola");
				trazos.Add("Hola", "Chau");
			}
			
			//----Queue----
			trazos = new Queue();
			trazos.EnQueue(1);
			object obj = trazos.DeQueue();
			
			//----Stack----
			trazos = new Stack();
			trazos.Push(1);
			object obj = trazos.Pop();*/

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
			trazos.Clear();
		}
	}
}
