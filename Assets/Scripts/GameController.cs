using RemoteInput.Core;
using RemoteInput.Core.Network;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Core
{
    public class GameController : MonoBehaviour
    {
        #region Fields

        private RemoteInputController _inputController;

        [SerializeField] private Button _listenButton;
        [SerializeField] private Button _connectButton;
        [SerializeField] private Text _ipAddressText;
        [SerializeField] private Text _statusText;
        private bool _sendData;

        public static GameController Instance { get; private set; }

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

            Application.runInBackground = true;

            _inputController = new RemoteInputController();

            _listenButton.onClick.AddListener(() =>
            {
                SubscribeHostEvents();
                _inputController.Listen();
            });

            _connectButton.onClick.AddListener(() =>
            {
                SubscribeControllerEvents();
                _inputController.Connect(_ipAddressText.text);
            });
        }

        private void Update()
        {
            //Dummy data
            if (_sendData)
            {
                var data = new InputData {EulerAngles = Input.gyro.attitude.eulerAngles, Acceleration = Input.acceleration };
                _inputController.SendData(data);
            }
        }

        #endregion //Unity Methods

        #region Private Methods

        private void SubscribeHostEvents()
        {
            _inputController.ReadyForConnection += RemoteInputController_ReadyForConnection;
            _inputController.ControllerConnected += RemoteInputController_ControllerConnected;
            _inputController.InputDataReceived += RemoteInputController_InputDataReceived;
        }

        private void SubscribeControllerEvents()
        {
            _inputController.ConnectedToHost += RemoteInputController_ConnectedToHost;
        }

        #endregion //Private Methods

        #region RemoteInputController Host Events

        private void RemoteInputController_ReadyForConnection(object sender, ListenerStartedArgs e)
        {
            var message = string.Format("Ready for connection at {0}", e.LocalEndPoint);
            Debug.Log(message);
            _statusText.text = message;
        }

        private void RemoteInputController_ControllerConnected(object sender, ListenerAcceptedClientArgs e)
        {
            UnityMainThreadDispatcher.Instance.Enqueue(() =>
            {
                var message = string.Format("Remote Controller Connected from {0}", e.ClientEndPoint);
                Debug.Log(message);
                _statusText.text = message;
            });
        }

        private void RemoteInputController_InputDataReceived(object sender, ListenerReceivedMessageArgs e)
        {
            UnityMainThreadDispatcher.Instance.Enqueue(() =>
            {
                var inputData = e.StreamMessage as InputData;
                var message = string.Format("EulerAngles: {0}, Acceleration: {1}", inputData.EulerAngles, inputData.Acceleration);
                Debug.Log(message);
                _statusText.text = message;
            });
        }

        #endregion //RemoteInputController Host Events

        #region RemoteInputController Controller Events

        private void RemoteInputController_ConnectedToHost(object sender, ClientConnectedArgs e)
        {
            var message = string.Format("Controller connected to host at {0}", e.RemoteEndPoint);
            Debug.Log(message);
            _statusText.text = message;

            _sendData = true;
            //Enabled gyroscope
            Input.gyro.enabled = true;
        }

        #endregion //RemoteInputController Controller Events
    }
}