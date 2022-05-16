using System;
using UnityEngine;
namespace CommonGame
{
    [CreateAssetMenu(fileName = "CameraShakeChannelSO", menuName = "EventChannels/CameraShakeChannelSO", order = 1)]
    public class CameraShakeChannelSO : ScriptableObject
    {
        public event Action OnShakeCamera;
        public void RaiseEventCameraShake()
        {
            if (OnShakeCamera != null)
                OnShakeCamera.Invoke();
            else
                Debug.Log("CameraShake action is null");
        }
    }
}