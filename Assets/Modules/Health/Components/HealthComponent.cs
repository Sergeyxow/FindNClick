using UnityEngine;
using UnityEngine.Events;

namespace Modules.Health
{
    public class HealthComponent : MonoBehaviour
    {
        public float MaxHealth;
        
        public UnityEvent<float> HealthChanged;
        public UnityEvent HealthIsOut;

        private float _health;
        
        public float Health
        {
            get => _health;
            set
            {
                _health = Mathf.Clamp(value, 0f, MaxHealth);
                HealthChanged?.Invoke(_health);
                if (_health <= 0f)
                    HealthIsOut?.Invoke();
            }
        }

        public void IncreaseHealth(float health)
        {
            Health += health;
        }
        
        public void DecreaseHealth(float health)
        {
            Health -= health;
        }
    }
}