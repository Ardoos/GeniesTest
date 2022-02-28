using UnityEditor;
using UnityEngine;

namespace Genies.Interview.Events
{
    [CustomEditor (typeof (GameEvent))]
    public class GameEventCustomEditor : Editor
    {
        public override void OnInspectorGUI ()
        {
            base.OnInspectorGUI ();

            GUI.enabled = Application.isPlaying;

            GameEvent gameEvent = target as GameEvent;
            if (GUILayout.Button ("Raise"))
            {
                gameEvent.Raise ();
            }
        }
    }
}