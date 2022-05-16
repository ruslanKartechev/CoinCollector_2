using UnityEngine;
namespace CommonGame.UI
{

    public class FinishPage : PageWithButton, ILevelStateObserver
    {
        [SerializeField] private Canvas _canvas;
        [SerializeField] private Animator _anim;
        [SerializeField] private FinishScoreOutput _scoreOutput;

        [SerializeField] private LevelStateSO _levelState;
        private void Awake()
        {
            _button.onClick.AddListener(OnClick);
            HidePage();
        }
        private void OnDisable()
        {
            _scoreOutput.Disable();
        }

        public void SetLevelState(LevelStateSO state)
        {
            _levelState = state;
        }

        public override void ShowPage()
        {
            if (this == null)
                return;
            _canvas.enabled = true;
            _button.interactable = true;
            _anim.enabled = true;
            if(_levelState != null)
            {
                _scoreOutput.ShowScore(_levelState.CurrentScore);
            }
            else
            {
                _scoreOutput.ShowScore(666);
            }
            _anim?.Play("Idle");
        }

        public override void HidePage()
        {
            _canvas.enabled = false;
            _button.interactable = false;
            if(_anim)
                _anim.enabled = false;

        }

        public override void SetHeader(string Text)
        {
            _header.text = Text;
        }

      
    }
}