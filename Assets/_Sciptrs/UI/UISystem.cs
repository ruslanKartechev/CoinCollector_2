using System.Collections;
using UnityEngine;
using CommonGame.Events;
namespace CommonGame.UI
{
    public class UISystem : MonoBehaviour, ILevelStateObserver
    {

        public bool SelfInit = false;
        [Space(10)]

        [SerializeField] protected LevelStartChannelSO _levelStartChannel;
        [SerializeField] protected LevelLoadChannelSO _levelLoadChannel;
        [SerializeField] protected LevelFinishChannelSO _levelFinishChannel;
        [Space(10)]
        [SerializeField] private PageWithButton _startPage;
        [SerializeField] private FinishPage _finishPage;
        [SerializeField] private PageBase _progressPage;
        [Space(10)]
        [SerializeField]  private LevelStateSO _levelState;
        protected LevelStateSO LevelState { get => _levelState; set => _levelState = value; }

        private void Start()
        {
            if (SelfInit)
            {
                Init();
            }
        }

        public void Init()
        {
            _levelLoadChannel.OnLevelLoaded += OnLevelLoaded;
            _levelFinishChannel.OnLevelFinished += OnLevelFinish;
            _levelStartChannel.OnLevelStarted += OnLevelStart;
            _startPage.OnButtonClick += OnStartButton;
            _finishPage.OnButtonClick += OnFinishButton;
            _finishPage.SetLevelState(_levelState);
        }

        public void OnLevelLoaded(int levelInd)
        {
            _startPage?.ShowPage();
            _startPage?.SetHeader($"LEVEL:  {_levelState.CurrentLevel + 1}");
        }

        public void OnLevelStart()
        {
            _startPage?.HidePage();
            _progressPage?.ShowPage();
        }

        public void OnLevelFinish()
        {
            _finishPage?.ShowPage();
            _progressPage?.HidePage();
            _startPage?.SetHeader($"LEVEL:  {_levelState.CurrentLevel + 1}");
        }

        private void OnStartButton()
        {
            _levelStartChannel?.RaiseEvent();
        }

        private void OnFinishButton()
        {
            Debug.Log($"Level finished button clicked. Current levelState: {_levelState.CurrentResult}");
            switch (_levelState.CurrentResult)
            {

                case LevelResult.Pass:
                    _levelLoadChannel.RaiseEventLoadNext();
                    _finishPage.HidePage();
                    break;
                case LevelResult.Fail:
                    _levelLoadChannel.RaiseEventReload();
                    _finishPage.HidePage();
                    break;
            }
        }

        public void SetLevelState(LevelStateSO state)
        {
            _levelState = state;
        }
    }
}