using System;
using Modules.Data;
using Plugins.DataSave;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Modules.UI
{
    public class SoundButton : MonoBehaviour
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
            UpdateBan(!_playerDataSaver.Instance.SoundEnabled);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(ChangeState);
        }

        private void ChangeState()
        {
            bool newState = !_playerDataSaver.Instance.SoundEnabled;
            _playerDataSaver.Instance.SoundEnabled = newState;
            _playerDataSaver.Save();
            
            UpdateBan(!newState);
        }

        private void UpdateBan(bool on)
        {
            _banImage.gameObject.SetActive(on);
        }
    }
}