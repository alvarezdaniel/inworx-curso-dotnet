using System;
using TeatroLib;   // Para no tener que usar prefijo

namespace Reservas
{
	/// <summary>
	/// Summary description for TeatroUI.
	/// </summary>
	class TeatroUI
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
			Teatro teatro = new Teatro(13, 16, "La vaca");

			teatro.Reservado += new TeatroLib.Teatro.ReservadoEventHandler(teatro_Reservado);
			teatro.Rechazado += new TeatroLib.Teatro.RechazadoEventHandler(teatro_Rechazado);

			Console.WriteLine(
				String.Format(
					"Obra = {0}, espacio = {1} filas, {2} asientos", 
					teatro.Obra, teatro.Filas, teatro.Filas*teatro.AsientosPorFila));
			
			while (true)
			{
				Console.Write("Fila=");
				string s1 = Console.ReadLine();
				int row = int.Parse(s1);
				Console.Write("Asiento=");
				string s2 = Console.ReadLine();
				int col = int.Parse(s2);

				/*
				bool b = teatro.EstaLibre(row, col);
				if (b)
				{
					teatro.ReservarAsiento(row, col);
					Console.WriteLine("Reservado.");
				}
				else
				{
					Console.WriteLine("Ocupado.");
				}
				*/

				teatro.ReservarAsiento(row, col);
				
				//Console.WriteLine("Asientos ocupados = {0}", teatro.AsientosOcupados);
				Console.WriteLine();
			}
		}

		private static void teatro_Reservado(object sender, TeatroLib.Teatro.ReservadoEventArgs e)
		{
			Console.WriteLine("Reservado (Quedan {0} asientos libres)", e.AsientosLibres);
		}

		private static void teatro_Rechazado(object sender, TeatroLib.Teatro.RechazadoEventArgs e)
		{
			Console.WriteLine("Rechazado.");
		}
	}
}
