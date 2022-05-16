using UnityEditor;
using UnityEngine;

namespace CommonGame
{
    [CustomEditor(typeof(PlaneFollower))]
    public class PlaneFollowerEditor : Editor
    {
        private PlaneFollower me;
        private void OnEnable()
        {
            me = target as PlaneFollower;

        }
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            if (GUILayout.Button("SaveOffset"))
            {
                me.SaveOffset();
            }
        }
    }
}
