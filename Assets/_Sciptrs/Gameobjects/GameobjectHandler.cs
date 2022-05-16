using UnityEngine;
using System.Threading.Tasks;

namespace CommonGame
{
    public class GameobjectHandler : MonoBehaviour, IGameobjectSpawner
    {
        [SerializeField] private GameObjectChannelSO _goChannel;

        private void Awake()
        {
            _goChannel.SetSpawner(this);
        }

        public void DestroyGO(GameObject go)
        {
            if(go!= null)
                Destroy(go);
        }

        public GameObject InstantiatePF(GameObject pf)
        {
            return Instantiate(pf);
        }

        public GameObject InstantiatePF(GameObject pf, Transform parent)
        {
            return Instantiate(pf,parent);

        }

        public GameObject InstantiatePF(GameObject pf, Transform parent, Vector3 worldPos)
        {
            GameObject spawned = Instantiate(pf, parent);
            spawned.transform.position = worldPos;
            return spawned;
        }
    }
}
