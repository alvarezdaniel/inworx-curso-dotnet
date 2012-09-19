using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace BankServiceConsumer
{
	/// <summary>
	/// Summary description for Bankito.
	/// </summary>
	public class Bankito : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.LinkButton LinkButton1;
		protected System.Web.UI.WebControls.LinkButton LinkButton2;
		protected System.Web.UI.WebControls.TextBox txtCuenta;
		protected System.Web.UI.WebControls.TextBox txtSaldo;
		protected System.Web.UI.WebControls.LinkButton lbConsultarSaldo;
		protected System.Web.UI.WebControls.LinkButton LinkButton3;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.LinkButton1.Click += new System.EventHandler(this.Depositar_Click);
			this.lbConsultarSaldo.Click += new System.EventHandler(this.lbConsultarSaldo_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		public void Depositar_Click(object sender, EventArgs ev)
		{
			Response.Redirect("Deposito.aspx");
		}

		private void lbConsultarSaldo_Click(object sender, System.EventArgs e)
		{
			BankServiceWeb.BankService banquito = new BankServiceWeb.BankService();
			float saldo = float.Parse(banquito.ObtenerSaldo(txtCuenta.Text));
			txtSaldo.Text = saldo.ToString();
		}

	}
}
