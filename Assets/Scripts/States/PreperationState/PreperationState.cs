using System;

namespace Game.Core
{
    public class PreperationState : IState, IMonoNotification, IObserver<BeginMappingButtonPressedArgs>, IObservable<BeginMappingButtonPressedArgs>,
                                                               IObserver<EndMappingButtonPressedArgs>,   IObservable<EndMappingButtonPressedArgs>,
                                                               IObserver<StartGameButtonPressedArgs>,  IObservable<StartGameButtonPressedArgs>
    {
        #region Fields

        private Preperation _model;
        private PreperationView _view;

        #endregion //Fields

        #region Events

        private event EventHandler<BeginMappingButtonPressedArgs> _beginMappingButtonPressed;
        private event EventHandler<EndMappingButtonPressedArgs> _endMappingButtonPressedArgs;
        private event EventHandler<StartGameButtonPressedArgs> _placeAvatarButtonPressedArgs;

        #endregion //Events

        #region Constructor

        public PreperationState(Preperation model, PreperationView view)
        {
            _model = model;
            _view = view;
        }

        #endregion //Constructor

        #region IState Interface

        void IState.Begin()
        {
            _view.Init();
            SubscribeEvents();
        }

        void IState.End()
        {
            UnsubscribeEvents();
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
        }

        #endregion //IMonoNotification

        #region Private Methods

        private void SubscribeEvents()
        {
            (_view as IObservable<BeginMappingButtonPressedArgs>).Attach(this);
            (_view as IObservable<EndMappingButtonPressedArgs>).Attach(this);
            (_view as IObservable<StartGameButtonPressedArgs>).Attach(this);
        }

        private void UnsubscribeEvents()
        {
            (_view as IObservable<BeginMappingButtonPressedArgs>).Detach(this);
            (_view as IObservable<EndMappingButtonPressedArgs>).Detach(this);
            (_view as IObservable<StartGameButtonPressedArgs>).Detach(this);
        }

        #endregion //Private Methods

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
            (this as IObservable<StartGameButtonPressedArgs>).Notify(null);
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