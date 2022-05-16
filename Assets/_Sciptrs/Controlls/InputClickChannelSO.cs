using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace CommonGame.Controlls
{
    [CreateAssetMenu(fileName = "InputClickChannelSO", menuName = "InputEvents/InputClickChannelSO", order = 1)]
    public class InputClickChannelSO : ScriptableObject
    {
        public event Action Click;
        public event Action Release;
        public Vector2 MousePosition;
        public void RaiseEventClick()
        {
            if (Click != null)
                Click.Invoke();
        }
        public void RaiseEventRelease()
        {
            if (Release != null)
                Release.Invoke();
        }
    }
}