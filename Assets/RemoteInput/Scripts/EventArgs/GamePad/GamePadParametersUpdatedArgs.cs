using System;

namespace RemoteInput.Core
{
    public class GamePadParametersUpdatedArgs : EventArgs
    {
        public GamePad GamePad { get; set; }
    }
}