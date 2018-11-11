using System;

namespace RemoteInput.Core.Network
{
    public class InputDataReceivedArgs : EventArgs
    {
        public GamePad GamePadData { get; set; }
    }
}