using System;
using System.Data;
using System.Data.SqlClient;

namespace AuthorsDemo
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
			string connString = "server=localhost;database=pubs;user=sa;pwd=inworx";
			SqlConnection con = new SqlConnection(connString);
			SqlDataAdapter adapter = new SqlDataAdapter("select * from authors", con);
			DataSet datos = new DataSet();
			adapter.Fill(datos, "AUTORES");

			foreach(DataRow fila in datos.Tables["AUTORES"].Rows)
				Console.WriteLine( fila[0].ToString() + "\t" + fila[1].ToString() );

			Console.ReadLine();
		}
	}
}
