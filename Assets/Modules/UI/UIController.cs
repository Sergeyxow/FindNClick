using System;
using Modules.Core;
using UnityEngine;
using Zenject;

namespace Modules.UI
{
    public class UIController : MonoBehaviour
    {
        public Canvas Canvas;
        public Screen GameHUD;
        public Screen WinScreen;
        
        private LevelStateTracker _levelStateTracker;

        [Inject]
        private void Construct(LevelStateTracker levelController)
        {
            _levelStateTracker = levelController;
        }

        private void Start()
        {
            GameHUD.Show();
        }

        private void OnEnable()
        {
            _levelStateTracker.LevelFinished += OnLevelFinished;
        }

        private void OnDisable()
        {
            _levelStateTracker.LevelFinished -= OnLevelFinished;
        }

        private void OnLevelFinished(bool win)
        {
            HideAll();
            WinScreen.Show();
        }

        private void HideAll()
        {
            GameHUD.Hide();
            WinScreen.Hide();
        }
    }
}