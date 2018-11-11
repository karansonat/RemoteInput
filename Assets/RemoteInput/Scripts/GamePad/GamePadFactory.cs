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

        public GamePad CreateGamePadModel()
        {
            return new GamePad();
        }

        public GamePadView CreateGamePadView()
        {
            var viewPrefab = Resources.Load<GameObject>("GamePad/GamePadView");
            return Object.Instantiate(viewPrefab).GetComponent<GamePadView>();
        }

        public GamePadController CreateGamePadController(GamePad model, GamePadView view)
        {
            return new GamePadController(model, view);
        }

        #endregion
    }
}