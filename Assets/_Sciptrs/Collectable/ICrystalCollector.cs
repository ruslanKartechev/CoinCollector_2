using System;


namespace MyGame
{
    public interface ICrystalCollector
    {
        void Subscribe(Action action);
        void Unsubscribe(Action action);
    }
}
