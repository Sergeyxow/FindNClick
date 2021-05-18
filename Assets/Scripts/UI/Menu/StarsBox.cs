using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarsBox : MonoBehaviour
{
    [SerializeField] private Image[] _images;
    [SerializeField] private Color _enabledColor, _disabledColor;

    public void Show(int i)
    {
        foreach (Image image in _images)
        {
            if (i > 0)
            {
                image.color = _enabledColor;
                i--;
            }
            else
            {
                image.color = _disabledColor;
            }
        }
    }
}
