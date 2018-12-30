using System;
using UnityEngine;

namespace Game.Core
{
    public enum StateType
    {
        Preperation,
        Game
    }

    public class StateController : IMonoNotification, IObserver<BeginMappingButtonPressedArgs>,    IObservable<BeginMappingButtonPressedArgs>,
                                                      IObserver<EndMappingButtonPressedArgs>,      IObservable<EndMappingButtonPressedArgs>,
                                                      IObserver<StartGameButtonPressedArgs>,       IObservable<StartGameButtonPressedArgs>
    {
        #region Fields

        private IState _activeState;

        #endregion //Fields

        #region Events

        private event EventHandler<BeginMappingButtonPressedArgs> _beginMappingButtonPressed;
        private event EventHandler<EndMappingButtonPressedArgs> _endMappingButtonPressedArgs;
        private event EventHandler<StartGameButtonPressedArgs> _placeAvatarButtonPressedArgs;

        #endregion //Events

        #region IMonoNotification

        void IMonoNotification.FixedUpdate()
        {
            if (_activeState != null)
                (_activeState as IMonoNotification).FixedUpdate();
        }

        void IMonoNotification.Update()
        {
            if (_activeState != null)
                (_activeState as IMonoNotification).Update();
        }

        void IMonoNotification.LateUpdate()
        {
            if (_activeState != null)
                (_activeState as IMonoNotification).LateUpdate();
        }

        #endregion //IMonoNotification

        #region Public Methods

        public void Init()
        {
            SwitchState(StateType.Preperation);
        }

        #endregion

        #region Private Methods

        private void SwitchState(StateType stateType)
        {
            // End state routine
            if (_activeState != null)
                _activeState.End();

            _activeState = null;

            // Create new state
            switch (stateType)
            {
                case StateType.Preperation:
                    var preperationModel = PreperationFactory.Instance.CreateModel();
                    var preperationView = PreperationFactory.Instance.CreateView();
                    _activeState = PreperationFactory.Instance.CreateController(preperationModel, preperationView);

                    preperationView.transform.SetParent(Camera.main.transform, false);
                    preperationView.transform.localEulerAngles = Vector3.zero;
                    preperationView.transform.localPosition = new Vector3(0, 0, 2);

                    (_activeState as IObservable<BeginMappingButtonPressedArgs>).Attach(this);
                    (_activeState as IObservable<EndMappingButtonPressedArgs>).Attach(this);
                    (_activeState as IObservable<StartGameButtonPressedArgs>).Attach(this);
                    break;
                case StateType.Game:
                    var gameModel = GameFactory.Instance.CreateModel();
                    var gameView = GameFactory.Instance.CreateView();
                    _activeState = GameFactory.Instance.CreateController(gameModel, gameView);

                    gameView.transform.SetParent(Camera.main.transform, false);
                    gameView.transform.localEulerAngles = Vector3.zero;
                    gameView.transform.localPosition = new Vector3(0, 0, 2);
                    break;
            }

            // Begin state routine
            if (_activeState != null)
                _activeState.Begin();
        }

        #endregion //Private methods

        #region IObserver Interface

        void IObserver<BeginMappingButtonPressedArgs>.OnNotified(object sender, BeginMappingButtonPressedArgs eventArgs)
        {
            (this as IObservable<BeginMappingButtonPressedArgs>).Notify(null);
        }

        void IObserver<EndMappingButtonPressedArgs>.OnNotified(object sender, EndMappingButtonPressedArgs eventArgs)
        {
            (this as IObservable<EndMappingButtonPressedArgs>).Notify(null);
        }

        void IObserver<StartGameButtonPressedArgs>.OnNotified(object sender, StartGameButtonPressedArgs eventArgs)
        {
            SwitchState(StateType.Game);
        }

        #endregion //IObserver Interface

        #region IObservable Interface

        void IObservable<BeginMappingButtonPressedArgs>.Attach(IObserver<BeginMappingButtonPressedArgs> observer)
        {
            _beginMappingButtonPressed += observer.OnNotified;
        }

        void IObservable<BeginMappingButtonPressedArgs>.Detach(IObserver<BeginMappingButtonPressedArgs> observer)
        {
            _beginMappingButtonPressed -= observer.OnNotified;
        }

        void IObservable<BeginMappingButtonPressedArgs>.Notify(BeginMappingButtonPressedArgs eventArgs)
        {
            if (_beginMappingButtonPressed != null)
                _beginMappingButtonPressed.Invoke(this, eventArgs);
        }

        void IObservable<EndMappingButtonPressedArgs>.Attach(IObserver<EndMappingButtonPressedArgs> observer)
        {
            _endMappingButtonPressedArgs += observer.OnNotified;
        }

        void IObservable<EndMappingButtonPressedArgs>.Detach(IObserver<EndMappingButtonPressedArgs> observer)
        {
            _endMappingButtonPressedArgs -= observer.OnNotified;
        }

        void IObservable<EndMappingButtonPressedArgs>.Notify(EndMappingButtonPressedArgs eventArgs)
        {
            if (_endMappingButtonPressedArgs != null)
                _endMappingButtonPressedArgs.Invoke(this, eventArgs);
        }

        void IObservable<StartGameButtonPressedArgs>.Attach(IObserver<StartGameButtonPressedArgs> observer)
        {
            _placeAvatarButtonPressedArgs += observer.OnNotified;
        }

        void IObservable<StartGameButtonPressedArgs>.Detach(IObserver<StartGameButtonPressedArgs> observer)
        {
            _placeAvatarButtonPressedArgs -= observer.OnNotified;
        }

        void IObservable<StartGameButtonPressedArgs>.Notify(StartGameButtonPressedArgs eventArgs)
        {
            if (_placeAvatarButtonPressedArgs != null)
                _placeAvatarButtonPressedArgs.Invoke(this, eventArgs);
        }

        #endregion //IObservable Interface
    }
}