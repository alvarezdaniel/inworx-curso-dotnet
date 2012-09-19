using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace ViewsWindowsApplication
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.DataGrid dataGrid1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
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
			this.button1 = new System.Windows.Forms.Button();
			this.dataGrid1 = new System.Windows.Forms.DataGrid();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(200, 16);
			this.button1.Name = "button1";
			this.button1.TabIndex = 0;
			this.button1.Text = "button1";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// dataGrid1
			// 
			this.dataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.dataGrid1.DataMember = "";
			this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid1.Location = new System.Drawing.Point(16, 56);
			this.dataGrid1.Name = "dataGrid1";
			this.dataGrid1.Size = new System.Drawing.Size(324, 228);
			this.dataGrid1.TabIndex = 1;
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(352, 302);
			this.Controls.Add(this.dataGrid1);
			this.Controls.Add(this.button1);
			this.Name = "Form1";
			this.Text = "Form1";
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
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

		private void button1_Click(object sender, System.EventArgs e)
		{
			DataSet ds = new DataSet();

			ds.Tables.Add(CreateMaster());
			ds.Tables.Add(CreateDetails());

			DataView dv;
			dv = ds.Tables[0].DefaultView;
			dv.Sort = "Nombre";
			dv.RowFilter = "Nombre LIKE 'D%'";
			dataGrid1.DataSource = dv;
			ds.WriteXml(@"C:\aa.xml");
			ds.Tables[0].Constraints.Add("PK_CODIGO", ds.Tables[0].Columns["Codigo"], true);
			DataRow dr = ds.Tables[0].Rows.Find("4");
			MessageBox.Show(dr["Nombre"].ToString());
			DataRow[] rows = ds.Tables[0].Select("Codigo > '2'");
//			DataSet ds2 = ds.Clone();
//			ds2.Tables[0].Rows.Add(rows[0]);
//			ds2.Tables[0].Rows.Add(rows[1]);
//			ds2.EnforceConstraints = false;
			DataRelation rel = new DataRelation("Relacion1", 
				ds.Tables[0].Columns["Codigo"], 
ds.Tables[1].Columns["Codigo"]);
			ds.Relations.Add(rel);
			rows = ds.Tables[0].Rows[0].GetChildRows("Relacion1");
		}

		private DataTable CreateMaster()
		{
			DataTable dt;
			DataColumn dc;

			dt = new DataTable("Participantes");
			dc = new DataColumn("Codigo", Type.GetType("System.String"));
			dt.Columns.Add(dc);
			dc = new DataColumn("Nombre", Type.GetType("System.String"));
			dt.Columns.Add(dc);
			dt.Rows.Add(new object[] { "1", "Alejandro" });
			dt.Rows.Add(new object[] { "2", "Daniel" });
			dt.Rows.Add(new object[] { "3", "Carlos" });
			dt.Rows.Add(new object[] { "4", "Bernardo" });
			return dt;
		}

		private DataTable CreateDetails()
		{
			DataTable dt;
			DataColumn dc;

			dt = new DataTable("Notas");
			dc = new DataColumn("Codigo", Type.GetType("System.String"));
			dt.Columns.Add(dc);
			dc = new DataColumn("Nota", Type.GetType("System.Int32"));
			dt.Columns.Add(dc);
			dt.Rows.Add(new object[] { "1", 3 });
			dt.Rows.Add(new object[] { "1", 9 });
			dt.Rows.Add(new object[] { "1", 8 });
			dt.Rows.Add(new object[] { "2", 4 });
			dt.Rows.Add(new object[] { "3", 3 });
			dt.Rows.Add(new object[] { "3", 5 });
			dt.Rows.Add(new object[] { "3", 8 });
			dt.Rows.Add(new object[] { "3", 4 });
			dt.Rows.Add(new object[] { "3", 7 });
			dt.Rows.Add(new object[] { "4", 2 });
			dt.Rows.Add(new object[] { "4", 6 });
			return dt;
		}
	}
}











