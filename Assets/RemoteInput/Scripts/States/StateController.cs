using RemoteInput.Core.Network;
using System;

namespace RemoteInput.Core
{
    public enum StateType
    {
        MainMenuState = 0,
        GamePadState
    }

    public class StateController : IMonoNotification , IObservable<GamePadParametersUpdatedArgs> , IObserver<GamePadParametersUpdatedArgs>,
                                                       IObservable<ListenButtonPressedArgs>,       IObserver<ListenButtonPressedArgs>,
                                                       IObservable<ConnectButtonPressedArgs>,      IObserver<ConnectButtonPressedArgs>,
                                                       IObservable<ListenerStartedArgs>,           IObserver<ListenerStartedArgs>,
                                                       IObservable<ClientConnectedArgs>,           IObserver<ClientConnectedArgs>,         
                                                       IObservable<ListenerAcceptedClientArgs>,    IObserver<ListenerAcceptedClientArgs>,  
                                                       IObservable<ListenerReceivedMessageArgs>,   IObserver<ListenerReceivedMessageArgs>,
                                                       IObservable<DisconnectButtonPressedArgs>,   IObserver<DisconnectButtonPressedArgs>
    {
        #region Fields

        private IState _activeState;

        #endregion //Fields

        #region Events

        private event EventHandler<GamePadParametersUpdatedArgs> _gamePadParametersUpdated;
        private event EventHandler<ListenButtonPressedArgs> _listenButtonPressed;
        private event EventHandler<ConnectButtonPressedArgs> _connectButtonPressed;
        private event EventHandler<ListenerStartedArgs> _listenerStarted;
        private event EventHandler<ClientConnectedArgs> _clientConnected;
        private event EventHandler<ListenerAcceptedClientArgs> _listenerAcceptedClient;
        private event EventHandler<ListenerReceivedMessageArgs> _listenerReceivedMessage;
        private event EventHandler<DisconnectButtonPressedArgs> _disconnectButtonPressed;

        #endregion //Events

        #region IMonoNotification Interface

        void IMonoNotification.FixedUpdate()
        {
            if (_activeState != null)
                (_activeState as IMonoNotification).FixedUpdate();
        }

        void IMonoNotification.Update()
        {
            if (_activeState != null)
                (_activeState as IMonoNotification).Update();
        }

        void IMonoNotification.LateUpdate()
        {
            if (_activeState != null)
                (_activeState as IMonoNotification).LateUpdate();
        }

        #endregion //IMonoNotification Interface

        #region Public Methods

        public void Init()
        {
            //Start with default state
            SwitchState(StateType.MainMenuState);
        }

        public void SwitchState(StateType state)
        {
            // End state routine
            if (_activeState != null)
                _activeState.End();

            _activeState = null;

            // Create new state
            switch (state)
            {
                case StateType.MainMenuState:
                    var mainMenuModel = MainMenuFactory.Instance.CreateModel();
                    var mainMenuView = MainMenuFactory.Instance.CreateView();
                    _activeState = MainMenuFactory.Instance.CreateController(mainMenuModel, mainMenuView);

                    (_activeState as IObservable<ListenButtonPressedArgs>).Attach(this);
                    (_activeState as IObservable<ConnectButtonPressedArgs>).Attach(this);

                    (this as IObservable<ListenerStartedArgs>).Attach(_activeState as IObserver<ListenerStartedArgs>);
                    (this as IObservable<ClientConnectedArgs>).Attach(_activeState as IObserver<ClientConnectedArgs>);
                    (this as IObservable<ListenerAcceptedClientArgs>).Attach(_activeState as IObserver<ListenerAcceptedClientArgs>);
                    (this as IObservable<ListenerReceivedMessageArgs>).Attach(_activeState as IObserver<ListenerReceivedMessageArgs>);
                    break;
                case StateType.GamePadState:
                    var gamePadModel = GamePadFactory.Instance.CreateModel();
                    var gamePadView = GamePadFactory.Instance.CreateView();
                    _activeState = GamePadFactory.Instance.CreateController(gamePadModel, gamePadView);

                    (_activeState as IObservable<GamePadParametersUpdatedArgs>).Attach(this);
                    (_activeState as IObservable<DisconnectButtonPressedArgs>).Attach(this);
                    break;
            }

            // Begin state routine
            if (_activeState != null)
                _activeState.Begin();
        }

        #endregion //Public Methods

        #region Private Methods

        #endregion //Private Methods

        #region IObserver Interface

        void IObserver<GamePadParametersUpdatedArgs>.OnNotified(object sender, GamePadParametersUpdatedArgs eventArgs)
        {
            (this as IObservable<GamePadParametersUpdatedArgs>).Notify(eventArgs);
        }

        void IObserver<ListenButtonPressedArgs>.OnNotified(object sender, ListenButtonPressedArgs eventArgs)
        {
            (this as IObservable<ListenButtonPressedArgs>).Notify(eventArgs);
        }

        void IObserver<ConnectButtonPressedArgs>.OnNotified(object sender, ConnectButtonPressedArgs eventArgs)
        {
            (this as IObservable<ConnectButtonPressedArgs>).Notify(eventArgs);
        }

        void IObserver<ListenerStartedArgs>.OnNotified(object sender, ListenerStartedArgs eventArgs)
        {
            (this as IObservable<ListenerStartedArgs>).Notify(eventArgs);
        }

        void IObserver<ClientConnectedArgs>.OnNotified(object sender, ClientConnectedArgs eventArgs)
        {
            (this as IObservable<ClientConnectedArgs>).Notify(eventArgs);
        }

        void IObserver<ListenerAcceptedClientArgs>.OnNotified(object sender, ListenerAcceptedClientArgs eventArgs)
        {
            (this as IObservable<ListenerAcceptedClientArgs>).Notify(eventArgs);
        }

        void IObserver<ListenerReceivedMessageArgs>.OnNotified(object sender, ListenerReceivedMessageArgs eventArgs)
        {
            (this as IObservable<ListenerReceivedMessageArgs>).Notify(eventArgs);
        }

        void IObserver<DisconnectButtonPressedArgs>.OnNotified(object sender, DisconnectButtonPressedArgs eventArgs)
        {
            (this as IObservable<DisconnectButtonPressedArgs>).Notify(eventArgs);
        }

        #endregion //IObserver Interface

        #region IObservable Interface

        void IObservable<GamePadParametersUpdatedArgs>.Attach(IObserver<GamePadParametersUpdatedArgs> observer)
        {
            _gamePadParametersUpdated += observer.OnNotified;
        }

        void IObservable<GamePadParametersUpdatedArgs>.Detach(IObserver<GamePadParametersUpdatedArgs> observer)
        {
            _gamePadParametersUpdated -= observer.OnNotified;
        }

        void IObservable<GamePadParametersUpdatedArgs>.Notify(GamePadParametersUpdatedArgs eventArgs)
        {
            if (_gamePadParametersUpdated != null)
            {
                _gamePadParametersUpdated.Invoke(this, eventArgs);
            }
        }

        void IObservable<ListenButtonPressedArgs>.Attach(IObserver<ListenButtonPressedArgs> observer)
        {
            _listenButtonPressed += observer.OnNotified;
        }

        void IObservable<ListenButtonPressedArgs>.Detach(IObserver<ListenButtonPressedArgs> observer)
        {
            _listenButtonPressed -= observer.OnNotified;
        }

        void IObservable<ListenButtonPressedArgs>.Notify(ListenButtonPressedArgs eventArgs)
        {
            if (_listenButtonPressed != null)
            {
                _listenButtonPressed.Invoke(this, eventArgs);
            }
        }

        void IObservable<ConnectButtonPressedArgs>.Attach(IObserver<ConnectButtonPressedArgs> observer)
        {
            _connectButtonPressed += observer.OnNotified;
        }

        void IObservable<ConnectButtonPressedArgs>.Detach(IObserver<ConnectButtonPressedArgs> observer)
        {
            _connectButtonPressed -= observer.OnNotified;
        }

        void IObservable<ConnectButtonPressedArgs>.Notify(ConnectButtonPressedArgs eventArgs)
        {
            if (_connectButtonPressed != null)
            {
                _connectButtonPressed.Invoke(this, eventArgs);
            }
        }

        void IObservable<ListenerStartedArgs>.Attach(IObserver<ListenerStartedArgs> observer)
        {
            _listenerStarted += observer.OnNotified;
        }

        void IObservable<ListenerStartedArgs>.Detach(IObserver<ListenerStartedArgs> observer)
        {
            _listenerStarted -= observer.OnNotified;
        }

        void IObservable<ListenerStartedArgs>.Notify(ListenerStartedArgs eventArgs)
        {
            if (_listenerStarted != null)
            {
                _listenerStarted.Invoke(this, eventArgs);
            }
        }

        void IObservable<ClientConnectedArgs>.Attach(IObserver<ClientConnectedArgs> observer)
        {
            _clientConnected += observer.OnNotified;
        }

        void IObservable<ClientConnectedArgs>.Detach(IObserver<ClientConnectedArgs> observer)
        {
            _clientConnected -= observer.OnNotified;
        }

        void IObservable<ClientConnectedArgs>.Notify(ClientConnectedArgs eventArgs)
        {
            if (_clientConnected != null)
            {
                _clientConnected.Invoke(this, eventArgs);
            }
        }

        void IObservable<ListenerAcceptedClientArgs>.Attach(IObserver<ListenerAcceptedClientArgs> observer)
        {
            _listenerAcceptedClient += observer.OnNotified;
        }

        void IObservable<ListenerAcceptedClientArgs>.Detach(IObserver<ListenerAcceptedClientArgs> observer)
        {
            _listenerAcceptedClient -= observer.OnNotified;
        }

        void IObservable<ListenerAcceptedClientArgs>.Notify(ListenerAcceptedClientArgs eventArgs)
        {
            if (_listenerAcceptedClient != null)
            {
                _listenerAcceptedClient.Invoke(this, eventArgs);
            }
        }

        void IObservable<ListenerReceivedMessageArgs>.Attach(IObserver<ListenerReceivedMessageArgs> observer)
        {
            _listenerReceivedMessage += observer.OnNotified;
        }

        void IObservable<ListenerReceivedMessageArgs>.Detach(IObserver<ListenerReceivedMessageArgs> observer)
        {
            _listenerReceivedMessage -= observer.OnNotified;
        }

        void IObservable<ListenerReceivedMessageArgs>.Notify(ListenerReceivedMessageArgs eventArgs)
        {
            if (_listenerReceivedMessage != null)
            {
                _listenerReceivedMessage.Invoke(this, eventArgs);
            }
        }

        void IObservable<DisconnectButtonPressedArgs>.Attach(IObserver<DisconnectButtonPressedArgs> observer)
        {
            _disconnectButtonPressed += observer.OnNotified;
        }

        void IObservable<DisconnectButtonPressedArgs>.Detach(IObserver<DisconnectButtonPressedArgs> observer)
        {
            _disconnectButtonPressed -= observer.OnNotified;
        }

        void IObservable<DisconnectButtonPressedArgs>.Notify(DisconnectButtonPressedArgs eventArgs)
        {
            if (_disconnectButtonPressed != null)
            {
                _disconnectButtonPressed.Invoke(this, eventArgs);
            }
        }

        #endregion //IObservable Interface
    }
}
