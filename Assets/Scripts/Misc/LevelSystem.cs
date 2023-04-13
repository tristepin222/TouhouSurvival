using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LevelSystem : MonoBehaviour
{
    [SerializeField] Slider XPSlider;
    [SerializeField] float MaxXPAmount;
    private float xp;

    private const float RATIO = 0.3f;
    // Start is called before the first frame update
    void Start()
    {
        CalculateNewMaxAmount();
    }
    public void addXP(float amount)
    {
        if (xp >= MaxXPAmount)
        {
            xp = 0;
            GlobalController.Instance.level++;
            GlobalController.Instance.levelToUpgrade++;
            CalculateNewMaxAmount();
        }
        xp += amount;
        XPSlider.value = xp;
    }
    private void CalculateNewMaxAmount()
    {
        XPSlider.maxValue = (GlobalController.Instance.level+1 * GlobalController.Instance.level + 1) / (RATIO * RATIO);
        MaxXPAmount = XPSlider.maxValue;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Loot loot))
        {
            addXP(1f);
            Destroy(collision.gameObject);
        }
    }
}
