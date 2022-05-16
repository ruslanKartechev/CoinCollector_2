﻿using UnityEngine;
using UnityEngine.Events;

namespace CommonGame.Events
{
    [CreateAssetMenu(fileName = "LevelStartChannelSO", menuName = "EventChannels/LevelStartChannelSO", order = 1)]
    public class LevelStartChannelSO : ScriptableObject
    {
        public UnityAction OnLevelStarted;
        
        public void RaiseEvent()
        {
            if (OnLevelStarted != null)
                OnLevelStarted.Invoke();
            else
                Debug.Log("OnLevelStarted action is null");
        }
    }
}
