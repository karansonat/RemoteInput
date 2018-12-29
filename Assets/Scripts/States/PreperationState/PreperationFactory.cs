using UnityEngine;

namespace Game.Core
{
    public class PreperationFactory
    {
        #region Singleton

        private static PreperationFactory _instance = new PreperationFactory();
        public static PreperationFactory Instance
        {
            get { return _instance; }
        }

        static PreperationFactory()
        {
        }

        private PreperationFactory()
        {
        }

        #endregion //Singleton

        #region Factory Methods

        public Preperation CreateModel()
        {
            var model = Resources.Load<Preperation>("Preperation");
            return Object.Instantiate(model);
        }

        public PreperationView CreateView()
        {
            var view = Resources.Load<GameObject>("PreperationView");
            return Object.Instantiate(view).GetComponent<PreperationView>();
        }

        public PreperationState CreateController(Preperation model, PreperationView view)
        {
            var controller = new PreperationState(model, view);
            return controller;
        }

        #endregion //Factory Methods

        #region Private Methods

        private SpatialMappingController CreateSpatialMappingController()
        {
            var spatialMappingPrefab = Resources.Load<GameObject>("SpatialMappingController");
            return Object.Instantiate(spatialMappingPrefab).GetComponent<SpatialMappingController>();
        }

        #endregion //Private Methods
    }
}