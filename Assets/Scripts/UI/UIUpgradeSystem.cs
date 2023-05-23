using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIUpgradeSystem : MonoBehaviour
{
    [SerializeField] UIShopElement[] uIUpgradeItems;
    [SerializeField] RarityScriptableObject rarityScriptableObject;
    private UpgradeScriptableObject[] pool;
    private UpgradeSystem upgradeSystem;
    // Start is called before the first frame update
    private void Start()
    {
        upgradeSystem = new UpgradeSystem();
        TryShowUpgrades();
    }

    private IEnumerator ShowUpgrades(UpgradeScriptableObject[] selectedPool)
    {
        int i = 0;
        foreach (UpgradeScriptableObject upgradeScriptableObject in selectedPool)
        {
            uIUpgradeItems[i].backGround.gameObject.SetActive(true);
            uIUpgradeItems[i].imageSprite.sprite = upgradeScriptableObject.upgradeSprite;
            uIUpgradeItems[i].name.text = upgradeScriptableObject.name;
            uIUpgradeItems[i].stats.text = upgradeScriptableObject.upgradeDescription;
            switch (upgradeScriptableObject.rarity)
            {
                case 0:
                    uIUpgradeItems[i].backGround.color = rarityScriptableObject.rarityColours[0].imageColor;
                    uIUpgradeItems[i].name.color = rarityScriptableObject.rarityColours[0].textColor;
                    break;
                case 1:
                    uIUpgradeItems[i].backGround.color = rarityScriptableObject.rarityColours[1].imageColor;
                    uIUpgradeItems[i].name.color = rarityScriptableObject.rarityColours[1].textColor;
                    break;
                case 2:
                    uIUpgradeItems[i].backGround.color = rarityScriptableObject.rarityColours[2].imageColor;
                    uIUpgradeItems[i].name.color = rarityScriptableObject.rarityColours[2].textColor;
                    break;
                case 3:
                    uIUpgradeItems[i].backGround.color = rarityScriptableObject.rarityColours[3].imageColor;
                    uIUpgradeItems[i].name.color = rarityScriptableObject.rarityColours[3].textColor;
                    break;
            }
            i++;
        }
        yield return 0;
    }

    private IEnumerator HideUpgrades()
    {
        foreach (UIShopElement uIShopElement in uIUpgradeItems)
        {
            uIShopElement.backGround.gameObject.SetActive(false);
        }
        yield return 0;
    }

    private void TryShowUpgrades()
    {
        if (upgradeSystem.CanShowUpgrades())
        {
            pool = upgradeSystem.GetUpgrades();
            StartCoroutine(ShowUpgrades(pool));
        }
        else
        {
            StartCoroutine(HideUpgrades());
        }
    }

    public void Buy(int upgradeIndex)
    {
        upgradeSystem.AddStats(upgradeIndex);
        StartCoroutine(HideUpgrades());
        TryShowUpgrades();
    }
}
