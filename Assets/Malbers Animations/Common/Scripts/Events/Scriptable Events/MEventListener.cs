using UnityEngine;

namespace MalbersAnimations.Events
{
    ///<summary>
    /// Listener to use with the GameEvents
    /// Based on the Talk - Game Architecture with Scriptable Objects by Ryan Hipple
    /// </summary>
    public class MEventListener : MonoBehaviour
    {
        [Tooltip("Event to register with.")]
        public MEvent Event;

        [Tooltip("Response to invoke when Event is raised.")]
        public UnityEngine.Events.UnityEvent Response;

        private void OnEnable() { Event.RegisterListener(this); }
        private void OnDisable() { Event.UnregisterListener(this); }
        public virtual void OnEventInvoked() { Response.Invoke(); }
    }
}