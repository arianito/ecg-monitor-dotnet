using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ecgmonitor
{
	/// <summary>
	/// Amazing painting library created by aryan alikhani, alikhaniaryan@gmail.com
	/// GNU public liscense
	/// </summary>
	static class painti
	{
		private const float ds = 0.39f;

		public static Image CreateDisabledImage(Image image)
		{
			return ToolStripRenderer.CreateDisabledImage(image);
		}

		public static void DrawButtonHighlight(Graphics g, Color baseColor, Color pushedBaseColor, RectangleF bounds, RenderMode renderMode, float opacity)
		{
			RectangleF ef = new RectangleF(bounds.X, bounds.Y + 1f, bounds.Width, bounds.Height - 2f);
			DrawHighlight(g, baseColor, pushedBaseColor, ef, renderMode, opacity);
			InternalDrawHighlightBorder(g, baseColor, bounds, (double)opacity);
		}

		public static void DrawHighlight(Graphics g, Color baseColor, Color pushedBaseColor, RectangleF bounds, RenderMode renderMode, float opacity)
		{
			g.SmoothingMode = (renderMode == RenderMode.HighQuality) ? SmoothingMode.HighQuality : SmoothingMode.HighSpeed;
			using (Brush brush = new SolidBrush(Color.FromArgb((int)(opacity * baseColor.A), baseColor)))
			{
				g.FillRectangle(brush, bounds);
			}
			HSBColor.HSB hsl = HSBColor.RGBToHSB(baseColor);
			hsl.H += 0.027450980392156862;
			hsl.B += hsl.B * 0.40000000596046448;
			Color color = HSBColor.HSBToRGB(hsl);
			RectangleF rect = new RectangleF(bounds.X, bounds.Y, bounds.Width, bounds.Height * 0.39f);
			RectangleF ef2 = new RectangleF(bounds.X, bounds.Y - 1f, bounds.Width, (bounds.Height * 0.39f) + 1f);
			using (LinearGradientBrush brush2 = new LinearGradientBrush(ef2, Color.FromArgb((int)(color.A * opacity), color), Color.FromArgb((int)(127f * opacity), color), LinearGradientMode.Vertical))
			{
				Blend blend = new Blend(3);
				blend.Positions[0] = 0f;
				blend.Positions[1] = 0.65f;
				blend.Positions[2] = 1f;
				blend.Factors[0] = 0f;
				blend.Factors[1] = 0.45f;
				blend.Factors[2] = 1f;
				brush2.Blend = blend;
				g.FillRectangle(brush2, rect);
			}
			hsl.H -= 0.047058823529411764;
			Color color2 = HSBColor.HSBToRGB(hsl);
			RectangleF ef3 = new RectangleF(bounds.X, rect.Bottom, bounds.Width, bounds.Height * 0.61f);
			RectangleF ef4 = new RectangleF(bounds.X, rect.Bottom - 1f, bounds.Width, (bounds.Height * 0.61f) + 2f);
			switch (renderMode)
			{
				case RenderMode.HighQuality:
					{
						using (GraphicsPath path = new GraphicsPath())
						{
							path.AddEllipse(ef4.X - 50f, ef4.Y, ef4.Width + 100f, ef4.Height * 2f);
							using (PathGradientBrush brush3 = new PathGradientBrush(path))
							{
								brush3.CenterColor = Color.FromArgb((int)(215f * opacity), color2);
								brush3.SurroundColors = new Color[] { Color.Transparent };
								g.FillRectangle(brush3, ef3);
							}
							return;
						}
					}
				case RenderMode.HighSpeed:
					using (LinearGradientBrush brush4 = new LinearGradientBrush(ef4, Color.Transparent, Color.FromArgb((int)(215f * opacity), color2), LinearGradientMode.Vertical))
					{
						Blend blend2 = new Blend(3);
						blend2.Positions[0] = 0f;
						blend2.Positions[1] = 0.65f;
						blend2.Positions[2] = 1f;
						blend2.Factors[0] = 0f;
						blend2.Factors[1] = 0.5f;
						blend2.Factors[2] = 1f;
						brush4.Blend = blend2;
						g.FillRectangle(brush4, ef3);
					}
					return;

				default:
					return;
			}
		}

		public static void DrawPushedButtonHighlight(Graphics g, Color baseColor, Color highlightBaseColor, RenderMode renderMode, RectangleF bounds, float opacity)
		{
			RectangleF ef = new RectangleF(bounds.X, bounds.Y + 1f, bounds.Width, bounds.Height - 2f);
			DrawPushedHighlight(g, baseColor, highlightBaseColor, ef, renderMode, opacity);
			InternalDrawPushBorder(g, baseColor, highlightBaseColor, bounds, (double)opacity);
		}

		public static void DrawPushedHighlight(Graphics g, Color baseColor, Color highlightBaseColor, RectangleF bounds, RenderMode renderMode, float opacity)
		{
			g.SmoothingMode = (renderMode == RenderMode.HighQuality) ? SmoothingMode.HighQuality : SmoothingMode.HighSpeed;
			HSBColor.HSB hsl = HSBColor.RGBToHSB(baseColor);
			hsl.B -= hsl.B * (0.1f * opacity);
			baseColor = HSBColor.HSBToRGB(hsl);
			using (Brush brush = new SolidBrush(baseColor))
			{
				g.FillRectangle(brush, bounds);
			}
			HSBColor.HSB hsb2 = HSBColor.RGBToHSB(baseColor);
			hsb2.H += 0.00784313725490196;
			hsb2.B += hsb2.B * 0.550000011920929;
			Color color = HSBColor.HSBToRGB(hsb2);
			RectangleF rect = new RectangleF(bounds.X, bounds.Y, bounds.Width, bounds.Height * 0.39f);
			RectangleF ef2 = new RectangleF(bounds.X, bounds.Y - 1f, bounds.Width, (bounds.Height * 0.39f) + 2f);
			using (LinearGradientBrush brush2 = new LinearGradientBrush(ef2, color, Color.FromArgb(80, color), LinearGradientMode.Vertical))
			{
				Blend blend = new Blend(3);
				blend.Positions[0] = 0f;
				blend.Positions[1] = 0.45f;
				blend.Positions[2] = 1f;
				blend.Factors[0] = 0f;
				blend.Factors[1] = 0.55f;
				blend.Factors[2] = 1f;
				brush2.Blend = blend;
				g.FillRectangle(brush2, rect);
			}
			HSBColor.HSB hsb3 = HSBColor.RGBToHSB(highlightBaseColor);
			hsb3.B += hsb3.B * 0.30000001192092896;
			hsb3.H += 0.027777777777777776;
			Color color2 = HSBColor.HSBToRGB(hsb3);
			RectangleF ef3 = new RectangleF(bounds.X, rect.Bottom, bounds.Width, bounds.Height * 0.61f);
			RectangleF ef4 = new RectangleF(bounds.X, rect.Bottom - 1f, bounds.Width, (bounds.Height * 0.61f) + 1f);
			switch (renderMode)
			{
				case RenderMode.HighQuality:
					{
						using (GraphicsPath path = new GraphicsPath())
						{
							path.AddEllipse(ef4.X - 50f, ef4.Y, ef4.Width + 100f, ef4.Height * 2f);
							using (PathGradientBrush brush3 = new PathGradientBrush(path))
							{
								ColorBlend blend2 = new ColorBlend(2);
								float[] numArray = new float[3];
								numArray[1] = 0.2f;
								numArray[2] = 1f;
								blend2.Positions = numArray;
								blend2.Colors = new Color[] { Color.Transparent, Color.FromArgb((int)(50f * (1f - opacity)), color2), Color.FromArgb(160 + ((int)(80f * (1f - opacity))), color2) };
								brush3.InterpolationColors = blend2;
								g.FillRectangle(brush3, ef3);
							}
							return;
						}
					}
				case RenderMode.HighSpeed:
					using (LinearGradientBrush brush4 = new LinearGradientBrush(ef4, Color.FromArgb((int)(30f * (1f - opacity)), color2), Color.FromArgb(160 + ((int)(80f * (1f - opacity))), color2), LinearGradientMode.Vertical))
					{
						Blend blend3 = new Blend(3);
						blend3.Positions[0] = 0f;
						blend3.Positions[1] = 0.5f;
						blend3.Positions[2] = 1f;
						blend3.Factors[0] = 0f;
						blend3.Factors[1] = 0.5f;
						blend3.Factors[2] = 1f;
						brush4.Blend = blend3;
						g.FillRectangle(brush4, ef3);
					}
					return;

				default:
					return;
			}
		}

		public static void DrawString(Graphics g, string text, Font font, Color foreColor, RectangleF rectangle, StringFormat sf)
		{
			using (SolidBrush brush = new SolidBrush(foreColor))
			{
				g.DrawString(text, font, brush, rectangle, sf);
			}
		}
		public static void DrawStringDisabled(Graphics g, string text, Font font, Color foreColor, RectangleF rectangle, StringFormat sf)
		{
			int red = 100 + ((int)(80f * foreColor.GetBrightness()));
			using (SolidBrush brush = new SolidBrush(Color.FromArgb(0x7f, red, red, red)))
			{
				g.DrawString(text, font, brush, rectangle, sf);
			}
		}

		internal static void InternalDrawHighlightBorder(Graphics g, Color baseColor, RectangleF bounds, double highlightOpacity)
		{
			HSBColor.HSB hsl = HSBColor.RGBToHSB(baseColor);
			hsl.B += hsl.B * 0.5;
			Color color = HSBColor.HSBToRGB(hsl);
			using (Pen pen = new Pen(Color.FromArgb((int)(150.0 * highlightOpacity), color), 1f))
			{
				g.DrawRectangle(pen, (float)(bounds.X + 1f), (float)(bounds.Y + 1f), (float)(bounds.Width - 3f), (float)(bounds.Height - 2f));
			}
			HSBColor.HSB hsb2 = HSBColor.RGBToHSB(baseColor);
			hsb2.S -= hsb2.S * 0.5;
			Color color2 = HSBColor.HSBToRGB(hsb2);
			using (Pen pen2 = new Pen(Color.FromArgb((int)(255.0 * highlightOpacity), color2), 1f))
			{
				g.DrawLine(pen2, bounds.X + 1f, bounds.Y, bounds.Right - 2f, bounds.Y);
				g.DrawLine(pen2, (float)(bounds.X + 1f), (float)(bounds.Bottom - 1f), (float)(bounds.Right - 2f), (float)(bounds.Bottom - 1f));
				g.DrawLine(pen2, bounds.X, bounds.Y + 1f, bounds.X, bounds.Bottom - 2f);
				g.DrawLine(pen2, (float)(bounds.Right - 1f), (float)(bounds.Y + 1f), (float)(bounds.Right - 1f), (float)(bounds.Bottom - 2f));
			}
		}

		internal static void InternalDrawPushBorder(Graphics g, Color baseColor, Color highlightBaseColor, RectangleF bounds, double highlightOpacity)
		{
			new RectangleF(bounds.X + 1f, bounds.Y, bounds.Width - 2f, 3f);
			using (LinearGradientBrush brush = new LinearGradientBrush(bounds, Color.FromArgb(200, 120, 120, 120), Color.FromArgb(200, 200, 200, 200), LinearGradientMode.Vertical))
			{
				using (Pen pen = new Pen(brush))
				{
					g.DrawLine(pen, bounds.X, bounds.Y + 1f, bounds.X, bounds.Bottom - 3f);
					g.DrawLine(pen, (float)(bounds.Right - 1f), (float)(bounds.Y + 1f), (float)(bounds.Right - 1f), (float)(bounds.Bottom - 3f));
				}
			}
			using (Pen pen2 = new Pen(Color.FromArgb(150, highlightBaseColor), 2f))
			{
				g.DrawLine(pen2, (float)(bounds.X + 2f), (float)(bounds.Y + 1f), (float)(bounds.X + 2f), (float)(bounds.Bottom - 1f));
				g.DrawLine(pen2, (float)(bounds.Right - 2f), (float)(bounds.Y + 1f), (float)(bounds.Right - 2f), (float)(bounds.Bottom - 1f));
				g.DrawLine(pen2, (float)(bounds.X + 1f), (float)(bounds.Bottom - 1f), (float)(bounds.Right - 1f), (float)(bounds.Bottom - 1f));
			}
			Color color = Color.FromArgb(130, 130, 130);
			using (Pen pen3 = new Pen(baseColor))
			{
				g.DrawLine(pen3, bounds.X + 1f, bounds.Y, bounds.Right - 2f, bounds.Y);
			}
			using (Pen pen4 = new Pen(Color.FromArgb(170, color)))
			{
				g.DrawLine(pen4, bounds.X + 1f, bounds.Y, bounds.Right - 2f, bounds.Y);
			}
			using (Pen pen5 = new Pen(Color.FromArgb(60, color)))
			{
				g.DrawLine(pen5, (float)(bounds.X + 1f), (float)(bounds.Y + 1f), (float)(bounds.Right - 2f), (float)(bounds.Y + 1f));
				g.DrawLine(pen5, (float)(bounds.X + 1f), (float)(bounds.Bottom - 1f), (float)(bounds.Right - 2f), (float)(bounds.Bottom - 1f));
			}
			using (Pen pen6 = new Pen(Color.FromArgb(30, color)))
			{
				g.DrawLine(pen6, (float)(bounds.X + 1f), (float)(bounds.Y + 2f), (float)(bounds.Right - 2f), (float)(bounds.Y + 2f));
			}
		}

		internal static Color InterpolateColors(Color color1, Color color2, float percentage)
		{
			byte red = Convert.ToByte((float)(color1.R + ((color2.R - color1.R) * percentage)));
			byte green = Convert.ToByte((float)(color1.G + ((color2.G - color1.G) * percentage)));
			byte blue = Convert.ToByte((float)(color1.B + ((color2.B - color1.B) * percentage)));
			return Color.FromArgb(Convert.ToByte((float)(color1.A + ((color2.A - color1.A) * percentage))), red, green, blue);
		}

		public static Rectangle OffsetRectangle(Rectangle rect, Point offset)
		{
			return new Rectangle(rect.X + offset.X, rect.Y + offset.Y, rect.Width, rect.Height);
		}

		public static Rectangle ResizeRectangle(Rectangle rect, int s)
		{
			return ResizeRectangle(rect, s, s);
		}

		public static Rectangle ResizeRectangle(Rectangle rect, int w, int h)
		{
			return new Rectangle(rect.X, rect.Y, rect.Width + w, rect.Height + h);
		}

		public enum RenderMode
		{
			HighQuality,
			HighSpeed
		}
	}
	internal class HSBColor
	{
		public static Color HSBToRGB(HSB hsl)
		{
			double num = 0.0;
			double num2 = 0.0;
			double num3 = 0.0;
			if (hsl.B == 0.0)
			{
				num = num2 = num3 = 0.0;
			}
			else if (hsl.S == 0.0)
			{
				num = num2 = num3 = hsl.B;
			}
			else
			{
				double num5 = (hsl.B <= 0.5) ? (hsl.B * (1.0 + hsl.S)) : ((hsl.B + hsl.S) - (hsl.B * hsl.S));
				double num4 = (2.0 * hsl.B) - num5;
				double[] numArray = new double[] { hsl.H + 0.33333333333333331, hsl.H, hsl.H - 0.33333333333333331 };
				double[] numArray2 = new double[3];
				for (int i = 0; i < 3; i++)
				{
					if (numArray[i] < 0.0)
					{
						numArray[i]++;
					}
					if (numArray[i] > 1.0)
					{
						numArray[i]--;
					}
					if ((6.0 * numArray[i]) < 1.0)
					{
						numArray2[i] = num4 + (((num5 - num4) * numArray[i]) * 6.0);
					}
					else if ((2.0 * numArray[i]) < 1.0)
					{
						numArray2[i] = num5;
					}
					else if ((3.0 * numArray[i]) < 2.0)
					{
						numArray2[i] = num4 + (((num5 - num4) * (0.66666666666666663 - numArray[i])) * 6.0);
					}
					else
					{
						numArray2[i] = num4;
					}
				}
				num = numArray2[0];
				num2 = numArray2[1];
				num3 = numArray2[2];
			}
			return Color.FromArgb((int)(255.0 * num), (int)(255.0 * num2), (int)(255.0 * num3));
		}

		public static Color ModifyBrightness(Color c, double brightness)
		{
			HSB hsl = RGBToHSB(c);
			hsl.B *= brightness;
			return HSBToRGB(hsl);
		}

		public static Color ModifyHue(Color c, double Hue)
		{
			HSB hsl = RGBToHSB(c);
			hsl.H *= Hue;
			return HSBToRGB(hsl);
		}

		public static Color ModifySaturation(Color c, double Saturation)
		{
			HSB hsl = RGBToHSB(c);
			hsl.S *= Saturation;
			return HSBToRGB(hsl);
		}

		public static HSB RGBToHSB(Color c)
		{
			return new HSB
			{
				H = ((double)c.GetHue()) / 360.0,
				B = (double)c.GetBrightness(),
				S = (double)c.GetSaturation()
			};
		}

		public static Color SetBrightness(Color c, double brightness)
		{
			HSB hsl = RGBToHSB(c);
			hsl.B = brightness;
			return HSBToRGB(hsl);
		}

		public static Color SetHue(Color c, double Hue)
		{
			HSB hsl = RGBToHSB(c);
			hsl.H = Hue;
			return HSBToRGB(hsl);
		}

		public static Color SetSaturation(Color c, double Saturation)
		{
			HSB hsl = RGBToHSB(c);
			hsl.S = Saturation;
			return HSBToRGB(hsl);
		}

		public class HSB
		{
			private double b = 0.0;
			private double h = 0.0;
			private double s = 0.0;

			internal HSB()
			{
			}

			public double B
			{
				get
				{
					return this.b;
				}
				set
				{
					this.b = value;
					this.b = (this.b > 1.0) ? 1.0 : ((this.b < 0.0) ? 0.0 : this.b);
				}
			}

			public double H
			{
				get
				{
					return this.h;
				}
				set
				{
					this.h = value;
					this.h = (this.h > 1.0) ? 1.0 : ((this.h < 0.0) ? 0.0 : this.h);
				}
			}

			public double S
			{
				get
				{
					return this.s;
				}
				set
				{
					this.s = value;
					this.s = (this.s > 1.0) ? 1.0 : ((this.s < 0.0) ? 0.0 : this.s);
				}
			}
		}
	}
}