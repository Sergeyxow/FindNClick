using System;
using UnityEngine;

namespace Modules.UI
{
    public class Screen : MonoBehaviour
    {
        public Widget[] Widgets;
        [SerializeField] private bool _autoShow;

        public bool IsShown => _isShown;
        private bool _isShown;

        private void Start()
        {
            if (_autoShow)
                Show();
        }

        public virtual void Show()
        {
            if (_isShown)
                return;
            
            _isShown = true;
            gameObject.SetActive(true);

            foreach (var widget in Widgets)
            {
                widget.Show();
            }
        }
        
        public virtual void Hide()
        {
            if (!_isShown)
                return;
            
            _isShown = false;
            gameObject.SetActive(false);

            foreach (var widget in Widgets)
            {
                widget.Hide();
            }
        }

        public T GetWidget<T>() where T : Widget
        {
            foreach (Widget widget in Widgets)
            {
                if (widget is T w)
                {
                    return w;
                }
            }

            return null;
        }

        public bool TryGetWidget<T>(out T widget) where T : Widget
        {
            widget = GetWidget<T>();

            return widget != null;
        }
    }
}
