namespace ecgmonitor
{
	partial class formAnalyse
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formAnalyse));
			this.panel1 = new System.Windows.Forms.Panel();
			this.progressBar1 = new System.Windows.Forms.ProgressBar();
			this.decg = new System.Windows.Forms.RadioButton();
			this.dst = new System.Windows.Forms.RadioButton();
			this.dpr = new System.Windows.Forms.RadioButton();
			this.graph1 = new ecgmonitor.SignalGraph();
			this.slider1 = new ecgmonitor.Slider();
			this.ribon1 = new ecgmonitor.ribon();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.panel1.BackgroundImage = global::ecgmonitor.box.backg;
			this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.panel1.Controls.Add(this.progressBar1);
			this.panel1.Controls.Add(this.decg);
			this.panel1.Controls.Add(this.dst);
			this.panel1.Controls.Add(this.dpr);
			this.panel1.Controls.Add(this.graph1);
			this.panel1.Controls.Add(this.slider1);
			this.panel1.Controls.Add(this.ribon1);
			this.panel1.Location = new System.Drawing.Point(4, 34);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(856, 403);
			this.panel1.TabIndex = 0;
			// 
			// progressBar1
			// 
			this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.progressBar1.Location = new System.Drawing.Point(520, 7);
			this.progressBar1.Name = "progressBar1";
			this.progressBar1.Size = new System.Drawing.Size(100, 23);
			this.progressBar1.TabIndex = 6;
			// 
			// decg
			// 
			this.decg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.decg.AutoSize = true;
			this.decg.Checked = true;
			this.decg.Location = new System.Drawing.Point(635, 9);
			this.decg.Name = "decg";
			this.decg.Size = new System.Drawing.Size(50, 21);
			this.decg.TabIndex = 5;
			this.decg.TabStop = true;
			this.decg.Text = "ECG";
			this.decg.UseVisualStyleBackColor = true;
			// 
			// dst
			// 
			this.dst.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.dst.AutoSize = true;
			this.dst.Location = new System.Drawing.Point(691, 9);
			this.dst.Name = "dst";
			this.dst.Size = new System.Drawing.Size(40, 21);
			this.dst.TabIndex = 4;
			this.dst.Text = "ST";
			this.dst.UseVisualStyleBackColor = true;
			// 
			// dpr
			// 
			this.dpr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.dpr.AutoSize = true;
			this.dpr.Checked = true;
			this.dpr.Location = new System.Drawing.Point(737, 9);
			this.dpr.Name = "dpr";
			this.dpr.Size = new System.Drawing.Size(86, 21);
			this.dpr.TabIndex = 3;
			this.dpr.TabStop = true;
			this.dpr.Text = "Pulse Rate";
			this.dpr.UseVisualStyleBackColor = true;
			// 
			// graph1
			// 
			this.graph1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.graph1.Location = new System.Drawing.Point(0, 73);
			this.graph1.Name = "graph1";
			this.graph1.Size = new System.Drawing.Size(856, 330);
			this.graph1.TabIndex = 2;
			this.graph1.Text = "heartbeatflow1";
			// 
			// slider1
			// 
			this.slider1.Dock = System.Windows.Forms.DockStyle.Top;
			this.slider1.Location = new System.Drawing.Point(0, 42);
			this.slider1.Name = "slider1";
			this.slider1.Size = new System.Drawing.Size(856, 31);
			this.slider1.TabIndex = 1;
			this.slider1.Text = "slider1";
			// 
			// ribon1
			// 
			this.ribon1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(30)))), ((int)(((byte)(40)))));
			this.ribon1.Dock = System.Windows.Forms.DockStyle.Top;
			this.ribon1.Location = new System.Drawing.Point(0, 0);
			this.ribon1.Margin = new System.Windows.Forms.Padding(0);
			this.ribon1.Name = "ribon1";
			this.ribon1.Size = new System.Drawing.Size(856, 42);
			this.ribon1.TabIndex = 0;
			// 
			// formAnalyse
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BorderSize = 2;
			this.ClientSize = new System.Drawing.Size(864, 441);
			this.ColorBorder = System.Drawing.Color.Crimson;
			this.ColorDefault = System.Drawing.Color.Black;
			this.ColorText = System.Drawing.Color.Gainsboro;
			this.Controls.Add(this.panel1);
			this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ForeColor = System.Drawing.Color.Gainsboro;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.IsDark = true;
			this.MaximumSize = new System.Drawing.Size(1366, 728);
			this.MinimizeBox = false;
			this.Name = "formAnalyse";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Analyses";
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private ribon ribon1;
		private Slider slider1;
		private SignalGraph graph1;
		private System.Windows.Forms.RadioButton dst;
		private System.Windows.Forms.RadioButton dpr;
		private System.Windows.Forms.RadioButton decg;
		private System.Windows.Forms.ProgressBar progressBar1;
	}
}