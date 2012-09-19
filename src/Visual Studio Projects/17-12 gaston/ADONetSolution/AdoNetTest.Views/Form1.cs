using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace AdoNetTest.Views
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
			this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.button1.Location = new System.Drawing.Point(16, 232);
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
			this.dataGrid1.Location = new System.Drawing.Point(8, 8);
			this.dataGrid1.Name = "dataGrid1";
			this.dataGrid1.Size = new System.Drawing.Size(272, 216);
			this.dataGrid1.TabIndex = 1;
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(292, 266);
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
			DataSet ds;
			ds = new DataSet();
			DataTable dt = new DataTable("Participantes");
			DataColumn dc;
			dc = new DataColumn("Codigo", Type.GetType("System.String"));
			dt.Columns.Add(dc);
			dc = new DataColumn("Nombre", Type.GetType("System.String"));
			dt.Columns.Add(dc);
			ds.Tables.Add(dt);
			ds.Tables[0].Rows.Add(new object[]{"1", "Alejandro"});
			ds.Tables[0].Rows.Add(new object[]{"2", "Fernando"});
			ds.Tables[0].Rows.Add(new object[]{"3", "Daniel"});
			ds.Tables[0].Rows.Add(new object[]{"4", "Pepe"});

			/*Dandole el dataset, se debe seleccionar el table dentro
			de la grilla*/
			//dataGrid1.DataSource = ds;

			/*Dandole directamente la tabla, no es necesaria la selección*/
			//dataGrid1.DataSource = ds.Tables[0];

			/*La vista extiende la funcionalidad de la tabla*/
			/*Toma la vista default de la tabla*/
			DataView dv;
			dv = ds.Tables[0].DefaultView;
			dv.Sort = "Nombre";
			dv.RowFilter = "Nombre like '%and%'";

			//Persistencia de datos | schema
			ds.WriteXmlSchema("c:\\squemita.xsd");
			ds.WriteXml("c:\\data.xsd", XmlWriteMode.DiffGram);

			dataGrid1.DataSource = ds.Tables[0].DefaultView;

			//Primary key + find (el find requiere una pk definida)
			ds.Tables[0].Constraints.Add("PKParticipantes",
				ds.Tables[0].Columns["Codigo"], true);
			DataRow dr = ds.Tables[0].Rows.Find("4");
			MessageBox.Show(dr["Nombre"].ToString());
			//Busca por expresion
			DataRow[] rows = ds.Tables[0].Select("Codigo > '2'");
			
			//Clona la estructura, no los datos
			DataSet ds2 = ds.Clone();
			//El EnforceConstraints determina si se chequean constraints
			ds2.EnforceConstraints = false;
			try
			{
				foreach (DataRow dr2 in rows)
					ds2.Tables[0].ImportRow(dr2);
				dataGrid1.DataSource = ds2.Tables[0];
			}
			finally
			{
				ds2.EnforceConstraints = true;
			}

			//ds2.Tables[0].TableName = "Participantes";
			dt = new DataTable("Notas");
			dc = new DataColumn("Codigo", Type.GetType("System.String"));
			dt.Columns.Add(dc);
			dc = new DataColumn("Nota", Type.GetType("System.Single"));
			dt.Columns.Add(dc);
			ds.Tables.Add(dt);
			dt.Rows.Add(new object[]{"3", "9"});
			dt.Rows.Add(new object[]{"4", "10"});

			DataTable referencia;
			referencia = ds.Tables["Participantes"];
			referencia = ds.Tables["Notas"];

			dv.RowFilter = "";

			/*Relaciones de datos*/

			/*DataRelation rel = new DataRelation("Relacion1",
				"Participantes", "Notas",
				new string[] {"Codigo"}, 
				new string[] {"Codigo"}, 
				true);

			ds.Relations.AddRange(new DataRelation[]{rel});*/
			

			DataRelation rel = new DataRelation("Relacion1",
				ds.Tables[0].Columns["Codigo"],
				ds.Tables[1].Columns["Codigo"]);

			ds.Relations.Add(rel);

			dataGrid1.DataSource = ds.Tables[0];
		}
	}
}
