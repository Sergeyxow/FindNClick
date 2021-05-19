using Modules.Health;

namespace DefaultNamespace
{
    public class DoubleHitAttackBehavior : AttackBehavior
    {
        public override void Attack(float damage, DamageableComponent damageable)
        {
            damageable.GetDamage(damage * 2);
        }
    }
}