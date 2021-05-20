using Bonuses;
using Zenject;

namespace DefaultNamespace.Bonuses
{
    public class DoubleAttackBonus : BonusBase
    {
        public float Duration;

        public override void OnCollected()
        {
            _levelEvents.DoubleAttackBonusCollected?.Invoke(this);
            Destroy(gameObject);
        }
    }
}