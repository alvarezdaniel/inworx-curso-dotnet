using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace SemaforoLib
{
	/// <summary>
	/// Summary description for Semaforo.
	/// </summary>
	public class Semaforo : System.Windows.Forms.UserControl
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		public enum SemaforoState 
		{
			Started,
			Stopped,
			Paused
		}

		private SemaforoState estado = SemaforoState.Stopped;

		public SemaforoState Estado
		{
			get{return estado;}
			set{
				estado = value;
				ReDrawSemaforo();
			}

		}

		public Semaforo()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitializeComponent call

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

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			// 
			// Semaforo
			// 
			this.Name = "Semaforo";
			this.Size = new System.Drawing.Size(104, 192);
			this.Resize += new System.EventHandler(this.Semaforo_Resize);
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.Semaforo_Paint);

		}
		#endregion

		private void Semaforo_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			Rectangle r1, r2, r3;
			int RectHeight = this.ClientRectangle.Height / 3;
			r1 = new Rectangle(0, 0, this.ClientRectangle.Width,
									 RectHeight);
			r2 = new Rectangle(0, RectHeight, 
								  this.ClientRectangle.Width,
									RectHeight);
			r3 = new Rectangle(0, 2 * RectHeight, 
				this.ClientRectangle.Width,
				this.ClientRectangle.Height - (2 * RectHeight));
			Graphics g = e.Graphics;
			Pen pen = new Pen(Color.Black);

			if (estado == SemaforoState.Paused)
			{
				g.FillEllipse(new SolidBrush(Color.Yellow), r2);
			}
			else if (estado == SemaforoState.Started)
			{
				g.FillEllipse(new SolidBrush(Color.Green), r1);
			}
			else if (estado == SemaforoState.Stopped)
			{
				g.FillEllipse(new SolidBrush(Color.Red), r3);
			};
			g.DrawEllipse(pen, r1);
			g.DrawEllipse(pen, r2);
			g.DrawEllipse(pen, r3);
		
		}

		private void Semaforo_Resize(object sender, System.EventArgs e)
		{
			ReDrawSemaforo();
		}

		private void ReDrawSemaforo()
		{
			this.Invalidate();
			this.Update();
		}
	}
}
