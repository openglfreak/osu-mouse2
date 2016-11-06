using System;
using System.Diagnostics;
using System.IO;
using System.Management;

namespace osu_mouse2
{
    public class ProcessTracer
    {
        private String processName;
        public String ProcessName
        {
            get
            {
                return processName;
            }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("value");
                else if (value.Length == 0)
                    throw new ArgumentException("", "value");
                else
                    processName = value;
            }
        }

        private ManagementEventWatcher processStartWatcher;
        private ManagementEventWatcher processStopWatcher;

        public delegate void ProcessEventHandler(object sender, ProcessEventArgs e);
        public event ProcessEventHandler ProcessStarted;
        public event ProcessEventHandler ProcessStopped;

        public class ProcessEventArgs : EventArgs
        {
            public uint ProcessID { get; }
            public String ProcessName { get; }

            public ProcessEventArgs(uint pid, String name)
            {
                ProcessID = pid;
                ProcessName = name;
            }
        }

        public ProcessTracer(String name)
        {
            ProcessName = name;

            processStartWatcher = new ManagementEventWatcher(new WqlEventQuery("Win32_ProcessStartTrace"));
            processStartWatcher.EventArrived += new EventArrivedEventHandler(ProcessStartEventArrived);
            processStopWatcher = new ManagementEventWatcher(new WqlEventQuery("Win32_ProcessStopTrace"));
            processStopWatcher.EventArrived += new EventArrivedEventHandler(ProcessStopEventArrived);
        }

        public void Start()
        {
            processStartWatcher.Start();
            processStopWatcher.Start();
        }

        public void Stop()
        {
            processStartWatcher.Stop();
            processStopWatcher.Stop();
        }

        public void ScanAll()
        {
            ScanAll(ProcessStarted);
        }

        public void ScanAll(ProcessEventHandler handler)
        {
            if (handler != null)
                foreach (Process p in Process.GetProcessesByName(Path.GetFileNameWithoutExtension(processName)))
                    handler.Invoke(this, new ProcessEventArgs((uint)p.Id, processName));
        }

        private void ProcessStartEventArrived(object sender, EventArrivedEventArgs e)
        {
            ProcessEventArrived(sender, e, ProcessStarted);
        }

        private void ProcessStopEventArrived(object sender, EventArrivedEventArgs e)
        {
            ProcessEventArrived(sender, e, ProcessStopped);
        }

        private void ProcessEventArrived(object sender, EventArrivedEventArgs e, ProcessEventHandler handler)
        {
            if (handler == null)
                return;
            String name = (String)e.NewEvent.GetPropertyValue("ProcessName");
            if (name == processName)
                handler.Invoke(this, new ProcessEventArgs((UInt32)e.NewEvent.GetPropertyValue("ProcessID"), name));
        }
    }
}
