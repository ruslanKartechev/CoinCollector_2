using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CommonGame
{
    public abstract class CameraFollowerBase : MonoBehaviour
    {
        public abstract void StartFollowing();
        public abstract void StopFollowing();


    }
}