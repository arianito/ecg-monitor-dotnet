namespace ecgmonitor
{
	partial class formPrint
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formPrint));
			this.panel1 = new System.Windows.Forms.Panel();
			this.button2 = new ecgmonitor.button();
			this.button1 = new ecgmonitor.button();
			this.slider1 = new ecgmonitor.Slider();
			this.printPreviewControl1 = new System.Windows.Forms.PrintPreviewControl();
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
			this.panel1.Controls.Add(this.button2);
			this.panel1.Controls.Add(this.button1);
			this.panel1.Controls.Add(this.slider1);
			this.panel1.Controls.Add(this.printPreviewControl1);
			this.panel1.Location = new System.Drawing.Point(4, 34);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(856, 396);
			this.panel1.TabIndex = 0;
			// 
			// button2
			// 
			this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.button2.Color = System.Drawing.Color.LightSteelBlue;
			this.button2.Focusable = true;
			this.button2.ImageSize = new System.Drawing.SizeF(24F, 24F);
			this.button2.Location = new System.Drawing.Point(743, 366);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 23);
			this.button2.TabIndex = 3;
			this.button2.Text = "Reset";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button1
			// 
			this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.button1.Color = System.Drawing.Color.LightSteelBlue;
			this.button1.Focusable = true;
			this.button1.ImageSize = new System.Drawing.SizeF(24F, 24F);
			this.button1.Location = new System.Drawing.Point(662, 366);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 2;
			this.button1.Text = "Print";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// slider1
			// 
			this.slider1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.slider1.Location = new System.Drawing.Point(3, 3);
			this.slider1.Name = "slider1";
			this.slider1.Size = new System.Drawing.Size(850, 59);
			this.slider1.TabIndex = 1;
			this.slider1.Text = "slider1";
			// 
			// printPreviewControl1
			// 
			this.printPreviewControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.printPreviewControl1.AutoZoom = false;
			this.printPreviewControl1.Location = new System.Drawing.Point(6, 68);
			this.printPreviewControl1.Name = "printPreviewControl1";
			this.printPreviewControl1.Rows = 3;
			this.printPreviewControl1.Size = new System.Drawing.Size(850, 292);
			this.printPreviewControl1.TabIndex = 0;
			this.printPreviewControl1.Zoom = 1;
			// 
			// formPrint
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BorderSize = 2;
			this.ClientSize = new System.Drawing.Size(864, 434);
			this.ColorBorder = System.Drawing.Color.Black;
			this.ColorDefault = System.Drawing.Color.Black;
			this.ColorText = System.Drawing.Color.Gainsboro;
			this.Controls.Add(this.panel1);
			this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ForeColor = System.Drawing.Color.Gainsboro;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.IsDark = true;
			this.MaximumSize = new System.Drawing.Size(1366, 728);
			this.MinimizeBox = false;
			this.Name = "formPrint";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Print";
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.PrintPreviewControl printPreviewControl1;
		private button button1;
		private Slider slider1;
		private button button2;
	}
}