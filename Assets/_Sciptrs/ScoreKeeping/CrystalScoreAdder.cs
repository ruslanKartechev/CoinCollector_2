namespace MyGame
{
    public class CrystalScoreAdder
    {
        private PlayerScoreSettings _settings;
        private IScoreKeeper _scoreKeeper;
        private ICrystalCollector _collector;
        public CrystalScoreAdder(PlayerScoreSettings settings, IScoreKeeper keeper, ICrystalCollector collector)
        {
            _settings = settings;
            _scoreKeeper = keeper;
            _collector = collector;
        }

        public void Enable()
        {
            _collector.Subscribe(AddScore);
        }

        public void Disable()
        {
            _collector.Unsubscribe(AddScore);
        }

        public void AddScore()
        {
            int score = UnityEngine.Random.Range(_settings.ScoreAdd_min, _settings.ScoreAdd_max);
            _scoreKeeper?.AddScore(score);
        }

    }

}
