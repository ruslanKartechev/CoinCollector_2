using UnityEngine;
namespace CommonGame
{
    public abstract class LevelLoader : MonoBehaviour
    {
        public abstract LevelStateSO Load(LevelData data);
        public abstract void ClearLevel();
    }
}
