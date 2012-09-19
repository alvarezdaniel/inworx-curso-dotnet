using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Web;
using System.Web.Services;

namespace BankService
{
	/// <summary>
	/// Summary description for BankService.
	/// </summary>
	public class BankService : System.Web.Services.WebService
	{
		public BankService()
		{
			//CODEGEN: This call is required by the ASP.NET Web Services Designer
			InitializeComponent();
		}

		#region Component Designer generated code
		
		//Required by the Web Services Designer 
		private IContainer components = null;
				
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if(disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);		
		}
		
		#endregion

		// WEB SERVICE EXAMPLE
		// The HelloWorld() example service returns the string Hello World
		// To build, uncomment the following lines then save and build the project
		// To test this web service, press F5

		[WebMethod]
		public string TransferirFondos(string NroCuentaOrigen, 
			string NroCuentaDestino, float Monto)
		{
			Banco banco = new Banco();
			Cuenta cuentaOrigen = banco.GetCuenta(int.Parse(NroCuentaOrigen));
			Cuenta cuentaDestino = banco.GetCuenta(int.Parse(NroCuentaDestino));
			banco.Transferir(
				cuentaOrigen, 
				cuentaDestino, 
				Monto);
			return cuentaOrigen.ToString() + " => " + cuentaDestino.ToString();
		}
		[WebMethod]
		public string Depositar(string NroCuenta, float Monto)
		{
			Banco banco = new Banco();
			Cuenta cuenta = banco.GetCuenta(int.Parse(NroCuenta));
			cuenta.Depositar(Monto);
			return cuenta.ToString();
		}

		[WebMethod]
		public string Extraer(string NroCuenta, float Monto)
		{
			Banco banco = new Banco();
			Cuenta cuenta = banco.GetCuenta(int.Parse(NroCuenta));
			cuenta.Extraer(Monto);
			return cuenta.ToString();
		}

		[WebMethod]
		public string ObtenerSaldo(string NroCuenta)
		{
			Banco banco = new Banco();
			Cuenta cuenta = banco.GetCuenta(int.Parse(NroCuenta));
			return cuenta.Saldo.ToString();
		}
	}
}
