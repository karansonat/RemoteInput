using System;
using UnityEngine;

namespace RemoteInput.Core
{
    public class GamePadState : IState, IMonoNotification, 
                                IObservable<GamePadParametersUpdatedArgs>,
                                IObservable<DisconnectButtonPressedArgs>, IObserver<DisconnectButtonPressedArgs>
    {
        #region Fields

        private GamePad _model;
        private GamePadView _view;

        private GamePadParametersUpdatedArgs _gamePadParametersUpdatedArgs;

        #endregion //Fields

        #region Events

        private event EventHandler<GamePadParametersUpdatedArgs> _gamePadParametersUpdated;
        private event EventHandler<DisconnectButtonPressedArgs> _disconnectButtonPressed;

        #endregion //Events

        public GamePadState(GamePad model, GamePadView view)
        {
            _model = model;
            _view = view;
        }

        #region IState Interface

        void IState.Begin()
        {
            Init();
        }

        void IState.End()
        {
            UnityEngine.Object.Destroy(_view.gameObject);
        }

        #endregion //IState Interface

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

            _view.Reset();
        }

        #endregion //IMonoNotification

        #region Private Methods

        private void Init()
        {
            _model.Init();
            _view.Init();

            _gamePadParametersUpdatedArgs = new GamePadParametersUpdatedArgs();

            (_view as IObservable<DisconnectButtonPressedArgs>).Attach(this);
        }

        private void UpdateGamePadParameters()
        {
            _model.SetData(_view.InputVector, _view.ButtonAPressed);
            _gamePadParametersUpdatedArgs.GamePad = _model;
        }

        #endregion //Private Methods

        #region IObserver Interface

        void IObserver<DisconnectButtonPressedArgs>.OnNotified(object sender, DisconnectButtonPressedArgs eventArgs)
        {
            (this as IObservable<DisconnectButtonPressedArgs>).Notify(eventArgs);
        }

        #endregion

        #region IObservable Interface

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

        void IObservable<DisconnectButtonPressedArgs>.Attach(IObserver<DisconnectButtonPressedArgs> observer)
        {
            _disconnectButtonPressed += observer.OnNotified;
        }

        void IObservable<DisconnectButtonPressedArgs>.Detach(IObserver<DisconnectButtonPressedArgs> observer)
        {
            _disconnectButtonPressed -= observer.OnNotified;
        }

        void IObservable<DisconnectButtonPressedArgs>.Notify(DisconnectButtonPressedArgs eventArgs)
        {
            if (_disconnectButtonPressed != null)
            {
                _disconnectButtonPressed.Invoke(this, eventArgs);
            }
        }

        #endregion //IObservable Interface
    }
}