using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ecgmonitor
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			// load file

			Settings set = Settings.instance();
			FileHandler.begin(set.path);
			Application.Run(new formMain());


		}


	}
}
