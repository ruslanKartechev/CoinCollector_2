using System;
using UnityEngine;
namespace MyGame
{
    public interface IObstacleDetector
    {
        void Subscribe(Action<Vector3> action);
        void Unsubscribe(Action<Vector3> action);
    }

}