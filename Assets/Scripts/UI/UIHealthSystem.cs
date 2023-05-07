using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHealthSystem : MonoBehaviour
{
    [SerializeField] Slider healthSlider;
    public void SetSlider(float baseHealth, float Health)
    {
        healthSlider.maxValue = baseHealth;
        healthSlider.value = Health;
    }
}
