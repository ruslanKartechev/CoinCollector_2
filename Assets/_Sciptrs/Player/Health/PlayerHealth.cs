using UnityEngine;
using System;
using MyGame.UI;
namespace MyGame
{
    public class PlayerHealth: IDamagable, IHealable
    {
        public bool TakeDamage = true;
        public event Action OnDamaged;
        public event Action OnHealed;
        public event Action OnZeroHealth;
        public int CurrentHealth { get => _settings.CurrentHealth; }
        
        [SerializeField] private SimpleHealthSettings _settings;
        private StatsUIChannel _UIChannel;

        public PlayerHealth(SimpleHealthSettings settings, StatsUIChannel healthChannel)
        {
            _settings = settings;
            _UIChannel = healthChannel;
            _UIChannel?.RaiseEventUpdate(CurrentHealth);

        }

        void IDamagable.TakeDamage(int damage)
        {
            _settings.CurrentHealth -= damage;
            OnDamaged?.Invoke();
            if (_settings.CurrentHealth <= 0)
                OnZeroHealth?.Invoke();
            _UIChannel?.Update(CurrentHealth);


        }

        public void Heal(int heal)
        {
            _settings.CurrentHealth += heal;
            if (_settings.CurrentHealth > _settings.MaxHealth)
                _settings.CurrentHealth = _settings.MaxHealth;
            _UIChannel?.Update(CurrentHealth);

        }


    }



}