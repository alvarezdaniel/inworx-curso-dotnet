using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Scribble
{
	/// <summary>
	/// Summary description for MainForm.
	/// </summary>
	public class MainForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem FileMenuItem;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem FileExitMenuItem;
		private System.Windows.Forms.MenuItem FileNewMenuItem;
		private System.Windows.Forms.MenuItem WindowMenuItem;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.MenuItem menuItem4;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public MainForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			this.ShowInTaskbar = true;
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
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			this.FileMenuItem = new System.Windows.Forms.MenuItem();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.FileExitMenuItem = new System.Windows.Forms.MenuItem();
			this.FileNewMenuItem = new System.Windows.Forms.MenuItem();
			this.WindowMenuItem = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.menuItem3 = new System.Windows.Forms.MenuItem();
			this.menuItem4 = new System.Windows.Forms.MenuItem();
			// 
			// mainMenu1
			// 
			this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.FileMenuItem,
																					  this.WindowMenuItem});
			// 
			// FileMenuItem
			// 
			this.FileMenuItem.Index = 0;
			this.FileMenuItem.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						 this.FileNewMenuItem,
																						 this.menuItem1,
																						 this.FileExitMenuItem});
			this.FileMenuItem.MergeType = System.Windows.Forms.MenuMerge.MergeItems;
			this.FileMenuItem.Text = "File";
			this.FileMenuItem.Click += new System.EventHandler(this.FileMenuItem_Click);
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 1;
			this.menuItem1.MergeOrder = 98;
			this.menuItem1.Text = "-";
			// 
			// FileExitMenuItem
			// 
			this.FileExitMenuItem.Index = 2;
			this.FileExitMenuItem.MergeOrder = 99;
			this.FileExitMenuItem.Text = "Exit";
			// 
			// FileNewMenuItem
			// 
			this.FileNewMenuItem.Index = 0;
			this.FileNewMenuItem.Text = "New";
			this.FileNewMenuItem.Click += new System.EventHandler(this.FileNewMenuItem_Click);
			// 
			// WindowMenuItem
			// 
			this.WindowMenuItem.Index = 1;
			this.WindowMenuItem.MdiList = true;
			this.WindowMenuItem.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						   this.menuItem2,
																						   this.menuItem3,
																						   this.menuItem4});
			this.WindowMenuItem.Text = "Window";
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 0;
			this.menuItem2.Text = "Horizontal";
			this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
			// 
			// menuItem3
			// 
			this.menuItem3.Index = 1;
			this.menuItem3.Text = "Vertical";
			this.menuItem3.Click += new System.EventHandler(this.menuItem3_Click);
			// 
			// menuItem4
			// 
			this.menuItem4.Index = 2;
			this.menuItem4.Text = "Cascada";
			this.menuItem4.Click += new System.EventHandler(this.menuItem4_Click);
			// 
			// MainForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(552, 273);
			this.IsMdiContainer = true;
			this.Menu = this.mainMenu1;
			this.Name = "MainForm";
			this.Text = "MainForm";

		}
		#endregion

		private void FileMenuItem_Click(object sender, System.EventArgs e)
		{
		
		}

		private void FileNewMenuItem_Click(object sender, System.EventArgs e)
		{
			ScribbleForm f = new ScribbleForm();
			f.MdiParent = this;
			f.Show();
		}

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new MainForm());
		}

		private void menuItem2_Click(object sender, System.EventArgs e)
		{
			this.LayoutMdi(MdiLayout.TileHorizontal);
		
		}

		private void menuItem3_Click(object sender, System.EventArgs e)
		{
			this.LayoutMdi(MdiLayout.TileVertical);
		
		}

		private void menuItem4_Click(object sender, System.EventArgs e)
		{
			this.LayoutMdi(MdiLayout.Cascade);
		}
	}
}
