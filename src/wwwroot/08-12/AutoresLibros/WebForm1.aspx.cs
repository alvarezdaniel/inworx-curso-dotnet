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
using System.Data.SqlClient;

namespace AutoresLibros
{
	/// <summary>
	/// Summary description for WebForm1.
	/// </summary>
	public class WebForm1 : System.Web.UI.Page
	{
        protected System.Web.UI.WebControls.DropDownList DropDownList1;
        protected System.Web.UI.WebControls.Label Label2;
        protected System.Web.UI.WebControls.DataGrid DataGrid1;
    
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
            if (!IsPostBack)
            {
                CargarDatos();
            }
		}

        private void CargarDatos()
        {
            SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=pubs;User ID=sa;Password=INWORX");
            SqlDataAdapter da_ma = new SqlDataAdapter("select * from Authors", conn);
            DataSet ds = new DataSet();
            da_ma.Fill(ds, "Autores");
            
            DropDownList1.DataSource = ds.Tables[0];
            DropDownList1.DataTextField = "au_lname";
            DropDownList1.DataValueField = "au_id";
            DropDownList1.DataBind();
            
            CargarDetalles(DropDownList1.SelectedValue);
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
            this.DropDownList1.SelectedIndexChanged += new System.EventHandler(this.DropDownList1_SelectedIndexChanged);
            this.Load += new System.EventHandler(this.Page_Load);

        }
		#endregion

        private void DropDownList1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            //
            Label2.Text = DropDownList1.SelectedValue;
            CargarDetalles(DropDownList1.SelectedValue);
        }
        
        private void CargarDetalles(string Au_id)
        {
            SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=pubs;User ID=sa;Password=INWORX");
            SqlDataAdapter da_de = new SqlDataAdapter("select titleauthor.au_id, titles.* from titles, titleauthor " + 
                "where titles.title_id = titleauthor.title_id " + 
                "and au_id = '" + Au_id + "'", conn);
            DataSet ds = new DataSet();
            da_de.Fill(ds, "Libros");
            
            DataGrid1.DataSource = ds.Tables[0];
            DataGrid1.DataBind();
        }
	}
}
