using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace MalbersAnimations.Events
{
    [CustomEditor(typeof(MEvent))]
    public class MEventEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            GUI.enabled = Application.isPlaying;

            MEvent e = target as MEvent;
            if (GUILayout.Button("Raise"))
                e.Invoke();
        }
    }
}