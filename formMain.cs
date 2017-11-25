using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.IO;

namespace ecgmonitor
{
	public partial class formMain : formi
	{
		/// <summary>
		/// make zero before number
		/// </summary>
		/// <param name="inp"></param>
		/// <returns></returns>
		string zero(int inp)
		{
			string o = inp.ToString();
			while (o.Length < 2) o = "0" + o;
			return o;
		}
		public formMain()
		{
			InitializeComponent();
			ribon1.add("Open", box.folder, true, () =>
			{
				// open ecg file
				OpenFileDialog op = new OpenFileDialog();
				op.Filter = "ECG Files (*.bin)|*.bin";
				if (op.ShowDialog() == DialogResult.OK)
				{
					// store path to config
					Settings set = Settings.instance();
					set.path = op.FileName;
					set.commit();
					// load file
					FileHandler.begin(set.path);
					this.OnLoad(null);

				}

			});
			ribon1.add("Print", box.mail, true, () =>
			{
				// skip if file not loaded
				if (!FileHandler.available())
					return;
				// open print form
				formPrint frm = new formPrint(this);
				frm.ShowDialog();



			});
			ribon1.add("Edit", box.edit, true, () =>
			{
				// skip if file not loaded
				if (!FileHandler.available())
					return;
				Settings set = Settings.instance();

				// edit file information
				formStatistic sttc = new formStatistic();

				sttc.mId.Text = FileHandler.id.id;
				sttc.mName.Text = FileHandler.id.name;
				sttc.mAge.Text = FileHandler.id.age;

				TimeSpan ts = TimeSpan.FromSeconds(FileHandler.id.starttimeSec);



				sttc.mTime.Text = zero(ts.Hours) + ":" + zero(ts.Minutes) + ":" + zero(ts.Seconds);

				if (sttc.ShowDialog() == DialogResult.OK)
				{
					// load ecg information data
					EcgStatistic ecg = new EcgStatistic();
					ecg.id = sttc.mId.Text;
					ecg.name = sttc.mName.Text;
					ecg.age = sttc.mAge.Text;
					ecg.critical = FileHandler.id.critical;
					string[] tm = sttc.mTime.Text.Split(':');
					int hh = int.Parse(tm[0]);
					int mm = int.Parse(tm[1]);
					int ss = int.Parse(tm[2]);
					ecg.starttimeSec = ss + mm * 60 + hh * 60 * 60;

					FileHandler.id = ecg;

					// save file information
					XmlClass<EcgStatistic>.Save(ecg, set.path + ".xml", SerializedFormat.Document);

					// refresh graph data
					graph1.ecgid = ecg;
					slider1.s2 = graph1.ecgid.starttimeSec;
					graph1.s2 = graph1.ecgid.starttimeSec + slider1.seek * 56.0f / sampleRate;
					graph1.Refresh();
					slider1.Refresh();




				}


			});
			ribon1.add("Save", box.save, true, () =>
			{
				// skip if file not loaded
				if (!FileHandler.available())
					return;

				// save  data 
				SaveFileDialog op = new SaveFileDialog();
				op.Filter = "ECG Files (*.bin)|*.bin";
				if (op.ShowDialog() == DialogResult.OK)
				{
					FileHandler.save(op.FileName, slider1.seek, slider1.blocks);
				}
			});
			ribon1.add("Analyses", box.heart, true, () =>
			{
				if (!FileHandler.available())
					return;

				// open analyse form
				formAnalyse frm = new formAnalyse();
				frm.ShowDialog();
			});


			ribon1.add("Goto", box.ff, true, () =>
			{
				// skip if file not loaded
				if (!FileHandler.available())
					return;

				// goto time
				formTime tme = new formTime();

				TimeSpan ts = TimeSpan.FromSeconds(FileHandler.id.starttimeSec + slider1.seek * 56.0f / slider1.sampleRate);
				tme.mDays.Value = ts.Days;
				tme.mTime.Text = zero(ts.Hours) + ":" + zero(ts.Minutes) + ":" + zero(ts.Seconds);


				if (tme.ShowDialog() == DialogResult.OK)
				{

					int days = (int)(tme.mDays.Value);
					string[] tm = tme.mTime.Text.Split(':');
					int hh = int.Parse(tm[0]);
					int mm = int.Parse(tm[1]);
					int ss = int.Parse(tm[2]);

					// calculate seek seconds
					long sc = days * 24 * 60 * 60 + hh * 60 * 60 + mm * 60 + ss;

					// conver seconds to block number
					slider1.seek = (long)((float)(sc - FileHandler.id.starttimeSec) * (float)slider1.sampleRate / 56.0f) + 1;

					if (slider1.seek < 0)
						slider1.seek = 0;

					slider1.page = (long)((float)slider1.seek / (float)slider1.perPage);

					// refresh
					slider1.reload();
				}

			});
			ribon1.add("Process Button Presses", box.analyse, true, () =>
			{
				// skip if file not loaded
				if (!FileHandler.available())
					return;

				// open signal for analysing button presses
				formProcess frm = new formProcess(this);
				if (frm.ShowDialog() == DialogResult.OK)
				{
					if (frm.listBox1.SelectedIndex >= 0)
					{
						var aa = (formProcess.time)(frm.listBox1.Items[frm.listBox1.SelectedIndex]);

						slider1.seek = aa.block;
						slider1.reload();
					}
				}


			});
			ribon1.add("Settings", box.settings, false, () =>
			{
				formSettings frm = new formSettings(this);
				frm.ShowDialog();
			});

			ribon1.add("About", box.i, false, () => { });

		}
		int sampleRate;

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

			// skip if file not loaded
			if (!FileHandler.available())
				return;


			// read sample rate from file
			sampleRate = FileHandler.readSampleRate();
			graph1.sampleRate = sampleRate;
			slider1.sampleRate = sampleRate;

			// read settings
			Settings set = Settings.instance();
			slider1.seek = set.lastSeek;
			slider1.blocks = set.lastBlocks;
			slider1.perPage = set.perPage;
			slider1.page = (long)(slider1.seek / slider1.perPage);
			slider1.blocksCount = FileHandler.blocksCount();


			// config zoom and start point
			graph1.start = set.lastOffset;
			graph1.zoom = set.lastZoom;

			graph1.detection = set.detection;
			graph1.detectST = set.detectST;

			// load filtered samples
			graph1.samples = FileHandler.load(slider1);
			graph1.ecgid = FileHandler.id;
			slider1.critical = graph1.ecgid.critical;


			slider1.s2 = graph1.ecgid.starttimeSec;
			graph1.s2 = slider1.seek * 56.0f / slider1.sampleRate;

			slider1.Refresh();
			graph1.Refresh();



			// on scroll changes
			graph1.onChange = () =>
			{
				if (!FileHandler.available())
					return;
				set = Settings.instance();
				set.lastOffset = graph1.start;
				set.lastZoom = graph1.zoom;
				set.commit();
			};
			// on slider position changes
			slider1.onChange = () =>
			{

				if (!FileHandler.available())
					return;
				set = Settings.instance();
				set.lastSeek = slider1.seek;
				set.lastBlocks = slider1.blocks;
				set.perPage = slider1.perPage;


				graph1.samples = FileHandler.load(slider1);

				slider1.critical = FileHandler.id.critical;


				graph1.zoom = slider1.blocks * 56.0f / slider1.sampleRate;
				graph1.s2 = slider1.seek * 56.0f / slider1.sampleRate;

				if (slider1.seek < 0)
					graph1.start = slider1.seek * 56.0f / slider1.sampleRate;
				else
					graph1.start = 0;


				graph1.detection = set.detection;
				graph1.detectST = set.detectST;


				set.commit();



				if (graph1.samples.Count < graph1.zoom * sampleRate)
					graph1.zoom = (float)graph1.samples.Count / (float)sampleRate;

				graph1.Refresh();

			};



		}
	}
}
