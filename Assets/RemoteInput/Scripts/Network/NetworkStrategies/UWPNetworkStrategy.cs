#if NETFX_CORE
#endif
//TODO: fix #if 

using System;

namespace RemoteInput.Core.Network
{
    public class UWPNetworkStrategy : INetworkStrategy
    {
        string INetworkStrategy.Connect(string ipAddress, int port)
        {
            throw new NotImplementedException();
        }

        string INetworkStrategy.Listen(int port)
        {
            throw new NotImplementedException();
        }

        void INetworkStrategy.SendData(object data)
        {
            throw new NotImplementedException();
        }
    }
}
