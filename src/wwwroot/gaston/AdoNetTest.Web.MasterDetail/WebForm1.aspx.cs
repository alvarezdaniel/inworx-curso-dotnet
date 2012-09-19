using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace AdoNetTest.Web.MasterDetail
{
	/// <summary>
	/// Summary description for WebForm1.
	/// </summary>
	public class WebForm1 : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DataGrid TitlesGrid;
		protected System.Web.UI.WebControls.DropDownList AuthorsList;
	
		private DataSet ds;
		private void Page_Load(object sender, System.EventArgs e)
		{
			ds = new DataSet();

			SqlConnection con;
			SqlDataAdapter da;
			con = new SqlConnection("server=192.168.131.65;database=pubs;user=sa;pwd=inworx");

			if (! IsPostBack)
			{
				// Put user code to initialize the page here

				//Traigo los autores
				da = new SqlDataAdapter("select * from authors", con);
				da.Fill(ds, "Authors");			
				AuthorsList.DataSource = ds.Tables["Authors"];
				AuthorsList.DataTextField = "au_fname";
				AuthorsList.DataValueField = "au_id";
				AuthorsList.DataBind();

				/*authorsList.DataBindings.Add(
					"SelectedValue",
					ds,
					"Authors.au_id");*/
			}
			//Traigos los libros
			da = new SqlDataAdapter("select titles.*, titleauthor.au_id from titles, titleauthor where titles.title_id = titleauthor.title_id" +
				" and au_id = '" + AuthorsList.SelectedValue + "'", con);
			da.Fill(ds, "Titles");

			TitlesGrid.DataSource = ds.Tables["Titles"];
			TitlesGrid.DataBind();
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
			this.AuthorsList.SelectedIndexChanged += new System.EventHandler(this.AuthorsList_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void AuthorsList_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			/*DataView dv = ds.Tables["Titles"].DefaultView;
			dv.RowFilter = "au_id = '" + AuthorsList.SelectedValue + "'";*/
		}

		
	}
}
