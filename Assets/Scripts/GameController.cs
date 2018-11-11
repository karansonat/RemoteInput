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

            ApplyApplicationConfiguration();

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
            (_inputController as IMonoNotification).Update();
        }

        private void LateUpdate()
        {
            (_inputController as IMonoNotification).LateUpdate();
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

        private void ApplyApplicationConfiguration()
        {
            Application.runInBackground = true;
            Application.targetFrameRate = 60;
        }

        private void BeginSendData()
        {
            _sendData = true;
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
                string message = "";
                try
                {
                    var gamepad = JsonUtility.FromJson<GamePad>(e.StreamMessage);
                    message = "Joystick: " + gamepad.Joystick.ToString()
                    + System.Environment.NewLine
                    + "Button A: " + (gamepad.ButtonA ? "Pressed" : "")
                    + System.Environment.NewLine
                    + "Button B: " + (gamepad.ButtonB ? "Pressed" : "");
                    Debug.Log(gamepad.ToString());
                }
                catch (System.Exception)
                {
                    message = "Shitty Json";
                }

                _statusText.text = message;
                Debug.Log(e.StreamMessage);
                
            });
        }

        #endregion //RemoteInputController Host Events

        #region RemoteInputController Controller Events

        private void RemoteInputController_ConnectedToHost(object sender, ClientConnectedArgs e)
        {
            var message = string.Format("Controller connected to host at {0}", e.RemoteEndPoint);
            Debug.Log(message);
            _statusText.text = message;

            BeginSendData();

            //TODO: Convert application into state machine
            Destroy(GameObject.Find("Canvas"));
#if !UNITY_EDITOR && (UNITY_IOS || UNITY_ANDROID)
            Screen.orientation = ScreenOrientation.LandscapeLeft;
#endif
        }

        #endregion //RemoteInputController Controller Events
    }
}