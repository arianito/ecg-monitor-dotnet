namespace ecgmonitor
{
	partial class formMain
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formMain));
			this.panel1 = new System.Windows.Forms.Panel();
			this.panel2 = new System.Windows.Forms.Panel();
			this.graph1 = new ecgmonitor.SignalGraph();
			this.slider1 = new ecgmonitor.Slider();
			this.ribon1 = new ecgmonitor.ribon();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(60)))), ((int)(((byte)(70)))));
			this.panel1.Controls.Add(this.panel2);
			this.panel1.Location = new System.Drawing.Point(4, 34);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(912, 550);
			this.panel1.TabIndex = 0;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.graph1);
			this.panel2.Controls.Add(this.slider1);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(912, 550);
			this.panel2.TabIndex = 3;
			// 
			// graph1
			// 
			this.graph1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.graph1.Location = new System.Drawing.Point(0, 36);
			this.graph1.Name = "graph1";
			this.graph1.Size = new System.Drawing.Size(912, 514);
			this.graph1.TabIndex = 1;
			this.graph1.Text = "graph1";
			// 
			// slider1
			// 
			this.slider1.Dock = System.Windows.Forms.DockStyle.Top;
			this.slider1.Location = new System.Drawing.Point(0, 0);
			this.slider1.Name = "slider1";
			this.slider1.Size = new System.Drawing.Size(912, 36);
			this.slider1.TabIndex = 3;
			this.slider1.Text = "slider1";
			// 
			// ribon1
			// 
			this.ribon1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(30)))), ((int)(((byte)(40)))));
			this.ribon1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.ribon1.Location = new System.Drawing.Point(1, 584);
			this.ribon1.Margin = new System.Windows.Forms.Padding(2);
			this.ribon1.Name = "ribon1";
			this.ribon1.Size = new System.Drawing.Size(918, 42);
			this.ribon1.TabIndex = 4;
			// 
			// formMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BorderSize = 2;
			this.ClientSize = new System.Drawing.Size(920, 627);
			this.ColorBorder = System.Drawing.Color.ForestGreen;
			this.ColorDefault = System.Drawing.Color.Black;
			this.ColorText = System.Drawing.Color.Gainsboro;
			this.Controls.Add(this.ribon1);
			this.Controls.Add(this.panel1);
			this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ForeColor = System.Drawing.Color.Gainsboro;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.IsDark = true;
			this.MaximumSize = new System.Drawing.Size(1366, 728);
			this.Name = "formMain";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "ECG Monitoring [DEMO]";
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private ribon ribon1;
		public SignalGraph graph1;
		public Slider slider1;

	}
}

