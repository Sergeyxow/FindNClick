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

        private LevelDescriptionCollection _levelDescriptionCollection;
        private LevelGameplayDataCollection _levelGameplayDataCollection;

        [Inject]
        private void Construct(SaverBase<PlayerData> playerDataSaver, SessionData sessionData, LevelData levelData,
        LevelDescriptionCollection levelDescriptionCollection, 
        LevelGameplayDataCollection levelGameplayDataCollection)
        {
            _playerDataSaver = playerDataSaver;
            _sessionData = sessionData;
            _levelData = levelData;
            _levelDescriptionCollection = levelDescriptionCollection;
            _levelGameplayDataCollection = levelGameplayDataCollection;
        }
        
        private void Awake()
        {
            if (!_sessionData.Initialized)
            {
                SceneManager.LoadScene(0, LoadSceneMode.Single);
                return;
            }

            InitializeLevel();
        }

        private void Start()
        {
            _levelData.EnemyActor.HealthComponent.HealthIsOut.AddListener(OnWin);
        }

        private void OnDestroy()
        {
            _levelData.EnemyActor.HealthComponent.HealthIsOut.RemoveListener(OnWin);
        }

        private void InitializeLevel()
        {
            if (_levelDescriptionCollection.TryGetDescription(_sessionData.LevelId, out LevelDescription levelDescription))
            {
                if (_levelGameplayDataCollection.TryGetStatistics(_sessionData.LevelId,
                    out LevelGameplayData levelGameplayData))
                {
                    _levelData.BackgroundImage.sprite = levelGameplayData.Background;
                    _levelData.EnemyActor.Init(levelDescription.AvatarSprite, levelGameplayData.ClicksToKill);
                    return;
                }
            }
            
            Debug.LogError("Level initialization went wrong!");
        }

        public void OnWin()
        {
            LevelFinished?.Invoke(true);
        }
        
    }
}
