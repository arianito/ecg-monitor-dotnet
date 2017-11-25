using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Drawing.Drawing2D;


namespace ecgmonitor
{

	/// <summary>
	/// Amazing button created by aryan alikhani, alikhaniaryan@gmail.com
	/// GNU public liscense
	/// </summary>
	public class button : Button
	{
		Color bBorderColor = Color.FromArgb(224, 224, 224);
		Color bColor = System.Drawing.Color.LightSteelBlue;
		Color toSatColor = Color.White;

		int entered;
		Color clrLight;
		Color clrDark;

		bool focusable = true;

		[Category("Skin")]
		public Color Color
		{
			get { return bColor; }
			set
			{
				bColor = value;

				clrLight = ControlPaint.Light(bColor);
				clrDark = ControlPaint.Dark(bColor);
				this.Refresh();
			}
		}


		[Category("Behavior")]
		public bool Focusable
		{
			get { return focusable; }
			set { focusable = value; this.Refresh(); }
		}

		private enum modes
		{
			focusIn = (1 << 0),
			focusOut = (1 << 1),
			mouseIn = (1 << 2),
			mouseOut = (1 << 3),
			downIn = (1 << 4),
			downOut = (1 << 5),
			sleep = (1 << 7),
		}

		private SizeF ims = new SizeF(24.0f, 24.0f);
		private float deltaStart = 0.2f;
		private float deltaEnd = 0.1f;

		private modes mode = modes.sleep;
		private Thread upd;
		private StringFormat format = StringFormat.GenericDefault;

		private float opacity = 0.0f, ohit = 0.0f, ofocus = 0.0f, ofocus1 = 1.0f;

		public button()
		{
			base.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);
			this.format = SetAlign(TextAlign, this.RightToLeft);

			clrLight = ControlPaint.Light(bColor);
			clrDark = ControlPaint.Dark(bColor);


		}

		public Color lerp(Color from, Color to, float d)
		{
			return Color.FromArgb((int)((float)from.A + ((float)to.A - (float)from.A) * d),
				(int)((float)from.R + ((float)to.R - (float)from.R) * d),
				(int)((float)from.G + ((float)to.G - (float)from.G) * d),
				(int)((float)from.B + ((float)to.B - (float)from.B) * d));
		}
		public void DrawOwn(ref Graphics g, ref RectangleF bound)
		{

			g.Clear(this.BackColor);
			g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
			if (Enabled)
			{

				g.FillRectangle(new SolidBrush(BackColor), bound);
				if (ofocus >= 0.001f && focusable)
				{


					float hei = (1.0f - ofocus1) * this.Height;
					g.FillRectangle(new SolidBrush(Color.FromArgb(100, clrLight)), 0, this.Height - hei, this.Width, hei);

				}
				if (opacity >= 0.001f)
				{
					float wid = 0;
					if (entered > this.Width / 2)
						wid = opacity * entered * 2;
					else
						wid = opacity * (this.Width - entered) * 2;

					//g.FillRectangle(new SolidBrush(Color.FromArgb((byte)(opacity * 100.0f), bColor)), entered - wid / 2, 0, wid, this.Height);
					g.FillEllipse(new SolidBrush(Color.FromArgb((byte)(opacity * 100.0f), bColor)), entered - wid / 2, this.Height / 2 - wid / 2, wid, wid);

				}
				if (ohit >= 0.001f)
				{
					g.FillRectangle(new SolidBrush(Color.FromArgb((int)(ohit * 255.0f), clrDark)), bound);
				}

				Color txtc = lerp(this.ForeColor, toSatColor, ohit);
				SizeF strSize = g.MeasureString(this.Text, this.Font);
				if (this.Image != null)
				{
					g.SmoothingMode = SmoothingMode.AntiAlias;
					RectangleF bnd;
					switch (TextImageRelation)
					{
						case TextImageRelation.TextBeforeImage:
							bnd = new RectangleF(0, 0, this.Width / 2f - (strSize.Width + ImageSize.Width) / 2f + strSize.Width, this.Height);
							g.DrawImage(this.Image, getImagePos(TextAlign, bnd, TextImageRelation));
							painti.DrawString(g, this.Text, this.Font, txtc, bnd, format); break;
						case TextImageRelation.ImageBeforeText:
							bnd = new RectangleF(this.Width / 2f - (strSize.Width + ImageSize.Width) / 2f + ImageSize.Width, 0, this.Width - (this.Width / 2f - (strSize.Width + ImageSize.Width) / 2f + ImageSize.Width), this.Height);
							g.DrawImage(this.Image, getImagePos(TextAlign, bnd, TextImageRelation));
							painti.DrawString(g, this.Text, this.Font, txtc, bnd, format); break;
						case TextImageRelation.ImageAboveText:
							bnd = new RectangleF(0, this.Height / 2f - (ImageSize.Height + strSize.Height) / 2f + ImageSize.Height, this.Width, this.Height - (this.Height / 2f - (ImageSize.Height + strSize.Height) / 2f + ImageSize.Height));
							g.DrawImage(this.Image, getImagePos(TextAlign, bnd, TextImageRelation));
							painti.DrawString(g, this.Text, this.Font, txtc, bnd, format);
							break;
						case TextImageRelation.TextAboveImage:
							bnd = new RectangleF(0, 0, this.Width, this.Height / 2f - (ImageSize.Height + strSize.Height) / 2f + strSize.Height);
							g.DrawImage(this.Image, getImagePos(TextAlign, bnd, TextImageRelation));
							painti.DrawString(g, this.Text, this.Font, txtc, bnd, format);
							break;
						case TextImageRelation.Overlay:
							g.DrawImage(this.Image, getImagePos(TextAlign, bound, TextImageRelation));
							painti.DrawString(g, this.Text, this.Font, txtc, bound, format);
							break;
					}
					g.SmoothingMode = SmoothingMode.Default;
				}
				else
				{
					painti.DrawString(g, this.Text, this.Font, txtc, bound, format);
				}
			}
			else
			{
				//aPaint.DrawButtonHighlight(g, a.baseColor, a.secColor, bound, aPaint.RenderMode.HighSpeed, 1.0f);
				SizeF strSize = g.MeasureString(this.Text, this.Font);
				if (this.Image != null)
				{
					g.SmoothingMode = SmoothingMode.AntiAlias;
					RectangleF bnd;
					switch (TextImageRelation)
					{
						case TextImageRelation.TextBeforeImage:
							bnd = new RectangleF(0, 0, this.Width / 2f - (strSize.Width + ImageSize.Width) / 2f + strSize.Width, this.Height);
							g.DrawImage(this.Image, getImagePos(TextAlign, bnd, TextImageRelation));
							painti.DrawStringDisabled(g, this.Text, this.Font, this.ForeColor, bnd, format); break;
						case TextImageRelation.ImageBeforeText:
							bnd = new RectangleF(this.Width / 2f - (strSize.Width + ImageSize.Width) / 2f + ImageSize.Width, 0, this.Width - (this.Width / 2f - (strSize.Width + ImageSize.Width) / 2f + ImageSize.Width), this.Height);
							g.DrawImage(this.Image, getImagePos(TextAlign, bnd, TextImageRelation));
							painti.DrawStringDisabled(g, this.Text, this.Font, this.ForeColor, bnd, format); break;
						case TextImageRelation.ImageAboveText:
							bnd = new RectangleF(0, this.Height / 2f - (ImageSize.Height + strSize.Height) / 2f + ImageSize.Height, this.Width, this.Height - (this.Height / 2f - (ImageSize.Height + strSize.Height) / 2f + ImageSize.Height));
							g.DrawImage(this.Image, getImagePos(TextAlign, bnd, TextImageRelation));
							painti.DrawStringDisabled(g, this.Text, this.Font, this.ForeColor, bnd, format);
							break;
						case TextImageRelation.TextAboveImage:
							bnd = new RectangleF(0, 0, this.Width, this.Height / 2f - (ImageSize.Height + strSize.Height) / 2f + strSize.Height);
							g.DrawImage(this.Image, getImagePos(TextAlign, bnd, TextImageRelation));
							painti.DrawStringDisabled(g, this.Text, this.Font, this.ForeColor, bnd, format);
							break;
						case TextImageRelation.Overlay:
							g.DrawImage(this.Image, getImagePos(TextAlign, bound, TextImageRelation));
							painti.DrawStringDisabled(g, this.Text, this.Font, this.ForeColor, bound, format);
							break;
					}
					g.SmoothingMode = SmoothingMode.Default;
				}
				else
				{
					painti.DrawStringDisabled(g, this.Text, this.Font, this.ForeColor, bound, format);
				}
			}
		}
		private RectangleF getImagePos(ContentAlignment a, RectangleF b, TextImageRelation ti)
		{
			RectangleF bnd = new RectangleF();
			switch (ti)
			{
				case TextImageRelation.TextBeforeImage:
					bnd = new RectangleF(b.Width, b.Y, this.Width - b.Width, b.Height);
					break;
				case TextImageRelation.ImageBeforeText:
					bnd = new RectangleF(0, b.Y, b.X, b.Height);
					break;
				case TextImageRelation.ImageAboveText:
					bnd = new RectangleF(b.X, 0, b.Width, b.Y);
					break;
				case TextImageRelation.TextAboveImage:
					bnd = new RectangleF(b.X, b.Height, b.Width, this.Height - b.Height);
					break;
				default:
					bnd = b;
					break;
			}
			switch (a)
			{
				case ContentAlignment.BottomCenter:
					return new RectangleF(bnd.X + bnd.Width / 2f - ImageSize.Width / 2f, bnd.Y + bnd.Height - ImageSize.Height, ImageSize.Width, ImageSize.Height);
				case ContentAlignment.BottomLeft:
					return new RectangleF(bnd.X, bnd.Y + bnd.Height - ImageSize.Height, ImageSize.Width, ImageSize.Height);
				case ContentAlignment.BottomRight:
					return new RectangleF(bnd.X + bnd.Width - ImageSize.Width, bnd.Y + bnd.Height - ImageSize.Height, ImageSize.Width, ImageSize.Height);
				case ContentAlignment.MiddleCenter:
					return new RectangleF(bnd.X + bnd.Width / 2f - ImageSize.Width / 2f, bnd.Y + bnd.Height / 2f - ImageSize.Height / 2f, ImageSize.Width, ImageSize.Height);
				case ContentAlignment.MiddleLeft:
					return new RectangleF(bnd.X + (bnd.Y + bnd.Height / 2f - ImageSize.Height / 2f), bnd.Y + bnd.Height / 2f - ImageSize.Height / 2f, ImageSize.Width, ImageSize.Height);
				case ContentAlignment.MiddleRight:
					return new RectangleF(bnd.X + bnd.Width - ImageSize.Width - (bnd.Y + bnd.Height / 2f - ImageSize.Height / 2f), bnd.Y + bnd.Height / 2f - ImageSize.Height / 2f, ImageSize.Width, ImageSize.Height);
				case ContentAlignment.TopCenter:
					return new RectangleF(bnd.X + bnd.Width / 2f - ImageSize.Width / 2, bnd.Y, ImageSize.Width, ImageSize.Height);
				case ContentAlignment.TopLeft:
					return new RectangleF(bnd.X, bnd.Y, ImageSize.Width, ImageSize.Height);
				default:
					return new RectangleF(bnd.X + bnd.Width - ImageSize.Width, bnd.Y, ImageSize.Width, ImageSize.Height);
			}
		}
		public static StringFormat SetAlign(ContentAlignment value, RightToLeft rtl)
		{
			StringFormat sf = new StringFormat();
			sf.Trimming = StringTrimming.EllipsisWord;

			if (rtl == RightToLeft.Yes)
				sf.FormatFlags = StringFormatFlags.DirectionRightToLeft;
			switch (value)
			{
				case ContentAlignment.TopLeft:
					sf.LineAlignment = StringAlignment.Near;
					sf.Alignment = StringAlignment.Near;
					return sf;
				case ContentAlignment.TopCenter:
					sf.LineAlignment = StringAlignment.Near;
					sf.Alignment = StringAlignment.Center;
					return sf;
				case ContentAlignment.TopRight:
					sf.LineAlignment = StringAlignment.Near;
					sf.Alignment = StringAlignment.Far;
					return sf;
				case ContentAlignment.MiddleLeft:
					sf.LineAlignment = StringAlignment.Center;
					sf.Alignment = StringAlignment.Near;
					return sf;
				case ContentAlignment.MiddleCenter:
					sf.LineAlignment = StringAlignment.Center;
					sf.Alignment = StringAlignment.Center;
					return sf;
				case ContentAlignment.MiddleRight:
					sf.LineAlignment = StringAlignment.Center;
					sf.Alignment = StringAlignment.Far;
					return sf;
				case ContentAlignment.BottomLeft:
					sf.LineAlignment = StringAlignment.Far;
					sf.Alignment = StringAlignment.Near;
					return sf;
				case ContentAlignment.BottomCenter:
					sf.LineAlignment = StringAlignment.Far;
					sf.Alignment = StringAlignment.Center;
					return sf;
				case ContentAlignment.BottomRight:
					sf.LineAlignment = StringAlignment.Far;
					sf.Alignment = StringAlignment.Far;
					return sf;
			}
			return sf;
		}
		private void update()
		{
			while (this.Created)
			{
				bool ot;
				if ((mode & modes.mouseIn) == modes.mouseIn)
				{
					opacity = lerp(opacity, 1.0f, deltaStart, out ot);
					if (ot)
					{
						mode &= ~modes.mouseIn;
					}
				}
				else if ((mode & modes.mouseOut) == modes.mouseOut)
				{
					opacity = lerp(opacity, 0.0f, deltaEnd, out ot);
					if (ot)
					{
						mode &= ~modes.mouseOut;
					}
				}
				if ((mode & modes.focusIn) == modes.focusIn)
				{
					bool ot1;
					ofocus = lerp(ofocus, 1.0f, deltaStart, out ot);
					ofocus1 = lerp(ofocus1, 0.0f, deltaEnd, out ot1);
					if (ot && ot1)
					{
						mode &= ~modes.focusIn;
					}
				}
				else if ((mode & modes.focusOut) == modes.focusOut)
				{
					bool ot1;
					ofocus = lerp(ofocus, 0.0f, deltaEnd, out ot);
					ofocus1 = lerp(ofocus1, 1.0f, deltaStart, out ot1);
					if (ot && ot1)
					{
						mode &= ~modes.focusOut;
					}
				}
				if ((mode & modes.downIn) == modes.downIn)
				{
					ohit = lerp(ohit, 1.0f, deltaStart, out ot);
					if (ot)
					{
						mode &= ~modes.downIn;
					}
				}
				else if ((mode & modes.downOut) == modes.downOut)
				{
					ohit = lerp(ohit, 0.0f, deltaEnd, out ot);
					if (ot)
					{
						mode &= ~modes.downOut;
					}
				}

				if (DesignMode)
					stop();
				sleep();
				this.Invalidate();
				Thread.Sleep(TimeSpan.FromSeconds(1.0 / 60.0));
			}
		}
		private void sleep()
		{
			mode |= modes.sleep;
			bool downIn = (mode & modes.downIn) == modes.downIn;
			bool downOut = (mode & modes.downOut) == modes.downOut;
			bool focusIn = (mode & modes.focusIn) == modes.focusIn;
			bool focusOut = (mode & modes.focusOut) == modes.focusOut;
			bool mouseIn = (mode & modes.mouseIn) == modes.mouseIn;
			bool mouseOut = (mode & modes.mouseOut) == modes.mouseOut;

			if (!downIn && !focusIn && !mouseIn && !downOut && !focusOut && !mouseOut)
			{
				stop();
			}
		}
		private void wakeup()
		{
			bool sleep = (mode & modes.sleep) == modes.sleep;
			if (sleep)
			{
				restart();
				mode &= ~modes.sleep;
			}
		}
		private void stop()
		{
			if (upd != null)
			{
				upd.Abort();
			}
			upd = null;
		}
		private void restart()
		{
			if (upd != null)
			{
				upd.Abort();
			}
			upd = null;
			upd = new Thread(new ThreadStart(update));
			upd.Start();
		}
		private float lerp(float value1, float value2, float delta, out bool end)
		{
			if (Math.Abs(value2 - value1) <= 0.001)
			{
				end = true;
				return value2;
			}
			end = false;
			return value1 + (value2 - value1) * delta;
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			RectangleF bnd = new RectangleF(0, 0, this.Width, this.Height);
			Graphics g = e.Graphics;
			DrawOwn(ref g, ref bnd);
		}
		protected override void OnCreateControl()
		{
			base.OnCreateControl();
			if (!DesignMode)
			{
				restart();
				sleep();
			}
		}
		protected override void OnEnabledChanged(EventArgs e)
		{
			base.OnEnabledChanged(e);
			if (this.Enabled)
			{
				wakeup();
			}
			else
			{
				sleep();
			}
		}
		protected override void OnMouseEnter(EventArgs e)
		{
			base.OnMouseEnter(e);
			mode |= modes.mouseIn;
			mode &= ~modes.mouseOut;
			wakeup();
		}
		protected override void OnMouseLeave(EventArgs e)
		{
			base.OnMouseLeave(e);
			mode |= modes.mouseOut;
			mode &= ~modes.mouseIn;
			wakeup();
		}
		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);
			mode |= modes.downIn;
			mode &= ~modes.downOut;
			wakeup();
		}
		protected override void OnMouseMove(MouseEventArgs mevent)
		{
			base.OnMouseMove(mevent);
			entered = mevent.X;
		}
		protected override void OnMouseUp(MouseEventArgs e)
		{
			base.OnMouseUp(e);
			mode |= modes.downOut;
			mode &= ~modes.downIn;
			wakeup();
		}
		protected override void OnKeyDown(KeyEventArgs e)
		{
			base.OnKeyDown(e);
			if (e.KeyCode == Keys.Space || e.KeyCode == Keys.Enter)
			{
				mode |= modes.downIn;
				mode &= ~modes.downOut;
				wakeup();
			}
		}
		protected override void OnKeyUp(KeyEventArgs e)
		{
			base.OnKeyUp(e);
			mode |= modes.downOut;
			mode &= ~modes.downIn;
			wakeup();
		}
		protected override void OnGotFocus(EventArgs e)
		{
			base.OnGotFocus(e);
			mode |= modes.focusIn;
			mode &= ~modes.focusOut;
			wakeup();
		}
		protected override void OnLostFocus(EventArgs e)
		{
			base.OnLostFocus(e);
			mode |= modes.focusOut;
			mode &= ~modes.focusIn;
			wakeup();
		}

		[Category("Appearance")]
		public override ContentAlignment TextAlign
		{
			get
			{
				return base.TextAlign;
			}
			set
			{
				base.TextAlign = value;
				this.format = SetAlign(TextAlign, this.RightToLeft);
				this.Invalidate();
			}
		}
		[Category("Appearance")]
		public SizeF ImageSize
		{
			get { return this.ims; }
			set { this.ims = value; }
		}
	}
}