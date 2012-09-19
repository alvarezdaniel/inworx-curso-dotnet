using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace Semaforo
{
    public enum SemaforoEstado
    {
        Started,
        Stoped,
        Paused
    }
    /// <summary>
	/// Summary description for Semaforo.
	/// </summary>
	public class Semaforo : System.Windows.Forms.UserControl
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
        private SemaforoEstado estado;
        
        public SemaforoEstado Estado
        {
            get {return estado;}
            set {this.estado = value;
                 this.Invalidate();}
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
            this.Resize += new System.EventHandler(this.Semaforo_Resize);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Semaforo_Paint);

        }
		#endregion

        private void Semaforo_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            Rectangle r1, r2, r3;
            r1 = new Rectangle(0, 0, this.ClientRectangle.Width, this.ClientRectangle.Height/3);
            r2 = new Rectangle(0, this.ClientRectangle.Height/3, this.ClientRectangle.Width, this.ClientRectangle.Height/3);
            r3 = new Rectangle(0, this.ClientRectangle.Height/3*2, this.ClientRectangle.Width, this.ClientRectangle.Height/3);
            Graphics g = this.CreateGraphics();
            Pen p = new Pen(Color.Gray);
            SolidBrush b = new SolidBrush(Color.Gray);
            if (estado == SemaforoEstado.Paused)
            {
              g.FillEllipse(b, r1);  
              g.FillEllipse(b, r3);  
              b.Color = Color.Yellow;
              g.FillEllipse(b, r2);  
              p.Color = Color.Yellow;
            }
            else if (estado == SemaforoEstado.Started)
            {
                g.FillEllipse(b, r2);  
                g.FillEllipse(b, r3);  
                b.Color = Color.Green;
                g.FillEllipse(b, r1);  
            }
            else
            {   
                g.FillEllipse(b, r1);  
                g.FillEllipse(b, r2);  
                b.Color = Color.Red;
                g.FillEllipse(b, r3);  
            }
        }

        private void Semaforo_Resize(object sender, System.EventArgs e)
        {
            this.Invalidate();
            this.Update();
        }
	}
}
