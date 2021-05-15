using DG.Tweening;
using UnityEngine;

namespace Modules.UI
{
    public class DelayShowWidget : Widget
    {
        [SerializeField] private float _delay;
        public override void Show()
        {
            gameObject.SetActive(false);

            DOTween.Sequence().AppendInterval(_delay).OnComplete(() => gameObject.SetActive(true));
        }
    }
}