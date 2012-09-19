using System;
using System.Data;
using System.Data.SqlClient;


namespace AdoNetTest.ExecuteSTP
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
			SqlCommand cmd;
			SqlParameter param;
			try
			{
				con = new SqlConnection("server=192.168.131.65;database=pubs;user=sa;pwd=inworx");
				cmd = new SqlCommand();
				cmd.Connection = con;
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "InsertEnMiTabla";

				//Descripcion
				param = new SqlParameter("@Descripcion", SqlDbType.VarChar, 50);
				param.Direction = ParameterDirection.Input;
				param.Value = "Hola don Pepito";
				cmd.Parameters.Add(param);

				UpdateStatus.

				//Return value
				param = new SqlParameter("@RETURN_VALUE", SqlDbType.Int);
				param.Direction = ParameterDirection.ReturnValue;
				cmd.Parameters.Add(param);

				con.Open();
				try
				{
					cmd.ExecuteNonQuery();
					int id;
					string sRetValue;

					sRetValue = cmd.Parameters[cmd.Parameters.IndexOf("@RETURN_VALUE")].Value.ToString();
					id = int.Parse(sRetValue);
					Console.WriteLine(string.Format("Se ha generado el registro {0}", id));
				}
				finally
				{
					con.Close();
				}
			}
			catch(SqlException ex)
			{
				Console.WriteLine(string.Format("Error: {0} \nCallStack: {1}",
					ex.Message, ex.StackTrace.ToString()));
				Console.ReadLine();
			}
		}
	}
}
