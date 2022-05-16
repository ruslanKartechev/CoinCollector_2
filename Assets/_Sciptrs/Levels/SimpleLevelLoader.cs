using UnityEngine;
namespace CommonGame
{
    public class SimpleLevelLoader : LevelLoader
    {
        public Transform levelPoint;
        public override LevelStateSO Load(LevelData data)
        {
            if (levelPoint == null)
                levelPoint = transform;
            GameObject level = Instantiate(data.lvlPF, levelPoint);
            LevelInitBase init = level.GetComponent<LevelInitBase>();
            if(init == null)
            {
                Debug.Log($"Level init script not found {level.gameObject.name}");
                return null;
            }
            return init.InitLevel();
        }
        public override void ClearLevel()
        {

            for (int i = 0; i < levelPoint.childCount; i++)
            {
                GameObject destroyObject = levelPoint.GetChild(i).gameObject;
                if (Application.isPlaying)
                    Destroy(destroyObject);
                else
                    DestroyImmediate(destroyObject);
            }
            
        }
    }
}



