using UnityEngine;

namespace RemoteInput.Core
{
    public class GamePad
    {
        #region Fields

        [SerializeField] private Vector3 _eulerAngles;
        public Vector3 EulerAngles { get { return _eulerAngles; } }
        
        [SerializeField] private Vector3 _acceleration;
        public Vector3 Acceleration { get { return _acceleration; } }
        
        [SerializeField] private Vector2 _joystick;
        public Vector2 Joystick { get { return _joystick; } }
        
        [SerializeField] private bool _buttonA;
        public bool ButtonA { get { return _buttonA; } }
        
        [SerializeField] private bool _buttonB;
        public bool ButtonB { get { return _buttonB; } }

        #endregion //Fields

        #region Public Methods

        public void Init()
        {
            Input.gyro.enabled = true;
        }

        public void SetData(Vector2 joystick, bool buttonA, bool buttonB)
        {
            RefreshSensorDatas();

            _joystick = joystick;
            _buttonA = buttonA;
            _buttonB = buttonB;
        }

        public override string ToString()
        {
            return "Joystick: " + Joystick.ToString()
                    + " - "
                    + "Button A: " + (ButtonA ? "Pressed" : "")
                    + " - "
                    + "Button B: " + (ButtonB ? "Pressed" : "");
        }

        #endregion //Public Methods

        #region Private Methods

        private void RefreshSensorDatas()
        {
            _eulerAngles = Input.gyro.attitude.eulerAngles;
            _acceleration = Input.acceleration;
        }

        #endregion //Private Methods
    }
}