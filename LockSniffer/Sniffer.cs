using System;
using System.Linq;
using Microsoft.Win32;

namespace LockSniffer
{
    public class Sniffer
    {
        private static readonly SessionSwitchReason[] LockReasons = { SessionSwitchReason.SessionLogoff, SessionSwitchReason.SessionLock, SessionSwitchReason.RemoteDisconnect, SessionSwitchReason.ConsoleDisconnect };
        private static readonly SessionSwitchReason[] UnlockReasons = { SessionSwitchReason.SessionLogon, SessionSwitchReason.SessionUnlock, SessionSwitchReason.RemoteConnect, SessionSwitchReason.ConsoleConnect };
        private readonly Lögger _lög;

        public Sniffer(Lögger lög)
        {
            _lög = lög;
        }

        public void StartSniffing()
        {
            SystemEvents.SessionSwitch += SystemEvents_SessionSwitch;
        }

        public void StopSniffing()
        {
            SystemEvents.SessionSwitch -= SystemEvents_SessionSwitch;
        }

        void SystemEvents_SessionSwitch(object sender, SessionSwitchEventArgs e)
        {
            if (LockReasons.Contains(e.Reason))
            {
                _lög.Lög(new LögEntry { Locked = true, Timestamp = DateTime.Now, Message = e.Reason.ToString() });
            }

            if (UnlockReasons.Contains(e.Reason))
            {
                _lög.Lög(new LögEntry { Locked = false, Timestamp = DateTime.Now, Message = e.Reason.ToString() });
            }
        }
    }
}