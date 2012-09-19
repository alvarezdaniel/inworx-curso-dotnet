using System;
using TeatroLib;

namespace Reservas
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	class Class1
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
			Teatro teatro;
			teatro = new Teatro("La vaca", 13, 16);
			teatro.Reservado += new TeatroLib.Teatro.ReservadoEventHandler(teatro_Reservado);
			teatro.Rechazado += new TeatroLib.Teatro.RechazadoEventHandler(teatro_Rechazado);
			while (true)
			{
				Console.Write("Fila=");
				string s1 = Console.ReadLine();
				int row = int.Parse(s1);
				Console.Write("Asiento=");
				string s2 = Console.ReadLine();
				int col = int.Parse(s2);
				teatro.ReservarAsiento(row, col);
				Console.WriteLine();
			}


			//
			// TODO: Add code to start application here
			//
		}

		private static void teatro_Reservado(object sender, TeatroLib.Teatro.ReservadoEventArgs e)
		{
			Console.WriteLine(
				"Quedan {0} asientos libres", 
				e.AsientosLibres);
		}

		private static void teatro_Rechazado(object sender, TeatroLib.Teatro.RechazadoEventArgs e)
		{
			Console.WriteLine("Reserva rechazada");
		}
	}
}
