using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSystem : MonoBehaviour
{
    [SerializeField] float maxXPAmount;
    [SerializeField] UIXPSystem uIXPSystem;
    private float xp;
    private int level;

    private const float RATIO = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        xp = GlobalController.Instance.xp;
        level = GlobalController.Instance.level;
        maxXPAmount = uIXPSystem.CalculateNewMaxAmount(RATIO, level);
        uIXPSystem.SetAmount(xp);
    }
    public void addXP(float amount)
    {
        GlobalController.Instance.xp += amount;
        if (xp >= maxXPAmount)
        {
            xp = 0;
            level = GlobalController.Instance.level++;
            GlobalController.Instance.xp = 0;
            GlobalController.Instance.levelToUpgrade++;
            maxXPAmount = uIXPSystem.CalculateNewMaxAmount(RATIO, level);
        }
        xp += amount;
        uIXPSystem.SetAmount(xp);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Loot loot))
        {
            if (loot.item.itemType == Item.ItemType.XPOrb)
            {
                addXP(1f);
                Destroy(collision.gameObject);
            }
        }
    }
}
