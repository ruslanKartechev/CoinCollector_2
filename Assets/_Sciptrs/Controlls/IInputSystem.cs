using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CommonGame.Controlls
{
    public interface IInputSystem
    {
        void Init();
        void Enable();
        void Disable();
    }
}