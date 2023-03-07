using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System.Linq;

namespace FateGames.Core
{
    [CreateAssetMenu(menuName = "Fate/Sound/Sound Table")]
    public class SoundTable : Table<SoundEntity>
    {

        public override void Initialize()
        {
            entities = Resources.FindObjectsOfTypeAll<SoundEntity>().ToList();
            base.Initialize();
        }
#if UNITY_EDITOR
        [MenuItem("Fate/Sound/Sound Table")]
        static void SelectSoundTable()
        {
            SoundTable table = Resources.Load<SoundTable>("SoundTable");
            Selection.activeObject = table;
        }
#endif
    }
}
