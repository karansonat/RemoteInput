using MalbersAnimations;
using RemoteInput.Core;
using RemoteInput.Core.Network;
using UnityEngine;

namespace Game.Core
{
    public class GameController : MonoBehaviour
    {
        #region Fields

        public static GameController Instance { get; private set; }

        [SerializeField] private RemoteInputController _inputController;
        [SerializeField] private Animal _dragon;

        private GamePad _gamepad;
        private FollowCameraController _followCameraController;

        #endregion //Fields

        #region Unity Methods

        private void Awake()
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

            ApplyApplicationConfiguration();
        }

        private void Start()
        {
            if (_inputController.Mode == RemoteControllerMode.Host)
            {
                SubscribeHostEvents();
                ConfigureFollowCamera();
                _dragon.Speed2 = true;
            }
        }

        private void FixedUpdate()
        {
            if (_dragon != null && _gamepad != null)
            {
                _dragon.Move(_gamepad.InputVector);

                if (_followCameraController != null)
                    _followCameraController.Follow();
            }
        }

        private void Update()
        {
            if (_gamepad == null)
                return;

            if (_gamepad.ButtonA)
            {
                _dragon.SetJump();
            }

            if (_gamepad.ButtonB)
            {
                _dragon.SetAttack();
            }
        }

        #endregion //Unity Methods

        #region Private Methods

        private void SubscribeHostEvents()
        {
            _inputController.ReadyForConnection += RemoteInputController_ReadyForConnection;
            _inputController.ControllerConnected += RemoteInputController_ControllerConnected;
            _inputController.InputDataReceived += _inputController_InputDataReceived;
        }

        private void ApplyApplicationConfiguration()
        {
            Application.runInBackground = true;
            Application.targetFrameRate = 60;
        }

        private void ConfigureFollowCamera()
        {
            _followCameraController = FollowCameraFactory.Instance.CreateController();
            _followCameraController.Initialize(_dragon.transform, Camera.main.transform);
        }

        #endregion //Private Methods

        #region RemoteInputController Host Events

        private void RemoteInputController_ReadyForConnection(object sender, ListenerStartedArgs e)
        {
        }

        private void RemoteInputController_ControllerConnected(object sender, ListenerAcceptedClientArgs e)
        {
        }

        private void _inputController_InputDataReceived(object sender, InputDataReceivedArgs e)
        {
            _gamepad = e.GamePadData;
        }

        #endregion //RemoteInputController Host Events
    }
}