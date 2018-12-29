using RemoteInput.Core;
using System;

namespace Game.Core
{
    public class ControllerDataReceivedArgs : EventArgs
    {
        public GamePad GamePad { get; set; }
    }
}