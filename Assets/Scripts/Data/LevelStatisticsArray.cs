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
    }
}