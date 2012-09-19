using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using ServiceLayer;

namespace DataLayer
{
	/// <summary>
	/// Summary description for AuthorDALC.
	/// </summary>
	public class AuthorDALC
	{
		public AuthorDALC()
		{
		}

		public void Update(string Id, string LastName, string FirstName)
		{
			SqlConnection con = null;
			SqlCommand cmd;
			string cs, sql;

			cs = ConfigurationSettings.AppSettings["ConnectionString"]; 

			sql = "UPDATE authors SET au_lname='{1}', au_fname='{2}' WHERE au_id='{0}'";
			sql = string.Format(sql, Id, FirstName, LastName);

			try
			{
				con = new SqlConnection(cs);
				cmd = new SqlCommand(sql, con);
				con.Open();
				cmd.ExecuteNonQuery();
			}
			catch (SqlException ex)
			{
				InworxException ex2;
				ex2 = new InworxException("Error en DataLayer.AuthorDALC.Update", 
					ex, true);
				throw ex2;
			}
			finally
			{
				con.Close();
			}
		}

		public void GetData(string Id, out string LastName, out string FirstName)
		{
			SqlConnection con;
			SqlDataAdapter da;
			DataSet ds;
			string cs, sql;

			cs = ConfigurationSettings.AppSettings["ConnectionString"]; 

			sql = "SELECT * FROM authors WHERE au_id='{0}'";
			sql = string.Format(sql, Id);

			try
			{
				con = new SqlConnection(cs);
				da = new SqlDataAdapter(sql, con);
				ds = new DataSet();
				da.Fill(ds);
				FirstName = ds.Tables[0].Rows[0]["au_fname"].ToString();
				LastName = ds.Tables[0].Rows[0]["au_lname"].ToString();
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
