using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    public Image hpBar;

    public void SetHpUI(int hp)
    {
        hpBar.fillAmount = (float)hp / 3;
    }
}
