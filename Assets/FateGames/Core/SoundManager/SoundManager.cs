using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FateGames.Core
{
    [CreateAssetMenu(menuName = "Fate/Sound/SoundManager")]
    public class SoundManager : ScriptableObject
    {
        [SerializeField] private GameStateVariable gameState;
        [SerializeField] private BoolVariable soundOn;
        [SerializeField] private GameObject soundWorkerPrefab;
        [SerializeField] private WorkingSoundWorkerSet workingWorkerSet;
        [SerializeField] private AvailableSoundWorkerSet availableWorkerSet;
        private int workerCount { get => workingWorkerSet.Items.Count + availableWorkerSet.Items.Count; }
        private SoundTable table = null;

        public void Initialize()
        {
            soundOn.Value = true;
            table = Resources.Load<SoundTable>("SoundTable");
            //table.Initialize();
        }

        public void StopWorkers()
        {
            foreach (SoundWorker worker in workingWorkerSet.Items)
                worker.Stop();
        }

        private SoundWorker GetAvailableWorker()
        {
            SoundWorker worker = null;
            void GetWorker() { if (availableWorkerSet.Items.Count > 0) worker = availableWorkerSet.Items[0]; }
            GetWorker();
            if (worker == null)
            {
                DoubleWorkers();
                GetWorker();
            }
            return worker;
        }

        private void DoubleWorkers()
        {
            int number = workerCount > 0 ? workerCount : 1;
            for (int i = 0; i < number; i++)
                InstantiateWorker();
        }

        private void InstantiateWorker()
        {
            Instantiate(soundWorkerPrefab);
        }

        public SoundWorker PlaySound(string soundTag, bool ignoreListenerPause = false)
        {
            return PlaySound(soundTag, Vector3.zero, ignoreListenerPause);
        }

        public SoundWorker PlaySound(string soundTag, Vector3 position, bool ignoreListenerPause = false, bool pauseOnStartIfGamePaused = false)
        {
            if (soundTag == "") return null;
            if (!ignoreListenerPause && !pauseOnStartIfGamePaused && gameState.Value == GameState.PAUSED) return null;
            SoundWorker worker = GetAvailableWorker();
            SoundEntity entity = table[soundTag];
            float pitch = Random.Range(entity.PitchRangeMin, entity.PitchRangeMax);
            worker.Initialize(entity.Clip, entity.Volume, pitch, entity.SpatialBlend, entity.Loop, position, ignoreListenerPause);
            worker.Play();
            if (!ignoreListenerPause && gameState.Value == GameState.PAUSED && pauseOnStartIfGamePaused)
            {
                worker.Pause();
            }
            return worker;
        }

    }
}
