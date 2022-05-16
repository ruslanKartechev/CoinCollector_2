using UnityEngine;
namespace CommonGame
{
    public interface IViewTransform
    {
        // position
        Vector3 GetPosition();
        float GetY();
        void Update3Position(Vector3 pos);
        void Update2Position(Vector3 pos);
        void UpdateY(float y);

        // rotation
        Quaternion GetRotation();
        float GetYAngle();
        void UpdateYAngle(float y);
        void UpdateRotation(Quaternion rotation);
 

    }


}