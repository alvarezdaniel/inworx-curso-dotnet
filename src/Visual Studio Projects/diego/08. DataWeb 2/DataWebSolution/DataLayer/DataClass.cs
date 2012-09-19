using System;
using System.Data;
using System.Data.SqlClient;
using ServiceLayer;
using System.Configuration;

namespace DataLayer
{
	/// <summary>
	/// Summary description for DataClass.
	/// </summary>
	/// Accede a los datos via ADO.NET
	public class DataClass
	{
		public DataClass()
		{
		}

		// Devuelve un dataset con los datos de la base
		public DataSet GetData()
		{
			SqlConnection con;
			SqlDataAdapter da;
			DataSet ds;
			string cs, sql;

			// String de conexion a la base de datos
			//cs = "Data Source=.; Initial catalog=pubs; User ID=sa; Password=inworx";
            cs = ConfigurationSettings.AppSettings["ConnectionString"];

			// SQL a ejecutar
			sql = "SELECT * FROM authors";

			try
			{
				con = new SqlConnection(cs);
				da = new SqlDataAdapter(sql, con);
				ds = new DataSet();
				da.Fill(ds); //Aca se abre la conexion implicitamente                
				return ds;
			}
			catch (SqlException ex)
			{
                InworxException ie = new InworxException("Error en DataLayer - " + ex.Message + " - " + ex.StackTrace, ex, true);
                throw ie;
				return null;
			}
			finally
			{
			}
		}
	}
}
