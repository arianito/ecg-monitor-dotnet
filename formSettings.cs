using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ecgmonitor
{
	public partial class formSettings : formi
	{
		formMain frm;
		public formSettings(formMain frm)
		{
			InitializeComponent();
			this.frm = frm;
		}
		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);


			// load and save settings
			Settings set = Settings.instance();

			perPage.Value = (decimal)((float)set.perPage / 858.0f);

			noise12hz.Checked = set.noise12Hz;
			noise20hz.Checked = set.noise20Hz;
			noise45hz.Checked = set.noise45Hz;
			noiseNotch.Checked = set.noiseNotch;
			if (set.noiseCustom == 50)
				noise50hz.Checked = true;
			else if (set.noiseCustom == 60)
				noise60hz.Checked = true;


			noise12hz.CheckedChanged += new EventHandler(noise12hz_CheckedChanged);
			noise20hz.CheckedChanged += new EventHandler(noise12hz_CheckedChanged);
			noise45hz.CheckedChanged += new EventHandler(noise12hz_CheckedChanged);
			noise50hz.CheckedChanged += new EventHandler(noise12hz_CheckedChanged);
			noise60hz.CheckedChanged += new EventHandler(noise12hz_CheckedChanged);

			perPage.ValueChanged +=new EventHandler(perPage_ValueChanged);


			if (set.detection == EcgDetectionType.PQ)
				detectPQ.Checked = true;
			else if (set.detection == EcgDetectionType.QT)
				detectQT.Checked = true;
			else if (set.detection == EcgDetectionType.QRS)
				detectQRS.Checked = true;
			else if (set.detection == EcgDetectionType.None)
				detectNone.Checked = true;

			detectST.Checked = set.detectST;


			detectPQ.CheckedChanged += new EventHandler(view_CheckedChanged);
			detectQT.CheckedChanged += new EventHandler(view_CheckedChanged);
			detectQRS.CheckedChanged += new EventHandler(view_CheckedChanged);
			detectNone.CheckedChanged += new EventHandler(view_CheckedChanged);
			detectST.CheckedChanged += new EventHandler(view_CheckedChanged);

		}

		private void noise12hz_CheckedChanged(object sender, EventArgs e)
		{

			Settings set = Settings.instance();

			set.noise12Hz = noise12hz.Checked;
			set.noise20Hz = noise20hz.Checked;
			set.noise45Hz = noise45hz.Checked;

			set.noiseNotch = noiseNotch.Checked;
			if (noise50hz.Checked)
				set.noiseCustom = 50;
			else if (noise60hz.Checked)
				set.noiseCustom = 60;

			set.commit();

			frm.graph1.samples = FileHandler.load(frm.slider1);
			frm.graph1.Refresh();
		}


		private void view_CheckedChanged(object sender, EventArgs e)
		{

			Settings set = Settings.instance();

			if (detectPQ.Checked)
				set.detection = EcgDetectionType.PQ;
			else if (detectQT.Checked)
				set.detection = EcgDetectionType.QT;
			else if (detectQRS.Checked)
				set.detection = EcgDetectionType.QRS;
			else if (detectNone.Checked)
				set.detection = EcgDetectionType.None;

				set.detectST = detectST.Checked;


			set.commit();

			frm.graph1.detection = set.detection;
			frm.graph1.detectST = set.detectST;
			frm.graph1.Refresh();
		}

		private void perPage_ValueChanged(object sender, EventArgs e)
		{


			Settings set = Settings.instance();

			set.perPage = (long)((float)perPage.Value * 858.0f);

			set.commit();
			frm.slider1.perPage = set.perPage;
			frm.slider1.Refresh();
		}
	}
}
