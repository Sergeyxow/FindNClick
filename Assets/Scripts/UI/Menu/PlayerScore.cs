using DefaultNamespace.Common;
using TMPro;
using UnityEngine;

namespace DefaultNamespace.UI
{
    public class PlayerScore : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _playerTextBox, _scoreTextBox;

        public void Init(UserScore userScore)
        {
            _playerTextBox.text = userScore.name;
            _scoreTextBox.text = userScore.time.ToString("0.0");
        }
    }
}