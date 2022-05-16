using System;
namespace MyGame
{
    public class PlayerCollector : ICrystalCollector
    {
        private ICollectableDetector _collectEvent;
        public event Action OnCrystalCollected;
        public PlayerCollector(ICollectableDetector _collectableCollisions)
        {
            _collectEvent = _collectableCollisions;
        }

        public void Enable()
        {
            _collectEvent?.Subscribe(OnCollectableCollision);
        }

        public void Disable()
        {
            _collectEvent?.Unsubscribe(OnCollectableCollision);
        }

        #region Events
        void ICrystalCollector.Subscribe(Action action)
        {
            OnCrystalCollected += action;
        }

        void ICrystalCollector.Unsubscribe(Action action)
        {
            OnCrystalCollected -= action;
        }
        #endregion


        public void OnCollectableCollision(ICollectable collectable)
        {
            switch (collectable.GetType())
            {
                case CollectableType.Crystal:
                    collectable?.Collect();
                    OnCrystalCollected?.Invoke();
                    break;
                default:
                    collectable?.Collect();
                    break;
            }
        }
    }



}