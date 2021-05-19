using System;
using DefaultNamespace;
using Modules.Data;
using UnityEngine;
using UnityEngine.SceneManagement;
using Plugins.DataSave;
using Zenject;

namespace Modules.Core
{
    public class LevelController : MonoBehaviour
    {
        public event Action<bool> LevelFinished;
        
        private LevelData _levelData;
        private SaverBase<PlayerData> _playerDataSaver;
        private SessionData _sessionData;
        private  LevelInitializer _levelInitializer;

        [Inject]
        private void Construct(SaverBase<PlayerData> playerDataSaver, SessionData sessionData, LevelData levelData,
        LevelDescriptionCollection levelDescriptionCollection, 
        LevelGameplayDataCollection levelGameplayDataCollection)
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
                return;
            }

            _levelInitializer.InitializeLevel();
        }

        private void Start()
        {
            _levelData.EnemyActor.HealthComponent.HealthIsOut.AddListener(OnWin);
        }

        private void OnDestroy()
        {
            _levelData.EnemyActor.HealthComponent.HealthIsOut.RemoveListener(OnWin);
        }

        public void OnWin()
        {
            LevelFinished?.Invoke(true);
        }
        
    }
}
