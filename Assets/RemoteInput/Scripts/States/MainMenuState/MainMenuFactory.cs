using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RemoteInput.Core
{
    public class MainMenuFactory
    {
        #region Singleton

        private static MainMenuFactory _instance = new MainMenuFactory();
        public static MainMenuFactory Instance
        {
            get
            {
                return _instance;
            }
        }

        static MainMenuFactory()
        {
        }

        private MainMenuFactory()
        {
        }

        #endregion //Singleton

        #region Factory Methods

        public MainMenu CreateModel()
        {
            return new MainMenu();
        }

        public MainMenuView CreateView()
        {
            var viewPrefab = Resources.Load<GameObject>("MainMenu/MainMenuView");
            return Object.Instantiate(viewPrefab).GetComponent<MainMenuView>();
        }

        public MainMenuState CreateController(MainMenu model, MainMenuView view)
        {
            return new MainMenuState(model, view);
        }

        #endregion
    }
}