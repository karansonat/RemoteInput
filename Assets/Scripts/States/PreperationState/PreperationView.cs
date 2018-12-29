using System;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Core
{
    public class PreperationView : MonoBehaviour, IObservable<BeginMappingButtonPressedArgs>,
                                                  IObservable<EndMappingButtonPressedArgs>,
                                                  IObservable<StartGameButtonPressedArgs>
    {
        #region Fields

        [SerializeField] private GameObject _panelBeginSpatialMapping;
        [SerializeField] private GameObject _panelEndSpatialMapping;
        [SerializeField] private GameObject _panelPlaceAvatar;
        [SerializeField] private Button _buttonBeginSpatialMapping;
        [SerializeField] private Button _buttonEndSpatialMapping;
        [SerializeField] private Button _buttonPlaceAvatar;

        #endregion //Fields

        #region Events

        private event EventHandler<BeginMappingButtonPressedArgs> _beginMappingButtonPressed;
        private event EventHandler<EndMappingButtonPressedArgs> _endMappingButtonPressedArgs;
        private event EventHandler<StartGameButtonPressedArgs> _placeAvatarButtonPressedArgs;

        #endregion //Events

        #region Public Methods

        public void Init()
        {
            _panelBeginSpatialMapping.SetActive(true);
            _panelEndSpatialMapping.SetActive(false);
            _panelPlaceAvatar.SetActive(false);

            _buttonBeginSpatialMapping.onClick.RemoveAllListeners();
            _buttonBeginSpatialMapping.onClick.AddListener(OnBeginSpatialMappingButtonPressed);

            _buttonEndSpatialMapping.onClick.RemoveAllListeners();
            _buttonEndSpatialMapping.onClick.AddListener(OnEndSpatialMappingButtonPressed);

            _buttonPlaceAvatar.onClick.RemoveAllListeners();
            _buttonPlaceAvatar.onClick.AddListener(OnPlaceAvatarButtonPressed);
        }

        #endregion //Public Methods

        #region Private Methods

        private void OnBeginSpatialMappingButtonPressed()
        {
            _panelBeginSpatialMapping.SetActive(false);
            _panelEndSpatialMapping.SetActive(true);

            (this as IObservable<BeginMappingButtonPressedArgs>).Notify(null);
        }

        private void OnEndSpatialMappingButtonPressed()
        {
            _panelEndSpatialMapping.SetActive(false);
            _panelPlaceAvatar.SetActive(true);

            (this as IObservable<EndMappingButtonPressedArgs>).Notify(null);
        }

        private void OnPlaceAvatarButtonPressed()
        {
            _panelPlaceAvatar.SetActive(false);

            (this as IObservable<StartGameButtonPressedArgs>).Notify(null);
        }

        #endregion //Private Methods

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