using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace BindeoDatos
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
        private System.Data.SqlClient.SqlCommand sqlSelectCommand1;
        private System.Data.SqlClient.SqlCommand sqlInsertCommand1;
        private System.Data.SqlClient.SqlCommand sqlUpdateCommand1;
        private System.Data.SqlClient.SqlCommand sqlDeleteCommand1;
        private System.Data.SqlClient.SqlConnection sqlConnection1;
        private System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
        private BindeoDatos.AuthorsDataSet authorsDataSet1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button prev;
        private System.Windows.Forms.Button next;
        private CurrencyManager MyCM;
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
            this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
            this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
            this.sqlInsertCommand1 = new System.Data.SqlClient.SqlCommand();
            this.sqlUpdateCommand1 = new System.Data.SqlClient.SqlCommand();
            this.sqlDeleteCommand1 = new System.Data.SqlClient.SqlCommand();
            this.sqlDataAdapter1 = new System.Data.SqlClient.SqlDataAdapter();
            this.authorsDataSet1 = new BindeoDatos.AuthorsDataSet();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.prev = new System.Windows.Forms.Button();
            this.next = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            ((System.ComponentModel.ISupportInitialize)(this.authorsDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // sqlSelectCommand1
            // 
            this.sqlSelectCommand1.CommandText = "SELECT au_id, au_lname, au_fname, phone, address, city, state, zip, contract FROM" +
                " authors";
            this.sqlSelectCommand1.Connection = this.sqlConnection1;
            // 
            // sqlConnection1
            // 
            this.sqlConnection1.ConnectionString = "workstation id=INWORXDEV;packet size=4096;integrated security=SSPI;data source=IN" +
                "WORXDEV;persist security info=True;initial catalog=pubs";
            // 
            // sqlInsertCommand1
            // 
            this.sqlInsertCommand1.CommandText = @"INSERT INTO authors(au_id, au_lname, au_fname, phone, address, city, state, zip, contract) VALUES (@au_id, @au_lname, @au_fname, @phone, @address, @city, @state, @zip, @contract); SELECT au_id, au_lname, au_fname, phone, address, city, state, zip, contract FROM authors WHERE (au_id = @au_id)";
            this.sqlInsertCommand1.Connection = this.sqlConnection1;
            this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@au_id", System.Data.SqlDbType.VarChar, 11, "au_id"));
            this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@au_lname", System.Data.SqlDbType.VarChar, 40, "au_lname"));
            this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@au_fname", System.Data.SqlDbType.VarChar, 20, "au_fname"));
            this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@phone", System.Data.SqlDbType.VarChar, 12, "phone"));
            this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@address", System.Data.SqlDbType.VarChar, 40, "address"));
            this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@city", System.Data.SqlDbType.VarChar, 20, "city"));
            this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@state", System.Data.SqlDbType.VarChar, 2, "state"));
            this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@zip", System.Data.SqlDbType.VarChar, 5, "zip"));
            this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@contract", System.Data.SqlDbType.Bit, 1, "contract"));
            // 
            // sqlUpdateCommand1
            // 
            this.sqlUpdateCommand1.CommandText = @"UPDATE authors SET au_id = @au_id, au_lname = @au_lname, au_fname = @au_fname, phone = @phone, address = @address, city = @city, state = @state, zip = @zip, contract = @contract WHERE (au_id = @Original_au_id) AND (address = @Original_address OR @Original_address IS NULL AND address IS NULL) AND (au_fname = @Original_au_fname) AND (au_lname = @Original_au_lname) AND (city = @Original_city OR @Original_city IS NULL AND city IS NULL) AND (contract = @Original_contract) AND (phone = @Original_phone) AND (state = @Original_state OR @Original_state IS NULL AND state IS NULL) AND (zip = @Original_zip OR @Original_zip IS NULL AND zip IS NULL); SELECT au_id, au_lname, au_fname, phone, address, city, state, zip, contract FROM authors WHERE (au_id = @au_id)";
            this.sqlUpdateCommand1.Connection = this.sqlConnection1;
            this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@au_id", System.Data.SqlDbType.VarChar, 11, "au_id"));
            this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@au_lname", System.Data.SqlDbType.VarChar, 40, "au_lname"));
            this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@au_fname", System.Data.SqlDbType.VarChar, 20, "au_fname"));
            this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@phone", System.Data.SqlDbType.VarChar, 12, "phone"));
            this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@address", System.Data.SqlDbType.VarChar, 40, "address"));
            this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@city", System.Data.SqlDbType.VarChar, 20, "city"));
            this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@state", System.Data.SqlDbType.VarChar, 2, "state"));
            this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@zip", System.Data.SqlDbType.VarChar, 5, "zip"));
            this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@contract", System.Data.SqlDbType.Bit, 1, "contract"));
            this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_au_id", System.Data.SqlDbType.VarChar, 11, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "au_id", System.Data.DataRowVersion.Original, null));
            this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_address", System.Data.SqlDbType.VarChar, 40, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "address", System.Data.DataRowVersion.Original, null));
            this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_au_fname", System.Data.SqlDbType.VarChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "au_fname", System.Data.DataRowVersion.Original, null));
            this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_au_lname", System.Data.SqlDbType.VarChar, 40, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "au_lname", System.Data.DataRowVersion.Original, null));
            this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_city", System.Data.SqlDbType.VarChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "city", System.Data.DataRowVersion.Original, null));
            this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_contract", System.Data.SqlDbType.Bit, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "contract", System.Data.DataRowVersion.Original, null));
            this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_phone", System.Data.SqlDbType.VarChar, 12, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "phone", System.Data.DataRowVersion.Original, null));
            this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_state", System.Data.SqlDbType.VarChar, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "state", System.Data.DataRowVersion.Original, null));
            this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_zip", System.Data.SqlDbType.VarChar, 5, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "zip", System.Data.DataRowVersion.Original, null));
            // 
            // sqlDeleteCommand1
            // 
            this.sqlDeleteCommand1.CommandText = @"DELETE FROM authors WHERE (au_id = @Original_au_id) AND (address = @Original_address OR @Original_address IS NULL AND address IS NULL) AND (au_fname = @Original_au_fname) AND (au_lname = @Original_au_lname) AND (city = @Original_city OR @Original_city IS NULL AND city IS NULL) AND (contract = @Original_contract) AND (phone = @Original_phone) AND (state = @Original_state OR @Original_state IS NULL AND state IS NULL) AND (zip = @Original_zip OR @Original_zip IS NULL AND zip IS NULL)";
            this.sqlDeleteCommand1.Connection = this.sqlConnection1;
            this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_au_id", System.Data.SqlDbType.VarChar, 11, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "au_id", System.Data.DataRowVersion.Original, null));
            this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_address", System.Data.SqlDbType.VarChar, 40, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "address", System.Data.DataRowVersion.Original, null));
            this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_au_fname", System.Data.SqlDbType.VarChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "au_fname", System.Data.DataRowVersion.Original, null));
            this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_au_lname", System.Data.SqlDbType.VarChar, 40, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "au_lname", System.Data.DataRowVersion.Original, null));
            this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_city", System.Data.SqlDbType.VarChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "city", System.Data.DataRowVersion.Original, null));
            this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_contract", System.Data.SqlDbType.Bit, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "contract", System.Data.DataRowVersion.Original, null));
            this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_phone", System.Data.SqlDbType.VarChar, 12, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "phone", System.Data.DataRowVersion.Original, null));
            this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_state", System.Data.SqlDbType.VarChar, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "state", System.Data.DataRowVersion.Original, null));
            this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_zip", System.Data.SqlDbType.VarChar, 5, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "zip", System.Data.DataRowVersion.Original, null));
            // 
            // sqlDataAdapter1
            // 
            this.sqlDataAdapter1.DeleteCommand = this.sqlDeleteCommand1;
            this.sqlDataAdapter1.InsertCommand = this.sqlInsertCommand1;
            this.sqlDataAdapter1.SelectCommand = this.sqlSelectCommand1;
            this.sqlDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
                                                                                                      new System.Data.Common.DataTableMapping("Table", "authors", new System.Data.Common.DataColumnMapping[] {
                                                                                                                                                                                                                 new System.Data.Common.DataColumnMapping("au_id", "au_id"),
                                                                                                                                                                                                                 new System.Data.Common.DataColumnMapping("au_lname", "au_lname"),
                                                                                                                                                                                                                 new System.Data.Common.DataColumnMapping("au_fname", "au_fname"),
                                                                                                                                                                                                                 new System.Data.Common.DataColumnMapping("phone", "phone"),
                                                                                                                                                                                                                 new System.Data.Common.DataColumnMapping("address", "address"),
                                                                                                                                                                                                                 new System.Data.Common.DataColumnMapping("city", "city"),
                                                                                                                                                                                                                 new System.Data.Common.DataColumnMapping("state", "state"),
                                                                                                                                                                                                                 new System.Data.Common.DataColumnMapping("zip", "zip"),
                                                                                                                                                                                                                 new System.Data.Common.DataColumnMapping("contract", "contract")})});
            this.sqlDataAdapter1.UpdateCommand = this.sqlUpdateCommand1;
            // 
            // authorsDataSet1
            // 
            this.authorsDataSet1.DataSetName = "AuthorsDataSet";
            this.authorsDataSet1.Locale = new System.Globalization.CultureInfo("es-AR");
            // 
            // textBox1
            // 
            this.textBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.authorsDataSet1, "authors.au_lname"));
            this.textBox1.Location = new System.Drawing.Point(40, 24);
            this.textBox1.Name = "textBox1";
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "textBox1";
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(40, 64);
            this.textBox2.Name = "textBox2";
            this.textBox2.TabIndex = 1;
            this.textBox2.Text = "textBox2";
            // 
            // prev
            // 
            this.prev.Location = new System.Drawing.Point(24, 112);
            this.prev.Name = "prev";
            this.prev.TabIndex = 2;
            this.prev.Text = "<";
            this.prev.Click += new System.EventHandler(this.prev_Click);
            // 
            // next
            // 
            this.next.Location = new System.Drawing.Point(120, 112);
            this.next.Name = "next";
            this.next.TabIndex = 3;
            this.next.Text = ">";
            this.next.Click += new System.EventHandler(this.next_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(592, 120);
            this.button1.Name = "button1";
            this.button1.TabIndex = 4;
            this.button1.Text = "button1";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGrid1
            // 
            this.dataGrid1.DataMember = "";
            this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid1.Location = new System.Drawing.Point(32, 152);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.Size = new System.Drawing.Size(648, 240);
            this.dataGrid1.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(696, 406);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.next);
            this.Controls.Add(this.prev);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.authorsDataSet1)).EndInit();
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

        private void textBox1_TextChanged(object sender, System.EventArgs e)
        {
        
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
            sqlDataAdapter1.Fill(authorsDataSet1);
            textBox2.DataBindings.Add("Text", authorsDataSet1, "Authors.au_fname");
            MyCM = (CurrencyManager) this.BindingContext[authorsDataSet1, "authors"];
            MyCM.Position = 0;
        }

        private void next_Click(object sender, System.EventArgs e)
        {
            if (MyCM.Position < MyCM.Count)   
              MyCM.Position += 1;
        }

        private void prev_Click(object sender, System.EventArgs e)
        {
            if (MyCM.Position > 0)   
                MyCM.Position -= 1;
        }

        private DataTable CreateMaster()
        {
            DataTable dt = new DataTable("Participantes");
            DataColumn dc;
            dc = new DataColumn("codigo", Type.GetType("System.String"));
            dt.Columns.Add(dc);
            dc = new DataColumn("nombre", Type.GetType("System.String"));
            dt.Columns.Add(dc);
            dt.Rows.Add(new Object[] {"1", "Diego"});
            dt.Rows.Add(new Object[] {"2", "Daniel"});
            dt.Rows.Add(new Object[] {"3", "Pepe"});
            dt.Rows.Add(new Object[] {"4", "Lala"});
            return dt;
        }
        
        private DataTable CreateDetail()
        {
            DataTable dt = new DataTable("Notas");
            DataColumn dc;
            dc = new DataColumn("codigo", Type.GetType("System.String"));
            dt.Columns.Add(dc);
            dc = new DataColumn("nota", Type.GetType("System.Int32"));
            dt.Columns.Add(dc);
            dt.Rows.Add(new Object[] {"1", "6"});
            dt.Rows.Add(new Object[] {"2", "3"});
            dt.Rows.Add(new Object[] {"1", "8"});
            dt.Rows.Add(new Object[] {"2", "6"});
            dt.Rows.Add(new Object[] {"3", "9"});
            return dt;
        }
    
        private void button1_Click(object sender, System.EventArgs e)
        {
            DataSet ds;
            ds = new DataSet();

            ds.Tables.Add(CreateMaster());
            ds.Tables.Add(CreateDetail());
            /*
            DataView dv;
            dv = ds.Tables[0].DefaultView;
            dv.Sort = "nombre";
            dv.RowFilter = "nombre like 'Pep%'";
            dataGrid1.DataSource = dv;
            //ds.WriteXml("c:\\bbb.xml");
            ds.Tables[0].Constraints.Add("pk_codigo", ds.Tables[0].Columns[0], true);
            DataRow dr = ds.Tables[0].Rows.Find("1");
            MessageBox.Show(dr["nombre"].ToString());
            DataRow[] drc = ds.Tables[0].Select("nombre like 'D%'");
            foreach (DataRow p in drc)
                MessageBox.Show(p["nombre"].ToString());
            */
            DataRelation rel = new DataRelation("Relacion1", ds.Tables[0].Columns["codigo"], ds.Tables[1].Columns["codigo"], true);
            ds.Relations.Add(rel);
            dataGrid1.DataSource = ds.Tables[0].DefaultView;
        }
	}
}
