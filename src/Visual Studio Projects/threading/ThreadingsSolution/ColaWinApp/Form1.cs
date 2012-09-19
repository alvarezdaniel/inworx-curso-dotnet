using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Threading;

namespace ColaWinApp
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button button2;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
        
        private AutoResetEvent myEvent;

		private class Punto
        {
            private double x, y;

            public Punto(double x, double y)
            {
                this.x = x;
                this.y = y;
            }
            public void SetPunto(double x, double y)
            {
                Monitor.Enter(this);
                this.x = x;
                this.y = y;
                Monitor.Exit(this);
            }
            public void GetPunto(ref double x, ref double y)
            {
                Monitor.Enter(this);
                x = this.x;
                y = this.y;
                Monitor.Exit(this);
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(56, 24);
            this.textBox1.Name = "textBox1";
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "textBox1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(168, 24);
            this.button1.Name = "button1";
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // listView1
            // 
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
                | System.Windows.Forms.AnchorStyles.Left) 
                | System.Windows.Forms.AnchorStyles.Right)));
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
                                                                                        this.columnHeader1,
                                                                                        this.columnHeader2});
            this.listView1.Location = new System.Drawing.Point(16, 88);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(264, 272);
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
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(168, 56);
            this.button2.Name = "button2";
            this.button2.TabIndex = 4;
            this.button2.Text = "button2";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(292, 382);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
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
            public string param;
            private ListView ls;

            public ThreadClass(string s, ListView lista)
            {
                param = s;
                ls = lista;
            }

            public void ThreadFunc()
            {   
                System.Threading.Thread.Sleep(500);
                ls.Invoke(new ThreadStart(DoUpdate));
                //MessageBox.Show("Expediente " + textBox1.Text + " listo!!");
                //Esto no es thread safe
                //ListViewItem item = ls.Items.Add(param);
                //item.SubItems.Add("Listo");
            }
            private void DoUpdate()
            {
                ListViewItem item = ls.Items.Add(param);
                item.SubItems.Add("Listo");
            }
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
//            ThreadClass start;
//            start = new ThreadClass(textBox1.Text);
//            ThreadStart st = new ThreadStart(start.ThreadFunc);
//            Thread t = new Thread(st);
//            t.Start();
//            t.IsBackground = false;
//            t.Join();
        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            listView1.Items.Clear();
            Thread[] t = new Thread[100];
            ThreadClass start;
            for (int i = 0; i < 100; i++)
            {
                start = new ThreadClass(i.ToString(), listView1);
                ThreadStart st = new ThreadStart(start.ThreadFunc);
                t[i] = new Thread(st);
            }
            for (int i = 0; i < 100; i++)
            {
                t[i].Start();
                t[i].IsBackground = false;
                //t.Join();
            }
            //WaitHandle.WaitAll();
            myEvent = new AutoResetEvent(false);
            //... myEvent.Set();... //En otro thread
            myEvent.WaitOne();

        }
	}
}
