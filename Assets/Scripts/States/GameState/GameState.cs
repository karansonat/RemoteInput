using RemoteInput.Core;

namespace Game.Core
{
    public class GameState : IState, IMonoNotification
    {
        #region Fields

        private GameModel _model;
        private GameView _view;

        #endregion //Fields

        #region Constructor

        public GameState(GameModel model, GameView view)
        {
            _model = model;
            _view = view;
        }

        #endregion //Constructor

        #region IState Interface

        void IState.Begin()
        {
            SubscribeEvents();
            _model.InitializeAvatar();
            RemoteInputController.Instance.Listen();
        }

        void IState.End()
        {
            UnsubscribeEvents();
        }

        #endregion //IState Interface

        #region IMonoNotification Interface

        void IMonoNotification.FixedUpdate()
        {
            (_model as IMonoNotification).FixedUpdate();
        }

        void IMonoNotification.LateUpdate()
        {
            (_model as IMonoNotification).LateUpdate();
        }

        void IMonoNotification.Update()
        {
            (_model as IMonoNotification).Update();
        }

        #endregion //IMonoNotification Interface

        #region Private Methods

        private void SubscribeEvents()
        {
            RemoteInputController.Instance.ReadyForConnection += OnReadyForConnection;
            RemoteInputController.Instance.ControllerConnected += OnControllerConnected;
            RemoteInputController.Instance.InputDataReceived += OnInputDataReceived;
        }

        private void UnsubscribeEvents()
        {
            RemoteInputController.Instance.ReadyForConnection -= OnReadyForConnection;
            RemoteInputController.Instance.ControllerConnected -= OnControllerConnected;
            RemoteInputController.Instance.InputDataReceived -= OnInputDataReceived;
        }

        private void OnInputDataReceived(object sender, RemoteInput.Core.Network.InputDataReceivedArgs e)
        {
            _model.UpdateGamePadData(e.GamePadData);
        }

        private void OnControllerConnected(object sender, RemoteInput.Core.Network.ListenerAcceptedClientArgs e)
        {
            UnityMainThreadDispatcher.Instance.Enqueue(() =>
            {
                _view.gameObject.SetActive(false);
            });
        }

        private void OnReadyForConnection(object sender, RemoteInput.Core.Network.ListenerStartedArgs e)
        {
            _view.Init(e.LocalEndPoint);
        }

        #endregion //Private Methods
    }
}