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

namespace WebCachingDataDemo
{
	/// <summary>
	/// Summary description for EmpleadosPorTerritorio.
	/// </summary>
	public class EmpleadosPorTerritorio : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DropDownList DropDownList1;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			DataSet data = GetCacheData();

			if(!IsPostBack)
			{
				DropDownList1.DataValueField = data.Tables[0].Columns[0].ToString();
				DropDownList1.DataTextField = data.Tables[0].Columns[1].ToString();
				DropDownList1.DataSource = data.Tables[0];
				DropDownList1.DataBind();
			}
		}

		private DataSet GetCacheData()
		{
			DataSet data = (DataSet)Cache["data"];
			if(data == null)
			{

//				Reportes r = new Reportes();
//				data = new DataSet();
//				data.Tables.Add(r.GetEmpleados());
//				Cache.Insert("data", data, null, DateTime.Now.AddMinutes(30), System.TimeSpan.Zero);

				data = new DataSet();
				data.ReadXmlSchema(@"C:\temp\Empleados.xsd");
				data.ReadXml(@"C:\temp\Empleados.xml");
				Cache.Insert("data", data, null, DateTime.Now.AddMinutes(30), System.TimeSpan.Zero);

			}
			//SaveCacheEmpleados(data);

			return data;
		}

		private void SaveCacheEmpleados(DataSet emp)
		{
			emp.WriteXmlSchema(@"C:\temp\Empleados.xsd");
			emp.WriteXml(@"C:\temp\Empleados.xml", XmlWriteMode.DiffGram);
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
			Reportes r = new Reportes();
			DataTable dt = r.GetTerritoriosPorEmpleado(DropDownList1.SelectedValue);

			DataGrid1.DataSource = dt;
			DataGrid1.DataBind();
		}
	}
}
