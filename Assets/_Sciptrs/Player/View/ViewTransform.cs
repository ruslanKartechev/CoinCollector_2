using UnityEngine;

namespace CommonGame
{
    [System.Serializable]
    public class ViewTransform : IViewTransform
    {
        public Transform _transform;
        #region PositionSet
        public Vector3 GetPosition()
        {
            return _transform.position;
        }
        public float GetY()
        {
            return _transform.position.y;
        }

        public void Update3Position(Vector3 position)
        {
            _transform.position = position;
        }

        public void Update2Position(Vector3 position)
        {
            _transform.position = new Vector3(position.x, _transform.position.y, position.z);
        }

        public void UpdateY(float y)
        {
            _transform.position = new Vector3(_transform.position.x, y, _transform.position.z);
        }
        #endregion
        #region Rotation
        public Quaternion GetRotation()
        {
            return _transform.rotation;
        }

        public float GetYAngle()
        {
            return _transform.eulerAngles.y;
        }
        public void UpdateYAngle(float y)
        {
            _transform.eulerAngles = new Vector3(_transform.eulerAngles.x, y, _transform.eulerAngles.z);
        }

        public void UpdateRotation(Quaternion rotation)
        {
            _transform.rotation = rotation;
        }

        #endregion
    }
}