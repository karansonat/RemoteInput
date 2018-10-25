using System;

namespace RemoteInput.Core.Network
{
    public class ListenerReceivedMessageArgs : EventArgs
    {
        public object StreamMessage { get; set; }
    }
}