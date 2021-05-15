using Modules.Data;
using Plugins.DataSave;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Modules.Core
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] private LoadSceneMode _loadSceneMode;
        
        private SessionData _sessionData;

        [Inject]
        public void Construct(SessionData sessionData)
        {
            _sessionData = sessionData;
        }

        private void Start()
        {
            _sessionData.Initialized = true;

            UnityEngine.Input.multiTouchEnabled = false;

            int sceneIndex = _sessionData.LoadSceneIndex;
            
            if (sceneIndex != 0)
            {
                SceneManager.LoadScene(sceneIndex, _loadSceneMode);
            }
            else
            {
                SceneManager.LoadScene(1);
            }
        }
    }
}
