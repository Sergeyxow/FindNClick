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
        
        private LevelController _levelController;

        [Inject]
        private void Construct(LevelController levelController)
        {
            _levelController = levelController;
        }

        private void Start()
        {
            GameHUD.Show();
        }

        private void OnEnable()
        {
            _levelController.LevelFinished += OnLevelFinished;
        }

        private void OnDisable()
        {
            _levelController.LevelFinished -= OnLevelFinished;
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