using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Genies.Interview.UI
{
    public class ActiveableButton : MonoBehaviour
    {
        [SerializeField] private Image buttonImage;
        [SerializeField] private Color activeColor;
        [SerializeField] private Color normalColor;

        public bool IsActive
        {
            get
            {
                return isActive;
            }
            set
            {
                isActive = value;
                if (buttonImage != null)
                {
                    buttonImage.color = IsActive ? activeColor : normalColor;
                }
            }
        }

        [SerializeField] private bool isActive;

        private void Awake ()
        {
            if (buttonImage == null)
            {
                buttonImage = GetComponent<Image> ();
            }
        }

        public void ChangeButtonState ()
        {
            IsActive = !IsActive;
        }
    }
}