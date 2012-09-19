using System;
using System.Data;
using System.Data.SqlClient;
using ServiceLayer;
using System.Configuration;
using System.Xml;

namespace DataLayer
{
	/// <summary>
	/// Summary description for DataClass.
	/// </summary>
	public class DataClass
	{

		public DataClass()
		{
		}

		public DataSet GetData()
		{
			SqlConnection con;
			SqlDataAdapter da;
			DataSet ds;
			string cs;

			//Data Source=. : mi maquina

			//Conexion fija
			//cs = "Data Source=.; Initial Catalog=pubs; User ID=sa; Password=inworx";
			
			//Conexion por settings
			cs = ConfigurationSettings.AppSettings["ConnectionString"];

			//XmlDocument doc = new XmlDocument();

			try
			{
				//Conexión
				con = new SqlConnection(cs);
				//Adapter
				da = new SqlDataAdapter("select * from authors", con);
				//Dataset & Fill
				//Fill hace open, tira el comando, llena el dataset y luego hace close
				ds = new DataSet();
				da.Fill(ds);
				return ds;
			}
			catch (SqlException ex)
			{
				InworxException ex2;
				ex2 = new InworxException("Error en GetData", ex, true);
				throw ex2;
			}
			finally
			{
			}
		}
	}
}
