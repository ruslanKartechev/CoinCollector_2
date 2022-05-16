
using UnityEngine;
using System;
namespace CommonGame
{
    public enum GameState {Paused, Playing }
    public enum LevelResult { Fail, Pass }


    [CreateAssetMenu(fileName = "LevelStateSO", menuName = "SO/LevelStateSO", order = 1)]

    public class LevelStateSO : ScriptableObject
    {
        public LevelStateSO() { }
        public LevelStateSO(int level)
        {
            CurrentLevel = level;
        }
        public GameState CurrentState = 0;
        public LevelResult CurrentResult = 0;
        public int CurrentLevel = 0;
        public event Action OnLevelStateUpdate;
        public event Action<int> OnScoreUpdate;

        public int CurrentScore = 0;
        public float CurrentProgress = 0;

        public void UpdateState(LevelResult result)
        {
            CurrentResult = result;
        }

        public void Pause()
        {
            CurrentState = GameState.Paused;
            RaiseStateUpdated();

        }
        public void Resume()
        {
            CurrentState = GameState.Playing;
            RaiseStateUpdated();

        }

        public void RaiseStateUpdated()
        {
            OnLevelStateUpdate?.Invoke();
        }

        public void Clear()
        {
            CurrentState = GameState.Paused;
            CurrentResult = LevelResult.Fail;
            CurrentScore = 0;
            CurrentProgress = 0f;
        }

        public void SetScore(int score)
        {
            CurrentScore = score;
            OnScoreUpdate?.Invoke(CurrentScore);
        }
    }

}