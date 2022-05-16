
using UnityEngine;
namespace MyGame
{
    [System.Serializable]
    public struct PawnMoveSettings
    {
        public Vector3 StartPosition;
        public float StartAngle;
        public float NormalSpeed;
        public float RotationSpeed;
        public float DeadZone;

    }
}