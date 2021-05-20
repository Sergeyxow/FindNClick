using Bonuses;
using DG.Tweening;
using Zenject;

namespace DefaultNamespace.Bonuses.Trackers
{
    public class GrowthBonus : BonusBase
    {
        public float Duration;
        public float ScaleMultiplier;
        public override void OnCollected()
        {
            _levelEvents.GrowthBonusCollected?.Invoke(this);
            Destroy(gameObject);
        }
    }
}