using NaughtyAttributes;
using Plugins.DataSave;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Modules.Data
{
    [CreateAssetMenu(fileName = "LevelsCollection", menuName = "Modules/Data/LevelsCollection")]
    public class LevelCollection : ScriptableObject
    {
        [Scene] public int[] Levels;
        public void LoadLevel(int levelIndex, LoadSceneMode loadSceneMode = LoadSceneMode.Single)
        {
            SceneManager.LoadScene(Levels[levelIndex % Levels.Length], loadSceneMode);
        }
    }
}
