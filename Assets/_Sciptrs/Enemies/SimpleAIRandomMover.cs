
using UnityEngine;
using System.Threading.Tasks;
using System.Threading;
namespace MyGame
{
    public class SimpleAIRandomMover
    {
        private RandomMoverSettings _settings;
        private CancellationTokenSource _token;
        private MapData _map;
        private IMoveManager _mover;

        public SimpleAIRandomMover(RandomMoverSettings settings, MapData map, IMoveManager mover)
        {
            _settings = settings;
            _map = map;
            _mover = mover;
        }

        public void Enable()
        {
            _token?.Cancel();
            _token = new CancellationTokenSource();
            MoveRoutine();
        }

        public void Disable()
        {
            _token?.Cancel();
            _mover?.Stop();
        }
        private async void MoveRoutine()
        {
            while(_token.IsCancellationRequested == false)
            {
                float delay = UnityEngine.Random.Range(_settings.MoveDelay_min, _settings.MoveDelay_max);
                if (delay < 0.5f)
                    delay = 0.5f;
                await Task.Delay((int)(delay*1000));
                if(this!=null && _token.IsCancellationRequested == false)
                {
                    Vector3 pos = GetRandomPosition();
                    _mover.Move(pos);
                }
            }
        }

        private Vector3 GetRandomPosition()
        {
            Vector3 center = _map.CenterPosition;
            float left = center.x - _map.Width / 2;
            float right = center.x + _map.Width / 2;
            float down = center.z - _map.Length / 2;
            float up = center.z + _map.Length / 2;

            Vector3 position = new Vector3();
            float x = UnityEngine.Random.Range(left, right);
            float z = UnityEngine.Random.Range(down, up);
            float y = _map.FloorY;
            position = new Vector3(x, y, z);
            return position;
        }

    }



}