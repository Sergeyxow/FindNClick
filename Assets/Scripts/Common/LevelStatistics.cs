using System;
using System.Collections.Generic;

namespace DefaultNamespace.Common
{
    [Serializable]
    public class LevelStatistics
    {
        public int stars;
        public List<UserScore> leaderboard;
    }
}