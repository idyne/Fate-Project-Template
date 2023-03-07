using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace FateGames.Core
{
    [CustomEditor(typeof(GameStateVariable))]
    public class GameStateVariableEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            EditorGUI.BeginDisabledGroup(true);
            DrawDefaultInspector();
            EditorGUI.EndDisabledGroup();
        }
    }

}