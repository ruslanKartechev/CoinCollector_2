
using UnityEngine;
namespace MyGame
{
    public class PlayerMoveCollisionHandler
    {
        private IPushbackTarget _mover;
        private IObstacleDetector _wallCollisions;
        public PlayerMoveCollisionHandler(IPushbackTarget mover, IObstacleDetector wallCollisions)
        {
            _mover = mover;
            _wallCollisions = wallCollisions;
        }

        public void Enable()
        {
            if (_wallCollisions != null)
                _wallCollisions.Subscribe(OnWallCollision);
            else
                Debug.Log("Wall collision event sender is null");
        }

        public void Disable()
        {
            if (_wallCollisions != null)
                _wallCollisions.Unsubscribe(OnWallCollision);
            else
                Debug.Log("Wall collision event sender is null");
        }

        public void OnWallCollision(Vector3 point)
        {
            _mover.PushBack(point);
        }
    }


}