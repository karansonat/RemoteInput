using RemoteInput.Core;
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
        [SerializeField] private Button _sendDataButton;
        [SerializeField] private Text _statusText;

        #endregion //Fields

        #region Unity Methods

        private void Awake()
        {
            _inputController = new RemoteInputController();

            _listenButton.onClick.AddListener(() =>
            {
                SubscribeHostEvents();
                _inputController.Listen();
            });
            
            _connectButton.onClick.AddListener(() =>
            {
                SubscribeControllerEvents();
                _inputController.Connect("192.168.1.29");
            });
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

        private void RemoteInputController_ReadyForConnection(object sender, RemoteInput.Core.Network.ListenerStartedArgs e)
        {
            var message = string.Format("Client is ready for connection at {0}", e.LocalEndPoint);
            Debug.Log(message);
            _statusText.text = message;
        }

        private void RemoteInputController_ControllerConnected(object sender, ListenerAcceptedClientArgs e)
        {
            UnityMainThreadDispatcher.Instance().Enqueue(() =>
            {
                var message = string.Format("Remote Controller Connected from {0}", e.ClientEndPoint);
                Debug.Log(message);
                _statusText.text = message;
            });
        }

        private void RemoteInputController_InputDataReceived(object sender, ListenerReceivedMessageArgs e)
        {
            UnityMainThreadDispatcher.Instance().Enqueue(() =>
            {
                var message = string.Format("Received message: {0}", e.StreamMessage);
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
        }

        #endregion //RemoteInputController Controller Events
    }
}