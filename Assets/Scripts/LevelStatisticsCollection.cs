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
        public LevelStatistics[] LevelStatisticsArray;

        [SerializeField] private string _path = "/Data/Levels.json";

        [Button()]
        private void LoadFromJson()
        {
            try
            {
                LevelStatistics[] array = JsonUtility.FromJson<List<LevelStatistics>>(File.ReadAllText(Application.dataPath + _path)).ToArray();
                LevelStatisticsArray = array;
            }
            catch (Exception e)
            {
                Debug.LogError(e);
            }
        }
    }
}