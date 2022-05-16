using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CommonGame
{
    [CreateAssetMenu(fileName = "CoroutineChannelSO", menuName = "SO/CoroutineChannelSO", order = 1)]

    public class CoroutineChannelSO : ScriptableObject
    {
        private ICoroutineRunner _routineRunner;

        public void SetRoutineRunner(ICoroutineRunner runner)
        {
            _routineRunner = runner;
        }

        public ICoroutineRunner GetRoutineRunner()
        {
            if (_routineRunner != null)
                return _routineRunner;
            else
            {
                Debug.LogError("RoutineRunner not assigned");
                return null;
            }

        }
    }
}