using System;

namespace RemoteInput.Core.Network
{
    public class ListenerAcceptedClientArgs : EventArgs
    {
        public string ClientEndPoint { get; set; }
    }
}