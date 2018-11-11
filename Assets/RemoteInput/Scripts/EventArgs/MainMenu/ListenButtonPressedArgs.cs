using System;

namespace RemoteInput.Core
{
    public class ConnectButtonPressedArgs : EventArgs
    {
        public string IpAddress { get; set; }
    }
}
