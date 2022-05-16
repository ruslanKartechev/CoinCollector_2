
using UnityEngine;
using CommonGame;
namespace MyGame
{
    public class PlayerCamera : MonoBehaviour
    {
        [SerializeField] private CameraShakeChannelSO _shakeChannel;
        [SerializeField] private IShaker _shacker;
        [Space(5)]
        [SerializeField] private CameraFollowerBase _follower;
        [SerializeField] private Camera _cam;

        private void Awake()
        {
            _shacker = GetComponent<IShaker>();
            if (_shacker == null)
                Debug.Log("Shaker not assigned");
            else
                _shakeChannel.OnShakeCamera += OnCameraShake;
            if (_cam != null)
                Camera.SetupCurrent(_cam);

        }

        private void OnEnable()
        {
            _shakeChannel.OnShakeCamera += OnCameraShake;
            _follower.StartFollowing();
        }

        private void OnDisable()
        {
            _shakeChannel.OnShakeCamera -= OnCameraShake;
            _follower.StopFollowing();
        }

        public void OnCameraShake()
        {
            _shacker?.StartShake();
        }
    }
}
