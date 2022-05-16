using UnityEngine;

namespace CommonGame
{
    public abstract class CameraCheckpointPositioner : MonoBehaviour
    {
        public abstract void Init(CameraMoverBase mover);
        public abstract void SetInitialPosition();
        public abstract void SetFinishPosition();
        public abstract void SetDefaultPosition();
    }
}