using System;
using DefaultNamespace.Bonuses;
using DefaultNamespace.Bonuses.Trackers;

namespace DefaultNamespace
{
    public class LevelEvents
    {
        public event Action<DoubleClickBonus> DoubleAttackBonusCollected;
        public event Action<FreezeBonus> FreezeBonusCollected;
        public event Action<GrowthBonus> GrowthBonusCollected;
    }
}