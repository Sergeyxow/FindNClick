using Bonuses;
using Zenject;

namespace DefaultNamespace.Bonuses
{
    public class DoubleClickBonus : BonusBase
    {
        public float Duration;

        public override void OnCollected()
        {
            _levelEvents.DoubleAttackBonusCollected?.Invoke(this);
        }
    }
}