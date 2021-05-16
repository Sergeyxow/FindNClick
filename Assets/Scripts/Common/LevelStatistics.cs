using System;

namespace DefaultNamespace.Common
{
    [Serializable]
    public class LevelStatistics
    {
        public int Stars;
        public UserStatistics[] Leaderboard;
    }
}