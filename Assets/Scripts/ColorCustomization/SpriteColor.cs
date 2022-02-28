using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Genies.Interview.Variables;
using Genies.Interview.Events;

namespace Genies.Interview.ColorCustomization
{
    public class SpriteColor : MonoBehaviour
    {
        public ColorVariable color;
        [SerializeField] private Image sprite;

        private void Update ()
        {
            UpdateSpriteColor ();
        }

        public void UpdateSpriteColor ()
        {
            sprite.color = color.Value;
        }
    }
}