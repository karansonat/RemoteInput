using UnityEngine;

namespace Game.Core
{
    [CreateAssetMenu(fileName = "NewSpatialMapping", menuName = "Game/Create Spatial Mapping Model")]
    public class SpatialMappingModel : ScriptableObject
    {
        [SerializeField] private float _trianglesPerCubicMeter;
        public float TrianglesPerCubicMeter
        {
            get { return _trianglesPerCubicMeter; }
        }

        [SerializeField] private float _timeBetweenUpdates;
        public float TimeBetweenUpdates
        {
            get { return _timeBetweenUpdates; }
        }
    }
}