using UnityEngine;

namespace Game.Core
{
    public class FollowCameraFactory
    {
        #region Singleton

        private static readonly FollowCameraFactory _instance = new FollowCameraFactory();
        public static FollowCameraFactory Instance
        {
            get { return _instance; }
        }

        static FollowCameraFactory()
        {
        }

        #endregion //Singleton

        #region Public Methods

        public FollowCameraController CreateController()
        {
            return new FollowCameraController(CreateModel());
        }

        #endregion //Public Methods

        #region Private Methods

        private FollowCamera CreateModel()
        {
            return Resources.Load<FollowCamera>("FollowCameraSettings");
        }

        #endregion //Private Methods
    }
}
