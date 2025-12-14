using System;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace cp_lab_11
{
    public partial class Form1 : Form
    {
        private Downloader downloader;

        public Form1()
        {
            InitializeComponent();
            downloader = new Downloader();

            downloader.ProgressChanged += Downloader_ProgressChanged;
            downloader.DownloadCompleted += Downloader_DownloadCompleted;
        }

        private void StartDownloadButton_Click(object sender, EventArgs e)
        {
            ProgressBar1.Value = 0;
            downloader.Start();
        }

        private void Downloader_ProgressChanged(int percent)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => Downloader_ProgressChanged(percent)));
                return;
            }

            ProgressBar1.Value = Math.Min(percent, 100);
        }

        private void Downloader_DownloadCompleted(string message)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => Downloader_DownloadCompleted(message)));
                return;
            }

            MessageBox.Show(message, "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
