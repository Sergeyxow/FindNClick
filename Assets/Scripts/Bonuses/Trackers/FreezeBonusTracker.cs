using DG.Tweening;
using UnityEngine;
using Zenject;

namespace DefaultNamespace.Bonuses.Trackers
{
    public class FreezeBonusTracker : MonoBehaviour
    {
        [SerializeField] private JumpInsideAreaComponent _jumpInsideArea;
        private LevelEvents _levelEvents;

        [Inject]
        private void Construct(LevelEvents levelEvents)
        {
            _levelEvents = levelEvents;
        }

        private void OnEnable()
        {
            _levelEvents.FreezeBonusCollected += OnFreezeBonusCollected;
        }

        private void OnDisable()
        {
            _levelEvents.FreezeBonusCollected -= OnFreezeBonusCollected;
        }

        private void OnFreezeBonusCollected(FreezeBonus bonus)
        {
            _jumpInsideArea.CanMove = false;
            this.DOKill();
            DOTween.Sequence().AppendInterval(bonus.Duration).OnComplete(() =>
            {
                _jumpInsideArea.CanMove = true;
            });
        }
    }
}