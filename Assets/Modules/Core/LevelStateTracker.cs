using System;
using Modules.Data;
using Zenject;

namespace Modules.Core
{
    public class LevelStateTracker
    {
        public event Action<bool> LevelFinished;
        
        private LevelData _levelData;
        
        [Inject]
        private void Construct(LevelData levelData)
        {
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
            LevelFinished?.Invoke(true);
        }
        
    }
}