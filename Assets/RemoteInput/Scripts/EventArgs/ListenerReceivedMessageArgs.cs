using System;

namespace RemoteInput.Core.Network
{
    public class ListenerReceivedMessageArgs : EventArgs
    {
        public string StreamMessage { get; set; }
    }
}