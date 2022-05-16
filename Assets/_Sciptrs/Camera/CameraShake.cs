using System.Collections;
using UnityEngine;
namespace CommonGame
{

    public class CameraShake : MonoBehaviour, IShaker
    {
        [Header("Settings")]
        [SerializeField] private CamShakeSettings _settings;
        private Coroutine _shaking;
        private Vector3 startLocalPosition;

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
            transform.localPosition = startLocalPosition;
            if (_shaking != null) StopCoroutine(_shaking);
            _shaking = null;
        }

        private IEnumerator Shaking(float duration, float magnitude)
        {
            float elapsed = 0f;
            startLocalPosition = transform.localPosition;
            while(elapsed <= duration)
            {
                transform.localPosition = startLocalPosition + Random.onUnitSphere * magnitude;
                elapsed += Time.deltaTime;
                yield return null;
            }
            StopShake();
        }


    }
}