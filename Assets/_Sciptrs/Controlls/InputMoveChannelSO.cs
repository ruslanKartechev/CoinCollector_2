using System;
using UnityEngine;

namespace CommonGame.Controlls
{
    [CreateAssetMenu(fileName = "InputEventChannelSO", menuName = "InputEvents/InputEventChannelSO", order = 1)]
    public class InputMoveChannelSO : ScriptableObject
    {
        public event Action Up;
        public event Action Down;
        public event Action Right;
        public event Action Left;
        public void RaiseEventUp()
        {
            if (Up != null)
                Up.Invoke();
        }
        public void RaiseEventDown()
        {
            if (Down != null)
                Down.Invoke();
        }
        public void RaiseEventLeft()
        {
            if (Left != null)
                Left.Invoke();
        }
        public void RaiseEventRight()
        {
            if (Right != null)
                Right.Invoke();
        }

    }


}