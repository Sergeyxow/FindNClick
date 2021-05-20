using System;
using DefaultNamespace.Bonuses;
using DefaultNamespace.Bonuses.Trackers;
using DG.Tweening;
using Modules.UI;
using UnityEngine;
using Zenject;

namespace DefaultNamespace.UI.Gameplay
{
    public class BonusBarWidget : Widget
    {
        [SerializeField] private GameObject _doubleAttack, _freeze, _growth;
        private LevelEvents _levelEvents;

        [Inject]
        private void Construct(LevelEvents levelEvents)
        {
            _levelEvents = levelEvents;
        }

        private void OnEnable()
        {
            _levelEvents.DoubleAttackBonusCollected += OnDoubleAttackBonusCollected;
            _levelEvents.FreezeBonusCollected += OnFreezeBonusCollected;
            _levelEvents.GrowthBonusCollected += OnLevelEventsGrowthBonusCollected;
        }

        private void OnDisable()
        {
            _levelEvents.DoubleAttackBonusCollected -= OnDoubleAttackBonusCollected;
            _levelEvents.FreezeBonusCollected -= OnFreezeBonusCollected;
            _levelEvents.GrowthBonusCollected -= OnLevelEventsGrowthBonusCollected;
        }

        private void OnLevelEventsGrowthBonusCollected(GrowthBonus bonus)
        {
            EnableForTime(_growth, bonus.Duration);
        }

        private void OnFreezeBonusCollected(FreezeBonus bonus)
        {
            EnableForTime(_freeze, bonus.Duration);
        }

        private void OnDoubleAttackBonusCollected(DoubleAttackBonus bonus)
        {
            EnableForTime(_doubleAttack, bonus.Duration);
        }

        private void EnableForTime(GameObject obj, float duration)
        {
            obj.SetActive(true);
            DOTween.Sequence().AppendInterval(duration).OnComplete(() => obj.SetActive(false));
        }
    }
}