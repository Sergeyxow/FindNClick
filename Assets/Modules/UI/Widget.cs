using UnityEngine;

namespace Modules.UI
{
    public class Widget : MonoBehaviour
    {
        public virtual void Show()
        {
            gameObject.SetActive(true);
        }
        
        public virtual void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}