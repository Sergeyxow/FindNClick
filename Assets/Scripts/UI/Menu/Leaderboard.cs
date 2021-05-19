using System.Collections.Generic;
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

        public void UpdateView(List<UserScore> userStatisticsList)
        {
            userStatisticsList = userStatisticsList.OrderBy(x => x.time).ToList();

            for (int i = _playerScoresParent.childCount - 1; i >= 0 ; i--)
            {
                Destroy(_playerScoresParent.GetChild(i).gameObject);
            }

            for (var i = 0; i < Mathf.Min(userStatisticsList.Count, _maxFields); i++)
            {
                Instantiate(_playerScorePrefab, _playerScoresParent).Init(userStatisticsList[i]);
            }
        }
    }
}