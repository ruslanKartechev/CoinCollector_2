using System;
using CommonGame;
using UnityEngine;


namespace MyGame
{



    public class CrystalCollectable : MonoBehaviour, ICollectable, IPoolSpawnable<ICollectable>
    {
        [SerializeField] private CollectableType _type;
        [SerializeField] private Animator _animator;
        private IObjectPool<IPoolSpawnable<ICollectable>> _pool;
        public void Collect()
        {
            if(_animator != null)
                _animator.enabled = false;
            if (_pool != null)
                _pool.ReturnToPool(this);
            else
                gameObject.SetActive(false);
        }

        public GameObject GetGO()
        {
            return gameObject;
        }

        public ICollectable GetObject()
        {
            return this;
        }

        public void SetPool(IObjectPool<IPoolSpawnable<ICollectable>> pool)
        {
            _pool = pool;
        }

        CollectableType ICollectable.GetType()
        {
            return _type;
        }
    }
}