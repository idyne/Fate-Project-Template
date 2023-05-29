using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace FateGames.Core
{
    public class Swerve : MonoBehaviour
    {
        [SerializeField] protected int Size = 100;
        public Vector2 AnchorPosition { get; protected set; } = Vector2.zero;
        public Vector2 MousePosition { get; protected set; } = Vector2.zero;
        public Vector2 Difference { get => MousePosition - AnchorPosition; }
        public Vector2 Direction { get => Difference.normalized; }
        public float Distance { get => Difference.magnitude; }
        public float Rate { get => Distance / Size; }
        public float XRate { get => Difference.x / Size; }
        public float YRate { get => Difference.y / Size; }
        [SerializeField] public UnityEvent<Swerve> OnStart = new();
        [SerializeField] public UnityEvent<Swerve> OnSwerve = new();
        [SerializeField] public UnityEvent<Swerve> OnRelease = new();


        private void Update()
        {
            if (Input.touchSupported)
            {
                if (Input.touchCount > 0)
                {
                    Touch touch = Input.GetTouch(0);
                    switch (touch.phase)
                    {
                        case UnityEngine.TouchPhase.Began:
                            OnMouseButtonDown();
                            break;
                        case UnityEngine.TouchPhase.Moved:
                            OnMouseButton();
                            break;
                        case UnityEngine.TouchPhase.Stationary:
                            break;
                        case UnityEngine.TouchPhase.Ended:
                            OnMouseButtonUp();
                            break;
                        case UnityEngine.TouchPhase.Canceled:
                            OnMouseButtonUp();
                            break;
                        default:
                            break;
                    }
                }
            }
            else
            {
                if (Input.GetMouseButtonDown(0)) OnMouseButtonDown();
                else if (Input.GetMouseButton(0)) OnMouseButton();
                else if (Input.GetMouseButtonUp(0)) OnMouseButtonUp();
            }
        }

        protected virtual void OnMouseButtonDown()
        {
            MousePosition = Input.mousePosition;
            AnchorPosition = MousePosition;
            OnStart.Invoke(this);
        }

        protected virtual void OnMouseButton()
        {
            Vector2 mousePosition = Input.mousePosition;
            Vector2 direction = (mousePosition - AnchorPosition).normalized;
            MousePosition = AnchorPosition + direction * Mathf.Clamp((mousePosition - AnchorPosition).magnitude, 0, Size);
            OnSwerve.Invoke(this);
        }

        protected virtual void OnMouseButtonUp()
        {
            OnRelease.Invoke(this);
        }

    }
}

