namespace ecgmonitor
{
	partial class formSettings
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formSettings));
			this.panel1 = new System.Windows.Forms.Panel();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.label1 = new System.Windows.Forms.Label();
			this.perPage = new System.Windows.Forms.NumericUpDown();
			this.detectNone = new System.Windows.Forms.RadioButton();
			this.detectST = new System.Windows.Forms.CheckBox();
			this.detectQT = new System.Windows.Forms.RadioButton();
			this.detectPQ = new System.Windows.Forms.RadioButton();
			this.detectQRS = new System.Windows.Forms.RadioButton();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.noiseNotch = new System.Windows.Forms.CheckBox();
			this.noise60hz = new System.Windows.Forms.RadioButton();
			this.noise45hz = new System.Windows.Forms.CheckBox();
			this.noise50hz = new System.Windows.Forms.RadioButton();
			this.noise20hz = new System.Windows.Forms.CheckBox();
			this.noise12hz = new System.Windows.Forms.CheckBox();
			this.panel1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.perPage)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.panel1.BackgroundImage = global::ecgmonitor.box.backg;
			this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.panel1.Controls.Add(this.groupBox2);
			this.panel1.Controls.Add(this.groupBox1);
			this.panel1.Location = new System.Drawing.Point(4, 34);
			this.panel1.Name = "panel1";
			this.panel1.Padding = new System.Windows.Forms.Padding(3);
			this.panel1.Size = new System.Drawing.Size(553, 234);
			this.panel1.TabIndex = 0;
			// 
			// groupBox2
			// 
			this.groupBox2.BackColor = System.Drawing.Color.Transparent;
			this.groupBox2.Controls.Add(this.label1);
			this.groupBox2.Controls.Add(this.perPage);
			this.groupBox2.Controls.Add(this.detectNone);
			this.groupBox2.Controls.Add(this.detectST);
			this.groupBox2.Controls.Add(this.detectQT);
			this.groupBox2.Controls.Add(this.detectPQ);
			this.groupBox2.Controls.Add(this.detectQRS);
			this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.groupBox2.ForeColor = System.Drawing.Color.GhostWhite;
			this.groupBox2.Location = new System.Drawing.Point(195, 6);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Padding = new System.Windows.Forms.Padding(10);
			this.groupBox2.Size = new System.Drawing.Size(349, 222);
			this.groupBox2.TabIndex = 5;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "View";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(143, 28);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(146, 17);
			this.label1.TabIndex = 7;
			this.label1.Text = "Maximum Per Page : (s)";
			// 
			// perPage
			// 
			this.perPage.DecimalPlaces = 2;
			this.perPage.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.perPage.Location = new System.Drawing.Point(142, 50);
			this.perPage.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
			this.perPage.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.perPage.Name = "perPage";
			this.perPage.Size = new System.Drawing.Size(154, 25);
			this.perPage.TabIndex = 6;
			this.perPage.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.perPage.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
			// 
			// detectNone
			// 
			this.detectNone.AutoSize = true;
			this.detectNone.Location = new System.Drawing.Point(13, 30);
			this.detectNone.Name = "detectNone";
			this.detectNone.Size = new System.Drawing.Size(58, 21);
			this.detectNone.TabIndex = 6;
			this.detectNone.Text = "None";
			this.detectNone.UseVisualStyleBackColor = true;
			// 
			// detectST
			// 
			this.detectST.AutoSize = true;
			this.detectST.Location = new System.Drawing.Point(13, 139);
			this.detectST.Name = "detectST";
			this.detectST.Size = new System.Drawing.Size(68, 21);
			this.detectST.TabIndex = 5;
			this.detectST.Text = "ST Line";
			this.detectST.UseVisualStyleBackColor = true;
			// 
			// detectQT
			// 
			this.detectQT.AutoSize = true;
			this.detectQT.Location = new System.Drawing.Point(13, 111);
			this.detectQT.Name = "detectQT";
			this.detectQT.Size = new System.Drawing.Size(102, 21);
			this.detectQT.TabIndex = 2;
			this.detectQT.Text = "QT Detection";
			this.detectQT.UseVisualStyleBackColor = true;
			// 
			// detectPQ
			// 
			this.detectPQ.AutoSize = true;
			this.detectPQ.Location = new System.Drawing.Point(13, 85);
			this.detectPQ.Name = "detectPQ";
			this.detectPQ.Size = new System.Drawing.Size(102, 21);
			this.detectPQ.TabIndex = 1;
			this.detectPQ.Text = "PQ Detection";
			this.detectPQ.UseVisualStyleBackColor = true;
			// 
			// detectQRS
			// 
			this.detectQRS.AutoSize = true;
			this.detectQRS.Checked = true;
			this.detectQRS.Location = new System.Drawing.Point(13, 58);
			this.detectQRS.Name = "detectQRS";
			this.detectQRS.Size = new System.Drawing.Size(110, 21);
			this.detectQRS.TabIndex = 0;
			this.detectQRS.TabStop = true;
			this.detectQRS.Text = "QRS Detection";
			this.detectQRS.UseVisualStyleBackColor = true;
			// 
			// groupBox1
			// 
			this.groupBox1.BackColor = System.Drawing.Color.Transparent;
			this.groupBox1.Controls.Add(this.noiseNotch);
			this.groupBox1.Controls.Add(this.noise60hz);
			this.groupBox1.Controls.Add(this.noise45hz);
			this.groupBox1.Controls.Add(this.noise50hz);
			this.groupBox1.Controls.Add(this.noise20hz);
			this.groupBox1.Controls.Add(this.noise12hz);
			this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.groupBox1.ForeColor = System.Drawing.Color.GhostWhite;
			this.groupBox1.Location = new System.Drawing.Point(6, 6);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Padding = new System.Windows.Forms.Padding(10);
			this.groupBox1.Size = new System.Drawing.Size(183, 222);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Filters";
			// 
			// noiseNotch
			// 
			this.noiseNotch.AutoSize = true;
			this.noiseNotch.Location = new System.Drawing.Point(13, 111);
			this.noiseNotch.Name = "noiseNotch";
			this.noiseNotch.Size = new System.Drawing.Size(94, 21);
			this.noiseNotch.TabIndex = 5;
			this.noiseNotch.Text = "Notch Filter";
			this.noiseNotch.UseVisualStyleBackColor = true;
			this.noiseNotch.CheckedChanged += new System.EventHandler(this.noise12hz_CheckedChanged);
			// 
			// noise60hz
			// 
			this.noise60hz.AutoSize = true;
			this.noise60hz.Location = new System.Drawing.Point(13, 165);
			this.noise60hz.Name = "noise60hz";
			this.noise60hz.Size = new System.Drawing.Size(87, 21);
			this.noise60hz.TabIndex = 4;
			this.noise60hz.TabStop = true;
			this.noise60hz.Text = "60Hz Filter";
			this.noise60hz.UseVisualStyleBackColor = true;
			// 
			// noise45hz
			// 
			this.noise45hz.AutoSize = true;
			this.noise45hz.Location = new System.Drawing.Point(13, 85);
			this.noise45hz.Name = "noise45hz";
			this.noise45hz.Size = new System.Drawing.Size(142, 21);
			this.noise45hz.TabIndex = 2;
			this.noise45hz.Text = "45Hz Lowpass Filter";
			this.noise45hz.UseVisualStyleBackColor = true;
			// 
			// noise50hz
			// 
			this.noise50hz.AutoSize = true;
			this.noise50hz.Location = new System.Drawing.Point(13, 138);
			this.noise50hz.Name = "noise50hz";
			this.noise50hz.Size = new System.Drawing.Size(87, 21);
			this.noise50hz.TabIndex = 3;
			this.noise50hz.TabStop = true;
			this.noise50hz.Text = "50Hz Filter";
			this.noise50hz.UseVisualStyleBackColor = true;
			// 
			// noise20hz
			// 
			this.noise20hz.AutoSize = true;
			this.noise20hz.Location = new System.Drawing.Point(13, 58);
			this.noise20hz.Name = "noise20hz";
			this.noise20hz.Size = new System.Drawing.Size(142, 21);
			this.noise20hz.TabIndex = 1;
			this.noise20hz.Text = "20Hz Lowpass Filter";
			this.noise20hz.UseVisualStyleBackColor = true;
			// 
			// noise12hz
			// 
			this.noise12hz.AutoSize = true;
			this.noise12hz.Location = new System.Drawing.Point(13, 31);
			this.noise12hz.Name = "noise12hz";
			this.noise12hz.Size = new System.Drawing.Size(142, 21);
			this.noise12hz.TabIndex = 0;
			this.noise12hz.Text = "12Hz Lowpass Filter";
			this.noise12hz.UseVisualStyleBackColor = true;
			// 
			// formSettings
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BorderSize = 2;
			this.ClientSize = new System.Drawing.Size(561, 272);
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
			this.Name = "formSettings";
			this.Resizable = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Settings";
			this.panel1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.perPage)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.CheckBox noise20hz;
		private System.Windows.Forms.CheckBox noise12hz;
		private System.Windows.Forms.CheckBox noise45hz;
		private System.Windows.Forms.RadioButton noise60hz;
		private System.Windows.Forms.RadioButton noise50hz;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.RadioButton detectPQ;
		private System.Windows.Forms.RadioButton detectQRS;
		private System.Windows.Forms.RadioButton detectQT;
		private System.Windows.Forms.CheckBox detectST;
		private System.Windows.Forms.RadioButton detectNone;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.NumericUpDown perPage;
		private System.Windows.Forms.CheckBox noiseNotch;
	}
}