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
using System.IO;

namespace ASPTest
{
	/// <summary>
	/// Summary description for WebForm1.
	/// </summary>
	public class WebForm1 : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Button Button1;
		protected System.Web.UI.WebControls.TextBox TextBox1;
		protected InworxControlsLib.SuperGrid SuperGrid1;
		protected System.Web.UI.WebControls.Button Button2;
		protected Cabecera Cabecera1;

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if (!IsPostBack)
			{
				Label1.Text = User.Identity.Name;
				Cabecera1.Title = "Mi Pagina";
			}
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
			this.Button1.Click += new System.EventHandler(this.Button1_Click);
			this.SuperGrid1.TextChanged += new InworxControlsLib.SuperGrid.TextChangedEventHandler(this.SuperGrid1_TextChanged);
			this.Button2.Click += new System.EventHandler(this.Button2_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void Button1_Click(object sender, System.EventArgs e)
		{
			Label1.Text = TextBox1.Text;
			StreamReader sr = File.OpenText(@"C:\aaa.txt");
			string s = sr.ReadToEnd();
			sr.Close();
			Label1.Text = s;
			Trace.Warn("Usuario", User.Identity.Name);
		}

		private void Button2_Click(object sender, System.EventArgs e)
		{
			SuperGrid1.Rows++;
		}

		private void SuperGrid1_TextChanged(object sender, InworxControlsLib.SuperGrid.TextChangedEventArgs e)
		{
			Label1.Text = string.Format("TextChanged at [{0},{1}]", e.Row, e.Col);
		}
	}
}









