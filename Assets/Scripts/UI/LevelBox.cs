using System;
using DefaultNamespace.Common;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace DefaultNamespace.UI
{
    public class LevelBox : MonoBehaviour, IPointerDownHandler
    {
        [SerializeField] private TextMeshProUGUI _titleTextBox;
        [SerializeField] private StarsBox _starsBox;
        [SerializeField] private Image _backgroundImage;
        [SerializeField] private Image _avatarImage;

        public event Action<int> Clicked;
        
        private int _id;
        private LevelDescription _levelDescription;
        private LevelStatistics _levelStatistics;

        public void Init(int id, LevelDescription levelDescription, LevelStatistics levelStatistics)
        {
            _id = id;
            _levelStatistics = levelStatistics;
            _levelDescription = levelDescription;
            
            UpdateView();
        }

        public void UpdateView()
        {
            _titleTextBox.text = _levelDescription.Name;
            _backgroundImage.sprite = _levelDescription.BackgroundSprite;
            _avatarImage.sprite = _levelDescription.AvatarSprite;
            _starsBox.Show(_levelStatistics.stars);
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            Clicked?.Invoke(_id);
        }
    }
}