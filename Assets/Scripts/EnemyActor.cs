using Modules.Health;
using UnityEngine;

namespace DefaultNamespace
{
    public class EnemyActor : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private HealthComponent _healthComponent;
        
        public void Init(Sprite sprite, float maxHealth)
        {
            _spriteRenderer.sprite = sprite;
            _healthComponent.MaxHealth = maxHealth;
        }
    }
}