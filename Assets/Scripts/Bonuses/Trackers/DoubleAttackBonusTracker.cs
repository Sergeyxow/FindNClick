using System;
using DG.Tweening;
using UnityEngine;
using Zenject;

namespace DefaultNamespace.Bonuses.Trackers
{
    public class DoubleAttackBonusTracker : MonoBehaviour
    {
        [SerializeField] private ClickAttacker _attacker;
        private LevelEvents _levelEvents;

        private readonly SingleHitAttackBehavior _singleHitAttackBehavior = new SingleHitAttackBehavior();
        private readonly DoubleHitAttackBehavior _doubleHitAttackBehavior = new DoubleHitAttackBehavior();

        
        [Inject]
        private void Construct(LevelEvents levelEvents)
        {
            _levelEvents = levelEvents;
        }

        private void OnEnable()
        {
            _levelEvents.DoubleAttackBonusCollected += OnDoubleAttackBonusCollected;
        }

        private void OnDisable()
        {
            _levelEvents.DoubleAttackBonusCollected -= OnDoubleAttackBonusCollected;
        }

        private void OnDoubleAttackBonusCollected(DoubleAttackBonus bonus)
        {
            _attacker.AttackBehavior = _doubleHitAttackBehavior;
            this.DOKill();
            DOTween.Sequence().AppendInterval(bonus.Duration).OnComplete(() =>
            {
                _attacker.AttackBehavior = _singleHitAttackBehavior;
            });
        }
    }
}






















