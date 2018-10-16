using System.Net;

namespace RemoteInput.Core.Network
{
    public interface INetworkStrategy
    {
        /// <summary>
        /// Listen given port
        /// </summary>
        /// <param name="port"></param>
        /// <returns></returns>
        string Listen(int port);
        string Connect(string ipAddress, int port);
        void SendData(object data);
    }
}
