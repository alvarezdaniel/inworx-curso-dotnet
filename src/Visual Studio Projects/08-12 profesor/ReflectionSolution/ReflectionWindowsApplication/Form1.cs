using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Configuration;
using System.Reflection;
using System.Diagnostics;

namespace ReflectionWindowsApplication
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
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
			this.button1 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(264, 128);
			this.button1.Name = "button1";
			this.button1.TabIndex = 0;
			this.button1.Text = "button1";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(592, 350);
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
			HandlerDelBoton(sender, e);
		}

		[Conditional("FULL")]
		private void HandlerDelBoton(object sender, System.EventArgs e)
		{
			string strClase, strMetodo;
			strClase = ConfigurationSettings.AppSettings["Clase"];
			strMetodo = ConfigurationSettings.AppSettings["Metodo"];
			Type t = Type.GetType(strClase);
			object ab = t.InvokeMember(null, 
				BindingFlags.CreateInstance, 
				null, null, null);
			object result = t.InvokeMember(strMetodo, 
				BindingFlags.InvokeMethod, 
				null, ab, null);
			MessageBox.Show(result.ToString());
			Assembly asm;
			asm = Assembly.LoadWithPartialName("System.Windows.Forms");
			Type[] types = asm.GetTypes();
			MessageBox.Show("En " + asm.FullName + " hay " + types.Length.ToString() + " clases");
			Type type = asm.GetType("System.Windows.Forms.Button");

		}
	}
}












