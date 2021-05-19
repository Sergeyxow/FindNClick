using System;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Modules.UI
{
    public class ChangeSceneButton : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] [Scene] private int _sceneToLoad;

        private void OnEnable()
        {
            _button.onClick.AddListener(OnClicked);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(OnClicked);
        }

        private void OnClicked()
        {
            SceneManager.LoadScene(_sceneToLoad);
        }
    }
}