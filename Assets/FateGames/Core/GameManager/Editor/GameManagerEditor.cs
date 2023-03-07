using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace FateGames.Core
{
    [CustomEditor(typeof(GameManager))]
    public class GameManagerEditor : Editor
    {
        [SerializeField] private BoolVariable paused;
        private GameManager gameManager;
        private void OnEnable()
        {
            gameManager = target as GameManager;
        }
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            if (paused.Value)
            {
                if (GUILayout.Button("Resume"))
                    gameManager.ResumeGame();
            }
            else
            {
                if (GUILayout.Button("Pause"))
                    gameManager.PauseGame();
            }
        }
    }

}

