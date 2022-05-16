using System;
namespace MyGame
{
    public interface ICollectableDetector
    {
        void Subscribe(Action<ICollectable> action);
        void Unsubscribe(Action<ICollectable> action);
    }

}