using UnityEngine;
using UnityEngine.Events;

namespace Modules.Utils.Components
{
    public class HealthComponent : MonoBehaviour
    {
        public UnityEvent<float> HealthChanged;
        public UnityEvent HealthIsOut;

        [SerializeField] private float _maxHealth;
        private float _health;
        
        public float Health
        {
            get => _health;
            set
            {
                _health = Mathf.Clamp(value, 0f, _maxHealth);
                HealthChanged?.Invoke(_health);
                if (_health <= 0f)
                    HealthIsOut?.Invoke();
            }
        }

        public void ChangeHealth(float health)
        {
            Health += health;
        }
    }
}