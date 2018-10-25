using System;

namespace RemoteInput.Core.Network
{
    public class ClientConnectedArgs : EventArgs
    {
        public string RemoteEndPoint { get; set; }
    }
}