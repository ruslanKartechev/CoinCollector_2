
using UnityEngine;
using CommonGame;
namespace MyGame
{

    public class EnemyManager : MonoBehaviour, IEnemyPawn, IPoolSpawnable<EnemyManager>
    {

        public PawnMoveSettings _movementSettings;
        public RandomMoverSettings _AIMoverSettings;
        public SimpleHealthSettings _healthSettings;
        public EnemyCollectorSettings _collectableSettings;

        [SerializeField] private EnemyMovementController _movement;
        [Space(5)]
        public bool DoRandomMove = true;
        [SerializeField] private SimpleAIRandomMover _moverAI;
        [Space(5)]
        [SerializeField] private ViewTransform _view;
        [Space(5)]
        [SerializeField] private PlayerCollider _collisions;
        [Space(5)]
        public bool EnableCollisions = true;
        private PlayerMoveCollisionHandler _movementCollisions;
        [Space(5)]
        public bool EnableCollector = true;
        private EnemyCollector _collector;
        [Space(5)]
        private EnemyHealth _health;
        public bool EnableDamage = true;
        private SimpleDamager _damager;
        
        private IObjectPool<IPoolSpawnable<EnemyManager>> _pool;

        private MapData _map;

        public MapData Map { get => _map; set => _map = value; }
        public Vector3 StartPosition { get; set; }

        public void Init()
        {
            if(_map == null)
            {
                Debug.Log("Map is null");
                return;
            }
            _movementSettings.StartPosition = StartPosition;
            _health = new EnemyHealth(_healthSettings);
            _damager = new SimpleDamager(_collisions,_health);
            _collector = new EnemyCollector(_collisions, _health, _collectableSettings);
            _movementCollisions = new PlayerMoveCollisionHandler(_movement, _collisions);
            _moverAI = new SimpleAIRandomMover(_AIMoverSettings, _map, _movement);
            _movement.Init(_movementSettings,_view);


        }

        public void Activate()
        {
            _movement?.Init(_movementSettings,_view);
            if (EnableDamage)
                _damager?.Enable();
            if (EnableCollector)
                _collector?.Enable();
            if (EnableCollisions)
                _movementCollisions?.Enable();
            if (DoRandomMove)
                _moverAI?.Enable();

            if(_health != null)
                _health.OnZeroHealth += Kill;
        }

        public void Deactivate()
        {
            _damager?.Disable();
            _collector?.Disable();
            _movementCollisions?.Disable();
            _moverAI?.Disable();
        }

        private void OnDisable()
        {
            Deactivate();
        }

        public void Kill()
        {
            Deactivate();
            _pool.ReturnToPool(this);
        }

        public GameObject GetGO()
        {
            return gameObject;
        }

        public void SetPool(IObjectPool<IPoolSpawnable<EnemyManager>> pool)
        {
            _pool = pool;
        }
        public EnemyManager GetObject()
        {
            return this;
        }

    }



}