using System;

namespace RemoteInput.Core.Network
{
    public class ListenerStartedArgs : EventArgs
    {
        public string LocalEndPoint { get; set; }
    }
}