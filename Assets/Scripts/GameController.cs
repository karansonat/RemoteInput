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
                SubscribeHostEvents();
        }

        #endregion //Unity Methods

        #region Private Methods

        private void SubscribeHostEvents()
        {
            _inputController.ReadyForConnection += RemoteInputController_ReadyForConnection;
            _inputController.ControllerConnected += RemoteInputController_ControllerConnected;
            _inputController.InputDataReceived += RemoteInputController_InputDataReceived;
        }

        private void ApplyApplicationConfiguration()
        {
            Application.runInBackground = true;
            Application.targetFrameRate = 60;
        }

        #endregion //Private Methods

        #region RemoteInputController Host Events

        private void RemoteInputController_ReadyForConnection(object sender, ListenerStartedArgs e)
        {
        }

        private void RemoteInputController_ControllerConnected(object sender, ListenerAcceptedClientArgs e)
        {
        }

        private void RemoteInputController_InputDataReceived(object sender, ListenerReceivedMessageArgs e)
        {
            Debug.Log(e.StreamMessage);
        }

        #endregion //RemoteInputController Host Events
    }
}