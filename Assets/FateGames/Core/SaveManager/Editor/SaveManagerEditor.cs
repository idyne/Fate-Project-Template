using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.AnimatedValues;

namespace FateGames.Core
{
    [CustomEditor(typeof(SaveManager))]
    public class SaveManagerEditor : Editor
    {
        private SaveManager saveManager;

        private void OnEnable()
        {
            saveManager = target as SaveManager;
        }
        public override void OnInspectorGUI()
        {
            //DrawDefaultInspector();
            bool overrideSave = EditorGUILayout.ToggleLeft("Override Save", saveManager.OverrideSave);
            saveManager.OverrideSave = overrideSave;
            EditorGUI.BeginDisabledGroup(!overrideSave);
            EditorGUI.indentLevel++;
            SaveDataVariable overrideSaveData = EditorGUILayout.ObjectField("Override Save Data", saveManager.OverrideSaveData, typeof(SaveDataVariable), false) as SaveDataVariable;
            saveManager.OverrideSaveData = overrideSaveData;
            EditorGUI.indentLevel--;
            EditorGUI.EndDisabledGroup();
            EditorGUI.BeginDisabledGroup(overrideSave);
            bool autoSave = EditorGUILayout.ToggleLeft("Auto Save", saveManager.AutoSave);
            saveManager.AutoSave = autoSave;

            EditorGUI.indentLevel++;
            saveManager.AutoSavePeriod = EditorGUILayout.FloatField("Auto Save Period", saveManager.AutoSavePeriod);
            EditorGUI.indentLevel--;


            EditorGUI.EndDisabledGroup();
            saveManager.SaveData = EditorGUILayout.ObjectField("Save Data", saveManager.SaveData, typeof(SaveDataVariable), false) as SaveDataVariable;

        }
    }
}
