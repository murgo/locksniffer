using System;
using System.Windows.Forms;

namespace LockSniffer
{
    class SnifferAppContext : ApplicationContext
    {
        private NotifyIcon _trayIcon;
        private readonly Lögger _lög;
        private readonly Sniffer _sniffer;

        public SnifferAppContext()
        {
            Application.ApplicationExit += OnApplicationExit;
            InitializeComponent();
            _trayIcon.Visible = true;

            _lög = new Lögger();
            _sniffer = new Sniffer(_lög);

            _lög.Lög(new LögEntry { Locked = false, Message = "Service started", Timestamp = DateTime.Now });
            _sniffer.StartSniffing();
        }

        private void InitializeComponent()
        {
            _trayIcon = new NotifyIcon
            {
                BalloonTipIcon = ToolTipIcon.Info,
                Text = "LockSniffer",
                Icon = Resource1.icon
            };

            _trayIcon.DoubleClick += TrayIcon_DoubleClick;
        }

        private void OnApplicationExit(object sender, EventArgs e)
        {
            _lög.Lög(new LögEntry { Locked = true, Message = "Service stopped", Timestamp = DateTime.Now });
            _sniffer.StopSniffing();

            _trayIcon.Visible = false;
        }

        private void TrayIcon_DoubleClick(object sender, EventArgs e)
        {
            var reportForm = new ReportForm(new Repörter());
            reportForm.Show();
        }
    }
}
