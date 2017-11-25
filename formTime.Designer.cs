namespace ecgmonitor
{
	partial class formTime
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formTime));
			this.panel1 = new System.Windows.Forms.Panel();
			this.label1 = new System.Windows.Forms.Label();
			this.mDays = new System.Windows.Forms.NumericUpDown();
			this.label4 = new System.Windows.Forms.Label();
			this.mTime = new System.Windows.Forms.MaskedTextBox();
			this.button2 = new ecgmonitor.button();
			this.button1 = new ecgmonitor.button();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.mDays)).BeginInit();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.panel1.BackgroundImage = global::ecgmonitor.box.backg;
			this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.mDays);
			this.panel1.Controls.Add(this.label4);
			this.panel1.Controls.Add(this.mTime);
			this.panel1.Controls.Add(this.button2);
			this.panel1.Controls.Add(this.button1);
			this.panel1.Location = new System.Drawing.Point(4, 34);
			this.panel1.Name = "panel1";
			this.panel1.Padding = new System.Windows.Forms.Padding(3);
			this.panel1.Size = new System.Drawing.Size(383, 189);
			this.panel1.TabIndex = 0;
			this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.Location = new System.Drawing.Point(59, 47);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(39, 17);
			this.label1.TabIndex = 8;
			this.label1.Text = "Days:";
			// 
			// mDays
			// 
			this.mDays.Location = new System.Drawing.Point(101, 45);
			this.mDays.Name = "mDays";
			this.mDays.Size = new System.Drawing.Size(205, 25);
			this.mDays.TabIndex = 7;
			this.mDays.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.BackColor = System.Drawing.Color.Transparent;
			this.label4.Location = new System.Drawing.Point(56, 84);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(39, 17);
			this.label4.TabIndex = 6;
			this.label4.Text = "Time:";
			// 
			// mTime
			// 
			this.mTime.Location = new System.Drawing.Point(101, 76);
			this.mTime.Mask = "00:00:00";
			this.mTime.Name = "mTime";
			this.mTime.Size = new System.Drawing.Size(205, 25);
			this.mTime.TabIndex = 5;
			this.mTime.Text = "102030";
			this.mTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// button2
			// 
			this.button2.Color = System.Drawing.Color.LightSteelBlue;
			this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.button2.Focusable = true;
			this.button2.ImageSize = new System.Drawing.SizeF(24F, 24F);
			this.button2.Location = new System.Drawing.Point(236, 125);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 23);
			this.button2.TabIndex = 4;
			this.button2.Text = "Cancel";
			this.button2.UseVisualStyleBackColor = true;
			// 
			// button1
			// 
			this.button1.Color = System.Drawing.Color.LightSteelBlue;
			this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.button1.Focusable = true;
			this.button1.ImageSize = new System.Drawing.SizeF(24F, 24F);
			this.button1.Location = new System.Drawing.Point(155, 125);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 3;
			this.button1.Text = "Ok";
			this.button1.UseVisualStyleBackColor = true;
			// 
			// formTime
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BorderSize = 2;
			this.ClientSize = new System.Drawing.Size(391, 227);
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
			this.Name = "formTime";
			this.Resizable = false;
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Statistics";
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.mDays)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private button button1;
		private button button2;
		private System.Windows.Forms.Label label4;
		public System.Windows.Forms.MaskedTextBox mTime;
		private System.Windows.Forms.Label label1;
		public System.Windows.Forms.NumericUpDown mDays;
	}
}