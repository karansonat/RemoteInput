using System;
using Game.Core;
using RemoteInput.Core.Network;

namespace RemoteInput.Core
{
    public class RemoteInputController : IMonoNotification, IObserver<ListenerStartedArgs>,
                                                            IObserver<ClientConnectedArgs>,
                                                            IObserver<ListenerAcceptedClientArgs>,
                                                            IObserver<ListenerReceivedMessageArgs>,
                                                            IObserver<GamePadParametersUpdatedArgs>
    {
        #region Fields

        private NetworkController _networkController;
        private GamePadController _gamePadController;

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

        #region IMonoNotification

        void IMonoNotification.FixedUpdate()
        {
        }

        void IMonoNotification.Update()
        {
            if (_gamePadController != null)
                (_gamePadController as IMonoNotification).Update();
        }

        void IMonoNotification.LateUpdate()
        {
            if (_gamePadController != null)
                (_gamePadController as IMonoNotification).LateUpdate();
        }

        #endregion //IMonoNotification

        #region Public Methods

        public void Connect(string ipAddress)
        {
            _networkController.Connect(ipAddress);
        }

        public void Listen()
        {
            _networkController.Listen();
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

        private void ConfigureGamePadController()
        {
            var model = GamePadFactory.Instance.CreateGamePadModel();
            var view = GamePadFactory.Instance.CreateGamePadView();
            _gamePadController = GamePadFactory.Instance.CreateGamePadController(model, view);
            _gamePadController.Init();

            (_gamePadController as IObservable<GamePadParametersUpdatedArgs>).Attach(this as IObserver<GamePadParametersUpdatedArgs>);
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

            ConfigureGamePadController();
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

        void IObserver<GamePadParametersUpdatedArgs>.OnNotified(object sender, GamePadParametersUpdatedArgs eventArgs)
        {
            _networkController.SendData(eventArgs.GamePad);
        }

        #endregion
    }
}
