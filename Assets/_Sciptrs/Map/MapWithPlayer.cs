using UnityEngine;
namespace MyGame
{
    [CreateAssetMenu(fileName = "MapWithPlayer", menuName = "SO/MapWithPlayer", order = 1)]

    public class MapWithPlayer : MapData
    {
        public SpawnInfo PlayerSpawn;
    }
}