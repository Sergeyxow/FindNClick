using Modules.Health;

namespace DefaultNamespace
{
    public abstract class AttackBehavior
    {
        public abstract void Attack(float damage, DamageableComponent damageable);
    }
}