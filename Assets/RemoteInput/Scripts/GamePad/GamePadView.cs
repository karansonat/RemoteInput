using UnityEngine;
using UnityEngine.UI;

namespace RemoteInput.Core
{
    public class GamePadView : MonoBehaviour
    {
        #region Fields

        [SerializeField] private VirtualJoystick _joystick;
        [SerializeField] private Button _buttonA;
        [SerializeField] private Button _buttonB;
        [SerializeField] private Button _buttonDisconnect;

        public Vector2 Joystick { get; private set; }
        public bool ButtonAPressed { get; private set; }
        public bool ButtonBPressed { get; private set; }
        public bool ButtonDisconnectPressed { get; private set; }

        private bool _initialized;

        #endregion //Fields

        #region Public Methods

        public void Init()
        {
            _buttonA.onClick.RemoveAllListeners();
            _buttonA.onClick.AddListener(OnButtonAPressed);

            _buttonB.onClick.RemoveAllListeners();
            _buttonB.onClick.AddListener(OnButtonBPressed);

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
            ButtonBPressed = false;
            ButtonDisconnectPressed = false;
        }

        #endregion //Public Methods

        #region Private Methods

        private void OnButtonAPressed()
        {
            ButtonAPressed = true;
        }

        private void OnButtonBPressed()
        {
            ButtonBPressed = true;
        }

        private void OnButtonDisconnectPressed()
        {
            ButtonDisconnectPressed = true;
        }

        private void OnJoystickUpdated()
        {
            Joystick = new Vector2(_joystick.Horizontal, _joystick.Vertical);
        }

        #endregion //Private Methods
    }
}