using System;
using DefaultNamespace.Common;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace.UI
{
    public class LevelPopup : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _titleTextBox;
        [SerializeField] private StarsBox _starsBox;
        [SerializeField] private Image _backgroundImage;
        [SerializeField] private Image _avatarImage;

        public event Action<int> PlayClicked;
        public event Action CloseClicked;
        
        private int _id;
        private LevelDescription _levelDescription;
        private LevelStatistics _levelStatistics;

        public void UpdateInformation(int id, LevelDescription levelDescription, LevelStatistics levelStatistics)
        {
            _id = id;
            _levelStatistics = levelStatistics;
            _levelDescription = levelDescription;
            
            UpdateView();
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        public void UpdateView()
        {
            _titleTextBox.text = _levelDescription.Name;
            _backgroundImage.sprite = _levelDescription.BackgroundSprite;
            _avatarImage.sprite = _levelDescription.AvatarSprite;
            _starsBox.Show(_levelStatistics.stars);
        }
    }
}