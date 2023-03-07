using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace FateGames.Core
{
    [CustomEditor(typeof(SoundTable))]
    public class SoundTableEditor : Editor
    {
        private SoundTable soundTable;
        private void OnEnable()
        {
            soundTable = target as SoundTable;
        }
        public override void OnInspectorGUI()
        {
            EditorGUI.BeginDisabledGroup(true);
            DrawDefaultInspector();
            EditorGUI.EndDisabledGroup();
            if (GUILayout.Button("Refresh"))
            {
                soundTable.Initialize();
            }
        }
    }
}
