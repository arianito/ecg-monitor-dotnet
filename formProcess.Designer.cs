namespace ecgmonitor
{
	partial class formProcess
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formProcess));
			this.panel1 = new System.Windows.Forms.Panel();
			this.button2 = new ecgmonitor.button();
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.progressBar1 = new System.Windows.Forms.ProgressBar();
			this.button1 = new ecgmonitor.button();
			this.label1 = new System.Windows.Forms.Label();
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
			this.panel1.Controls.Add(this.listBox1);
			this.panel1.Controls.Add(this.progressBar1);
			this.panel1.Controls.Add(this.button1);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Location = new System.Drawing.Point(4, 34);
			this.panel1.Name = "panel1";
			this.panel1.Padding = new System.Windows.Forms.Padding(3);
			this.panel1.Size = new System.Drawing.Size(383, 422);
			this.panel1.TabIndex = 0;
			this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
			// 
			// button2
			// 
			this.button2.Color = System.Drawing.Color.LightSteelBlue;
			this.button2.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.button2.Focusable = true;
			this.button2.ImageSize = new System.Drawing.SizeF(24F, 24F);
			this.button2.Location = new System.Drawing.Point(254, 359);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 23);
			this.button2.TabIndex = 4;
			this.button2.Text = "Goto";
			this.button2.UseVisualStyleBackColor = true;
			// 
			// listBox1
			// 
			this.listBox1.FormattingEnabled = true;
			this.listBox1.ItemHeight = 17;
			this.listBox1.Location = new System.Drawing.Point(39, 128);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(290, 225);
			this.listBox1.TabIndex = 3;
			// 
			// progressBar1
			// 
			this.progressBar1.Location = new System.Drawing.Point(39, 53);
			this.progressBar1.Name = "progressBar1";
			this.progressBar1.Size = new System.Drawing.Size(290, 23);
			this.progressBar1.TabIndex = 0;
			// 
			// button1
			// 
			this.button1.Color = System.Drawing.Color.LightSteelBlue;
			this.button1.Focusable = true;
			this.button1.ImageSize = new System.Drawing.SizeF(24F, 24F);
			this.button1.Location = new System.Drawing.Point(254, 82);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 2;
			this.button1.Text = "start";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(36, 33);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(210, 17);
			this.label1.TabIndex = 1;
			this.label1.Text = "Processing where button pressed :";
			// 
			// formProcess
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BorderSize = 2;
			this.ClientSize = new System.Drawing.Size(391, 460);
			this.ColorBorder = System.Drawing.Color.DeepSkyBlue;
			this.ColorDefault = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(30)))), ((int)(((byte)(40)))));
			this.ColorText = System.Drawing.Color.Gainsboro;
			this.Controls.Add(this.panel1);
			this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ForeColor = System.Drawing.Color.Gainsboro;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.IsDark = true;
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(1366, 728);
			this.MinimizeBox = false;
			this.Name = "formProcess";
			this.Resizable = false;
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Process";
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private button button1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ProgressBar progressBar1;
		private button button2;
		public System.Windows.Forms.ListBox listBox1;
	}
}