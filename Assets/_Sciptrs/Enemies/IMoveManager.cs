using UnityEngine;
namespace MyGame
{
    public interface IMoveManager
    {
        void Move(Vector3 movePos);
        void Stop();
    }



}