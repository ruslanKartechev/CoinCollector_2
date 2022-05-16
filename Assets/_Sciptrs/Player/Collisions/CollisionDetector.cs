using System;
using UnityEngine;
namespace MyGame
{
    public abstract class CollisionDetector : MonoBehaviour
    {
        public event Action<GameObject> OnCollision;
        public event Action<GameObject> OnTrigger;
        protected void RaiseOnCollision(GameObject go)
        {
            OnCollision?.Invoke(go);
        } 
        protected void RaiseOnTrigger(GameObject go)
        {
            OnTrigger?.Invoke(go);
        }
    }

}