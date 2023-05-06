using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
public class UpgradeSystem
{
    [SerializeField] GameObject[] images;
    [SerializeField] UpgradeScriptableObject[] upgradeScriptableObjects;
    [SerializeField] RarityColour[] rarityColours;

    private UpgradeScriptableObject[] selectedPool;
    // Start is called before the first frame update
    public bool CanShowUpgrades()
    {
        return (GlobalController.Instance.levelToUpgrade > 0);
    }

    public UpgradeScriptableObject[] GetUpgrades()
    {
        if (upgradeScriptableObjects == null)
        {
            upgradeScriptableObjects = Resources.LoadAll<UpgradeScriptableObject>("ItemScriptableObjects/Upgrades/");
        }
        selectedPool = new UpgradeScriptableObject[5];
        GlobalController.Instance.levelToUpgrade--;
        return CheckWeight();
    }

    private UpgradeScriptableObject[] CheckWeight(float penality = 0)
    {
        int i = 0;
        float weightTotal = CalculateWeightTotal();
        float random = UnityEngine.Random.Range(0, weightTotal - penality);
        foreach (UpgradeScriptableObject upgradeScriptableObject in upgradeScriptableObjects)
        {

            if (random <= upgradeScriptableObject.weight)
            {
                if (i < selectedPool.Length)
                {
                    if (selectedPool[i] == null)
                    {
                        selectedPool[i] = upgradeScriptableObject;
                    }
                }
                i++;

            }
            else
            {
                random -= upgradeScriptableObject.weight/20;
            }
        }

        CheckEmpty();
        return selectedPool;
    }

    private void CheckEmpty()
    {
        for (int i = 0; i < selectedPool.Length; i++)
        {
            if (selectedPool[i] == null)
            {
                CheckWeight();
            }
        }
    }

    private float CalculateWeightTotal()
    {
        float weightTotal = 0f;
        foreach (UpgradeScriptableObject upgradeScriptableObject in upgradeScriptableObjects)
        {
            weightTotal += upgradeScriptableObject.weight;
        }
        return weightTotal;
    }

    public void AddStats(int upgradeIndex)
    {
        switch (selectedPool[upgradeIndex].upgradeName)
        {
            default:
                break;
            case "Health":
                GlobalController.Instance.bonusHealthAmount += selectedPool[upgradeIndex].upgradeValue;
                break;
            case "Damage":
                GlobalController.Instance.bonusDamage += selectedPool[upgradeIndex].upgradeValue;
                break;
            case "AttackSpeed":
                GlobalController.Instance.bonusAttackSpeed += selectedPool[upgradeIndex].upgradeValue;
                break;
            case "Range":
                GlobalController.Instance.bonusRange += selectedPool[upgradeIndex].upgradeValue;
                break;
        }
    }
}
