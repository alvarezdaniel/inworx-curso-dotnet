namespace ASPTest
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;

	/// <summary>
	///		Summary description for Cabecera.
	/// </summary>
	public class Cabecera : System.Web.UI.UserControl
	{
		protected System.Web.UI.WebControls.Label TitleLabel;
		protected System.Web.UI.WebControls.Label DateLabel;
		protected System.Web.UI.WebControls.Label UserLabel;

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if (Request.UserLanguages.Length > 0)
			{
				System.Threading.Thread.CurrentThread.CurrentCulture = 
					new System.Globalization.CultureInfo(Request.UserLanguages[0]);
			}
			if (!IsPostBack)
			{
				UserLabel.Text = Page.User.Identity.Name;
				DateLabel.Text = DateTime.Today.ToShortDateString();
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
		///		Required method for Designer support - do not modify
		///		the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		public string Title
		{
			get { return TitleLabel.Text; }
			set { TitleLabel.Text = value; }
		}
	}
}






