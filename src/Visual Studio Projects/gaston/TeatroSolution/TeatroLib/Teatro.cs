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

		public Teatro(int filas, int asientosPorFila, string obra)
		{
			this.filas = filas;
			this.asientosPorFila = asientosPorFila;
			this.obra = obra;
			reservas = new bool[filas, asientosPorFila];
			for(int i = 0; i < filas; i++)
				for(int j = 0; j < asientosPorFila; j++)
					reservas[i, j] = false;
		}

		public int Filas
		{
			get { return filas; }
			set { filas = value; }
		}

		public int AsientosPorFila
		{
			get	{ return asientosPorFila; }
			set { asientosPorFila = value; }
		}

		public string Obra
		{
			get { return obra; }
			set { obra = value; }
		}

		public bool EstaLibre(int Fila, int Asiento)
		{
			if ((Fila < 0) || (Fila >= filas))
			{
				return false;
			}
			if ((Asiento < 0) || (Asiento >= asientosPorFila))
			{
				return false;
			}

			return !reservas[Fila, Asiento];
		}

		public int AsientosLibres()
		{
			int cant;
			cant = 0;
			for (int i = 0; i < filas; i++)
				for (int j = 0; j < asientosPorFila; j++)
					if (!reservas[i, j]) cant++;

			return cant;
		}

		public void ReservarAsiento(int Fila, int Asiento)
		{
			if ((Fila < 0) || (Fila >= filas))
			{
				return;
			}
			if ((Asiento < 0) || (Asiento >= asientosPorFila))
			{
				return;
			}

			if (EstaLibre(Fila, Asiento))
			{
				reservas[Fila, Asiento] = true;

				if (Reservado != null)
				{
					Reservado(this, new ReservadoEventArgs(obra, Fila, Asiento, AsientosLibres()));
				}
			}
			else
			{
				if (Rechazado != null)
				{
					Rechazado(this, new RechazadoEventArgs(obra, Fila, Asiento));
				}
			}
		}

		public class ReservadoEventArgs: EventArgs
		{
			private int fila;
			private int asiento;
			private string obra;
			private int libres;

			public ReservadoEventArgs(string Obra, int Fila, int Asiento, int AsientosLibres)
			{
				this.fila = Fila;
				this.asiento = Asiento;
				this.obra = Obra;
				this.libres = AsientosLibres;
			}

			public int Fila
			{
				get { return fila; }
			}

			public int Asiento
			{
				get { return asiento;}
			}

			public string Obra
			{
				get { return obra;}
			}

			public int AsientosLibres
			{
				get { return libres;}
			}
		}

		public class RechazadoEventArgs: EventArgs
		{
			private int fila;
			private int asiento;
			private string obra;

			public RechazadoEventArgs(string Obra, int Fila, int Asiento)
			{
				this.fila = Fila;
				this.asiento = Asiento;
				this.obra = Obra;
			}

			public int Fila
			{
				get { return fila; }
			}

			public int Asiento
			{
				get { return asiento;}
			}

			public string Obra
			{
				get { return obra;}
			}
		}
		public delegate void ReservadoEventHandler(object Sender, ReservadoEventArgs e);
		public delegate void RechazadoEventHandler(object Sender, RechazadoEventArgs e);
		public event ReservadoEventHandler Reservado;
		public event RechazadoEventHandler Rechazado;
	}
}
