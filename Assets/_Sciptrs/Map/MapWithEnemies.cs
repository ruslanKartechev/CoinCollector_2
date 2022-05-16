using UnityEngine;
using System.Collections.Generic;
namespace MyGame
{
    [CreateAssetMenu(fileName = "MapWithEnemies", menuName = "SO/MapWithEnemies", order = 1)]
    public class MapWithEnemies : MapWithPlayer
    {
        public List<SpawnInfo> EnemySpawns;
    }


    [System.Serializable]
    public struct SpawnInfo
    {
        public Vector3 Position;
        public float Radius;

    }
}