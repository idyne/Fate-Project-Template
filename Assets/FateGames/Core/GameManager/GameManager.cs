using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace FateGames.Core
{

    [CreateAssetMenu(menuName = "Fate/Manager/GameManager")]
    public class GameManager : ScriptableObject
    {
        [SerializeField] private int targetFrameRate = -1;
        [SerializeField] private GameStateVariable gameState;
        [SerializeField] private UnityEvent OnPause, OnResume;

        public void Initialize()
        {
            Application.targetFrameRate = targetFrameRate;
        }

        public void PauseGame()
        {
            if (gameState.Value == GameState.PAUSED) return;
            gameState.Value = GameState.PAUSED;
            OnPause.Invoke();
        }

        public void ResumeGame()
        {
            if (gameState.Value != GameState.PAUSED) return;
            gameState.Value = GameState.IN_GAME;
            OnResume.Invoke();
        }
    }
}
