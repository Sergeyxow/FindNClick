using System;

namespace DefaultNamespace.Common
{
    [Serializable]
    public class LevelStatistics
    {
        public int stars;
        public UserStatistics[] leaderboard;
    }
}