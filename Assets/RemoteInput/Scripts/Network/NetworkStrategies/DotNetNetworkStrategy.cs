#if !NETFX_CORE

using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using UnityEngine;

namespace RemoteInput.Core.Network
{
    public class DotNetNetworkStrategy : INetworkStrategy, IObservable<ListenerReceivedMessageArgs>,
                                                           IObservable<ListenerAcceptedClientArgs>
    {
        #region Fields
        
        private TcpListener _listener;
        private TcpClient _client;
        private NetworkStream _stream;
        private Thread _serviceThread;

        //Events
        private event EventHandler<ListenerAcceptedClientArgs> ListenerAcceptedClient;
        private event EventHandler<ListenerReceivedMessageArgs> ListenerReceivedMessage;

        //Args
        protected ListenerReceivedMessageArgs ListenerReceivedMessageArgs;

        #endregion //Fields

        #region Constructor

        public DotNetNetworkStrategy()
        {
            ListenerReceivedMessageArgs = new ListenerReceivedMessageArgs();
            _serviceThread = new Thread(Service);
        }

        #endregion

        string INetworkStrategy.Connect(string ipAddress, int port)
        {
            var hostName = Dns.GetHostName();
            _client = new TcpClient();
            _client.Connect(IPAddress.Parse(ipAddress), port);
            _client.NoDelay = true;
            _stream = _client.GetStream();
            return _client.Client.RemoteEndPoint.ToString();
        }

        string INetworkStrategy.Listen(int port)
        {
            var ipAddress = IPAddress.Parse(GetLocalIPAddress());
            _listener = new TcpListener(ipAddress, port);
            _listener.Start();

            Thread thread = new Thread(Service);
            thread.Start();

            return _listener.Server.LocalEndPoint.ToString();
        }

        void INetworkStrategy.SendData(object data)
        {
            var jsonString = JsonUtility.ToJson(data);
            Debug.Log("INetworkStrategy.SendData: " + jsonString);
            var byteMessage = Encoding.ASCII.GetBytes(jsonString);
            _stream.Write(byteMessage, 0, byteMessage.Length);
        }

        void INetworkStrategy.Suspend()
        {
            _serviceThread.Abort();
        }

        #region Private Methods

        private string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }

        private void Service()
        {
            _client = _listener.AcceptTcpClient();
            _listener.Stop();
            _stream = _client.GetStream();

            (this as IObservable<ListenerAcceptedClientArgs>).Notify(
                new ListenerAcceptedClientArgs
                {
                    ClientEndPoint = ((IPEndPoint)_client.Client.RemoteEndPoint).Address.ToString()
                });

            byte[] bytes = new byte[1024];
            while (true)
            {
                var byteStream = _stream.Read(bytes, 0, bytes.Length);
                var json = Encoding.ASCII.GetString(bytes, 0, byteStream);
                ListenerReceivedMessageArgs.StreamMessage = json;
                (this as IObservable<ListenerReceivedMessageArgs>).Notify(ListenerReceivedMessageArgs);
            }
        }

        #endregion //Private Methods

        #region IObservable Interface

        void IObservable<ListenerAcceptedClientArgs>.Attach(IObserver<ListenerAcceptedClientArgs> observer)
        {
            ListenerAcceptedClient += observer.OnNotified;
        }

        void IObservable<ListenerAcceptedClientArgs>.Detach(IObserver<ListenerAcceptedClientArgs> observer)
        {
            ListenerAcceptedClient -= observer.OnNotified;
        }

        void IObservable<ListenerAcceptedClientArgs>.Notify(ListenerAcceptedClientArgs eventArgs)
        {
            if (ListenerAcceptedClient != null)
            {
                ListenerAcceptedClient.Invoke(this, eventArgs);
            }
        }

        void IObservable<ListenerReceivedMessageArgs>.Attach(IObserver<ListenerReceivedMessageArgs> observer)
        {
            ListenerReceivedMessage += observer.OnNotified;
        }

        void IObservable<ListenerReceivedMessageArgs>.Detach(IObserver<ListenerReceivedMessageArgs> observer)
        {
            ListenerReceivedMessage -= observer.OnNotified;
        }

        void IObservable<ListenerReceivedMessageArgs>.Notify(ListenerReceivedMessageArgs eventArgs)
        {
            if (ListenerReceivedMessage != null)
            {
                ListenerReceivedMessage.Invoke(this, eventArgs);
            }
        }

        #endregion //IObservable Interface
    }
}

#endif