using System;
using System.Drawing;
using System.Windows.Forms;

namespace osu_mouse2
{
    public partial class MainWindow : Form
    {
        private bool loaded;

        public MainWindow()
        {
            InitializeComponent();
            notifyIcon.Icon = Icon;
            if (Program.oldAccel[2].ToInt32() == 0)
                disableAccelButton.Enabled = false;
            else
                enableAccelButton.Enabled = false;
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            OnLoad();
        }

        public void OnLoad()
        {
            if (loaded)
                return;
            Program.MouseAccelDisabled += MouseAccelDisabled;
            Program.MouseAccelReset += MouseAccelReset;
            Program.tracer.ScanAll();
            loaded = true;
        }

        private void MouseAccelDisabled(object sender, EventArgs e)
        {
            if (InvokeRequired)
                Invoke(new EventHandler(MouseAccelDisabled), sender, e);
            else
            {
                enableAccelButton.Enabled = true;
                disableAccelButton.Enabled = false;
                enableAccelButton.Refresh();
                disableAccelButton.Refresh();
                infoLabel.Text = "Osu! found";
                notifyIcon.ShowBalloonTip(5000, "osu!mouse2", "Osu! found, mouse acceleration disabled", ToolTipIcon.Info);
            }
        }

        private void MouseAccelReset(object sender, EventArgs e)
        {
            if (InvokeRequired)
                Invoke(new EventHandler(MouseAccelReset), sender, e);
            else
            {
                if (Program.oldAccel[2].ToInt32() == 0)
                {
                    enableAccelButton.Enabled = true;
                    disableAccelButton.Enabled = false;
                }
                else
                {
                    enableAccelButton.Enabled = false;
                    disableAccelButton.Enabled = true;
                }
                infoLabel.Text = "Osu! exited";
                notifyIcon.ShowBalloonTip(1000, "osu!mouse2", "Osu! exited, mouse acceleration reset", ToolTipIcon.Info);
            }
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            notifyIcon.Visible = false;
            Program.Stop();
        }

        private void enableAccelButton_Click(object sender, EventArgs e)
        {
            enableAccelButton.Enabled = false;
            Program.MouseAccel._enableAccel(Program.oldAccel);
            disableAccelButton.Enabled = true;
        }

        private void enableAccelButton_MouseUp(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Right) != 0)
            {
                Program.oldAccel[2] = new IntPtr(1);
                enableAccelButton.Refresh();
                disableAccelButton.Refresh();
            }
        }

        private void disableAccelButton_Click(object sender, EventArgs e)
        {
            disableAccelButton.Enabled = false;
            Program.MouseAccel._disableAccel();
            enableAccelButton.Enabled = true;
        }

        private void disableAccelButton_MouseUp(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Right) != 0)
            {
                Program.oldAccel[2] = IntPtr.Zero;
                enableAccelButton.Refresh();
                disableAccelButton.Refresh();
            }
        }

        private void MainWindow_MouseUp(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Right) != 0)
            {
                Control c = GetChildAtPoint(e.Location);
                if (c == enableAccelButton)
                    Program.oldAccel[2] = new IntPtr(1);
                else if (c == disableAccelButton)
                    Program.oldAccel[2] = IntPtr.Zero;
                else
                    return;
                enableAccelButton.Refresh();
                disableAccelButton.Refresh();
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Close();
            Dispose();
            Application.Exit();
        }

        private void minimizeButton_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
        }

        private void enableAccelButton_Paint(object sender, PaintEventArgs e)
        {
            if (Program.oldAccel[2].ToInt32() != 0)
            {
                e.Graphics.DrawRectangle(Pens.Goldenrod, new Rectangle(1, 1, enableAccelButton.Width - 3, enableAccelButton.Height - 3));
                e.Graphics.DrawRectangle(Pens.Goldenrod, new Rectangle(2, 2, enableAccelButton.Width - 5, enableAccelButton.Height - 5));
            }
        }

        private void disableAccelButton_Paint(object sender, PaintEventArgs e)
        {
            if (Program.oldAccel[2].ToInt32() == 0)
            {
                e.Graphics.DrawRectangle(Pens.Goldenrod, new Rectangle(1, 1, disableAccelButton.Width - 3, disableAccelButton.Height - 3));
                e.Graphics.DrawRectangle(Pens.Goldenrod, new Rectangle(2, 2, disableAccelButton.Width - 5, disableAccelButton.Height - 5));
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            e.Graphics.DrawImage(Properties.Resources.logo, new Rectangle(logoPanel.Width / 5, logoPanel.Height / 3, logoPanel.Width * 3 / 5, logoPanel.Height * 1 / 3));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("\"Enable Accel\" enables mouse acceleration\n"
                + "\"Disable Accel\" disables mouse acceleration\n"
                + "\"Minimize\" minimizes the window\n"
                + "\"Exit\" exits osu!mouse2\n"
                + "\n"
                + "Command line options:\n"
                + "/minimized: starts osu!mouse2 in minimized mode\n");
        }
    }
}
