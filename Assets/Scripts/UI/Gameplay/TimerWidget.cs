using Modules.UI;
using TMPro;
using UnityEngine;
using Zenject;

namespace DefaultNamespace.UI.Gameplay
{
    public class TimerWidget : Widget
    {
        [SerializeField] private TextMeshProUGUI _textBox;
        
        private LevelTimer _levelTimer;

        [Inject]
        private void Construct(LevelTimer levelTimer)
        {
            _levelTimer = levelTimer;
        }
        
        public override void Show()
        {
            base.Show();
            _levelTimer.SecondsUpdated += SecondsUpdated;
        }

        public override void Hide()
        {
            base.Hide();
            _levelTimer.SecondsUpdated -= SecondsUpdated;
        }

        private void SecondsUpdated(int seconds)
        {
            _textBox.text = seconds.ToString();
        }
    }
}