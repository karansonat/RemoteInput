using System.Net;

namespace RemoteInput.Core.Network
{
    public interface INetworkStrategy
    {
        /// <summary>
        /// Listen given port
        /// </summary>
        /// <param name="port"></param>
        /// <returns>returns server's local end point address</returns>
        string Listen(int port);

        /// <summary>
        /// Connect to address;
        /// </summary>
        /// <param name="ipAddress"></param>
        /// <param name="port"></param>
        /// <returns>returns client end point</returns>
        string Connect(string ipAddress, int port);
        void SendData(object data);
        void Suspend();
    }
}
