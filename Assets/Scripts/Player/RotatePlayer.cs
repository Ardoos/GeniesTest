using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Genies.Interview.Touch
{
    public class RotatePlayer : MonoBehaviour
    {
        public bool CanMove
        {
            get
            {
                return !(ignoreIfStartedOverGui && isStartedOverGui);
            }
        }

        [SerializeField] private float rotationSpeed = 1f;
        [SerializeField] private bool ignoreIfStartedOverGui;

        private bool isStartedOverGui;

        private void Update ()
        {
#if (UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR
            if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Began)
            {
                OnTouchBegin (0);
            }
            else if (CanMove && Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Moved)
            {
                OnTouch (-Input.touches[0].deltaPosition.x);
            }
#else
            if (Input.GetMouseButtonDown (0))
            {
                OnTouchBegin (-1);
            }
            else if (CanMove && Input.GetMouseButton (0))
            {
                OnTouch (-Input.GetAxis ("Mouse X"));
            }
#endif
        }

        private void OnTouchBegin (int touchId)
        {
            isStartedOverGui = EventSystem.current.IsPointerOverGameObject (touchId);
        }

        private void OnTouch (float xMove)
        {
            transform.rotation *= Quaternion.AngleAxis (xMove * rotationSpeed, Vector3.up);
        }
    }
}