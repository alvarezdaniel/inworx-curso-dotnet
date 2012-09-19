using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Scribble
{
	/// <summary>
	/// Summary description for WidthForm.
	/// </summary>
	public class WidthForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button btnAceptar;
		private System.Windows.Forms.Button btnCancelar;
		private System.Windows.Forms.NumericUpDown nudAncho;
		private System.Windows.Forms.Label label1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private float selectedWidth;

		public WidthForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			SelectedWidth = 1;

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
			this.btnAceptar = new System.Windows.Forms.Button();
			this.btnCancelar = new System.Windows.Forms.Button();
			this.nudAncho = new System.Windows.Forms.NumericUpDown();
			this.label1 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.nudAncho)).BeginInit();
			this.SuspendLayout();
			// 
			// btnAceptar
			// 
			this.btnAceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnAceptar.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnAceptar.Location = new System.Drawing.Point(116, 132);
			this.btnAceptar.Name = "btnAceptar";
			this.btnAceptar.TabIndex = 0;
			this.btnAceptar.Text = "Aceptar";
			this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
			// 
			// btnCancelar
			// 
			this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancelar.Location = new System.Drawing.Point(196, 132);
			this.btnCancelar.Name = "btnCancelar";
			this.btnCancelar.TabIndex = 1;
			this.btnCancelar.Text = "Cancelar";
			// 
			// nudAncho
			// 
			this.nudAncho.Location = new System.Drawing.Point(72, 16);
			this.nudAncho.Name = "nudAncho";
			this.nudAncho.TabIndex = 2;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(48, 23);
			this.label1.TabIndex = 3;
			this.label1.Text = "Ancho";
			// 
			// WidthForm
			// 
			this.AcceptButton = this.btnAceptar;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btnCancelar;
			this.ClientSize = new System.Drawing.Size(280, 166);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.nudAncho);
			this.Controls.Add(this.btnCancelar);
			this.Controls.Add(this.btnAceptar);
			this.Name = "WidthForm";
			this.Text = "WidthForm";
			((System.ComponentModel.ISupportInitialize)(this.nudAncho)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void btnAceptar_Click(object sender, System.EventArgs e)
		{
		}

		public float SelectedWidth
		{
			get{return float.Parse(nudAncho.Value.ToString());}
			set{nudAncho.Value = decimal.Parse(value.ToString());}
		}
	}
}
