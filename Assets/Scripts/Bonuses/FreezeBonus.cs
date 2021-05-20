using Bonuses;
using Zenject;

namespace DefaultNamespace.Bonuses
{
    public class FreezeBonus : BonusBase
    {
        public float Duration;
        public override void OnCollected()
        {
            _levelEvents.FreezeBonusCollected?.Invoke(this);
            Destroy(gameObject);
        }
    }
}