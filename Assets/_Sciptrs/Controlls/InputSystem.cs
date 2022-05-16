using UnityEngine;
namespace CommonGame.Controlls
{
    public class InputSystem : MonoBehaviour, IInputSystem
    {
        [SerializeField] protected ControllManagerBase _manager;
        [SerializeField] private bool IsDebug = true;

        public void Start()
        {
            if(IsDebug)
                Init();
        }
        public void Init()
        {
            Input.simulateMouseWithTouches = true;
            Enable();
        }

        public void Enable()
        {
            _manager.EnableControlls();
        }
        public void Disable()
        {
            _manager.DisableControlls();
        }


    }
}