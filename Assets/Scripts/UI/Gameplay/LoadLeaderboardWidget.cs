using System.Collections.Generic;
using DefaultNamespace.Common;
using Modules.Data;
using Modules.UI;
using Plugins.DataSave;
using UnityEngine;
using Zenject;

namespace DefaultNamespace.UI.Gameplay
{
    public class LoadLeaderboardWidget : Widget
    {
        [SerializeField] private Leaderboard _leaderboard;
        private SaverBase<LevelStatisticsArray> _levelStatisticsSaver;
        private SessionData _sessionData;

        [Inject]
        private void Construct(SaverBase<LevelStatisticsArray> levelStatisticsSaver, SessionData sessionData)
        {
            _sessionData = sessionData;
            _levelStatisticsSaver = levelStatisticsSaver;
        }

        public override void Show()
        {
            base.Show();
            int levelId = _sessionData.LevelId;
            List<UserScore> userStatisticsList = _levelStatisticsSaver.Instance.stats[levelId].leaderboard;
            _leaderboard.UpdateView(userStatisticsList);
        }
    }
}