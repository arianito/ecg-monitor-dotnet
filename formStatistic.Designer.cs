namespace ecgmonitor
{
	partial class formStatistic
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formStatistic));
			this.panel1 = new System.Windows.Forms.Panel();
			this.label4 = new System.Windows.Forms.Label();
			this.mTime = new System.Windows.Forms.MaskedTextBox();
			this.button2 = new ecgmonitor.button();
			this.button1 = new ecgmonitor.button();
			this.mId = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.mAge = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.mName = new System.Windows.Forms.TextBox();
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
			this.panel1.Controls.Add(this.label4);
			this.panel1.Controls.Add(this.mTime);
			this.panel1.Controls.Add(this.button2);
			this.panel1.Controls.Add(this.button1);
			this.panel1.Controls.Add(this.mId);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.mAge);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.mName);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Location = new System.Drawing.Point(4, 34);
			this.panel1.Name = "panel1";
			this.panel1.Padding = new System.Windows.Forms.Padding(3);
			this.panel1.Size = new System.Drawing.Size(383, 206);
			this.panel1.TabIndex = 0;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.BackColor = System.Drawing.Color.Transparent;
			this.label4.Location = new System.Drawing.Point(23, 120);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(70, 17);
			this.label4.TabIndex = 6;
			this.label4.Text = "Start Time:";
			// 
			// mTime
			// 
			this.mTime.Location = new System.Drawing.Point(99, 117);
			this.mTime.Mask = "00:00:00";
			this.mTime.Name = "mTime";
			this.mTime.Size = new System.Drawing.Size(205, 25);
			this.mTime.TabIndex = 5;
			this.mTime.Text = "000000";
			this.mTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// button2
			// 
			this.button2.Color = System.Drawing.Color.LightSteelBlue;
			this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.button2.Focusable = true;
			this.button2.ImageSize = new System.Drawing.SizeF(24F, 24F);
			this.button2.Location = new System.Drawing.Point(262, 164);
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
			this.button1.Location = new System.Drawing.Point(181, 164);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 3;
			this.button1.Text = "Ok";
			this.button1.UseVisualStyleBackColor = true;
			// 
			// mId
			// 
			this.mId.Location = new System.Drawing.Point(99, 24);
			this.mId.Name = "mId";
			this.mId.Size = new System.Drawing.Size(205, 25);
			this.mId.TabIndex = 0;
			this.mId.Text = "0";
			this.mId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.BackColor = System.Drawing.Color.Transparent;
			this.label3.Location = new System.Drawing.Point(67, 27);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(22, 17);
			this.label3.TabIndex = 4;
			this.label3.Text = "Id:";
			// 
			// mAge
			// 
			this.mAge.Location = new System.Drawing.Point(99, 86);
			this.mAge.Name = "mAge";
			this.mAge.Size = new System.Drawing.Size(205, 25);
			this.mAge.TabIndex = 2;
			this.mAge.Text = "0";
			this.mAge.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.BackColor = System.Drawing.Color.Transparent;
			this.label2.Location = new System.Drawing.Point(55, 89);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(38, 17);
			this.label2.TabIndex = 2;
			this.label2.Text = "Age: ";
			// 
			// mName
			// 
			this.mName.Location = new System.Drawing.Point(99, 55);
			this.mName.Name = "mName";
			this.mName.Size = new System.Drawing.Size(205, 25);
			this.mName.TabIndex = 1;
			this.mName.Text = "Patient1";
			this.mName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.Location = new System.Drawing.Point(43, 58);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(50, 17);
			this.label1.TabIndex = 0;
			this.label1.Text = "Name: ";
			// 
			// formStatistic
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BorderSize = 2;
			this.ClientSize = new System.Drawing.Size(391, 244);
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
			this.Name = "formStatistic";
			this.Resizable = false;
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Statistics";
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		public System.Windows.Forms.TextBox mAge;
		private System.Windows.Forms.Label label2;
		public System.Windows.Forms.TextBox mName;
		private System.Windows.Forms.Label label1;
		private button button1;
		public System.Windows.Forms.TextBox mId;
		private System.Windows.Forms.Label label3;
		private button button2;
		private System.Windows.Forms.Label label4;
		public System.Windows.Forms.MaskedTextBox mTime;
	}
}