using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CommonGame
{
    public interface ICameraFollower
    {
        void SetTarget(Transform target);
    }
    public class PlaneFollower : CameraFollowerBase, ICameraFollower
    {
        [SerializeField] private Transform _followTarget;
        [SerializeField] private Vector3 _targetOffset;
        private Coroutine _following;
        public override void StartFollowing()
        {
            if (_following != null)
                StopCoroutine(_following);
            _following = StartCoroutine(Following());
        }

        public override void StopFollowing()
        {
            if (_following != null)
                StopCoroutine(_following);
        }

        public void SetTarget(Transform target)
        {
            _followTarget = target;
        }

        public void SaveOffset()
        {
            if(_followTarget == null)
            {
                Debug.Log("target not assigned");
                return;
            }
            _targetOffset = transform.position - _followTarget.position;
        }

        private IEnumerator Following()
        {
            while (true)
            {
                transform.position = _followTarget.position + _targetOffset;
                yield return null;
            }
        }

    }
}