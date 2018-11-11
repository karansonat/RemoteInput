using System.Collections.Generic;
using UnityEngine;

namespace MalbersAnimations.Events
{
    ///<summary>
    /// The list of listeners that this event will notify if it is Invoked. 
    /// Based on the Talk - Game Architecture with Scriptable Objects by Ryan Hipple
    /// </summary>
    [CreateAssetMenu(menuName = "Malbers Animations/Event" , fileName = "New Event Asset")]
    public class MEvent : ScriptableObject
    {
        /// <summary>
        /// The list of listeners that this event will notify if it is raised.
        /// </summary>
        private readonly List<MEventListener> eventListeners = new List<MEventListener>();

#if UNITY_EDITOR
        [Multiline]
        public string Description;
#endif

        public virtual void Invoke()
        {
            for (int i = eventListeners.Count - 1; i >= 0; i--)
                eventListeners[i].OnEventInvoked();
        }

        public virtual void RegisterListener(MEventListener listener)
        {
            if (!eventListeners.Contains(listener))
                eventListeners.Add(listener);
        }

        public virtual void UnregisterListener(MEventListener listener)
        {
            if (eventListeners.Contains(listener))
                eventListeners.Remove(listener);
        }



        //This is for Debugin porpuses
        public virtual void DebugLog(string text)
        {
            Debug.Log(text);
        }

        public virtual void DebugLog(bool value)
        {
            Debug.Log(value);
        }

        public virtual void DebugLog(int value)
        {
            Debug.Log(value);
        }

        public virtual void DebugLog(float value)
        {
            Debug.Log(value);
        }

        public virtual void DebugLog(object value)
        {
            Debug.Log(value);
        }

        public virtual void DebugLog(MonoBehaviour value)
        {
            Debug.Log(value.name);
        }
    }
}
