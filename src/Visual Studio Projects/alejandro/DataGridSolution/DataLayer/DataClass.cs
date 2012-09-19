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
			string cs, sql;

			cs = ConfigurationSettings.AppSettings["ConnectionString"]; 

			sql = "SELECT * FROM authors";

			try
			{
				con = new SqlConnection(cs);
				da = new SqlDataAdapter(sql, con);
				ds = new DataSet();
				da.Fill(ds);
				return ds;
			}
			catch (SqlException ex)
			{
				InworxException ex2;
				ex2 = new InworxException("Error en DataLayer.GetData", 
					ex, true);
				throw ex2;
			}
			finally
			{
			}
		}
	}
}







