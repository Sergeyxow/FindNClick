using DefaultNamespace;
using Modules.Data;
using UnityEngine;
using Zenject;

namespace Modules.Core
{
    public class LevelInitializer
    {
        private LevelData _levelData;
        private SessionData _sessionData;
        private LevelDescriptionCollection _levelDescriptionCollection;
        private LevelGameplayDataCollection _levelGameplayDataCollection;

        
        [Inject]
        private void Construct(
            SessionData sessionData, 
            LevelData levelData,
            LevelDescriptionCollection levelDescriptionCollection, 
            LevelGameplayDataCollection levelGameplayDataCollection)
        {
            _sessionData = sessionData;
            _levelData = levelData;
            _levelDescriptionCollection = levelDescriptionCollection;
            _levelGameplayDataCollection = levelGameplayDataCollection;
        }

        public void InitializeLevel()
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
    }
}