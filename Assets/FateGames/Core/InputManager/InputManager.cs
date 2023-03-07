using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace FateGames.Core
{
    public static class InputManager
    {
        private static InputListener listener = null;
        private static float defaultSwerveSize = Screen.width / 4;
        private static Dictionary<float, Swerve> swerveTable = new();
        private static Dictionary<float, FloatingSwerve> floatingSwerveTable = new();
        public static void Initialize()
        {
            if (listener != null) return;
            listener = new GameObject("InputListener").AddComponent<InputListener>();
            Object.DontDestroyOnLoad(listener.gameObject);
        }

        public static UnityEvent GetKeyDownEvent(KeyCode keyCode)
        {
            return listener.AddKeyDownListener(keyCode);
        }
        public static UnityEvent GetKeyEvent(KeyCode keyCode)
        {
            return listener.AddKeyListener(keyCode);
        }
        public static UnityEvent GetKeyUpEvent(KeyCode keyCode)
        {
            return listener.AddKeyUpListener(keyCode);
        }

        public static Swerve GetSwerve(float size)
        {
            Swerve swerve;
            if (swerveTable.ContainsKey(size)) swerve = swerveTable[size];
            else
            {
                swerve = new Swerve(size);
                swerveTable.Add(size, swerve);
            }
            return swerve;
        }
        public static Swerve GetSwerve()
        {
            return GetSwerve(defaultSwerveSize);
        }

        public static FloatingSwerve GetFloatingSwerve(float size)
        {
            FloatingSwerve floatingSwerve;
            if (floatingSwerveTable.ContainsKey(size)) floatingSwerve = floatingSwerveTable[size];
            else
            {
                floatingSwerve = new FloatingSwerve(size);
                floatingSwerveTable.Add(size, floatingSwerve);
            }
            return floatingSwerve;
        }
        public static FloatingSwerve GetFloatingSwerve()
        {
            return GetFloatingSwerve(defaultSwerveSize);
        }
    }

}
