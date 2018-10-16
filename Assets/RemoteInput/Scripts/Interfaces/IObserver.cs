using System;
namespace RemoteInput.Core
{
    public interface IObserver<T> where T : EventArgs
    {
        void OnNotified(object sender, T eventArgs);
    }
}
