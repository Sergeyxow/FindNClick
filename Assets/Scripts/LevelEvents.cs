using System;
using DefaultNamespace.Bonuses;
using DefaultNamespace.Bonuses.Trackers;

namespace DefaultNamespace
{
    public class LevelEvents
    {
        public Action<DoubleClickBonus> DoubleAttackBonusCollected;
        public Action<FreezeBonus> FreezeBonusCollected;
        public Action<GrowthBonus> GrowthBonusCollected;
    }
}