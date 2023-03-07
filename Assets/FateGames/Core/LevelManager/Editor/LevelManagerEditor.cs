using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UIElements;

namespace FateGames.Core
{
    [CustomEditor(typeof(LevelManager))]
    public class LevelManagerEditor : Editor
    {
        private LevelManager levelManager;

        private void OnEnable()
        {
            levelManager = target as LevelManager;
        }
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            if (GUILayout.Button("Lose")) levelManager.FinishLevel(false);
            if (GUILayout.Button("Win")) levelManager.FinishLevel(true);
        }
    }

}
