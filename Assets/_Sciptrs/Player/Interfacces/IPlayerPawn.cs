using System;
namespace MyGame
{
    public interface IPlayerPawn
    {
        void Init();
        void Enable();
        void Subscribe(Action<IPlayerPawn> player);
    }

}