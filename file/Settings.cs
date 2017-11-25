using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Collections.Specialized;

namespace ecgmonitor
{
	/// <summary>
	/// class for store and restoring data
	/// </summary>
	[Serializable]
	public class Settings
	{
		
		private static string filename = "config.ini";


		public string path = "";

		public bool noise12Hz = true;
		public bool noise20Hz = true;
		public bool noise45Hz = false;
		public bool noiseNotch = true;
		public int noiseCustom = 50;


		public EcgDetectionType detection = EcgDetectionType.QRS;
		public bool detectST = false;

		
		public long lastSeek = 0;
		public long lastBlocks = 100;
		public float lastOffset = 0.0f;
		public float lastZoom = 1.0f;




		public long perPage = 858;



		private static Settings inst;


		
		/// <summary>
		/// make instance of current class
		/// </summary>
		/// <returns></returns>
		public static Settings instance()
		{
			// load setting from path
			string path = Application.StartupPath + "\\" + filename;
			if (File.Exists(path))
			{
				inst = XmlClass<Settings>.Load(path, SerializedFormat.Document);
			}
			else
			{
				inst = new Settings();
				XmlClass<Settings>.Save(inst, path, SerializedFormat.Document);
			}
			return inst;
		}
		// store stored data
		public void commit()
		{

			string path = Application.StartupPath + "\\" + filename;
			XmlClass<Settings>.Save(this, path, SerializedFormat.Document);
		}
	}
}