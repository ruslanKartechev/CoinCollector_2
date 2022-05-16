using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyGame
{

    [CreateAssetMenu(fileName = "PlayerStartSettings", menuName = "SO/PlayerStartSettings", order = 1)]

    public class PlayerStartSettings : ScriptableObject
    {
        public SimpleHealthSettings Health;
        public PlayerScoreSettings Score;
        public PawnMoveSettings Movement;

    }
}