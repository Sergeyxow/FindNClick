using System;
using Modules.Data;
using UnityEngine;
using UnityEngine.SceneManagement;
using Plugins.DataSave;
using Zenject;

namespace Modules.Core
{
    public class LevelController : MonoBehaviour
    {
        public event Action<bool> OnLevelFinished;
        
        private LevelData _levelData;
        private SaverBase<PlayerData> _playerDataSaver;
        private SessionData _sessionData;

        [Inject]
        private void Construct(SaverBase<PlayerData> playerDataSaver, SessionData sessionData, LevelData levelData)
        {
            _playerDataSaver = playerDataSaver;
            _sessionData = sessionData;
            _levelData = levelData;
        }
        
        private void Awake()
        {
            if (!_sessionData.Initialized)
            {
                SceneManager.LoadScene(0, LoadSceneMode.Single);
            }
        }
        public void OnWin()
        {
            _playerDataSaver.Instance.LevelIdx++;
            _playerDataSaver.Save();
            OnLevelFinished?.Invoke(true);
        }
        
        public void OnLose()
        {
            OnLevelFinished?.Invoke(false);
        }
        
    }
}
