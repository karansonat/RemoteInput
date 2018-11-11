using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RemoteInput.Core
{
    public class GamePadFactory
    {
        #region Singleton

        private static GamePadFactory _instance = new GamePadFactory();
        public static GamePadFactory Instance
        {
            get
            {
                return _instance;
            }
        }

        static GamePadFactory()
        {
        }

        private GamePadFactory()
        {
        }

        #endregion //Singleton

        #region Factory Methods

        public GamePad CreateModel()
        {
            return new GamePad();
        }

        public GamePadView CreateView()
        {
            var viewPrefab = Resources.Load<GameObject>("GamePad/GamePadView");
            return Object.Instantiate(viewPrefab).GetComponent<GamePadView>();
        }

        public GamePadState CreateController(GamePad model, GamePadView view)
        {
            return new GamePadState(model, view);
        }

        #endregion
    }
}