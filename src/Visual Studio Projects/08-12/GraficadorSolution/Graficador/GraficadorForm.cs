using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using GraficadorLib;
using System.IO;
using System.Runtime.Serialization.Formatters.Soap;
using System.Runtime.Serialization.Formatters.Binary;
using System.Net;
using System.Net.Sockets;

namespace Graficador
{
	/// <summary>
	/// Summary description for GraficadorForm.
	/// </summary>
	public class GraficadorForm : System.Windows.Forms.Form
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
        private Dibujo dibujo;
        private System.Windows.Forms.MainMenu mainMenu1;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem menuItem2;
        private System.Windows.Forms.MenuItem menuItem3;
        private System.Windows.Forms.MenuItem menuItem4;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.MenuItem menuItem5;
        private System.Windows.Forms.MenuItem menuItem6;
        private System.Windows.Forms.MenuItem menuItem7;
        private System.Windows.Forms.MenuItem menuItem8;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.MenuItem menuItem9;
        private System.Windows.Forms.MenuItem menuItem10;
        private Trazo trazo;
        private Color color;
        private System.Windows.Forms.MenuItem menuItem11;
        private float width;

		public GraficadorForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
            dibujo = new Dibujo();
            trazo = null;
            color = Color.Black;
            width = 1;
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
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(GraficadorForm));
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.menuItem5 = new System.Windows.Forms.MenuItem();
            this.menuItem6 = new System.Windows.Forms.MenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.menuItem7 = new System.Windows.Forms.MenuItem();
            this.menuItem8 = new System.Windows.Forms.MenuItem();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.menuItem9 = new System.Windows.Forms.MenuItem();
            this.menuItem10 = new System.Windows.Forms.MenuItem();
            this.menuItem11 = new System.Windows.Forms.MenuItem();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
                                                                                      this.menuItem1,
                                                                                      this.menuItem9});
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 0;
            this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
                                                                                      this.menuItem4,
                                                                                      this.menuItem3,
                                                                                      this.menuItem2,
                                                                                      this.menuItem5,
                                                                                      this.menuItem6,
                                                                                      this.menuItem7,
                                                                                      this.menuItem8});
            this.menuItem1.MergeType = System.Windows.Forms.MenuMerge.MergeItems;
            this.menuItem1.Text = "File";
            // 
            // menuItem4
            // 
            this.menuItem4.Index = 0;
            this.menuItem4.Text = "Open";
            this.menuItem4.Click += new System.EventHandler(this.menuItem4_Click);
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 1;
            this.menuItem3.Text = "Save As...";
            this.menuItem3.Click += new System.EventHandler(this.menuItem3_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 2;
            this.menuItem2.MergeOrder = 30;
            this.menuItem2.Text = "Close";
            this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
            // 
            // menuItem5
            // 
            this.menuItem5.Index = 3;
            this.menuItem5.Text = "Send";
            this.menuItem5.Click += new System.EventHandler(this.menuItem5_Click);
            // 
            // menuItem6
            // 
            this.menuItem6.Index = 4;
            this.menuItem6.Text = "Receive";
            this.menuItem6.Click += new System.EventHandler(this.menuItem6_Click);
            // 
            // menuItem7
            // 
            this.menuItem7.Index = 5;
            this.menuItem7.Text = "Print Preview";
            this.menuItem7.Click += new System.EventHandler(this.menuItem7_Click);
            // 
            // menuItem8
            // 
            this.menuItem8.Index = 6;
            this.menuItem8.Text = "Print";
            this.menuItem8.Click += new System.EventHandler(this.menuItem8_Click);
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Location = new System.Drawing.Point(21, 82);
            this.printPreviewDialog1.MinimumSize = new System.Drawing.Size(375, 250);
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.TransparencyKey = System.Drawing.Color.Empty;
            this.printPreviewDialog1.Visible = false;
            // 
            // menuItem9
            // 
            this.menuItem9.Index = 1;
            this.menuItem9.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
                                                                                      this.menuItem10,
                                                                                      this.menuItem11});
            this.menuItem9.Text = "Edit";
            // 
            // menuItem10
            // 
            this.menuItem10.Index = 0;
            this.menuItem10.Text = "Color";
            this.menuItem10.Click += new System.EventHandler(this.menuItem10_Click);
            // 
            // menuItem11
            // 
            this.menuItem11.Index = 1;
            this.menuItem11.Text = "Width";
            this.menuItem11.Click += new System.EventHandler(this.menuItem11_Click);
            // 
            // GraficadorForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(656, 382);
            this.Menu = this.mainMenu1;
            this.Name = "GraficadorForm";
            this.Text = "Graficador";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GraficadorForm_MouseDown);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.GraficadorForm_MouseUp);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.GraficadorForm_Paint);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.GraficadorForm_MouseMove);

        }
		#endregion

        private void GraficadorForm_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                trazo = new Trazo(color, width);
                trazo.Add(new Point(e.X, e.Y));
            }
        }

        private void GraficadorForm_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (trazo != null)
            {   
                trazo.Add(new Point(e.X, e.Y));
                trazo.Draw(this.CreateGraphics());
            }
        }

        private void GraficadorForm_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            { 
                if (trazo != null)
                {   
                    trazo.Add(new Point(e.X, e.Y));
                    trazo.Draw(this.CreateGraphics());
                    dibujo.Add(trazo);
                    trazo = null;
                }
            }
            else
            {
                dibujo.Clear();
                this.Invalidate();
                this.Update();
            }
        }

        private void GraficadorForm_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            dibujo.Draw(e.Graphics);
        }

        private void menuItem2_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void menuItem3_Click(object sender, System.EventArgs e)
        {
            DialogResult dr;
            dr = saveFileDialog1.ShowDialog();
            if (dr == DialogResult.OK)
            {
                FileStream str = new FileStream(saveFileDialog1.FileName, FileMode.Create);
                //BinaryFormatter bf = new BinaryFormatter();
                SoapFormatter sf = new SoapFormatter();
                sf.Serialize(str, dibujo);
                //bf.Serialize(str, dibujo);
                str.Close();
            }
        }

        private void menuItem4_Click(object sender, System.EventArgs e)
        {
            DialogResult dr;
            dr = openFileDialog1.ShowDialog();
            if (dr == DialogResult.OK)
            {
                FileStream str = new FileStream(openFileDialog1.FileName, FileMode.Open);
                SoapFormatter sf = new SoapFormatter();
                dibujo = (Dibujo)sf.Deserialize(str);
                str.Close();
                this.Invalidate();
                this.Update();
            }
        }

        private void menuItem6_Click(object sender, System.EventArgs e)
        {
            int port = 13000;
            IPAddress add = IPAddress.Parse("127.0.0.1");
            TcpListener lsr = new TcpListener(add, port);
            lsr.Start();
            TcpClient cliente = lsr.AcceptTcpClient();
            Stream str = cliente.GetStream();
            BinaryFormatter bf = new BinaryFormatter();
            dibujo = (Dibujo)bf.Deserialize(str);
            str.Close();
            cliente.Close();
            lsr.Stop();
            this.Invalidate();
            this.Update();
        }

        private void menuItem5_Click(object sender, System.EventArgs e)
        {
            int port = 13000;
            IPAddress add = IPAddress.Parse("127.0.0.1");
            TcpClient cliente = new TcpClient();
            cliente.Connect(add, port);
            Stream str = cliente.GetStream();
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(str, dibujo);
            str.Close();
            cliente.Close();
        }

        private void menuItem7_Click(object sender, System.EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }

        private void menuItem8_Click(object sender, System.EventArgs e)
        {
            printDocument1.Print();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            dibujo.Draw(e.Graphics);
            //e.HasMorePages = true;
        }

        private void menuItem10_Click(object sender, System.EventArgs e)
        {
            DialogResult dr;
            colorDialog1.Color = color;
            dr = colorDialog1.ShowDialog();
            if (dr == DialogResult.OK) 
            {
               color = colorDialog1.Color;                         
            }
        }

        private void menuItem11_Click(object sender, System.EventArgs e)
        {
            DialogResult dr;
            WidthForm wf = new WidthForm();
            wf.SelectedWidth = width;
            dr = wf.ShowDialog();
            if (dr == DialogResult.OK)
            {
                width = wf.SelectedWidth;
            }
        }
	}
}
