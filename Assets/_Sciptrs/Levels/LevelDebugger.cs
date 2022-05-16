
using UnityEngine;
using CommonGame.Events;
namespace CommonGame
{
    public class LevelDebugger : MonoBehaviour
    {
        [SerializeField] protected LevelInitBase LevelInit;
        [SerializeField] protected bool DoStartLevel = false;
        [SerializeField] protected LevelStartChannelSO _startChennel;
        [SerializeField] protected LevelLoadChannelSO _levelLoadChannel;
        private bool _started = false;
        public void Start()
        {
            LevelInit.InitLevel().CurrentLevel = 1;
            _startChennel.OnLevelStarted += StartLevel;
            _levelLoadChannel?.OnLevelLoaded?.Invoke(0);

            if (DoStartLevel)
            {
                StartLevel();
            }
        }

        public void StartLevel()
        {
            if(_started == false)
            {
                _started = true;
                LevelInit.StartLevel();
            }
        }



    }
}