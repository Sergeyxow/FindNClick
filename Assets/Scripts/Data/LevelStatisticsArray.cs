using System;
using DefaultNamespace.Common;
using UnityEngine;

namespace DefaultNamespace
{
    [Serializable]
    public class LevelStatisticsArray
    {
        public LevelStatistics[] stats;

        public LevelStatisticsArray()
        {
            JsonUtility.FromJsonOverwrite(Resources.Load<TextAsset>("Levels").text, this);
        }
        
        public bool TryGetStatistics(int id, out LevelStatistics outLevelStatistics)
        {
            if (id < stats.Length)
            {
                outLevelStatistics = stats[id];
                return true;
            }

            outLevelStatistics = null;
            return false;
        }

        public void UpdateUserScore(int levelId, UserScore userScore)
        {
            LevelStatistics levelStatistics = stats[levelId];
            
            for (var i = 0; i < stats[levelId].leaderboard.Count; i++)
            {
                if (levelStatistics.leaderboard[i].id == userScore.id)
                {
                    levelStatistics.leaderboard[i] = userScore;
                    return;
                }
            }
            
            levelStatistics.leaderboard.Add(userScore);
        }
    }
}