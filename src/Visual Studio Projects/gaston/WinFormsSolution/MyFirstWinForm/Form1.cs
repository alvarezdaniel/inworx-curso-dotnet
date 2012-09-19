using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Xml;
using System.Reflection;

namespace MyFirstWinForm
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button button2;
		private SemaforoLib.Semaforo semaforo1;
		private System.Windows.Forms.Button button1;
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
			this.button2 = new System.Windows.Forms.Button();
			this.semaforo1 = new SemaforoLib.Semaforo();
			this.button1 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(16, 232);
			this.button2.Name = "button2";
			this.button2.TabIndex = 0;
			this.button2.Text = "Mensaje";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// semaforo1
			// 
			this.semaforo1.Estado = SemaforoLib.Semaforo.SemaforoState.Paused;
			this.semaforo1.Location = new System.Drawing.Point(184, 32);
			this.semaforo1.Name = "semaforo1";
			this.semaforo1.Size = new System.Drawing.Size(104, 192);
			this.semaforo1.TabIndex = 1;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(16, 200);
			this.button1.Name = "button1";
			this.button1.TabIndex = 2;
			this.button1.Text = "button1";
			this.button1.Click += new System.EventHandler(this.button1_Click_1);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(292, 266);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.semaforo1);
			this.Controls.Add(this.button2);
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.ResumeLayout(false);

		}
		#endregion

		#region Cachito
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			//Application.Run(new Form1());
			Form f = new Form1();

			//Si se cierra el form, no finaliza la app
			//f.Show();
			//Application.Run();

			//Vincula el close del documento al exit del msg loop
			//Application.Run(f);

			//Tiene su propio msg loop, pero no puedo crear ventanas no-modales
			f.ShowDialog();
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			//Corta el message loop
			Application.Exit();
		}

		private void button2_Click(object sender, System.EventArgs e)
		{
			//Corta el message loop
			MessageBox.Show("Hola!!!");
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
			XmlDocument doc= new XmlDocument();
			XmlNodeList list;
			doc.Load(@"C:\Documents and Settings\Inworx\My Documents\Visual Studio Projects\WinFormsSolution\MyFirstWinForm\XMLControls.xml");
//			list = doc.SelectNodes(@"\\form[@name='login']\\control");
			list = doc.SelectNodes(@"//control");
			foreach (XmlElement node in list)
			{
				switch (node.GetAttribute("type"))
				{
					case "text":
						//Type t = Type.GetType("System.Windows.Forms.Button",true, true);
						//Type t = Type.GetType("System.Int32");
						//Type t = Type.GetType("Button");
						//MessageBox.Show(t.Name);
						//MessageBox.Show(btn2.GetType().Name);
						System.Reflection.Assembly asm = Assembly.LoadFrom(@"C:\WINDOWS\Microsoft.NET\Framework\v1.1.4322\System.Windows.Forms.dll");
						Type t = asm.GetType("System.Windows.Forms.Button");
						//Control c = (System.Windows.Forms.Control)Activator.CreateInstance(t);
						Object o = Activator.CreateInstance(t);
						PropertyInfo info = t.GetProperty("text");
						if (info.CanWrite)
						{
							info.SetValue(o, node.GetAttribute("text"), null);
						}
						this.Controls.Add(((Control)o));
						TextBox tb = new TextBox();
						tb.Text = node.GetAttribute("text");
						tb.Name = node.GetAttribute("name");
						tb.Location = new Point(int.Parse(node.GetAttribute("x")),
												int.Parse(node.GetAttribute("y")));
						tb.Width = int.Parse(node.GetAttribute("width"));
						tb.Height = int.Parse(node.GetAttribute("height"));
						this.Controls.Add(tb);
						break;
					case "pass":break;
					case "button":
						Button btn = new Button();
						btn.Name = node.GetAttribute("name");
						btn.Location = new Point(int.Parse(node.GetAttribute("x")),
							int.Parse(node.GetAttribute("y")));
						btn.Width = int.Parse(node.GetAttribute("width"));
						btn.Height = int.Parse(node.GetAttribute("height"));
						this.Controls.Add(btn);
						
						break;
					default:break;
				}
			}
			//Atributos name de los nodos dentro de controls
			//XMLNodeList nodes = doc.SelectNodes(@"\\controls\\control\\@name");
			//XMLNodeList nodes = doc.SelectNodes(@"\\controls\\control\\[@name='pepe']\@type");
			//XMLNodeList nodes = doc.SelectNodes(@"\form\controls\control\\[@name='pepe']\@type");
		
		}

		private void button1_Click_1(object sender, System.EventArgs e)
		{
			int i;
			for(i=0; i < 3;i++)
			{
				semaforo1.Estado = SemaforoLib.Semaforo.SemaforoState.Started;
				System.Threading.Thread.Sleep(1000);
				semaforo1.Estado = SemaforoLib.Semaforo.SemaforoState.Paused;
				System.Threading.Thread.Sleep(1000);
				semaforo1.Estado = SemaforoLib.Semaforo.SemaforoState.Stopped;
				System.Threading.Thread.Sleep(1000);
			}
		}

	}
}
