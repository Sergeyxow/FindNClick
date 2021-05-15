using System;
using Modules.Data;
using NaughtyAttributes;
using Plugins.DataSave;
using UnityEngine;

namespace Modules.Data
{
    [CreateAssetMenu(fileName = "PlayerDataConfigurator", menuName = "Modules/Data/PlayerDataConfigurator")]
    public class PlayerDataConfigurator : ScriptableObject
    {
        [SerializeField] private PlayerData _playerData;
        private SaverBase<PlayerData> _playerDataSaver;

        private void OnEnable()
        {
            Load();
        }

        [Button()]
        public void Load()
        {
            _playerData = _playerDataSaver.Instance;
        }

        [Button()]
        public void Save()
        {
            _playerData = _playerDataSaver.Instance = _playerData;
            _playerDataSaver.Save();
        }

        [ContextMenu("Clean")]
        private void Clean()
        {
            _playerData = new PlayerData();
        }
    }
}