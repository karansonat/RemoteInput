using UnityEngine;

namespace Game.Core
{
    [CreateAssetMenu(fileName = "NewFollowCameraSettings", menuName = "Game/Create FollowCameraSettings")]
    public class FollowCamera : ScriptableObject
    {
        [SerializeField] private float _offsetX;
        public float OffsetX
        {
            get { return _offsetX; }
        }

        [SerializeField] private float _offsetY;
        public float OffsetY
        {
            get { return _offsetY; }
        }

        [SerializeField] private float _offsetZ;
        public float OffsetZ
        {
            get { return _offsetZ; }
        }

        [SerializeField] private float _distance;
        public float Distance
        {
            get { return _distance; }
        }

        private Vector3 _followOffset = new Vector3();

        public Vector3 GetFollowOffset()
        {
            _followOffset.x = _offsetX;
            _followOffset.y = _offsetY;
            _followOffset.z = _offsetZ;
            return _followOffset * _distance;
        }
    }
}
