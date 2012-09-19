using System;

namespace Inworx.Banco.Modelo
{
	/// <summary>
	/// Summary description for Cuenta.
	/// </summary>
	public class Cuenta
	{
		private int numero;
		private float saldo;
		private float saldoMinimo = 150f;

		public Cuenta(int numero, float saldo)
		{
			this.saldo = saldo;
		}

		internal void Depositar(float monto)
		{
			saldo += monto;
		}

		internal void Extraer(float monto)
		{
			saldo -= monto;
		}

		internal int Numero
		{
			get { return numero; }
		}

		internal float Saldo()
		{
			return saldo;
		}
	}
}
