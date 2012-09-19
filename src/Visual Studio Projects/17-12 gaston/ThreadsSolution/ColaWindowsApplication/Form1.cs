using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Threading;

namespace ColaWindowsApplication
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox edtNroSolicitud;
		private System.Windows.Forms.Button btnViewState;
		private System.Windows.Forms.ListView listView1;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.Button button1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Button button2;

		private AutoResetEvent myEvent;

		private class Punto
		{
			private double x, y;
			public Punto(double x, double y)
			{
				this.x = x;
				this.y = y;
			}

			void SetPunto(double x, double y)
			{
				Monitor.Enter(this);
				//Si pudo entrar retorna true...
				//Monitor.TryEnter
				try
				{
					this.x = x;
					this.y = y;
				}
				finally
				{
					Monitor.Exit(this);
				}
			}

			void GetPunto(ref double x, ref double y)
			{
				Monitor.Enter(this);
				try
				{
					x = this.x;
					y = this.y;
				}
				finally
				{
					Monitor.Exit(this);
				}
			}
		}

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
			this.label1 = new System.Windows.Forms.Label();
			this.edtNroSolicitud = new System.Windows.Forms.TextBox();
			this.btnViewState = new System.Windows.Forms.Button();
			this.listView1 = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(72, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "Nro. Solicitud";
			// 
			// edtNroSolicitud
			// 
			this.edtNroSolicitud.Location = new System.Drawing.Point(96, 24);
			this.edtNroSolicitud.Name = "edtNroSolicitud";
			this.edtNroSolicitud.TabIndex = 1;
			this.edtNroSolicitud.Text = "";
			// 
			// btnViewState
			// 
			this.btnViewState.Location = new System.Drawing.Point(200, 24);
			this.btnViewState.Name = "btnViewState";
			this.btnViewState.TabIndex = 2;
			this.btnViewState.Text = "View State";
			this.btnViewState.Click += new System.EventHandler(this.btnViewState_Click);
			// 
			// listView1
			// 
			this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						this.columnHeader1,
																						this.columnHeader2});
			this.listView1.Location = new System.Drawing.Point(16, 152);
			this.listView1.Name = "listView1";
			this.listView1.Size = new System.Drawing.Size(256, 160);
			this.listView1.TabIndex = 3;
			this.listView1.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Expediente";
			this.columnHeader1.Width = 100;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Estado";
			this.columnHeader2.Width = 100;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(200, 64);
			this.button1.Name = "button1";
			this.button1.TabIndex = 4;
			this.button1.Text = "button1";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(16, 72);
			this.button2.Name = "button2";
			this.button2.TabIndex = 5;
			this.button2.Text = "button2";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(292, 326);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.listView1);
			this.Controls.Add(this.btnViewState);
			this.Controls.Add(this.edtNroSolicitud);
			this.Controls.Add(this.label1);
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

		private class ThreadClass
		{
			private string param;
			private ListView list;

			public ThreadClass(string param, ListView list)
			{
				this.param = param;
				this.list = list;
			}

			public void ThreadFunc()
			{
				System.Threading.Thread.Sleep(20000);
				//MessageBox.Show(string.Format("Expediente {0} está listo", edtNroSolicitud.Text));
				MessageBox.Show(string.Format("Expediente {0} está listo", param));
			}

			private void DoUpdate()
			{
				ListViewItem item = list.Items.Add(param);
				item.SubItems.Add("Listo");
			}

			public void ThreadFunc2()
			{
				System.Threading.Thread.Sleep(200);
				//Llamada sincronica...
				list.Invoke(new ThreadStart(DoUpdate));
				/*
				 Llamada asincronica, de modo que el thread puede continuar con el trabajo
				 list.BeginInvoke(new ThreadStart(DoUpdate));
				 .....
				 list.EndInvoke();*/
			}

		}

		private class EventableThreadClass
		{
			private AutoResetEvent raisableEvent;

			public EventableThreadClass(AutoResetEvent ev)
			{
				this.raisableEvent = ev;
			}

			public void Run()
			{
				MessageBox.Show("Empece el thread...");
				System.Threading.Thread.Sleep(2000);
				raisableEvent.Set();
				System.Threading.Thread.Sleep(5000);
				MessageBox.Show("Finalice el thread...");
			}
		}

		private void btnViewState_Click(object sender, System.EventArgs e)
		{
			//ThreadStart start;
			//start = new ThreadStart(ThreadFunc);
			ThreadClass start;
			start = new ThreadClass(edtNroSolicitud.Text, listView1);
			Thread t = new Thread(new ThreadStart(start.ThreadFunc));
			t.Start();
			t.IsBackground = false;
			//Bloquea el hilo hasta la finalizacion de t
			//t.Join();
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			Thread[] ts = new Thread[100];
			ThreadClass start;
			for (int i = 0; i < ts.Length; i++)
			{
				start = new ThreadClass(i.ToString(), listView1);
				ts[i] = new Thread(new ThreadStart(start.ThreadFunc2));
			}
			
			for (int i = 0; i < ts.Length; i++)
			{
				ts[i].Start();
				ts[i].IsBackground = false;
				//Modo de apartment (COM)
				//MTA: multi threading apartment
				//STA: single threading apartment
				//ts[i].ApartmentState = ApartmentState.MTA;

			}

			myEvent = new AutoResetEvent(false);
			//	lanzo un thread y le paso el event por parametro
			//	cuando el thread lo considrea hace
			//	myEvent.Set();
			//	hago una sub-tarea
			//.....
			myEvent.WaitOne();


			//Espero por todos los threads en el array...
			//WaitHandle.WaitAll(new WaitHandle[]{ts[1], ts[3],....});

			/*System.IntPtr a = new IntPtr(0);
			unsafe
			{
				if (a.ToPointer() == IntPtr.Zero.ToPointer())
				{
					MessageBox.Show("Soy null, puto!!!");
				}
				void * ptr = a.ToPointer();
			}*/
		}

		private void button2_Click(object sender, System.EventArgs e)
		{
			AutoResetEvent evento;

			evento = new AutoResetEvent(false);
			EventableThreadClass start = new EventableThreadClass(evento);
			Thread t = new Thread(new ThreadStart(start.Run));
			t.Start();
			evento.WaitOne();
			MessageBox.Show("Se disparo el evento");

		}

		
		 // No se puede heredar!!!
		/*
		private class MyThread: Thread
		{
			string param;

			public MyThread(string param) : base(new ThreadStart(MyThreadFunc))
			{
				this.param = param;
			}
			private void MyThreadFunc()
			{
			}
		}*/
	}
}
