using HoloToolkit.Unity.SpatialMapping;
using System;
using UnityEngine;

namespace Game.Core
{
    public class SpatialMappingController
    {
        #region Fields

        private SpatialMappingManager _spatialMappingManager;
        private SpatialMappingObserver _spatialMappingObserver;

        #endregion //Fields

        #region Constructor

        public SpatialMappingController(SpatialMappingManager spatialMappingManager, SpatialMappingObserver spatialMappingObserver)
        {
            _spatialMappingManager = spatialMappingManager;
            _spatialMappingObserver = spatialMappingObserver;
        }

        #endregion //Constructor

        #region Public Methods

        public void Init(float trianglesPerCubicMeter, float timeBetweenUpdates)
        {
            _spatialMappingObserver.TrianglesPerCubicMeter = trianglesPerCubicMeter;
            _spatialMappingObserver.TimeBetweenUpdates = timeBetweenUpdates;
        }

        public void BeginScanning()
        {
            _spatialMappingObserver.StartObserving();
            SetMeshVisiblity(true);
        }

        public void EndScanning()
        {
            _spatialMappingObserver.StopObserving();
            SetMeshVisiblity(false);
        }

        #endregion //Public Methods

        #region Private Methods

        private void SetMeshVisiblity(bool state)
        {
            SpatialMappingManager.Instance.DrawVisualMeshes = state;

            foreach (var meshRenderer in _spatialMappingObserver.GetComponentsInChildren<MeshRenderer>(true))
            {
                meshRenderer.enabled = state;
            }
        }

        #endregion //Private Methods
    }
}