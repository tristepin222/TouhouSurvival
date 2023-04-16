using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
public class UpgradeSystem : MonoBehaviour
{
    [SerializeField] GameObject[] images;
    [SerializeField] UpgradeScriptableObject[] upgradeScriptableObjects;
    [SerializeField] RarityColour[] rarityColours;

    private UpgradeScriptableObject[] selectedPool = new UpgradeScriptableObject[5];
    // Start is called before the first frame update
    void Start()
    {
        if (GlobalController.Instance.levelToUpgrade > 0)
        {
            GlobalController.Instance.levelToUpgrade--;
            StartCoroutine(CheckWeight());
        }
        else
        {
            StartCoroutine(HideUpgrades());
        }
    }
    private IEnumerator CheckWeight(float penality = 0)
    {
        int i = 0;
        foreach (UpgradeScriptableObject upgradeScriptableObject in selectedPool)
        {
            images[i].gameObject.SetActive(true);
            i++;
        }
        i = 0;
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

        StartCoroutine(CheckEmpty());
        yield return 0;
    }
    private IEnumerator CheckEmpty()
    {
        for (int i = 0; i < selectedPool.Length; i++)
        {
            if (selectedPool[i] == null)
            {
                StartCoroutine(CheckWeight());
                yield break;
            }
        }
        StartCoroutine(ShowUpgrades());
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
    private IEnumerator ShowUpgrades()
    {
        int i = 0;
        foreach (UpgradeScriptableObject upgradeScriptableObject in selectedPool)
        {
            TextMeshProUGUI name = images[i].transform.Find("Name").GetComponent<TextMeshProUGUI>();
            Image imageSprite = images[i].transform.Find("Image").GetComponent<Image>();
            Image image = images[i].GetComponent<Image>();
            images[i].transform.Find("Image").GetComponent<Image>().color = upgradeScriptableObject.upgradeColor;
            images[i].transform.Find("Description").GetComponent<TextMeshProUGUI>().text = upgradeScriptableObject.upgradeDescription;
            imageSprite.sprite = upgradeScriptableObject.upgradeSprite;
            name.text = upgradeScriptableObject.upgradeName;
            switch (upgradeScriptableObject.rarity)
            {
                case 0:
                    image.color = rarityColours[0].imageColor;
                    name.color = rarityColours[0].textColor;
                    break;
                case 1:
                    image.color = rarityColours[1].imageColor;
                    name.color = rarityColours[1].textColor;
                    break;
                case 2:
                    image.color = rarityColours[2].imageColor;
                    name.color = rarityColours[2].textColor;
                    break;
                case 3:
                    image.color = rarityColours[3].imageColor;
                    name.color = rarityColours[3].textColor;
                    break;
            }
            i++;
        }
        yield return 0;
    }
    private IEnumerator HideUpgrades()
    {
        int i = 0;
        foreach (UpgradeScriptableObject upgradeScriptableObject in selectedPool)
        {
            images[i].gameObject.SetActive(false);
            i++;
        }
        yield return 0;
    }
    public void Buy(int upgradeIndex)
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
        StartCoroutine(HideUpgrades());
        if (GlobalController.Instance.levelToUpgrade > 0)
        {
            GlobalController.Instance.levelToUpgrade--;
            StartCoroutine(CheckWeight());
        }
    }
}
