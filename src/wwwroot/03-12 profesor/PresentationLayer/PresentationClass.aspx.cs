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
using BusinessLayer;
using ServiceLayer;

namespace PresentationLayer
{
	/// <summary>
	/// Summary description for PresentationClass.
	/// </summary>
	public class PresentationClass : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if (!IsPostBack)
			{
				try
				{
					reloadData();
				}
				catch (InworxException ex)
				{
					Response.Redirect("Error.aspx?msg=" + 
						Server.UrlEncode(ex.Message));
				}
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
			this.DataGrid1.CancelCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid1_CancelCommand);
			this.DataGrid1.EditCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid1_EditCommand);
			this.DataGrid1.UpdateCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid1_UpdateCommand);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void reloadData()
		{
			BusinessClass biz;
			biz = new BusinessClass();
			DataGrid1.DataSource = biz.GetData();
			DataGrid1.DataBind();
		}

		private void DataGrid1_EditCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			DataGrid1.EditItemIndex = e.Item.ItemIndex;
			reloadData();
		}

		private void DataGrid1_UpdateCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			// realizar cambios
			string id, fname, lname;
			id = e.Item.Cells[0].Text;
			fname = ((TextBox) (e.Item.Cells[1].Controls[0])).Text;
			lname = ((TextBox) (e.Item.Cells[2].Controls[0])).Text;
			Author a = new Author(id);
			a.LastName = lname;
			a.FirstName = lname;
			a.Update();
			DataGrid1.EditItemIndex = -1;
			reloadData();	
		}

		private void DataGrid1_CancelCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			DataGrid1.EditItemIndex = -1;
			reloadData();		
		}
	}
}




