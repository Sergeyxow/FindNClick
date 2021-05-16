using NaughtyAttributes;
using Plugins.DataSave;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Modules.Data
{
    [CreateAssetMenu(fileName = "LevelsCollection", menuName = "Modules/Data/LevelsCollection")]
    public class LevelCollection : ScriptableObject
    {
        public int[] Levels;
    }
}
