
using UnityEngine;
namespace CommonGame.Data {
    [CreateAssetMenu(fileName = "DataGameMain", menuName = "SO/DataGameMain", order = 1)]
    public class DataGameMain : ScriptableObject
    {
       

        [Header("Sound")]
        [Space(10)]
        public bool UseSound = true;
        public bool PlayMusic = true;
    }
}