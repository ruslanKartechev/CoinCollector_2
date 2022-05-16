using UnityEngine;
using System;
namespace MyGame
{

    public class PlayerCollider : CollisionDetector, IObstacleDetector, ICollectableDetector, IDamagerDetector
    {
        public event Action<Vector3> OnWallCollision;
        public event Action<ICollectable> OnCollectableCollision;
        public event Action<IDamageDealer> OnDamagableCollision;

        #region EventSubsription
        
        void IObstacleDetector.Subscribe(Action<Vector3> action)
        {
            OnWallCollision += action;
        }

        void IObstacleDetector.Unsubscribe(Action<Vector3> action)
        {
            OnWallCollision -= action;
        }

        void ICollectableDetector.Subscribe(Action<ICollectable> action)
        {
            OnCollectableCollision += action;
        }

        void ICollectableDetector.Unsubscribe(Action<ICollectable> action)
        {
            OnCollectableCollision -= action;
        }

        void IDamagerDetector.Subscribe(Action<IDamageDealer> action)
        {
            OnDamagableCollision += action;
        }
        void IDamagerDetector.Unsbscribe(Action<IDamageDealer> action)
        {
            OnDamagableCollision -= action;
        }
        #endregion


        private void OnCollisionEnter(Collision collision)
        {
            RaiseOnCollision(collision.collider.gameObject);
            switch (collision.gameObject.tag)
            {
                case GameTags.Collectable:
                    ICollectable target = collision.gameObject.GetComponent<ICollectable>();
                    if(target == null)
                    {
                        Debug.Log($"Collectable interface not found: {collision.gameObject.name}");
                        break;
                    }
                    else
                    {
                        OnCollectableCollision?.Invoke(target);
                    }
                    break;
                case GameTags.StaticWall:
                    OnWallCollision?.Invoke(collision.contacts[0].point);
                    break;
                default:
                    IDamageDealer dealer = collision.gameObject.GetComponent<IDamageDealer>();
                    if (dealer != null)
                        OnDamagableCollision?.Invoke(dealer);
                    break;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            RaiseOnTrigger(other.gameObject);
            switch (other.gameObject.tag)
            {
                case GameTags.Collectable:
                    ICollectable target = other.gameObject.GetComponent<ICollectable>();
                    if (target == null)
                    {
                        Debug.Log($"Collectable interface not found: {other.gameObject.name}");
                        break;
                    }
                    else
                    {
                        OnCollectableCollision.Invoke(target);
                    }
                    break;
                case GameTags.StaticWall:
                    OnWallCollision?.Invoke(other.ClosestPoint(transform.position));
                    break;
            }
        }

    }

}