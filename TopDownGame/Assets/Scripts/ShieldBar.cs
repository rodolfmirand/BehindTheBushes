using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShieldBar : MonoBehaviour
{
    public Slider slider;

    public void SetMaxShield(int shield){

        slider.maxValue = shield;
        slider.value = shield;
    }

    public void SetShield(int shield){

        slider.value = shield;
    }
}
