
using UnityEngine;
using CommonGame;
using CommonGame.Events;
namespace MyGame
{
    
    public class PlayerSpawner : MonoBehaviour
    {
        [SerializeField] LevelStateSO _levelState;
        [SerializeField] LevelFinishChannelSO _levelFinishChannel;
        [Space(10)]
        [SerializeField] private MapWithPlayer _map;
        [SerializeField] protected LayerMask _blockingLayers;
        [SerializeField] private int _maxSearchIterations = 50;
        [SerializeField] private PlayerManager _prefab;

        private PlayerManager _spawned;
        public void SpawnPlayer()
        {

            SpawnInfo spawn = _map.PlayerSpawn;
            Vector3 position = GetPositionAroundSpawner(spawn.Position, spawn.Radius);
            PlayerManager player = Instantiate(_prefab, transform);
            player.SetSpawnPosition(position);
            player.IsDebug = false;
            player.Init();
            player.Subscribe(OnPlayerDead);
            _spawned = player;
        }

        public void EnablePlayer()
        {
            _spawned.Enable();
        }

        public void OnPlayerDead(IPlayerPawn pawn)
        {
            _levelState.CurrentState = GameState.Paused;
            _levelState.CurrentResult = LevelResult.Fail;
            _levelState.RaiseStateUpdated();
            _levelFinishChannel.RaiseEvent();
        }
        private Vector3 GetPositionAroundSpawner(Vector3 spawnerPosition, float rad)
        {
            Vector3 mapCenter = _map.CenterPosition;
            Vector3 center = spawnerPosition;

            float left = mapCenter.x - rad;
            float right = mapCenter.x + rad;
            float up = mapCenter.z + rad;
            float down = mapCenter.z - rad;

            float leftB = center.x - _map.Width / 2;
            float rightB = center.x + _map.Width / 2;
            float downB = center.z - _map.Length / 2;
            float upB = center.z + _map.Length / 2;

            if (left < leftB)
                left = leftB;
            if (right > rightB)
                right = rightB;
            if (up > upB)
                up = upB;
            if (down < downB)
                down = downB;

            Vector3 position = new Vector3();
            float y = _map.FloorY;
            int i = 0;
            do
            {
                float x = UnityEngine.Random.Range(left, right);
                float z = UnityEngine.Random.Range(down, up);
                position = new Vector3(x, y, z);
            } while (CheckPosition(position, rad) == false && i < _maxSearchIterations);
            return position;

        }


        private bool CheckPosition(Vector3 position, float rad)
        {
            Collider[] colliders = Physics.OverlapSphere(position, rad, _blockingLayers);
            if (colliders.Length == 0 || colliders == null)
                return true;
            else
                return false;
        }
    }
}