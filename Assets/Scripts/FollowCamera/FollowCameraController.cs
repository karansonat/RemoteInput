using UnityEngine;

namespace Game.Core
{
    public class FollowCameraController
    {
        #region Fields
        private FollowCamera _model;

        private Transform _target;
        private Transform _camera;
        private Vector3 _desiredPosition;
        private float _smoothSpeed = 7.5f;
        private float _distance = 5.0f;
        private float _yOffSet = 3.5f;

        #endregion //Fields

        #region Contructor

        public FollowCameraController(FollowCamera model)
        {
            _model = model;
        }

        #endregion //Contructor

        #region Public Methods

        public void Initialize(Transform targetTransform, Transform cameraTransform)
        {
            _target = targetTransform;
            _camera = cameraTransform;
        }

        public void Follow()
        {
            if (_camera != null && _target != null)
            {
                _desiredPosition = _target.position + _model.GetFollowOffset();
                _camera.position = Vector3.Lerp(_camera.position, _desiredPosition, _smoothSpeed * Time.deltaTime);
                _camera.LookAt(_target.position + Vector3.up);
            }
        }

        #endregion //Public Methods
    }
}