using UnityEngine;
using System.Collections;

namespace MalbersAnimations
{
    [CreateAssetMenu(menuName = "Malbers Animations/Actions")]
    public class Actions : ScriptableObject
    {
        [SerializeField]
        public ActionsEmotions[] actions;
    }


    public struct ActionSet
    {
        public enum ActionInterruption { None, Movement, Time, Release }
        /// <summary>
        /// Name of the ActionEmotion
        /// </summary>
        public string name;
        public int ID;
        public ActionInterruption interruption;
        public float time;
        public float loops;
    }
}