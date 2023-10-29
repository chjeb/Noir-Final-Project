using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DentedPixel;

public class InvincibilityBar : MonoBehaviour
{
    public GameObject invincibilityBar;
    public int time;

    public void AnimateBar()
    {
        LeanTween.scaleX(invincibilityBar, 1, time).setOnComplete(Reset);
    }

    public void Reset()
    {
        LeanTween.scaleX(invincibilityBar, 0, 0);
    }
}