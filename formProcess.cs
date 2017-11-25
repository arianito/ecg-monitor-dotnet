using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace ecgmonitor
{
	public partial class formProcess : formi
	{
		formMain main;
		public formProcess(formMain m)
		{
			this.main = m;
			InitializeComponent();
		}
		public struct time
		{
			public long block;
			public int sampleRate;
			public float s2;
			public override string ToString()
			{
				return convertSecs((float)block * 56.0f / sampleRate + s2);
			}
			 
			public string convertSecs(float sec)
			{
				if (sec < 0) sec = -sec;

				string s = "-";
				TimeSpan t = TimeSpan.FromSeconds(sec);
				s = t.Seconds + "s";

				if (t.Minutes > 0)
					s = t.Minutes + "m" + s;

				if (t.Hours > 0)
					s = t.Hours + "h" + s;
				if (t.Days > 0)
					s = t.Days + "d" + s;

				return s;


			}
		}
		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);
			this.listBox1.Items.Clear();


			EcgStatistic set = FileHandler.id;
			
			if (set.critical != null)
			{
				foreach (var l in set.critical)
				{
					time t = new time();
					t.block = l;
					t.sampleRate = main.graph1.sampleRate;
					t.s2 = FileHandler.id.starttimeSec;
					listBox1.Items.Add(t);
				}
			}



			
		}
		private void panel1_Paint(object sender, PaintEventArgs e)
		{

		}
		Thread trd;
		private void button1_Click(object sender, EventArgs e)
		{
			trd = new Thread(new ThreadStart(run));
			trd.Start();
		}

		void run()
		{

			progressBar1.Minimum = 0;
			progressBar1.Maximum = 100;

			if (!FileHandler.available())
				return;

			EcgStatistic set = FileHandler.id;
			

			if (set.critical == null)
				set.critical = new List<long>();
			

			long len = FileHandler.blocksCount();

			long i0 = 0;
			if (set.critical.Count > 2)
				i0 = set.critical[set.critical.Count - 1] + 1;


			for (long i = i0; i < len; i++)
			{

				FileHandler.setPosition(i);

				if (FileHandler.remainingBlocks() < 2)
					break;

				int sdm = FileHandler.io.ReadByte();
				if (sdm == 170)
					set.critical.Add(i);

				progressBar1.Value = (int)((float)i / (float)len * 100.0f);
				progressBar1.Refresh();
			
				


			}
			XmlClass<EcgStatistic>.Save(set, FileHandler.p+".xml", SerializedFormat.Document);
			listBox1.Items.Clear();
			if (set.critical != null)
			{
				foreach (var l in set.critical)
				{
					time t = new time();
					t.block = l;
					t.sampleRate = main.graph1.sampleRate;
					t.s2 = FileHandler.id.starttimeSec;
					listBox1.Items.Add(t);
				}
			}

			progressBar1.Value = 0;
			progressBar1.Refresh();

			MessageBox.Show("finish!");

		}
	}
}
