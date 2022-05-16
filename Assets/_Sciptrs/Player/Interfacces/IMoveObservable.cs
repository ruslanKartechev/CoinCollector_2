using System;
namespace MyGame
{
    public interface IMoveObservable
    {
        public  void SubscribeToStart(Action action);
        public void SubscribeToStop(Action action);
        public void UnsubscribeToStart(Action action);
        public void UnsubscribeToStop(Action action);
    }


}