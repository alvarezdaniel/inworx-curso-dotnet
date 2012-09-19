using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Xml;

namespace MyFirstWindowsApplication
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private SemaforoLib.Semaforo semaforo1;
		private System.Windows.Forms.Button button4;
		private bool bEquis;

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			bEquis = false;
		}

		#region Dispose
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
		#endregion

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.semaforo1 = new SemaforoLib.Semaforo();
			this.button4 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(200, 24);
			this.button1.Name = "button1";
			this.button1.TabIndex = 0;
			this.button1.Text = "button1";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(24, 24);
			this.button2.Name = "button2";
			this.button2.TabIndex = 0;
			this.button2.Text = "button2";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(112, 112);
			this.button3.Name = "button3";
			this.button3.TabIndex = 1;
			this.button3.Text = "button3";
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// semaforo1
			// 
			this.semaforo1.Estado = SemaforoLib.SemaforoEstado.Stopped;
			this.semaforo1.Location = new System.Drawing.Point(552, 16);
			this.semaforo1.Name = "semaforo1";
			this.semaforo1.Size = new System.Drawing.Size(24, 88);
			this.semaforo1.TabIndex = 2;
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(176, 232);
			this.button4.Name = "button4";
			this.button4.TabIndex = 3;
			this.button4.Text = "button4";
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(592, 534);
			this.Controls.Add(this.button4);
			this.Controls.Add(this.semaforo1);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.button2);
			this.Name = "Form1";
			this.Text = "Form1";
			this.Resize += new System.EventHandler(this.Form1_Resize);
			this.Load += new System.EventHandler(this.Form1_Load);
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Form1 f = new Form1();
			Application.Run(f);
			//f.ShowDialog();
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			Application.Exit();
		}

		private void button2_Click(object sender, System.EventArgs e)
		{
			MessageBox.Show("Hola");
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
			XmlDocument doc = new XmlDocument();
			XmlNodeList list;
			TextBox tb;
			int i = 0;

			doc.Load(@"C:\Documents and Settings\Inworx\My Documents\Visual Studio Projects\WindowsSolution\MyFirstWindowsApplication\login.xml");
			//MessageBox.Show(doc.InnerXml);
			// XPath es un lenguage de query tipo SQL
			list = doc.SelectNodes(@"//form[@name='login']/control");
			foreach (XmlElement node in list)
			{
				switch (node.GetAttribute("type"))
				{
					case "text":
						tb = new TextBox();
						tb.Text = node.GetAttribute("text");
						tb.Name = node.GetAttribute("name");
						tb.Location = new Point(10, 10 + 30*i++);
						this.Controls.Add(tb);
						break;
					default:
						break;
				}
			}
		}

		private void button3_Click(object sender, System.EventArgs e)
		{
			bEquis = true;
			this.Invalidate();
			this.Update();
		}

		private void Form1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			if (bEquis)
			{
				Graphics g = e.Graphics;
				Pen pen = new Pen(Color.Red, 2);
				g.DrawLine(pen, 0, 0, this.ClientRectangle.Width, this.ClientRectangle.Height);
				g.DrawLine(pen, 0, this.ClientRectangle.Height, this.ClientRectangle.Width, 0);
				g.DrawEllipse(pen, this.ClientRectangle);
			}
		}

		private void Form1_Resize(object sender, System.EventArgs e)
		{
			this.Invalidate();
			this.Update();
		}

		private void button4_Click(object sender, System.EventArgs e)
		{
			semaforo1.Estado = SemaforoLib.SemaforoEstado.Started;
			System.Threading.Thread.Sleep(10000);
			semaforo1.Estado = SemaforoLib.SemaforoEstado.Paused;
			System.Threading.Thread.Sleep(1000);
			semaforo1.Estado = SemaforoLib.SemaforoEstado.Stopped;
		}
	}
}













