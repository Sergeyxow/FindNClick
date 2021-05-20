using System;
using Modules.Data;
using Plugins.DataSave;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Modules.UI
{
    public class MusicButton : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private Image _banImage;

        private SaverBase<PlayerData> _playerDataSaver;

        [Inject]
        private void Construct(SaverBase<PlayerData> playerDataSaver)
        {
            _playerDataSaver = playerDataSaver;
        }

        private void OnEnable()
        {
            _button.onClick.AddListener(ChangeState);
            UpdateBan(!_playerDataSaver.Instance.MusicEnabled);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(ChangeState);
        }

        private void ChangeState()
        {
            bool newState = !_playerDataSaver.Instance.MusicEnabled;
            _playerDataSaver.Instance.MusicEnabled = newState;
            _playerDataSaver.Save();
            
            UpdateBan(!newState);
        }

        private void UpdateBan(bool on)
        {
            _banImage.gameObject.SetActive(on);
        }
    }
}