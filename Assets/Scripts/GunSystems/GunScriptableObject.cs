using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

namespace GunSystems
{
    [CreateAssetMenu(fileName = "Gun", menuName = "Guns/Gun", order = 0)]
    [Serializable]
    public class GunScriptableObject : ScriptableObject
    {
        public GunType gunType;
        public GameObject modelPrefab;
        public Vector3 spawnPoint;
        public Vector3 spawnRotation;

        public ShootConfigurationScriptableObject shootConfig;
        public TrailConfigurationScriptableObject trailConfig;

        private MonoBehaviour _activeMonoBehaviour;
        private GameObject _model;
        private float _lastShotTime;
        private ParticleSystem _shootSystem;
        private ObjectPool<TrailRenderer> _trailPool;

        public void Spawn(Transform parent, MonoBehaviour activeMonoBehaviour)
        {
            this._activeMonoBehaviour = activeMonoBehaviour;
            _lastShotTime = 0;
            _trailPool = new ObjectPool<TrailRenderer>(CreateTrail);

            _model = Instantiate(modelPrefab, parent, false);
            _model.transform.SetPositionAndRotation(spawnPoint, Quaternion.Euler(spawnRotation));

            _shootSystem = _model.GetComponentInChildren<ParticleSystem>();
        }

        public void Shoot()
        {
            if (Time.time > shootConfig.fireRate + _lastShotTime)
            {
                _lastShotTime = Time.time;
                _shootSystem.Play();

                Vector3 shootDirection = _model.transform.forward + new Vector3(
                    UnityEngine.Random.Range(-shootConfig.spread.x, shootConfig.spread.x),
                    UnityEngine.Random.Range(-shootConfig.spread.y, shootConfig.spread.y),
                    UnityEngine.Random.Range(-shootConfig.spread.z, shootConfig.spread.z));
                shootDirection.Normalize();

                Vector3 shootPosition = _shootSystem.transform.position;
                if (Physics.Raycast(shootPosition, shootDirection, out RaycastHit hit,
                        float.MaxValue, shootConfig.hitMask))
                {
                    _activeMonoBehaviour.StartCoroutine(PlayTrail(shootPosition, hit.point, hit));
                }
                else
                {
                    var shootEndPosition = shootPosition + shootDirection * trailConfig.missDistance;
                    _activeMonoBehaviour.StartCoroutine(
                        PlayTrail(shootPosition, shootEndPosition, new RaycastHit())
                    );
                }
            }
        }

        private IEnumerator PlayTrail(Vector3 startPoint, Vector3 endPoint, RaycastHit hit)
        {
            TrailRenderer trailInstance = _trailPool.Get();
            trailInstance.gameObject.SetActive(true);
            trailInstance.transform.position = startPoint;
            yield return null;

            trailInstance.emitting = true;
            float distance = Vector3.Distance(startPoint, endPoint);
            float remainingDistance = distance;
            while (remainingDistance > 0)
            {
                trailInstance.transform.position =
                    Vector3.Lerp(startPoint, endPoint, Mathf.Clamp01(1 - remainingDistance / distance));
                remainingDistance -= trailConfig.simulationSpeed * Time.deltaTime;
                yield return null;
            }

            trailInstance.transform.position = endPoint;
            yield return new WaitForSeconds(trailConfig.duration);
            yield return null;
            trailInstance.emitting = false;
            trailInstance.gameObject.SetActive(false);
            _trailPool.Release(trailInstance);
        }

        private TrailRenderer CreateTrail()
        {
            GameObject instance = new GameObject("Bullet Trail");
            TrailRenderer trail = instance.AddComponent<TrailRenderer>();
            trail.colorGradient = trailConfig.colorGradient;
            trail.material = trailConfig.material;
            trail.widthCurve = trailConfig.widthCurve;
            trail.time = trailConfig.duration;
            trail.minVertexDistance = trailConfig.minVertexDistance;

            trail.emitting = false;
            trail.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;

            return trail;
        }
    }
}