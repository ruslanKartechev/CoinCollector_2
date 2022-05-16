using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CommonGame
{
    [CreateAssetMenu(fileName = "CamShakeSettings", menuName = "Camera/CamShakeSettings", order = 1)]
    public class SimpleShakerSettings : ScriptableObject
    {
        public float Duration;
        public float Magnitude;
    }
}