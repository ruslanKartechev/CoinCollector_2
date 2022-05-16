using UnityEngine;
using System;
namespace MyGame
{
    public interface IPoolCollectable
    {
        void Subscribe(Action<IPoolCollectable> notifier);
        GameObject GetGO();
    }
}
