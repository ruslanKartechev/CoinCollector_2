using CommonGame;

namespace MyGame
{
    [System.Serializable]
    public class PlayerView : ViewTransform
    {
        public PlayerAnimator _animator;

        public void Init(IMoveObservable moveEvents)
        {
            _animator.Init(moveEvents);
        }

        public void Enable()
        {
            _animator.Enable();
            _transform.gameObject.SetActive(true);

        }

        public void Disable()
        {
            _animator.Disable();
            _transform.gameObject.SetActive(false);
        }

        public void OnDeath()
        {
            _animator.OnDead();
        }
    }
}