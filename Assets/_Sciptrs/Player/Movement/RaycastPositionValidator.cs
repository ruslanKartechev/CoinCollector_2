using UnityEngine;

namespace MyGame
{
    public class RaycastPositionValidator : MovePositionValidator
    {
        public LayerMask _blockingMask;
        public RaycastPositionValidator(LayerMask blockMask)
        {
            _blockingMask = blockMask;
        }

        public override Vector3 GetCorrectedPosition(Vector3 targetPos, Vector3 startPos, float deadZone)
        {
            Vector3 distanceVector = targetPos - startPos;
            Ray ray = new Ray( startPos, distanceVector);
            if(Physics.Raycast(ray,out RaycastHit hit, distanceVector.magnitude, _blockingMask))
            {
                Vector3 planePoint = new Vector3(hit.point.x, startPos.y, hit.point.z);
                Vector3 allowedPos = planePoint + hit.normal * deadZone;
                return allowedPos;
            }

            return targetPos;
        }
    }


}