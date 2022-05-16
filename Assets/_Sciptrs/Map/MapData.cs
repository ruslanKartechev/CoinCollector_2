using UnityEngine;
namespace MyGame
{

    [CreateAssetMenu(fileName = "MapData", menuName = "SO/MapData", order = 1)]

    public class MapData : ScriptableObject
    {
        public Vector3 CenterPosition;
        public float Width;
        public float Length;
        public float FloorY;
    }
}