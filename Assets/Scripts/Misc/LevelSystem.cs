using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LevelSystem : MonoBehaviour
{
    [SerializeField] Slider XPSlider;
    [SerializeField] float MaxXPAmount;
    private float xp;
    // Start is called before the first frame update
    void Start()
    {
        XPSlider.maxValue = MaxXPAmount;
    }
    public void addXP(float amount)
    {
        xp += amount;
        XPSlider.value = xp;
    }

}
