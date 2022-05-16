
using System.Collections;
using UnityEngine;
using System;
namespace CommonGame
{

    public class CameraMover : CameraMoverBase
    {
        private Coroutine _moving;
        public override void SetPosition(Vector3 position, Quaternion rotation, float time, Action onFinish = null)
        {
            if(_moving != null)
            {
                StopCoroutine(_moving);
            }
            _moving = StartCoroutine(Moving(position, rotation, time, onFinish));
        }

        public override void SetPositionLocal(Vector3 localPosition, Quaternion localRot, float time, Action onFinish = null)
        {
            if (_moving != null)
            {
                StopCoroutine(_moving);
            }
            _moving = StartCoroutine(MovingLocal(localPosition, localRot, time, onFinish));
        }

        public IEnumerator Moving(Vector3 position, Quaternion rot, float time, Action onFinish = null)
        {
            float elapsed = 0f;
            Vector3 startPos = transform.position;
            Quaternion startRot = transform.rotation;
            while (elapsed <= time)
            {

                transform.localPosition = Vector3.Lerp(startPos, position, elapsed / time);
                transform.localRotation = Quaternion.Lerp(startRot, rot, elapsed / time);
                elapsed += Time.deltaTime;
                yield return null;
            }
            transform.position = position;
            transform.rotation = rot;
            onFinish?.Invoke();

        }

        public IEnumerator MovingLocal(Vector3 localPos, Quaternion localRot, float time, Action onFinish = null)
        {
            float elapsed = 0f;
            Vector3 startPos = transform.localPosition;
            Quaternion startRot = transform.localRotation;
            while (elapsed <= time)
            {

                transform.localPosition = Vector3.Lerp(startPos, localPos, elapsed / time);
                transform.localRotation = Quaternion.Lerp(startRot, localRot, elapsed / time);
                elapsed += Time.deltaTime;
                yield return null;
            }
            transform.localPosition = localPos;
            transform.localRotation = localRot;
            onFinish?.Invoke();
        }

    }
}
