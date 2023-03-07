using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FateGames.Core
{
    public class RoutineRunner : MonoBehaviour
    {
        private static RoutineRunner instance = null;
        public static void StartRoutine(IEnumerator routine)
        {
            if (instance == null) Initialize();
            instance.StartCoroutine(routine);
        }

        private static void Initialize()
        {
            instance = new GameObject("RoutineRunner").AddComponent<RoutineRunner>();
            DontDestroyOnLoad(instance.gameObject);
        }
    }

}