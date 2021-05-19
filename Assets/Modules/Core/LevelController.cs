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
        
        private SessionData _sessionData;
        
        private LevelInitializer _levelInitializer;
        private LevelStateTracker _levelStateTracker;

        
        [Inject]
        private void Construct(SessionData sessionData, LevelInitializer levelInitializer, LevelStateTracker levelStateTracker)
        {
            _sessionData = sessionData;
            _levelInitializer = levelInitializer;
            _levelStateTracker = levelStateTracker;
        }
        
        private void Awake()
        {
            if (!_sessionData.Initialized)
            {
                SceneManager.LoadScene(0, LoadSceneMode.Single);
                return;
            }
        }

        private void Start()
        {
            _levelInitializer.InitializeLevel();
            _levelStateTracker.Activate();
        }
    }
}
