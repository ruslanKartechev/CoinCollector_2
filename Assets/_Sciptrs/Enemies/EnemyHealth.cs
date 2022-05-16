using UnityEngine;
using System;
namespace MyGame
{
    public class EnemyHealth : IDamagable
    {
        public bool TakeDamage = true;
        public event Action OnDamaged;
        public event Action OnZeroHealth;
        public int CurrentHealth { get => _settings.CurrentHealth; }
        [SerializeField] private SimpleHealthSettings _settings;

        public EnemyHealth(SimpleHealthSettings settings)
        {
            _settings = settings;
        }

        void IDamagable.TakeDamage(int damage)
        {
            _settings.CurrentHealth -= damage;
            OnDamaged?.Invoke();
            if (_settings.CurrentHealth <= 0)
                OnZeroHealth?.Invoke();
        }

    }



}