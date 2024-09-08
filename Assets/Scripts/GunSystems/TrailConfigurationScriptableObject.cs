using System;
using UnityEngine;

namespace GunSystems
{
    [CreateAssetMenu(fileName = "Trail Config", menuName = "Guns/Trail Config", order = 4)]
    [Serializable]
    public class TrailConfigurationScriptableObject: ScriptableObject
    {
        public Material material;
        public AnimationCurve widthCurve;
        public float duration = .5f;
        public float minVertexDistance = 0.1f;
        public Gradient colorGradient;

        public float missDistance = 100f;
        public float simulationSpeed = 100f;

    }
}