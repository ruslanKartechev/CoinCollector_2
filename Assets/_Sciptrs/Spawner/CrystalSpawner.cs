
using UnityEngine;
using System.Threading.Tasks;
using System.Threading;
using CommonGame;
namespace MyGame
{

    public class CrystalSpawner : SpawnerBase<ICollectable>
    {
        private CancellationTokenSource _spawnerToken;
        [SerializeField] private GameObject _prefab;
        [SerializeField] private MapData _map;
        [SerializeField] private IObjectPool<IPoolSpawnable<ICollectable>> _pool;
        [SerializeField] private int _maxSearchIterations = 50;
        [SerializeField] GameObjectChannelSO _GoChannel;
        public void Init(MapData map)
        {
            _poolSpawner = new GenericPoolSpawner<ICollectable>(_GoChannel.GetSpawner()) ;
            _map = map;
            _poolSpawner.MaxPoolSize = _settings.Limit;
            _poolSpawner.Parent = gameObject.transform;
            _pool = _poolSpawner.CreateFromPrefab(_prefab);
        }
        private void OnDisable()
        {
            StopSpawner();
        }
        public override void StartSpawner()
        {
            if (_pool == null)
            {
                Debug.Log("Pool was not created");
                return;
            }
            _spawnerToken?.Cancel();
            _spawnerToken = new CancellationTokenSource();
            Spawn(_settings.StartSpawnCount);
            SpawningRoutine(_spawnerToken);
        }

        public override void StopSpawner()
        {
            _spawnerToken?.Cancel();
        }

        private async void SpawningRoutine(CancellationTokenSource token)
        {
            while (token.IsCancellationRequested == false)
            {
                float delay = UnityEngine.Random.Range(_settings.SpawnInterval_min, _settings.SpawnInterval_max);
                if (delay <= 0.01f)
                    delay = 0.01f;
                await Task.Delay((int)(delay * 1000));
                if(this && token.IsCancellationRequested == false)
                {
                    Spawn(_settings.AmountPerSpawn);
                }
                
            }
        }

   
        private void Spawn(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                IPoolSpawnable<ICollectable> collectable = _pool.TakeFromPool();
                if (collectable == null)
                    return;
                GameObject go = collectable.GetGO();
                go.transform.position = GetPosition();
            }    
        }

        private Vector3 GetPosition()
        {
            Vector3 center = _map.CenterPosition;
            float left = center.x - _map.Width / 2;
            float right = center.x + _map.Width / 2;
            float down = center.z - _map.Length / 2;
            float up = center.z + _map.Length / 2;

            Vector3 position = new Vector3();
            float y = _map.FloorY + _spawnedElevation;
            int i = 0;
            do
            {
                float x = UnityEngine.Random.Range(left,right);
                float z = UnityEngine.Random.Range(down,up);
                position = new Vector3(x, y, z);
            } while (CheckPosition(position) == false && i < _maxSearchIterations);
            return position;
        }


        private bool CheckPosition(Vector3 position)
        {
            float rad = _deadZone;
            Collider[] colliders = Physics.OverlapSphere(position,rad,_blockingLayers);
            if (colliders.Length == 0 || colliders == null)
                return true;
            else
                return false;
        }
    }
}