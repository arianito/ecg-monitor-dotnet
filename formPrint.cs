using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Drawing.Printing;

namespace ecgmonitor
{
	public partial class formPrint : formi
	{
		formMain main;
		public formPrint(formMain m)
		{
			InitializeComponent();
			this.main = m;
		}
		int i = 0;
		PrintDocument pd = new PrintDocument();
		protected override void OnLoad(EventArgs e2)
		{
			base.OnLoad(e2);
			pd = new PrintDocument();
			pd.DefaultPageSettings.PaperSize = new PaperSize("PaperA4", 826, 1169);
			pd.DefaultPageSettings.Landscape = true;

			pd.PrintPage += (ss, e) =>
			{
				// calculate page count
				int pg = (int)((float)slider1.blocksCount / (float)slider1.blocks + 1);

				

				printPreviewControl1.Rows = pg;

				// draw pages
				main.graph1.s2 = main.slider1.seek * 56.0f / (float)main.graph1.sampleRate + i * (float)slider1.blocks * 56.0f / (float)main.graph1.sampleRate;
				main.graph1.print(e.Graphics, e.PageBounds, i * (int)slider1.blocks * 56, (int)slider1.blocks * 56);

				i++;

				e.HasMorePages = i < pg;

			};
			// lock slider to zero
			printPreviewControl1.Document = pd;
			slider1.seek = 0;
			slider1.sampleRate = main.graph1.sampleRate;
			slider1.s2 = main.slider1.s2 + (int)((float)main.slider1.seek * 56.0f / main.slider1.sampleRate);
			slider1.blocksCount = (long)((int)main.graph1.samples.Count / 56.0f);
			slider1.perPage = slider1.blocksCount;
			slider1.blocks = slider1.blocksCount / 2;
			slider1.locked = true;
			slider1.Refresh();
			slider1.onChange = () =>
			{
				i = 0;
				printPreviewControl1.InvalidatePreview();
			};


		}

		private void button1_Click(object sender, EventArgs e)
		{

			PrintDialog pdl = new PrintDialog();
			pdl.UseEXDialog = true;
			pdl.Document = pd;
			if (pdl.ShowDialog() == DialogResult.OK)
			{
				i = 0;
				pd.Print();
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			// reset slider bar
			slider1.seek = 0;
			slider1.sampleRate = main.graph1.sampleRate;
			slider1.blocksCount = (long)((int)main.graph1.samples.Count / 56.0f);
			slider1.perPage = slider1.blocksCount;
			slider1.blocks = slider1.blocksCount / 2;
			slider1.locked = true;
			slider1.reload();
		}
	}
}
