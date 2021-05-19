using System;
using DefaultNamespace;
using DefaultNamespace.Common;
using Modules.Data;
using Plugins.DataSave;
using Zenject;

namespace Modules.Core
{
    public class LevelStateTracker
    {
        public event Action<bool> LevelFinished;
        
        private LevelData _levelData;
        private SaverBase<LevelStatisticsArray> _levelStatisticsSaver;
        private LevelTimer _levelTimer;
        private SessionData _sessionData;
        
        private UserScore _playerFakeScore = new UserScore {id = 0000, name = "You", time = 0f};

        [Inject]
        private void Construct(
            LevelData levelData, SaverBase<LevelStatisticsArray> levelStatisticsSaver, 
            LevelTimer levelTimer, SessionData sessionData)
        {
            _sessionData = sessionData;
            _levelTimer = levelTimer;
            _levelStatisticsSaver = levelStatisticsSaver;
            _levelData = levelData;
        }

        public void Activate()
        {
            _levelData.EnemyActor.HealthComponent.HealthIsOut.AddListener(OnWin);
        }
        
        ~LevelStateTracker()
        {
            _levelData.EnemyActor.HealthComponent.HealthIsOut.RemoveListener(OnWin);
        }
        
        public void OnWin()
        {
            UserScore score = _playerFakeScore;
            score.time = _levelTimer.Time;
            
            _levelStatisticsSaver.Instance.UpdateUserScore(_sessionData.LevelId, score);
            _levelStatisticsSaver.Save();
            
            LevelFinished?.Invoke(true);
        }
        
    }
}