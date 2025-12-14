using System;
using System.Windows.Forms;

namespace cp_lab_11
{
    public class Downloader
    {
        public delegate void ProgressChangedHandler(int percent);
        public delegate void DownloadCompletedHandler(string message);

        public event ProgressChangedHandler ProgressChanged;
        public event DownloadCompletedHandler DownloadCompleted;

        private readonly Timer timer;
        private int progress;

        public Downloader()
        {
            timer = new Timer();
            timer.Interval = 100;
            timer.Tick += Timer_Tick;
        }

        public void Start()
        {
            progress = 0;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            progress += 5;

            ProgressChanged.Invoke(progress);

            if (progress >= 100)
            {
                timer.Stop();
                DownloadCompleted.Invoke("The developer of this virus was a bit lazy so now you yourself have to delete all the system files");
            }
        }
    }
}
