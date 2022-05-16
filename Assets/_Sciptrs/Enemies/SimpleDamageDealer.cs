using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyGame
{
    public class SimpleDamageDealer : MonoBehaviour, IDamageDealer
    {
        public int Damage = 1;
        public int GetDamage()
        {
            return Damage;
        }

    }
}