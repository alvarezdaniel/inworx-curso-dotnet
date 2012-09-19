using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Configuration;
using System.Reflection;
using AuthorLib;

namespace ReflectionWindowsApplication
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.ListView listView1;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
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
			System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
																													 "Roberto",
																													 "Cacho"}, -1);
			this.button1 = new System.Windows.Forms.Button();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.label1 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.button2 = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.button3 = new System.Windows.Forms.Button();
			this.listView1 = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(72, 208);
			this.button1.Name = "button1";
			this.button1.TabIndex = 0;
			this.button1.Text = "button1";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(48, 23);
			this.label1.TabIndex = 1;
			this.label1.Text = "Asm";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(72, 16);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(168, 20);
			this.textBox1.TabIndex = 2;
			this.textBox1.Text = "textBox1";
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(248, 16);
			this.button2.Name = "button2";
			this.button2.TabIndex = 3;
			this.button2.Text = "button2";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(16, 56);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(48, 23);
			this.label2.TabIndex = 4;
			this.label2.Text = "Author";
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(72, 48);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(168, 20);
			this.textBox2.TabIndex = 5;
			this.textBox2.Text = "textBox2";
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(248, 48);
			this.button3.Name = "button3";
			this.button3.TabIndex = 6;
			this.button3.Text = "button3";
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// listView1
			// 
			this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						this.columnHeader1,
																						this.columnHeader2});
			this.listView1.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
																					  listViewItem1});
			this.listView1.Location = new System.Drawing.Point(16, 88);
			this.listView1.Name = "listView1";
			this.listView1.Size = new System.Drawing.Size(304, 97);
			this.listView1.TabIndex = 7;
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Clase";
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Ubicacion";
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(392, 266);
			this.Controls.Add(this.listView1);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.textBox2);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.button1);
			this.Name = "Form1";
			this.Text = "Form1";
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
			string  s;
			Type t;
			s = ConfigurationSettings.AppSettings["x"];
			t = Type.GetType(s);
			object obj = t.InvokeMember("", BindingFlags.CreateInstance, null,
				null, null);
			B obj_b = (B) obj;
			MessageBox.Show(obj_b.ToString());
			MessageBox.Show(obj.ToString());

			string clase, metodo;
			clase = ConfigurationSettings.AppSettings["clase"];
			metodo = ConfigurationSettings.AppSettings["metodo"];
			t = Type.GetType(clase);
			obj = t.InvokeMember("", BindingFlags.CreateInstance, null,
				null, null);
			object result = t.InvokeMember(metodo,
					BindingFlags.InvokeMethod,
					null,
					obj,
					null);

			MessageBox.Show(result.ToString());

			Assembly asm = Assembly.LoadWithPartialName("System.Windows.Forms");
			Type[] types = asm.GetTypes();
			Type type = asm.GetType("System.Windows.Forms.Button");
			MessageBox.Show(types.ToString());
			object o_btn = type.InvokeMember("", BindingFlags.CreateInstance, null, null, null);
			Button btn = (Button) o_btn;
			Control ctl = (Control) o_btn;
			this.Controls.Add(ctl);

			type = Type.GetType("System.Windows.Forms.Button");
			object obj2 = Activator.CreateInstance(type, false);
			Button btn2 = (Button)obj2;

		    /*
			s = ConfigurationSettings.AppSettings["y"];
			t = Type.GetType(s);
			
			obj = t.InvokeMember("", BindingFlags.CreateInstance, null,
				null, null);
			
			this.Controls.Add((Control) obj);*/
		}

		private void button2_Click(object sender, System.EventArgs e)
		{
			openFileDialog1.ShowDialog();
			textBox1.Text = openFileDialog1.FileName;

		}

		private void button3_Click(object sender, System.EventArgs e)
		{
			AuthorAttribute temp = new AuthorAttribute("");
			Assembly asm = Assembly.LoadFrom(textBox1.Text);
			Type[] types = asm.GetTypes();
			foreach (Type t in types)
			{
				//Type.GetType("AuthorLib.AuthorAttribute")
				object[] atributos = t.GetCustomAttributes(temp.GetType(), false);
				if (atributos.Length > 0)
				{
					AuthorAttribute att = (AuthorAttribute) atributos[0];
					if (att.Nombre == textBox2.Text)
					{
						ListViewItem item = listView1.Items.Add("Clase");
						listView1.Items.Add(t.FullName);
					}
				}
			}
		}
	}
}
