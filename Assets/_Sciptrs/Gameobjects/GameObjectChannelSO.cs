using UnityEngine;

namespace CommonGame
{
    [CreateAssetMenu(fileName = "GameObjectChannel", menuName = "SO/GameObjectChannel", order = 1)]
    public class GameObjectChannelSO : ScriptableObject
    {
        protected IGameobjectSpawner _spawner;

        public void SetSpawner(IGameobjectSpawner spawner)
        {
            _spawner = spawner;
        }
        public IGameobjectSpawner GetSpawner()
        {
            return _spawner;
        }
    }


}
