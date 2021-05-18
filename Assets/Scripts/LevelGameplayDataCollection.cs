using UnityEngine;

namespace DefaultNamespace
{
    public class LevelGameplayDataCollection : ScriptableObject
    {
        [SerializeField] private LevelGameplayData[] _levelGameplayDataArray;

        public bool TryGetStatistics(int id, out LevelGameplayData outLevelGameplayData)
        {
            if (id < _levelGameplayDataArray.Length)
            {
                outLevelGameplayData = _levelGameplayDataArray[id];
                return true;
            }

            outLevelGameplayData = null;
            return false;
        }
    }
}