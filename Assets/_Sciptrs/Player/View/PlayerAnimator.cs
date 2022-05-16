using UnityEngine;
namespace MyGame
{
    [System.Serializable]
    public class PlayerAnimator : AnimationControler
    {
        [SerializeField] private Animator _animator;
        private IMoveObservable _moveEvents;

        
        public void Init(IMoveObservable moveEvents)
        {
            _moveEvents = moveEvents;
      
        }

        public override void Enable()
        {
            if(_animator)
                _animator.enabled = true;
            if (_moveEvents != null)
            {
                _moveEvents.SubscribeToStart(OnMoveStart);
                _moveEvents.SubscribeToStop(OnMoveStop);
            }
        }

        public override void Disable()
        {
            if (_animator)
                _animator.enabled = false;
            if (_moveEvents != null)
            {
                _moveEvents.UnsubscribeToStart(OnMoveStart);
                _moveEvents.UnsubscribeToStop(OnMoveStop);
            }
        }

        public void OnDead()
        {
            if (!_animator)
                return;
            _animator.SetBool("IsRunning", false);
            _animator.SetBool("IsDead", false);
        }

        private void OnMoveStart()
        {
            if (!_animator)
                return;
            _animator.SetBool("IsRunning", true);
        }

        private void OnMoveStop()
        {
            if (!_animator)
                return;
            _animator.SetBool("IsRunning", false);
        }

    }



}