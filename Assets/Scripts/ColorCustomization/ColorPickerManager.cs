using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI.Extensions.ColorPicker;
using Genies.Interview.Variables;
using Genies.Interview.Events;

namespace Genies.Interview.ColorCustomization
{
    public class ColorPickerManager : MonoBehaviour
    {
        public ColorVariable ColorToChange
        {
            private get;
            set;
        }

        [SerializeField] ColorPickerControl colorPickerControl;
        [SerializeField] private GameEvent startPickEvent;
        [SerializeField] private GameEvent stopPickEvent;
        [SerializeField] List<ColorChangeGameEvent> colorChangeGameEvents;
        private GameEvent currentPickEvent;

        public void StartPickColor (GameEvent pickEvent)
        {
            if (pickEvent != currentPickEvent)
            {
                if (currentPickEvent != null)
                {
                    currentPickEvent.Raise ();
                }
                startPickEvent.Raise ();
                currentPickEvent = pickEvent;
                ColorToChange = GetColorForEvent (currentPickEvent);
            }
            else
            {
                stopPickEvent.Raise ();
                currentPickEvent = null;
                ColorToChange = null;
            }
        }

        private ColorVariable GetColorForEvent (GameEvent gameEvent)
        {
            foreach (var colorChangeGameEvent in colorChangeGameEvents)
            {
                if (colorChangeGameEvent.gameEvent == gameEvent)
                {
                    return colorChangeGameEvent.color;
                }
            }
            return null;
        }

        private void OnColorChanged (float hue, float saturation, float brightness)
        {
            //Saturation & Brightness set to 1, because we only set hue
            Color color = Color.HSVToRGB (hue, 1f, 1f);
            UpdateColor (color);
        }

        private void UpdateColor (Color color)
        {
            if (ColorToChange != null)
            {
                ColorToChange.SetValue (color);
            }
        }

        private void OnEnable ()
        {
            colorPickerControl.onHSVChanged.AddListener (OnColorChanged);
        }

        private void OnDisable ()
        {
            colorPickerControl.onHSVChanged.RemoveListener (OnColorChanged);
        }
    }

    [Serializable]
    public struct ColorChangeGameEvent
    {
        public GameEvent gameEvent;
        public ColorVariable color;
    }
}