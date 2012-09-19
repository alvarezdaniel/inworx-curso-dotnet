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
			Teatro teatrin;

			teatrin = new Teatro(13, 16, "La vaca");
			teatrin.Reservado += new TeatroLib.Teatro.ReservadoEventHandler(teatrin_Reservado);
			teatrin.Reservado += new TeatroLib.Teatro.ReservadoEventHandler(teatrin_Reservado1);
			teatrin.Rechazado += new TeatroLib.Teatro.RechazadoEventHandler(teatrin_Rechazado);

			while (true)
			{
				Console.Write("Por favor, ingrese fila: ");
				string s1 = Console.ReadLine();
				int row = int.Parse(s1);
				Console.Write("Por favor, ingrese asiento: ");
				string s2 = Console.ReadLine();
				int col = int.Parse(s2);

				teatrin.ReservarAsiento(row, col);
				/*
				if (teatrin.EstaLibre(row, col))
				{
					teatrin.ReservarAsiento(row, col);
					Console.WriteLine("Reservado!!!");
				}
				else
				{
					Console.WriteLine("Cagaste!!!");
				}
				*/
			}	
		}

		private static void teatrin_Reservado(object Sender, TeatroLib.Teatro.ReservadoEventArgs e)
		{
			Console.WriteLine(string.Format("Reservado. Quedan {0} asientos libres.", e.AsientosLibres));
		}

		private static void teatrin_Reservado1(object Sender, TeatroLib.Teatro.ReservadoEventArgs e)
		{
			Console.WriteLine(string.Format("Reservado. Quedan {0} asientos libres. Pancho!!!", e.AsientosLibres));
		}

		private static void teatrin_Rechazado(object Sender, TeatroLib.Teatro.RechazadoEventArgs e)
		{
			Console.WriteLine("Cagaste!!!");
		}
	}
}
