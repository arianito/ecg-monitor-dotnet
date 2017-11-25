using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
namespace ecgmonitor
{
	public class ribonItem
	{
		public string name;
		public Bitmap image;
		public Rectangle bound;
		public bool left;
		public int index;
		public int state;
		public Action action;

	}
	/// <summary>
	/// Amazing ribon created by aryan alikhani, alikhaniaryan@gmail.com
	/// GNU public liscense
	/// </summary>
	public class ribon : UserControl
	{
		int pad = 20;
		public List<ribonItem> ribons = new List<ribonItem>();

		int left = 0;
		int right = 0;


		int selL = -1;
		int selR = -1;
		public ribon()
		{

			base.SetStyle(ControlStyles.StandardClick, true);
			this.DoubleBuffered = true;
			this.ResizeRedraw = true;
			this.Padding = new Padding(0);
			this.Margin = new Padding(0);
		}

		public void add(string name, Bitmap image, bool lft, Action acc)
		{
			ribonItem rb = new ribonItem();
			rb.name = name;
			rb.image = image;
			rb.index = lft ? left : right;
			rb.left = lft;
			rb.state = -1;
			if (lft) left++;
			else right++;
			rb.action = acc;
			this.ribons.Add(rb);


		}
		public static Rectangle getCentered(ref Rectangle bound, int width, int height)
		{
			return new Rectangle(bound.X + bound.Width / 2 - width / 2, bound.Y + bound.Height / 2 - height / 2, width, height);
		}
		protected override void OnMouseMove(MouseEventArgs e)
		{
			for (int i = 0; i < ribons.Count; i++)
			{
				ribonItem rb = ribons[i];

				if (rb.bound.Contains(e.Location))
				{
					rb.state = 0;
					if (rb.left)
					{
						selR = -1;
						selL = i;
					}
					else
					{
						selR = i;
						selL = -1;
					}
					this.Invalidate();
				}
				else
				{
					rb.state = -1;
					this.Invalidate();
				}
			}

		}
		protected override void OnMouseDown(MouseEventArgs e)
		{
			for (int i = 0; i < ribons.Count; i++)
			{
				ribonItem rb = ribons[i];

				if (rb.bound.Contains(e.Location))
				{
					rb.state = 1;
				}
			}
			this.Invalidate();

		}
		protected override void OnMouseClick(MouseEventArgs e)
		{
			//base.OnMouseClick(e); 

			for (int i = 0; i < ribons.Count; i++)
			{
				ribonItem rb = ribons[i];

				if (rb.bound.Contains(e.Location))
				{
					if (rb.action != null)
						rb.action();
				}
			}
		}
		protected override void OnMouseLeave(EventArgs e)
		{
			selR = -1;
			selL = -1;
			for (int i = 0; i < ribons.Count; i++)
			{
				ribonItem rb = ribons[i];

				rb.state = -1;
			}
			this.Invalidate();
			base.OnMouseLeave(e);



		}
		protected override void OnPaint(PaintEventArgs e)
		{
			//base.OnPaint(e);


			e.Graphics.FillRectangle(new SolidBrush(this.BackColor), 0, 0, this.Width, this.Height);

			Color clr = ControlPaint.Light(this.BackColor);
			Color clr2 = ControlPaint.Dark(this.BackColor);
			int bBorderSize = 4;
			ControlPaint.DrawBorder(e.Graphics, ClientRectangle,
					clr, bBorderSize, ButtonBorderStyle.None,
					clr, bBorderSize, ButtonBorderStyle.None,
					clr, bBorderSize, ButtonBorderStyle.None,
					clr, bBorderSize, ButtonBorderStyle.Dashed);

			int lx = 0;
			int rx = this.Width;
			int sep = -3;
			for (int i = 0; i < ribons.Count; i++)
			{
				ribonItem rb = ribons[i];

				if (rb.left)
				{
					rb.bound.X = pad + (this.Height + sep) * rb.index;

					if (rb.bound.X > lx)
						lx = rb.bound.X;
				}
				else
				{
					rb.bound.X = this.Width - pad - (this.Height + sep) * (rb.index + 1);
					if (rb.bound.X < rx)
						rx = rb.bound.X;
				}


				rb.bound.Y = 0;
				rb.bound.Width = this.Height - 3;
				rb.bound.Height = this.Height - 3;


				if (rb.state >= 0)
				{
					e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb((rb.state == 1) ? 120 : 60, clr2)), rb.bound);
				}



				e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
				rb.bound.Inflate(-4, -4);
				e.Graphics.DrawImage(rb.image, rb.bound);
				e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;

				if (rb.state == -1)
				{
					e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(60, this.BackColor)), rb.bound);
				}


			}

			Font f = new Font(this.Font, FontStyle.Bold);
			int x = pad / 2 + lx + this.Height;
			int w = rx - x - pad / 2;
			RectangleF bound = new RectangleF(x, 0, w, this.Height - 3);

			e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

			StringFormat sf = new StringFormat();
			sf.Alignment = StringAlignment.Near;
			sf.LineAlignment = StringAlignment.Center;
			sf.Trimming = StringTrimming.EllipsisWord;
			sf.FormatFlags = StringFormatFlags.LineLimit;

			if (selL > -1)
			{

				e.Graphics.DrawString(ribons[selL].name, f, new SolidBrush(this.ForeColor), bound, sf);
			}
			else if (selR > -1)
			{

				sf.Alignment = StringAlignment.Far;
				e.Graphics.DrawString(ribons[selR].name, f, new SolidBrush(this.ForeColor), bound, sf);
			}


		}


	}
}