using System;
using UnityEngine;
using UnityEngine.UI;

namespace RemoteInput.Core
{
    public class MainMenuView : MonoBehaviour, IObservable<ListenButtonPressedArgs>,
                                               IObservable<ConnectButtonPressedArgs>
    {
        #region Fields

        [SerializeField] private Button _listenButton;
        [SerializeField] private Button _connectButton;
        [SerializeField] private Text _ipAddressText;
        [SerializeField] private Text _statusText;

        #endregion //Fields

        #region Events

        private event EventHandler<ListenButtonPressedArgs> _listenButtonPressed;
        private event EventHandler<ConnectButtonPressedArgs> _connectButtonPressed;

        #endregion //Events

        #region Public Methods

        public void Init()
        {
            _listenButton.onClick.RemoveAllListeners();
            _listenButton.onClick.AddListener(OnListenButtonPressed);

            _connectButton.onClick.RemoveAllListeners();
            _connectButton.onClick.AddListener(OnConnectButtonPressed);
        }

        public void UpdateStatus(string statusText)
        {
            _statusText.text = statusText;
        }

        #endregion

        #region Private Methods

        private void OnListenButtonPressed()
        {
            (this as IObservable<ListenButtonPressedArgs>).Notify(null);
        }

        private void OnConnectButtonPressed()
        {
            (this as IObservable<ConnectButtonPressedArgs>).Notify(new ConnectButtonPressedArgs
            {
                IpAddress = _ipAddressText.text
            });
        }

        #endregion //Private Methods

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
