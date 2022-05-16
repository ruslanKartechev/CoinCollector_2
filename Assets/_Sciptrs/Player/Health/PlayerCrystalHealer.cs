

namespace MyGame
{
    [System.Serializable]
    public class PlayerCrystalHealer
    {
        private IHealable _healTarget;
        private ICrystalCollector _crystalCollector;
        private int _healAmount = 1;

        public PlayerCrystalHealer(ICrystalCollector crystalEvents, IHealable healTarget, int healPerCrystal)
        {
            _crystalCollector = crystalEvents;
            _healTarget = healTarget;
            _healAmount = healPerCrystal;
        }

        public void Enable()
        {
            _crystalCollector?.Subscribe(OnCrystal);
        }

        public void Disable()
        {
            _crystalCollector?.Unsubscribe(OnCrystal);
        }

        public void OnCrystal()
        {
            _healTarget?.Heal(_healAmount);
        }
    }

}