using System;
using System.Collections;

namespace Inworx.Banco.Modelo
{
	/// <summary>
	/// Summary description for Banco.
	/// </summary>
	public class Banco
	{
		private Hashtable cuentas;

		public Banco()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public void TransferirFondos(Cuenta origen, Cuenta destino, float monto)
		{
			GetCuenta(origen.Numero).Extraer(monto);
			GetCuenta(destino.Numero).Depositar(monto);
		}

		public IList GetCuentas()
		{
			return cuentas.Values;
		}

		public Cuenta GetSaldo(Cuenta cuenta)
		{
			return GetCuenta(cuenta.Numero).Saldo();
		}

		private Cuenta GetCuenta(int numero)
		{
			return (Cuenta)cuentas[numero];
		}

		public void Deposito(Cuenta cuenta, float monto)
		{
			GetCuenta(cuenta.Numero).Depositar(monto);
		}

		public void Extraccion(Cuenta cuenta, float monto)
		{
			GetCuenta(cuenta.Numero).Extraer(monto);
		}
	}
}
