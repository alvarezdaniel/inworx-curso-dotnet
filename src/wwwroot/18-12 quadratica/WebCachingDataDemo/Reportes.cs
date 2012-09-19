using System;
using System.Data;
using System.Data.SqlClient;

namespace WebCachingDataDemo
{
	/// <summary>
	/// Summary description for Reportes.
	/// </summary>
	public class Reportes
	{
		private DataTable EjecutarConsulta(string sql)
		{
			SqlConnection con = new SqlConnection("server=localhost;user=sa;pwd=inworx;database=northwind");
			SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
			DataTable datos = new DataTable();
			adapter.Fill(datos);
			return datos;
		}

		public DataTable GetEmpleados()
		{
			return EjecutarConsulta("select EmployeeID, FirstName, LastName from Employees");
		}

		public DataTable GetTerritoriosPorEmpleado(string empID)
		{
			return EjecutarConsulta("select t.* from Territories t, EmployeeTerritories et where t.TerritoryID=et.TerritoryID and et.EmployeeID=" + empID);
		}
	}
}
