using System;
using System.Data;
using System.Data.SqlClient;

namespace AdoNetTest.ReadDataSet
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
			SqlConnection con;
			SqlDataAdapter da;
			DataSet ds;
			SqlCommand cmd;
			SqlDataReader reader;

			try
			{
				//Comun
				con = new SqlConnection("server=192.168.131.65;database=pubs;user=sa;pwd=inworx");
				//con = new SqlConnection("server=192.168.0.75;database=pubs;user=sa;pwd=inworx");

				//Desconectada
				Console.WriteLine("Modo Desconectado\n");
				da = new SqlDataAdapter("select * from authors", con);
				ds = new DataSet();
				da.Fill(ds);
				foreach (DataRow dr in ds.Tables[0].Rows)
				{
					Console.WriteLine(dr["au_lname"].ToString());
				}
				Console.ReadLine();
				//Conectada
				Console.WriteLine("Modo Conectado\n");
				con.Open();
				try
				{
					cmd = new SqlCommand("select * from authors", con);
					reader = cmd.ExecuteReader(); 
					while (reader.Read())
					{
						int i = reader.GetOrdinal("au_lname");
						Console.WriteLine(reader.GetString(i));
					}
				}
				finally
				{
					con.Close();
				}
				Console.ReadLine();
			}
			catch(SqlException ex)
			{
					Console.WriteLine(string.Format("Error: {0} \nCallStack: {1}",
						ex.Message, ex.StackTrace.ToString()));
			}
			

		}
	}
}
