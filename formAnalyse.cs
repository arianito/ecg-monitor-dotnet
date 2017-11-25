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
	public partial class formAnalyse : formi
	{
		// is thread working
		bool working = false;
		int sampleRate = 0;
		
	
		SignalSamples samples = new SignalSamples();



		public formAnalyse()
		{
			InitializeComponent();
			// disable qrs detection from graph

			graph1.detection = EcgDetectionType.None;
			ribon1.add("Start", box.play, true, () =>
			{

				// start thread for processing
				if (!working)
				{
					Thread trd = new Thread(new ThreadStart(run));
					trd.Start();
					working = true;
				}
			});
			ribon1.add("Load", box.folder, true, () =>
			{
				// open sample files
				OpenFileDialog op = new OpenFileDialog();
				op.Filter = "Sample Files (*.sample)|*.sample";
				if (op.ShowDialog() == DialogResult.OK)
				{

					// load samples from file
					graph1.samples = XmlClass<SignalSamples>.Load(op.FileName, SerializedFormat.Binary);
					graph1.sampleRate = graph1.samples.sampleRate;
					graph1.zoom = (float)graph1.samples.Count / (float)graph1.sampleRate;
					graph1.Refresh();
				}
			});
			ribon1.add("Save", box.save, true, () =>
			{
				// save samples
				if (graph1.samples != null)
				{
					SaveFileDialog op = new SaveFileDialog();
					op.Filter = "Sample Files (*.sample)|*.sample";
					if (op.ShowDialog() == DialogResult.OK)
					{

						XmlClass<SignalSamples>.Save(graph1.samples, op.FileName, SerializedFormat.Binary);
					}
				}
			});


		}
		/// <summary>
		/// thread for faster analysing
		/// </summary>
		void run()
		{

			// skip if file not available
			if (!FileHandler.available())
				return;



			progressBar1.Value = 0;

			// load sample rate
			sampleRate = FileHandler.readSampleRate();

			// load samples
			samples = FileHandler.load(slider1);

			progressBar1.Value = 20;
			Application.DoEvents();
			bool fst = false;
			// if signal was ecg
			if (decg.Checked)
			{
				// set samples
				graph1.samples = samples;
				graph1.sampleRate = sampleRate;
				graph1.ylabel = "mv";
			}
			else
			{
				graph1.samples = new SignalSamples();
				graph1.samples.sampleRate = 0;
				graph1.sampleRate = 0;

				bool stop = false;

				// initialize ecg arrays
				int[] tr = new int[3];
				int[] offset = new int[3];
				List<float>[] sigz = new List<float>[3];
				EcgCharacteristics[] last = new EcgCharacteristics[3];
				EcgCharacteristics[] now = new EcgCharacteristics[3];


				// define ecg arrays
				for (int i = 0; i < 3; i++)
				{

					sigz[i] = new List<float>();
					offset[i] = sampleRate;
					// detect first ecg signal
					last[i] = samples.FindDelta(i + 1, 0, offset[i]);
					tr[i] = 0;
				}

				// loop until signal is end
				do
				{
					for (int i = 0; i < 3; i++)
					{
						//  detect second ecg signal
						now[i] = samples.FindDelta(i + 1, last[i].lastCharacteristic(), offset[i]);


						// find distrance between two pulses
						offset[i] = Math.Abs(now[i]["R"].idx - last[i]["R"].idx);

						// if the heart beat(pulse rate) between exact range
						if (offset[i] > 0 && offset[i] < sampleRate)
						{

							// find heart beat sample rate
							if (!fst)
							{
								graph1.samples.sampleRate += offset[i];
								if (i == 2)
									fst = true;
							}
							float hpr = 0;

							// calculate ST line
							if (dst.Checked)
								hpr = (now[i]["ST"].value - now[i]["Q"].value);
							else if (dpr.Checked) // calculate heart beat
								hpr = 60.0f / (float)(offset[i] / (float)sampleRate);

							sigz[i].Add(hpr);
						}
						else
						{
							// if pulse rate was not reliable set offset as default sample rate 
							offset[i] = sampleRate;
						}
						//  if ecg data was not reliable try again
						if (now[i]["c"].idx <= 0 || now[i]["T"].idx <= 0)
						{
							tr[i]++;
						}

						// set last ecg signal if signal was out of range
						if (now[i].lastCharacteristic() <= last[i].lastCharacteristic())
							now[i]["c"].idx = last[i].lastCharacteristic() + offset[i];

						// skip if signal was out of range
						if (now[i].lastCharacteristic() + offset[i] > samples.Count)
							tr[i] = 40;

						// set 
						last[i] = now[i];

					}

					// return when data was end
					if (tr[0] > 30 && tr[1] > 30 && tr[2] > 30)
						stop = true;



				} while (!stop);

				// find maximum signal range
				int max = sigz[0].Count;
				for (int i = 0; i < 3; i++)
				{
					if (sigz[i].Count > max)
						max = sigz[i].Count;
				}

				// insert collected data as samples
				for (int i = 0; i < max; i++)
				{
					Signal sig = new Signal();
					for (int j = 0; j < 3; j++)
					{
						if (i < sigz[j].Count)
							sig[j + 1] = sigz[j][i];
					}

					graph1.samples.Add(sig);
				}
				// show results
				if(dpr.Checked)
					graph1.ylabel = ""; 
				else if(dst.Checked)
					graph1.ylabel = "mv";
				progressBar1.Value = 100;
				graph1.samples.sampleRate = (int)((float)sampleRate / (float)graph1.samples.sampleRate / 3.0f + 1);
				graph1.sampleRate = graph1.samples.sampleRate;
				graph1.samples.NoiseReduction(3);
			}
			graph1.zoom = (float)graph1.samples.Count / (float)graph1.sampleRate;

			graph1.Refresh();
			working = false;
		}
		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

			// skip if file is not specified
			if (!FileHandler.available())
				return;


			// read sample rate
			sampleRate = FileHandler.readSampleRate();
			slider1.sampleRate = sampleRate;


			// set default settings
			Settings set = Settings.instance();
			slider1.seek = set.lastSeek;
			slider1.blocks = set.lastBlocks;
			slider1.perPage = set.perPage;
			slider1.page = (long)(slider1.seek / slider1.perPage);
			slider1.blocksCount = FileHandler.blocksCount();


		}
	}
}
