namespace MyGame
{
    public class EnemyCollector
    {
        private ICollectableDetector _collectableDetector;
        private IDamagable _damageTarget;
        private EnemyCollectorSettings _settings;
        public EnemyCollector(ICollectableDetector detector, IDamagable damagable, EnemyCollectorSettings settings)
        {
            _collectableDetector = detector;
            _damageTarget = damagable;
            _settings = settings;
        }

        public void Enable()
        {
            if(_collectableDetector != null)
            {
                _collectableDetector.Subscribe(Collect);
            }
        }

        public void Disable()
        {
            if (_collectableDetector != null)
            {
                _collectableDetector.Unsubscribe(Collect);
            }
        }

        public void Collect(ICollectable collectable)
        {
            if(_settings.DoCollect)
                collectable?.Collect();
            if(_settings.DoDamage)
                _damageTarget?.TakeDamage(_settings.DamagePerCrystal);
        }
    }



}