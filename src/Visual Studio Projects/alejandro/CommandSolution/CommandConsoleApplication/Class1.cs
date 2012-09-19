using System;
using System.Data;
using System.Data.SqlClient;

namespace CommandConsoleApplication
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
			SqlConnection con = null;
			SqlCommand cmd;
			SqlParameter par;
			string cs;
			int n;

			try
			{
				cs = "Data Source=.;Initial Catalog=pubs;" + 
					"User ID=sa;Password=inworx";
				con = new SqlConnection(cs);
				cmd = new SqlCommand();
				cmd.Connection = con;
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "InsertEnMiTabla";
				// Defino el parametro de ingreso
				par = new SqlParameter("@Descripcion", SqlDbType.VarChar, 50);
				par.Direction = ParameterDirection.Input;
				par.Value = "Hola";
				cmd.Parameters.Add(par);
				// Defino el return value
				par = new SqlParameter("@RETURN_VALUE", SqlDbType.Int);
				par.Direction = ParameterDirection.ReturnValue;
				cmd.Parameters.Add(par);
				con.Open();
				cmd.ExecuteNonQuery();
				n = (int)(cmd.Parameters["@RETURN_VALUE"].Value);
			}
			catch (SqlException ex)
			{
				Console.WriteLine("Error: " + ex.Message);
			}
			finally
			{
				con.Close();
			}
		}
	}
}




