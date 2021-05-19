using DefaultNamespace;
using Modules.Data;
using UnityEngine;
using UnityEngine.SceneManagement;
using Plugins.DataSave;

namespace Modules.Core
{
    public class LevelController : MonoBehaviour
    {
        
        private SessionData _sessionData;
        
        private LevelInitializer _levelInitializer;
        private LevelStateTracker _levelStateTracker;

        private void Construct(SessionData sessionData)
        {
            _sessionData = sessionData;
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
