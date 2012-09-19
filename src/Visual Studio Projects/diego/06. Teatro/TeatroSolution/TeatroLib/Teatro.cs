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
		private bool[,] reservas;    // Array bidimensional

		public Teatro(int filas, int asientosPorFila, string obra)
		{
			this.filas = filas;
			this.asientosPorFila = asientosPorFila;
			this.obra = obra;
			reservas = new bool[filas, asientosPorFila];
			for (int i=0; i < filas; i++)
				for (int j=0; j < asientosPorFila; j++)
					reservas[i,j] = false;
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
		public string Obra
		{
			get { return obra; }
			set { obra = value; }
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
				// Hace la reserva
				reservas[Fila, Asiento] = true;   
				
				// Llama al evento
				if (Reservado != null)
				    Reservado(this, new ReservadoEventArgs(obra, Fila, Asiento, AsientosLibres()));			
			}
			else
			{
				if (Rechazado != null)
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

		public int AsientosOcupados()
		{
			int c=0;
			for (int i=0; i < filas; i++)
				for (int j=0; j < asientosPorFila; j++)
					if (reservas[i,j])
						c++;
			return c;
		}

		public int AsientosLibres()
		{
			int c=0;
			for (int i=0; i < filas; i++)
				for (int j=0; j < asientosPorFila; j++)
					if (!reservas[i,j])
						c++;
			return c;
		}

		// Clases para manejo de argumentos de eventos
		#region ReservadoEventArgs
		public class ReservadoEventArgs: EventArgs
		{
			private int fila, asiento;
			private string obra;
			private int asientosLibres;
			
			public ReservadoEventArgs(string Obra, int Fila, int Asiento, int AsientosLibres)
			{
				obra = Obra;
				fila = Fila;
				asiento = Asiento;
				asientosLibres = AsientosLibres;
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
		#endregion 	
		
		#region RechazadoEventArgs
		public class RechazadoEventArgs: EventArgs
		{
			private int fila, asiento;
			private string obra;
			
			public RechazadoEventArgs(string Obra, int Fila, int Asiento)
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
		
		#endregion
		
		// Declaracion de delegados
		public delegate void ReservadoEventHandler(object sender, ReservadoEventArgs e);
		public delegate void RechazadoEventHandler(object sender, RechazadoEventArgs e);
		
		// Declaracion de eventos
		public event ReservadoEventHandler Reservado;
		public event RechazadoEventHandler Rechazado;
	}
}
