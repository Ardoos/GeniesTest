using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Genies.Interview.Variables;
using Genies.Interview.Events;

namespace Genies.Interview.ColorCustomization
{
    public class MaterialsColor : MonoBehaviour
    {
        public ColorVariable color;
        [SerializeField] private List<Material> materials;

        private void Update ()
        {
            UpdateMaterials ();
        }

        public void UpdateMaterials ()
        {
            for (int i = 0; i < materials.Count; i++)
            {
                materials[i].color = color.Value;
            }
        }
    }
}