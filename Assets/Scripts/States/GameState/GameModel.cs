using MalbersAnimations;
using RemoteInput.Core;
using UnityEngine;

namespace Game.Core
{
    [CreateAssetMenu(fileName = "NewGameModel", menuName = "Game/Create Game Model")]
    public class GameModel : ScriptableObject, IMonoNotification
    {
        #region Fields

        private Animal _avatar;
        private GamePad _gamePad;

        #endregion //Fields

        #region IMonoNotification Interface

        void IMonoNotification.FixedUpdate()
        {
            if (_gamePad == null || _avatar == null)
                return;

            Debug.Log(_gamePad.InputVector.ToString());

            _avatar.Move(_gamePad.InputVector, false);
        }

        void IMonoNotification.LateUpdate()
        {
        }

        void IMonoNotification.Update()
        {
            if (_gamePad == null || _avatar == null)
                return;

            UpdateAvatarFlyState();

            if (_gamePad.ButtonA)
                _avatar.SetSecondaryAttack();
        }

        private void UpdateAvatarFlyState()
        {
            if (!_avatar.Fly && _gamePad.RotationRateUnbiased.y > 0.5f && _gamePad.Acceleration.y < -0.7f)
            {
                _avatar.Fly = true;
            }

            if (_avatar.Fly && _gamePad.RotationRateUnbiased.y < -0.5f && _gamePad.Acceleration.y > 0.7f)
            {
                _avatar.Fly = false;
            }
        }

        #endregion //IMonoNotification Interface

        #region Public Methods

        public Animal InitializeAvatar()
        {
            SpawnAvatar();
            SetAvatarPosition();
            SetAvatarProperties();

            return _avatar;
        }

        public void UpdateGamePadData(GamePad gamePadData)
        {
            _gamePad = gamePadData;
        }

        #endregion //Public Methods

        #region Private Methods

        private void SpawnAvatar()
        {
            var prefab = Resources.Load<GameObject>("Dragon");
            _avatar = Instantiate(prefab).GetComponent<Animal>();
        }

        private void SetAvatarPosition()
        {
            var camPos = Camera.main.transform.position;
            camPos += Camera.main.transform.forward * 2;
            _avatar.transform.position = camPos;
        }

        private void SetAvatarProperties()
        {
            _avatar.Speed2 = true;
        }

        #endregion //Private Methods
    }
}