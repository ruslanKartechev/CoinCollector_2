using UnityEngine;
using CommonGame;
namespace MyGame
{
    public abstract class SpawnerBase<T> : MonoBehaviour where T : class
    {
        protected GenericPoolSpawner<T> _poolSpawner;
        [SerializeField] protected SpawningSettings _settings;
        [SerializeField] protected LayerMask _blockingLayers;
        [SerializeField] protected float _deadZone = 0.5f;
        [SerializeField] protected float _spawnedElevation = 1;
        public abstract void StartSpawner();
        public abstract void StopSpawner();
    }
}