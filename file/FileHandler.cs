using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace ecgmonitor
{
	/// <summary>
	/// ECG File Handler
	/// </summary>
	class FileHandler
	{

		public static BinaryReader io;
		public static EcgStatistic id;

		public static string p;


		/// <summary>
		/// Initialize self streaming system
		/// </summary>
		/// <param name="path">path to file</param>
		public static void begin(string path)
		{
			p = path;
			end();
			if (File.Exists(path))
			{
				// load and save statistic file
				if (!File.Exists(path+".xml"))
				{
					formStatistic sttc = new formStatistic();
					if (sttc.ShowDialog() == DialogResult.OK)
					{
						EcgStatistic ecg = new EcgStatistic();
						ecg.id = sttc.mId.Text;
						ecg.name = sttc.mName.Text;
						ecg.age = sttc.mAge.Text;

						string[] tm = sttc.mTime.Text.Split(':');
						int hh = int.Parse(tm[0]);
						int mm = int.Parse(tm[1]);
						int ss = int.Parse(tm[2]);
						ecg.starttimeSec = ss + mm * 60 + hh * 60 * 60;

						id = ecg;

						
					}else{
						id = new EcgStatistic();
					}
					XmlClass<EcgStatistic>.Save(id, path + ".xml", SerializedFormat.Document);

				}else
				{
					id = XmlClass<EcgStatistic>.Load(path + ".xml", SerializedFormat.Document);
				}



				// load file to stream
				io = new BinaryReader(new FileStream(path, FileMode.Open));
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns>is file available to read</returns>
		public static bool available()
		{
			return File.Exists(p);
		}
		/// <summary>
		/// close stream
		/// </summary>
		public static void end()
		{
			if (io != null)
			{
				io.Close();
				io = null;
			}
		}

		/// <summary>
		/// load and filter signal
		/// </summary>
		/// <param name="slider">slider</param>
		/// <returns></returns>
		public static SignalSamples load(Slider slider)
		{
			// skip if file not exist
			if (!FileHandler.available())
				return null;


			// load samples
			Settings set = Settings.instance();

			int sampleRate = FileHandler.readSampleRate();
			SignalSamples samples = FileHandler.readBlocks(slider.seek, slider.blocks);

			samples = samples.Normalize();
			samples.sampleRate = sampleRate;


			// find signal amplitude
			Signal deltaGreat = samples.FindMax() - samples.FindMin();

			// 2x 12 hz filter
			if (set.noise12Hz)
			{
				samples.Filter(12, sampleRate / 2, 1.3f);
				samples.Filter(12, sampleRate / 2, 1.3f);
			}
			// 20 hz filter
			if (set.noise20Hz)
			{
				samples.Filter(20, sampleRate / 2, 1.3f);

				samples.Filter(20, sampleRate / 2, 1.3f);
			}

			// 45 hz filter
			if (set.noise45Hz)
				samples.Filter(45, sampleRate / 2, 1.3f);


			// 50hz or 60hz noise
			if (set.noiseCustom > 0)
				samples.Filter(set.noiseCustom, sampleRate / 2, 1);


			// notch filter
			if (set.noiseNotch)
				samples = FilterNotch.Process(samples, 400, 0.1f);



			// find signal loss enerrgy amplitude
			Signal deltaLess = samples.FindMax() - samples.FindMin();

			// amplify loosed amplitude
			samples.Amplify(deltaGreat, deltaLess);

			// load file description
			FileHandler.id = XmlClass<EcgStatistic>.Load(FileHandler.p + ".xml", SerializedFormat.Document);

			return samples;

		}

		
		/// <summary>
		/// save to file, each block is 512 bytes
		/// </summary>
		/// <param name="path">path to file</param>
		/// <param name="seek">position of block</param>
		/// <param name="blocks">blocks to save</param>
		public static void save(string path, long seek, long blocks)
		{
			
			if (seek > blocksCount())
				return;

			BinaryWriter bw = new BinaryWriter(new FileStream(path, FileMode.Create));

			long cnt = 0;
			if (seek < 0)
			{
				setPosition(0);
				cnt = blocks + seek;
			}
			else
			{
				setPosition(seek);
				cnt = blocks;
			}

			for (int i = 0; i < cnt; i++)
			{
				bw.Write(readBlock());


				if (remainingBlocks() < 1)
				{
					bw.Close();
					return;
				}
			}


			bw.Close();

			EcgStatistic ecg = new EcgStatistic();
			ecg.id = id.id;
			ecg.age = id.age;
			ecg.name = id.name;
			ecg.starttimeSec = id.starttimeSec + (int)((float)seek * 56.0f / FileHandler.readSampleRate());


			XmlClass<EcgStatistic>.Save(ecg, path + ".xml", SerializedFormat.Document);



		}
		/// <summary>
		///  each block is 512 bytes
		/// </summary>
		/// <returns>count of all blocks</returns>
		public static long blocksCount()
		{
			return io.BaseStream.Length / 512;
		}

		/// <summary>
		///  each block is 512 bytes
		/// </summary>
		/// <returns>remaining block available to read</returns>
		public static long remainingBlocks()
		{
			return (io.BaseStream.Length - io.BaseStream.Position) / 512;
		}
		/// <summary>
		/// set position to block
		/// </summary>
		/// <param name="bpos">block position in file</param>
		public static void setPosition(long bpos)
		{
			io.BaseStream.Position = bpos * 512;
		}
		/// <summary>
		/// read block and store them as signal samples for processing
		/// </summary>
		/// <param name="seek">seek to block</param>
		/// <param name="count">blocks to read</param>
		/// <returns></returns>
		public static SignalSamples readBlocks(long seek, long count)
		{
			SignalSamples samples = new SignalSamples();
			if (seek > blocksCount())
				return samples;


			long cnt = 0;
			if (seek < 0)
			{
				setPosition(0);
				cnt = count + seek;
			}
			else
			{
				setPosition(seek);
				cnt = count;
			}


			for (int i = 0; i < cnt; i++)
			{
				if (remainingBlocks() < 2)
				{
					return samples;
				}
				readBlock(ref samples);


			}
			return samples;

		}
		/// <summary>
		/// read from file based on time and sample rate
		/// </summary>
		/// <param name="start">start time in seconds</param>
		/// <param name="lapse">seconds of data to read</param>
		/// <param name="sampleRate">data sample rate, sample per seconds</param>
		/// <returns></returns>
		public static SignalSamples readSeconds(float start, float lapse, int sampleRate)
		{
			return readBlocks((int)((start) * (float)sampleRate / 56.0f), (int)((lapse + 1) * (float)sampleRate / 56.0f));

		}
		/// <summary>
		/// read sample rate
		/// </summary>
		/// <returns>sample rate</returns>
		public static int readSampleRate()
		{
			setPosition(0);

			int odr = 102400 * io.ReadByte() / io.ReadByte() / io.ReadByte() / io.ReadByte();

			setPosition(0);


			return odr;
		}
		/// <summary>
		/// read one block as byte array
		/// </summary>
		/// <returns>read one block</returns>
		private static byte[] readBlock()
		{
			return io.ReadBytes(512);
		}
		/// <summary>
		/// read single block as signal
		/// </summary>
		/// <param name="samples"></param>
		private static void readBlock(ref SignalSamples samples)
		{
			byte[] header = io.ReadBytes(8);

			double adcmax = 0x800000;

			byte SDM = header[0];

			byte R1 = header[1];
			byte R2 = header[2];
			byte R3 = header[3];

			int odr = 102400 * SDM / R1 / R2 / R3;

			if (R2 == 4 || R2 == 8)
			{
				if (R3 == 6 || R3 == 12)
					adcmax = 0xF30000;
				else
					adcmax = 0x800000;
			}
			else if (R2 == 5)
			{
				if (R3 == 6 || R3 == 12)
					adcmax = 0xB964F0;
				else
					adcmax = 0xC35000;
			}
			else if (R2 == 6)
			{
				if (R3 == 6 || R3 == 12)
					adcmax = 0xE6A900;
				else
					adcmax = 0xF30000;
			}

			for (int i = 0; i < 56; i++)
			{
				double sample1 = ((Math.Pow(2, 16) * io.ReadByte() + Math.Pow(2, 8) * io.ReadByte() + io.ReadByte()) / adcmax - 0.5) * 4.8 / 3.5 * 1000;
				double sample2 = ((Math.Pow(2, 16) * io.ReadByte() + Math.Pow(2, 8) * io.ReadByte() + io.ReadByte()) / adcmax - 0.5) * 4.8 / 3.5 * 1000;
				double sample3 = ((Math.Pow(2, 16) * io.ReadByte() + Math.Pow(2, 8) * io.ReadByte() + io.ReadByte()) / adcmax - 0.5) * 4.8 / 3.5 * 1000;

				Signal ss = new Signal() { lead1 = (float)sample1, lead2 = (float)sample2, lead3 = (float)sample3 };
				
				samples.Add(ss);
			}
		}
	}
}

