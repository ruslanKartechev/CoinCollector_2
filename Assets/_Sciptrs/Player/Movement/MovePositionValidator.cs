using UnityEngine;

namespace MyGame
{
    public abstract class MovePositionValidator
    {
        public abstract Vector3 GetCorrectedPosition(Vector3 targetPos, Vector3 startPos, float deadZone);
    }


}