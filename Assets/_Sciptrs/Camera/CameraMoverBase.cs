using UnityEngine;
using System;
namespace CommonGame
{
    public abstract class CameraMoverBase : MonoBehaviour
    {
        public abstract void SetPosition(Vector3 position, Quaternion rotation, float time, Action onFinish = null);
        public abstract void SetPositionLocal(Vector3 localPosition, Quaternion localRotation, float time, Action onFinish = null);

    }
}
