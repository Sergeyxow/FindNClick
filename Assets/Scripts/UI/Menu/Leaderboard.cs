using System.Linq;
using DefaultNamespace.Common;
using UnityEngine;

namespace DefaultNamespace.UI
{
    public class Leaderboard : MonoBehaviour
    {
        [SerializeField] private RectTransform _playerScoresParent;
        [SerializeField] private PlayerScore _playerScorePrefab;
        [SerializeField] private int _maxFields = 7;

        public void UpdateView(UserStatistics[] userStatisticsArray)
        {
            userStatisticsArray = userStatisticsArray.OrderBy(x => x.time).ToArray();

            for (int i = _playerScoresParent.childCount - 1; i >= 0 ; i--)
            {
                Destroy(_playerScoresParent.GetChild(i).gameObject);
            }

            for (var i = 0; i < Mathf.Min(userStatisticsArray.Length, _maxFields); i++)
            {
                Instantiate(_playerScorePrefab, _playerScoresParent).Init(userStatisticsArray[i]);
            }
        }
    }
}