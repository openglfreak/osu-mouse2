using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace osu_mouse2
{
    static class Program
    {
        public const String PROCESS_NAME = "osu!.exe";

        public static ProcessTracer tracer;
        public static List<UInt32> pids;

        public static IntPtr[] oldAccel = new IntPtr[3];
        public static event EventHandler MouseAccelDisabled;
        public static event EventHandler MouseAccelReset;

        /// <summary>
        /// This is german -> Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main(String[] args)
        {
            bool minimized = false;
            foreach (String arg in args)
                if (arg.ToLower() == "/help" || arg == "/?")
                {
                    Console.Write("options:\n"
                        + "\t/help: prints this text\n"
                        + "\t/minimized: starts in minimized mode\n");
                    return;
                }
                else if (arg.ToLower() == "/minimized")
                    minimized = true;
                else
                {
                    Console.WriteLine("unrecognized option: " + arg);
                    return;
                }

            MouseAccel._getAccel(oldAccel);

            tracer = new ProcessTracer(PROCESS_NAME);
            tracer.ProcessStarted += Program_ProcessStarted;
            tracer.ProcessStopped += Program_ProcessStopped;
            tracer.Start();
            pids = new List<UInt32>();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (minimized)
            {
                new MainWindow().OnLoad();
                Application.Run();
            }
            else
                Application.Run(new MainWindow());
        }

        public static void Stop()
        {
            tracer.Stop();
            MouseAccel._setAccel(oldAccel);
        }

        private static void Program_ProcessStarted(object sender, ProcessTracer.ProcessEventArgs e)
        {
            if (pids.Count == 0)
                DisableMouseAccel();
            pids.Add(e.ProcessID);
        }

        private static void Program_ProcessStopped(object sender, ProcessTracer.ProcessEventArgs e)
        {
            pids.Remove(e.ProcessID);
            if (pids.Count == 0)
                ResetMouseAccel();
        }

        private static void DisableMouseAccel()
        {
            MouseAccel._disableAccel();
            if (MouseAccelDisabled != null)
                MouseAccelDisabled.Invoke(null, EventArgs.Empty);
        }

        private static void ResetMouseAccel()
        {
            MouseAccel._setAccel(oldAccel);
            if (MouseAccelReset != null)
                MouseAccelReset.Invoke(null, EventArgs.Empty);
        }

        public static class MouseAccel
        {
            [DllImport("user32.dll", SetLastError = true)]
            private static extern bool SystemParametersInfo(uint uiAction, uint uiParam, IntPtr[] pvParam, uint fWinIni);

            private const int SPI_GETMOUSE = 0x03;
            private const int SPI_SETMOUSE = 0x04;
            private const int SPIF_SENDCHANGE = 0x02;

            public static void _getAccel(IntPtr[] arr)
            {
                if (!SystemParametersInfo(SPI_GETMOUSE, 0, arr, 0))
                    throw new Win32Exception(Marshal.GetLastWin32Error());
            }

            public static void _disableAccel()
            {
                _setAccel(new IntPtr[3] { IntPtr.Zero, IntPtr.Zero, IntPtr.Zero });
            }
            
            public static void _enableAccel(IntPtr[] arr)
            {
                arr = (IntPtr[])arr.Clone();
                arr[2] = new IntPtr(1);
                _setAccel(arr);
            }

            public static void _setAccel(IntPtr[] arr)
            {
                if (!SystemParametersInfo(SPI_SETMOUSE, 0, arr, 0))
                    throw new Win32Exception(Marshal.GetLastWin32Error());
            }
        }
    }
}
