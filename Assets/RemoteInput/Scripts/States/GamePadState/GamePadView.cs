using System;
using UnityEngine;
using UnityEngine.UI;

namespace RemoteInput.Core
{
    public class GamePadView : MonoBehaviour, IObservable<DisconnectButtonPressedArgs>
    {
        #region Fields

        [SerializeField] private VirtualJoystick _joystick;
        [SerializeField] private Button _buttonA;
        [SerializeField] private Button _buttonDisconnect;

        public Vector3 InputVector { get; private set; }
        public bool ButtonAPressed { get; private set; }

        private bool _initialized;

        #endregion //Fields

        #region Events

        private event EventHandler<DisconnectButtonPressedArgs> _disconnectButtonPressed;

        #endregion

        #region Public Methods

        public void Init()
        {
            _buttonA.onClick.RemoveAllListeners();
            _buttonA.onClick.AddListener(OnButtonAPressed);

            _buttonDisconnect.onClick.RemoveAllListeners();
            _buttonDisconnect.onClick.AddListener(OnButtonDisconnectPressed);

            _initialized = true;
        }

        public void Update()
        {
            if (_initialized)
                OnJoystickUpdated();
        }

        public void Reset()
        {
            ButtonAPressed = false;
        }

        #endregion //Public Methods

        #region Private Methods

        private void OnButtonAPressed()
        {
            ButtonAPressed = true;
        }

        private void OnButtonDisconnectPressed()
        {
            (this as IObservable<DisconnectButtonPressedArgs>).Notify(null);
        }

        private void OnJoystickUpdated()
        {
            InputVector = _joystick.InputVector;
        }

        #endregion //Private Methods

        #region IObservable Interface

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