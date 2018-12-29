using UnityEngine;

namespace Game.Core
{
    public class GameFactory
    {
        #region Singleton

        private static GameFactory _instance = new GameFactory();
        public static GameFactory Instance
        {
            get { return _instance; }
        }

        static GameFactory()
        {
        }

        private GameFactory()
        {
        }

        #endregion //Singleton

        #region Factory Methods

        public GameModel CreateModel()
        {
            var model = Resources.Load<GameModel>("Game");
            return Object.Instantiate(model);
        }

        public GameView CreateView()
        {
            var view = Resources.Load<GameObject>("GameView");
            return Object.Instantiate(view).GetComponent<GameView>();
        }

        public GameState CreateController(GameModel model, GameView view)
        {
            var controller = new GameState(model, view);
            return controller;
        }

        #endregion //Factory Methods
    }
}