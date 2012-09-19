using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace AdoNetTest.WinForms.MasterDetail
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ListBox authorsList;
		private System.Windows.Forms.DataGrid titlesGrid;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private DataSet ds;

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			ds = new DataSet();

			SqlConnection con;
			SqlDataAdapter da;

			con = new SqlConnection("server=192.168.131.65;database=pubs;user=sa;pwd=inworx");
			//Traigo los autores
			da = new SqlDataAdapter("select * from authors", con);
			da.Fill(ds, "Authors");			
			//Traigos los libros
			da = new SqlDataAdapter("select titles.*, titleauthor.au_id from titles, titleauthor where titles.title_id = titleauthor.title_id", con);
			da.Fill(ds, "Titles");

			authorsList.DataSource = ds.Tables["Authors"];
			authorsList.DisplayMember = "au_fname";
			authorsList.ValueMember = "au_id";
			authorsList.DataBindings.Add(
				"SelectedValue",
				ds,
				"Authors.au_id");

		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.label1 = new System.Windows.Forms.Label();
			this.authorsList = new System.Windows.Forms.ListBox();
			this.titlesGrid = new System.Windows.Forms.DataGrid();
			((System.ComponentModel.ISupportInitialize)(this.titlesGrid)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(72, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Author";
			// 
			// authorsList
			// 
			this.authorsList.Location = new System.Drawing.Point(96, 16);
			this.authorsList.Name = "authorsList";
			this.authorsList.Size = new System.Drawing.Size(176, 17);
			this.authorsList.TabIndex = 1;
			this.authorsList.SelectedValueChanged += new System.EventHandler(this.authorsList_DisplayValueChanged);
			// 
			// titlesGrid
			// 
			this.titlesGrid.DataMember = "";
			this.titlesGrid.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.titlesGrid.Location = new System.Drawing.Point(16, 48);
			this.titlesGrid.Name = "titlesGrid";
			this.titlesGrid.Size = new System.Drawing.Size(256, 200);
			this.titlesGrid.TabIndex = 2;
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(292, 266);
			this.Controls.Add(this.titlesGrid);
			this.Controls.Add(this.authorsList);
			this.Controls.Add(this.label1);
			this.Name = "Form1";
			this.Text = "Form1";
			((System.ComponentModel.ISupportInitialize)(this.titlesGrid)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		private void authorsList_DisplayValueChanged(object sender, System.EventArgs e)
		{
			DataView dv = ds.Tables["Titles"].DefaultView;
			dv.RowFilter = "au_id = '" + authorsList.SelectedValue + "'";
		}
	}
}
