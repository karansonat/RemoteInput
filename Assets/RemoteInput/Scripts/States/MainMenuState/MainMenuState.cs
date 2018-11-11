using RemoteInput.Core.Network;
using System;
using UnityEngine;

namespace RemoteInput.Core
{
    public class MainMenuState : IState, IMonoNotification,
                                 IObservable<ListenButtonPressedArgs>,  IObserver<ListenButtonPressedArgs>,
                                 IObservable<ConnectButtonPressedArgs>, IObserver<ConnectButtonPressedArgs>,
                                                                        IObserver<ListenerStartedArgs>,
                                                                        IObserver<ClientConnectedArgs>,
                                                                        IObserver<ListenerAcceptedClientArgs>,
                                                                        IObserver<ListenerReceivedMessageArgs>
    {
        #region Fields

        private MainMenu _model;
        private MainMenuView _view;

        #endregion //Fields

        #region Events

        private event EventHandler<ListenButtonPressedArgs> _listenButtonPressed;
        private event EventHandler<ConnectButtonPressedArgs> _connectButtonPressed;

        #endregion //Events

        #region Constructor

        public MainMenuState(MainMenu model, MainMenuView view)
        {
            _model = model;
            _view = view;
        }

        #endregion //Constructor

        #region IState Interface

        void IState.Begin()
        {
            Init();
            SubscribeEvents();
        }

        void IState.End()
        {
            UnsubscribeEvents();

            UnityEngine.Object.Destroy(_view.gameObject);
            UnityEngine.Object.Destroy(_model);
        }

        #endregion //IState Interface

        #region IMonoNotification Interface

        void IMonoNotification.FixedUpdate()
        {
        }

        void IMonoNotification.LateUpdate()
        {
        }

        void IMonoNotification.Update()
        {
        }

        #endregion //IMonoNotification Interface

        #region Private Methods

        private void Init()
        {
#if !UNITY_EDITOR && (UNITY_IOS || UNITY_ANDROID)
            Screen.orientation = ScreenOrientation.Portrait;
#endif

            _view.Init();
        }

        private void SubscribeEvents()
        {
            (_view as IObservable<ListenButtonPressedArgs>).Attach(this);
            (_view as IObservable<ConnectButtonPressedArgs>).Attach(this);
        }

        private void UnsubscribeEvents()
        {
            (_view as IObservable<ListenButtonPressedArgs>).Detach(this);
            (_view as IObservable<ConnectButtonPressedArgs>).Detach(this);
        }

        #endregion //Private Methods

        #region IObserver Interface

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
            var message = string.Format("Ready for connection at {0}", eventArgs.LocalEndPoint);
            _view.UpdateStatus(message);
        }

        void IObserver<ClientConnectedArgs>.OnNotified(object sender, ClientConnectedArgs eventArgs)
        {
            var message = string.Format("Controller connected to host at {0}", eventArgs.RemoteEndPoint);
            _view.UpdateStatus(message);
        }

        void IObserver<ListenerAcceptedClientArgs>.OnNotified(object sender, ListenerAcceptedClientArgs eventArgs)
        {
            UnityMainThreadDispatcher.Instance.Enqueue(() =>
            {
                var message = string.Format("Remote Controller Connected from {0}", eventArgs.ClientEndPoint);
                _view.UpdateStatus(message);
                _view.gameObject.SetActive(false);
            });
        }

        void IObserver<ListenerReceivedMessageArgs>.OnNotified(object sender, ListenerReceivedMessageArgs eventArgs)
        {
            UnityMainThreadDispatcher.Instance.Enqueue(() =>
            {
                string message = "";

                try
                {
                    var gamepad = JsonUtility.FromJson<GamePad>(eventArgs.StreamMessage);
                    message = "Joystick: " + gamepad.InputVector.ToString()
                    + Environment.NewLine
                    + "Button A: " + (gamepad.ButtonA ? "Pressed" : "")
                    + Environment.NewLine
                    + "Button B: " + (gamepad.ButtonB ? "Pressed" : "");
                }
                catch (Exception)
                {
                    message = "Shitty Json";
                }

                _view.UpdateStatus(message);
            });
        }

        #endregion //IObserver Interface

        #region IObservable Interface

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

        #endregion //IObservable Interface
    }
}
