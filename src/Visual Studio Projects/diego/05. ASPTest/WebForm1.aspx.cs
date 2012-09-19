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
		protected System.Web.UI.HtmlControls.HtmlInputText Text1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Button Button2;
		protected System.Web.UI.WebControls.TextBox TextBox1;
		protected InworxControlsLib.SuperGrid SuperGrid1;
		protected System.Web.UI.WebControls.Button Button3;
		protected System.Web.UI.WebControls.Button Button4;
		protected Cabecera Cabecera1;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if (!IsPostBack)
			{
				Label1.Text = User.Identity.Name;
                Cabecera1.Title = Cabecera1.Title + " - Bienvenido";
				SuperGrid1.TextChange +=new EventHandler(SuperGrid1_TextChange);
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
			this.Button2.Click += new System.EventHandler(this.Button2_Click);
			this.Button3.Click += new System.EventHandler(this.Button3_Click);
			this.Button4.Click += new System.EventHandler(this.Button4_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void Button1_Click(object sender, System.EventArgs e)
		{
		  Label1.Text = TextBox1.Text;
		  StreamReader Sr = File.OpenText(@"c:\aaa.txt");
		  string str = Sr.ReadToEnd();
			Sr.Close();
		  Label2.Text = str;
		  Trace.Warn("User", User.Identity.Name);
		}

		private void Button2_Click(object sender, System.EventArgs e)
		{
			System.Web.Security.FormsAuthentication.SignOut();
		}

		private void Button3_Click(object sender, System.EventArgs e)
		{
			SuperGrid1.Rows++;
		}

		private void Button4_Click(object sender, System.EventArgs e)
		{
           if (SuperGrid1.Rows > 1)
	         SuperGrid1.Rows--;
		}

		private void SuperGrid1_TextChange(object sender, EventArgs e)
		{

		}
	}
}
