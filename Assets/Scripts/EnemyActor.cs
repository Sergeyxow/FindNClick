using Modules.Health;
using UnityEngine;

namespace DefaultNamespace
{
    public class EnemyActor : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;
        public HealthComponent HealthComponent;
        
        public void Init(Sprite sprite, float maxHealth)
        {
            _spriteRenderer.sprite = sprite;
            HealthComponent.MaxHealth = maxHealth;
        }
    }
}