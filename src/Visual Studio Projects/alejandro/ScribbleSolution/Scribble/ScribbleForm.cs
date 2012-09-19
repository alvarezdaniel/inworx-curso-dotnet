using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using ScribbleLib;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Net;
using System.Net.Sockets;

namespace Scribble
{
	/// <summary>
	/// Summary description for ScribbleForm.
	/// </summary>
	public class ScribbleForm : System.Windows.Forms.Form
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private Dibujo dibujo;
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem fileMenuItem;
		private System.Windows.Forms.MenuItem fileCloseMenuItem;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.SaveFileDialog saveFileDialog1;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.ColorDialog colorDialog1;
		private System.Windows.Forms.MenuItem fileSendMenuItem;
		private System.Windows.Forms.MenuItem fileReceiveMenuItem;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.MenuItem menuItem4;
		private System.Drawing.Printing.PrintDocument printDocument1;
		private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
		private System.Windows.Forms.MenuItem menuItem5;
		private System.Windows.Forms.MenuItem menuItem6;
		private Trazo trazo;
		private Color color;
		private System.Windows.Forms.MenuItem menuItem7;
		private float width;

		public ScribbleForm()
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(ScribbleForm));
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			this.fileMenuItem = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.fileCloseMenuItem = new System.Windows.Forms.MenuItem();
			this.fileSendMenuItem = new System.Windows.Forms.MenuItem();
			this.fileReceiveMenuItem = new System.Windows.Forms.MenuItem();
			this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.colorDialog1 = new System.Windows.Forms.ColorDialog();
			this.menuItem3 = new System.Windows.Forms.MenuItem();
			this.menuItem4 = new System.Windows.Forms.MenuItem();
			this.printDocument1 = new System.Drawing.Printing.PrintDocument();
			this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
			this.menuItem5 = new System.Windows.Forms.MenuItem();
			this.menuItem6 = new System.Windows.Forms.MenuItem();
			this.menuItem7 = new System.Windows.Forms.MenuItem();
			// 
			// mainMenu1
			// 
			this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.fileMenuItem,
																					  this.menuItem5});
			// 
			// fileMenuItem
			// 
			this.fileMenuItem.Index = 0;
			this.fileMenuItem.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						 this.menuItem2,
																						 this.menuItem1,
																						 this.fileCloseMenuItem,
																						 this.fileSendMenuItem,
																						 this.fileReceiveMenuItem,
																						 this.menuItem3,
																						 this.menuItem4});
			this.fileMenuItem.MergeType = System.Windows.Forms.MenuMerge.MergeItems;
			this.fileMenuItem.Text = "File";
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 0;
			this.menuItem2.Text = "Open...";
			this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 1;
			this.menuItem1.Text = "Save As...";
			this.menuItem1.Click += new System.EventHandler(this.menuItem1_Click);
			// 
			// fileCloseMenuItem
			// 
			this.fileCloseMenuItem.Index = 2;
			this.fileCloseMenuItem.MergeOrder = 30;
			this.fileCloseMenuItem.Text = "Close";
			this.fileCloseMenuItem.Click += new System.EventHandler(this.fileCloseMenuItem_Click);
			// 
			// fileSendMenuItem
			// 
			this.fileSendMenuItem.Index = 3;
			this.fileSendMenuItem.Text = "Send...";
			this.fileSendMenuItem.Click += new System.EventHandler(this.fileSendMenuItem_Click);
			// 
			// fileReceiveMenuItem
			// 
			this.fileReceiveMenuItem.Index = 4;
			this.fileReceiveMenuItem.Text = "Receive";
			this.fileReceiveMenuItem.Click += new System.EventHandler(this.fileReceiveMenuItem_Click);
			// 
			// menuItem3
			// 
			this.menuItem3.Index = 5;
			this.menuItem3.Text = "Print Preview...";
			this.menuItem3.Click += new System.EventHandler(this.menuItem3_Click);
			// 
			// menuItem4
			// 
			this.menuItem4.Index = 6;
			this.menuItem4.Text = "Print...";
			this.menuItem4.Click += new System.EventHandler(this.menuItem4_Click);
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
			this.printPreviewDialog1.Location = new System.Drawing.Point(68, 88);
			this.printPreviewDialog1.MinimumSize = new System.Drawing.Size(375, 250);
			this.printPreviewDialog1.Name = "printPreviewDialog1";
			this.printPreviewDialog1.TransparencyKey = System.Drawing.Color.Empty;
			this.printPreviewDialog1.Visible = false;
			// 
			// menuItem5
			// 
			this.menuItem5.Index = 1;
			this.menuItem5.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem6,
																					  this.menuItem7});
			this.menuItem5.Text = "Edit";
			// 
			// menuItem6
			// 
			this.menuItem6.Index = 0;
			this.menuItem6.Text = "Color...";
			this.menuItem6.Click += new System.EventHandler(this.menuItem6_Click);
			// 
			// menuItem7
			// 
			this.menuItem7.Index = 1;
			this.menuItem7.Text = "Width...";
			this.menuItem7.Click += new System.EventHandler(this.menuItem7_Click);
			// 
			// ScribbleForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(720, 446);
			this.Menu = this.mainMenu1;
			this.Name = "ScribbleForm";
			this.Text = "Scribble";
			this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ScribbleForm_MouseDown);
			this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ScribbleForm_MouseUp);
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.ScribbleForm_Paint);
			this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ScribbleForm_MouseMove);

		}
		#endregion

		private void ScribbleForm_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				trazo = new Trazo(color, width);
				trazo.Add(new Point(e.X, e.Y));
			}
		}

		private void ScribbleForm_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (trazo != null)
			{
				trazo.Add(new Point(e.X, e.Y));
				trazo.Draw(this.CreateGraphics());
			}
		}

		private void ScribbleForm_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
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

		private void ScribbleForm_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			dibujo.Draw(e.Graphics);
		}

		private void fileCloseMenuItem_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void menuItem1_Click(object sender, System.EventArgs e)
		{
			DialogResult dr;
			dr = saveFileDialog1.ShowDialog();
			if (dr == DialogResult.OK)
			{
				Stream stm = new FileStream(saveFileDialog1.FileName, 
					FileMode.Create);
				SoapFormatter fmt = new SoapFormatter();
				fmt.Serialize(stm, dibujo);
				stm.Close();
			}
		}

		private void menuItem2_Click(object sender, System.EventArgs e)
		{
			DialogResult dr;
			dr = openFileDialog1.ShowDialog();
			if (dr == DialogResult.OK)
			{
				Stream stm = new FileStream(openFileDialog1.FileName, 
					FileMode.Open);
				SoapFormatter fmt = new SoapFormatter();
				dibujo = (Dibujo) fmt.Deserialize(stm);
				stm.Close();
				this.Invalidate();
				this.Update();
			}
		}

		private void fileReceiveMenuItem_Click(object sender, System.EventArgs e)
		{
			int port = 13000;
			IPAddress localAddr = IPAddress.Parse("127.0.0.1");
      
			TcpListener listener = new TcpListener(localAddr, port);			
			listener.Start();
			TcpClient client = listener.AcceptTcpClient();
			Stream stm = client.GetStream();
			BinaryFormatter fmt = new BinaryFormatter();
			dibujo = (Dibujo) fmt.Deserialize(stm);
			stm.Close();
			client.Close();
			listener.Stop();
			this.Invalidate();
			this.Update();
		}

		private void fileSendMenuItem_Click(object sender, System.EventArgs e)
		{
			int port = 13000;
			TcpClient client = new TcpClient();
			client.Connect("localhost", port);
			Stream stm = client.GetStream();
			BinaryFormatter fmt = new BinaryFormatter();
			fmt.Serialize(stm, dibujo);
			stm.Close();
			client.Close();
		}

		private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
		{
			dibujo.Draw(e.Graphics);
			//e.HasMorePages = true;
		}

		private void menuItem4_Click(object sender, System.EventArgs e)
		{
			printDocument1.Print();
		}

		private void menuItem3_Click(object sender, System.EventArgs e)
		{
			printPreviewDialog1.Document = printDocument1;
			printPreviewDialog1.ShowDialog();
		}

		private void menuItem6_Click(object sender, System.EventArgs e)
		{
			DialogResult dr;
			colorDialog1.Color = color;
			dr = colorDialog1.ShowDialog();
			if (dr == DialogResult.OK)
			{
				color = colorDialog1.Color;
			}
		}

		private void menuItem7_Click(object sender, System.EventArgs e)
		{
			DialogResult dr;
			WidthForm f = new WidthForm();
			f.SelectedWidth = width;
			dr = f.ShowDialog();
			if (dr == DialogResult.OK)
			{
				width = f.SelectedWidth;
			}
		}
	}
}











