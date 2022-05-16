using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace CommonGame
{
    public abstract class LevelInitBase : MonoBehaviour
    {
        [SerializeField] protected LevelStateSO _myState;

        public abstract LevelStateSO InitLevel();
        public abstract void StartLevel();
    }
}