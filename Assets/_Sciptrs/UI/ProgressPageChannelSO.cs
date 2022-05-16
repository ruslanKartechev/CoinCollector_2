using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace CommonGame.UI
{
    [CreateAssetMenu(fileName = "ProgressPageChannelSO", menuName = "SO/ProgressPageChannelSO", order = 1)]

    public class ProgressPageChannelSO : ScriptableObject
    {
        public Action<float> SetProgress;
        public Action Refresh;
        public void RaiseSetPregress(float amount)
        {
            if (SetProgress != null)
            {
                SetProgress.Invoke(amount);
            }
            else
                Debug.Log("SetProgress action not assigned");
        }
        public void RaiseRefresh()
        {
            if (Refresh != null)
                Refresh.Invoke();
            else
                Debug.Log("Refresh action is null");
        }
    }
}
