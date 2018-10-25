using System;
using RemoteInput.Core.Network;

namespace RemoteInput.Core
{
    public class RemoteInputController : IObserver<ListenerStartedArgs>,
                                         IObserver<ClientConnectedArgs>,
                                         IObserver<ListenerAcceptedClientArgs>,
                                         IObserver<ListenerReceivedMessageArgs>
    {
        #region Fields

        private NetworkController _networkController;
        public InputData InputData { get; private set;}

        #endregion //Fields

        #region Events

        public event EventHandler<ListenerStartedArgs> ReadyForConnection;
        public event EventHandler<ClientConnectedArgs> ConnectedToHost;
        public event EventHandler<ListenerAcceptedClientArgs> ControllerConnected;
        public event EventHandler<ListenerReceivedMessageArgs> InputDataReceived;

        #endregion

        #region Constructor

        public RemoteInputController()
        {
            _networkController = new NetworkController();

            SubscribeEvents();
        }

        #endregion

        #region Public Methods

        public void Connect(string ipAddress)
        {
            _networkController.Connect(ipAddress);
        }

        public void Listen()
        {
            _networkController.Listen();
        }

        //TODO: Delete this
        public void SendData(object data)
        {
            _networkController.SendData(data);
        }

        #endregion //Public Methods

        #region Private Methods

        private void SubscribeEvents()
        {
            (_networkController as IObservable<ListenerStartedArgs>).Attach(this as IObserver<ListenerStartedArgs>);
            (_networkController as IObservable<ClientConnectedArgs>).Attach(this as IObserver<ClientConnectedArgs>);
            (_networkController as IObservable<ListenerAcceptedClientArgs>).Attach(this as IObserver<ListenerAcceptedClientArgs>);
            (_networkController as IObservable<ListenerReceivedMessageArgs>).Attach(this as IObserver<ListenerReceivedMessageArgs>);
        }

        #endregion

        #region IObserver Interface

        void IObserver<ListenerStartedArgs>.OnNotified(object sender, ListenerStartedArgs eventArgs)
        {
            if (ReadyForConnection != null)
            {
                ReadyForConnection.Invoke(this, eventArgs);
            }
        }

        void IObserver<ClientConnectedArgs>.OnNotified(object sender, ClientConnectedArgs eventArgs)
        {
            if (ConnectedToHost != null)
            {
                ConnectedToHost.Invoke(this, eventArgs);
            }
        }

        void IObserver<ListenerAcceptedClientArgs>.OnNotified(object sender, ListenerAcceptedClientArgs eventArgs)
        {
            if (ControllerConnected != null)
            {
                ControllerConnected.Invoke(this, eventArgs);
            }
        }

        void IObserver<ListenerReceivedMessageArgs>.OnNotified(object sender, ListenerReceivedMessageArgs eventArgs)
        {
            if (InputDataReceived != null)
            {
                InputDataReceived.Invoke(this, eventArgs);
            }
        }

        #endregion
    }
}
