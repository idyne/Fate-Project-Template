using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

namespace FateGames.Core
{
    public class InputListener : MonoBehaviour
    {
        private readonly Dictionary<KeyCode, UnityEvent> keyDownEvents = new();
        private readonly Dictionary<KeyCode, UnityEvent> keyEvents = new();
        private readonly Dictionary<KeyCode, UnityEvent> keyUpEvents = new();

        
        private void Update()
        {
            ListenKeyDownEvent();
            ListenKeyEvent();
            ListenKeyUpEvent();
        }
        public UnityEvent AddKeyDownListener(KeyCode keyCode)
        {
            if (keyDownEvents.ContainsKey(keyCode)) return keyDownEvents[keyCode];
            UnityEvent keyDownEvent = new();
            keyDownEvents.Add(keyCode, keyDownEvent);
            return keyDownEvent;
        }
        public UnityEvent AddKeyListener(KeyCode keyCode)
        {
            if (keyEvents.ContainsKey(keyCode)) return keyEvents[keyCode];
            UnityEvent keyEvent = new();
            keyEvents.Add(keyCode, keyEvent);
            return keyEvent;
        }
        public UnityEvent AddKeyUpListener(KeyCode keyCode)
        {
            if (keyUpEvents.ContainsKey(keyCode)) return keyUpEvents[keyCode];
            UnityEvent keyUpEvent = new();
            keyUpEvents.Add(keyCode, keyUpEvent);
            return keyUpEvent;
        }
        private void ListenKeyDownEvent()
        {
            for (int i = 0; i < keyDownEvents.Count; i++)
            {
                KeyCode keyCode = keyDownEvents.ElementAt(i).Key;
                if (Input.GetKeyDown(keyCode)) keyDownEvents[keyCode].Invoke();
            }
        }
        private void ListenKeyEvent()
        {
            for (int i = 0; i < keyEvents.Count; i++)
            {
                KeyCode keyCode = keyEvents.ElementAt(i).Key;
                if (Input.GetKey(keyCode)) keyEvents[keyCode].Invoke();
            }
        }
        private void ListenKeyUpEvent()
        {
            for (int i = 0; i < keyUpEvents.Count; i++)
            {
                KeyCode keyCode = keyUpEvents.ElementAt(i).Key;
                if (Input.GetKeyUp(keyCode)) keyUpEvents[keyCode].Invoke();
            }
        }
    }

}