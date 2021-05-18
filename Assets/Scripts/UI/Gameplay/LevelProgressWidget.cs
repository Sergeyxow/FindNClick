using Modules.Data;
using Modules.Health;
using Modules.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace DefaultNamespace.UI.Gameplay
{
    public class LevelProgressWidget : Widget
    {
        [SerializeField] private Slider _slider;
        [SerializeField] private TextMeshProUGUI _currentTextBox, _maxTextBox;
        
        private LevelData _levelData;
        private float _maxHealth;

        [Inject]
        public void Construct(LevelData levelData)
        {
            _levelData = levelData;
        }

        public override void Show()
        {
            base.Show();
            HealthComponent healthComponent = _levelData.EnemyActor.HealthComponent;
            healthComponent.HealthChanged.AddListener(OnHealthChanged);
            _maxHealth = healthComponent.MaxHealth;
            Init(_maxHealth);
        }

        public override void Hide()
        {
            base.Hide();
            _levelData.EnemyActor.HealthComponent.HealthChanged.RemoveListener(OnHealthChanged);
        }

        private void Init(float maxValue)
        {
            _slider.maxValue = maxValue;
            _slider.value = 0f;
            _maxTextBox.text = "/" + maxValue.ToString("0.");
            _currentTextBox.text = "0";
        }

        private void OnHealthChanged(float health)
        {
            _slider.value = _maxHealth - health;
            _currentTextBox.text = (_maxHealth - health).ToString("0.");
        }
    }
}