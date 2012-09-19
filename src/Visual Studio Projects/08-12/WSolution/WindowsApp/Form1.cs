using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Reflection;

namespace WindowsApp
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
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
            System.Xml.XmlDocument Doc = new System.Xml.XmlDocument();
            Doc.Load("c:\\Controles.xml");
            System.Xml.XmlNodeList lista;
            lista = Doc.SelectNodes(@"//Control");
            System.Xml.XmlElement e;
            string clase, top, heigh, left, width, text;
            //Assembly objAssembly=System.Reflection.Assembly.LoadFrom("C:\\Windows\\Microsoft.NET\\Framework\\v1.1.4322\\System.Windows.Forms.dll");
            Assembly objAssembly = Assembly.LoadWithPartialName("System.Windows.Forms");
            Object b;
            for (int i=0; i < lista.Count; i++)
            {
                e = (System.Xml.XmlElement)lista[i];
                clase = e.GetAttribute("clase");
                top = e.GetAttribute("top");
                heigh = e.GetAttribute("height");
                left = e.GetAttribute("left");
                width = e.GetAttribute("width");
                text = e.GetAttribute("text");
                Type t = objAssembly.GetType(clase);
                //b = Activator.CreateInstance(t);
                b = t.InvokeMember("", BindingFlags.CreateInstance, null, null, null);
                //Activator.CreateInstance(t);
                
                /*
                Button c = (Button)b;
                c.Location = new System.Drawing.Point(int.Parse(left) , int.Parse(top));
                c.Text = text;
                c.Name = "boton" + i.ToString();
                */
                t.InvokeMember("Location", BindingFlags.SetProperty, null, b, 
                    new object[] {new System.Drawing.Point(int.Parse(left) , int.Parse(top))});
                t.InvokeMember("Text", BindingFlags.SetProperty, null, b, new object[] {text});
                t.InvokeMember("Name", BindingFlags.SetProperty, null, b, new object[] {"control" + i.ToString()});

                //PropertyInfo pi = t.GetProperty("Name"); 
                //PropertyInfo pi2 = t.GetProperty("Pepe"); 

                this.Controls.Add((Control)b);
            }
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
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Name = "Form1";
            this.Text = "Form1";

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
	}
}
