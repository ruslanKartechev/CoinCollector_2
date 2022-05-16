using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace CommonGame.Controlls
{
    [CreateAssetMenu(fileName = "InputAttackChannelSO", menuName = "InputEvents/InputAttackChannelSO", order = 1)]
    public class InputAttackChannelSO : ScriptableObject
    {
        public event Action Attack;
        public void RaiseEventAttack()
        {
            if (Attack != null)
                Attack.Invoke();
        }
    }
}