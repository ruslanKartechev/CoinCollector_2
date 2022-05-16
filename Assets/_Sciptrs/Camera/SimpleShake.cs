using System.Collections;
using UnityEngine;
namespace CommonGame
{
    public class SimpleShake : MonoBehaviour, IShaker
    {
        [Header("Settings")]
        [SerializeField] private SimpleShakerSettings _settings;
        private Coroutine _shaking;
        private Vector3 startLocalPosition;
        [SerializeField] private Transform _shakeTarget;
        public void StartShake()
        {
            if (!this)
            {
                Debug.LogError("problem with cam shake");
                return;
            }
            if (_shaking != null) StopCoroutine(_shaking);
            _shaking = StartCoroutine(Shaking(_settings.Duration, _settings.Magnitude));
        }

        public void StopShake()
        {
            _shakeTarget.localPosition = startLocalPosition;
            if (_shaking != null) StopCoroutine(_shaking);
            _shaking = null;
        }

        private IEnumerator Shaking(float duration, float magnitude)
        {
            float elapsed = 0f;
            startLocalPosition = _shakeTarget.localPosition;
            while(elapsed <= duration)
            {
                _shakeTarget.localPosition = startLocalPosition + Random.onUnitSphere * magnitude;
                elapsed += Time.deltaTime;
                yield return null;
            }
            StopShake();
        }


    }
}