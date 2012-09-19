using System;

namespace BankService
{
	/// <summary>
	/// Summary description for Banco.
	/// </summary>
	public class Banco
	{
		public Banco()
		{
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
			Cuenta cuenta = new Cuenta();
			cuenta.Titular = Titular;
			cuenta.Depositar(SaldoInicial);
			return cuenta;
		}
	}
}
