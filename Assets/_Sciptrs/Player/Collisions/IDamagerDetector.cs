using System;
namespace MyGame
{
    public interface IDamagerDetector
    {
        void Subscribe(Action<IDamageDealer> action);
        void Unsbscribe(Action<IDamageDealer> action);

    }

}