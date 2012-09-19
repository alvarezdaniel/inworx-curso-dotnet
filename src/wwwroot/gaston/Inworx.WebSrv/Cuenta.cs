using System;

namespace BankService
{
	/// <summary>
	/// Summary description for Cuenta.
	/// </summary>
	public class Cuenta
	{
		private int id;
		private string titular;
		private float saldo;

		public Cuenta()
		{
			saldo = 0;
			id = 0;
			titular = "";
		}

		public Cuenta(int Id, string Titular, float Saldo)
		{
			id = Id;
			saldo = Saldo;
			titular = Titular;
		}

		public void Depositar(float Monto)
		{
			saldo += Monto;
		}


		public void Extraer(float Monto)
		{
			saldo -= Monto;
		}

		public float Saldo
		{
			get{return saldo;}
		}

		public string Titular
		{
			get{return titular;}
			set{titular=value;}
		}
	}
}
