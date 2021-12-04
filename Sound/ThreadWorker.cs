using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Sound
{
    public class ThreadWorker
    {
        private volatile string _command = "";
        private volatile string[] _audioDevices = new string[]{};
        private volatile bool _stop;
        private int _lastDisplay;

        public ThreadWorker() { }
        
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern IntPtr GetForegroundWindow();
    
        [DllImport("user32", SetLastError = true)]
        private static extern int GetWindowText(
            IntPtr hWnd,
            StringBuilder lpString,
            int nMaxCount 
        );
 
        [DllImport("user32.dll")]
        private static extern int GetClassName(
            IntPtr hWnd,
            StringBuilder lpString, 
            int nMaxCount 
        );

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool GetWindowRect(IntPtr hWnd, ref RECT lpRect);

        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left;  
            public int Top;
            public int Right;
            public int Bottom;
        }
        
        [DllImport("user32")]
        public static extern int GetSystemMetrics(int nIndex);
        
        
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern int GetWindowThreadProcessId(IntPtr hwnd, out int ID);
        
        public void Start()
        {
            Worker();
        }
        
        private int OnDisplay(int l, int t)
        {
            for (int i = 0; i < Screen.AllScreens.Length; i++)
            {
                if (l > Screen.AllScreens[i].Bounds.Left && l <= Screen.AllScreens[i].Bounds.Right &&
                    t > Screen.AllScreens[i].Bounds.Top && t <= Screen.AllScreens[i].Bounds.Bottom)
                {
                    return i;
                }
            }
            return 0;
        }

        private void Worker()
        {
            Console.WriteLine("Start work!");
            DeviceList device = DeviceList.GetAudioDevice();
            while (!_stop)
            {
                IntPtr window = GetForegroundWindow();
                RECT r = new RECT();
                GetWindowRect(window, ref r);
                int tid = 0;
                int pid = 0;
                tid = GetWindowThreadProcessId(window, out pid);
                Process p = Process.GetProcessById(pid);
                int onNoDisplay = OnDisplay(r.Left + (r.Right - r.Left) / 2, r.Top + (r.Bottom - r.Top) / 2);
                if (_lastDisplay != onNoDisplay)
                {
                    Console.WriteLine(p.ProcessName+" sound move to disp."+onNoDisplay+" PID"+pid);
                    Console.WriteLine(_command);
                    Excu(onNoDisplay, pid+"", false);
                }
                _lastDisplay = onNoDisplay;
                Thread.Sleep(1000);
            }
            Console.WriteLine("Stop work!");
        }

        private void Excu(int noOfDisplay, string process, bool headphone)
        {
            Process p = new Process();
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.RedirectStandardInput = true;
            p.Start();
            if(!headphone)
                p.StandardInput.WriteLine(_command+" /SetAppDefault "+(_audioDevices[noOfDisplay])+" 0 "+process);
            else
                p.StandardInput.WriteLine(_command+" /SetDefault "+(_audioDevices[noOfDisplay])+" 0");
            p.StandardInput.Flush();
            p.StandardInput.Close();
            p.Close();
        }

        public void Terminate(bool stop) { this._stop = stop; }
        
        public void SetLocation(string location)
        {
            _command = location;
        }

        public void SetDeviceId(string[] list)
        {
            _audioDevices = list;
        }

        public void AddAudioDevice(int noOfDisp, string deviceID)
        {
            if (noOfDisp < _audioDevices.Length)
                _audioDevices[noOfDisp] = deviceID;
            else
            {
                string[] newArr = new string[_audioDevices.Length + 1];
                _audioDevices.CopyTo(newArr, 0);
                newArr[_audioDevices.Length] = deviceID;
                _audioDevices = newArr;
            }
        }
    }
}