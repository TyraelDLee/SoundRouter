using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using Sound;

namespace Sound
{
    public partial class SoundMapper : Form
    {
        private string _svLocation = "";

        public SoundMapper()
        {
            InitializeComponent();
            ThreadWorker tw = new ThreadWorker();
            Thread worker = new Thread(tw.Start);
            worker.IsBackground = true;
            worker.Name = "bg worker";
            worker.Start();
        }

        public SoundMapper(string location)
        {
            InitializeComponent();
            ThreadWorker tw = new ThreadWorker();
            Thread worker = new Thread(tw.Start);
            tw.SetLocation(location);
            worker.IsBackground = true;
            worker.Name = "bg worker";
            worker.Start();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                ni.Visible = true;
                this.Visible = false;
            }
            else
            {
                ni.Visible = false;
            }
        }

        private void ni_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Visible = true;
            this.WindowState = FormWindowState.Normal;
        }

        public void SetLocaiton(string location)
        {
            this._svLocation = location;
        }
    }
}
