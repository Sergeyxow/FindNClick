using DefaultNamespace.Common;
using TMPro;
using UnityEngine;

namespace DefaultNamespace.UI
{
    public class PlayerScore : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _playerTextBox, _scoreTextBox;

        public void Init(UserStatistics userStatistics)
        {
            _playerTextBox.text = userStatistics.name;
            _scoreTextBox.text = userStatistics.time.ToString();
        }
    }
}