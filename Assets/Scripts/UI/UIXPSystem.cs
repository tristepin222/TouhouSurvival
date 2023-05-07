using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIXPSystem : MonoBehaviour
{
    [SerializeField] Slider XPSlider;
    public void SetAmount(float xp)
    {
        XPSlider.value = xp;
    }
    public float CalculateNewMaxAmount(float ratio, int level)
    {
        return XPSlider.maxValue = (level + 1 * level + 1) / (ratio * ratio);
    }
}
