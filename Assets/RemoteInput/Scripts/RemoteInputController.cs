using System;
using RemoteInput.Core.Network;
using UnityEngine;

namespace RemoteInput.Core
{
    public enum RemoteControllerMode
    {
        Host,
        Controller
    }

    public class RemoteInputController : MonoBehaviour, IObserver<ListenerStartedArgs>,         IObservable<ListenerStartedArgs>,
                                                        IObserver<ClientConnectedArgs>,         IObservable<ClientConnectedArgs>,
                                                        IObserver<ListenerAcceptedClientArgs>,  IObservable<ListenerAcceptedClientArgs>,
                                                        IObserver<ListenerReceivedMessageArgs>, IObservable<ListenerReceivedMessageArgs>,
                                                        IObserver<GamePadParametersUpdatedArgs>,
                                                        IObserver<ListenButtonPressedArgs>,
                                                        IObserver<ConnectButtonPressedArgs>,
                                                        IObserver<DisconnectButtonPressedArgs>
    {
        #region Fields

        [SerializeField] private RemoteControllerMode _mode;
        public RemoteControllerMode Mode
        {
            get { return _mode; }
        }

        public static RemoteInputController Instance { get; private set; }
        public string LocalEndPoint { get; private set; }

        private NetworkController _networkController;
        private StateController _stateController;
        private InputDataReceivedArgs _inputDataReceivedArgs;

        #endregion //Fields

        #region Events

        public event EventHandler<ListenerStartedArgs> ReadyForConnection;
        public event EventHandler<ClientConnectedArgs> ConnectedToHost;
        public event EventHandler<ListenerAcceptedClientArgs> ControllerConnected;
        public event EventHandler<InputDataReceivedArgs> InputDataReceived;
        private event EventHandler<ListenerReceivedMessageArgs> _listenerReceivedMessage;

        #endregion

        #region Unity Methods

        void Awake()
        {
            #region Singleton

            if (Instance == null)
            {
                Instance = this;
            }
            else if (Instance != this)
            {
                Destroy(Instance.gameObject);
            }

            #endregion //Singleton

            _networkController = new NetworkController();
            _stateController = new StateController();
            _inputDataReceivedArgs = new InputDataReceivedArgs();

            _stateController.Init();
            SubscribeEvents();
        }

        void FixedUpdate()
        {
            if (_stateController != null)
                (_stateController as IMonoNotification).FixedUpdate();
        }

        void Update()
        {
            if (_stateController != null)
                (_stateController as IMonoNotification).Update();
        }

        void LateUpdate()
        {
            if (_stateController != null)
                (_stateController as IMonoNotification).LateUpdate();
        }

        #endregion Unity Methods

        #region Public Methods

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

            (_stateController as IObservable<GamePadParametersUpdatedArgs>).Attach(this);
            (_stateController as IObservable<ListenButtonPressedArgs>).Attach(this);
            (_stateController as IObservable<ConnectButtonPressedArgs>).Attach(this);
            (_stateController as IObservable<DisconnectButtonPressedArgs>).Attach(this);

            (this as IObservable<ListenerStartedArgs>).Attach(_stateController);
            (this as IObservable<ClientConnectedArgs>).Attach(_stateController);
            (this as IObservable<ListenerAcceptedClientArgs>).Attach(_stateController);
            (this as IObservable<ListenerReceivedMessageArgs>).Attach(_stateController);
        }

        #endregion

        #region IObserver Interface

        void IObserver<ListenerStartedArgs>.OnNotified(object sender, ListenerStartedArgs eventArgs)
        {
            LocalEndPoint = eventArgs.LocalEndPoint;

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

            _stateController.SwitchState(StateType.GamePadState);
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
            if (_listenerReceivedMessage != null)
            {
                _listenerReceivedMessage.Invoke(this, eventArgs);
            }

            var gamepad = JsonUtility.FromJson<GamePad>(eventArgs.StreamMessage);
            _inputDataReceivedArgs.GamePadData = gamepad;

            if (InputDataReceived != null)
            {
                InputDataReceived.Invoke(this, _inputDataReceivedArgs);
            }
        }

        void IObserver<GamePadParametersUpdatedArgs>.OnNotified(object sender, GamePadParametersUpdatedArgs eventArgs)
        {
            _networkController.SendData(eventArgs.GamePad);
        }

        void IObserver<ListenButtonPressedArgs>.OnNotified(object sender, ListenButtonPressedArgs eventArgs)
        {
            _networkController.Listen();
        }

        void IObserver<ConnectButtonPressedArgs>.OnNotified(object sender, ConnectButtonPressedArgs eventArgs)
        {
            _networkController.Connect(eventArgs.IpAddress);
        }

        void IObserver<DisconnectButtonPressedArgs>.OnNotified(object sender, DisconnectButtonPressedArgs eventArgs)
        {
            _networkController.Disconnect();
        }

        #endregion

        #region IObservable Interface

        void IObservable<ListenerStartedArgs>.Attach(IObserver<ListenerStartedArgs> observer)
        {
            ReadyForConnection += observer.OnNotified;
        }

        void IObservable<ListenerStartedArgs>.Detach(IObserver<ListenerStartedArgs> observer)
        {
            ReadyForConnection -= observer.OnNotified;
        }

        void IObservable<ListenerStartedArgs>.Notify(ListenerStartedArgs eventArgs)
        {
            if (ReadyForConnection != null)
            {
                ReadyForConnection.Invoke(this, eventArgs);
            }
        }

        void IObservable<ClientConnectedArgs>.Attach(IObserver<ClientConnectedArgs> observer)
        {
            ConnectedToHost += observer.OnNotified;
        }

        void IObservable<ClientConnectedArgs>.Detach(IObserver<ClientConnectedArgs> observer)
        {
            ConnectedToHost -= observer.OnNotified;
        }

        void IObservable<ClientConnectedArgs>.Notify(ClientConnectedArgs eventArgs)
        {
            if (ConnectedToHost != null)
            {
                ConnectedToHost.Invoke(this, eventArgs);
            }
        }

        void IObservable<ListenerAcceptedClientArgs>.Attach(IObserver<ListenerAcceptedClientArgs> observer)
        {
            ControllerConnected += observer.OnNotified;
        }

        void IObservable<ListenerAcceptedClientArgs>.Detach(IObserver<ListenerAcceptedClientArgs> observer)
        {
            ControllerConnected -= observer.OnNotified;
        }

        void IObservable<ListenerAcceptedClientArgs>.Notify(ListenerAcceptedClientArgs eventArgs)
        {
            if (ControllerConnected != null)
            {
                ControllerConnected.Invoke(this, eventArgs);
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

        #endregion //IObservable Interface
    }
}
