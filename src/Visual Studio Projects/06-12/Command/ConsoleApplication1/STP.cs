using System;
using System.Data;
using System.Data.SqlClient;

namespace STP
{
	/// <summary>
	/// Summary description for STP.
	/// </summary>
	class STP
	{
		public void Ejecutar()
        {
            SqlConnection con = null;
            SqlCommand co = null;
            SqlParameter par = null;
            try
            {
                con = new SqlConnection("Data Source=.; Initial catalog=pubs; User ID=sa; Password=inworx");
                co = new SqlCommand();
                co.Connection = con;
                co.CommandType = CommandType.StoredProcedure;
                co.CommandText = "InsertMiTabla";
                par = new SqlParameter("@descripcion", SqlDbType.VarChar, 50);
                par.Direction = ParameterDirection.Input;
                par.Value = "PEPE";
                co.Parameters.Add(par);
                par = new SqlParameter("@RETURN_VALUE", SqlDbType.Int);
                par.Direction = ParameterDirection.ReturnValue;
                co.Parameters.Add(par);
                con.Open();
                co.ExecuteNonQuery();
                int i = int.Parse(co.Parameters["@RETURN_VALUE"].Value.ToString());
                Console.WriteLine("numero generado: " + i.ToString());
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

        /// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
            STP stp = new STP();
            stp.Ejecutar();
		}
	}
}
