using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace FateGames.Core
{
    public class Swerve
    {
        public readonly float Size;
        public Vector2 AnchorPosition { get; protected set; } = Vector2.zero;
        public Vector2 MousePosition { get; protected set; } = Vector2.zero;
        public Vector2 Difference { get => MousePosition - AnchorPosition; }
        public float Distance { get => Difference.magnitude; }
        public float Rate { get => Distance / Size; }
        public float XRate { get => Difference.x / Size; }
        public float YRate { get => Difference.y / Size; }
        public readonly UnityEvent OnStart = new();
        public readonly UnityEvent OnSwerve = new();
        public readonly UnityEvent OnRelease = new();

        public Swerve(float size)
        {
            Size = size;
            UnityEvent mouseButtonDownEvent = InputManager.GetKeyDownEvent(KeyCode.Mouse0);
            UnityEvent mouseButtonEvent = InputManager.GetKeyEvent(KeyCode.Mouse0);
            UnityEvent mouseButtonUpEvent = InputManager.GetKeyUpEvent(KeyCode.Mouse0);

            mouseButtonDownEvent.AddListener(OnMouseButtonDown);
            mouseButtonEvent.AddListener(OnMouseButton);
            mouseButtonUpEvent.AddListener(OnMouseButtonUp);
        }

        protected virtual void OnMouseButtonDown()
        {
            AnchorPosition = Input.mousePosition;
            MousePosition = Input.mousePosition;
            OnStart.Invoke();
        }

        protected virtual void OnMouseButton()
        {
            Vector2 mousePosition = Input.mousePosition;
            Vector2 direction = (mousePosition - AnchorPosition).normalized;
            MousePosition = AnchorPosition + direction * Mathf.Clamp((mousePosition - AnchorPosition).magnitude, 0, Size);
            OnSwerve.Invoke();
        }

        protected virtual void OnMouseButtonUp()
        {
            OnRelease.Invoke();
        }

    }
}

