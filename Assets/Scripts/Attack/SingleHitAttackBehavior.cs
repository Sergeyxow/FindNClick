using Modules.Health;

namespace DefaultNamespace
{
    public class SingleHitAttackBehavior : AttackBehavior
    {
        public override void Attack(float damage, DamageableComponent damageable)
        {
            damageable.GetDamage(damage);
        }
    }
}