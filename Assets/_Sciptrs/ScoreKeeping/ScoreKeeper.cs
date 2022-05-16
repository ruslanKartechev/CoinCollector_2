using System;
using UnityEngine;
using MyGame.UI;
using CommonGame;
namespace MyGame
{
    public class ScoreKeeper : IScoreKeeper
    {
        public PlayerScoreSettings _scoreSettings;
        public event Action<int> OnScoreChange;
        public int CurrentScore { get => _scoreSettings.CurrentScore; }
        private StatsUIChannel _UIChannel;
        private LevelStateSO _levelState;
        public ScoreKeeper(PlayerScoreSettings settings, StatsUIChannel channel, LevelStateSO levelState)
        {
            _scoreSettings = settings;
            _UIChannel = channel;
            _UIChannel?.RaiseEventUpdate(CurrentScore);
            _levelState = levelState;
        }
        public void AddScore(int score)
        {
            _scoreSettings.CurrentScore += score;
            OnScoreChange?.Invoke(_scoreSettings.CurrentScore);
            _UIChannel?.Update(CurrentScore);
            if(_levelState != null)
            {
                _levelState.CurrentScore = CurrentScore;
            }
        }


    }

}
