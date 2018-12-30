using UnityEngine;

namespace RemoteInput.Core
{
    public class GamePad
    {
        #region Fields

        [SerializeField] private Vector3 _rotationRateUnbiased;
        public Vector3 RotationRateUnbiased { get { return _rotationRateUnbiased; } }
        
        [SerializeField] private Vector3 _acceleration;
        public Vector3 Acceleration { get { return _acceleration; } }
        
        [SerializeField] private Vector3 _inputVector;
        public Vector3 InputVector { get { return _inputVector; } }
        
        [SerializeField] private bool _buttonA;
        public bool ButtonA { get { return _buttonA; } }

        #endregion //Fields

        #region Public Methods

        public void Init()
        {
            Input.gyro.enabled = true;
        }

        public void SetData(Vector3 inputVector, bool buttonA)
        {
            RefreshSensorDatas();

            _inputVector = inputVector;
            _buttonA = buttonA;
        }

        #endregion //Public Methods

        #region Private Methods

        private void RefreshSensorDatas()
        {
            _rotationRateUnbiased = Input.gyro.rotationRateUnbiased;
            _acceleration = Input.acceleration;
        }

        #endregion //Private Methods
    }
}