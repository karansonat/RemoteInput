namespace RemoteInput.Core.Network
{
    public class NetworkController : IObservable<ListenerStartedArgs>,         
                                     IObservable<ClientConnectedArgs>,         
                                     IObservable<ListenerAcceptedClientArgs>,  IObserver<ListenerAcceptedClientArgs>,
                                     IObservable<ListenerReceivedMessageArgs>, IObserver<ListenerReceivedMessageArgs>
    {
        #region Fields

        protected const int PORT = 56000;
        protected INetworkStrategy _networkStrategy;
        
        //Events
        private event System.EventHandler<ListenerStartedArgs> ListenerStarted;
        private event System.EventHandler<ClientConnectedArgs> ClientConnected;
        private event System.EventHandler<ListenerAcceptedClientArgs> ListenerAcceptedClient;
        private event System.EventHandler<ListenerReceivedMessageArgs> ListenerReceivedMessage;
        
        //Args
        protected ListenerStartedArgs ListenerStartedArgs;
        protected ClientConnectedArgs ClientConnectedArgs;

        #endregion //Fields

        #region Public Methods

        public virtual void Listen()
        {
            var localEndPoint = _networkStrategy.Listen(PORT);
            ListenerStartedArgs.LocalEndPoint = localEndPoint.ToString();
            SubscribeHostEvents();

            (this as IObservable<ListenerStartedArgs>).Notify(ListenerStartedArgs);
        }

        public virtual void Connect(string ipAddress)
        {
            var remoteEndPoint = _networkStrategy.Connect(ipAddress, PORT);
            ClientConnectedArgs.RemoteEndPoint = remoteEndPoint.ToString();
            (this as IObservable<ClientConnectedArgs>).Notify(ClientConnectedArgs);
        }

        public virtual void SendData(object data)
        {
            _networkStrategy.SendData(data);
        }

        public virtual void Disconnect()
        {
            _networkStrategy.Disconnect();
        }

        public virtual void Suspend()
        {
            _networkStrategy.Suspend();
        }

        #endregion //Public Methods

        #region Constructor

        public NetworkController()
        {
            _networkStrategy = NetworkStrategyFactory.Instance.CreateDotNetworkStrategy();

//#if NETFX_CORE
//            _networkStrategy = NetworkStrategyFactory.Instance.CreateUWPworkStrategy();
//#else
//            _networkStrategy = NetworkStrategyFactory.Instance.CreateDotNetworkStrategy();
//#endif
            ListenerStartedArgs = new ListenerStartedArgs();
            ClientConnectedArgs = new ClientConnectedArgs();
        }

        #endregion //Constructor

        #region Private Methods

        private void SubscribeHostEvents()
        {
            (_networkStrategy as IObservable<ListenerAcceptedClientArgs>).Attach(this as IObserver<ListenerAcceptedClientArgs>);
            (_networkStrategy as IObservable<ListenerReceivedMessageArgs>).Attach(this as IObserver<ListenerReceivedMessageArgs>);
        }

        #endregion

        #region IObservable Interface

        void IObservable<ListenerStartedArgs>.Attach(IObserver<ListenerStartedArgs> observer)
        {
            ListenerStarted += observer.OnNotified;
        }

        void IObservable<ListenerStartedArgs>.Detach(IObserver<ListenerStartedArgs> observer)
        {
            ListenerStarted -= observer.OnNotified;
        }

        void IObservable<ListenerStartedArgs>.Notify(ListenerStartedArgs eventArgs)
        {
            if (ListenerStarted != null)
            {
                ListenerStarted.Invoke(this, eventArgs);
            }
        }
        
        void IObservable<ClientConnectedArgs>.Attach(IObserver<ClientConnectedArgs> observer)
        {
            ClientConnected += observer.OnNotified;
        }

        void IObservable<ClientConnectedArgs>.Detach(IObserver<ClientConnectedArgs> observer)
        {
            ClientConnected -= observer.OnNotified;
        }

        void IObservable<ClientConnectedArgs>.Notify(ClientConnectedArgs eventArgs)
        {
            if (ClientConnected != null)
            {
                ClientConnected.Invoke(this, eventArgs);
            }
        }

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

        #region IObserver Interface

        void IObserver<ListenerAcceptedClientArgs>.OnNotified(object sender, ListenerAcceptedClientArgs eventArgs)
        {
            (this as IObservable<ListenerAcceptedClientArgs>).Notify(eventArgs);
        }

        void IObserver<ListenerReceivedMessageArgs>.OnNotified(object sender, ListenerReceivedMessageArgs eventArgs)
        {
            (this as IObservable<ListenerReceivedMessageArgs>).Notify(eventArgs);
        }

        #endregion
    }
}
