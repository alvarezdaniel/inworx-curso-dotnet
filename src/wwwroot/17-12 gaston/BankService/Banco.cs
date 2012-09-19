using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;

namespace BankService
{
	/// <summary>
	/// Summary description for Banco.
	/// </summary>
	public class Banco
	{
		private Hashtable cuentas;

		public Banco()
		{
			cuentas = new Hashtable();
		}

		public void Extraer(Cuenta cuenta, float Monto)
		{
			cuenta.Extraer(Monto);
		}

		public void Depositar(Cuenta cuenta, float Monto)
		{
			cuenta.Depositar(Monto);
		}

		public void Transferir(Cuenta cuentaOrigen, Cuenta cuentaDestino, float Monto)
		{
			cuentaOrigen.Extraer(Monto);
			cuentaDestino.Depositar(Monto);
		}

		public Cuenta CrearCuenta(string Titular, float SaldoInicial)
		{
			SqlConnection con;
			SqlCommand cmd;

			con = new SqlConnection("server=.;database=inworxbank;user=sa;password=inworx");
			cmd = new SqlCommand(
				string.Format("insert into cuentas (titular, saldo) values ('{0}',{1})",
					Titular, SaldoInicial), con);
			int count = cmd.ExecuteNonQuery();


			Cuenta cuenta = new Cuenta();
			cuenta.Titular = Titular;
			cuenta.Depositar(SaldoInicial);
			return cuenta;
		}

		public Cuenta GetCuenta(int NroCuenta)
		{
			SqlConnection con;
			SqlDataAdapter da;
			DataSet ds;


			con = new SqlConnection("server=.;database=inworxbank;user=sa;password=inworx");
			da = new SqlDataAdapter("select * from cuentas", con);
			ds = new DataSet();
			da.Fill(ds);

			ds.HasChanges(DataRowState.

			/*DataView dv;

			dv = ds.Tables[0].DefaultView;
			dv.RowFilter = "id=" + NroCuenta.ToString();
			*/
			Cuenta cuenta;
			DataRow[] rows = ds.Tables[0].Select("Id = " + NroCuenta.ToString());
			if (rows.Length == 0)
			{
				cuenta = CrearCuenta("Default", "0");
			}
			else
			{
				string titular;
				float saldo;
				titular = rows[0]["Titular"].ToString();
				saldo = float.Parse(rows[0]["Saldo"].ToString());
				cuenta = new Cuenta(NroCuenta, titular, saldo);
			}

			return cuenta
		}
	}
}
