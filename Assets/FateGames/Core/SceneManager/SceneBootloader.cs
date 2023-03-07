using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace FateGames.Core
{
    public class SceneBootloader : MonoBehaviour
    {
        [SerializeField] private SceneManager sceneManager;
        [SerializeField] private LevelManager levelManager;
        [SerializeField] private GameStateVariable gameState;

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }
        void OnEnable()
        {
            //Tell our 'OnLevelFinishedLoading' function to start listening for a scene change as soon as this script is enabled.
            UnityEngine.SceneManagement.SceneManager.sceneLoaded += OnLevelFinishedLoading;
        }

        void OnDisable()
        {
            //Tell our 'OnLevelFinishedLoading' function to stop listening for a scene change as soon as this script is disabled. Remember to always have an unsubscription for every delegate you subscribe to!
            UnityEngine.SceneManagement.SceneManager.sceneLoaded -= OnLevelFinishedLoading;
        }

        void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
        {
            if (sceneManager.IsLevel(scene))
            {
                gameState.Value = GameState.BEFORE_START;
                if (levelManager.AutoStart)
                    levelManager.StartLevel();
            }
        }
    }
}
