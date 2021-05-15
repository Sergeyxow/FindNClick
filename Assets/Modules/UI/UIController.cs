using System;
using UnityEngine;

namespace Modules.UI
{
    public class UIController : MonoBehaviour
    {
        public Canvas Canvas;
        public Screen GameHUD;
        public Screen WinScreen;
        public Screen LoseScreen;

        public void HideAll()
        {
            GameHUD.Hide();
            WinScreen.Hide();
            LoseScreen.Hide();
        }
    }
}