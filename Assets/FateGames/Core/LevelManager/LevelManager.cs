using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.Events;
namespace FateGames.Core
{
    [CreateAssetMenu(menuName = "Fate/Manager/LevelManager")]
    public class LevelManager : ScriptableObject
    {

        [SerializeField] private bool autoStart = false;
        [SerializeField] private SaveDataVariable saveData;
        [SerializeField] private GameObject loseScreen, winScreen;
        [SerializeField] private GameStateVariable gameState;
        [SerializeField] private UnityEvent OnLevelStarted, OnLevelFinished, OnLevelFailed, OnLevelWon;

        public bool AutoStart { get => autoStart; }

        public void StartLevel()
        {
            gameState.Value = GameState.IN_GAME;
            OnLevelStarted.Invoke();
        }

        public void FinishLevel(bool success)
        {
            OnLevelFinished.Invoke();
            if (success)
            {
                gameState.Value = GameState.WIN_SCREEN;
                saveData.Value.Level++;
                Instantiate(winScreen);
                OnLevelWon.Invoke();
            }
            else
            {
                gameState.Value = GameState.LOSE_SCREEN;
                Instantiate(loseScreen);
                OnLevelFailed.Invoke();
            }
        }

#if UNITY_EDITOR
        [MenuItem("Fate/Level/Open Level Manager")]
        public static void OpenLevelManager()
        {
            AssetDatabase.OpenAsset(Resources.Load("LevelManager"));
        }
        [MenuItem("Fate/Level/Open Win Screen")]
        public static void OpenWinScreen()
        {
            AssetDatabase.OpenAsset(Resources.Load("Screens/WinScreen"));
        }

        [MenuItem("Fate/Level/Open Lose Screen")]
        public static void OpenLoseScreen()
        {
            AssetDatabase.OpenAsset(Resources.Load("Screens/LoseScreen"));
        }
#endif
    }

}

