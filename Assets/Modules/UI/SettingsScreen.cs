using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Modules.UI
{
    public class SettingsScreen : MonoBehaviour
    {
        [SerializeField] private Button _gearButton;
        [SerializeField] private RectTransform _soundPad;
        [SerializeField] private RectTransform _soundPadEnabledPoint, _soundPadDisabledPoint;

        private bool _soundPadIsOn;
        private bool _soundPadIsMoving;

        private void Start()
        {
            _gearButton.onClick.AddListener(OnGearClicked);
        }

        private void OnGearClicked()
        {
            if (_soundPadIsMoving)
                return;

            _soundPadIsOn = !_soundPadIsOn;
            MoveSoundPad(_soundPadIsOn);
        }

        private void MoveSoundPad(bool targetState)
        {
            _soundPadIsMoving = true;
            
            Vector2 anchorPosition = targetState
                ? _soundPadEnabledPoint.anchoredPosition
                : _soundPadDisabledPoint.anchoredPosition;

            _soundPad.DOComplete();
            _soundPad.DOKill();
            _soundPad.DOAnchorPos(anchorPosition, 0.25f).OnComplete(() => _soundPadIsMoving = false);
        }
    }
}