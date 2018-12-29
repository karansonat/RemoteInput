using UnityEngine;

namespace Game.Core
{
    public class GameController : MonoBehaviour, IObserver<BeginMappingButtonPressedArgs>,
                                                 IObserver<EndMappingButtonPressedArgs>
    {
        #region Fields

        public static GameController Instance { get; private set; }

        private StateController _stateController;
        private SpatialMappingController _spatialMappingController;

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
            InitializeSpatialMappingController();
            InitializeStateController();
        }

        private void FixedUpdate()
        {
            if (_stateController != null)
                (_stateController as IMonoNotification).FixedUpdate();
        }

        private void Update()
        {
            if (_stateController != null)
                (_stateController as IMonoNotification).Update();
        }

        void LateUpdate()
        {
            if (_stateController != null)
                (_stateController as IMonoNotification).LateUpdate();
        }

        #endregion //Unity Methods

        #region Private Methods

        private void ApplyApplicationConfiguration()
        {
            Application.runInBackground = true;
            Application.targetFrameRate = 60;
        }

        private void InitializeStateController()
        {
            _stateController = new StateController();

            (_stateController as IObservable<BeginMappingButtonPressedArgs>).Attach(this);
            (_stateController as IObservable<EndMappingButtonPressedArgs>).Attach(this);

            _stateController.Init();
        }

        private void InitializeSpatialMappingController()
        {
            var model = SpatialMappingFactory.Instance.CreateModel();
            _spatialMappingController = SpatialMappingFactory.Instance.CreateController();
            _spatialMappingController.Init(model.TrianglesPerCubicMeter, model.TimeBetweenUpdates);
        }

        #endregion //Private Methods

        #region IObserver Interface

        void IObserver<BeginMappingButtonPressedArgs>.OnNotified(object sender, BeginMappingButtonPressedArgs eventArgs)
        {
            _spatialMappingController.BeginScanning();
        }

        void IObserver<EndMappingButtonPressedArgs>.OnNotified(object sender, EndMappingButtonPressedArgs eventArgs)
        {
            _spatialMappingController.EndScanning();
        }

        #endregion //IObserver Interface
    }
}