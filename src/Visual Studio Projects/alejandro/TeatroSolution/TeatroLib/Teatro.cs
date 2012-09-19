using System;

namespace TeatroLib
{
	/// <summary>
	/// Summary description for Teatro.
	/// </summary>
	public class Teatro
	{
		private int filas;
		private int asientosPorFila;
		private string obra;
		private bool[,] reservas;

		public Teatro(string Obra, int Filas, int AsientosPorFila)
		{
			obra = Obra;
			filas = Filas;
			asientosPorFila = AsientosPorFila;
			reservas = new bool[filas, asientosPorFila];
			for (int i = 0; i < filas; i++)
			{
				for (int j = 0; j < asientosPorFila; j++)
				{
					reservas[i, j] = false;
				}
			}
		}

		public string Obra
		{
			get { return obra; }
			set { obra = value; }
		}

		public int Filas
		{
			get { return filas; }
			set { filas = value; }
		}

		public int AsientosPorFila
		{
			get { return asientosPorFila; }
			set { asientosPorFila = value; }
		}

		public void ReservarAsiento(int Fila, int Asiento)
		{
			if (Fila < 0 || Fila >= filas)
			{
				return;
			}
			if (Asiento < 0 || Asiento >= asientosPorFila)
			{
				return;
			}
			if (EstaLibre(Fila, Asiento))
			{
				reservas[Fila, Asiento] = true;
				int n = 0;
				Reservado(this, new ReservadoEventArgs(obra, Fila, Asiento, n));
			}
			else
			{
				Rechazado(this, new RechazadoEventArgs(obra, Fila, Asiento));
			}
		}

		public bool EstaLibre(int Fila, int Asiento)
		{
			if (Fila < 0 || Fila >= filas)
			{
				return false;
			}
			if (Asiento < 0 || Asiento >= asientosPorFila)
			{
				return false;
			}
			return !reservas[Fila, Asiento];
		}

		public class ReservadoEventArgs: EventArgs
		{
			private string obra;
			private int fila, asiento;
			private int asientosLibres;

			public ReservadoEventArgs(string Obra, int Fila, 
				int Asiento, int AsientoLibres)
			{
				obra = Obra;
				fila = Fila;
				asiento = Asiento;
				asientosLibres = AsientoLibres;
			}

			public string Obra
			{
				get { return obra; }
			}

			public int Fila
			{
				get { return fila; }
			}

			public int Asiento
			{
				get { return asiento; }
			}

			public int AsientosLibres
			{
				get { return asientosLibres; }
			}
		}
		public class RechazadoEventArgs: EventArgs
		{
			private string obra;
			private int fila, asiento;

			public RechazadoEventArgs(string Obra, int Fila, 
				int Asiento)
			{
				obra = Obra;
				fila = Fila;
				asiento = Asiento;
			}

			public string Obra
			{
				get { return obra; }
			}

			public int Fila
			{
				get { return fila; }
			}

			public int Asiento
			{
				get { return asiento; }
			}
		}
		public delegate void ReservadoEventHandler(
			object sender, ReservadoEventArgs e);
		public delegate void RechazadoEventHandler(
			object sender, RechazadoEventArgs e);
		public event ReservadoEventHandler Reservado;
		public event RechazadoEventHandler Rechazado;
	}
}
















