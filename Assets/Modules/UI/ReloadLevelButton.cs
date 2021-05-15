using Modules.Data;
using Plugins.DataSave;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Modules.UI
{
    public class ReloadLevelButton : Widget
    {
        [SerializeField] private Button _button;

        private GameData _gameData;
        private SaverBase<PlayerData> _playerDataSaver;

        [Inject]
        public void Construct(GameData gameData, SaverBase<PlayerData> playerDataSaver)
        {
            _gameData = gameData;
            _playerDataSaver = playerDataSaver;
        }

        public override void Show()
        {
            base.Show();
            _button.onClick.AddListener(Reload);
        }

        public override void Hide()
        {
            base.Hide();
            _button.onClick.RemoveListener(Reload);
        }
        
        private void Reload()
        {
            _gameData.LevelCollection.LoadLevel(_playerDataSaver.Instance.LevelIdx);
        }
    }
}