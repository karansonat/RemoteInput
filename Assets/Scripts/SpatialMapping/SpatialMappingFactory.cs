using HoloToolkit.Unity.SpatialMapping;
using UnityEngine;

namespace Game.Core
{
    public class SpatialMappingFactory
    {
        #region Singleton

        private static SpatialMappingFactory _instance = new SpatialMappingFactory();
        public static SpatialMappingFactory Instance
        {
            get { return _instance; }
        }

        static SpatialMappingFactory()
        {
        }

        private SpatialMappingFactory()
        {
        }

        #endregion //Singleton

        #region Factory Methods

        public SpatialMappingModel CreateModel()
        {
            var model = Resources.Load<SpatialMappingModel>("SpatialMappingModel");
            return Object.Instantiate(model);
        }

        public SpatialMappingController CreateController()
        {
            var spatialMappingPrefab = Resources.Load<GameObject>("SpatialMapping");
            var spatialMappingObject = Object.Instantiate(spatialMappingPrefab);
            var spatialMappingManager = spatialMappingObject.GetComponent<SpatialMappingManager>();
            var spatialMappingObserver = spatialMappingObject.GetComponent<SpatialMappingObserver>();
            return new SpatialMappingController(spatialMappingManager, spatialMappingObserver);
        }

        #endregion //Factory Methods
    }
}