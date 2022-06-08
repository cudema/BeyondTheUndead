using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EXPBar : MonoBehaviour
{
    public Image expBar;

    public void SetExpUI(int exp, int expFigure)
    {
        expBar.fillAmount = (float)exp / expFigure;
    }
}
