using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Genies.Interview.Variables
{
    [CreateAssetMenu]
    public class ColorVariable : ScriptableObject
    {
        public Color Value;

        public void SetValue (Color value)
        {
            Value = value;
        }
    }
}