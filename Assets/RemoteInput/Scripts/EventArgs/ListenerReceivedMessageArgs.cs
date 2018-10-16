using System;

public class ListenerReceivedMessageArgs : EventArgs
{
    public object StreamMessage { get; set; }
}