using MyGame.UI;
using System;
using UnityEngine;
using CommonGame;
namespace MyGame
{
    [DefaultExecutionOrder(100)]
    public class PlayerManager : MonoBehaviour, IPlayerPawn
    {
        [SerializeField] private PlayerStartSettings _startSettings;
        [SerializeField] private StatsUIChannel _healthUI;
        [SerializeField] private StatsUIChannel _scoreUI;
        [SerializeField] private LevelStateSO _levelState;
        public event Action<IPlayerPawn> OnDeath;

        public bool IsDebug = false;
        [Space(10)]
        public bool InitScoreFromSave = true;
        [Space(10)]

        public bool EnableMovement = true;
        public bool EnableCollisions = true;
        public bool EnableCollecting = true;
        public bool EnableScoreAdding = true;
        public bool EnableHealing = true;
        public bool EnableDamage = true;
        public bool AllowOverrideSpawnPosition = true;
  
        [Space(10)]
        [SerializeField] private PlayerMoveController _movement;
        [Space(10)]
        [SerializeField] private PlayerView _playerView;
        [Space(10)]
        [SerializeField] private PlayerCollider _collisions;
        private PlayerMoveCollisionHandler _movementCollisions;

        private ScoreKeeper _scoreKepper;
        private PlayerCollector _collectableManager;
        private CrystalScoreAdder _scoreAdder;
        private PlayerHealth _health;
        private PlayerCrystalHealer _healer;
        private SimpleDamager _damager;
      

        private void Start()
        {
            if (IsDebug)
            {
                Init();
                Enable();
            }
        }

        private void OnDestroy()
        {
            Kill();
        }
        public void Init()
        {
            if (_startSettings == null)
            {
                Debug.Log("Start settings null. Cannot init");
                return;
            }
            _movement.Init(_startSettings.Movement, _playerView);
            _playerView?.Init(_movement);
            _movementCollisions = new PlayerMoveCollisionHandler(_movement, _collisions);

            if (InitScoreFromSave && _levelState != null)
                _startSettings.Score.CurrentScore = _levelState.CurrentScore;
            _scoreKepper = new ScoreKeeper(_startSettings.Score, _scoreUI, _levelState);
            _collectableManager = new PlayerCollector(_collisions);
            _scoreAdder = new CrystalScoreAdder(_startSettings.Score, _scoreKepper, _collectableManager);

            _health = new PlayerHealth(_startSettings.Health, _healthUI);
            _healer = new PlayerCrystalHealer(_collectableManager, _health,1 );
            _damager = new SimpleDamager(_collisions,_health);

            _health.OnZeroHealth += Kill;
        }
        public void SetSpawnPosition(Vector3 spawnPosition)
        {
            if(AllowOverrideSpawnPosition)
                _startSettings.Movement.StartPosition = spawnPosition;

        }

        public void Enable()
        {
            _playerView?.Enable();

            if (EnableMovement)
                _movement?.EnableMovement();

            if (EnableCollecting)
                _collectableManager?.Enable();
            if (EnableCollisions)
                _movementCollisions?.Enable();

            if (EnableHealing)
                _healer?.Enable();
            if (EnableDamage)
                _damager?.Enable();

            if (EnableScoreAdding)
                _scoreAdder?.Enable();
        }

        private void Kill()
        {
            _movement?.StopMovement();
            _movement?.DisableMovement();
            _playerView?.OnDeath();
            _collectableManager?.Disable();
            _movementCollisions?.Disable();
            _healer?.Disable();
            _damager?.Disable();
            _scoreAdder?.Disable();
            OnDeath?.Invoke(this);
            _playerView.Disable();
            Debug.Log("Player Died");
        }

        public void Subscribe(Action<IPlayerPawn> player)
        {
            OnDeath += player;
        }
    }



}