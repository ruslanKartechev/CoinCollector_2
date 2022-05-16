using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CommonGame
{
    public class CoroutineRunner : MonoBehaviour, ICoroutineRunner
    {

        //[SerializeField] private 


       
        public Coroutine StartRoutine(IEnumerator enumerator)
        {
            return StartCoroutine(enumerator);
        }

        public void StopRoutine(Coroutine routine)
        {
            if (routine != null)
                StopCoroutine(routine);
        }

    }
}