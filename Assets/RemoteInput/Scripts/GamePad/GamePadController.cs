using Game.Core;
using System;

namespace RemoteInput.Core
{
    #region EventArgs

    public class GamePadParametersUpdatedArgs : EventArgs
    {
        public GamePad GamePad { get; set; }
    }

    #endregion //EventArgs

    public class GamePadController : IMonoNotification, IObservable<GamePadParametersUpdatedArgs>
    {
        #region Fields

        private GamePad _model;
        private GamePadView _view;

        private event EventHandler<GamePadParametersUpdatedArgs> _gamePadParametersUpdated;

        private GamePadParametersUpdatedArgs _gamePadParametersUpdatedArgs;

        #endregion //Fields

        public GamePadController(GamePad model, GamePadView view)
        {
            _model = model;
            _view = view;
        }

        public void Init()
        {
            _model.Init();
            _view.Init();

            _gamePadParametersUpdatedArgs = new GamePadParametersUpdatedArgs();
        }

        #region IMonoNotification

        void IMonoNotification.FixedUpdate()
        {
        }

        void IMonoNotification.Update()
        {
        }

        void IMonoNotification.LateUpdate()
        {
            UpdateGamePadParameters();

            (this as IObservable<GamePadParametersUpdatedArgs>).Notify(_gamePadParametersUpdatedArgs);

            //var a = JsonUtility.ToJson(_model);
            //var b = JsonUtility.FromJson<GamePad>(a);
            //Debug.Log(a);
            //Debug.Log(b.ToString());

            _view.Reset();
        }

        #endregion //IMonoNotification

        #region Private Methods

        private void UpdateGamePadParameters()
        {
            _model.SetData(_view.Joystick, _view.ButtonAPressed, _view.ButtonBPressed);
            _gamePadParametersUpdatedArgs.GamePad = _model;
        }

        void IObservable<GamePadParametersUpdatedArgs>.Attach(IObserver<GamePadParametersUpdatedArgs> observer)
        {
            _gamePadParametersUpdated += observer.OnNotified;
        }

        void IObservable<GamePadParametersUpdatedArgs>.Detach(IObserver<GamePadParametersUpdatedArgs> observer)
        {
            _gamePadParametersUpdated -= observer.OnNotified;
        }

        void IObservable<GamePadParametersUpdatedArgs>.Notify(GamePadParametersUpdatedArgs eventArgs)
        {
            if (_gamePadParametersUpdated != null)
            {
                _gamePadParametersUpdated.Invoke(this, eventArgs);
            }
        }

        #endregion //Private Methods
    }
}