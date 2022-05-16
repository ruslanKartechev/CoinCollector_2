
namespace MyGame
{

    public class SimpleDamager
    {
        public IDamagerDetector _damageDetector;
        public IDamagable _target;

        public SimpleDamager(IDamagerDetector damageDetector, IDamagable target)
        {
            _damageDetector = damageDetector;
            _target = target;
        }

        public void Enable()
        {
            _damageDetector.Subscribe(OnDamager);
        }

        public void Disable()
        {
            _damageDetector.Unsbscribe(OnDamager);
        }

        public void OnDamager(IDamageDealer dealer)
        {
            _target?.TakeDamage(dealer.GetDamage());
        }

    }
}