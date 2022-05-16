using UnityEngine;

namespace CommonGame
{
    public abstract class ActorBase : MonoBehaviour, IActor
    {
        public abstract string GetID();
    }
}
