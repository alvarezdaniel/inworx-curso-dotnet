using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using ScribbleLib;
using System.IO;
using System.Runtime.Serialization.Formatters.Soap;
using System.Runtime.Serialization.Formatters.Binary;
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
		private System.Windows.Forms.MenuItem FileMenuItem;
		private System.Windows.Forms.MenuItem FileCloseMenuItem;
		private System.Windows.Forms.MainMenu mainMenu;
		private System.Windows.Forms.MenuItem FileSaveAsMenuItem;
		private System.Windows.Forms.MenuItem FileOpenMenuItem;
		private System.Windows.Forms.SaveFileDialog saveFileDialog1;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.MenuItem FileSendMenuItem;
		private System.Windows.Forms.MenuItem FileReceiveMenuItem;
		private System.Windows.Forms.MenuItem FilePrintMenuItem;
		private System.Windows.Forms.MenuItem FilePrintPreviewMenuItem;
		private System.Drawing.Printing.PrintDocument printDocument1;
		private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
		private System.Windows.Forms.MenuItem EditMenuItem;
		private System.Windows.Forms.MenuItem ColorMenuItem;
		private System.Windows.Forms.ColorDialog colorDialog1;
		private Trazo trazo;
		private Color color;
		private System.Windows.Forms.MenuItem WidthMenuItem;
		private float width;

		public ScribbleForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

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
				if(components != null)
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
			this.mainMenu = new System.Windows.Forms.MainMenu();
			this.FileMenuItem = new System.Windows.Forms.MenuItem();
			this.FileCloseMenuItem = new System.Windows.Forms.MenuItem();
			this.FileSaveAsMenuItem = new System.Windows.Forms.MenuItem();
			this.FileOpenMenuItem = new System.Windows.Forms.MenuItem();
			this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.FileSendMenuItem = new System.Windows.Forms.MenuItem();
			this.FileReceiveMenuItem = new System.Windows.Forms.MenuItem();
			this.FilePrintMenuItem = new System.Windows.Forms.MenuItem();
			this.FilePrintPreviewMenuItem = new System.Windows.Forms.MenuItem();
			this.printDocument1 = new System.Drawing.Printing.PrintDocument();
			this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
			this.EditMenuItem = new System.Windows.Forms.MenuItem();
			this.ColorMenuItem = new System.Windows.Forms.MenuItem();
			this.colorDialog1 = new System.Windows.Forms.ColorDialog();
			this.WidthMenuItem = new System.Windows.Forms.MenuItem();
			// 
			// mainMenu
			// 
			this.mainMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					 this.FileMenuItem,
																					 this.EditMenuItem});
			// 
			// FileMenuItem
			// 
			this.FileMenuItem.Index = 0;
			this.FileMenuItem.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						 this.FileOpenMenuItem,
																						 this.FileSaveAsMenuItem,
																						 this.FileCloseMenuItem,
																						 this.FileSendMenuItem,
																						 this.FileReceiveMenuItem,
																						 this.FilePrintMenuItem,
																						 this.FilePrintPreviewMenuItem});
			this.FileMenuItem.MergeType = System.Windows.Forms.MenuMerge.MergeItems;
			this.FileMenuItem.Text = "File";
			// 
			// FileCloseMenuItem
			// 
			this.FileCloseMenuItem.Index = 2;
			this.FileCloseMenuItem.MergeOrder = 30;
			this.FileCloseMenuItem.MergeType = System.Windows.Forms.MenuMerge.MergeItems;
			this.FileCloseMenuItem.Text = "Close";
			this.FileCloseMenuItem.Click += new System.EventHandler(this.FileCloseMenuItem_Click);
			// 
			// FileSaveAsMenuItem
			// 
			this.FileSaveAsMenuItem.Index = 1;
			this.FileSaveAsMenuItem.Text = "Save As";
			this.FileSaveAsMenuItem.Click += new System.EventHandler(this.FileSaveAsMenuItem_Click);
			// 
			// FileOpenMenuItem
			// 
			this.FileOpenMenuItem.Index = 0;
			this.FileOpenMenuItem.Text = "Open";
			this.FileOpenMenuItem.Click += new System.EventHandler(this.FileOpenMenuItem_Click);
			// 
			// FileSendMenuItem
			// 
			this.FileSendMenuItem.Index = 3;
			this.FileSendMenuItem.Text = "Send";
			this.FileSendMenuItem.Click += new System.EventHandler(this.FileSendMenuItem_Click);
			// 
			// FileReceiveMenuItem
			// 
			this.FileReceiveMenuItem.Index = 4;
			this.FileReceiveMenuItem.Text = "Receive";
			this.FileReceiveMenuItem.Click += new System.EventHandler(this.FileReceiveMenuItem_Click);
			// 
			// FilePrintMenuItem
			// 
			this.FilePrintMenuItem.Index = 5;
			this.FilePrintMenuItem.Text = "Print";
			this.FilePrintMenuItem.Click += new System.EventHandler(this.FilePrintMenuItem_Click);
			// 
			// FilePrintPreviewMenuItem
			// 
			this.FilePrintPreviewMenuItem.Index = 6;
			this.FilePrintPreviewMenuItem.Text = "Preview";
			this.FilePrintPreviewMenuItem.Click += new System.EventHandler(this.FilePrintPreviewMenuItem_Click);
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
			this.printPreviewDialog1.Location = new System.Drawing.Point(67, 88);
			this.printPreviewDialog1.MinimumSize = new System.Drawing.Size(375, 250);
			this.printPreviewDialog1.Name = "printPreviewDialog1";
			this.printPreviewDialog1.TransparencyKey = System.Drawing.Color.Empty;
			this.printPreviewDialog1.Visible = false;
			// 
			// EditMenuItem
			// 
			this.EditMenuItem.Index = 1;
			this.EditMenuItem.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						 this.ColorMenuItem,
																						 this.WidthMenuItem});
			this.EditMenuItem.Text = "Edit";
			// 
			// ColorMenuItem
			// 
			this.ColorMenuItem.Index = 0;
			this.ColorMenuItem.Text = "Color";
			this.ColorMenuItem.Click += new System.EventHandler(this.ColorMenuItem_Click);
			// 
			// WidthMenuItem
			// 
			this.WidthMenuItem.Index = 1;
			this.WidthMenuItem.Text = "Width";
			this.WidthMenuItem.Click += new System.EventHandler(this.WidthMenuItem_Click);
			// 
			// ScribbleForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(292, 266);
			this.Menu = this.mainMenu;
			this.Name = "ScribbleForm";
			this.ShowInTaskbar = false;
			this.Text = "ScribbleForm";
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

		private void FileCloseMenuItem_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void FileSaveAsMenuItem_Click(object sender, System.EventArgs e)
		{
			DialogResult dr;
			dr = saveFileDialog1.ShowDialog();
			if (dr == DialogResult.OK)
			{
				FileStream stm = new FileStream(saveFileDialog1.FileName, 
					FileMode.Create);
				try
				{
					SoapFormatter fmt = new SoapFormatter();
					fmt.Serialize(stm, dibujo);
				}
				finally
				{
					stm.Close();
				}
			}
		}

		private void FileOpenMenuItem_Click(object sender, System.EventArgs e)
		{
			DialogResult dr;
			dr = openFileDialog1.ShowDialog();
			if (dr == DialogResult.OK)
			{
				FileStream stm = new FileStream(openFileDialog1.FileName, 
					FileMode.Open);
				try
				{
					SoapFormatter fmt = new SoapFormatter();
					dibujo = (Dibujo) fmt.Deserialize(stm);
				}
				finally
				{
					stm.Close();
				}
				this.Invalidate();
				this.Update();
			}
		}

		private void FileSendMenuItem_Click(object sender, System.EventArgs e)
		{
			int port = 3000;
			//IPAddress localAdd = IPAddress.Parse("127.0.0.1");
			IPAddress localAdd = IPAddress.Parse("192.168.0.75");
			TcpClient client = new TcpClient();
			client.Connect(localAdd, port);
			Stream stm = client.GetStream();
			BinaryFormatter fmt = new BinaryFormatter();
			fmt.Serialize(stm, dibujo);
			stm.Close();
			client.Close();
		}

		private void FileReceiveMenuItem_Click(object sender, System.EventArgs e)
		{
			int port = 3000;
			IPAddress localAdd = IPAddress.Parse("192.168.0.75");
			TcpListener listener = new TcpListener(localAdd, port);		
			listener.Start();
			TcpClient client = listener.AcceptTcpClient();
			NetworkStream stm = client.GetStream();
			BinaryFormatter fmt = new BinaryFormatter();
			dibujo = (Dibujo) fmt.Deserialize(stm);
			stm.Close();
			client.Close();
			this.Invalidate();
			this.Update();
		}

		private void FilePrintMenuItem_Click(object sender, System.EventArgs e)
		{
			printDocument1.Print();
		
		}

		private void FilePrintPreviewMenuItem_Click(object sender, System.EventArgs e)
		{
			printPreviewDialog1.Document = printDocument1;
			printPreviewDialog1.ShowDialog();
		}

		private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
		{
			dibujo.Draw(e.Graphics);
		}

		private void ColorMenuItem_Click(object sender, System.EventArgs e)
		{
			DialogResult dr;
			colorDialog1.Color = color;
			dr = colorDialog1.ShowDialog();
			if (dr == DialogResult.OK)
			{
				color = colorDialog1.Color;
			}
		}

		private void WidthMenuItem_Click(object sender, System.EventArgs e)
		{
			DialogResult dr;
			WidthForm dlg = new WidthForm();
			dlg.SelectedWidth = width;
			dr = dlg.ShowDialog();
			if (dr == DialogResult.OK)
			{
				width = dlg.SelectedWidth;
			}
		}
	}
}
