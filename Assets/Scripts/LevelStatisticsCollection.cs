using System;
using System.Collections.Generic;
using System.IO;
using DefaultNamespace.Common;
using NaughtyAttributes;
using UnityEngine;

namespace DefaultNamespace
{
    [CreateAssetMenu(fileName = "LevelStatisticsCollection", menuName = "LevelStatisticsCollection")]
    public class LevelStatisticsCollection : ScriptableObject
    {
        public LevelStatisticsArray LevelStatisticsArray;

        [SerializeField] private string _path = "/Data/Levels.json";

        [Button()]
        private void LoadFromJson()
        {
            try
            {
                LevelStatisticsArray = JsonUtility.FromJson<LevelStatisticsArray>(File.ReadAllText(Application.dataPath + _path));
            }
            catch (Exception e)
            {
                Debug.LogError(e);
            }
        }
    }

    [Serializable]
    public class LevelStatisticsArray
    {
        public LevelStatistics[] stats;
    }
}