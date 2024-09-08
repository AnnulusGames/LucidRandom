using System;
using UnityEngine;

namespace GunSystems
{
    [CreateAssetMenu(fileName = "Shoot Config", menuName = "Guns/Shoot Configuration", order = 2)]
    [Serializable]
    public class ShootConfigurationScriptableObject : ScriptableObject
    {
        public LayerMask hitMask;
        public Vector3 spread = new(0.1f, 0.1f, 0.1f);
        public float fireRate = 0.25f;
    }
}