using DG.Tweening;
using UnityEngine;
using Zenject;

namespace DefaultNamespace.Bonuses.Trackers
{
    public class GrowthBonusTracker : MonoBehaviour
    {
        [SerializeField] private Transform _target;
        private LevelEvents _levelEvents;

        [Inject]
        private void Construct(LevelEvents levelEvents)
        {
            _levelEvents = levelEvents;
        }

        private void OnEnable()
        {
            _levelEvents.GrowthBonusCollected += OnGrowthBonusCollected;
        }

        private void OnDisable()
        {
            _levelEvents.GrowthBonusCollected -= OnGrowthBonusCollected;
        }

        private void OnGrowthBonusCollected(GrowthBonus bonus)
        {
            this.DOComplete();
            this.DOKill();
            
            Sequence sequence = DOTween.Sequence();
            sequence.Append(_target.DOScale(bonus.ScaleMultiplier, 0.25f));
            sequence.AppendInterval(bonus.Duration / 2f);
            sequence.SetLoops(2, LoopType.Yoyo);
            sequence.Play();
        }
    }
}